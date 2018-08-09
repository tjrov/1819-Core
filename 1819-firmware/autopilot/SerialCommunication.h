/*
 Functions for Serial Communication
 Protocol is as follows:
 Header (0x42)
 Command (bit 0 determines whether request or command)
 Length of data
 Data
 Checksum (XOR of length and all data bytes)
*/


void blink(int pin) {
	digitalWrite(13, HIGH);
	delay(50);
	digitalWrite(13, LOW);
	delay(50);
}

struct MESSAGE {
	uint8_t command, length;
	uint8_t data[MAX_PACKET_LENGTH];
};

uint8_t receiveProgress, index, calculatedChecksum;

MESSAGE rxData;

/*
 Function to be called repeatedly in loop() that receives Serial messages
 return values:
false: no message received
true: valid message received
*/
bool receiveMessage() {
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
			if (index >= rxData.length) {
				receiveProgress = 4;
			}
		} else if (receiveProgress == 4 && c == calculatedChecksum) { //checksum
			receiveProgress = 0;
			return true;
		}
		else {
			receiveProgress = -1;
		}
	}
	return false;
}

/*
 sends the MESSAGE struct msg
*/
void sendMessage(MESSAGE msg) {
	digitalWrite(TX_EN, HIGH); //turn on transmit mode
	Serial.write(0x42); //header
	Serial.write(msg.command); //command
	Serial.write(msg.length); //length
	calculatedChecksum = msg.length;
	for (int i = 0; i < msg.length; i++) { //all data
		Serial.write(msg.data[i]);
		//calc checksum as we go with XOR
		calculatedChecksum ^= msg.data[i];
	}
	Serial.write(calculatedChecksum); //checksum
}

/*
 to be called repeatedly in loop and ensure 
 RS-485 data direction pin is correctly set
 TX_EN goes high when there is data in the buffer
 to transmit, or low when there is none and we are 
 ready to receive data
*/
void handleDataDirection() {
	/*
	 UCSR0A is the USART control/status register 0A
	 and TXC0 is the bit of ths register that is turned
	 on when all data has been shifted out onto the serial
	 lines.
	*/
	if (UCSR0A & _BV(TXC0)) { //tx buffer done emptying (TXC0 bit off)
		if (digitalRead(TX_EN)) { //if not already off
			digitalWrite(TX_EN, LOW); //turn off transmit
			delay(100);
		}
	}
}