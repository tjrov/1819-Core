/*Program that helps with setting up ROV*/

#include <Wire.h>
#include "Arduino_I2C_ESC.h"

//array of 6 escs
Arduino_I2C_ESC *escs[6];
uint8_t addressList[6];

void setup() {
	Serial.begin(250000);

	Serial.println("Autopilot board setup utility");
	Serial.println("Scanning for I2C devices");

	Wire.begin();
	Wire.setClock(400000);

	int j = 0;

	//for all i2c device addresses
	for (int i = 0; i < 127; i++) {
		//attempt to connect
		Wire.beginTransmission(i);
		uint8_t code = Wire.endTransmission();
		//if success
		if (code == 0) {
			//print address
			Serial.println(i);
			//store address
			addresses[j] = i;
			escs[j] = Arduino_I2C_ESC(i, 6);
			//if it's actually an esc and not another i2c device
			if (escs[j]->isAlive()) {
				//don't overwrite it
				j++;
				Serial.print(" (ESC)");
			}
			Serial.println();
		}
	}
}

void loop() {
}