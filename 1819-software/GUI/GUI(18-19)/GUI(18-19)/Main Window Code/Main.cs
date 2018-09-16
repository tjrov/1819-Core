using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GUI.Communication;
using GUI.Devices;
using SlimDX.DirectInput;
using System.Runtime.InteropServices;
using System.IO.Ports;

namespace GUI
{
    public partial class Main : Form
    {
        //Communication Globals 
        private SerialCommunication comms;

        //Sensor Globals
        private OrientationSensor imuSensor;
        private StatusSensor statusSensor;
        private PropulsionSensor escSensors;
        private DepthSensor depthSensor;
        private DiagnosticsSensor versionSensor;

        //Actuator Globals
        private PropulsionActuator escActuators;
        private StatusActuator statusActuator;
        private ToolsActuator toolActuators;

        //Controller Globals
        DirectInput Input = new DirectInput();
        SlimDX.DirectInput.Joystick stick;
        Joystick[] Sticks;
        bool MouseClicked = false;
        bool[] buttons;
        int[] pointOfView;
        int xValue = 0;
        int yValue = 0;
        int zValue = 0;
        int xRotValue = 0;
        int yRotValue = 0;
        int zRotValue = 0;
        double rightTrigger = 0;
        double leftTrigger = 0;

        public Main()
        {
            //Create Window
            InitializeComponent();
            //Fullscreen = true; //you can always do alt-enter to go fullscreen

            //Custom Window Code 
            //(We cannot alter Designer-generated method InitializeComponent())
            portInfoButton.Text = string.Format("{0}@{1}baud", Properties.Settings.Default.PortName,
                Properties.Settings.Default.BaudRate);

            //Populate serial port names in toolbar options
            portNameComboBox.Items.AddRange(SerialPort.GetPortNames());

            //Comms Initialization 
            comms = new SerialCommunication(
                new BetterSerialPort(Properties.Settings.Default.PortName,
                Properties.Settings.Default.BaudRate));
            comms.Started += OnCommsStarted;
            comms.Stopped += OnCommsStopped;
            comms.CommunicationException += OnCommsException;
            comms.TenElapsed += OnTenElapsed;
            comms.HundredElapsed += OnHundredElapsed;
            comms.ThousandElapsed += OnThousandElapsed;

            //Data Structure Declarations
            List<ESCData> escDataList = new List<ESCData>();
            List<ToolData> toolDataList = new List<ToolData>();
            StatusData status = new StatusData();

            //Sensor Declarations
            imuSensor = new OrientationSensor(new OrientationData());
            depthSensor = new DepthSensor(new DepthData());
            statusSensor = new StatusSensor(status);
            escSensors = new PropulsionSensor(escDataList);
            versionSensor = new DiagnosticsSensor(new VersionData());

            //Actuator Declarations
            escActuators = new PropulsionActuator(escDataList);
            statusActuator = new StatusActuator(status);
            toolActuators = new ToolsActuator(toolDataList);

            //Controller Method Calls
            Sticks = GetSticks();
        }

