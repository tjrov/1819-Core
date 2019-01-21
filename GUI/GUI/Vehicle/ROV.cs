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
        private void T10_Tick(object sender, EventArgs e)
        {
            comms.Queue.Enqueue(PropulsionActuator);
        }

        private void T50_Tick(object sender, EventArgs e)
        {
            comms.Queue.Enqueue(DepthSensor);
            comms.Queue.Enqueue(OrientationSensor);
            comms.Queue.Enqueue(ToolsActuator);
        }

        private void T500_Tick(object sender, EventArgs e)
        {
            comms.Queue.Enqueue(StatusSensor);
            comms.Queue.Enqueue(StatusActuator);
        }
    }
}
