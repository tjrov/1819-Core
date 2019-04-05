/*
Name:		autopilot.ino
Created:	7/7/2018 9:44:39 AM
Author:	Henry (add names as necessary)

Firmware for main board
*/

/*Firmware version info*/
/*From 0<->255 for each*/

#define VERSION_MAJOR 0
#define VERSION_MINOR 3

/*
Import libraries
*/

#include <Wire.h>

#include "Adafruit_BNO055.h"
#include "SparkFun_MS5803_I2C.h"
#include "Adafruit_PWMServoDriver.h"

/*
Configuration for autopilot board
*/

#define SERIAL_BAUD 115200 //Max tested on tether so far. 500 kbaud possible in theory
#define MAX_PACKET_LENGTH 64 //maximum possible message is 255 bytes, increase to that if needed
#define HEADER_BYTE 0x42
#define SERIAL_TIMEOUT 1000
#define I2C_CLOCK 400000

#define NUM_ESCS 6
#define ESC_ADDRESSES { 0x31, 0x2A, 0x2B, 0x2C, 0x2D, 0x2E }
#define ESC_INVERT {0,0,0,0,0,0}
#define TOOLS_INVERT {0,0,0,0}
#define NUM_POLES 6

#define PCA_9685_ADDRESS 0x40
#define PWM_FREQ 100
//use formula pulse length/period * 4096, must be in [0,4096) to work
#define PWM_MIN 500 //signal on-time values out of a 4096-step period
#define PWM_STOP 590
#define PWM_MAX 680

#define NUM_TOOLS 4
#define NUM_SERVO 2

#define DEPTH_ADDRESS 0x76

#define IMU_ADDRESS 0x28

//#define RESET_DELAY 600 //increases time between receiving reset command and actual reset occuring so that it can coincide with upload start

enum ERROR {
	ALL_SYSTEMS_GO = 0,
	IMU_FAILURE = 1,
	ESC_FAILURE = 2,
	PRESSURE_SENSOR_FAILURE = 4,
	TOOLS_FAILURE = 8,
	INVALID_CHECKSUM = 16,
	INVALID_COMMAND = 32
};

enum STATUS {
	DISCONNECTED = 0,
	DISARMED = 1,
	ARMED = 2,
	REBOOT = 3
};

enum COMMAND {
	IMU_REQ = 0x01,
	ESC_REQ = 0x02,
	DEPTH_REQ = 0x03,
	STATUS_REQ = 0x04,
	VERSION_REQ = 0x05,
	ESC_CMD = 0x81,
	TOOLS_CMD = 0x82,
	STATUS_CMD = 0x83,
	SERVO_CMD = 0x84
};

/*Pin definitions*/
//DO NOT CHANGE PIN DEFS ON MASTER BRANCH WITHOUT ASKING AN ELECTRICAL SUBTEAM MEMBER
#define VOLTAGE_SENSOR A0

#define LED 13

/*End pin definitions*/

//#define TX_EN 2

/*Variable declarations*/
Adafruit_BNO055 bno055 = Adafruit_BNO055();
MS5803 ms5803(ADDRESS_HIGH);
Adafruit_PWMServoDriver pca9685 = Adafruit_PWMServoDriver();

const uint8_t esc_invert[6] = ESC_INVERT;
const uint8_t tools_invert[4] = TOOLS_INVERT;

struct MESSAGE {
	COMMAND command;
	uint8_t length;
	uint8_t data[MAX_PACKET_LENGTH];
};
MESSAGE rxData, txData;

uint8_t receiveProgress, index, calculatedChecksum;
uint32_t lastComms;

ERROR error = ALL_SYSTEMS_GO;
STATUS status = DISCONNECTED;

/*Function prototypes*/
void receiveMessage();
void sendMessage();
bool isTimeout();
bool checkI2C(uint8_t address);
void writeESCs();
void writeTools();
void writeServo();
void checkESCsAndTools();
void initStatus();
void readStatus();
void writeStatus();
void emergencyStop();
double mapDouble(double val, double minVal, double maxVal, double minResult, double maxResult);
void initIMU();
void readIMU();
void initDepth();
void readDepth();
void controlLEDs();
void initLEDs();
void flashError();

/*
the setup function runs once when you press reset or power the board
*/
void setup() {
	//run this first to prevent auto-reset
	//pinMode(RESET, INPUT_PULLUP); //connect RST to 5V with a 10k internal resistance
	pinMode(LED, OUTPUT);
	digitalWrite(LED, HIGH);
	delay(500);
	//pinMode(TX_EN, OUTPUT);
	Serial.begin(SERIAL_BAUD);

	Wire.begin();
    Wire.setClock(I2C_CLOCK);

	initStatus();

	//initalize subsystems (status changes based on init errors)
	initIMU();
	initDepth();
	initToolsAndESCs();
	digitalWrite(LED, LOW);
}

