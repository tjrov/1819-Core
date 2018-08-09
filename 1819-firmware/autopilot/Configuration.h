/*
 Configuration for autopilot board 
*/

#define SERIAL_BAUD 115200 //Max tested on tether so far. 500 kbaud possible in theory
#define MAX_PACKET_LENGTH 64 //maximum possible message is 255 bytes, increase to that if needed

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
