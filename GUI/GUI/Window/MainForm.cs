using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class MainForm : Form
    {
        private DepthSensor depthSensor;
        private OrientationSensor orientationSensor;
        private StatusSensor statusSensor;
        private PropulsionSensor propulsionSensor;
        private VersionSensor versionSensor;

        private StatusActuator statusActuator;
        private PropulsionActuator propulsionActuator;
        private ToolsActuator toolsActuator;

        private SerialCommunication comms;

        private Boolean Fullscreen = false;

        public MainForm()
        {
            //setup window
            InitializeComponent();

            //setup devices
            BetterSerialPort port = new BetterSerialPort("COM5", 500000);
            port.Open();
            comms = new SerialCommunication(port);
            comms.Stopped += comms_Stopped;
            comms.Started += comms_Started;
            //comms.Connect();

            depthSensor = new DepthSensor();
            orientationSensor = new OrientationSensor();
            statusSensor = new StatusSensor();
            propulsionSensor = new PropulsionSensor();
            versionSensor = new VersionSensor();

            statusActuator = new StatusActuator();
            propulsionActuator = new PropulsionActuator();
            toolsActuator = new ToolsActuator();

            //get ROV firmware version info
            comms.Queue.Enqueue(versionSensor);

            //go Fullscreen
            GoFullscreen();
        }

        public void GoFullscreen()
        {
            if (!Fullscreen)
            {
                this.WindowState = FormWindowState.Normal;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                this.Bounds = Screen.PrimaryScreen.Bounds;
                Fullscreen = !Fullscreen;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
                Fullscreen = !Fullscreen;
            }
        }

        private void comms_Started(object sender, EventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                button1.Text = "Comms Started";
                timer500.Enabled = true;
                timer50.Enabled = true;
                timer10.Enabled = true;
            }));
        }

        private void comms_Stopped(object sender, EventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                button1.Text = "Comms Stopped";
                timer500.Enabled = false;
                timer50.Enabled = false;
                timer10.Enabled = false;
            }));
        }

        private void timer500_Tick(object sender, EventArgs e)
        {
            //statusActuator.Data.DesiredStatus = ROVStatus.ARMED;
            comms.Queue.Enqueue(statusSensor);
            comms.Queue.Enqueue(propulsionSensor);
            comms.Queue.Enqueue(statusActuator);
            label1.Text = "Queue length: " + comms.Queue.Count;
            button2.Text = statusSensor.Data.Status == ROVStatus.ARMED ? "Armed" : "Disarmed";
        }

        private void timer50_Tick(object sender, EventArgs e)
        {
            comms.Queue.Enqueue(depthSensor);
            comms.Queue.Enqueue(orientationSensor);
            //comms.Queue.Enqueue(toolsActuator);
        }

        private void timer10_Tick(object sender, EventArgs e)
        {
            comms.Queue.Enqueue(propulsionActuator);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            comms.LinkActive = !comms.LinkActive;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(statusSensor.Data.Status == ROVStatus.ARMED)
            {
                statusActuator.Data.DesiredStatus = ROVStatus.DISARMED;
            } else if(statusSensor.Data.Status == ROVStatus.DISARMED)
            {
                statusActuator.Data.DesiredStatus = ROVStatus.ARMED;
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Form.ActiveForm.Close();
        }
    }
}
