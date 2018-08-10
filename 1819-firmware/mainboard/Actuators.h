Arduino_I2C_ESC *escs[6];

void initESCs() {
	uint8_t addresses[] = ESC_ADDRESSES;
	for (int i = 0; i < 6; i++) {
		escs[i] = new Arduino_I2C_ESC(addresses[i], 6); //T100 has 12 poles. Is the default of 6 correct?
													//This will affect the RPM value
	}
}

void writeESCs() {
	for (int i = 0; i < 6; i++) {
		//convert pairs of bytes into 16-bit int for control of ESC
		escs[i]->set(rxData.data[i * 2 + 1] << 8 | rxData.data[i * 2]);
	}
}

void initTools() {
	pinMode(LED_CTRL, OUTPUT);
	pinMode(RLY1_CTRL, OUTPUT);
	pinMode(RLY2_CTRL, OUTPUT);
	pinMode(MOT1_DIR1, OUTPUT);
	pinMode(MOT1_DIR2, OUTPUT);
	pinMode(MOT2_DIR1, OUTPUT);
	pinMode(MOT2_DIR2, OUTPUT);
	pinMode(MOT3_DIR1, OUTPUT);
	pinMode(MOT3_DIR2, OUTPUT);
	pinMode(MOT4_DIR1, OUTPUT);
	pinMode(MOT4_DIR2, OUTPUT);
}

/*
Sets manipulator speed of motor controlled by pins dir1 & dir2
to val. 0 is full reverse, 255 is full forward, and 128 is stopped
*/
void setManipulator(uint8_t val, uint8_t dir1, uint8_t dir2) {
	if (val > 128) {
		analogWrite(dir1, (val - 128) * 2);
		digitalWrite(dir2, LOW);
	}
	else if (val < 128) {
		analogWrite(dir1, val * 2);
		digitalWrite(dir2, HIGH);
	}
	else {
		digitalWrite(dir1, LOW);
		digitalWrite(dir2, LOW);
	}
}

void writeTools() {
	setManipulator(rxData.data[0], MOT1_DIR1, MOT1_DIR2);
	setManipulator(rxData.data[1], MOT2_DIR1, MOT2_DIR2);
	setManipulator(rxData.data[2], MOT3_DIR1, MOT3_DIR2);
	setManipulator(rxData.data[3], MOT4_DIR1, MOT4_DIR2);
}