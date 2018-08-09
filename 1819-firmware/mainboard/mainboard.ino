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
	pinMode(TX_EN, OUTPUT);
	Serial.begin(SERIAL_BAUD);

	Wire.begin();
	Wire.setClock(400000);

	initIMU();
	initDepth();
	initTools();
	initESCs();
}

/*
 the loop function runs over and over again until power down or reset
*/
void loop() {
	receiveMessage();
	if (receiveProgress == 5) {
		receiveProgress = 0;
		switch (rxData.command) {
			//Actuator commands
			case ESC_CMD:
				writeESCs();
				break; //no need to send data in response to actuator commands
			case TOOLS_CMD:
				writeTools();
				break; //ditto
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
				errorCode = COMMUNICATION_FAILURE;
		}
	}
	handleDataDirection();
}