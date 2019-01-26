//Edward Li
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
        private ROV rov;
        private SerialCommunication comms;
        private AttitudeIndicator attitudeIndicator;
        private HeadingIndicator headingIndicator;
        private DepthIndicator depthIndicator;
        public X.Gamepad pilot, copilot;

        Boolean isLockClicked = false;
        int depthvalue = 0;
        Boolean RightBumperCheck = false;


        public MainForm()
        {
            //controller
            pilot = X.Gamepad_1;
            pilot.Enable = true;
            pilot.Update(); //must call update right after setting enable to true in order for it to connect
            //copilot = X.Gamepad_2;
            //copilot.Enable = false; //change later on

            //setup window
            this.KeyPreview = true;
            InitializeComponent();

            depthIndicator = new DepthIndicator() { Location = new Point(0, 100) };
            attitudeIndicator = new AttitudeIndicator() { Location = new Point(100, 100) };
            headingIndicator = new HeadingIndicator() { Location = new Point(600, 100) };
            Controls.Add(depthIndicator);
            Controls.Add(attitudeIndicator);
            Controls.Add(headingIndicator);

            //setup devices
            BetterSerialPort port = new BetterSerialPort("COM10", 115200);
            portLabel.Text = string.Format("{0}@{1}baud", port.PortName, port.BaudRate);
            comms = new SerialCommunication(port);
            comms.Stopped += comms_Stopped;
            comms.Started += comms_Started;
            //comms.Connect();

            rov = new ROV(comms);

            //update displays when sensors polled
            rov.OrientationSensor.Updated += OrientationSensor_Updated;
            rov.DepthSensor.Updated += DepthSensor_Updated;
        }

        private void DepthSensor_Updated(object sender, DepthData e)
        {
            depthIndicator.Depth = rov.DepthSensor.Data.DepthValue;
        }

        private void OrientationSensor_Updated(object sender, OrientationData e)
        {
            attitudeIndicator.PitchAngle = rov.OrientationSensor.Data.Pitch;
            attitudeIndicator.RollAngle = rov.OrientationSensor.Data.Roll;
            attitudeIndicator.YawAngle = rov.OrientationSensor.Data.Yaw;
            headingIndicator.Heading = rov.OrientationSensor.Data.Yaw;
        }

        private void comms_Started(object sender, EventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                connectButton.Text = "Comms Started";
            }));
        }

        private void comms_Stopped(object sender, EventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                connectButton.Text = "Comms Stopped";
            }));
        }

        private void timer500_Tick(object sender, EventArgs e)
        {
            queueLabel.Text = "Queue length: " + comms.Queue.Count;
            armButton.Text = rov.StatusSensor.Data.Status == ROVStatus.ARMED ? "Armed" : "Disarmed";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            comms.LinkActive = !comms.LinkActive;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(rov.StatusSensor.Data.Status == ROVStatus.ARMED)
            {
                rov.StatusActuator.Data.DesiredStatus = ROVStatus.DISARMED;
            } else if(rov.StatusSensor.Data.Status == ROVStatus.DISARMED)
            {
                rov.StatusActuator.Data.DesiredStatus = ROVStatus.ARMED;
            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            rov.StatusActuator.Data.DesiredStatus = ROVStatus.REBOOT;
        }


        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Environment.Exit(1);
        }

        private void controllerUpdateTimer_Tick(object sender, EventArgs e)
        {
            pilot.Update();

            //Zeroing Code for left joystick
            int LStickZeroX = pilot.LStick.X;
            if (Math.Abs(LStickZeroX) < 5000)
                LStickZeroX = 0;
            int LStickZeroY = pilot.LStick.Y;
            if (Math.Abs(LStickZeroY) < 5000)
                LStickZeroY = 0;

            //Zeroing Code for right joystick
            int RStickZeroX = pilot.RStick.X;
            if (Math.Abs(RStickZeroX) < 5000)
                RStickZeroX = 0;
            int RStickZeroY = pilot.RStick.Y;
            if (Math.Abs(RStickZeroY) < 5000)
                RStickZeroY = 0;

            

            if (pilot.IsConnected)
            {
                ConnectionB.BackColor = Color.Green;
                ConnectionLabel.Text = "yes";
                button0.Text = "LStick.X" + LStickZeroX;
                button1.Text = "LStick.Y" + LStickZeroY;
                button2.Text = "LStick" + pilot.LStick_down;
                button3.Text = "RStick.X" + RStickZeroX;
                button4.Text = "RStick.Y" + RStickZeroY;
                button5.Text = "DPad up" + pilot.Dpad_Up_down;
                button6.Text = "DPad down" + pilot.Dpad_Down_down;
                button7.Text = "DPad left" + pilot.Dpad_Left_down;
                button8.Text = "DPad right" + pilot.Dpad_Right_down;
                button9.Text = "A" + pilot.A_down;
                button10.Text = "B" + pilot.B_down;
                button11.Text = "X" + pilot.X_down;
                button12.Text = "Y" + pilot.Y_down;
                button13.Text = "LBumper" + pilot.LBumper_down;
                button14.Text = "RBumper" + pilot.RBumper_down;
                button15.Text = "LTrigger" + pilot.LTrigger;
                button16.Text = "RTrigger" + pilot.RTrigger;
                button17.Text = "Start" + pilot.Start_down;
                topLeft.Text = "" + (rov.ForeAftMotion + rov.StrafeMotion - rov.TurnMotion);
                midLeft.Text = "" + rov.VerticalMotion;
                botLeft.Text = "" + (rov.ForeAftMotion - rov.StrafeMotion - rov.TurnMotion);
                topRight.Text = "" + (rov.ForeAftMotion - rov.StrafeMotion + rov.TurnMotion);
                midRight.Text = "" + rov.VerticalMotion;
                botRight.Text = "" + (rov.ForeAftMotion + rov.StrafeMotion + rov.TurnMotion);

                if (pilot.RBumper_down && !RightBumperCheck) //checks if bumper is down
                {
                    isLockClicked = !isLockClicked; //turns on lock position
                    if (isLockClicked)
                    {
                        depthvalue = (int)(rov.DepthSensor.Data.DepthValue);
                    }
                    RightBumperCheck = true; //disables use of bumper until button is let go
                }

                if (pilot.RBumper_up && RightBumperCheck)
                {
                    RightBumperCheck = false; //reenables button if it is let go
                }

                    if (isLockClicked)
                {
                    depthLockButton.BackColor = Color.Green; //edits button in design

                    if (depthvalue < (int)(rov.DepthSensor.Data.DepthValue))
                    {
                        rov.VerticalMotion += 1;  //brings robot up
                    } else
                    {

                        rov.VerticalMotion -= 1;  //brings robot down
                    }
                } else
                {
                    depthLockButton.BackColor = Color.DarkRed;
                    
                }
                    //ACTUATOR CODE for next few lines

                if (pilot.A_down)
                {
                    if (rov.ToolsActuator.Data.Speeds[0]-10 > -100)
                    {
                        rov.ToolsActuator.Data.Speeds[0] -= 10;
                    }
                    else {
                        rov.ToolsActuator.Data.Speeds[0] = -100;
                    }
                }

                if (pilot.B_down)
                {
                    if (rov.ToolsActuator.Data.Speeds[0] + 10 < 100)
                    {
                        rov.ToolsActuator.Data.Speeds[0] += 10;
                    }
                    else
                    {
                        rov.ToolsActuator.Data.Speeds[0] = 100;
                    }
                }


                if (pilot.X_down)
                {
                    if (rov.ToolsActuator.Data.Speeds[1] - 10 > -100)
                    {
                        rov.ToolsActuator.Data.Speeds[1] -= 10;
                    }
                    else
                    {
                        rov.ToolsActuator.Data.Speeds[1] = -100;
                    }
                }

                if (pilot.Y_down)
                {
                    if (rov.ToolsActuator.Data.Speeds[1] + 10 < 100)
                    {
                        rov.ToolsActuator.Data.Speeds[1] += 10;
                    }
                    else
                    {
                        rov.ToolsActuator.Data.Speeds[1] = 100;
                    }
                }


                if (pilot.Dpad_Down_down)
                {
                    if (rov.ToolsActuator.Data.Speeds[2] - 10 > -100)
                    {
                        rov.ToolsActuator.Data.Speeds[2] -= 10;
                    }
                    else
                    {
                        rov.ToolsActuator.Data.Speeds[2] = -100;
                    }
                }

                if (pilot.Dpad_Right_down)
                {
                    if (rov.ToolsActuator.Data.Speeds[2] + 10 < 100)
                    {
                        rov.ToolsActuator.Data.Speeds[2] += 10;
                    }
                    else
                    {
                        rov.ToolsActuator.Data.Speeds[2] = 100;
                    }
                }


                if (pilot.Dpad_Left_down)
                {
                    if (rov.ToolsActuator.Data.Speeds[3] - 10 > -100)
                    {
                        rov.ToolsActuator.Data.Speeds[3] -= 10;
                    }
                    else
                    {
                        rov.ToolsActuator.Data.Speeds[3] = -100;
                    }
                }

                if (pilot.Dpad_Up_down)
                {
                    if (rov.ToolsActuator.Data.Speeds[3] + 10 < 100)
                    {
                        rov.ToolsActuator.Data.Speeds[3] += 10;
                    }
                    else
                    {
                        rov.ToolsActuator.Data.Speeds[3] = 100;
                    }
                }

                //end of actuator code

                //Lstick controls horizontal translations 
                rov.ForeAftMotion = (int)(ConvertUtils.Map(LStickZeroY, -32768, 32767, -100, 100));
                rov.StrafeMotion = (int)(ConvertUtils.Map(LStickZeroX, -32768, 32767, -100, 100));
                if (rov.EnableHeadingLock)
                {
                    //RStick controls desired heading
                    rov.TurnMotion = 0;
                    rov.DesiredHeading += (int)(ConvertUtils.Map(RStickZeroX, -32768, 32767, -100, 100) / 100);
                }
                else
                {
                    //Rstick controls yaw (turning about vertical axis)
                    rov.TurnMotion = (int)(ConvertUtils.Map(RStickZeroX, -32768, 32767, -100, 100));
                }
                    
                //left bumper moves downward, right bumper moves upward
                rov.VerticalMotion = (int)(ConvertUtils.Map(pilot.LTrigger, 0, 255, 0, -100) + ConvertUtils.Map(pilot.RTrigger, 0, 255, 0, 100));
            }
            else
            {
                ConnectionB.BackColor = Color.DarkRed;
                ConnectionLabel.Text = "no";
                depthLockButton.BackColor = Color.DarkRed;
            }
            Actuator1.Value = (int)(ConvertUtils.Map(LStickZeroY, -32768, 32767, 0, 200));
            Actuator2.Value = (int)(ConvertUtils.Map(LStickZeroX, -32768, 32767, 0, 200));
            Actuator3.Value = (int)(ConvertUtils.Map(RStickZeroY, -32768, 32767, 0, 200));
            Actuator4.Value = (int)(ConvertUtils.Map(RStickZeroX, -32768, 32767, 0, 200));
        
        }

        private void Actuator1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < 6; i++)
            {   
                //if(Int32.TryParse(textBox1.Text , out int n))
                   // rov.PropulsionActuator.Data.Speeds[i] = n;
            }
        }
    }   
}
