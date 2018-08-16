/*
 Name:		motorcontroller.ino
 Created:	7/6/2018 7:48:49 PM
 Author:	Henry

 Firmware for motor controller board
*/

/*CONFIGURATION*/
#define ADDRESS 0x10
#define HEADER_BYTE 0x42
#define TIMEOUT 1000

#include <Wire.h>
#include "PinDefinitions.h"

const uint8_t in1[] = IN1;
const uint8_t in2[] = IN2;

uint32_t lastComms = 0;

uint8_t speeds[] = { 128, 128, 128 };

// the setup function runs once when you press reset or power the board
void setup() {
	initLEDs();
	initMotors();
	Wire.begin(ADDRESS);
	Wire.setClock(400000);
	Wire.onReceive(onReceive); //attach method as event
}

// the loop function runs over and over again until power down or reset
void loop() {
	if (isTimeout()) { //disconnected from autopilot
		digitalWrite(RED, HIGH); //yellow light
		digitalWrite(GREEN, HIGH);
		for (int i = 0; i < 3; i++) {
			speeds[i] = 128; //reset speeds to stopped
			idleMotor(in1[i], in2[i]); //release motors
		}
	}
	else { //in contact with autopilot
		bool isRunning = false;
		//check if any motors are running
		for (int i = 0; i < 3; i++) {
			if (speeds[i] != 128) {
				isRunning = true;
			}
		}
		//control LEDs
		if (isRunning) {
			//flash green
			digitalWrite(RED, LOW);
			digitalWrite(GREEN, (millis() % 1000) < 500);
		}
		else {
			//solid green
			digitalWrite(RED, LOW);
			digitalWrite(GREEN, HIGH);
		}
		//drive motors
		for (int i = 0; i < 3; i++) {
			setMotor(speeds[i], in1[i], in2[i]);
		}
	}
}

/*
 Message format
 0x42 - header
 [0] data bytes
 [1] specify
 [2] motor speeds
  0 - reverse, 128 - stop, 255 - forward
 checksum
*/

void onReceive(int numBytes) {
	if (Wire.available() >= 4) { //full msg
		if (Wire.read() == HEADER_BYTE) { //first byte is header
			for (int i = 0; i < 3; i++) {
				speeds[i] = Wire.read();
			}
			lastComms = millis();
		}
	}
}

void initLEDs() {
	//both leds are outputs
	pinMode(RED, OUTPUT);
	pinMode(GREEN, OUTPUT);

	//flash leds to test them
	digitalWrite(RED, HIGH);
	digitalWrite(GREEN, HIGH);
	delay(125);
	digitalWrite(RED, LOW);
	digitalWrite(GREEN, LOW);
}

void initMotors() {
	for (int i = 0; i < 3; i++) {
		pinMode(in1[i], OUTPUT);
		pinMode(in2[i], OUTPUT);
	}
}

bool isTimeout() {
	return (millis() - lastComms) > TIMEOUT;
}

void setMotor(uint8_t val, uint8_t one, uint8_t two) {
	if (val < 128) {
		analogWrite(one, val * 2);
		digitalWrite(two, HIGH);
	}
	else if (val > 128) {
		digitalWrite(one, HIGH);
		analogWrite(two, (255 - val) * 2);
	}
	else {
		digitalWrite(one, HIGH);
		digitalWrite(two, HIGH);
	}
}

void idleMotor(int one, int two) {
	digitalWrite(one, LOW);
	digitalWrite(two, LOW);
}