/*
the loop function runs over and over again until power down or reset
*/
void loop() {
	receiveMessage(); //wait for a message
	processMessage(); //act on it by responding with sensor data or writing to an actuator
	//handleDataDirection(); //control the RS-485 data direction pin

	//check whether still connected and set the status variable
	if (isTimeout()) { //state disconnected when no messages received
		status = DISCONNECTED;
	}
	else {
		if (status == DISCONNECTED) {
			//go from disconnected to disarmed
			//after comms return for safety
			status = DISARMED;
		}
	}

	//stop all actuators every .25 sec if the robot is disarmed or disconnected
	if (status != ARMED && millis() % 250 == 0) {
		emergencyStop();
	}

	if (millis() % 100 == 0) {
		checkESCsAndTools();
	}

	controlLEDs();
}

void processMessage() {
	if (receiveProgress == 5) {
		receiveProgress = 0;
		switch (rxData.command) {
			//Actuator commands
		case ESC_CMD:
			if (status == ARMED)
				writeESCs();
			break; //no need to send data in response to actuator commands
		case TOOLS_CMD:
			if (status == ARMED)
				writeTools();
			break; //ditto
		case SERVO_CMD:
			if (status == ARMED)
				writeServo();
			break;
		case STATUS_CMD:
			writeStatus();
			break;
			//Sensor requests
		case IMU_REQ:
			readIMU();
			sendMessage();
			break;
		case DEPTH_REQ:
			readDepth();
			sendMessage();
			break;
		case STATUS_REQ:
			readStatus();
			sendMessage();
			break;
		case VERSION_REQ:
			readVersion();
			sendMessage();
			break;
		default:
			error |= INVALID_COMMAND;
		}
	}
}

/*
Functions for Serial Communication
Protocol is as follows:
Header (0x42)
Command (bit 0 determines whether request or command)
Length of data
Data
Checksum (XOR of length and all data bytes)
*/

/*
Function to be called repeatedly in loop() that receives Serial messages
*/
void receiveMessage() {
	if (Serial.available()) {
		uint8_t c = Serial.read();
		if (c == 0x42) { //new message starting
			receiveProgress = 1;
		}
		else if (receiveProgress == 1) { //command byte
			rxData.command = (COMMAND)c;
			receiveProgress = 2;
		}
		else if (receiveProgress == 2) { //length bytes
			rxData.length = c;
			calculatedChecksum = rxData.length; //checksum begins with length in it
			if (c > 0) { //skip data section for 0-length messages
				receiveProgress = 3;
				index = 0;
			}
			else {
				receiveProgress = 4;
			}
		}
		else if (receiveProgress == 3) { //data bytes
			rxData.data[index] = c;
			calculatedChecksum ^= c; //XOR checksum with all data bytes
			index++;
			if (index >= rxData.length) {
				receiveProgress = 4;
			}
		}
		else if (receiveProgress == 4) { //checksum
			if (c == calculatedChecksum) {
				receiveProgress = 5;
				lastComms = millis();
			}
			else {
				receiveProgress = 0;
				error |= INVALID_CHECKSUM;
			}
		}
		else {
			receiveProgress = 0;
		}
	}
}
void sendMessage() {
	Serial.write(HEADER_BYTE);
	Serial.write(txData.command);
	Serial.write(txData.length);
	uint8_t checksum = txData.length;
	for (int i = 0; i < txData.length; i++) {
		Serial.write(txData.data[i]);
		checksum ^= txData.data[i];
	}
	Serial.write(checksum);
}
bool isTimeout() {
	return (millis() - lastComms) > SERIAL_TIMEOUT;
}

//reads the versioning info
void readVersion() {
	txData.length = 2;
	txData.command = VERSION_REQ;
	//get ready to send versioning info
	txData.data[0] = VERSION_MAJOR;
	txData.data[1] = VERSION_MINOR;
}

//returns true if device at address available
bool checkI2C(uint8_t address) {
	Wire.beginTransmission(address);
	//endtransmission returns 0 only for a successful contact
	return Wire.endTransmission() == 0;
}

/*void handleDataDirection() {
if ((UCSR0A & _BV(TXC0)) == 0) {
digitalWrite(TX_EN, HIGH);
}
else {
digitalWrite(TX_EN, LOW);
}
}*/

/*ESCs*/
void initToolsAndESCs() {
	/*for (int i = 0; i < 6; i++) {
		escs[i].attach(i + 3);
		escs[i].writeMicroseconds(1500);
	}*/
	if (checkI2C(PCA_9685_ADDRESS)) {
		pca9685.begin();
		pca9685.setPWMFreq(PWM_FREQ);
	}
	else {
		error |= TOOLS_FAILURE;
	}
}

