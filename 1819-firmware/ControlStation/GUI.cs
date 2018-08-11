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
        private StatusActuator system;

        public GUI()
        {
            InitializeComponent();
            //start serial comms
            comms = new SerialCommunication("COM1", 115200);

            //construct sensor and actuator display objects
            depth = new DepthSensor(comms);
            imu = new OrientationSensor(comms);
            thrusters = new PropulsionActuator(comms);
            tools = new ToolsActuator(comms);
            escs = new PropulsionSensor(comms);
            status = new StatusSensor(comms);
            system = new StatusActuator(comms);

            //start timer
            timer100Hz = new Timer();
            timer100Hz.Interval = 10;
            timer100Hz.Tick += new EventHandler(Tick100Hz);
            //timer100Hz.Enabled = true;
        }

        void Tick4Hz()
        {
            escs.Update();
            tools.Update();
            system.Update();

            status.Update();
            depth.Update();
        }

        void Tick100Hz(object sender, EventArgs e)
        {
            try
            {
                //Handle running Tick4Hz on same thread at proper interval
                if (tickCount > 25)
                {
                    Tick4Hz();
                    tickCount = 0;
                }
                thrusters.Update();
                imu.Update();
                tickCount++;
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message, ex.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("Communication history", comms.GetHistory() + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // GUI
            // 
            this.ClientSize = new System.Drawing.Size(1280, 1024);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GUI";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.GUI_Load);
            this.ResumeLayout(false);

        }

        private void GUI_Load(object sender, EventArgs e)
        {
        }
    }
}
