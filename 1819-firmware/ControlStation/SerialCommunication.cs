<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace ControlStation
{
    /*
     Protocol is as follows:
     Header(0x42)
     Command(bit 0 determines whether request or command)
     Length of data
     Data
     Checksum(XOR of length and all data bytes)
    */
    public class SerialCommunication : SerialPort, INotifyPropertyChanged
    {
        private Timer checkTimer;
        private bool wasOpen;

        public event PropertyChangedEventHandler PropertyChanged;

        public SerialCommunication(string portName, int baudRate) : base(portName, baudRate, Parity.None, 8, StopBits.One)
        {
            //checks for a change in connection status at 10Hz
            checkTimer = new Timer()
            {
                Interval = 100,
                Enabled = true
            };
            checkTimer.Tick += new EventHandler(OnCheckTimer);
        }
        
        //fires when connection lost or regained
        private void OnCheckTimer(object sender, EventArgs e)
        {
            if(IsOpen != wasOpen)
            {
                PropertyChanged(this, null);
            }
            wasOpen = IsOpen;
        }

        public void SendMessage(MessageStruct msg)
        {
            //assemble header, command, length bytes at front of message
            byte[] temp = new byte[msg.data.Length + 4];
            temp[0] = (byte)0x42;
            temp[1] = msg.command;
            temp[2] = (byte)msg.data.Length;
            //checksum starts as msg length
            byte calculatedChecksum = (byte)msg.data.Length;
            //add all message data in
            for (int i = 0; i < msg.data.Length; i++)
            {
                temp[i + 3] = msg.data[i];
                calculatedChecksum ^= msg.data[i];
            }
            //add checksum and send off
            temp[temp.Length - 1] = calculatedChecksum;
            Write(temp, 0, temp.Length);
        }
        public MessageStruct ReceiveMessage()
        {
            //after sending a request for sensor data, the ROV replies with info
            //only allow 10 ms for this to occur
            var task = Task.Run(() => ReceiveMessageHelper());
            if (task.Wait(TimeSpan.FromMilliseconds(10)))
                return task.Result;
            else
                throw new Exception("Timed out receiving data");
        }
        private MessageStruct ReceiveMessageHelper()
        {
            MessageStruct msg = new MessageStruct();
            while (ReadByte() != 0x42) ; //read in until header byte reached
            msg.command = (byte)ReadByte();
            msg.data = new byte[ReadByte()];
            byte calculatedChecksum = (byte)msg.data.Length; //start calculating a checksum
            for (int i = 0; i < msg.data.Length; i++)
            {
                //read in all the data bytes
                msg.data[i] = (byte)ReadByte();
                calculatedChecksum ^= msg.data[i];
            }
            if (calculatedChecksum != ReadByte()) //see if received checksum matches calculated one
            {
                throw new Exception("Received corrupted data (Checksums did not match)");
            }
            return msg;
        }
    }
    public struct MessageStruct
    {
        public MessageStruct(byte command, byte length)
        {
            this.command = command;
            data = new byte[length];
        }
        public MessageStruct(byte command, byte[] data)
        {
            this.command = command;
            this.data = data;
        }
        public byte command;
        public byte[] data;
    }
=======
﻿using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlStation
{
    /*
     Protocol is as follows:
     Header(0x42)
     Command(bit 0 determines whether request or command)
     Length of data
     Data
     Checksum(XOR of length and all data bytes)
    */
    public class SerialCommunication
    {
        private SerialPort port;
        public SerialCommunication(string portName, int baudRate)
        {
            port = new SerialPort(portName, baudRate, Parity.None, 8, StopBits.One);
            port.Open();
        }
        public void SendMessage(MessageStruct msg)
        {
            //assemble header, command, length bytes at front of message
            byte[] temp = new byte[msg.data.Length + 4];
            temp[0] = (byte)0x42;
            temp[1] = msg.command;
            temp[2] = (byte)msg.data.Length;
            //checksum starts as msg length
            byte calculatedChecksum = (byte)msg.data.Length;
            //add all message data in
            for (int i = 0; i < msg.data.Length; i++)
            {
                temp[i + 3] = msg.data[i];
                calculatedChecksum ^= msg.data[i];
            }
            //add checksum and send off
            temp[temp.Length - 1] = calculatedChecksum;
            port.Write(temp, 0, temp.Length);
        }
        public MessageStruct ReceiveMessage()
        {
            //after sending a request for sensor data, the ROV replies with info
            //only allow 10 ms for this to occur
            return ReceiveMessageHelper();

            var task = Task.Run(() => ReceiveMessageHelper());
            if (task.Wait(TimeSpan.FromMilliseconds(10)))
                return task.Result;
            else
                throw new Exception("Timed out receiving data");
        }
        private MessageStruct ReceiveMessageHelper()
        {
            MessageStruct msg = new MessageStruct();
            while (port.ReadByte() != 0x42) ; //read in until header byte reached
            msg.command = (byte)port.ReadByte();
            msg.data = new byte[port.ReadByte()];
            byte calculatedChecksum = (byte)msg.data.Length; //start calculating a checksum
            for (int i = 0; i < msg.data.Length; i++)
            {
                //read in all the data bytes
                msg.data[i] = (byte)port.ReadByte();
                calculatedChecksum ^= msg.data[i];
            }
            if (calculatedChecksum != port.ReadByte()) //see if received checksum matches calculated one
            {
                throw new Exception("Received corrupted data (Checksums did not match)");
            }
            return msg;
        }
    }
    public struct MessageStruct
    {
        public MessageStruct(byte command, byte length)
        {
            this.command = command;
            data = new byte[length];
        }
        public MessageStruct(byte command, byte[] data)
        {
            this.command = command;
            this.data = data;
        }
        public byte command;
        public byte[] data;
    }
>>>>>>> 577825f6b0bcaa6236b942a1dab438a783301dae
}