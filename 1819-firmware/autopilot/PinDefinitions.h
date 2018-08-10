/*
 Pin definitions for 2016-17 autopilot board
 
 DO NOT CHANGE PIN DEFINITIONS WITHOUT ASKING AN ELECTRICAL SUBTEAM MEMBER
 Thank you.
*/

//=====LIGHTS====================================================================================================
//Set HIGH to turn on

//STATUS LIGHT (blue color)
#define STATUS_LED 13

//HEADLIGHTS (white color)
#define LED_CTRL A3

//=====MOTORS====================================================================================================
//To go forwards, set speed from 0<->255 by analogWrite (uses PWM) on MOTX_DIR1/
//0 is stopped, 255 is full forward
//Set MOTX_DIR2 to LOW by digitalWrite

//To reverse, set speed from 0<->255 by analogWrite on MOTX_DIR1
//Now, 255 is stopped and 0 is full reverse
//Set MOTX_DIR2 to HIGH by digitalWrite

//MOTOR 1
#define MOT1_DIR1 3
#define MOT1_DIR2 A1

//MOTOR 2
#define MOT2_DIR1 5
#define MOT2_DIR2 A2

//MOTOR 3
#define MOT3_DIR1 6
#define MOT3_DIR2 8

//MOTOR 4
#define MOT4_DIR1 9
#define MOT4_DIR2 4

//=====RELAYS====================================================================================================
//Set HIGH to turn on
//RELAY 1
#define RLY1_CTRL A0

//RELAY 2
#define RLY2_CTRL 7

//=====MISC====================================================================================================

//SPEAKER
//Set high with digitalWrite to power on Connor's noisemaker circuit and emit a (annoying, square-wavey) beep
//A specific beep pattern will activate the OBS release
#define SPK 10

//RS-485 TRANSMIT ENABLE
//Set high to transmit data from ROV onboard computer (this processor) to control station over tether
//Set low to receive data from control station (should be default state)
//This should be handled in the Modbus library. Just reference this pin there
#define TX_EN 2

//VOLTAGE MONITORING PIN
//Analog pin to measure voltage
//The actual value is scaled down proportionally by a voltage divider
#define VOLT_MONITOR A0