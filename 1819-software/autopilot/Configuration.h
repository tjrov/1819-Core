/*
 Configuration for autopilot board
*/

/*
 Serial config
*/
#define SERIAL_BAUD 250000 //Max tested on tether so far. 500 kbaud possible in theory
#define MAX_PACKET_LENGTH 64 //maximum possible message is 255 bytes, increase to that if needed
#define SERIAL_TIMEOUT 2000 //if a message is not received in this time, board goes disconnected
#define HEADER_BYTE 0x42 //all messages begin with 0x42 (of course :D)

/*
 I2C config
*/
#define I2C_CLOCK 400000 //400kHz. Lower options available if i2c does not work at this speed

/*
 ESC config
*/
#define NUM_ESCS 6
#define NUM_POLES 6 //affects RPM. magnetic poles per motor (T100 has 6 or 12 uncertain of which)
#define ESC_ADDRESSES {0x31, 0x2B, 0x2C, 0x2D, 0x2E, 0x2F} //range is 0x2A to 0x38 for ESCs number 0 to 15

/*
 Manipulator config
*/
#define NUM_TOOLS 3
#define TOOLS_ADDRESS 0x10

/*
 Depth sensor config
*/
#define DEPTH_ADDRESS 0x76 //default jumper position
#define BAROMETRIC_PRESSURE 101300 //in Pascals
#define GRAVITATIONAL_ACCELERATION 9.81 //m/s^2 of course
#define DEPTH_PRECISION ADC_256 //lowest precision reading for highest speed

/*
 Message command code definitions
*/
enum COMMAND {
	IMU_REQ = 0x01,
	ESC_REQ = 0x02,
	DEPTH_REQ = 0x03,
	STATUS_REQ = 0x04,
	ESC_CMD = 0x81,
	TOOLS_CMD = 0x82,
	STATUS_CMD = 0x83
};

/*
 Error code definitions
*/
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

/*
 System status definitions
*/
enum STATUS {
	DISCONNECTED = 0 ,
	DISARMED = 1,
	ARMED = 2,
	REBOOT = 3
};
STATUS status;
