﻿//Edward Li
//Angela Chen
//Darius Kianersi
//Anish Gorentala
//Aneesh Boreda
//Shreepa Parthaje
//Suhas Nandiraju

using System;
using System.Drawing;
using System.Windows.Forms;
using XInput.Wrapper;


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

        private AttitudeIndicator attitudeIndicator;
        private HeadingIndicator headingIndicator;
        private DepthIndicator depthIndicator;
        public X.Gamepad g1;

        public MainForm()
        {
            //controller
            g1 = X.Gamepad_1;
            g1.Enable = true;

            //setup window
            this.KeyPreview = true;
            InitializeComponent();
            controllerUpdate.Enabled = true;

            depthIndicator = new DepthIndicator() { Location = new Point(0, 100) };
            attitudeIndicator = new AttitudeIndicator() { Location = new Point(100, 100) };
            headingIndicator = new HeadingIndicator() { Location = new Point(600, 100) };
            Controls.Add(depthIndicator);
            Controls.Add(attitudeIndicator);
            Controls.Add(headingIndicator);

            //setup devices
            BetterSerialPort port = new BetterSerialPort("COM5", 115200);
            port.Open();
            portLabel.Text = string.Format("{0}@{1}baud", port.PortName, port.BaudRate);
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

            //update displays when sensors polled
            orientationSensor.Updated += OrientationSensor_Updated;
            depthSensor.Updated += DepthSensor_Updated;

            //get ROV firmware version info
            comms.Queue.Enqueue(versionSensor);
        }

        private void DepthSensor_Updated(object sender, DepthData e)
        {
            depthIndicator.Depth = depthSensor.Data.DepthValue;
        }

        private void OrientationSensor_Updated(object sender, OrientationData e)
        {
            attitudeIndicator.PitchAngle = orientationSensor.Data.Pitch;
            attitudeIndicator.RollAngle = orientationSensor.Data.Roll;
            attitudeIndicator.YawAngle = orientationSensor.Data.Yaw;
            headingIndicator.Heading = orientationSensor.Data.Yaw;
        }

        private void comms_Started(object sender, EventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                connectButton.Text = "Comms Started";
                timer500.Enabled = true;
                timer50.Enabled = true;
                timer10.Enabled = true;
            }));
        }

        private void comms_Stopped(object sender, EventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                connectButton.Text = "Comms Stopped";
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
            queueLabel.Text = "Queue length: " + comms.Queue.Count;
            armButton.Text = statusSensor.Data.Status == ROVStatus.ARMED ? "Armed" : "Disarmed";
        }

        private void timer50_Tick(object sender, EventArgs e)
        {
            comms.Queue.Enqueue(depthSensor);
            comms.Queue.Enqueue(orientationSensor);
            comms.Queue.Enqueue(toolsActuator);
        }

        private void timer10_Tick(object sender, EventArgs e)
        {
            try {
                comms.Queue.Enqueue(propulsionActuator);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Unhandled Error: " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void resetButton_Click(object sender, EventArgs e)
        {
            statusActuator.Data.DesiredStatus = ROVStatus.REBOOT;
        }


        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Environment.Exit(1);
        }

        private void controllerUpdateTimer_Tick(object sender, EventArgs e)
        {
            g1.Update();
            if (g1.IsConnected)
            {
                ConnectionB.BackColor = Color.Green;
                ConnectionLabel.Text = "" + g1.LTrigger;
            }
            else
            {
                ConnectionB.BackColor = Color.DarkRed;
                ConnectionLabel.Text = "no" + g1.LTrigger;
            }

        }
    }   
}
