/*
 Name:		autopilot.ino
 Created:	7/6/2018 7:48:15 PM
 Author:	Henry

 Firmware for autopilot board
*/

/*
 Import libraries
*/
#include "Wire.h" //Arduino I2C Library

#include "Arduino_I2C_ESC.h" //ESC over I2C
#include "SparkFun_MS5803_I2C.h" //Pressure sensor
#include "SparkFunLSM9DS1.h" //IMU

#include "Configuration.h"
#include "PinDefinitions.h"
#include "SerialCommunication.h" //Our functions for serial comms

// the setup function runs once when you press reset or power the board
void setup() {
	pinMode(TX_EN, OUTPUT);
	Serial.begin(SERIAL_BAUD);
}

// the loop function runs over and over again until power down or reset
void loop() {
	while (!Serial.available());

}
