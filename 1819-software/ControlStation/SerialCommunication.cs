using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;
using System.Collections.Concurrent;

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
        private EventSerialPort port;
        private ConcurrentQueue<GenericDevice> devices;

        private Thread thread;

        private ConcurrentQueue<string> history;

        private Button toggle;
        private Label info;

        public event EventHandler<bool> IsPortOpenChanged
        {
            add
            {
                port.IsOpenChanged += value;
            }
            remove
            {
                port.IsOpenChanged -= value;
            }
        }

        public SerialCommunication(string portName, int baudRate) : base()
        {
            port = new EventSerialPort(portName, baudRate);
            port.IsOpenChanged += OnIsOpenChanged;
            devices = new ConcurrentQueue<GenericDevice>();
            history = new ConcurrentQueue<string>();
            //background loop runs on this thread
            thread = new Thread(new ThreadStart(BackgroundLoop));
            thread.SetApartmentState(ApartmentState.STA); //for UI compatibility
            //setup gui
            toggle = new Button()
            {
                Text = "Disconnected",
                BackColor = Color.Yellow,
                AutoSize = true
            };
            toggle.Click += OnClick;

            info = new Label()
            {
                Text = string.Format("{0}@{1}kbaud", port.PortName, port.BaudRate / 1000.0)
            };

            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BorderStyle = BorderStyle.Fixed3D;
            FlowDirection = FlowDirection.RightToLeft;

            Controls.Add(toggle);
            Controls.Add(info);

            thread.Start(); //start the background loop
        }
        //requests update of a device
        public void QueueDevice(GenericDevice device)
        {
            devices.Enqueue(device);
        }
        //recent comms to help with debugging
        private string GetHistory()
        {
            string result = "";
            while (history.Count > 0)
            {
                history.TryDequeue(out string temp);
                result += temp + "\n";
            }
            return result;
        }
        //handles communication and processing of queue
        private void BackgroundLoop()
        {
            while (true)
            {
                try
                {
                    if (port.IsOpen)
                    {
                        if (devices.Count > 0) //if anything needs updating
                        {
                            //send the request
                            devices.TryDequeue(out GenericDevice device);
                            TransmitMessage(device.GetMessage());
                            //if it's a sensor and needs a reply
                            if (device.NeedsResponse)
                            {
                                //get the reply
                                MessageStruct msg = ReceiveMessage();
                                //update the device's data on UI thread
                                device.Invoke(new Action(() => device.UpdateData(msg)));
                            }
                            //redraw the device on UI thread
                            device.Invoke(new Action(device.UpdateControls));
                        }
                    }
                    else
                    {
                        Thread.Sleep(100);
                    }
                } catch(Exception ex)
                {
                    //show in dialog
                    this.Invoke(new Action(() => ShowException(ex)));
                }
            }
        }

        private void ShowException(Exception ex)
        {
            //stop further errors from occuring
            port.Close();
            //show error
            MessageBox.Show(this, ex.Message + ex.StackTrace,
                  "Error in CommsBackgroundLoop", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //show comms history
            MessageBox.Show(GetHistory() + ex.Message,
              "Communication history", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void TransmitMessage(MessageStruct msg)
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

            //note transmission in history
            string historyString = "TX: ";
            for (int i = 0; i < temp.Length; i++)
            {
                historyString += temp[i] + " ";
            }
            history.Enqueue(historyString);
            //limit length of history
            while (history.Count > 10)
            {
                history.TryDequeue(out string delete);
            }

            //send it off
            port.Write(temp, 0, temp.Length);
        }
        private MessageStruct ReceiveMessage()
        {
            //after sending a request for sensor data, the ROV replies with info
            //only allow 100 ms for this to occur
            var task = Task.Run(() => ReceiveMessageHelper());
            if (task.Wait(TimeSpan.FromMilliseconds(1000)))
                return task.Result;
            else
                throw new Exception("Timed out receiving data");
        }
        private MessageStruct ReceiveMessageHelper()
        {

            MessageStruct msg = new MessageStruct();
            string temp = "RX: ";
            while (ReadByte(ref temp) != 0x42) ; //read in until header byte reached
            msg.command = (byte)ReadByte(ref temp);
            msg.data = new byte[ReadByte(ref temp)];
            byte calculatedChecksum = (byte)msg.data.Length; //start calculating a checksum
            for (int i = 0; i < msg.data.Length; i++)
            {
                //read in bytes one by one, calculating checksum as we go
                msg.data[i] = (byte)ReadByte(ref temp);
                calculatedChecksum ^= msg.data[i];
            }
            byte actualChecksum = (byte)ReadByte(ref temp);
            history.Enqueue(temp);
            if (calculatedChecksum != actualChecksum) //see if received checksum matches calculated one
            {
                throw new Exception(string.Format("Received corrupted data (Calculated checksum" +
                    " of {0} did not match received {1})", calculatedChecksum, actualChecksum));
            }
            return msg;
        }

        private int ReadByte(ref string history)
        {
            int x = port.ReadByte();
            history += x + " ";
            return x;
        }
        private void OnIsOpenChanged(object sender, bool e)
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
        }
    }
    public class EventSerialPort : SerialPort
    {
        public event EventHandler<bool> IsOpenChanged;
        public EventSerialPort(string portName, int baudRate) : base(portName, baudRate)
        {
            ErrorReceived += Error;
        }
        private void Error(object sender, SerialErrorReceivedEventArgs e)
        {
            IsOpenChanged(this, IsOpen);
        }
        public new void Open()
        {
            base.Open();
            IsOpenChanged(this, IsOpen);
        }
        public new void Close()
        {
            base.Close();
            IsOpenChanged(this, IsOpen);
        }
    }
}