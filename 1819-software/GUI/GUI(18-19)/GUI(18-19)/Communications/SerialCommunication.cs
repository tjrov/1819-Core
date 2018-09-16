using System;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;
using System.Collections.Concurrent;
using System.IO;
using GUI.Devices;
using System.ComponentModel;

namespace GUI.Communication
{
    public class SerialCommunication : Component
    {
        private BetterSerialPort port;

        private ConcurrentQueue<GenericAbstractDevice> devices;
        private Thread thread;

        private bool linkActive;
        private bool shuttingDown;

        public bool LinkActive
        {
            get
            {
                return linkActive;
            }
            set
            {
                if (value)
                {
                    if (!port.IsOpen)
                    {
                        port.Open();
                    }
                    Logger.LogString("Communication started.");
                    if (Started != null)
                    {
                        Started(this, null);
                    }
                }
                else
                {
                    if (port.IsOpen)
                    {
                        port.Close();
                    }
                    //empty queue of devices needing update
                    while (devices.Count > 0)
                    {
                        devices.TryDequeue(out GenericAbstractDevice trash);
                    }
                    Logger.LogString("Communication stopped.");
                    if (Stopped != null)
                    {
                        Stopped(this, null); //notify rest of code with event
                    }
                }
                linkActive = value;
            }
        }

        public event EventHandler<Exception> CommunicationException;
        public event EventHandler Started, Stopped;
        public event EventHandler TenElapsed, HundredElapsed, ThousandElapsed;

        public SerialCommunication(BetterSerialPort port) : base()
        {
            this.port = port;

            //Communications Process
            this.port = port;
            //connection between UI and background threads is a queue of Devices that need updating
            devices = new ConcurrentQueue<GenericAbstractDevice>();

            //background loop runs on this thread
            thread = new Thread(new ThreadStart(BackgroundLoop));
            thread.SetApartmentState(ApartmentState.STA); //for UI compatibility
            thread.IsBackground = true;

            //get going
            thread.Start();
            //port.Open(); //error when port opened in constructor
        }
        public void ShutDown()
        {
            LinkActive = false;
            Thread.Sleep(500);
            shuttingDown = true;
        }
        //requests update of a device
        public void QueueDeviceUpdate(GenericAbstractDevice device)
        {
            devices.Enqueue(device);
        }
        //handles communication and processing of queue
        private void BackgroundLoop()
        {
            long prevTime = DateTime.Now.Ticks;
            int thousandCount = 0;
            int hundredCount = 0;
            while (!shuttingDown)
            {
                if (linkActive)
                {
                    try
                    {
                        //update all queued devices
                        while (devices.Count > 0)
                        {
                            //send the request or command
                            devices.TryDequeue(out GenericAbstractDevice device);
                            port.TransmitRequestOrCommand(device.GetMessage());
                            //if it's a sensor and needs a reply
                            if (device.NeedsResponse)
                            {
                                //get the reply
                                ROVMessage msg = port.WaitReceiveData(1000);
                                //update the device's data on UI thread
                                //device.Invoke(new Action(() => device.UpdateData(msg)));
                            }
                            //redraw the device on UI thread
                            //device.Invoke(new Action(device.UpdateControls));
                        }
                    }
                    catch (Exception ex)
                    {
                        //log history before exception for debugging
                        Logger.LogString("Start Communication Log Dump\n" + port.GetHistory() + "\nEnd Communication Log Dump");
                        Logger.LogException(ex);
                        //cease communication
                        LinkActive = false;
                        //show exception dialog
                        if (CommunicationException != null)
                        {
                            CommunicationException(this, ex);
                        }
                    }
                    //fire timers if necessary
                    if ((DateTime.Now.Ticks - prevTime) > 10 * TimeSpan.TicksPerMillisecond)
                    {
                        //System.Diagnostics.Debug.WriteLine(DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond);
                        //System.Diagnostics.Debug.WriteLine(devices.Count);
                        prevTime = DateTime.Now.Ticks;
                        thousandCount++;
                        hundredCount++;
                        if (thousandCount > 100)
                        {
                            thousandCount = 0;
                            if (ThousandElapsed != null)
                            {
                                ThousandElapsed(this, null);
                            }
                        }
                        else if (hundredCount > 10)
                        {
                            hundredCount = 0;
                            if (HundredElapsed != null)
                            {
                                HundredElapsed(this, null);
                            }
                        }
                        else
                        {
                            if (TenElapsed != null)
                            {
                                TenElapsed(this, null);
                            }
                        }
                    }
                }
                else
                {
                    Thread.Sleep(100);
                }
            }
        }
    }
}
