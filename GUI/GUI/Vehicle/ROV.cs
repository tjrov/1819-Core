using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace GUI
{
    public class ROV
    {
        public DepthSensor DepthSensor;
        public OrientationSensor OrientationSensor;
        public StatusSensor StatusSensor;
        public PropulsionSensor PropulsionSensor;
        public VersionSensor VersionSensor;

        public StatusActuator StatusActuator;
        public PropulsionActuator PropulsionActuator;
        public ToolsActuator ToolsActuator;

        public ServoActuator ServoActuator;
        public MiniROVActuator MiniROVActuator;

        private SerialCommunication comms;
        private Timer t500, t50, t10;

        private int parityFL, parityFR, parityBL, parityBR;
        public int directionPref;
        private readonly PidController depthPID, headingPID, rollPID;

        public double ToolMotion;

        public double VerticalMotion, ForeAftMotion, StrafeMotion, TurnMotion; //ccw positive\

        private double desiredHeading;

        public double DesiredHeading
        {
            get { return desiredHeading; }
            set
            {
                if (value > 360)
                {
                    desiredHeading = value - 360;
                }
                else if (value < 0)
                {
                    desiredHeading = 360 - value;
                }
                else
                {
                    desiredHeading = value;
                }
            }
        }

        public bool EnableHeadingLock, EnableRollLock, EnableDepthLock;

        private readonly Dictionary<string, int> thruster = new Dictionary<string, int>()
        {
            ["top-left"] = 0,
            ["top-right"] = 3,
            ["bottom-left"] = 2,
            ["bottom-right"] = 5,
            ["vertical-1"] = 1,
            ["vertical-2"] = 4
        };

        //change as needed
        private readonly Dictionary<string, int> key = new Dictionary<string, int>();

        private readonly double headingAdj;
        private readonly double depthAdj;
        private readonly double rollAdj;

        public ROV(SerialCommunication comms)
        {
            #region Set thrusters to pins

            key["ForwardPort"] = thruster["top-left"];
            key["ForwardStarboard"] = thruster["top-right"];
            key["AftPort"] = thruster["bottom-left"];
            key["AftStarboard"] = thruster["bottom-right"];
            key["VerticalPort"] = thruster["vertical-1"];
            key["VerticalStarboard"] = thruster["vertical-2"];

            #endregion

            this.comms = comms;
            comms.Started += Comms_Started;
            comms.Stopped += Comms_Stopped;

            //device setup
            DepthSensor = new DepthSensor();
            OrientationSensor = new OrientationSensor();
            StatusSensor = new StatusSensor();
            PropulsionSensor = new PropulsionSensor();
            VersionSensor = new VersionSensor();

            StatusActuator = new StatusActuator();
            PropulsionActuator = new PropulsionActuator();
            ToolsActuator = new ToolsActuator();
            ServoActuator = new ServoActuator();
            MiniROVActuator = new MiniROVActuator();

            //timer setup
            t500 = new Timer() {Enabled = true, Interval = 500};
            t50 = new Timer() {Enabled = true, Interval = 50};
            t10 = new Timer() {Enabled = true, Interval = 10};
            t500.Tick += T500_Tick;
            t50.Tick += T50_Tick;
            t10.Tick += T10_Tick;

            VerticalMotion = 0.0;
            ForeAftMotion = 0.0;
            StrafeMotion = 0.0;
            TurnMotion = 0.0;

            //get the ROV firmware version when connection starts
            comms.Queue.Enqueue(VersionSensor);
        }

        private void Comms_Stopped(object sender, EventArgs e)
        {
            t500.Enabled = false;
            t50.Enabled = false;
            t10.Enabled = false;
        }

        private void Comms_Started(object sender, EventArgs e)
        {
            t500.Enabled = true;
            t50.Enabled = true;
            t10.Enabled = true;
        }

        //update loops
        //fast loop reserved for thruster control only
        private void T10_Tick(object sender, EventArgs e)
        {
            //horizontal vector thrusters
            //all thruster speeds are positive for forward/upward thrust
            //ForeAftMotion is positive forward, StrafeMotion is positive rightward, and TurnMotion is positive CCW (think right hand rule)
            double localTurnMotion = TurnMotion;
            if (EnableHeadingLock)
            {
                localTurnMotion += headingAdj;
            }

            PropulsionActuator.Data.Speeds[key["ForwardPort"]] = ForeAftMotion + StrafeMotion - TurnMotion >= 0
                ? Math.Min(ForeAftMotion + StrafeMotion - TurnMotion, 100)
                : Math.Max(ForeAftMotion + StrafeMotion - TurnMotion, -100);
            PropulsionActuator.Data.Speeds[key["ForwardStarboard"]] = ForeAftMotion - StrafeMotion + TurnMotion >= 0
                ? Math.Min(ForeAftMotion - StrafeMotion + TurnMotion, 100)
                : Math.Max(ForeAftMotion - StrafeMotion + TurnMotion, -100);
            PropulsionActuator.Data.Speeds[key["AftPort"]] = ForeAftMotion - StrafeMotion - TurnMotion >= 0
                ? Math.Min(ForeAftMotion - StrafeMotion - TurnMotion, 100)
                : Math.Max(ForeAftMotion - StrafeMotion - TurnMotion, -100);
            PropulsionActuator.Data.Speeds[key["AftStarboard"]] = ForeAftMotion + StrafeMotion + TurnMotion >= 0
                ? Math.Min(ForeAftMotion + StrafeMotion + TurnMotion, 100)
                : Math.Max(ForeAftMotion + StrafeMotion + TurnMotion, -100);

            //vertical thrusters
            //VerticalMotion is positive upward
            PropulsionActuator.Data.Speeds[key["VerticalPort"]] = VerticalMotion;
            PropulsionActuator.Data.Speeds[key["VerticalStarboard"]] = VerticalMotion;
            // Vertical Starboard used to equal -VerticalMotion which doesn't really make sense

            if (EnableDepthLock)
            {
                PropulsionActuator.Data.Speeds[key["VerticalPort"]] += depthAdj;
                PropulsionActuator.Data.Speeds[key["VerticalStarboard"]] += depthAdj;
            }

            if (EnableRollLock)
            {
                PropulsionActuator.Data.Speeds[key["VerticalPort"]] += rollAdj;
                PropulsionActuator.Data.Speeds[key["VerticalStarboard"]] += rollAdj;
            }


            //send the thruster speeds to the ROV
            comms.Queue.Enqueue(PropulsionActuator);
        }

        //public void LaunchMiniROV()
        //{
        //    comms.Queue.Enqueue(MiniROVActuator);
        //}

        //medium loop for sensors and manipulators/tools
        private void T50_Tick(object sender, EventArgs e)
        {
            comms.Queue.Enqueue(DepthSensor);
            comms.Queue.Enqueue(OrientationSensor);
            comms.Queue.Enqueue(ToolsActuator);
            comms.Queue.Enqueue(ServoActuator);
        }

        //slow loop for status and error reports, arming/disarming, etc.
        private void T500_Tick(object sender, EventArgs e)
        {
            comms.Queue.Enqueue(StatusSensor);
            comms.Queue.Enqueue(StatusActuator);
        }

        public void setDirection(int direction)
        {
            // parity fields haven't been changed, don't know if they have to be changed
            // it may break? it may not break?
            directionPref = direction;
            switch (direction)
            {
                case 0:
                    parityFL = parityFR = parityBL = parityBR = 1;
                    key["ForwardPort"] = thruster["top-left"];
                    key["ForwardStarboard"] = thruster["top-right"];
                    key["AftPort"] = thruster["bottom-left"];
                    key["AftStarboard"] = thruster["bottom-right"];
                    break;
                case 1:
                    parityFR = parityBL = 1;
                    parityFL = parityBR = -1;
                    key["ForwardPort"] = thruster["top-right"];
                    key["ForwardStarboard"] = thruster["bottom-right"];
                    key["AftPort"] = thruster["top-left"];
                    key["AftStarboard"] = thruster["bottom-left"];
                    break;
                case 2:
                    parityFL = parityFR = parityBL = parityBR = -1;
                    key["ForwardPort"] = thruster["bottom-right"];
                    key["ForwardStarboard"] = thruster["bottom-left"];
                    key["AftPort"] = thruster["top-right"];
                    key["AftStarboard"] = thruster["top-left"];
                    break;
                case 3:
                    parityFR = parityBL = -1;
                    parityFL = parityBR = 1;
                    key["ForwardPort"] = thruster["bottom-left"];
                    key["ForwardStarboard"] = thruster["top-left"];
                    key["AftPort"] = thruster["bottom-right"];
                    key["AftStarboard"] = thruster["top-right"];
                    break;
            }
        }
    }
}