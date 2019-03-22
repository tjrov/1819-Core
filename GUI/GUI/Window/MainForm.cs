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
        private bool RightBumperCheck = false;
        private int numberOfSquares = 0;
        private int numberOfCircles = 0;
        private int numberOfTriangles = 0;
        private int numberOfLines = 0;
        private bool isCapturing = false;
        private VideoCaptureDevice videoSource;
        private FilterInfoCollection videoDevices;
        private bool EMGU = false;

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
            // define position for four servos
            rov.ToolsActuator.Data.Speeds = new double[4] { 100, 100, 100, 100 };

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

            if (EMGU) {
                #region EmguCV

                #region Processing
                Image<Bgr, Byte> source = new Image<Bgr, Byte>(bitmap);
                var temp = source.SmoothGaussian(5).Convert<Gray, byte>().ThresholdBinaryInv(new Gray(88), new Gray(255));
                #endregion

                #region Find contours
                VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
                CvInvoke.FindContours(temp, contours, new Mat(), RetrType.External, ChainApproxMethod.ChainApproxSimple);
                #endregion

                #region guess shapes
                Image<Bgr, byte> final = source.Copy();
                double approxAmount = 0.05;
                double minRatio = 0.8; // 0.973
                double maxRatio = 1 / minRatio;
                double minArea = 150;
                double bx = 5;

                for (int i = 0; i < contours.Size; i++) {
                    var contour = contours[i];
                    double perimeter = CvInvoke.ArcLength(contour, true);
                    VectorOfPoint approx = new VectorOfPoint();
                    CvInvoke.ApproxPolyDP(contour, approx, approxAmount * perimeter, true);

                    CvInvoke.DrawContours(final, contours, i, new MCvScalar(0, 0, 255), 1);
                    Rectangle bounds = CvInvoke.BoundingRectangle(contour);
                    final.Draw(bounds, new Bgr(255, 0, 0));

                    double area = CvInvoke.ContourArea(contour);

                    if (!(bounds.X > bx && bounds.X < final.Width - bx)) {
                        continue;
                    }

                    if (!(bounds.Y > bx && bounds.Y < final.Height - bx)) {
                        continue;
                    }

                    if (area < minArea) {
                        continue;
                    }

                    if (approx.Size == 3) {
                        numberOfTriangles += 1;
                    } else if (approx.Size == 4) {
                        System.Drawing.Point[] test = approx.ToArray();

                        System.Drawing.Point a = test[0];
                        System.Drawing.Point b = test[1];
                        System.Drawing.Point c = test[2];

                        double width = Math.Sqrt((((double)(a.X - b.X)) * ((double)(a.X - b.X))) + (((double)(a.Y - b.Y)) * ((double)(a.Y - b.Y))));
                        double height = Math.Sqrt((((double)(c.X - b.X)) * ((double)(c.X - b.X))) + (((double)(c.Y - b.Y)) * ((double)(c.Y - b.Y))));

                        double ratio = width / height;
                        if (ratio > minRatio && ratio < maxRatio) {
                            numberOfSquares += 1;
                        } else {
                            numberOfLines += 1;
                        }
                    } else {
                        numberOfCircles += 1;
                    }
                }

                #endregion

                #endregion
            } else {
                #region AForge.NET
                // lock image
                BitmapData bitmapData = bitmap.LockBits(
                    new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                    ImageLockMode.ReadWrite, bitmap.PixelFormat);

                // step 1 - turn background to black
                ColorFiltering colorFilter = new ColorFiltering();

                colorFilter.Red = new IntRange(0, 64);
                colorFilter.Green = new IntRange(0, 64);
                colorFilter.Blue = new IntRange(0, 64);
                colorFilter.FillOutsideRange = false;

                colorFilter.ApplyInPlace(bitmapData);

                // step 2 - locating objects
                BlobCounter blobCounter = new BlobCounter();

                blobCounter.FilterBlobs = true;
                blobCounter.MinHeight = 5;
                blobCounter.MinWidth = 5;

                blobCounter.ProcessImage(bitmapData);
                Blob[] blobs = blobCounter.GetObjectsInformation();
                bitmap.UnlockBits(bitmapData);

                // step 3 - check objects' type and highlight
                SimpleShapeChecker shapeChecker = new SimpleShapeChecker();

                Graphics g = Graphics.FromImage(bitmap);

                for (int i = 0, n = blobs.Length; i < n; i++) {
                    List<IntPoint> edgePoints = blobCounter.GetBlobsEdgePoints(blobs[i]);

                    AForge.Point center;
                    float radius;

                    // is circle ?
                    if (shapeChecker.IsCircle(edgePoints, out center, out radius)) {
                        numberOfCircles++;
                    } else {
                        List<IntPoint> corners;

                        // is triangle or quadrilateral
                        if (shapeChecker.IsConvexPolygon(edgePoints, out corners)) {
                            // get sub-type
                            PolygonSubType subType = shapeChecker.CheckPolygonSubType(corners);
                            if (subType == PolygonSubType.Square) {
                                numberOfSquares++;
                            } else if (subType == PolygonSubType.EquilateralTriangle) {
                                numberOfTriangles++;
                            } else {
                                numberOfLines++;
                            }
                        }
                    }
                }
                g.Dispose();

                // put new image to clipboard
                Clipboard.SetDataObject(bitmap);
                // and to picture box
                picture.Image = bitmap;
                #endregion
            }

            triangleCount.Text = "" + numberOfTriangles;
            CircleCount.Text = "" + numberOfCircles;
            SquareCount.Text = "" + numberOfSquares;
            RectangleCount.Text = "" + numberOfLines;
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

                /*
                #region ACTUATOR CODE for next few lines
                int val0 = Convert.ToInt32(pilot.A_down) - Convert.ToInt32(pilot.B_down);
                int val1 = Convert.ToInt32(pilot.X_down) - Convert.ToInt32(pilot.Y_down);
                int val2 = Convert.ToInt32(pilot.Dpad_Down_down) - Convert.ToInt32(pilot.Dpad_Right_down);
                int val3 = Convert.ToInt32(pilot.Dpad_Left_down) - Convert.ToInt32(pilot.Dpad_Up_down);

                rov.ToolsActuator.Data.Speeds[0] = val0 * 100;
                rov.ToolsActuator.Data.Speeds[1] = val1 * 100;
                rov.ToolsActuator.Data.Speeds[2] = val2 * 100;
                rov.ToolsActuator.Data.Speeds[3] = val3 * 100;

                #endregion
                */

                #region ROV Motion
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
                rov.VerticalMotion = (int)(ConvertUtils.Map(pilot.RTrigger, 0, 255, 0, -100) + ConvertUtils.Map(pilot.LTrigger, 0, 255, 0, 100));
                #endregion

                #region Direction Lock
                if  (pilot.Dpad_Up_down) 
                {
                    forPrefButton_Click(null, null);
                }

                if (pilot.Dpad_Right_down)
                {
                    rightPrefButton_Click(null, null);
                }
                
                if (pilot.Dpad_Down_down)
                {
                    backPrefButton_Click(null, null);
                }

                if (pilot.Dpad_Left_down)
                {
                    leftPrefButton_Click(null, null);
                }

                #endregion

            } else
            {
                PilotConnectionLabel.Text = "Pilot Controller Not Connected";
                PilotConnectionLabel.ForeColor = Color.DarkRed;
                depthLockEngageLabel.ForeColor = Color.DarkRed;
                depthLockEngageLabel.Text = "Depth Lock Disengaged";
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
                if (copilot.Y_down)
                {
                    // switch servo one
                    rov.ToolsActuator.Data.Speeds[0] *= -1;
                }

                if (copilot.B_down)
                {
                    // switch servo two
                    rov.ToolsActuator.Data.Speeds[1] *= -1;
                }

                if (copilot.A_down)
                {
                    // switch servo three
                    rov.ToolsActuator.Data.Speeds[2] *= -1;
                }

                if (copilot.X_down)
                {
                    // switch servo four
                    rov.ToolsActuator.Data.Speeds[4] *= -1;
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
            pilotLTriggerIndicator.Visible = pilot.LTrigger > 128; // 0 - 255
            pilotRBumperIndicator.Visible = pilot.RBumper_down;
            pilotRTriggerIndicator.Visible = pilot.RTrigger > 128;
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
            copilotLTriggerIndicator.Visible = copilot.LTrigger > 128;
            copilotRBumperIndicator.Visible = copilot.RBumper_down;
            copilotRTriggerIndicator.Visible = copilot.RTrigger > 128;
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
        }
    }
}
