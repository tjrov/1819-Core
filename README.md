# 1819-Core
All software and hardware for 2018-19 season

If you want to work on anything, the ControlStation is a great place to start.

So far, I've made abstract classes for sub-Panels of the GUI that control robot actuators
or read data from robot sensors. Serial comms are already taken care of. Just instantiate
one of the concrete subclasses and add it to the GUI controls.

The Draw() methods of these subclasses are not yet implemented.

The Update() methods should be added to timers that regularly update the sub-Panels

It's recommended to use Visual Studio with the .NET and Windows Forms stuff installed for 
ControlStation development. For development of firmware for the mainboard and motorcontroller,
which are Arduino boards, install the Visual Micro plugin for Visual Studio.
