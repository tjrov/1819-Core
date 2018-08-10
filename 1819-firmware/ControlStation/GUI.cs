using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlStation
{
    public class GUI : Form
    {
        private SerialCommunication comms;

        private Timer timer100Hz;
        private int tickCount = 0;

        private OrientationSensor imu;
        private DepthSensor depth;
        private PropulsionActuator thrusters;
        private PropulsionSensor escs;
        private StatusSensor status;
        private ToolsActuator tools;

        private ConnectionPanel connection;

        public GUI()
        {
            //TopMost = true; //forefront
            //FormBorderStyle = FormBorderStyle.None; //fullscreen
            WindowState = FormWindowState.Maximized; //maximize window

            //start serial comms
            comms = new SerialCommunication("COM1", 115200);

            connection = new ConnectionPanel(comms);
            Controls.Add(connection);

            //construct sensor and actuator display objects
            imu = new OrientationSensor(comms);
            thrusters = new PropulsionActuator(comms);
            escs = new PropulsionSensor(comms);
            status = new StatusSensor(comms);

            //start timer
            timer100Hz = new Timer();
            timer100Hz.Interval = 10;
            timer100Hz.Tick += new EventHandler(Tick100Hz);
            //timer100Hz.Enabled = true;

            void Tick2Hz()
            {
                //escs.Update();
                status.Update();
                //thrusters.Update();
            }

            void Tick100Hz(object sender, EventArgs e)
            {
                //Handle running Tick2Hz on same thread at proper interval
                if (tickCount > 50)
                {
                    Tick2Hz();
                    tickCount = 0;
                }
                //thrusters.Update();
                //imu.Update();
                tickCount++;
            }
        }
        public class ConnectionPanel : FlowLayoutPanel
        {
            private SerialCommunication comms;
            Button toggle;
            public ConnectionPanel(SerialCommunication comms)
            {
                this.comms = comms;

                BackColor = Color.Azure;
                Size = new Size(100, 200);
                
                toggle = new Button()
                {
                    Text = "Disconnected",
                    BackColor = Color.Red,
                };
                toggle.Click += new EventHandler(ToggleClicked);
                comms.PropertyChanged += UpdateButton;

                Controls.Add(toggle);
            }

            private void UpdateButton(object sender, PropertyChangedEventArgs e)
            {
                if (comms.IsOpen)
                {
                    toggle.BackColor = Color.Green;
                    toggle.Text = "Connected";
                }
                else
                {
                    toggle.BackColor = Color.Red;
                    toggle.Text = "Disconnected";
                }
            }

            private void ToggleClicked(object sender, EventArgs e)
            {
                if (!comms.IsOpen)
                {
                    comms.Open();
                }
                else
                {
                    comms.Close();
                }
                UpdateButton(null, null);
            }
        }
    }
}
