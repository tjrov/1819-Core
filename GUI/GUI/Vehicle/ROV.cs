﻿using System;
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

        private SerialCommunication comms;
        private Timer t500, t50, t10;

        private int parityFL, parityFR, parityBL, parityBR;
        public int directionPref;
        private readonly PidController depthPID, headingPID, rollPID;

        public double ToolMotion;

        public double VerticalMotion, ForeAftMotion, StrafeMotion, TurnMotion; //ccw positive
        public double DesiredHeading
        {
            get => DesiredHeading;
            set
            {
                if (value > 360)
                {
                    DesiredHeading = value - 360;
                }
                else if (value < 0)
                {
                    DesiredHeading = 360 - value;
                }
                else
                {
                    DesiredHeading = value;
                }
            }
        }
        public bool EnableHeadingLock, EnableRollLock, EnableDepthLock;

        //change as needed
        private readonly Dictionary<string, int> key = new Dictionary<string, int>()
        {
            ["ForwardPort"] = 0,
            ["ForwardStarboard"] = 3,
            ["AftPort"] = 2,
            ["AftStarboard"] = 5,
            ["VerticalPort"] = 1,
            ["VerticalStarboard"] = 4
        };

       /* public enum ThrusterLocations
        {
            ForwardPort=5,
            ForwardStarboard=2,
            AftPort=3,
            AftStarboard=0,
            VerticalPort=4,
            VerticalStarboard=1
        };*/

        private readonly double headingAdj;
        private readonly double depthAdj;
        private readonly double rollAdj;

        public ROV(SerialCommunication comms)
        {
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

            //timer setup
            t500 = new Timer() { Enabled = false, Interval = 500 };
            t50 = new Timer() { Enabled = false, Interval = 50 };
            t10 = new Timer() { Enabled = false, Interval = 10 };
            t500.Tick += T500_Tick;
            t50.Tick += T50_Tick;
            t10.Tick += T10_Tick;

            //get the ROV firmware version when connection starts
            comms.Queue.Enqueue(VersionSensor);
        }

        private void Comms_Stopped(object sender, EventArgs e)
        {
            t500.Enabled = false; t50.Enabled = false; t10.Enabled = false;
        }

        private void Comms_Started(object sender, EventArgs e)
        {
            t500.Enabled = true; t50.Enabled = true; t10.Enabled = true;
        }

        //update loops
        //fast loop reserved for thruster control only
        private void T10_Tick(object sender, EventArgs e)
        {
            double[] speeds = PropulsionActuator.Data.Speeds; //this might make an array copy instead of a reference idk

            //horizontal vector thrusters
            //all thruster speeds are positive for forward/upward thrust
            //ForeAftMotion is positive forward, StrafeMotion is positive rightward, and TurnMotion is positive CCW (think right hand rule)
            double localTurnMotion = TurnMotion;
            if (EnableHeadingLock)
            {
                localTurnMotion += headingAdj;
            }
            speeds[key["ForwardPort"]] = ForeAftMotion + StrafeMotion - TurnMotion >= 0 ? Math.Min(ForeAftMotion + StrafeMotion - TurnMotion, 100) : Math.Max(ForeAftMotion + StrafeMotion - TurnMotion, -100);
            speeds[key["ForwardStarboard"]] = ForeAftMotion - StrafeMotion + TurnMotion >= 0 ? Math.Min(ForeAftMotion - StrafeMotion + TurnMotion, 100) : Math.Max(ForeAftMotion - StrafeMotion + TurnMotion, -100);
            speeds[key["AftPort"]] = ForeAftMotion - StrafeMotion - TurnMotion >= 0 ? Math.Min(ForeAftMotion - StrafeMotion - TurnMotion, 100) : Math.Max(ForeAftMotion - StrafeMotion - TurnMotion, -100);
            speeds[key["AftStarboard"]] = ForeAftMotion + StrafeMotion + TurnMotion >= 0 ? Math.Min(ForeAftMotion + StrafeMotion + TurnMotion, 100) : Math.Max(ForeAftMotion + StrafeMotion + TurnMotion, -100);

            //vertical thrusters
            //VerticalMotion is positive upward
            speeds[key["VerticalPort"]] = VerticalMotion;
            speeds[key["VerticalStarboard"]] = -VerticalMotion;
            if (EnableDepthLock)
            {
                speeds[key["VerticalPort"]] += depthAdj;
                speeds[key["VerticalStarboard"]] += depthAdj;
            }
            if (EnableRollLock)
            {
                speeds[key["VerticalPort"]] += rollAdj;
                speeds[key["VerticalStarboard"]] += rollAdj;
            }
            //send the thruster speeds to the ROV
            comms.Queue.Enqueue(PropulsionActuator);
        }

        //medium loop for sensors and manipulators/tools
        private void T50_Tick(object sender, EventArgs e)
        {
            //comms.Queue.Enqueue(DepthSensor);
            //comms.Queue.Enqueue(OrientationSensor);
            comms.Queue.Enqueue(ToolsActuator);
        }

        //slow loop for status and error reports, arming/disarming, etc.
        private void T500_Tick(object sender, EventArgs e)
        {
            //comms.Queue.Enqueue(StatusSensor);
            comms.Queue.Enqueue(StatusActuator);
        }
        public void setDirection(int direction)
        {
            directionPref = direction;
            switch (direction)
            {
                case 0:
                    parityFL = parityFR = parityBL = parityBR = 1;
                    key["ForwardPort"] = 0;
                    key["ForwardStarboard"] = 1;
                    key["AftPort"] = 2;
                    key["AftStarboard"] = 3;
                    break;
                case 1:
                    parityFR = parityBL = 1;
                    parityFL = parityBR = -1;
                    key["ForwardPort"] = 1;
                    key["ForwardStarboard"] = 3;
                    key["AftPort"] = 0;
                    key["AftStarboard"] = 2;
                    break;
                case 2:
                    parityFL = parityFR = parityBL = parityBR = -1;
                    key["ForwardPort"] = 3;
                    key["ForwardStarboard"] = 2;
                    key["AftPort"] = 1;
                    key["AftStarboard"] = 0;
                    break;
                case 3:
                    parityFR = parityBL = -1;
                    parityFL = parityBR = 1;
                    key["ForwardPort"] = 2;
                    key["ForwardStarboard"] = 0;
                    key["AftPort"] = 3;
                    key["AftStarboard"] = 1;
                    break;
            }
        }
    }
}
