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
	Serial.println("Press any key to continue");
	waitInput();
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
	Serial.println("Press any key to continue");
	waitInput();

	Serial.println("Thruster identification");
	Serial.println("1) The program will indicate which thruster it is looking for");
	Serial.println("2) The program will run all available thrusters");
	Serial.println("3) Send any key to continue if the wrong thruster is running");
	Serial.println("4) When the right thruster runs, send an I to invert the direction or N to not invert");
	Serial.println("(Vertical thrusters should generate a force upwards. Horizontal, forwards)");

	Serial.println("Press any key to continue");
	waitInput();

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
		Serial.print(identifiedAddresses[i], HEX);
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

char waitInput() {
	while (!Serial.available());
	char input = Serial.read();
	delay(10);
	//clear Serial buffer
	while (Serial.available()) {
		Serial.read();
	}
	return input;
}

uint8_t identifyThruster() {
	//repeatedly try all esc addresses
	while (true) {
		for (int i = 0; i < 6; i++) {
			Serial.print("Running thruster at ");
			Serial.println(addresses[i], HEX);
			//run the thruster at low forward speed for a few seconds
			escs[i]->set(1000);
			//check for a received C or I or N
			switch (waitInput()) {
			case 'N':
				Serial.println("Thruster selected (noninverted)");
				invert[i] = 0;
				return addresses[i];
			case 'I':
				Serial.println("Thruster selected (inverted)");
				invert[i] = 1;
				return addresses[i];
			}
			escs[i]->set(0); //stop
		}
	}
}