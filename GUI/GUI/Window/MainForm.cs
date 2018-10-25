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

        public MainForm()
        {
            //setup window
            InitializeComponent();

            //setup devices
            BetterSerialPort port = new BetterSerialPort("COM5", 1000000);
            comms = new SerialCommunication(port);
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
        }

        private void timer500_Tick(object sender, EventArgs e)
        {
            comms.Queue.Enqueue(statusSensor);
            comms.Queue.Enqueue(propulsionSensor);
            comms.Queue.Enqueue(statusActuator);
            label1.Text = "Queue length: " + comms.Queue.Count;
        }

        private void timer50_Tick(object sender, EventArgs e)
        {
            comms.Queue.Enqueue(depthSensor);
            comms.Queue.Enqueue(orientationSensor);
            comms.Queue.Enqueue(toolsActuator);
        }

        private void timer10_Tick(object sender, EventArgs e)
        {
            comms.Queue.Enqueue(propulsionActuator);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Connected")
            {
                comms.Disconnect();
                timer10.Enabled = false;
                timer50.Enabled = false;
                timer500.Enabled = false;
                button1.Text = "Disconnected";
            }
            else
            {
                comms.Connect();
                timer10.Enabled = true;
                timer50.Enabled = true;
                timer500.Enabled = true;
                button1.Text = "Connected";
            }
        }
    }
}
