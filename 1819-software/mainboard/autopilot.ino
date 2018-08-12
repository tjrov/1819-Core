/*
 Name:		autopilot.ino
 Created:	7/7/2018 9:44:39 AM
 Author:	Henry (add names as necessary)

 Firmware for main board
*/

/*
 Import libraries
*/

#include <Wire.h>
#include <SPI.h>

#include "SparkFun_MS5803_I2C.h"
#include "SparkFunLSM9DS1.h"
#include "Arduino_I2C_ESC.h"

#include "Configuration.h"
#include "PinDefinitions.h"
#include "SerialCommunication.h" //Our functions for serial comms
#include "Actuators.h" //Initializing and writing to actuators
#include "Sensors.h" //Initializing and reading from sensors
#include "LEDs.h" //Controlling status LED

/*
 the setup function runs once when you press reset or power the board
*/
void setup() {
	MCUSR = 0; //clear register holding cause of board reset
	//prevents interference with bootloader

	digitalWrite(RESET, HIGH); //turn on pullup to RESET pin

	initLEDs();

	pinMode(TX_EN, OUTPUT);
	Serial.begin(SERIAL_BAUD);

	Wire.begin();
	Wire.setClock(I2C_CLOCK);

	initStatus();

	//initalize subsystems (status changes based on init errors)
	//initIMU();
	//initDepth();
	initTools();
	//initESCs();

	if (error != ALL_SYSTEMS_GO) { //if we can't init
		while (true) {
			controlLEDs(); //flash out the error code
		}
	}
}

/*
 the loop function runs over and over again until power down or reset
*/
void loop() {
	receiveMessage(); //wait for a message
	processMessage(); //act on it by responding with sensor data or writing to an actuator
	handleDataDirection(); //control the RS-485 data direction pin

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
	//stop all actuators if the robot is disarmed or disconnected
	if (status != ARMED) {
		//emergencyStop();
	}

	controlLEDs();
}

//printf '\x42\x82\x03\x00\x00\x00\x03' > COM7

void processMessage() {
	if (receiveProgress == 5) {
		receiveProgress = 0;
		switch (rxData.command) {
			//Actuator commands
		case ESC_CMD:
			if (status == ARMED)
				//writeESCs();
			break; //no need to send data in response to actuator commands
		case TOOLS_CMD:
			//if (status == ARMED)
				writeTools();
			break; //ditto
		case STATUS_CMD:
			writeStatus();
			break;

			//Sensor requests
		case IMU_REQ:
			//readIMU();
			sendMessage();
			break;
		case ESC_REQ:
			//readESCs();
			sendMessage();
			break;
		case DEPTH_REQ:
			//readDepth();
			sendMessage();
			break;
		case STATUS_REQ:
			readStatus();
			sendMessage();
			break;
		default:
			error = INVALID_COMMAND;
		}
	}
}