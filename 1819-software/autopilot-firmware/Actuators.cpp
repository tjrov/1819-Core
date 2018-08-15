

Arduino_I2C_ESC *escs[NUM_ESCS];

void initESCs() {
	uint8_t addresses[] = ESC_ADDRESSES;
	for (int i = 0; i < NUM_ESCS; i++) {
		Wire.beginTransmission(addresses[i]); //check if ESC at this address available
		uint8_t err = Wire.endTransmission();
		if (err > 0) {
			error = ESC_FAILURE;
			return;
		}
		escs[i] = new Arduino_I2C_ESC(addresses[i], NUM_POLES); //T100 has 12 poles. Is the default of 6 correct?
													//This will affect the RPM value
	}
}

void writeESCs() {
	for (int i = 0; i < NUM_ESCS; i++) {
		//convert pairs of bytes into 16-bit int for control of ESC
		escs[i]->set(rxData.data[i * 2 + 1] << 8 | rxData.data[i * 2]);
	}
}

void initTools() {
	Wire.beginTransmission(TOOLS_ADDRESS);
	uint8_t err = Wire.endTransmission();
	if (err > 0) {
		error = TOOLS_FAILURE;
	}
}

void writeTools() {
	Wire.beginTransmission(TOOLS_ADDRESS);
	Wire.write(HEADER_BYTE);
	uint8_t checksum;
	for (int i = 0; i < NUM_TOOLS; i++) {
		Wire.write(rxData.data[i]);
		checksum ^= rxData.data[i];
	}
	Wire.write(checksum);
	Wire.endTransmission();
}

void initStatus() {
	error = ALL_SYSTEMS_GO;
	status = DISCONNECTED;
}

void resetBoard() {
	pinMode(RESET, OUTPUT);
	digitalWrite(RESET, LOW); //connected to RESET pin
	while (true);
}

void writeStatus() {
	if (status != rxData.data[0]) { //only change if needed
		switch (rxData.data[0]) {
			case DISARMED:
				if (status == ARMED) //avoids going to disarmed state
					status = DISARMED; //when not connected
				break;
			case ARMED:
				if (status == DISARMED) //ditto ^
					status = ARMED;
				break;
			case REBOOT:
				resetBoard();
				break;
		}
	}
}

//call to stop all movement of actuators
void emergencyStop() {
	for (int i = 0; i < NUM_ESCS; i++) {
		escs[i]->set(0);
	}
	for (int i = 0; i < NUM_TOOLS; i++) {
		Wire.beginTransmission(TOOLS_ADDRESS);
		Wire.write(HEADER_BYTE);
		for (int i = 0; i < 3; i++) {
			Wire.write(128);
		}
		Wire.write(0);
		Wire.endTransmission();
	}
}