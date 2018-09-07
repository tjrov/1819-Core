using System;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;
using System.Collections.Concurrent;
using System.IO;
using ControlStation.Devices;
using ControlStation.Devices.Sensors;

namespace ControlStation.Communication
{
    public class SerialCommunicationPanel : FlowLayoutPanel
    {
        private Button toggle;
        private Label info;
        private BetterSerialPort port;

        public SerialCommunicationPanel(BetterSerialPort port) : base()
        {
            this.port = port;
            //setup gui
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.Transparent;
            Size = new Size(350, 40);
            toggle = new Button()
            {
                Text = "Disconnected",
                BackColor = Color.Yellow,
                AutoSize = true,
            };
            toggle.Click += OnClick;

            info = new Label()
            {
                AutoSize = true,
                Text = string.Format("{0}@{1}kbaud", port.PortName, port.BaudRate / 1000.0)
            };
            Controls.Add(toggle);
            Controls.Add(info);
            port.IsOpenChanged += OnIsOpenChanged;
        }

        private void OnIsOpenChanged(object sender, bool e)
        {
            if (e)
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
    public class SerialCommunicationProcess
    {
        private BetterSerialPort port;
        private ConcurrentQueue<GenericDevice> devices;
        private Thread thread;
        public event EventHandler<Exception> ExceptionThrown;

        public SerialCommunicationProcess(BetterSerialPort port)
        {
            this.port = port;
            //connection between UI and background threads is a queue of Devices that need updating
            devices = new ConcurrentQueue<GenericDevice>();

            //background loop runs on this thread
            thread = new Thread(new ThreadStart(BackgroundLoop));
            thread.SetApartmentState(ApartmentState.STA); //for UI compatibility
            thread.Start(); //start the background loop
        }

        //requests update of a device
        public void QueueDeviceUpdate(GenericDevice device)
        {
            devices.Enqueue(device);
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
                            //send the request or command
                            devices.TryDequeue(out GenericDevice device);
                            port.TransmitRequestOrCommand(device.GetMessage());
                            //if it's a sensor and needs a reply
                            if (device.NeedsResponse)
                            {
                                //get the reply
                                ROVMessage msg = port.WaitReceiveData(1000);
                                //update the device's data on UI thread
                                device.Invoke(new Action(() => device.UpdateData(msg)));
                            }
                            //redraw the device on UI thread
                            device.Invoke(new Action(device.UpdateControls));
                        }
                    }
                    else
                    {
                        //reduce thread's processing time while port is closed
                        Thread.Sleep(100);
                    }
                }
                catch (Exception ex)
                {
                    port.Close(); //stop further exceptions
                    //empty queue of devices needing update
                    while (devices.Count > 0)
                    {
                        devices.TryDequeue(out GenericDevice trash);
                    }
                    //log exception
                    Logger.LogException(ex);
                    Logger.LogString("History: " + port.GetHistory());
                    //fire event
                    if (ExceptionThrown != null)
                        ExceptionThrown(this, ex);
                }
            }
        }
    }
}