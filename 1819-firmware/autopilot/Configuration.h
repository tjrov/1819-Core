/*
 Hardware configuration 
*/
#define SERIAL_BAUD 115200 //Max tested on tether so far. 500 kbaud possible in theory
#define MAX_PACKET_LENGTH 64 //maximum possible message is 255 bytes, increase to that if needed
#define ESC_ADDRESSES {0x31, 0x2B, 0x2C, 0x2D, 0x2E, 0x2F}
#define DEPTH_ADDRESS 0x76

/*
 "Universal" constants that vary based on geographic location & weather if we want more sig figs
*/
#define BAROMETRIC_PRESSURE 101300 //in Pascals
#define GRAVITATIONAL_ACCELERATION 9.81 //m/s^2 of course

/*
 Message command code definitions 
*/
//sensor data request codes
#define IMU_REQ 0x01
#define ESC_REQ 0x02
#define DEPTH_REQ 0x03
#define STATUS_REQ 0x05
//actuator command codes
#define ESC_CMD 0x81
#define TOOLS_CMD 0x82

/*
 Error code definitions
*/
#define ALL_SYSTEMS_GO 0
#define IMU_FAILURE 1
#define COMMUNICATION_FAILURE 2
#define ESC_FAILURE 3
#define PRESSURE_SENSOR_FAILURE 4
