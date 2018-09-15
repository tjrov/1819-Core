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
        private PropulsionActuator escControls;
        private StatusActuator statusControls;
        private ToolsActuator toolControls;

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
            GoFullscreen(true);

            //Comms Initialization 
            comms = new SerialCommunication(new BetterSerialPort("COM3", 500000));
            comms.Started += OnCommsStarted;
            comms.Stopped += OnCommsStopped;
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
            escControls = new PropulsionActuator(escDataList);
            statusControls = new StatusActuator(status);
            toolControls = new ToolsActuator(toolDataList);

            //Controller Method Calls
            GetSticks();
            Sticks = GetSticks();

        }

        /*
         * Method calls on application load
         */
        private void Main_Load(object sender, EventArgs e)
        {
            Joystick[] joystick = GetSticks();
        }

        /*
         * Gets Controllers from SlimDx
         */
        public Joystick[] GetSticks()
        {
            List<SlimDX.DirectInput.Joystick> sticks = new List<SlimDX.DirectInput.Joystick>();
            foreach (DeviceInstance device in Input.GetDevices(DeviceClass.GameController, DeviceEnumerationFlags.AttachedOnly))
            {
                try
                {
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
                }
                catch (DirectInputException)
                {

                }
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
            /**/
        } 

        /*
         * runs 1Hz
         */
        private void OnThousandElapsed(object sender, EventArgs e)
        {
            comms.QueueDeviceUpdate(statusControls);
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
            comms.QueueDeviceUpdate(escControls);
        }

        /*
         * when communication broken off (both intentionally and because of oopsie whoopsies)
         */
        private void OnCommsStopped(object sender, EventArgs e)
        {
            ComButton.Text = "Disconnected";
            ComButton.BackColor = Color.OrangeRed;
        }

        /*
         * when comms started (this should only happen intentionally, unless there was an oopsie whoopsie)
         */ 
        private void OnCommsStarted(object sender, EventArgs e)
        {
            ComButton.Text = "Connected";
            ComButton.BackColor = Color.Green;
            comms.QueueDeviceUpdate(versionSensor); //ask for the firmware version
        }

        /*
         * Sets the Program to be a fullscreen window
         */
        private void GoFullscreen(bool fullscreen)
        {
            if (fullscreen)
            {
                this.WindowState = FormWindowState.Maximized;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
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
    }
}