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

MESSAGE txData;

// the setup function runs once when you press reset or power the board
void setup() {
	pinMode(TX_EN, OUTPUT);
	Serial.begin(SERIAL_BAUD);
}

// the loop function runs over and over again until power down or reset
void loop() {
	if (receiveMessage()) {
		sendMessage(rxData); //reply back with same data
		//blink();
	}
	//handleDataDirection();
}

