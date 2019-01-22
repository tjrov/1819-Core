using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private PidController depthPID, headingPID, rollPID;

        public float VerticalMotion, ForeAftMotion, StrafeMotion, TurnMotion; //ccw positive
        public float DesiredHeading;
        public bool EnableHeadingLock, EnableRollLock, EnableDepthLock;

        //change as needed
        private Dictionary<string, int> key = new Dictionary<string, int>()
        {
            ["Forward Port"] = 0,
            ["Forward Starboard"] = 1,
            ["Aft Port"] = 2,
            ["Aft Starboard"] = 3,
            ["Vertical Port"] = 4,
            ["Vertical Starboard"] = 5
        };

        private double headingAdj;
        private double depthAdj;
        private double rollAdj;

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
            t500 = new Timer() { Enabled = true, Interval = 500 };
            t50 = new Timer() { Enabled = true, Interval = 50 };
            t10 = new Timer() { Enabled = true, Interval = 10 };
            t500.Tick += T500_Tick;
            t50.Tick += T50_Tick;
            t10.Tick += T10_Tick;

            //get the firmware version
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
            speeds[key["Forward Port"]] = ForeAftMotion + StrafeMotion - TurnMotion;
            speeds[key["Forward Starboard"]] = ForeAftMotion - StrafeMotion + TurnMotion;
            speeds[key["Aft Port"]] = ForeAftMotion - StrafeMotion - TurnMotion;
            speeds[key["Aft Starboard"]] = ForeAftMotion + StrafeMotion + TurnMotion;

            //vertical thrusters
            //VerticalMotion is positive upward
            speeds[key["Vertical Port"]] = VerticalMotion;
            speeds[key["Vertical Starboard"]] = VerticalMotion;
            if(EnableDepthLock)
            {
                speeds[key["Vertical Port"]] += depthAdj;
                speeds[key["Vertical Starboard"]] += depthAdj;
            }
            if (EnableRollLock)
            {
                speeds[key["Vertical Port"]] += rollAdj;
                speeds[key["Vertical Starboard"]] += rollAdj;
            }

            //send the thruster speeds
            comms.Queue.Enqueue(PropulsionActuator);
        }

        //medium loop for sensors and manipulators/tools
        private void T50_Tick(object sender, EventArgs e)
        {
            comms.Queue.Enqueue(DepthSensor);
            comms.Queue.Enqueue(OrientationSensor);
            comms.Queue.Enqueue(ToolsActuator);
        }

        //slow loop for status and error reports, arming/disarming, etc.
        private void T500_Tick(object sender, EventArgs e)
        {
            comms.Queue.Enqueue(StatusSensor);
            comms.Queue.Enqueue(StatusActuator);
        }
    }
}
