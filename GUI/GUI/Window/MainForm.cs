//Edward Li
//Angela Chen
//Darius Kianersi
//Anish Gorentala
//Aneesh Boreda
//Shreepa Parthaje
//Suhas Nandiraju
//Kevin Wu

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
namespace GUI
{
    public partial class MainForm : Form
    {
        private ROV rov;
        private SerialCommunication comms;
        public X.Gamepad pilot, copilot;
        private bool isLockClicked = false;
        private int depthvalue = 0;
        private bool RightBumperCheck = false;
        private int numberOfSquareShits = 0;
        private int numberOfCircleShits = 0;
        private int numberOfTriangleShits = 0;
        private int numberOfLineShits = 0;
        private bool isCapturing = false;
        private VideoCaptureDevice videoSource;
        private FilterInfoCollection videoDevices;

        public MainForm()
        {
            //controller
            pilot = X.Gamepad_1;
            pilot.Enable = true;
            pilot.Update(); //must call update right after setting enable to true in order for it to connect
            //copilot = X.Gamepad_2;
            //copilot.Enable = false; //change later on

            //setup window
            KeyPreview = true;
            InitializeComponent();

            //setup devices
            string portName = "COM6";
            try
            {
                portName = BetterSerialPort.GetPortNames()[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("No Serial ports available");
                //Environment.Exit(0);
            }
            BetterSerialPort port = new BetterSerialPort(portName, 115200);
            portLabel.Text = string.Format("{0}@{1}baud", port.PortName, port.BaudRate);
            comms = new SerialCommunication(port);
            comms.Stopped += comms_Stopped;
            comms.Started += comms_Started;
            comms.CommunicationException += Comms_CommunicationException;
            //comms.Connect();*/

            rov = new ROV(comms);

            //update displays when sensors polled
            rov.OrientationSensor.Updated += OrientationSensor_Updated;
            rov.DepthSensor.Updated += DepthSensor_Updated;

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
            catch (NullReferenceException potato)
            {
                //fill in later, catch made temporarily to ignore NullReferenceException
            }
            picture.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void Comms_CommunicationException(object sender, Exception e)
        {
            MessageBox.Show(e+"", "Communication Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void DepthSensor_Updated(object sender, DepthData e)
        {
            depthIndicator1.Depth = rov.DepthSensor.Data.DepthValue;
        }

        private void OrientationSensor_Updated(object sender, OrientationData e)
        {
            /*attitudeIndicator1.PitchAngle = rov.OrientationSensor.Data.Pitch;
            attitudeIndicator1.RollAngle = rov.OrientationSensor.Data.Roll;
            attitudeIndicator1.YawAngle = rov.OrientationSensor.Data.Yaw;*/
            headingIndicator1.Heading = rov.OrientationSensor.Data.Yaw;
        }
        private void ProcessImage(Bitmap bitmap)
        {
            // reset counters
            numberOfCircleShits = 0;
            numberOfLineShits = 0;
            numberOfSquareShits = 0;
            numberOfTriangleShits = 0;

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

            for (int i = 0, n = blobs.Length; i < n; i++)
            {
                List<IntPoint> edgePoints = blobCounter.GetBlobsEdgePoints(blobs[i]);

                AForge.Point center;
                float radius;

                // is circle ?
                if (shapeChecker.IsCircle(edgePoints, out center, out radius))
                {
                    numberOfCircleShits++;
                }
                else
                {
                    List<IntPoint> corners;

                    // is triangle or quadrilateral
                    if (shapeChecker.IsConvexPolygon(edgePoints, out corners))
                    {
                        // get sub-type
                        PolygonSubType subType = shapeChecker.CheckPolygonSubType(corners);
                        Pen pen;
                        if (subType == PolygonSubType.Square)
                        {
                            numberOfSquareShits++;
                        }
                        else if (subType == PolygonSubType.EquilateralTriangle)
                        {
                            numberOfTriangleShits++;
                        }
                        else
                        {
                            numberOfLineShits++;
                        }
                    }
                }
            }
            g.Dispose();
            // put new image to clipboard
            Clipboard.SetDataObject(bitmap);
            // and to picture box
            picture.Image = bitmap;
            triangleCount.Text = "" + numberOfTriangleShits;
            CircleCount.Text = "" + numberOfCircleShits;
            SquareCount.Text = "" + numberOfSquareShits;
            RectangleCount.Text = "" + + numberOfLineShits;
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
            //queueLabel.Text = "Queue length: " + comms.Queue.Count;
            armButton.Text = rov.StatusSensor.Data.Status == ROVStatus.ARMED ? "Armed" : "Disarmed";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            comms.LinkActive = !comms.LinkActive;
        }

        private void button2_Click(object sender, EventArgs e)
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
                ConnectionB.BackColor = Color.Green;
                ConnectionLabel.Text = "Controller Connected : True";
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
                //Code for displaying motor values
                topLeft.Text = (rov.ForeAftMotion + rov.StrafeMotion - rov.TurnMotion) >= 0 ? "" + Math.Min(rov.ForeAftMotion + rov.StrafeMotion - rov.TurnMotion, 100) : "" + Math.Max(rov.ForeAftMotion + rov.StrafeMotion - rov.TurnMotion, -100);
                midLeft.Text = "" + rov.VerticalMotion;
                botLeft.Text = (rov.ForeAftMotion - rov.StrafeMotion - rov.TurnMotion) >= 0 ? "" + Math.Min(rov.ForeAftMotion - rov.StrafeMotion - rov.TurnMotion, 100) : "" + Math.Max(rov.ForeAftMotion - rov.StrafeMotion - rov.TurnMotion, -100);
                topRight.Text = (rov.ForeAftMotion - rov.StrafeMotion + rov.TurnMotion) >= 0 ? "" + Math.Min(rov.ForeAftMotion - rov.StrafeMotion + rov.TurnMotion, 100) : "" + Math.Max(rov.ForeAftMotion - rov.StrafeMotion + rov.TurnMotion, -100);
                midRight.Text = "" + rov.VerticalMotion;
                botRight.Text = (rov.ForeAftMotion + rov.StrafeMotion + rov.TurnMotion) >= 0 ? "" + Math.Min(rov.ForeAftMotion + rov.StrafeMotion + rov.TurnMotion, 100) : "" + Math.Max(rov.ForeAftMotion + rov.StrafeMotion + rov.TurnMotion, -100);

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
                    }
                    else
                    {

                        rov.VerticalMotion -= 1;  //brings robot down
                    }
                }
                else
                {
                    depthLockButton.BackColor = Color.DarkRed;

                }
                //ACTUATOR CODE for next few lines
                int val0 = Convert.ToInt32(pilot.A_down) - Convert.ToInt32(pilot.B_down);
                int val1 = Convert.ToInt32(pilot.X_down) - Convert.ToInt32(pilot.Y_down);
                int val2 = Convert.ToInt32(pilot.Dpad_Down_down) - Convert.ToInt32(pilot.Dpad_Right_down);
                int val3 = Convert.ToInt32(pilot.Dpad_Left_down) - Convert.ToInt32(pilot.Dpad_Up_down);

                rov.ToolsActuator.Data.Speeds[0] = val0 * 100;
                rov.ToolsActuator.Data.Speeds[1] = val1 * 100;
                rov.ToolsActuator.Data.Speeds[2] = val2 * 100;
                rov.ToolsActuator.Data.Speeds[3] = val3 * 100;

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
                rov.VerticalMotion = (int)(ConvertUtils.Map(pilot.RTrigger, 0, 255, 0, -100) + ConvertUtils.Map(pilot.LTrigger, 0, 255, 0, 100));
            }
            else
            {
                ConnectionB.BackColor = Color.DarkRed;
                ConnectionLabel.Text = "Controller Connected : False";
                depthLockButton.BackColor = Color.DarkRed;
                rov.VerticalMotion = 0.0;
                rov.ForeAftMotion = 0.0;
                rov.StrafeMotion = 0.0;
                rov.TurnMotion = 0.0;
            }
            joyStickChart1.Series["Series1"].Points[0].XValue = (int)(ConvertUtils.Map(LStickZeroX, -32768, 32767, -100, 100));
            joyStickChart1.Series["Series1"].Points[0].YValues[0] = (double)(ConvertUtils.Map(LStickZeroY, -32768, 32767, -100, 100));
            joyStickChart2.Series["Series1"].Points[0].XValue = (int)(ConvertUtils.Map(RStickZeroX, -32768, 32767, -100, 100));
            joyStickChart2.Series["Series1"].Points[0].YValues[0] = (double)(ConvertUtils.Map(RStickZeroY, -32768, 32767, -100, 100));
        }
    

