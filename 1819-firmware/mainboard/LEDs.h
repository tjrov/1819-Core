/*
 Code for controlling status LEDs
*/

void controlLEDs() {
	if (error == ALL_SYSTEMS_GO) {
		switch (status) {
		case DISCONNECTED:
			//yellow
			digitalWrite(RED, HIGH);
			digitalWrite(GREEN, HIGH);
			break;
		case DISARMED:
			//solid green
			digitalWrite(RED, LOW);
			digitalWrite(GREEN, HIGH);
			break;
		case ARMED:
			//1Hz flashing green
			digitalWrite(RED, LOW);
			digitalWrite(GREEN, (millis() % 1000) < 500);
			break;
		}
		//flash blue 5ms for correctly processed messages
		//digitalWrite(BLUE, (millis() - lastComms) < 5); //too slow to show all msgs
	}
	else {
		//flash red the number of times in the error code number
		int t = millis() % 10000;
		digitalWrite(RED, ((t % 1000) < 500) && ((t / 1000) < error));
		digitalWrite(GREEN, LOW);
		digitalWrite(BLUE, LOW);
	}
}

void initLEDs() {
	for (int i = RED; i <= BLUE; i++) {
		pinMode(i, OUTPUT);
		digitalWrite(i, HIGH);
		delay(150);
		digitalWrite(i, LOW);
	}
}