        /*
         * Method calls on exception in communication thread
         */
        private void OnCommsException(object sender, Exception e)
        {
            this.BeginInvoke(new Action(() =>
            {
                MessageBox.Show(e.Message + "(see log.txt for details)",
                    "Exception Unhandled in Communication Thread", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }));
        }

        /*
         * Method calls on application load
         */
        private void Main_Load(object sender, EventArgs e)
        {
            //Joystick[] joystick = GetSticks();
        }

        /*
         * Gets Controllers from SlimDx
         */
        public Joystick[] GetSticks()
        {
            List<SlimDX.DirectInput.Joystick> sticks = new List<SlimDX.DirectInput.Joystick>();
            foreach (DeviceInstance device in Input.GetDevices(DeviceClass.GameController, DeviceEnumerationFlags.AttachedOnly))
            {
                //try
                //{
                    stick = new SlimDX.DirectInput.Joystick(Input, device.InstanceGuid);
                    stick.Acquire();
                    foreach (DeviceObjectInstance deviceObject in stick.GetObjects())
                    {
                        if ((deviceObject.ObjectType & ObjectDeviceType.Axis) != 0)
                        {
                            stick.GetObjectPropertiesById((int)deviceObject.ObjectType).SetRange(-100, 100);
                        }
                    }
                    sticks.Add(stick);
                //}
                //catch (DirectInputException)
                //{

                //}
            }
            return sticks.ToArray();
        }

        /*
         * Handles Controller Inputs
         */
        void stickHandle(Joystick stick, int id)
        {
            JoystickState state = new JoystickState();
            state = stick.GetCurrentState();

            xValue = state.X;
            yValue = state.Y;
            zValue = state.Z;

            xRotValue = state.RotationX;
            yRotValue = state.RotationY;
            zRotValue = state.RotationZ;

            bool[] buttons = state.GetButtons();
            int[] pointOfView = state.GetPointOfViewControllers();
            if (id == 0) //User One Controller input definitions go here
            {

            }
            if (id == 1) //User Two Controller input definitions go here
            {

            }
        }

        /*
         * Updates the controller data when the timer ticks 
         */
        private void ControllerTimer_Tick(object sender, EventArgs e)
        {
            for (int a = 0; a < Sticks.Length; a++)
            {
                stickHandle(Sticks[a], a);
                rightTrigger = (yRotValue + 100) / 2;
                leftTrigger = (xRotValue + 100) / 2;
            }

            //-S-e-b-a-s-t-i-a-n -is- a- -C-r-i-a-d-o-
            //C-ar-d-d-I-o i-s-s i-NN t-H-Eee Se-bast-iiaan
            /*
                ----\
               | -_- |
                -----
               /|\ <----CARDIO of the Sebastian resides here
                |
               / \
               |  \

            SEA BASS tan(CRAYON)
            */

            /*
            "Iakimovitch" ====> "Iaki" (nickname proposal)
            */
        }

        /*
         * runs 1Hz
         */
        private void OnThousandElapsed(object sender, EventArgs e)
        {
            comms.QueueDeviceUpdate(statusSensor);
            comms.QueueDeviceUpdate(escSensors);
        }

        /*
         *runs 20Hz
         */
        private void OnHundredElapsed(object sender, EventArgs e)
        {
            comms.QueueDeviceUpdate(imuSensor);
            comms.QueueDeviceUpdate(depthSensor);
        }

        /*
         * runs 100Hz
         */
        private void OnTenElapsed(object sender, EventArgs e)
        {
            comms.QueueDeviceUpdate(escActuators);
        }

        /*
         * when communication broken off (both intentionally and because of oopsie whoopsies)
         */
        private void OnCommsStopped(object sender, EventArgs e)
        {
            this.BeginInvoke(new Action(() =>
            {
                comButton.Text = "Disconnected";
                comButton.BackColor = Color.OrangeRed;
            }));
        }

        /*
         * when comms started (this should only happen intentionally, unless there was an oopsie whoopsie)
         */
        private void OnCommsStarted(object sender, EventArgs e)
        {
            comButton.Text = "Connected";
            comButton.BackColor = Color.Green;
            comms.QueueDeviceUpdate(versionSensor); //ask for the firmware version when comms first start up
        }

        /*
         * Sets the Program to be a fullscreen window
         */
        private bool fullscreen;
        public bool Fullscreen
        {
            get
            {
                return fullscreen;
            }
            set
            {
                if (value)
                {
                    this.WindowState = FormWindowState.Maximized;
                    this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                }
                else
                {
                    this.WindowState = FormWindowState.Maximized;
                    this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
                }
                fullscreen = value;
            }
        }

        /*
         * Enables and disables communications on button click
         */
        private void ComButton_Click(object sender, EventArgs e)
        {
            //toggle state of communications
            comms.LinkActive = !comms.LinkActive;
        }

        private void portInfoButton_Click(object sender, EventArgs e)
        {
            //stop communication
            comms.ShutDown();
            //show the settings
            SettingsForm sf = new SettingsForm();
            sf.ShowDialog();
            //restart the app
            Application.Restart();
        }

        /*
         * Handle Keyboard Input
         */
        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            //alt-enter toggles full-screen mode
            if (e.Alt && e.KeyCode == Keys.Enter)
            {
                Fullscreen = !Fullscreen;
            }
            //control+another key
            else if (e.Control)
            {
                //these commands only apply while connected
                if (comms.LinkActive)
                {
                    switch (e.KeyCode)
                    {
                        //ctrl-a to toggle armed/disarmed
                        case (Keys.A):
                            statusActuator.Data.DesiredStatus =
                                (statusActuator.Data.DesiredStatus == ROVStatus.ARMED) ?
                                ROVStatus.DISARMED : ROVStatus.ARMED;
                            comms.QueueDeviceUpdate(statusActuator); //send command
                            break;
                        //ctrl-R to reboot ROV computer
                        case (Keys.R):
                            statusActuator.Data.DesiredStatus = ROVStatus.REBOOT;
                            comms.QueueDeviceUpdate(statusActuator); //send command
                            break;
                    }
                }
                //these commands apply whether or not ROV is connected
                switch (e.KeyCode)
                {
                    case (Keys.C):
                        comms.LinkActive = !comms.LinkActive;
                        break;
                }
            }
        }
    }
}