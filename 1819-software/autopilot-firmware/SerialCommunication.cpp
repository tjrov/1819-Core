/*
 Functions for Serial Communication
 Protocol is as follows:
 Header (0x42)
 Command (bit 0 determines whether request or command)
 Length of data
 Data
 Checksum (XOR of length and all data bytes)
*/
struct MESSAGE {
	COMMAND command;
	uint8_t length;
	uint8_t data[MAX_PACKET_LENGTH];
};

uint8_t receiveProgress, index, calculatedChecksum;
uint32_t lastComms;

MESSAGE rxData, txData;

/*
 Function to be called repeatedly in loop() that receives Serial messages
 return values:
 -1: error receiving
 1<->4: various stages of progress
 5: received succesfully
*/
void receiveMessage() {
	if (Serial.available()) {
		uint8_t c = Serial.read();
		if (c == 0x42) { //new message starting
			receiveProgress = 1;
		}
		else if (receiveProgress == 1) { //command byte
			rxData.command = (COMMAND)c;
			receiveProgress = 2;
		}
		else if (receiveProgress == 2) { //length bytes
			rxData.length = c;
			calculatedChecksum = rxData.length; //checksum begins with length in it
			if (c > 0) { //skip data section for 0-length messages
				receiveProgress = 3;
				index = 0;
			}
			else {
				receiveProgress = 4;
			}
		}
		else if (receiveProgress == 3) { //data bytes
			rxData.data[index] = c;
			calculatedChecksum ^= c; //XOR checksum with all data bytes
			index++;
			if (index >= MAX_PACKET_LENGTH) {
				receiveProgress = 4;
			}
		}
		else if (receiveProgress == 4) { //checksum
			if (c == calculatedChecksum) {
				receiveProgress = 5;
				lastComms = millis();
			}
			else {
				receiveProgress = 0;
				error = INVALID_CHECKSUM;
			}
		}
		else {
			receiveProgress = 0;
		}
	}
}
void sendMessage() {
	Serial.write(HEADER_BYTE);
	Serial.write(txData.command);
	Serial.write(txData.length);
	uint8_t checksum = txData.length;
	for (int i = 0; i < txData.length; i++) {
		Serial.write(txData.data[i]);
		checksum ^= txData.data[i];
	}
	Serial.write(checksum);
}
bool isTimeout() {
	return (millis() - lastComms) > SERIAL_TIMEOUT;
}
void handleDataDirection() {
	if ((UCSR0A & _BV(TXC0)) == 0) {
		digitalWrite(TX_EN, HIGH);
	}
	else {
		digitalWrite(TX_EN, LOW);
	}
}