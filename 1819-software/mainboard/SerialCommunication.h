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
	uint8_t command, length;
	uint8_t data[MAX_PACKET_LENGTH];
};

uint8_t receiveProgress, index, calculatedChecksum;

MESSAGE rxData;

/*
 Function to be called repeatedly in loop() that receives Serial messages
 return values:
 -1: error receiving
 1<->4: various stages of progress
 5: received succesfully
*/
uint8_t receiveMessage() {
	if (Serial.available()) {
		uint8_t c = Serial.read();
		if (c == 0x42) { //new message starting
			receiveProgress = 1;
		}
		else if (receiveProgress == 1) { //command byte
			rxData.command = c;
			receiveProgress = 2;
		}
		else if (receiveProgress == 2) { //length bytes
			rxData.length = c;
			calculatedChecksum = rxData.length; //checksum begins with length in it
			receiveProgress = 3;
			index = 0;
		}
		else if (receiveProgress == 3) { //data bytes
			rxData.data[index] = c;
			calculatedChecksum ^= c; //XOR checksum with all data bytes
			index++;
			if (index >= MAX_PACKET_LENGTH) {
				receiveProgress = 4;
			}
		} else if (receiveProgress == 4 && c == calculatedChecksum) { //checksum
			receiveProgress = 5;
		}
		else {
			receiveProgress = -1;
		}
	}
	return receiveProgress;
}