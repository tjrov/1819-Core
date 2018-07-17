using System;
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
        private Queue<MessageStruct> txQueue;
        private List<ROVInput<Int16>> inputs; //I assumed that the data is int16, change if necessary  -kwu
        private List<ROVOutput> outputs;
        public SerialCommunication(SerialPort port, List<ROVInput<Int16>> inputs, List<ROVOutput> outputs) //more assumptions
        {
            this.port = port;
            txQueue = new Queue<MessageStruct>();
        }
        public void RequestUpdate(ROVInput<Int16> input)//More assumptions
        {
            MessageStruct msg = new MessageStruct();
            msg.command = input.MessageCommand;
            msg.data = new byte[0];
            txQueue.Enqueue(msg);
        }
        public void ProcessMessage(MessageStruct msg)
        {
            foreach (ROVInput<Int16> input in inputs) { //more assumptions
                if(input.MessageCommand == msg.command)
                {
                    //input.Value = msg.; ERROR!!!!!!!!
                }
            }
        }
        private void SendMessage(MessageStruct msg)
        {
            byte[] temp = new byte[msg.data.Length + 4];
            temp[0] = (byte)0x42;
            temp[1] = msg.command;
            temp[2] = (byte)msg.data.Length;
            byte calculatedChecksum = (byte)msg.data.Length;
            for (int i = 0; i < msg.data.Length; i++)
            {
                temp[i + 3] = msg.data[i];
                calculatedChecksum ^= msg.data[i];
            }
            temp[temp.Length - 1] = calculatedChecksum;
            port.Write(temp, 0, temp.Length);
        }
        private MessageStruct ReceiveMessage()
        {
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
            byte calculatedChecksum = (byte)msg.data.Length;
            for (int i = 0; i < msg.data.Length; i++)
            {
                msg.data[i] = (byte)port.ReadByte();
                calculatedChecksum ^= msg.data[i];
            }
            if (calculatedChecksum != port.ReadByte())
            {
                throw new Exception("Received corrupted data (Checksums did not match)");
            }
            return msg;
        }
    }
    public struct MessageStruct
    {
        public byte command;
        public byte[] data;
    }
    public abstract class ROVInput<T>
    {
        public T Value { get; }
        public byte MessageCommand { get; }
        public ROVInput(byte cmd)
        {
            MessageCommand = cmd;
        }
    }
    public class ROVOutput
    {
        private byte messageCommand;
        public byte MessageCommand { get { return messageCommand; } }
    }
}