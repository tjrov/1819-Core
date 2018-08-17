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
        private FlowLayoutPanel panel;
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
        private StatusActuator statusControl;
        private List<GenericDevice> devices;

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
                Size = new System.Drawing.Size(1280, 1024),
                BackColor = Color.Black
            };

            //setup serial port
            comms = new SerialCommunication("COM5", 250000);
            comms.IsPortOpenChanged += OnIsPortOpenChanged;

            //construct sensor and actuator objects
            depth = new DepthSensor(new Depth());
            imu = new OrientationSensor(new Orientation());

            List<Tool> toolList = new List<Tool>();
            for(int i = 0; i < 3; i++)
            {
                toolList.Add(new Tool());
            }
            tools = new ToolsActuator(toolList);

            //both use the same data object
            List<ESC> escList = new List<ESC>();
            for (int i = 0; i < 6; i++)
            {
                escList.Add(new ESC());
            }
            escs = new PropulsionSensor(escList);
            thrusters = new PropulsionActuator(escList);

            //both use the same data object
            State state = new State();
            status = new StatusSensor(state);
            statusControl = new StatusActuator(state);

            //put them in the dictionary
            devices = new List<GenericDevice>();
            devices.Add(depth);
            devices.Add(imu);
            devices.Add(escs);
            devices.Add(thrusters);
            devices.Add(tools);
            devices.Add(status);
            devices.Add(statusControl);

            //add everything in
            panel.Controls.Add(comms);
            foreach (GenericDevice device in devices)
            {
                panel.Controls.Add(device);
                device.Enabled = false;
            }
            Controls.Add(panel);
        }

        private void OnIsPortOpenChanged(object sender, bool e)
        {
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
            comms.QueueDevice(statusControl);
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
            if (countSlow > 50)
            {
                countSlow = 0;
                SlowLoop();
            }
            else if (countMedium > 5)
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
