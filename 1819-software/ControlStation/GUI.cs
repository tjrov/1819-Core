using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ControlStation.Communication;
using ControlStation.Devices;
using ControlStation.Devices.Actuators;
using ControlStation.Devices.Sensors;

namespace ControlStation
{
    public class GUI : Form
    {
        private SerialCommunicationProcess comms;
        private SerialCommunicationPanel commsPanel;

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
        private DiagnosticsSensor versioning;

        private TableLayoutPanel centerPanel;
        private FlowLayoutPanel upperPanel;
        private GroupBox statusBox;
        private GroupBox toolsBox;
        private GroupBox thrustersBox;
        private TableLayoutPanel statusPanel;
        private Panel thrustersPanel;
        private TableLayoutPanel attitudePanel;
        private Panel toolsPanel;
        private GroupBox communicationBox;
        private GroupBox controllerBox;
        private GroupBox groupBox1;
        private TableLayoutPanel attitudeDepthPanel;
        private GroupBox depthBox;
        private GroupBox attitudeBox;
        private List<GenericDevice> devices;

        public GUI()
        {
            InitializeComponent();
            timer = new Timer
            {
                Interval = 10
            };
            timer.Tick += TimerLoop;

            //setup serial port
            BetterSerialPort port = new BetterSerialPort(ControlStation.Properties.Settings.Default.PortName,
                ControlStation.Properties.Settings.Default.BaudRate);
            comms = new SerialCommunicationProcess(port);
            commsPanel = new SerialCommunicationPanel(port);
            port.IsOpenChanged += OnIsOpenChanged;
            comms.ExceptionThrown += OnExceptionThrown;

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

            versioning = new DiagnosticsSensor(new VersionData());

            //put them in the list
            devices = new List<GenericDevice>();
            devices.Add(depth);
            devices.Add(imu);
            devices.Add(escs);
            devices.Add(thrusters);
            devices.Add(tools);
            devices.Add(status);
            devices.Add(statusControl);
            devices.Add(versioning);

            //add controls to their respective panels
            communicationBox.Controls.Add(commsPanel);
            commsPanel.Location = new Point(0, 10);
            controllerBox.Controls.Add(new Label { Text = "Joystick placeholder" });

            statusPanel.Controls.Add(status, 0, 0);
            statusPanel.Controls.Add(statusControl, 0, 1);
            statusPanel.Controls.Add(versioning, 0, 2);
            statusPanel.Controls.Add(escs, 1, 0);
            statusPanel.SetRowSpan(escs, 3);

            toolsPanel.Controls.Add(tools);

            thrustersPanel.Controls.Add(thrusters);

            depthBox.Controls.Add(depth);
            attitudeBox.Controls.Add(imu);

            //disable all devices to start off
            foreach (GenericDevice device in devices)
            {
                device.Enabled = false;
            }

            upperPanel.SendToBack(); //don't overlap top bar with main section
        }

        private void OnExceptionThrown(object sender, Exception e)
        {
            //show dialog on UI thread
            this.Invoke(new Action(() => MessageBox.Show(e.Message + " (See log.txt for details)",
                "Exception in communication thread", MessageBoxButtons.OK, MessageBoxIcon.Error)));
        }

        private void OnIsOpenChanged(object sender, bool isOpen)
        {
            //enable/disable all device panels
            foreach (GenericDevice device in devices)
            {
                device.Enabled = isOpen;
            }
            //start/stop timer
            timer.Enabled = isOpen;
            //ask for new version and diagnostics
            if(isOpen)
            {
                comms.QueueDeviceUpdate(versioning);
            }
        }

        private void SlowLoop()
        {
            comms.QueueDeviceUpdate(escs);
            comms.QueueDeviceUpdate(statusControl);
            comms.QueueDeviceUpdate(status);
        }

        private void MediumLoop()
        {
            comms.QueueDeviceUpdate(imu);
            comms.QueueDeviceUpdate(depth);
            comms.QueueDeviceUpdate(tools);
        }

