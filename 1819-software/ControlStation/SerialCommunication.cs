using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Drawing;

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
    public class SerialCommunication : FlowLayoutPanel
    {
        private SerialPort port;
        private Timer checkTimer;
        private bool wasOpen;
        private Queue<string> history;

        private Button toggle;
        private Label info;

        public event EventHandler OnConnectionStatusChange;

        public bool IsPortOpen
        {
            get
            {
                return port.IsOpen;
            }
        }

        public SerialCommunication(string portName, int baudRate) : base()
        {
            //checks for a change in connection status at 10Hz
            port = new SerialPort(portName, baudRate, Parity.None, 8, StopBits.One);

            history = new Queue<string>();

            checkTimer = new Timer
            {
                Interval = 100,
                Enabled = true
            };
            checkTimer.Tick += OnCheckTimer;

            toggle = new Button() {
                Text = "Disconnected",
                BackColor = Color.Red,
                AutoSize = true
            };
            toggle.Click += OnClick;

            info = new Label()
            {
                Text = String.Format("{0}@{1}kbaud", portName, baudRate / 1000.0),
                AutoSize = true
            };

            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BorderStyle = BorderStyle.Fixed3D;
            FlowDirection = FlowDirection.RightToLeft;

            Controls.Add(toggle);
            Controls.Add(info);
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

            //note transmission in history
            history.Enqueue("TX: " + temp);
            //limit size to ten messages total
            if(history.Count > 10)
            {
                history.Dequeue();
            }
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
            string temp = "RX:";
            while (ReadByte(ref temp) != 0x42); //read in until header byte reached
            msg.command = (byte)ReadByte(ref temp);
            msg.data = new byte[ReadByte(ref temp)];
            byte calculatedChecksum = (byte)msg.data.Length; //start calculating a checksum
            for (int i = 0; i < msg.data.Length; i++)
            {
                //read in all the data bytes
                msg.data[i] = (byte)ReadByte(ref temp);
                calculatedChecksum ^= msg.data[i];
            }
            if (calculatedChecksum != ReadByte(ref temp)) //see if received checksum matches calculated one
            {
                throw new Exception("Received corrupted data (Checksums did not match)");
            }
            history.Enqueue(temp);
            return msg;
        }

        private int ReadByte(ref string history)
        {
            int x = port.ReadByte();
            history += " " + x;
            return x;
        }

        public string GetHistory()
        {
            string result = "";
            while(history.Count > 0)
            {
                result += history.Dequeue() + "\n";
            }
            return result;
        }

        private void OnClick(object sender, EventArgs e)
        {
            if (!port.IsOpen)
            {
                port.Open();
            }
            else
            {
                port.Close();
            }
            UpdateButton();
            if (OnConnectionStatusChange != null) {
                OnConnectionStatusChange(this, null);
            }
        }

        private void UpdateButton()
        {
            if (port.IsOpen)
            {
                toggle.BackColor = Color.Green;
                toggle.Text = "Connected";
            }
            else
            {
                toggle.BackColor = Color.Yellow;
                toggle.Text = "Disconnected";
            }
        }

        private void OnCheckTimer(object sender, EventArgs e)
        {
            if (port.IsOpen != wasOpen)
            {
                UpdateButton();
                if (OnConnectionStatusChange != null)
                {
                    OnConnectionStatusChange(this, EventArgs.Empty);
                }
            }
            wasOpen = port.IsOpen;
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
}