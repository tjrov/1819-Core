double mapDouble(double val, double minVal, double maxVal, double minResult, double maxResult) {
	return ((val - minVal) / (maxVal - minVal) * (maxResult - minResult)) + minResult;
}

Adafruit_BNO055 imu = Adafruit_BNO055(55);

void initIMU() {
	//try to setup IMU
	if (!imu.begin()) {
		error = IMU_FAILURE;
		return;
	}
	imu.setExtCrystalUse(true);
	//do any configuration of imu here
}

void readIMU() {
	//refresh data from imu
	sensors_event_t imuData;
	imu.getEvent(&imuData);

	/* Display the floating point data */
	Serial.print("X: ");
	Serial.print(imuData.orientation.x, 4);
	Serial.print("\tY: ");
	Serial.print(imuData.orientation.y, 4);
	Serial.print("\tZ: ");
	Serial.print(imuData.orientation.z, 4);
	Serial.println("");

	//prepare txData for transmission
	txData.command = IMU_REQ;
	txData.length = 6;
	/*txData.data[0] = headingInt & 0x00FF;
	txData.data[1] = headingInt >> 8;
	txData.data[0] = pitchInt & 0x00FF;
	txData.data[1] = pitchInt >> 8;
	txData.data[0] = rollInt & 0x00FF;
	txData.data[1] = rollInt >> 8;*/
}

void readESCs() {
	txData.command = ESC_REQ;
	txData.length = 12;
	//refresh data from ESCs
	/*for (int i = 0; i < 6; i++) {
		escs[i]->update();
		txData.data[i * 2] = (uint8_t)mapDouble(escs[i]->rpm(), 0, 5000, 0, 255);
		txData.data[i * 2 + 1] = (uint8_t)mapDouble(escs[i]->temperature(), 0, 100, 0, 255);
	}*/
}

MS5803 depth(DEPTH_ADDRESS);

void initDepth() {
	//attempt to contact sensor to check if it's available
	Wire.beginTransmission(DEPTH_ADDRESS);
	uint8_t err = Wire.endTransmission();
	if (err > 0) {
		error = PRESSURE_SENSOR_FAILURE;
		return;
	}
	depth.reset();
	depth.begin();
	depth.getTemperature(CELSIUS, ADC_256);
}

void readDepth() {
	//8-bit adc reading gives +/-1 mbar, or better than 
	//1mm resolution of depth with a 0.5ms response time
	//subtract pressure of air on surface; it doesn't factor
	//into the pressure caused by the water column
	/*double depthDouble = depth.getPressure(ADC_256) - BAROMETRIC_PRESSURE;
	//depth = pressure / (density * acceleration)
	//where depth is in meters, pressure is in Pascals (N/m^2)
	//density is in kilograms per cubic meter, 
	//and acceleration is in meters per second per second
	depthDouble /= 1000.0 * GRAVITATIONAL_ACCELERATION;

	//now convert to bytes and prepare txData
	int intDepth = (int)mapDouble(depthDouble, 0, 30, -32768, 32767);*/
	txData.command = DEPTH_REQ;
	txData.length = 2;
	/*txData.data[0] = intDepth & 0x00FF;
	txData.data[1] = intDepth >> 8;*/
}

void readStatus() {
	txData.command = STATUS_REQ;
	txData.length = 3;
	txData.data[0] = status;
	txData.data[1] = error;
	txData.data[2] = analogRead(VOLTAGE_SENSOR) >> 2;
}