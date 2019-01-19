//Edward Li
//Angela Chen
// Darius Kianersi
//Anish Gorentala
//Aneesh Boreda
// Shreepa Parthaje
// Suhas Nandiraju

using SlimDX.DirectInput;
using System;
using System.Collections.Generic;
using System.Drawing;
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

        //Gampads
        public DirectInput Input = new DirectInput();
        public Joystick stick;
        public Joystick[] Sticks;
        int yValueL = 0;
        int xValueL = 0;
        int zValue = 0;
        int tickCount = 0;
        public Boolean connected1 = false;

        private AttitudeIndicator attitudeIndicator;
        private HeadingIndicator headingIndicator;
        private DepthIndicator depthIndicator;

        public MainForm()
        {
            //setup window
            this.KeyPreview = true;
            InitializeComponent();
            Sticks = GetSticks();
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

        public Joystick[] GetSticks()
        {
            List<Joystick> sticks = new List<Joystick>();
            foreach(DeviceInstance device in Input.GetDevices(DeviceClass.GameController,DeviceEnumerationFlags.AttachedOnly))
            {
                try
                {
                    stick = new Joystick(Input, device.InstanceGuid);
                    stick.Acquire();

                    foreach(DeviceObjectInstance deviceObject in stick.GetObjects())
                    {
                        if((deviceObject.ObjectType & ObjectDeviceType.Axis) != 0)
                        {
                            stick.GetObjectPropertiesById((int)deviceObject.ObjectType).SetRange(-100, 100);
                        }
                    }
                    sticks.Add(stick);
                }
                catch(DirectInputException ex)
                {
                    MessageBox.Show("Controller Error: " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (sticks.Count != 0)
            {
                connected1 = true;
            }
            else
                connected1 = false;
            return sticks.ToArray();
        }

        public void StickHandle(Joystick stick, int id)
        {
            JoystickState state = new JoystickState();
            state = stick.GetCurrentState();

            if (-state.Y != 0)
            {
                yValueL = -state.Y;
                if(yValueL < 9 && yValueL > -9)
                {
                    yValueL = 0;
                }
                y.Text = "" + yValueL;
            }
            if (state.X != 0)
            {
                xValueL = state.X;
                if (xValueL < 9 && xValueL > -9)
                {
                    xValueL = 0;
                }
                x.Text = "" + xValueL;
            }
            zValue = state.Z;

            bool[] buttons = state.GetButtons();

            if(id == 0)
            {
                for(int i = 0; i < buttons.Length; i++)
                {
                    switch (i)
                    {
                        case 0:
                            if (buttons[0] != false)
                                button0.Text = "Pressed";
                            else
                                button0.Text = "N/A";
                            break;
                        case 1:
                            if (buttons[1] != false)
                                button1.Text = "Pressed";
                            else
                                button1.Text = "N/A";
                            break;
                        case 2:
                            if (buttons[2] != false)
                                button2.Text = "Pressed";
                            else
                                button2.Text = "N/A";
                            break;
                        case 3:
                            if (buttons[3] != false)
                                button3.Text = "Pressed";
                            else
                                button3.Text = "N/A";
                            break;
                        case 4:
                            if (buttons[4] != false)
                                button4.Text = "Pressed";
                            else
                                button4.Text = "N/A";
                            break;
                        case 5:
                            if (buttons[5] != false)
                                button5.Text = "Pressed";
                            else
                                button5.Text = "N/A";
                            break;
                        case 6:
                            if (buttons[6] != false)
                                button6.Text = "Pressed";
                            else
                                button6.Text = "N/A";
                            break;
                        case 7:
                            if (buttons[7] != false)
                                button7.Text = "Pressed";
                            else
                                button7.Text = "N/A";
                            break;
                        case 8:
                            if (buttons[8] != false)
                                button8.Text = "Pressed";
                            else
                                button8.Text = "N/A";
                            break;
                        case 9:
                            if (buttons[9] != false)
                                button9.Text = "Pressed";
                            else
                                button9.Text = "N/A";
                            break;
                        case 10:
                            if (buttons[10] != false)
                                button10.Text = "Pressed";
                            else
                                button10.Text = "N/A";
                            break;
                        case 11:
                            if (buttons[11] != false)
                                button11.Text = "Pressed";
                            else
                                button11.Text = "N/A";
                            break;
                        case 12:
                            if (buttons[12] != false)
                                button12.Text = "Pressed";
                            else
                                button12.Text = "N/A";
                            break;
                        case 13:
                            if (buttons[13] != false)
                                button13.Text = "Pressed";
                            else
                                button13.Text = "N/A";
                            break;
                        case 14:
                            if (buttons[14] != false)
                                button14.Text = "Pressed";
                            else
                                button14.Text = "N/A";
                            break;
                        case 15:
                            if (buttons[15] != false)
                                button15.Text = "Pressed";
                            else
                                button15.Text = "N/A";
                            break;
                        default:
                            break;
                    }
                }
            }
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

        private void controllerUpdate_Tick(object sender, EventArgs e)
        {
            if(tickCount >= 10)
            {
                Sticks = GetSticks();
                tickCount = 0;
            }
            if (connected1)
            {
                ConnectionLabel.Text = "Controller Connected = True";
                ConnectionB.BackColor = Color.LimeGreen;
            }
            else
            {
                ConnectionLabel.Text = "Controller Connected = False";
                ConnectionB.BackColor = Color.DarkRed;
            }

            for (int i = 0; i < Sticks.Length; i++)
            {
                StickHandle(Sticks[i], i);
            }
            Console.WriteLine(tickCount);
            tickCount++;
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Environment.Exit(1);
        }
    }
}
