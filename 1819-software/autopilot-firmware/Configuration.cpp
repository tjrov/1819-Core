/*
 Configuration for autopilot board 
*/

#define SERIAL_BAUD 250000 //Max tested on tether so far. 500 kbaud possible in theory
#define MAX_PACKET_LENGTH 64 //maximum possible message is 255 bytes, increase to that if needed
#define HEADER_BYTE 0x42
#define SERIAL_TIMEOUT 1000
#define I2C_CLOCK 400000

#define NUM_ESCS 6
#define ESC_ADDRESSES { 0x31, 0x2A, 0x2B, 0x2C, 0x2D, 0x2E }
#define NUM_POLES 6

#define NUM_TOOLS 3
#define TOOLS_ADDRESS 0x10

#define DEPTH_ADDRESS ADDRESS_LOW

enum ERROR {
	ALL_SYSTEMS_GO = 0,
	IMU_FAILURE = 1,
	ESC_FAILURE = 2,
	PRESSURE_SENSOR_FAILURE = 3,
	TOOLS_FAILURE = 4,
	INVALID_CHECKSUM = 5,
	INVALID_COMMAND = 6
};
ERROR error;

enum STATUS {
	DISCONNECTED = 0,
	DISARMED = 1,
	ARMED = 2,
	REBOOT = 3
};
STATUS status;

enum COMMAND {
	IMU_REQ = 0x01,
	ESC_REQ = 0x02,
	DEPTH_REQ = 0x03,
	STATUS_REQ = 0x04,
	ESC_CMD = 0x81,
	TOOLS_CMD = 0x82,
	STATUS_CMD = 0x83
};
