/*
 Name:		mainboard.ino
 Created:	7/7/2018 9:44:39 AM
 Author:	Henry

 Firmware for main board
*/

/*
Import libraries
*/

/*#include <Wire.h> //Arduino I2C Library

#include "Arduino_I2C_ESC.h" //ESC over I2C
#include "SparkFun_MS5803_I2C.h" //Pressure sensor
#include "SparkFunLSM9DS1.h" //IMU*/

#include "SparkFun_MS5803_I2C.h"
#include "SparkFunLSM9DS1.h"
#include "Arduino_I2C_ESC.h"

#include "Configuration.h"
#include "PinDefinitions.h"
#include "SerialCommunication.h" //Our functions for serial comms

uint8_t isArmed = 0, isConnected = 0, errorCode = ALL_SYSTEMS_GO;

// the setup function runs once when you press reset or power the board
void setup() {
	pinMode(TX_EN, OUTPUT);
	Serial.begin(SERIAL_BAUD);
	for (int i = 10; i <= 13; i++) {
		pinMode(i, OUTPUT);
		blink(i);
	}
}

// the loop function runs over and over again until power down or reset
void loop() {
	receiveMessage();
	if (receiveProgress == 5) {
		receiveProgress = 0;
		switch (rxData.command) {
			//Actuator commands
			case ESC_CMD:
				break; //no need to send data in response to actuator commands
			//Sensor requests
			case IMU_REQ:
				txData.command = IMU_REQ;
				txData.length = 6;
				sendMessage();
				break;
			case ESC_REQ:
				txData.command = ESC_REQ;
				txData.length = 12;
				sendMessage();
				break;
			case STATUS_REQ:
				txData.command = STATUS_REQ;
				txData.length = 2;
				txData.data[0] = isArmed << 1 | isConnected;
				txData.data[1] = errorCode;
				sendMessage();
				break;
		}
	}
	handleDataDirection();
}

