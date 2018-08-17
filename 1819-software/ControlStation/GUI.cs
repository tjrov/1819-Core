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

        private AttitudeIndicator attitudeIndicator;
        private HeadingIndicator headingIndicator;

        private TableLayoutPanel centerPanel;
        private FlowLayoutPanel upperPanel;
        private GroupBox statusBox;
        private GroupBox toolsBox;
        private GroupBox thrustersBox;
        private GroupBox attitudeBox;
        private FlowLayoutPanel toolsPanel;
        private FlowLayoutPanel thrustersPanel;
        private FlowLayoutPanel attitudePanel;
        private FlowLayoutPanel statusPanel;
        private List<GenericDevice> devices;

        public GUI()
        {
            InitializeComponent();
            upperPanel.SendToBack(); //don't overlap with controls
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
            this.toolsBox = new System.Windows.Forms.GroupBox();
            this.toolsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.statusBox = new System.Windows.Forms.GroupBox();
            this.statusPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.thrustersBox = new System.Windows.Forms.GroupBox();
            this.thrustersPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.attitudeBox = new System.Windows.Forms.GroupBox();
            this.attitudePanel = new System.Windows.Forms.FlowLayoutPanel();
            this.upperPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.centerPanel.SuspendLayout();
            this.toolsBox.SuspendLayout();
            this.statusBox.SuspendLayout();
            this.thrustersBox.SuspendLayout();
            this.attitudeBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // centerPanel
            // 
            this.centerPanel.AutoSize = true;
            this.centerPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.centerPanel.ColumnCount = 2;
            this.centerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 43.84247F));
            this.centerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 56.15753F));
            this.centerPanel.Controls.Add(this.toolsBox, 0, 1);
            this.centerPanel.Controls.Add(this.statusBox, 0, 0);
            this.centerPanel.Controls.Add(this.thrustersBox, 1, 0);
            this.centerPanel.Controls.Add(this.attitudeBox, 1, 1);
            this.centerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.centerPanel.Location = new System.Drawing.Point(0, 50);
            this.centerPanel.Name = "centerPanel";
            this.centerPanel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 20);
            this.centerPanel.RowCount = 2;
            this.centerPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.centerPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.centerPanel.Size = new System.Drawing.Size(1280, 974);
            this.centerPanel.TabIndex = 3;
            // 
            // toolsBox
            // 
            this.toolsBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.toolsBox.Controls.Add(this.toolsPanel);
            this.toolsBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolsBox.Location = new System.Drawing.Point(13, 482);
            this.toolsBox.Name = "toolsBox";
            this.toolsBox.Size = new System.Drawing.Size(697, 464);
            this.toolsBox.TabIndex = 1;
            this.toolsBox.TabStop = false;
            this.toolsBox.Text = "Tools";
            // 
            // toolsPanel
            // 
            this.toolsPanel.BackgroundImage = global::ControlStation.Properties.Resources.rov_tools;
            this.toolsPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.toolsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolsPanel.Location = new System.Drawing.Point(3, 34);
            this.toolsPanel.Name = "toolsPanel";
            this.toolsPanel.Size = new System.Drawing.Size(691, 427);
            this.toolsPanel.TabIndex = 0;
            // 
            // statusBox
            // 
            this.statusBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.statusBox.Controls.Add(this.statusPanel);
            this.statusBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusBox.Location = new System.Drawing.Point(13, 13);
            this.statusBox.Name = "statusBox";
            this.statusBox.Size = new System.Drawing.Size(697, 463);
            this.statusBox.TabIndex = 0;
            this.statusBox.TabStop = false;
            this.statusBox.Text = "Status";
            // 
            // statusPanel
            // 
            this.statusPanel.BackgroundImage = global::ControlStation.Properties.Resources.rov_electronics;
            this.statusPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.statusPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.statusPanel.Location = new System.Drawing.Point(3, 34);
            this.statusPanel.Name = "statusPanel";
            this.statusPanel.Size = new System.Drawing.Size(691, 426);
            this.statusPanel.TabIndex = 0;
            // 
            // thrustersBox
            // 
            this.thrustersBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.thrustersBox.Controls.Add(this.thrustersPanel);
            this.thrustersBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.thrustersBox.Location = new System.Drawing.Point(716, 13);
            this.thrustersBox.Name = "thrustersBox";
            this.thrustersBox.Size = new System.Drawing.Size(644, 463);
            this.thrustersBox.TabIndex = 2;
            this.thrustersBox.TabStop = false;
            this.thrustersBox.Text = "Thrusters";
            // 
            // thrustersPanel
            // 
            this.thrustersPanel.BackgroundImage = global::ControlStation.Properties.Resources.rov_thrusters;
            this.thrustersPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.thrustersPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.thrustersPanel.Location = new System.Drawing.Point(3, 34);
            this.thrustersPanel.Name = "thrustersPanel";
            this.thrustersPanel.Size = new System.Drawing.Size(638, 426);
            this.thrustersPanel.TabIndex = 0;
            // 
            // attitudeBox
            // 
            this.attitudeBox.Controls.Add(this.attitudePanel);
            this.attitudeBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.attitudeBox.Location = new System.Drawing.Point(716, 482);
            this.attitudeBox.Name = "attitudeBox";
            this.attitudeBox.Size = new System.Drawing.Size(644, 464);
            this.attitudeBox.TabIndex = 3;
            this.attitudeBox.TabStop = false;
            this.attitudeBox.Text = "Attitude";
            // 
            // attitudePanel
            // 
            this.attitudePanel.BackColor = System.Drawing.SystemColors.Control;
            this.attitudePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.attitudePanel.Location = new System.Drawing.Point(3, 34);
            this.attitudePanel.Name = "attitudePanel";
            this.attitudePanel.Size = new System.Drawing.Size(638, 427);
            this.attitudePanel.TabIndex = 0;
            // 
            // upperPanel
            // 
            this.upperPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.upperPanel.Location = new System.Drawing.Point(0, 0);
            this.upperPanel.Name = "upperPanel";
            this.upperPanel.Size = new System.Drawing.Size(1280, 50);
            this.upperPanel.TabIndex = 3;
            // 
            // GUI
            // 
            this.ClientSize = new System.Drawing.Size(1280, 1024);
            this.Controls.Add(this.centerPanel);
            this.Controls.Add(this.upperPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GUI";
            this.Load += new System.EventHandler(this.GUI_Load);
            this.centerPanel.ResumeLayout(false);
            this.toolsBox.ResumeLayout(false);
            this.statusBox.ResumeLayout(false);
            this.thrustersBox.ResumeLayout(false);
            this.attitudeBox.ResumeLayout(false);
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

            List<ESCData> escList = new List<ESCData>();
            for (int i = 0; i < 6; i++)
            {
                escList.Add(new ESCData());
            }
            escs = new PropulsionSensor(escList);
            thrusters = new PropulsionActuator(escList);

            StatusData state = new StatusData();
            status = new StatusSensor(state);
            statusControl = new StatusActuator(state);

            //put them in the list
            devices = new List<GenericDevice>();
            devices.Add(depth);
            devices.Add(imu);
            devices.Add(escs);
            devices.Add(thrusters);
            devices.Add(tools);
            devices.Add(status);
            devices.Add(statusControl);

            //add controls to their respective panels
            upperPanel.Controls.Add(comms);

            statusPanel.Controls.Add(status);
            statusPanel.Controls.Add(statusControl);

            toolsPanel.Controls.Add(tools);

            thrustersPanel.Controls.Add(thrusters);

            attitudePanel.Controls.Add(imu);
            attitudePanel.Controls.Add(depth);

            //disable all devices to start off
            foreach (GenericDevice device in devices)
            {
                device.Enabled = false;
            }
        }
    }
}
