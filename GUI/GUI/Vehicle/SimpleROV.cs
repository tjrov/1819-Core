using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    public class SimpleROV
    { 
        private byte[] data = new byte[16];
        private SerialPort port;
        public SimpleROV(string portName, int baudRate)
        {
            port = new SerialPort(portName, baudRate);
            port.Open();
        }
        //sends values to USB-to-I2C bridge
        public void Update()
        {
            //send message as below:
            //0x42 is the header
            //next 6 bytes are thruster motor speeds, 127 to stop, 0 reverse, 255 forward
            //next 4 bytes are manipulator motor speeds, same control scheme
            byte[] toSend = new byte[17];
            toSend[0] = (byte)0x42;
            for (int i = 0; i < 16; i++) toSend[i + 1] = data[i];
            port.Write(toSend, 0, 17);
        }
        //stops all motors (thrusters and manipulators)
        public void EmergencyStop()
        {
            for(int i = 0; i < 16; i++)
            {
                data[i] = 127;
            }
            Update();
        }
        public void SetThruster(Thrusters which, byte speed)
        {
            data[(int)which] = speed;
        }
        public void SetManipulator(Manipulators which, byte speed)
        {
            data[(int)which] = speed;
        }
    }
    public enum Thrusters
    {
        ForwardPort = 5,
        ForwardStarboard = 2,
        AftPort = 3,
        AftStarboard = 0,
        VerticalPort = 4,
        VerticalStarboard = 1
    }
    public enum Manipulators
    {
        ToolOne=6,
        ToolTwo=7,
        ToolThree=8,
        ToolFour=9
    }
}
