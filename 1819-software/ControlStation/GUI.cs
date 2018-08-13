using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ControlStation
{
    public class GUI : Form
    {
        private SerialCommunication comms;

        private BackgroundWorker commsBackgroundWorker;
        private long lastLoopTime;
        private long loopTime = TimeSpan.TicksPerMillisecond * 50;
        private int count10Hz = 0;
        private int count1Hz = 0;

        private OrientationSensor imu;
        private DepthSensor depth;
        private PropulsionActuator thrusters;
        private PropulsionSensor escs;
        private StatusSensor status;
        private ToolsActuator tools;
        private StatusActuator system;

        private List<IDevice> deviceList;
        private List<DevicePanel> displayList;

        private FlowLayoutPanel panel;

        private Label label = new Label();

        public GUI()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            // 
            // panel
            // 
            this.panel = new FlowLayoutPanel();
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Size = new System.Drawing.Size(1280, 1024);
            this.panel.TabIndex = 0;
            // 
            // GUI
            // 
            this.ClientSize = new System.Drawing.Size(1280, 1024);
            this.Controls.Add(this.panel);
            panel.Controls.Add(label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Load += new System.EventHandler(this.GUI_Load);
            this.ResumeLayout(false);
            //this.TopMost = true;

        }

        private void GUI_Load(object sender, EventArgs e)
        {
            //start serial comms
            comms = new SerialCommunication("COM1", 115200);
            comms.OnConnectionStatusChanged += OnConnectionStatusChanged;

            //construct sensor and actuator display objects
            depth = new DepthSensor(comms);
            imu = new OrientationSensor(comms);
            thrusters = new PropulsionActuator(comms);
            tools = new ToolsActuator(comms);
            escs = new PropulsionSensor(comms);
            status = new StatusSensor(comms);
            system = new StatusActuator(comms);

            panel.Controls.Add(comms);

            //does communication on a background thread
            commsBackgroundWorker = new BackgroundWorker();
            commsBackgroundWorker.DoWork += CommsBackgroundLoop;
            commsBackgroundWorker.RunWorkerCompleted += OnCommsBackgroundLoopExited;
            commsBackgroundWorker.WorkerSupportsCancellation = true;
        }

        private void OnConnectionStatusChanged(object sender, EventArgs e)
        {
            //start or stop the background thread on port connect/disconnect
            if (comms.PortIsOpen)
            {
                if (!commsBackgroundWorker.IsBusy)
                {
                    commsBackgroundWorker.RunWorkerAsync();
                }
            }
            else
            {
                if (!commsBackgroundWorker.CancellationPending)
                {
                    //no longer needed since while loop exits on port close
                    //commsBackgroundWorker.CancelAsync();
                }
            }
        }

        private void Loop100Hz(object sender, EventArgs e)
        {
            count10Hz++;
            count1Hz++;
            //Handle running other timers on same thread at proper intervals
            if (count10Hz > 10)
            {
                Loop10Hz();
                count10Hz = 0;
            }
            else if (count1Hz > 100)
            {
                Loop1Hz();
                count1Hz = 0;
            }
            else
            {
                thrusters.Update();
            }
            //imu.Update();
            //depth.Update();
        }

        private void Loop1Hz()
        {
            escs.Update();
            status.Update();
        }

        private void Loop10Hz()
        {
            imu.Update();
            depth.Update();
        }

        private void CommsBackgroundLoop(object sender, DoWorkEventArgs e)
        {
            while (comms.PortIsOpen)
            {
                if ((DateTime.Now.Ticks - lastLoopTime) > loopTime)
                {
                    lastLoopTime = DateTime.Now.Ticks;

                    thrusters.Update();
                }
                Thread.Sleep(1);
            }
        }

        private void OnCommsBackgroundLoopExited(object sender, RunWorkerCompletedEventArgs e)
        {
            if(e.Error != null)
            {
                comms.ClosePort();
                //show recent communications for debugging purposes
                MessageBox.Show(comms.GetHistory() + e.Error.Message, "Communication history",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                throw e.Error; //so that the main method will show a dialog
            }
        }
    }
}
