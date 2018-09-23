/*
 Name:		autopilot_setup.ino
 Created:	8/19/2018 11:34:08 AM
 Author:	Henry
*/

/*Program that helps with setting up ROV
Connect to the ROV serial port with a terminal
like Putty or the Arduino IDE serial monitor.
It's easiest to use underwater*/

#include <Wire.h>
#include "Arduino_I2C_ESC.h"

//array of 6 escs
Arduino_I2C_ESC *escs[6];
uint8_t addresses[6];
uint8_t identifiedAddresses[6];
uint8_t invert[6];

void setup() {
	Serial.begin(500000);
	delay(1000);
	Serial.println("Autopilot board setup utility");
	Serial.println("Scanning I2C devices");

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
			Arduino_I2C_ESC tempESC(i, 6);
			//if it's actually an esc and not another i2c device
			if (tempESC.isAlive()) {
				//store it
				addresses[j] = i;
				escs[j] = &tempESC;
				j++;
				//print as such
				Serial.print(" (ESC)");
			}
			Serial.println();
		}
	}
	delay(7000);

	Serial.println("Thruster identification");
	Serial.println("When the indicated thruster runs, send Y or send N if the direction is inverted");
	Serial.println("Vertical thrusters should pull the ROV upward, and horizontal thrusters should pull it forward");
	
	delay(7000);
	
	Serial.println("Port vertical");
	identifiedAddresses[0] = identifyThruster();
	Serial.println("Starboard vertical");
	identifiedAddresses[1] = identifyThruster();
	Serial.println("Forward port");
	identifiedAddresses[2] = identifyThruster();
	Serial.println("Forward starboard");
	identifiedAddresses[3] = identifyThruster();
	Serial.println("Aft port");
	identifiedAddresses[4] = identifyThruster();
	Serial.println("Aft starboard");
	identifiedAddresses[5] = identifyThruster();

	Serial.println("Results (use in configuration section of autopilot-firmware)");
	Serial.print("#define ESC_ADDRESSES {");
	for (int i = 0; i < 6; i++) {
		Serial.print(identifiedAddresses[i]);
		Serial.print(", ");
	}
	Serial.println("}");
	Serial.print("#define ESC_INVERT {");
	for (int i = 0; i < 6; i++) {
		Serial.print(invert[i]);
		Serial.print(", ");
	}
	Serial.println("}");
}

void loop() {
	//wait for reset cmd
	if (Serial.available()) {
		asm("jmp 0x3800");
	}
}

uint8_t identifyThruster() {
	//repeatedly try all esc addresses
	while (true) {
		for (int i = 0; i < 6; i++) {
			Serial.print("Running thruster at ");
			Serial.println(addresses[i]);
			//run the thruster at low forward speed for a few seconds
			escs[i]->set(1000);
			delay(5000);
			escs[i]->set(0); //stop
			//check for a received Y or N
			if (Serial.available()) {
				char c = Serial.read();
				if (c == 'Y' || c == 'y') {
					Serial.println("Thruster selected (noninverted)");
					invert[i] = 0;
				}
				else if (c == 'N' || c == 'n') {
					Serial.println("Thruster selected (inverted)");
					invert[i] = 1;
				}
				//clear Serial buffer
				while (Serial.available()) {
					Serial.read();
				}
				return addresses[i];
			}
		}
	}
}