LSM9DS1 imu;

double mapDouble(double val, double minVal, double maxVal, double minResult, double maxResult) {
	return ((val - minVal) / (maxVal - minVal) * (maxResult - minResult)) + minResult;
}

void initIMU() {
	//See link for how config works
    //https://github.com/sparkfun/LSM9DS1_Breakout/blob/master/Libraries/Arduino/examples/LSM9DS1_Settings/LSM9DS1_Settings.ino
	
	//general device config
	imu.settings.device.commInterface = IMU_MODE_SPI; // Set mode to SPI
	imu.settings.device.mAddress = 9; // Mag CS pin connected to D9
	imu.settings.device.agAddress = 10; // AG CS pin connected to D10

	//accel config
	imu.settings.accel.scale = 4; // Set accel range to +/-4g
	imu.settings.accel.sampleRate = 3; //119Hz sample rate

	//gyro config (gyro not used for now, implement later if smoother readings needed)
	imu.settings.gyro.enabled = false;

	//mag config
	imu.settings.mag.scale = 8; // Set mag range to +/-8Gs
	imu.settings.mag.sampleRate = 7; //80Hz sample rate

	imu.settings.temp.enabled = false; //disable thermometer

	//try to setup IMU
	if (!imu.begin()) {
		errorCode = IMU_FAILURE;
	}
}

void readIMU() {
	//refresh data from IMU
	imu.readAccel();
	imu.readMag();

	//calculate heading, pitch, roll from accelerations and magnetic flux in the three axes
	// Pitch/roll calculations taken from this app note:
	// http://cache.freescale.com/files/sensors/doc/app_note/AN3461.pdf?fpsp=1
	// Heading calculations taken from this app note:
	// http://www51.honeywell.com/aero/common/documents/myaerospacecatalog-documents/Defense_Brochures-documents/Magnetic__Literature_Application_notes-documents/AN203_Compass_Heading_Using_Magnetometers.pdf
	double roll = atan2(imu.ay, imu.az);
	double pitch = atan2(-imu.ax, sqrt(imu.ay * imu.ay + imu.az * imu.az));

	double heading;
	if (-imu.mx == 0)
		heading = (-imu.my < 0) ? 180.0 : 0;
	else
		heading = atan2(-imu.my, -imu.mx);

	if (heading > PI) heading -= (2 * PI);
	else if (heading < -PI) heading += (2 * PI);
	else if (heading < 0) heading += 2 * PI;

	//Convert double to int
	int headingInt = (int)mapDouble(heading, -PI, PI, -32768, 32767);
	int pitchInt = (int)mapDouble(pitch, -PI, PI, -32768, 32767);
	int rollInt = (int)mapDouble(roll, -PI, PI, -32768, 32767);

	//prepare txData for transmission
	txData.command = IMU_REQ;
	txData.length = 6;
	txData.data[0] = headingInt & 0x00FF;
	txData.data[1] = headingInt >> 8;
	txData.data[0] = pitchInt & 0x00FF;
	txData.data[1] = pitchInt >> 8;
	txData.data[0] = rollInt & 0x00FF;
	txData.data[1] = rollInt >> 8;
}

void readESCs() {
	txData.command = ESC_REQ;
	txData.length = 12;
	//refresh data from ESCs
	for (int i = 0; i < 6; i++) {
		escs[i]->update();
		txData.data[i * 2] = (uint8_t)mapDouble(escs[i]->rpm(), 0, 5000, 0, 255);
		txData.data[i * 2 + 1] = (uint8_t)mapDouble(escs[i]->temperature(), 0, 100, 0, 255);
	}
}

MS5803 depth(DEPTH_ADDRESS);

void initDepth() {
	depth.reset();
	depth.begin();
}

void readDepth() {
	//9-bit adc reading gives +/-1 mbar, or better than 
	//1mm resolution of depth without compromising speed
	//subtract pressure of air on surface; it doesn't factor
	//into the pressure caused by the water column
	double depthDouble = depth.getPressure(ADC_512) - BAROMETRIC_PRESSURE;
	//depth = pressure / (density * acceleration)
	//where depth is in meters, pressure is in Pascals (N/m^2)
	//density is in kilograms per cubic meter, 
	//and acceleration is in meters per second per second
	depthDouble /= 1000.0 * GRAVITATIONAL_ACCELERATION;

	//now convert to bytes and prepare txData
	int intDepth = (int)mapDouble(depthDouble, 0, 30, -32768, 32767);
	txData.command = DEPTH_REQ;
	txData.length = 2;
	txData.data[0] = intDepth & 0x00FF;
	txData.data[1] = intDepth >> 8;
}

void readStatus() {
	txData.command = STATUS_REQ;
	txData.length = 3;
	txData.data[0] = isArmed << 1 | isConnected;
	txData.data[1] = errorCode;
	txData.data[2] = analogRead(VOLT_MONITOR) >> 2;
}