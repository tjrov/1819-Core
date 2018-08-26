# 1819-Core
All software and hardware for 2018-19 season

## Software
### ControlStation
If you want to program something, the ControlStation is a great place to start.

So far, I've made abstract classes for sub-Panels of the GUI that control robot actuators
or read data from robot sensors. Serial comms are already taken care of. Just instantiate
one of the concrete subclasses and add it to the GUI controls.

The UpdateControls() methods are what draws the UI for each Device class. This method will run after the device is updated over serial.
New information will be available in the Data field of the class, and you can update the UI with that data.

TODO:
- Make UI look better (probably have the controls take up more of the screen and be laid out less haphazardly. Also maybe use win10 look and feel)
- Controller input
- Heading lock (override handheld controller values and control motors based on heading as compared to a desired heading)
- Depth lock
- Roll lock

It's recommended to use Visual Studio with the .NET and Windows Forms stuff installed for 
ControlStation development.

### autopilot-firmware

The autopilot-firmware and motorcontroller-firmware code is pretty much done. For development of firmware for the autopilot and motorcontroller, which are Arduino boards, install the Visual Micro plugin for Visual Studio. Upload the autopilot-firmware to a regular Arduino board connected to your computer over USB (comment out code that actually uses sensors and actuators since it won't work anyway), then start the ControlStation code and test out the UI.

### Uploading procedure

It's kinda complicated since we only have RS-485 (one twisted pair of wires) connecting the surface and ROV computers
1. You click upload in visual studio on the surface computer
2. The code gets compiled into a .hex file
3. The board.txt file (in the project directory) specifies a pre-upload command to run reset.bat (also in that directory)
4. reset.bat sends a command to the ROV: (hex) 42 83 01 03 02
5. On receiving this command, the autopilot-firmware (as well as the autopilot-setup code once it has finished running) will jump to the start of its bootloader code
6. reset.bat runs avrdude to upload the .hex file to the ROV

## Hardware

Electronics people can take a look at the autopilot board files. We'll also be making a
motorcontroller board that connects to the ROV's i2c bus. You can use Eagle with the Sparkfun Eagle part libraries installed to work on them.

Current autopilot revision features:
- Arduino Pro Mini
- RGB status LED
- RS485 interface
- Auto direction control of rs485 interface allows new firmware to be uploaded over the tether
- PCA-9615 differential I2C transceiver allows it to talk to the ROV data bus and access the motorcontroller board and the 6 ESC boards
- I2C Orientation sensor gives compass heading, pitch, and roll angles
- I2C Pressure sensor provides a depth reading

Motorcontroller planned features:
- Arduino Pro Mini
- RGB status led
- PCA-9615 differential I2C transceiver (connects to the ROV i2c bus)
- Bus termination (see autopilot board schematic)
- 3x DRV8871 motor drivers. (wired as they are on the adafruit breakouts)
See the autopilot board schematic for how to wire the I2C circuits, since they
are the same on that board.