void checkESCsAndTools() {
	//check for motor controller device
	if (!checkI2C(PCA_9685_ADDRESS)) {
		error |= TOOLS_FAILURE;
	}
	//reset connection to motor driver after power failures
	if (error & TOOLS_FAILURE) {
		pca9685.reset();
		pca9685.setPWMFreq(PWM_FREQ);
		//if after reset it works
		if (checkI2C(PCA_9685_ADDRESS)) {
			//clear error state
			error &= ~TOOLS_FAILURE;
		}
	}
}

void writeESCs() {
	if (!(error&ESC_FAILURE)) {
		/*for (int i = 0; i < 6; i++) {
			//convert pairs of bytes into 16-bit int
			int16_t speed = rxData.data[i * 2 + 1] << 8 | rxData.data[i * 2];
			//now convert to pulse time length out of 4096
			if (esc_invert[i] == 1) {
				speed = -speed;
			}
			speed = map(speed, -32768, 32767, PWM_MIN, PWM_MAX);
			speed = PWM_MAX;
			escs[i].writeMicroseconds(speed);
		}*/

		for (int i = 0; i < NUM_ESCS; i++) {
			uint8_t speed = rxData.data[i];
			if (esc_invert[i] == 1) {
				speed = 255 - speed;
			}
			if (speed == 127) {
				//stop motor
				pca9685.setPWM(i, 0, PWM_STOP);
			}
			else {
				//run motor forward or reverse
				pca9685.setPWM(i, 0, map(speed, 0, 255, PWM_MIN, PWM_MAX));
			}
		}
	}
}

void writeTools() {
	if (!(error&ESC_FAILURE)) {
		for (int i = 0; i < NUM_TOOLS; i++) {
			uint8_t speed = rxData.data[i];
			if (tools_invert[i] == 1) {
				speed = 255 - speed;
			}
			if (speed == 127) {
				//both pins high to brake when stop requested
				pca9685.setPWM(15 - i * 2, 0, 4095);
				pca9685.setPWM(14 - i * 2, 0, 4095);
			}
			else if (speed < 127) {
				//turn one way
				pca9685.setPWM(15 - i * 2, 0, 0);
				pca9685.setPWM(14 - i * 2, 0, map(speed, 0, 127, 4095, 0));
			}
			else {
				//turn other way
				pca9685.setPWM(15 - i * 2, 0, map(speed, 127, 255, 0, 4095));
				pca9685.setPWM(14 - i * 2, 0, 0);
			}
		}
	}
}

void writeServo() {
	if (!(error&ESC_FAILURE)) {
		for (int i = 0; i < NUM_SERVO; i++) {
			uint8_t position = rxData.data[i];
			// not sure exactly what position variable will be here (it should be 0-255 i think)
			pca9685.setPWM(i, map(position, 0, 255, 0, 4095), map(255 - position, 0, 255, 0, 4095));
		}
	}
}

/*Status*/
void initStatus() {
	error = ALL_SYSTEMS_GO;
	status = DISCONNECTED;
}

void readStatus() {
	txData.command = STATUS_REQ;
	txData.length = 3;
	txData.data[0] = status;
	txData.data[1] = error;
	txData.data[2] = analogRead(VOLTAGE_SENSOR) >> 2;
}

void writeStatus() {
	if (status != rxData.data[0]) { //only change if needed
		switch ((STATUS)rxData.data[0]) {
		case DISARMED:
			if (status == ARMED) {
				status = DISARMED;
			}
			break;
		case ARMED:
			if (status == DISARMED) {
				status = ARMED;
			}
			break;
		case REBOOT:
			break;
			//turn off leds or they will stay on
			/*digitalWrite(RED, LOW);
			digitalWrite(GREEN, LOW);
			digitalWrite(BLUE, LOW);

			pinMode(RESET, OUTPUT); //pull RST to GND
			digitalWrite(RESET, LOW);
			delay(RESET_DELAY);
			digitalWrite(RESET, HIGH); //release RST
			while (1);*/

			//go to the bootloader address in flash memory
			//asm("jmp 0x3800");
		}
	}
}

//call to stop all movement of actuators
void emergencyStop() {
	if (!(error&ESC_FAILURE)) {
		/*for (int i = 0; i < 6; i++) {
			escs[i].writeMicroseconds(1500);
		}*/
		//stop ESCs
		//int stopped = (PWM_MIN + PWM_MAX) / 2; //stopped signal pulse length is halfway between full forward and full reverse
		//Serial.print(PWM_MIN); Serial.print('\t'); Serial.println(PWM_MAX);
		for (int i = 0; i < NUM_ESCS; i++) {
			pca9685.setPWM(i, 0, PWM_STOP);
		}
		//stop motor outputs (coast to a stop instead of braking so that claws will let go
		for (int i = 0; i < NUM_TOOLS; i++) {
			pca9685.setPWM(15 - i * 2, 0, 0);
			pca9685.setPWM(14 - i * 2, 0, 0);
		}
	}
}

