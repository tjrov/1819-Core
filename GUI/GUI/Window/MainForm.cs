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
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Reflection;
using System.IO;

using AForge;
using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge.Math.Geometry;
using AForge.Video;
using AForge.Video.DirectShow;
using AForge.Controls;

using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;

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
        private bool isLockClicked = false;
        private int depthvalue = 0;
        private int numberOfSquares = 0;
        private int numberOfCircles = 0;
        private int numberOfTriangles = 0;
        private int numberOfLines = 0;
        private bool isCapturing = false;
        private VideoCaptureDevice videoSource;
        private FilterInfoCollection videoDevices;
        private bool EMGU = true;

        private enum ControllerKeys { Y, B, A, X, Up, Right, Left, Down, LeftBumper, RightBumper, LeftJoystick, RightJoystick}
        private bool[] pilotKeysUp = new bool[12] { true, true, true, true, true, true, true, true, true, true, true, true };
        private bool[] copilotKeysUp = new bool[12] { true, true, true, true, true, true, true, true, true, true, true, true };

        private int[] activeClawPositions = new int[] { 45, 135 };
        private int[] rockContainerPositions = new int[] { 0, 180 };

        public MainForm()
        {
            //controller
            pilot = X.Gamepad_1;
            pilot.Enable = true;
            //must call update right after setting enable to true in order for it to connect
            pilot.Update(); 
            
            copilot = X.Gamepad_2;
            copilot.Enable = true;
            copilot.Update();

            //setup window
            KeyPreview = true;
            InitializeComponent();

            depthIndicator = new DepthIndicator() { Location = new System.Drawing.Point(20, 100) };
            attitudeIndicator = new AttitudeIndicator() { Location = new System.Drawing.Point(Width - 50, Height) };
            headingIndicator = new HeadingIndicator() { Location = new System.Drawing.Point(0, Height- 100) };
            Controls.Add(depthIndicator);
            Controls.Add(attitudeIndicator);
            Controls.Add(headingIndicator);

            hideAllControllerButtons();

            //setup devices
            BetterSerialPort port = new BetterSerialPort("COM5", 115200);
            portLabel.Text = string.Format("{0}@{1}baud", port.PortName, port.BaudRate);
            comms = new SerialCommunication(port);
            comms.Stopped += comms_Stopped;
            comms.Started += comms_Started;
            comms.CommunicationException += Comms_CommunicationException;
            //comms.Connect();

            rov = new ROV(comms);

            //update displays when sensors polled
            rov.OrientationSensor.Updated += OrientationSensor_Updated;
            rov.DepthSensor.Updated += DepthSensor_Updated;

            // define position for two servos
            rov.ServoActuator.Data.Positions = new double[2] { activeClawPositions[0], rockContainerPositions[0] };

            // enumerate video devices
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            for (int i = 0; i < videoDevices.Count; i++)
            {
                if (videoDevices[i].Name.Equals("OEM Device"))
                {
                    videoSource = new VideoCaptureDevice(videoDevices[i].MonikerString);
                    videoSource.CrossbarVideoInput = videoSource.AvailableCrossbarVideoInputs[1];
                    videoSource.VideoResolution = videoSource.VideoCapabilities[1];
                }
            }
            // set NewFrame event handler
            try
            {
                videoSource.NewFrame += new NewFrameEventHandler(video_NewFrame);
            }
            catch (NullReferenceException ex)
            {
                //fill in later, catch made temporarily to ignore NullReferenceException
            }
            picture.SizeMode = PictureBoxSizeMode.StretchImage;
            
        }

        private void Comms_CommunicationException(object sender, Exception e)
        {
            MessageBox.Show(e.Message, "Communication Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void ProcessImage(Bitmap bitmap)
        {
            numberOfCircles = 0;
            numberOfLines = 0;
            numberOfSquares = 0;
            numberOfTriangles = 0;

            SpeciesFinder cv;

            if (EMGU) {
                cv = new EmguSpeciesFinder(bitmap);
            } else {
                cv = new AForgeSpeciesFinder(bitmap);
            }

            Bitmap final = cv.FindSpecies();

            triangleCount.Text = cv.Triangles.ToString();
            CircleCount.Text = cv.Circles.ToString();
            SquareCount.Text = cv.Squares.ToString();
            RectangleCount.Text = cv.Lines.ToString();
        }
        private AForge.Point[] ToPointsArray(List<IntPoint> points)
        {
            AForge.Point[] array = new AForge.Point[points.Count];

            for (int i = 0, n = points.Count; i < n; i++)
            {
                array[i] = new AForge.Point(points[i].X, points[i].Y);
            }

            return array;
        }

        private void comms_Started(object sender, EventArgs e)
        {
            Invoke(new Action(() =>
            {
                connectButton.Text = "Comms Started";
            }));
        }

        private void comms_Stopped(object sender, EventArgs e)
        {
            Invoke(new Action(() =>
            {
                connectButton.Text = "Comms Stopped";
            }));
        }

        private void timer500_Tick(object sender, EventArgs e)
        {
            queueLabel.Text = "Queue length: " + comms.Queue.Count;
            armButton.Text = rov.StatusSensor.Data.Status == ROVStatus.ARMED ? "Armed" : "Disarmed";
        }

        private void connectROV_Click(object sender, EventArgs e)
        {
            comms.LinkActive = !comms.LinkActive;
        }

        private void arm_Click(object sender, EventArgs e)
        {
            if (rov.StatusSensor.Data.Status == ROVStatus.ARMED)
            {
                rov.StatusActuator.Data.DesiredStatus = ROVStatus.DISARMED;
            }
            else if (rov.StatusSensor.Data.Status == ROVStatus.DISARMED)
            {
                rov.StatusActuator.Data.DesiredStatus = ROVStatus.ARMED;
            }
        } 

        private void backPrefButton_Click(object sender, EventArgs e)
        {
            forPrefButton.BackColor = Color.Red;
            backPrefButton.BackColor = Color.Green;
            leftPrefButton.BackColor = Color.Red;
            rightPrefButton.BackColor = Color.Red;
            rov.setDirection(2);
        }
        private void forPrefButton_Click(object sender, EventArgs e)
        {
            forPrefButton.BackColor = Color.Green;
            backPrefButton.BackColor = Color.Red;
            leftPrefButton.BackColor = Color.Red;
            rightPrefButton.BackColor = Color.Red;
            rov.setDirection(0);
        }
        private void leftPrefButton_Click(object sender, EventArgs e)
        {
            forPrefButton.BackColor = Color.Red;
            backPrefButton.BackColor = Color.Red;
            leftPrefButton.BackColor = Color.Green;
            rightPrefButton.BackColor = Color.Red;
            rov.setDirection(3);
        }

        private void rightPrefButton_Click(object sender, EventArgs e)
        {
            forPrefButton.BackColor = Color.Red;
            backPrefButton.BackColor = Color.Red;
            leftPrefButton.BackColor = Color.Red;
            rightPrefButton.BackColor = Color.Green;
            rov.setDirection(1);
        }
        private void resetButton_Click(object sender, EventArgs e)
        {
            rov.StatusActuator.Data.DesiredStatus = ROVStatus.REBOOT;
        }


        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Environment.Exit(0);
            }
        }

        private void controllerUpdateTimer_Tick(object sender, EventArgs e)
        {
            #region Pilot Controller
            pilot.Update();

            //Zeroing Code for left joystick
            int LStickZeroX = pilot.LStick.X;
            if (Math.Abs(LStickZeroX) < 5000)
            {
                LStickZeroX = 0;
            }

            int LStickZeroY = pilot.LStick.Y;
            if (Math.Abs(LStickZeroY) < 5000)
            {
                LStickZeroY = 0;
            }

            //Zeroing Code for right joystick
            int RStickZeroX = pilot.RStick.X;
            if (Math.Abs(RStickZeroX) < 5000)
            {
                RStickZeroX = 0;
            }

            int RStickZeroY = pilot.RStick.Y;
            if (Math.Abs(RStickZeroY) < 5000)
            {
                RStickZeroY = 0;
            }

            if (pilot.IsConnected)
            {
                PilotConnectionLabel.Text = "Pilot Controller Connected";
                PilotConnectionLabel.ForeColor = Color.Green;

                updatePilotButtons();

                #region button update
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
                #endregion

                #region Code for displaying motor values
                topLeft.Text = (rov.ForeAftMotion + rov.StrafeMotion - rov.TurnMotion) >= 0 ? "" + Math.Min(rov.ForeAftMotion + rov.StrafeMotion - rov.TurnMotion, 100) : "" + Math.Max(rov.ForeAftMotion + rov.StrafeMotion - rov.TurnMotion, -100);
                midLeft.Text = "" + rov.VerticalMotion;
                botLeft.Text = (rov.ForeAftMotion - rov.StrafeMotion - rov.TurnMotion) >= 0 ? "" + Math.Min(rov.ForeAftMotion - rov.StrafeMotion - rov.TurnMotion, 100) : "" + Math.Max(rov.ForeAftMotion - rov.StrafeMotion - rov.TurnMotion, -100);
                topRight.Text = (rov.ForeAftMotion - rov.StrafeMotion + rov.TurnMotion) >= 0 ? "" + Math.Min(rov.ForeAftMotion - rov.StrafeMotion + rov.TurnMotion, 100) : "" + Math.Max(rov.ForeAftMotion - rov.StrafeMotion + rov.TurnMotion, -100);
                midRight.Text = "" + rov.VerticalMotion;
                botRight.Text = (rov.ForeAftMotion + rov.StrafeMotion + rov.TurnMotion) >= 0 ? "" + Math.Min(rov.ForeAftMotion + rov.StrafeMotion + rov.TurnMotion, 100) : "" + Math.Max(rov.ForeAftMotion + rov.StrafeMotion + rov.TurnMotion, -100);
                #endregion

                #region depth lock
                if (pilot.Y_down && pilotKeysUp[(int) ControllerKeys.Y]) //checks if Y is down
                {
                    isLockClicked = !isLockClicked; //turns on lock position
                    if (isLockClicked)
                    {
                        depthvalue = (int)(rov.DepthSensor.Data.DepthValue);
                    }
                    pilotKeysUp[(int)ControllerKeys.Y] = false; //disables use of bumper until button is let go
                } else if (!pilot.Y_down)
                {
                    pilotKeysUp[(int)ControllerKeys.Y] = true; //reenables button if it is let go
                }

                if (isLockClicked)
                {
                    depthLockEngageLabel.ForeColor = Color.Green;
                    depthLockEngageLabel.Text = "Depth Lock Engaged";

                    if (depthvalue < (int)(rov.DepthSensor.Data.DepthValue))
                    {
                        rov.VerticalMotion += 1;  //brings robot up
                    }
                    else
                    {

                        rov.VerticalMotion -= 1;  //brings robot down
                    }
                }
                else
                {
                    depthLockEngageLabel.ForeColor = Color.DarkRed;
                    depthLockEngageLabel.Text = "Depth Lock Disengaged";

                }
                #endregion

                #region heading lock
                if (pilot.B_down && pilotKeysUp[(int) ControllerKeys.B]) {
                    rov.EnableHeadingLock = !EnableHeadingLock;
                    pilotKeysUp[(int) ControllerKeys.B] = false;
                } else if (!pilot.B_down) {
                    pilotKeysUp[(int) ControllerKeys.B] = true;
                }

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
                #endregion

                #region roll lock
                if (pilot.A_down && pilotKeysUp[(int) ControllerKeys.A]) {
                    rov.EnableRollLock = !rov.EnableRollLock;
                    pilotKeysUp[(int) ControllerKeys.A] = false;
                } else if (!pilot.A_down) {
                    pilotKeysUp[(int) ControllerKeys.A] = true;
                }
                #endregion

                #region ROV Motion
                //Lstick controls horizontal translations 
                rov.ForeAftMotion = (int)(ConvertUtils.Map(LStickZeroY, -32768, 32767, -100, 100));
                rov.StrafeMotion = (int)(ConvertUtils.Map(LStickZeroX, -32768, 32767, -100, 100));
                //left bumper moves downward, right bumper moves upward
                rov.VerticalMotion = (int)(ConvertUtils.Map(pilot.RTrigger, 0, 255, 0, -100) + ConvertUtils.Map(pilot.LTrigger, 0, 255, 0, 100));
                #endregion

                #region Direction Lock
                if  (pilot.Dpad_Up_down && pilotKeysUp[(int)ControllerKeys.Up]) 
                {
                    forPrefButton_Click(null, null);
                    pilotKeysUp[(int)ControllerKeys.Up] = false;
                } else if (!pilot.Dpad_Up_down) {
                    pilotKeysUp[(int)ControllerKeys.Up] = true;
                }

                if (pilot.Dpad_Right_down && pilotKeysUp[(int)ControllerKeys.Right])
                {
                    rightPrefButton_Click(null, null);
                    pilotKeysUp[(int)ControllerKeys.Right] = false;
                } else if (!pilot.Dpad_Right_down) {
                    pilotKeysUp[(int)ControllerKeys.Right] = true;
                }
                
                if (pilot.Dpad_Down_down && pilotKeysUp[(int)ControllerKeys.Down])
                {
                    backPrefButton_Click(null, null);
                    pilotKeysUp[(int)ControllerKeys.Down] = false;
                } else if (!pilot.Dpad_Down_down){
                    pilotKeysUp[(int)ControllerKeys.Down] = true;
                }

                if (pilot.Dpad_Left_down && pilotKeysUp[(int)ControllerKeys.Left])
                {
                    leftPrefButton_Click(null, null);
                    pilotKeysUp[(int)ControllerKeys.Left] = false;
                } else if (!pilot.Dpad_Left_down) {
                    pilotKeysUp[(int)ControllerKeys.Left] = true;
                }

                #endregion

            } else
            {
                PilotConnectionLabel.Text = "Pilot Controller Not Connected";
                PilotConnectionLabel.ForeColor = Color.DarkRed;
                depthLockEngageLabel.ForeColor = Color.DarkRed;
                depthLockEngageLabel.Text = "Depth Lock Disengaged";
                // TODO: add a heading lock + depth lock indicator
                rov.VerticalMotion = 0.0;
                rov.ForeAftMotion = 0.0;
                rov.StrafeMotion = 0.0;
                rov.TurnMotion = 0.0;
            }
            trackBar1.Value = (int)(ConvertUtils.Map(LStickZeroY, -32768, 32767, 0, 200));
            trackBar2.Value = (int)(ConvertUtils.Map(LStickZeroX, -32768, 32767, 0, 200));
            trackBar3.Value = (int)(ConvertUtils.Map(RStickZeroY, -32768, 32767, 0, 200));
            trackBar4.Value = (int)(ConvertUtils.Map(RStickZeroX, -32768, 32767, 0, 200));
            #endregion

            #region Copilot Controller
            copilot.Update();

            if (copilot.IsConnected)
            {
                CopilotConnectionLabel.Text = "Copilot Controller Connected";
                CopilotConnectionLabel.ForeColor = Color.Green;
                updateCopilotButtons();

                #region Servo Controls
                if (copilot.Y_down && copilotKeysUp[(int)ControllerKeys.Y])
                {
                    // switch servo one (active claw)
                    // TODO: Display for this
                    if (rov.ServoActuator.Data.Positions[0] == activeClawPositions[0]) {
                        rov.ServoActuator.Data.Positions[0] = activeClawPositions[1];
                    } else {
                        rov.ServoActuator.Data.Positions[0] = activeClawPositions[0];
                    }
                    copilotKeysUp[(int)ControllerKeys.Y] = false;
                } else if (!copilot.Y_down) {
                    copilotKeysUp[(int)ControllerKeys.Y] = true;
                }

                if (copilot.B_down && copilotKeysUp[(int)ControllerKeys.B])
                {
                    // switch servo two (rock holding container)
                    // TODO: Display for this
                    // TODO: Remove Chart
                    if (rov.ServoActuator.Data.Positions[0] == rockContainerPositions[0]) {
                        rov.ServoActuator.Data.Positions[0] = rockContainerPositions[1];
                    } else {
                        rov.ServoActuator.Data.Positions[0] = rockContainerPositions[0];
                    }        
                    copilotKeysUp[(int)ControllerKeys.B] = false;
                } else if (!copilot.B_down) {
                    copilotKeysUp[(int)ControllerKeys.B] = true;
                }

                if (copilot.A_down && copilotKeysUp[(int)ControllerKeys.A])
                {
                    // activate MiniROV?
                    copilotKeysUp[(int)ControllerKeys.A] = false;
                } else if (!copilot.A_down) {
                    copilotKeysUp[(int)ControllerKeys.A] = true;
                }

                if (copilot.X_down && copilotKeysUp[(int)ControllerKeys.X])
                {
                    // nothing
                    copilotKeysUp[(int) ControllerKeys.X] = false;
                } else if (!copilot.X_down) {
                    copilotKeysUp[(int) ControllerKeys.X] = true;
                }
                #endregion

                #region Other Controls
                if (copilot.Dpad_Up_down && copilotKeysUp[(int)ControllerKeys.Up])
                {
                    // start camera
                    capButton_Click(null, null);
                    copilotKeysUp[(int)ControllerKeys.Up] = false;
                } else if (!copilot.Dpad_Up_down) {
                    copilotKeysUp[(int)ControllerKeys.Up] = true;
                }

                if (copilot.Dpad_Right_down && copilotKeysUp[(int)ControllerKeys.Right])
                {
                    // find shapes
                    computerVisionButtonClick(null, null);
                    copilotKeysUp[(int)ControllerKeys.Right] = false;
                } else if (!copilot.Dpad_Right_down) {
                    copilotKeysUp[(int)ControllerKeys.Right] = true;
                }
                #endregion

            } else
            {
                CopilotConnectionLabel.Text = "Copilot Controller Not Connected";
                CopilotConnectionLabel.ForeColor = Color.DarkRed;
            }

            #endregion
        }

        private void hideAllControllerButtons()
        {
            pilotAIndicator.Visible = false;
            pilotBIndicator.Visible = false;
            pilotYIndicator.Visible = false;
            pilotXIndicator.Visible = false;
            pilotLBumperIndicator.Visible = false;
            pilotLTriggerIndicator.Visible = false;
            pilotRBumperIndicator.Visible = false;
            pilotRTriggerIndicator.Visible = false;
            pilotLStickIndicator.Visible = false;
            pilotRStickIndicator.Visible = false;
            pilotUpIndicator.Visible = false;
            pilotRightIndicator.Visible = false;
            pilotDownIndicator.Visible = false;
            pilotLeftIndicator.Visible = false;

            copilotAIndicator.Visible = false;
            copilotBIndicator.Visible = false;
            copilotYIndicator.Visible = false;
            copilotXIndicator.Visible = false;
            copilotLBumperIndicator.Visible = false;
            copilotLTriggerIndicator.Visible = false;
            copilotRBumperIndicator.Visible = false;
            copilotRTriggerIndicator.Visible = false;
            copilotLStickIndicator.Visible = false;
            copilotRStickIndicator.Visible = false;
            copilotUpIndicator.Visible = false;
            copilotRightIndicator.Visible = false;
            copilotDownIndicator.Visible = false;
            copilotLeftIndicator.Visible = false;
        }

        private void updatePilotButtons() {
            pilotAIndicator.Visible = pilot.A_down;
            pilotBIndicator.Visible = pilot.B_down;
            pilotYIndicator.Visible = pilot.Y_down;
            pilotXIndicator.Visible = pilot.X_down;
            pilotLBumperIndicator.Visible = pilot.LBumper_down;
            pilotLTriggerIndicator.Visible = pilot.LTrigger > 0; // 0 - 255
            // TODO: change button value to actual value
            pilotRBumperIndicator.Visible = pilot.RBumper_down;
            pilotRTriggerIndicator.Visible = pilot.RTrigger > 0; // 0 - 255
            // TODO: change button value to actual value
            pilotLStickIndicator.Visible = pilot.LStick_down;
            pilotRStickIndicator.Visible = pilot.RStick_down;
            pilotUpIndicator.Visible = pilot.Dpad_Up_down;
            pilotRightIndicator.Visible = pilot.Dpad_Right_down;
            pilotDownIndicator.Visible = pilot.Dpad_Down_down;
            pilotLeftIndicator.Visible = pilot.Dpad_Left_down;
        }

        private void updateCopilotButtons() {
            copilotAIndicator.Visible = copilot.A_down;
            copilotBIndicator.Visible = copilot.B_down;
            copilotYIndicator.Visible = copilot.Y_down;
            copilotXIndicator.Visible = copilot.X_down;
            copilotLBumperIndicator.Visible = copilot.LBumper_down;
            copilotLTriggerIndicator.Visible = copilot.LTrigger > 0; // 0 - 255
            // TODO: change button value to actual value
            copilotRBumperIndicator.Visible = copilot.RBumper_down;
            copilotRTriggerIndicator.Visible = copilot.RTrigger > 0; // 0 - 255
            // TODO: change button value to actual value
            copilotLStickIndicator.Visible = copilot.LStick_down;
            copilotRStickIndicator.Visible = copilot.RStick_down;
            copilotUpIndicator.Visible = copilot.Dpad_Up_down;
            copilotRightIndicator.Visible = copilot.Dpad_Right_down;
            copilotDownIndicator.Visible = copilot.Dpad_Down_down;
            copilotLeftIndicator.Visible = copilot.Dpad_Left_down;
        }

        /* code for some mission, commented out for now
        private void button18_Click(object sender, EventArgs e)
        {
            double L = Double.Parse(LengthOfBarrel.Text);
            double R1 = Double.Parse(InnerRadius1.Text);
            double R2 = Double.Parse(InnerRadius2.Text);
            double R3 = Double.Parse(InnerRadius3.Text);
            double hole = Math.PI * (Math.Pow(R2, 2)) * L;
            double cone = Math.PI * L / 3 * (Math.Pow(R1, 2) + Math.Pow(R3, 2) + R1 * R3);
            double result = cone - hole;
            answerBox.Text = result.ToString();  
        }
         */

        private void computerVisionButtonClick(object sender, EventArgs e)
        {
            ProcessImage(video);
        }

        private void forTestingPurposes_Click(object sender, EventArgs e)
        {
            rov.ForeAftMotion = 100;
        }

        private void capButton_Click(object sender, EventArgs e)
        {
            if(videoSource == null)
            {
                DialogResult res = MessageBox.Show("There isn't a video source connected.", "No Camera", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cvButton.Enabled = false;
            }
            else
            {
                if (isCapturing)
                {
                    isCapturing = false;
                    capButton.Text = "Start Camera";
                    videoSource.SignalToStop();
                }
                else
                {
                    isCapturing = true;
                    capButton.Text = "Stop Camera";
                    videoSource.Start();
                }
                cvButton.Enabled = true;
            }
            
        }

        private Bitmap video;

        private void video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            video = (Bitmap) eventArgs.Frame.Clone();
            picture.Image = video;
            // note picture does not display image; however, creating a new picturebox in the designer does
            // TODO: create a new picture box
        }
    }
}
