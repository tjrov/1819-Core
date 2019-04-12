using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    /*
    Protocol is as follows:
    Header(0x42)
    Command(bit 0 determines whether request or command)
    Length of data
    Data
    Checksum(XOR of length and all data bytes)
    */
    public class ROVMessage
    {
        public byte command;
        public byte[] data;
    }
    //Has an IsOpenChanged event and logging capabilities
    public class BetterSerialPort : SerialPort
    {
        public BetterSerialPort(string portName, int baudRate) : base(portName, baudRate)
        {
        }
        //custom code for rov serial comms
        public void TransmitRequestOrCommand(ROVMessage msg)
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
            //add checksum
            temp[temp.Length - 1] = calculatedChecksum;

            //send it off
            Write(temp, 0, temp.Length);
        }

        public ROVMessage WaitReceiveData(int timeout)
        {
            //after sending a request for sensor data, the ROV replies with info
            //only allow 100 ms for this to occur

            Task<ROVMessage> task = Task.Run(() => ReceiveHelper());
            if (task.Wait(TimeSpan.FromMilliseconds(timeout)))
            {
                return task.Result;
            }
            else
            {
                throw new Exception("Timed out receiving data");
            }
            //return ReceiveHelper();
        }
        private ROVMessage ReceiveHelper()
        {

            ROVMessage msg = new ROVMessage();
            while (ReadByte() != 0x42) ; //read in until header byte reached
            msg.command = (byte)ReadByte();
            msg.data = new byte[ReadByte()];
            byte calculatedChecksum = (byte)msg.data.Length; //start calculating a checksum
            for (int i = 0; i < msg.data.Length; i++)
            {
                //read in bytes one by one, calculating checksum as we go
                msg.data[i] = (byte)ReadByte();
                calculatedChecksum ^= msg.data[i];
            }
            byte actualChecksum = (byte)ReadByte();
            if (calculatedChecksum != actualChecksum) //see if received checksum matches calculated one
            {
                throw new Exception(string.Format("Received corrupted data (Calculated checksum" +
                                                  " of {0} did not match received {1})", calculatedChecksum, actualChecksum));
            }
            return msg;
        }
    }
}