        private void button18_Click(object sender, EventArgs e)
        {
            try
            {
                double L = Double.Parse(LengthOfBarrel.Text);
                double R1 = Double.Parse(InnerRadius1.Text);
                double R2 = Double.Parse(InnerRadius2.Text);
                double R3 = Double.Parse(InnerRadius3.Text);
                double hole = Math.PI * (Math.Pow(R2, 2)) * L;
                double cone = Math.PI * L / 3 * (Math.Pow(R1, 2) + Math.Pow(R3, 2) + R1 * R3);
                double result = cone - hole;
                answerBox.Text = Math.Round(result, 4).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception:" + '\n' + ex + ""  + '\n' + '\n' + "Please input a number.", "Numerical Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void benthicButton_Click(object sender, EventArgs e)
        {
            ProcessImage(video);
        }

        private void forTestingPurposes_Click(object sender, EventArgs e)
        {
            rov.ForeAftMotion = 100;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < 6; i++)
            {
                //if(Int32.TryParse(textBox1.Text , out int n))
                // rov.PropulsionActuator.Data.Speeds[i] = n;
            }
        }

        private void capButton_Click(object sender, EventArgs e)
        {
            if(videoSource == null)
            {
                DialogResult res = MessageBox.Show("There isn't a video source connected.", "Connect an OEM device", MessageBoxButtons.OK, MessageBoxIcon.Information);
                benthicButton.Enabled = false;
            }
            else
            {
                if (isCapturing)
                {
                    isCapturing = false;
                    capButton.Text = "Enable Video";
                    videoSource.SignalToStop();
                    benthicButton.Enabled = false;
                }
                else
                {
                    isCapturing = true;
                    capButton.Text = "Disable Video";
                    videoSource.Start();
                    benthicButton.Enabled = true;
                }
            }
            
        }

        private void selectVideoDevice_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private Bitmap video;

        private void joyStickChart1_Click(object sender, EventArgs e)
        {

        }

        private void video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            video = (Bitmap)eventArgs.Frame.Clone();
            picture.Image = video;
        }
    }
}
