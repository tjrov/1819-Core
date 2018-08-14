using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ControlStation
{
    public class GUI : Form
    {
        private SerialCommunication comms;

        private System.Windows.Forms.Timer checkCommsTimer;

        private Thread commsBackgroundThread;
        private Exception commsBackgroundException;
        private int countSlow = 0;
        private int countMedium = 0;

        private OrientationSensor imu;
        private DepthSensor depth;
        private PropulsionActuator thrusters;
        private PropulsionSensor escs;
        private StatusSensor status;
        private ToolsActuator tools;
        private StatusActuator system;

        private Dictionary<string, GenericDevice> devices;

        private FlowLayoutPanel panel;

        public GUI()
        {
            //top window, fullscreen, no border
            ClientSize = new Size(1280, 1024);
            FormBorderStyle = FormBorderStyle.None;
            //TopMost = true;

            //panel to hold subpanels
            panel = new FlowLayoutPanel
            {
                Dock = System.Windows.Forms.DockStyle.Fill,
                Location = new System.Drawing.Point(0, 0),
                Size = new System.Drawing.Size(1280, 1024),
            };

            //timer to regularly check comm status
            checkCommsTimer = new System.Windows.Forms.Timer
            {
                Interval = 200,
            };
            checkCommsTimer.Tick += CheckComms;

            //start serial comms
            comms = new SerialCommunication("COM7", 250000);
            panel.Controls.Add(comms);

            //construct sensor and actuator display objects
            depth = new DepthSensor(comms);
            imu = new OrientationSensor(comms);
            escs = new PropulsionSensor(comms);
            thrusters = new PropulsionActuator(comms);
            tools = new ToolsActuator(comms);
            status = new StatusSensor(comms);
            system = new StatusActuator(comms);
            system.LinkTo(status);

            devices = new Dictionary<string, GenericDevice>();
            devices.Add("status", status);
            devices.Add("system", system);

            //add devices to panel
            foreach (GenericDevice device in devices.Values)
            {
                panel.Controls.Add(device);
            }

            //does communication on a background thread
            commsBackgroundThread = new Thread(new ThreadStart(CommsBackgroundLoop));
            commsBackgroundThread.SetApartmentState(ApartmentState.STA); //comptabile with UI threads
            commsBackgroundThread.Start();

            //start timer once everything else is ready
            checkCommsTimer.Start();

            //draw it
            Controls.Add(panel);
            Invalidate();
            //ResumeLayout(false);
        }

        private void CheckComms(object sender, EventArgs e)
        {
            //show any errors from comms
            if (commsBackgroundException != null)
            {
                Exception ex = commsBackgroundException;
                commsBackgroundException = null;
                //Showing dialog boxes freezes program. Unsure why
                //MessageBox.Show(this, ex.Message + ex.StackTrace,
                //  "Error in CommsBackgroundLoop", MessageBoxButtons.OK, MessageBoxIcon.Error);*/
                //MessageBox.Show(comms.GetHistory() + ex.Message,
                //  "Communication history", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //enable/disable all device panels
            foreach (GenericDevice device in devices.Values)
            {
                device.Enabled = comms.PortIsOpen;
            }
            //update the button on comms
            comms.Invalidate();
        }

        private void SlowLoop()
        {
            escs.Update();
            system.Update();
            status.Update();
        }

        private void MediumLoop()
        {
            imu.Update();
            depth.Update();
            tools.Update();
        }

        private void FastLoop()
        {
            thrusters.Update();
        }

        private void CommsBackgroundLoop()
        {
            while (true)
            {
                if (comms.PortIsOpen)
                {
                    try
                    {
                        countSlow++;
                        countMedium++;
                        if (countSlow > 5)
                        {
                            countSlow = 0;
                            SlowLoop();
                        }
                        else if (countMedium > 50)
                        {
                            countMedium = 0;
                            MediumLoop();
                        }
                        else
                        {
                            FastLoop();
                        }
                    }
                    catch (Exception ex)
                    {
                        commsBackgroundException = ex;
                    }
                }
            }
        }
    }
}
