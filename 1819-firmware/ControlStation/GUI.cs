using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlStation
{
    public class GUI : Form
    {
        private SerialCommunication comms;

        private Timer timer100Hz;
        private int tickCount = 0;

        private IMU imu;
        private PropulsionActuator thrusters;
        private PropulsionSensor escs;
        private StatusSensor status;

        public GUI() : base()
        {
            //TopMost = true; //forefront
            //FormBorderStyle = FormBorderStyle.None; //fullscreen
            //WindowState = FormWindowState.Maximized; //maximize window

            //start serial comms
            comms = new SerialCommunication("COM1", 115200);

            //construct sensor and actuator display objects
            imu = new IMU(comms);
            thrusters = new PropulsionActuator(comms);
            escs = new PropulsionSensor(comms);
            status = new StatusSensor(comms);

            //start timer
            timer100Hz = new Timer();
            timer100Hz.Interval = 10;
            timer100Hz.Tick += new EventHandler(Tick100Hz);
            timer100Hz.Enabled = true;
        }

        private void Tick2Hz()
        {
            //escs.Update();
            status.Update();
            //thrusters.Update();
        }

        private void Tick100Hz(object sender, EventArgs e)
        {
            //Handle running Tick2Hz on same thread at proper interval
            if(tickCount > 50)
            {
                Tick2Hz();
                tickCount = 0;
            }
            //thrusters.Update();
            //imu.Update();
            tickCount++;
        }
    }
}