        private void FastLoop()
        {
            comms.QueueDeviceUpdate(thrusters);
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
            this.toolsPanel = new System.Windows.Forms.Panel();
            this.statusBox = new System.Windows.Forms.GroupBox();
            this.statusPanel = new System.Windows.Forms.TableLayoutPanel();
            this.thrustersBox = new System.Windows.Forms.GroupBox();
            this.thrustersPanel = new System.Windows.Forms.Panel();
            this.attitudePanel = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.upperPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.communicationBox = new System.Windows.Forms.GroupBox();
            this.controllerBox = new System.Windows.Forms.GroupBox();
            this.attitudeDepthPanel = new System.Windows.Forms.TableLayoutPanel();
            this.depthBox = new System.Windows.Forms.GroupBox();
            this.attitudeBox = new System.Windows.Forms.GroupBox();
            this.centerPanel.SuspendLayout();
            this.toolsBox.SuspendLayout();
            this.statusBox.SuspendLayout();
            this.thrustersBox.SuspendLayout();
            this.attitudePanel.SuspendLayout();
            this.upperPanel.SuspendLayout();
            this.attitudeDepthPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // centerPanel
            // 
            this.centerPanel.AutoSize = true;
            this.centerPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.centerPanel.BackColor = System.Drawing.Color.Transparent;
            this.centerPanel.ColumnCount = 2;
            this.centerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.centerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 675F));
            this.centerPanel.Controls.Add(this.toolsBox, 0, 1);
            this.centerPanel.Controls.Add(this.statusBox, 0, 0);
            this.centerPanel.Controls.Add(this.thrustersBox, 1, 0);
            this.centerPanel.Controls.Add(this.attitudeDepthPanel, 1, 1);
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
            this.toolsBox.Location = new System.Drawing.Point(3, 480);
            this.toolsBox.Name = "toolsBox";
            this.toolsBox.Size = new System.Drawing.Size(599, 471);
            this.toolsBox.TabIndex = 1;
            this.toolsBox.TabStop = false;
            this.toolsBox.Text = "Manipulators";
            // 
            // toolsPanel
            // 
            this.toolsPanel.BackgroundImage = global::ControlStation.Properties.Resources.rov_tools;
            this.toolsPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.toolsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolsPanel.Location = new System.Drawing.Point(3, 34);
            this.toolsPanel.Name = "toolsPanel";
            this.toolsPanel.Size = new System.Drawing.Size(593, 434);
            this.toolsPanel.TabIndex = 0;
            // 
            // statusBox
            // 
            this.statusBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.statusBox.Controls.Add(this.statusPanel);
            this.statusBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusBox.Location = new System.Drawing.Point(3, 3);
            this.statusBox.Name = "statusBox";
            this.statusBox.Size = new System.Drawing.Size(599, 471);
            this.statusBox.TabIndex = 0;
            this.statusBox.TabStop = false;
            this.statusBox.Text = "System Status/Control";
            // 
            // statusPanel
            // 
            this.statusPanel.BackgroundImage = global::ControlStation.Properties.Resources.rov_electronics;
            this.statusPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.statusPanel.ColumnCount = 2;
            this.statusPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.statusPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.statusPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusPanel.Location = new System.Drawing.Point(3, 34);
            this.statusPanel.Name = "statusPanel";
            this.statusPanel.RowCount = 3;
            this.statusPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.statusPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.statusPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.statusPanel.Size = new System.Drawing.Size(593, 434);
            this.statusPanel.TabIndex = 0;
            // 
            // thrustersBox
            // 
            this.thrustersBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.thrustersBox.Controls.Add(this.thrustersPanel);
            this.thrustersBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.thrustersBox.Location = new System.Drawing.Point(608, 3);
            this.thrustersBox.Name = "thrustersBox";
            this.thrustersBox.Size = new System.Drawing.Size(669, 471);
            this.thrustersBox.TabIndex = 2;
            this.thrustersBox.TabStop = false;
            this.thrustersBox.Text = "Propulsion";
            // 
            // thrustersPanel
            // 
            this.thrustersPanel.BackgroundImage = global::ControlStation.Properties.Resources.rov_thrusters;
            this.thrustersPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.thrustersPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.thrustersPanel.Location = new System.Drawing.Point(3, 34);
            this.thrustersPanel.Name = "thrustersPanel";
            this.thrustersPanel.Size = new System.Drawing.Size(663, 434);
            this.thrustersPanel.TabIndex = 0;
            // 
            // attitudePanel
            // 
            this.attitudePanel.ColumnCount = 2;
            this.attitudePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.attitudePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.attitudePanel.Controls.Add(this.groupBox1, 1, 0);
            this.attitudePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.attitudePanel.Location = new System.Drawing.Point(3, 34);
            this.attitudePanel.Name = "attitudePanel";
            this.attitudePanel.RowCount = 1;
            this.attitudePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.attitudePanel.Size = new System.Drawing.Size(663, 434);
            this.attitudePanel.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(63, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(597, 428);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Attitude & Heading";
            // 
            // upperPanel
            // 
            this.upperPanel.BackColor = System.Drawing.Color.Transparent;
            this.upperPanel.Controls.Add(this.communicationBox);
            this.upperPanel.Controls.Add(this.controllerBox);
            this.upperPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.upperPanel.Location = new System.Drawing.Point(0, 0);
            this.upperPanel.Name = "upperPanel";
            this.upperPanel.Size = new System.Drawing.Size(1280, 50);
            this.upperPanel.TabIndex = 3;
            // 
            // communicationBox
            // 
            this.communicationBox.AutoSize = true;
            this.communicationBox.Location = new System.Drawing.Point(3, 3);
            this.communicationBox.Name = "communicationBox";
            this.communicationBox.Padding = new System.Windows.Forms.Padding(10);
            this.communicationBox.Size = new System.Drawing.Size(20, 19);
            this.communicationBox.TabIndex = 0;
            this.communicationBox.TabStop = false;
            this.communicationBox.Text = "Serial Communication";
            // 
            // controllerBox
            // 
            this.controllerBox.AutoSize = true;
            this.controllerBox.Location = new System.Drawing.Point(29, 3);
            this.controllerBox.Name = "controllerBox";
            this.controllerBox.Padding = new System.Windows.Forms.Padding(10);
            this.controllerBox.Size = new System.Drawing.Size(20, 19);
            this.controllerBox.TabIndex = 1;
            this.controllerBox.TabStop = false;
            this.controllerBox.Text = "Controllers";
            // 
            // attitudeDepthPanel
            // 
            this.attitudeDepthPanel.ColumnCount = 2;
            this.attitudeDepthPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.attitudeDepthPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.attitudeDepthPanel.Controls.Add(this.depthBox, 0, 0);
            this.attitudeDepthPanel.Controls.Add(this.attitudeBox, 1, 0);
            this.attitudeDepthPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.attitudeDepthPanel.Location = new System.Drawing.Point(608, 480);
            this.attitudeDepthPanel.Name = "attitudeDepthPanel";
            this.attitudeDepthPanel.RowCount = 1;
            this.attitudeDepthPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.attitudeDepthPanel.Size = new System.Drawing.Size(669, 471);
            this.attitudeDepthPanel.TabIndex = 3;
            // 
            // depthBox
            // 
            this.depthBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.depthBox.Location = new System.Drawing.Point(3, 3);
            this.depthBox.Name = "depthBox";
            this.depthBox.Size = new System.Drawing.Size(54, 465);
            this.depthBox.TabIndex = 0;
            this.depthBox.TabStop = false;
            this.depthBox.Text = "Depth";
            // 
            // attitudeBox
            // 
            this.attitudeBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.attitudeBox.Location = new System.Drawing.Point(63, 3);
            this.attitudeBox.Name = "attitudeBox";
            this.attitudeBox.Size = new System.Drawing.Size(603, 465);
            this.attitudeBox.TabIndex = 1;
            this.attitudeBox.TabStop = false;
            this.attitudeBox.Text = "Attitude/Heading";
            // 
            // GUI
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1280, 1024);
            this.Controls.Add(this.centerPanel);
            this.Controls.Add(this.upperPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "GUI";
            this.Load += new System.EventHandler(this.GUI_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GUI_KeyPress);
            this.centerPanel.ResumeLayout(false);
            this.toolsBox.ResumeLayout(false);
            this.statusBox.ResumeLayout(false);
            this.thrustersBox.ResumeLayout(false);
            this.attitudePanel.ResumeLayout(false);
            this.upperPanel.ResumeLayout(false);
            this.upperPanel.PerformLayout();
            this.attitudeDepthPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void GUI_Load(object sender, EventArgs e)
        {
        }

        private void GUI_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch(e.KeyChar)
            {
                case '1':
                    tools.Data[0].Speed++;
                    break;
                case '2':
                    tools.Data[0].Speed--;
                    break;
            }
        }
    }
}
