using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ControlStation
{
    public class GUI : Form
    {
        //private FlowLayoutPanel panel;
        private SerialCommunication comms;

        private int countSlow = 0;
        private int countMedium = 0;
        private Timer timer;

        private OrientationSensor imu;
        private DepthSensor depth;
        private PropulsionActuator thrusters;
        private PropulsionSensor escs;
        private StatusSensor status;
        private ToolsActuator tools;
        private StatusActuator statusControl;
        private TableLayoutPanel centerPanel;
        private FlowLayoutPanel upperPanel;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private List<GenericDevice> devices;

        public GUI()
        {
            InitializeComponent();
        }

        private void OnIsPortOpenChanged(object sender, bool e)
        {
            //enable/disable all device panels
            foreach (GenericDevice device in devices)
            {
                device.Enabled = e;
            }
            //start/stop timer
            timer.Enabled = e;
        }

        private void SlowLoop()
        {
            comms.QueueDevice(escs);
            comms.QueueDevice(statusControl);
            comms.QueueDevice(status);
        }

        private void MediumLoop()
        {
            comms.QueueDevice(imu);
            comms.QueueDevice(depth);
            comms.QueueDevice(tools);
        }

        private void FastLoop()
        {
            comms.QueueDevice(thrusters);
        }

        private void TimerLoop(object sender, EventArgs e)
        {

            countSlow++;
            countMedium++;
            if (countSlow > 50)
            {
                countSlow = 0;
                SlowLoop();
            }
            else if (countMedium > 5)
            {
                countMedium = 0;
                MediumLoop();
            }
            else
            {
                FastLoop();
            }
        }

        private void InitializeComponent()
        {
            this.centerPanel = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.upperPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.centerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // centerPanel
            // 
            this.centerPanel.ColumnCount = 2;
            this.centerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.centerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.centerPanel.Controls.Add(this.groupBox2, 1, 0);
            this.centerPanel.Controls.Add(this.groupBox1, 0, 0);
            this.centerPanel.Controls.Add(this.groupBox3, 0, 1);
            this.centerPanel.Controls.Add(this.groupBox4, 1, 1);
            this.centerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.centerPanel.Location = new System.Drawing.Point(0, 0);
            this.centerPanel.Name = "centerPanel";
            this.centerPanel.Padding = new System.Windows.Forms.Padding(10, 10, 10, 25);
            this.centerPanel.RowCount = 2;
            this.centerPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.centerPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.centerPanel.Size = new System.Drawing.Size(1280, 1024);
            this.centerPanel.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.BackgroundImage = global::ControlStation.Properties.Resources.rov_tools;
            this.groupBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(643, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(624, 488);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tools";
            // 
            // groupBox1
            // 
            this.groupBox1.BackgroundImage = global::ControlStation.Properties.Resources.rov_electronics;
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(624, 488);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Status";
            // 
            // groupBox3
            // 
            this.groupBox3.BackgroundImage = global::ControlStation.Properties.Resources.rov_thrusters;
            this.groupBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(13, 507);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(624, 489);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Thrusters";
            // 
            // groupBox4
            // 
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(643, 507);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(624, 489);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Attitude";
            // 
            // upperPanel
            // 
            this.upperPanel.AutoSize = true;
            this.upperPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.upperPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.upperPanel.Location = new System.Drawing.Point(0, 0);
            this.upperPanel.Name = "upperPanel";
            this.upperPanel.Size = new System.Drawing.Size(1280, 0);
            this.upperPanel.TabIndex = 3;
            // 
            // GUI
            // 
            this.ClientSize = new System.Drawing.Size(1280, 1024);
            this.Controls.Add(this.upperPanel);
            this.Controls.Add(this.centerPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GUI";
            this.Load += new System.EventHandler(this.GUI_Load);
            this.centerPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void GUI_Load(object sender, EventArgs e)
        {
            timer = new Timer
            {
                Interval = 10
            };
            timer.Tick += TimerLoop;

            //top window, fullscreen, no border
            /*ClientSize = new Size(1280, 1024);
            FormBorderStyle = FormBorderStyle.None;*/
            //TopMost = true;

            //panel to hold subpanels
            /*panel = new FlowLayoutPanel
            {
                Dock = System.Windows.Forms.DockStyle.Fill,
                Location = new System.Drawing.Point(0, 0),
                Size = new System.Drawing.Size(1280, 1024),
                BackColor = Color.Black
            };*/

            //setup serial port
            comms = new SerialCommunication("COM5", 250000);
            comms.IsPortOpenChanged += OnIsPortOpenChanged;

            //construct sensor and actuator objects
            depth = new DepthSensor(new DepthData());
            imu = new OrientationSensor(new OrientationData());

            List<ToolData> toolList = new List<ToolData>();
            for (int i = 0; i < 3; i++)
            {
                toolList.Add(new ToolData());
            }
            tools = new ToolsActuator(toolList);

            //both use the same data object
            List<ESCData> escList = new List<ESCData>();
            for (int i = 0; i < 6; i++)
            {
                escList.Add(new ESCData());
            }
            escs = new PropulsionSensor(escList);
            thrusters = new PropulsionActuator(escList);

            //both use the same data object
            StatusData state = new StatusData();
            status = new StatusSensor(state);
            statusControl = new StatusActuator(state);

            //put them in the dictionary
            devices = new List<GenericDevice>();
            devices.Add(depth);
            devices.Add(imu);
            devices.Add(escs);
            devices.Add(thrusters);
            devices.Add(tools);
            devices.Add(status);
            devices.Add(statusControl);

            //add everything in
            upperPanel.Controls.Add(comms);
            foreach (GenericDevice device in devices)
            {
                //centerPanel.Controls.Add(device);
                device.Enabled = false;
            }
            upperPanel.SendToBack();
        }
    }
}
