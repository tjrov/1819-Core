/*
 Name:		mainboard.ino
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

/*
 the setup function runs once when you press reset or power the board
*/
void setup() {
	pinMode(STATUS_LED, OUTPUT);
	digitalWrite(STATUS_LED, HIGH);
	//LED on while starting up

	pinMode(TX_EN, OUTPUT);
	Serial.begin(SERIAL_BAUD);

	Wire.begin();
	Wire.setClock(I2C_CLOCK);

	initStatus();

	//initalize subsystems (status changes based on init errors)
	initIMU();
	initDepth();
	initTools();
	initESCs();
	
	//LED off when ready
	digitalWrite(STATUS_LED, LOW);
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
	else if (status = DISCONNECTED) { 
		//go from disconnected to disarmed after comms return for safety
		status = DISARMED;
	}

	//stop all actuators if the robot is disarmed or disconnected
	if (status != ARMED) {
		emergencyStop();
	}

	controlLED();
}

void processMessage() {
	if (receiveProgress == 5) {
		receiveProgress = 0;
		switch (rxData.command) {
			//Actuator commands
		case ESC_CMD:
			if(status = ARMED)
				writeESCs();
			break; //no need to send data in response to actuator commands
		case TOOLS_CMD:
			if(status = ARMED)
				writeTools();
			break; //ditto
		case STATUS_CMD:
			writeStatus();
			break;

		//Sensor requests
		case IMU_REQ:
			readIMU();
			sendMessage();
			break;
		case ESC_REQ:
			readESCs();
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
		default:
			error = COMMUNICATION_FAILURE;
		}
	}
}

void controlLED() {
	switch (status) {
		case DISCONNECTED:
			//* - - - - - - - - -
			digitalWrite(STATUS_LED, DISCONNECTED_FLASH);
			break;
		case DISARMED:
			//* * * * * * * * * *
			digitalWrite(STATUS_LED, DISARMED_FLASH);
			break;
		case ARMED:
			//* * * * * - - - - -
			digitalWrite(STATUS_LED, ARMED_FLASH);
			break;
	}
}