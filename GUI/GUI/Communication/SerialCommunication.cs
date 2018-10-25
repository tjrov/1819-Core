using System;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;
using System.Collections.Concurrent;
using System.IO;
using System.ComponentModel;

namespace GUI
{
    public class SerialCommunication : Component
    {
        private BetterSerialPort port;

        private ConcurrentQueue<GenericAbstractDevice> devices;
        public ConcurrentQueue<GenericAbstractDevice> DeviceQueue
        {
            get
            {
                return devices;
            }
        }
        private Thread thread;

        public event EventHandler<Exception> CommunicationException;
        public event EventHandler Started, Stopped;

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
        public void Connect()
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
            thread.Start();
        }
        public void Disconnect()
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
            thread.Abort();
        }
        //handles communication and processing of queue
        private void BackgroundLoop()
        {
            while (true) {
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
                            //update the device's data
                            device.UpdateData(msg);
                        }
                    }
                }
                catch (Exception ex)
                {
                    //log history before exception for debugging
                    Logger.LogString("Start Communication Log Dump\n" + port.GetHistory() + "\nEnd Communication Log Dump");
                    Logger.LogException(ex);
                    //cease communication
                    Disconnect();
                    //show exception dialog
                    if (CommunicationException != null)
                    {
                        CommunicationException(this, ex);
                    }
                }
            }
        }
    }
}
