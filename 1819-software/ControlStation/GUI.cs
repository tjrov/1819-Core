using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ControlStation
{
    public class GUI : Form
    {
        private SerialCommunication comms;

        private int countSlow = 0;
        private int countMedium = 0;
        private Timer timer;

        private OrientationSensor imu;
        private DepthSensor depth;
        private PropulsionActuator thrusters;
        private PropulsionSensor escs;
        private StatusSensor status;
        private ToolsActuator tools;
        private StatusActuator system;

        private List<GenericDevice> devices;

        private FlowLayoutPanel panel;

        public GUI()
        {
            timer = new Timer
            {
                Interval = 10
            };
            timer.Tick += TimerLoop;

            //top window, fullscreen, no border
            ClientSize = new Size(1280, 1024);
            FormBorderStyle = FormBorderStyle.None;
            //TopMost = true;

            //panel to hold subpanels
            panel = new FlowLayoutPanel
            {
                Dock = System.Windows.Forms.DockStyle.Fill,
                Location = new System.Drawing.Point(0, 0),
                Size = new System.Drawing.Size(1280, 1024)
            };

            //setup serial port
            comms = new SerialCommunication("COM7", 250000);
            comms.IsPortOpenChanged += OnIsPortOpenChanged;

            //construct sensor and actuator objects
            depth = new DepthSensor();
            imu = new OrientationSensor();
            escs = new PropulsionSensor();
            thrusters = new PropulsionActuator();
            tools = new ToolsActuator();
            status = new StatusSensor();
            system = new StatusActuator();

            //put them in the dictionary
            devices = new List<GenericDevice>();
            devices.Add(depth);
            devices.Add(imu);
            devices.Add(escs);
            devices.Add(thrusters);
            devices.Add(tools);
            devices.Add(status);
            devices.Add(system);

            //add everything in
            panel.Controls.Add(comms.Panel);
            foreach (GenericDevice device in devices)
            {
                panel.Controls.Add(device);
            }
            Controls.Add(panel);
        }

        private void OnIsPortOpenChanged(object sender, bool e)
        {
            //show any errors from comms
            /*if (commsBackgroundException != null)
            {
                Exception ex = commsBackgroundException;
                commsBackgroundException = null;
                //Showing dialog boxes freezes program. Unsure why
                MessageBox.Show(this, ex.Message + ex.StackTrace,
                  "Error in CommsBackgroundLoop", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(comms.GetHistory() + ex.Message,
                  "Communication history", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }*/
            //enable/disable all device panels
            foreach (GenericDevice device in devices)
            {
                device.Enabled = e;
            }
            //start/stop timer
            timer.Enabled = e;
        }

        private void SlowLoop()
        {
            comms.QueueDevice(escs);
            comms.QueueDevice(system);
            comms.QueueDevice(status);
        }

        private void MediumLoop()
        {
            comms.QueueDevice(imu);
            comms.QueueDevice(depth);
            comms.QueueDevice(tools);
        }

        private void FastLoop()
        {
            comms.QueueDevice(thrusters);
        }

        private void TimerLoop(object sender, EventArgs e)
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
    }
}