double mapDouble(double val, double minVal, double maxVal, double minResult, double maxResult) {
	return ((val - minVal) / (maxVal - minVal) * (maxResult - minResult)) + minResult;
}
/*IMU*/
void initIMU() {
	//try to setup IMU
	if (!bno055.begin()) {
		error |= IMU_FAILURE;
		return;
	}
	bno055.setExtCrystalUse(true);
	//do any configuration of imu here
}

void readIMU() {
	txData.command = IMU_REQ;
	txData.length = 6;
	if (!(error&IMU_FAILURE)) {
		//refresh data from imu
		sensors_event_t imuData;
		bno055.getEvent(&imuData);

		/* Display the data */
		/*Serial.print("Heading: ");
		Serial.print(imuData.orientation.x, 4);
		Serial.print("Pitch: ");
		Serial.print(imuData.orientation.y, 4);
		Serial.print("Roll: ");
		Serial.print(imuData.orientation.z, 4);
		Serial.println("");*/

		/* physical axis directions:
			+----------+
			|         *| RST   PITCH  ROLL  HEADING
		ADR |*        *| SCL
		INT |*        *| SDA     ^            /->
		PS1 |*        *| GND     |            |
		PS0 |*        *| 3VO     Y    Z-->    \-X
			|         *| VIN
			+----------+
		*/

		uint16_t rollInt = (int)mapDouble(imuData.orientation.heading, 0, 360, 0, 65535);
		uint16_t pitchInt = (int)mapDouble(imuData.orientation.pitch, 0, 360, 0, 65535);
		uint16_t headingInt = (int)mapDouble(imuData.orientation.roll, 0, 360, 0, 65535);

		//prepare txData for transmission
		txData.data[0] = headingInt & 0xFF;
		txData.data[1] = (headingInt >> 8) & 0xFF;
		txData.data[2] = pitchInt & 0xFF;
		txData.data[3] = (pitchInt >> 8) & 0xFF;
		txData.data[4] = rollInt & 0xFF;
		txData.data[5] = (rollInt >> 8) & 0xFF;
	}
}
/*Depth*/
void initDepth() {
	//attempt to contact sensor to check if it's available
	//if (checkI2C(DEPTH_ADDRESS)) {
		ms5803.reset();
		ms5803.begin();
	//}
	//else {
		//error |= PRESSURE_SENSOR_FAILURE;
	//}
}

void readDepth() {
	
	txData.command = DEPTH_REQ;
	txData.length = 2;
	if (!(error & PRESSURE_SENSOR_FAILURE)) {
		//subtract pressure of air on surface; it doesn't factor
		//into the pressure caused by the water column
		//depth = pressure / (density * acceleration)
		//where depth is in meters, pressure is in Pascals (N/m^2)
		//density is in kilograms per cubic meter,
		//and acceleration is in meters per second per second
		double depthDouble = (ms5803.getPressure(ADC_1024) - 9230.0) / (1000.0 * 9.81);
		//now convert to bytes and prepare txData
		uint16_t intDepth = (int)mapDouble(depthDouble, 0, 30, 0, 65535);

		txData.data[0] = intDepth & 0xFF;
		txData.data[1] = (intDepth >> 8) & 0xFF;
	}
}

/*
Code for controlling status LEDs
*/

/*
LED codes:

Reboot
Blue flash 2x for bootloader (upload can happen during this time)
Red, green, blue cycle to test lamps
ROV firmware starts
Yellow - disconnected
Green solid - disarmed but connected
Green flashing - armed and connected
Red blinks - error state
*/

void flashError() {
	for (int i = 0; i < 5; i++) {
		digitalWrite(LED, HIGH);
		delay(100);
		digitalWrite(LED, LOW);
		delay(100);
	}
}

void controlLEDs() {
	switch (status) {
	case DISCONNECTED:
		//flash every few seconds
		digitalWrite(LED, (millis() % 2000 < 50));
		break;
	case DISARMED:
		//LED on
		digitalWrite(LED, HIGH);
		break;
	case ARMED:
		//flashing
		digitalWrite(LED, (millis() % 500 < 250));
		break;
	}
	//flash blue 5ms for correctly processed messages
	//digitalWrite(BLUE, (millis() - lastComms) < 5); //too slow to show all msgs
}
