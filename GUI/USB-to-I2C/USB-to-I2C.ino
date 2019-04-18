/*
 Name:		USB_to_I2C.ino
 Created:	4/18/19 6:26:02 PM
 Author:	
*/

//Takes USB input and converts to I2C to be sent down tether to PCA9685 motor & ESC controller

//Communications config
#define SERIAL_BAUD 250000
#define PWM_FREQ 100
#define I2C_FREQ 100000

//ESC PWM config
#define PWM_MIN 451 //signal on-time values out of a 4096-step period
#define PWM_STOP 590 //used to be 590
#define PWM_MAX 770

#include <Adafruit_PWMServoDriver.h>
#include <Wire.h>

Adafruit_PWMServoDriver pca9685 = Adafruit_PWMServoDriver();

uint8_t data[16];
int8_t data_progress = -1;

// the setup function runs once when you press reset or power the board
void setup() {
	//serial init
	Serial.begin(SERIAL_BAUD);
	Serial.println("Init");
	//i2c pwm init
	Wire.begin();
	Wire.setClock(I2C_FREQ);
	pca9685.begin();
	pca9685.setPWMFreq(PWM_FREQ);
	Serial.println("I2C Init");
	pinMode(LED_BUILTIN, OUTPUT);
}

// the loop function runs over and over again until power down or reset
void loop() {
	//when data is received over USB Serial
	if (Serial.available()) {
		//messages start with 0x42
		if (data_progress == -1) {
			if (Serial.read() == 0x42) {
				data_progress++;
			}
		}
		//then come 16 bytes of data
		else if (data_progress >= 0 && data_progress < 16) {
			data[data_progress] = Serial.read();
			data_progress++;
		}
		//now write out the data to the PWM board
		else if (data_progress == 16) {
			data_progress = -1;
			//ESCs
			for (int i = 0; i < 6; i++) {
				uint8_t speed = data[i];
				if (speed == 127 || speed == 128) {
					//stop motor
					pca9685.setPWM(i, 0, PWM_STOP);
				}
				else {
					//run motor forward or reverse
					pca9685.setPWM(i, 0, map(speed, 0, 255, PWM_MIN, PWM_MAX));
				}
			}
			//Servomotors
			for (int i = 6; i < 10; i++) {
				uint8_t speed = data[i];
				if (speed == 127 || speed == 128) {
					//both pins high to brake when stop requested
					pca9685.setPWM(15 - i * 2, 0, 4095);
					pca9685.setPWM(14 - i * 2, 0, 4095);
				}
				else if (speed < 127) {
					//turn one way
					pca9685.setPWM(15 - i * 2, 0, 0);
					pca9685.setPWM(14 - i * 2, 0, map(speed, 0, 127, 4095, 0));
				}
				else if (speed > 128) {
					//turn other way
					pca9685.setPWM(15 - i * 2, 0, map(speed, 127, 255, 0, 4095));
					pca9685.setPWM(14 - i * 2, 0, 0);
				}
			}
		}
	}

	//blink LED 13 so we can make sure code doesn't lock up
	if (millis() % 500 == 0) {
		digitalWrite(LED_BUILTIN, !digitalRead(LED_BUILTIN));
	}
}
