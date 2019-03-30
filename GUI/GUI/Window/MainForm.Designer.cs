using System.Collections.Generic;
using System.Drawing;

namespace GUI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer500 = new System.Windows.Forms.Timer(this.components);
            this.connectButton = new System.Windows.Forms.Button();
            this.queueLabel = new System.Windows.Forms.Label();
            this.armButton = new System.Windows.Forms.Button();
            this.portLabel = new System.Windows.Forms.Label();
            this.resetButton = new System.Windows.Forms.Button();
            this.PilotConnectionLabel = new System.Windows.Forms.Label();
            this.controllerUpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.topLeft = new System.Windows.Forms.Label();
            this.topRight = new System.Windows.Forms.Label();
            this.midLeft = new System.Windows.Forms.Label();
            this.midRight = new System.Windows.Forms.Label();
            this.botLeft = new System.Windows.Forms.Label();
            this.botRight = new System.Windows.Forms.Label();
            this.depthLockEngageLabel = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.trackBar3 = new System.Windows.Forms.TrackBar();
            this.trackBar4 = new System.Windows.Forms.TrackBar();
            this.cvButton = new System.Windows.Forms.Button();
            this.forPrefButton = new System.Windows.Forms.Button();
            this.backPrefButton = new System.Windows.Forms.Button();
            this.rightPrefButton = new System.Windows.Forms.Button();
            this.leftPrefButton = new System.Windows.Forms.Button();
            this.capButton = new System.Windows.Forms.Button();
            this.rovPanel = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.RectangleCount = new System.Windows.Forms.Label();
            this.SquareCount = new System.Windows.Forms.Label();
            this.CircleCount = new System.Windows.Forms.Label();
            this.triangleCount = new System.Windows.Forms.Label();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pilotPanel = new System.Windows.Forms.Panel();
            this.l9 = new System.Windows.Forms.Label();
            this.l8 = new System.Windows.Forms.Label();
            this.l7 = new System.Windows.Forms.Label();
            this.l6 = new System.Windows.Forms.Label();
            this.l5 = new System.Windows.Forms.Label();
            this.l4 = new System.Windows.Forms.Label();
            this.l3 = new System.Windows.Forms.Label();
            this.l2 = new System.Windows.Forms.Label();
            this.l1 = new System.Windows.Forms.Label();
            this.pilotRightIndicator = new System.Windows.Forms.Button();
            this.pilotUpIndicator = new System.Windows.Forms.Button();
            this.pilotLeftIndicator = new System.Windows.Forms.Button();
            this.pilotDownIndicator = new System.Windows.Forms.Button();
            this.pilotBIndicator = new System.Windows.Forms.Button();
            this.pilotYIndicator = new System.Windows.Forms.Button();
            this.pilotXIndicator = new System.Windows.Forms.Button();
            this.pilotAIndicator = new System.Windows.Forms.Button();
            this.pilotRStickIndicator = new System.Windows.Forms.Button();
            this.pilotLStickIndicator = new System.Windows.Forms.Button();
            this.pilotRBumperIndicator = new System.Windows.Forms.Button();
            this.pilotRTriggerIndicator = new System.Windows.Forms.Button();
            this.pilotLBumperIndicator = new System.Windows.Forms.Button();
            this.pilotLTriggerIndicator = new System.Windows.Forms.Button();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.copilotPanel = new System.Windows.Forms.Panel();
            this.cl6 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cl3 = new System.Windows.Forms.Label();
            this.cl5 = new System.Windows.Forms.Label();
            this.cl4 = new System.Windows.Forms.Label();
            this.cl2 = new System.Windows.Forms.Label();
            this.cl1 = new System.Windows.Forms.Label();
            this.copilotRightIndicator = new System.Windows.Forms.Button();
            this.copilotUpIndicator = new System.Windows.Forms.Button();
            this.copilotLeftIndicator = new System.Windows.Forms.Button();
            this.copilotDownIndicator = new System.Windows.Forms.Button();
            this.copilotBIndicator = new System.Windows.Forms.Button();
            this.copilotYIndicator = new System.Windows.Forms.Button();
            this.copilotXIndicator = new System.Windows.Forms.Button();
            this.copilotAIndicator = new System.Windows.Forms.Button();
            this.copilotRStickIndicator = new System.Windows.Forms.Button();
            this.copilotLStickIndicator = new System.Windows.Forms.Button();
            this.copilotRBumperIndicator = new System.Windows.Forms.Button();
            this.copilotRTriggerIndicator = new System.Windows.Forms.Button();
            this.copilotLBumperIndicator = new System.Windows.Forms.Button();
            this.copilotLTriggerIndicator = new System.Windows.Forms.Button();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.CopilotConnectionLabel = new System.Windows.Forms.Label();
            this.headingLockEngageLabel = new System.Windows.Forms.Label();
            this.rollLockEngageLabel = new System.Windows.Forms.Label();
            this.containerPicture = new System.Windows.Forms.PictureBox();
            this.clawPicture = new System.Windows.Forms.PictureBox();
            this.propulsionActuator1 = new GUI.PropulsionActuator();
            this.propulsionActuator2 = new GUI.PropulsionActuator();
            this.cvFinalImage = new System.Windows.Forms.PictureBox();
            this.cvFinalProcessedImage = new System.Windows.Forms.PictureBox();
            this.cameraFeed = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar4)).BeginInit();
            this.rovPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.pilotPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            this.copilotPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.containerPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clawPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cvFinalImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cvFinalProcessedImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cameraFeed)).BeginInit();
            this.SuspendLayout();
            // 
            // timer500
            // 
            this.timer500.Interval = 500;
            this.timer500.Tick += new System.EventHandler(this.timer500_Tick);
            // 
            // connectButton
            // 
            this.connectButton.AutoSize = true;
            this.connectButton.Location = new System.Drawing.Point(11, 11);
            this.connectButton.Margin = new System.Windows.Forms.Padding(2);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(83, 23);
            this.connectButton.TabIndex = 0;
            this.connectButton.Text = "Connect ROV";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectROV_Click);
            // 
            // queueLabel
            // 
            this.queueLabel.AutoSize = true;
            this.queueLabel.Location = new System.Drawing.Point(186, 16);
            this.queueLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.queueLabel.Name = "queueLabel";
            this.queueLabel.Size = new System.Drawing.Size(77, 13);
            this.queueLabel.TabIndex = 1;
            this.queueLabel.Text = "Queue length: ";
            // 
            // armButton
            // 
            this.armButton.AutoSize = true;
            this.armButton.Location = new System.Drawing.Point(98, 11);
            this.armButton.Margin = new System.Windows.Forms.Padding(2);
            this.armButton.Name = "armButton";
            this.armButton.Size = new System.Drawing.Size(35, 23);
            this.armButton.TabIndex = 2;
            this.armButton.Text = "Arm";
            this.armButton.UseVisualStyleBackColor = true;
            this.armButton.Click += new System.EventHandler(this.arm_Click);
            // 
            // portLabel
            // 
            this.portLabel.AutoSize = true;
            this.portLabel.Location = new System.Drawing.Point(112, -60);
            this.portLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(0, 13);
            this.portLabel.TabIndex = 3;
            // 
            // resetButton
            // 
            this.resetButton.AutoSize = true;
            this.resetButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.resetButton.Location = new System.Drawing.Point(137, 11);
            this.resetButton.Margin = new System.Windows.Forms.Padding(2);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(45, 23);
            this.resetButton.TabIndex = 4;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // PilotConnectionLabel
            // 
            this.PilotConnectionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PilotConnectionLabel.AutoSize = true;
            this.PilotConnectionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PilotConnectionLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.PilotConnectionLabel.Location = new System.Drawing.Point(544, 649);
            this.PilotConnectionLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.PilotConnectionLabel.Name = "PilotConnectionLabel";
            this.PilotConnectionLabel.Size = new System.Drawing.Size(201, 15);
            this.PilotConnectionLabel.TabIndex = 5;
            this.PilotConnectionLabel.Text = "Pilot Controller Not Connected";
            this.PilotConnectionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // controllerUpdateTimer
            // 
            this.controllerUpdateTimer.Enabled = true;
            this.controllerUpdateTimer.Interval = 5;
            this.controllerUpdateTimer.Tick += new System.EventHandler(this.controllerUpdateTimer_Tick);
            // 
            // topLeft
            // 
            this.topLeft.AutoSize = true;
            this.topLeft.Location = new System.Drawing.Point(36, 57);
            this.topLeft.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.topLeft.Name = "topLeft";
            this.topLeft.Size = new System.Drawing.Size(27, 13);
            this.topLeft.TabIndex = 30;
            this.topLeft.Text = "N/A";
            // 
            // topRight
            // 
            this.topRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.topRight.AutoSize = true;
            this.topRight.Location = new System.Drawing.Point(160, 55);
            this.topRight.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.topRight.Name = "topRight";
            this.topRight.Size = new System.Drawing.Size(27, 13);
            this.topRight.TabIndex = 31;
            this.topRight.Text = "N/A";
            // 
            // midLeft
            // 
            this.midLeft.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.midLeft.AutoSize = true;
            this.midLeft.Location = new System.Drawing.Point(36, 132);
            this.midLeft.Margin = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.midLeft.Name = "midLeft";
            this.midLeft.Size = new System.Drawing.Size(27, 13);
            this.midLeft.TabIndex = 32;
            this.midLeft.Text = "N/A";
            // 
            // midRight
            // 
            this.midRight.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.midRight.AutoSize = true;
            this.midRight.Location = new System.Drawing.Point(160, 132);
            this.midRight.Margin = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.midRight.Name = "midRight";
            this.midRight.Size = new System.Drawing.Size(27, 13);
            this.midRight.TabIndex = 33;
            this.midRight.Text = "N/A";
            // 
            // botLeft
            // 
            this.botLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.botLeft.AutoSize = true;
            this.botLeft.Location = new System.Drawing.Point(36, 210);
            this.botLeft.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.botLeft.Name = "botLeft";
            this.botLeft.Size = new System.Drawing.Size(27, 13);
            this.botLeft.TabIndex = 34;
            this.botLeft.Text = "N/A";
            // 
            // botRight
            // 
            this.botRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.botRight.AutoSize = true;
            this.botRight.Location = new System.Drawing.Point(160, 210);
            this.botRight.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.botRight.Name = "botRight";
            this.botRight.Size = new System.Drawing.Size(27, 13);
            this.botRight.TabIndex = 35;
            this.botRight.Text = "N/A";
            // 
            // depthLockEngageLabel
            // 
            this.depthLockEngageLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.depthLockEngageLabel.AutoSize = true;
            this.depthLockEngageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.depthLockEngageLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.depthLockEngageLabel.Location = new System.Drawing.Point(1186, 9);
            this.depthLockEngageLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.depthLockEngageLabel.Name = "depthLockEngageLabel";
            this.depthLockEngageLabel.Size = new System.Drawing.Size(160, 15);
            this.depthLockEngageLabel.TabIndex = 41;
            this.depthLockEngageLabel.Text = "Depth Lock Disengaged";
            this.depthLockEngageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trackBar1
            // 
            this.trackBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.trackBar1.Location = new System.Drawing.Point(829, 373);
            this.trackBar1.Margin = new System.Windows.Forms.Padding(2);
            this.trackBar1.Maximum = 200;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar1.Size = new System.Drawing.Size(45, 91);
            this.trackBar1.TabIndex = 42;
            this.trackBar1.Value = 100;
            // 
            // trackBar2
            // 
            this.trackBar2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.trackBar2.Location = new System.Drawing.Point(878, 373);
            this.trackBar2.Margin = new System.Windows.Forms.Padding(2);
            this.trackBar2.Maximum = 200;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(156, 45);
            this.trackBar2.TabIndex = 43;
            this.trackBar2.Value = 108;
            // 
            // trackBar3
            // 
            this.trackBar3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.trackBar3.Location = new System.Drawing.Point(780, 373);
            this.trackBar3.Margin = new System.Windows.Forms.Padding(2);
            this.trackBar3.Maximum = 200;
            this.trackBar3.Name = "trackBar3";
            this.trackBar3.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar3.Size = new System.Drawing.Size(45, 91);
            this.trackBar3.TabIndex = 44;
            this.trackBar3.Value = 100;
            // 
            // trackBar4
            // 
            this.trackBar4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.trackBar4.Location = new System.Drawing.Point(878, 421);
            this.trackBar4.Margin = new System.Windows.Forms.Padding(2);
            this.trackBar4.Maximum = 200;
            this.trackBar4.Name = "trackBar4";
            this.trackBar4.Size = new System.Drawing.Size(156, 45);
            this.trackBar4.TabIndex = 45;
            this.trackBar4.Value = 100;
            // 
            // cvButton
            // 
            this.cvButton.Enabled = false;
            this.cvButton.Location = new System.Drawing.Point(98, 40);
            this.cvButton.Margin = new System.Windows.Forms.Padding(2);
            this.cvButton.Name = "cvButton";
            this.cvButton.Size = new System.Drawing.Size(92, 19);
            this.cvButton.TabIndex = 59;
            this.cvButton.Text = "Find Organisms";
            this.cvButton.UseMnemonic = false;
            this.cvButton.UseVisualStyleBackColor = true;
            this.cvButton.Click += new System.EventHandler(this.computerVisionButtonClick);
            // 
            // forPrefButton
            // 
            this.forPrefButton.BackColor = System.Drawing.Color.Green;
            this.forPrefButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.forPrefButton.Location = new System.Drawing.Point(86, 2);
            this.forPrefButton.Margin = new System.Windows.Forms.Padding(2);
            this.forPrefButton.Name = "forPrefButton";
            this.forPrefButton.Size = new System.Drawing.Size(80, 42);
            this.forPrefButton.TabIndex = 53;
            this.forPrefButton.Text = "↑";
            this.forPrefButton.UseVisualStyleBackColor = false;
            this.forPrefButton.Click += new System.EventHandler(this.forPrefButton_Click);
            // 
            // backPrefButton
            // 
            this.backPrefButton.BackColor = System.Drawing.Color.Red;
            this.backPrefButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.backPrefButton.Location = new System.Drawing.Point(86, 48);
            this.backPrefButton.Margin = new System.Windows.Forms.Padding(2);
            this.backPrefButton.Name = "backPrefButton";
            this.backPrefButton.Size = new System.Drawing.Size(80, 43);
            this.backPrefButton.TabIndex = 54;
            this.backPrefButton.Text = "↓";
            this.backPrefButton.UseVisualStyleBackColor = false;
            this.backPrefButton.Click += new System.EventHandler(this.backPrefButton_Click);
            // 
            // rightPrefButton
            // 
            this.rightPrefButton.BackColor = System.Drawing.Color.Red;
            this.rightPrefButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightPrefButton.Location = new System.Drawing.Point(170, 48);
            this.rightPrefButton.Margin = new System.Windows.Forms.Padding(2);
            this.rightPrefButton.Name = "rightPrefButton";
            this.rightPrefButton.Size = new System.Drawing.Size(82, 43);
            this.rightPrefButton.TabIndex = 55;
            this.rightPrefButton.Text = "→";
            this.rightPrefButton.UseVisualStyleBackColor = false;
            this.rightPrefButton.Click += new System.EventHandler(this.rightPrefButton_Click);
            // 
            // leftPrefButton
            // 
            this.leftPrefButton.BackColor = System.Drawing.Color.Red;
            this.leftPrefButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leftPrefButton.Location = new System.Drawing.Point(2, 48);
            this.leftPrefButton.Margin = new System.Windows.Forms.Padding(2);
            this.leftPrefButton.Name = "leftPrefButton";
            this.leftPrefButton.Size = new System.Drawing.Size(80, 43);
            this.leftPrefButton.TabIndex = 56;
            this.leftPrefButton.Text = "←";
            this.leftPrefButton.UseVisualStyleBackColor = false;
            this.leftPrefButton.Click += new System.EventHandler(this.leftPrefButton_Click);
            // 
            // capButton
            // 
            this.capButton.Location = new System.Drawing.Point(11, 38);
            this.capButton.Margin = new System.Windows.Forms.Padding(2);
            this.capButton.Name = "capButton";
            this.capButton.Size = new System.Drawing.Size(83, 21);
            this.capButton.TabIndex = 60;
            this.capButton.Text = "Start Camera";
            this.capButton.UseVisualStyleBackColor = true;
            this.capButton.Click += new System.EventHandler(this.capButton_Click);
            // 
            // rovPanel
            // 
            this.rovPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.rovPanel.AutoSize = true;
            this.rovPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.rovPanel.Controls.Add(this.topLeft);
            this.rovPanel.Controls.Add(this.botRight);
            this.rovPanel.Controls.Add(this.botLeft);
            this.rovPanel.Controls.Add(this.midRight);
            this.rovPanel.Controls.Add(this.topRight);
            this.rovPanel.Controls.Add(this.midLeft);
            this.rovPanel.Controls.Add(this.pictureBox1);
            this.rovPanel.Location = new System.Drawing.Point(1108, 398);
            this.rovPanel.Name = "rovPanel";
            this.rovPanel.Size = new System.Drawing.Size(238, 260);
            this.rovPanel.TabIndex = 64;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::GUI.Properties.Resources.rov_thrusters;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(238, 260);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 29;
            this.pictureBox1.TabStop = false;
            // 
            // RectangleCount
            // 
            this.RectangleCount.AutoSize = true;
            this.RectangleCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RectangleCount.Location = new System.Drawing.Point(172, 0);
            this.RectangleCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.RectangleCount.Name = "RectangleCount";
            this.RectangleCount.Size = new System.Drawing.Size(30, 29);
            this.RectangleCount.TabIndex = 56;
            this.RectangleCount.Text = "0";
            this.RectangleCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SquareCount
            // 
            this.SquareCount.AutoSize = true;
            this.SquareCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SquareCount.Location = new System.Drawing.Point(104, 0);
            this.SquareCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SquareCount.Name = "SquareCount";
            this.SquareCount.Size = new System.Drawing.Size(30, 29);
            this.SquareCount.TabIndex = 57;
            this.SquareCount.Text = "0";
            this.SquareCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CircleCount
            // 
            this.CircleCount.AutoSize = true;
            this.CircleCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CircleCount.Location = new System.Drawing.Point(240, 0);
            this.CircleCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.CircleCount.Name = "CircleCount";
            this.CircleCount.Size = new System.Drawing.Size(36, 29);
            this.CircleCount.TabIndex = 58;
            this.CircleCount.Text = " 0";
            this.CircleCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // triangleCount
            // 
            this.triangleCount.AutoSize = true;
            this.triangleCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.triangleCount.Location = new System.Drawing.Point(36, 0);
            this.triangleCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.triangleCount.Name = "triangleCount";
            this.triangleCount.Size = new System.Drawing.Size(30, 29);
            this.triangleCount.TabIndex = 53;
            this.triangleCount.Text = "0";
            this.triangleCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.Controls.Add(this.backPrefButton, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.leftPrefButton, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.rightPrefButton, 2, 1);
            this.tableLayoutPanel4.Controls.Add(this.forPrefButton, 1, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(520, 373);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(254, 93);
            this.tableLayoutPanel4.TabIndex = 67;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 8;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel2.Controls.Add(this.triangleCount, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.SquareCount, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.RectangleCount, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.CircleCount, 7, 0);
            this.tableLayoutPanel2.Controls.Add(this.pictureBox2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.pictureBox3, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.pictureBox4, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.pictureBox5, 6, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(195, 40);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(278, 29);
            this.tableLayoutPanel2.TabIndex = 69;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Image = global::GUI.Properties.Resources.triangle;
            this.pictureBox2.Location = new System.Drawing.Point(3, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(28, 23);
            this.pictureBox2.TabIndex = 59;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox3.Image = global::GUI.Properties.Resources.square;
            this.pictureBox3.Location = new System.Drawing.Point(71, 3);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(28, 23);
            this.pictureBox3.TabIndex = 60;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox4.Image = global::GUI.Properties.Resources.line;
            this.pictureBox4.Location = new System.Drawing.Point(139, 3);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(28, 23);
            this.pictureBox4.TabIndex = 61;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox5.Image = global::GUI.Properties.Resources.circle;
            this.pictureBox5.Location = new System.Drawing.Point(207, 3);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(28, 23);
            this.pictureBox5.TabIndex = 62;
            this.pictureBox5.TabStop = false;
            // 
            // pilotPanel
            // 
            this.pilotPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pilotPanel.Controls.Add(this.l9);
            this.pilotPanel.Controls.Add(this.l8);
            this.pilotPanel.Controls.Add(this.l7);
            this.pilotPanel.Controls.Add(this.l6);
            this.pilotPanel.Controls.Add(this.l5);
            this.pilotPanel.Controls.Add(this.l4);
            this.pilotPanel.Controls.Add(this.l3);
            this.pilotPanel.Controls.Add(this.l2);
            this.pilotPanel.Controls.Add(this.l1);
            this.pilotPanel.Controls.Add(this.pilotRightIndicator);
            this.pilotPanel.Controls.Add(this.pilotUpIndicator);
            this.pilotPanel.Controls.Add(this.pilotLeftIndicator);
            this.pilotPanel.Controls.Add(this.pilotDownIndicator);
            this.pilotPanel.Controls.Add(this.pilotBIndicator);
            this.pilotPanel.Controls.Add(this.pilotYIndicator);
            this.pilotPanel.Controls.Add(this.pilotXIndicator);
            this.pilotPanel.Controls.Add(this.pilotAIndicator);
            this.pilotPanel.Controls.Add(this.pilotRStickIndicator);
            this.pilotPanel.Controls.Add(this.pilotLStickIndicator);
            this.pilotPanel.Controls.Add(this.pilotRBumperIndicator);
            this.pilotPanel.Controls.Add(this.pilotRTriggerIndicator);
            this.pilotPanel.Controls.Add(this.pilotLBumperIndicator);
            this.pilotPanel.Controls.Add(this.pilotLTriggerIndicator);
            this.pilotPanel.Controls.Add(this.pictureBox6);
            this.pilotPanel.Location = new System.Drawing.Point(520, 472);
            this.pilotPanel.Name = "pilotPanel";
            this.pilotPanel.Size = new System.Drawing.Size(254, 174);
            this.pilotPanel.TabIndex = 71;
            // 
            // l9
            // 
            this.l9.AutoSize = true;
            this.l9.Location = new System.Drawing.Point(164, 55);
            this.l9.Name = "l9";
            this.l9.Size = new System.Drawing.Size(27, 13);
            this.l9.TabIndex = 93;
            this.l9.Text = "help";
            // 
            // l8
            // 
            this.l8.AutoSize = true;
            this.l8.Location = new System.Drawing.Point(3, 55);
            this.l8.Name = "l8";
            this.l8.Size = new System.Drawing.Size(111, 13);
            this.l8.TabIndex = 92;
            this.l8.Text = "Dpad - Direction Lock";
            // 
            // l7
            // 
            this.l7.AutoSize = true;
            this.l7.Location = new System.Drawing.Point(56, 93);
            this.l7.Name = "l7";
            this.l7.Size = new System.Drawing.Size(54, 13);
            this.l7.TabIndex = 91;
            this.l7.Text = "Horizontal";
            // 
            // l6
            // 
            this.l6.AutoSize = true;
            this.l6.Location = new System.Drawing.Point(141, 93);
            this.l6.Name = "l6";
            this.l6.Size = new System.Drawing.Size(73, 13);
            this.l6.TabIndex = 90;
            this.l6.Text = "Heading/Yaw";
            // 
            // l5
            // 
            this.l5.AutoSize = true;
            this.l5.Location = new System.Drawing.Point(200, 56);
            this.l5.Name = "l5";
            this.l5.Size = new System.Drawing.Size(56, 13);
            this.l5.TabIndex = 89;
            this.l5.Text = "Heading L";
            // 
            // l4
            // 
            this.l4.AutoSize = true;
            this.l4.Location = new System.Drawing.Point(162, 73);
            this.l4.Name = "l4";
            this.l4.Size = new System.Drawing.Size(52, 13);
            this.l4.TabIndex = 88;
            this.l4.Text = "Roll Lock";
            // 
            // l3
            // 
            this.l3.AutoSize = true;
            this.l3.Location = new System.Drawing.Point(179, 38);
            this.l3.Name = "l3";
            this.l3.Size = new System.Drawing.Size(63, 13);
            this.l3.TabIndex = 87;
            this.l3.Text = "Depth Lock";
            // 
            // l2
            // 
            this.l2.AutoSize = true;
            this.l2.Location = new System.Drawing.Point(179, 4);
            this.l2.Name = "l2";
            this.l2.Size = new System.Drawing.Size(47, 13);
            this.l2.TabIndex = 86;
            this.l2.Text = "ROV Up";
            // 
            // l1
            // 
            this.l1.AutoSize = true;
            this.l1.Location = new System.Drawing.Point(24, 8);
            this.l1.Name = "l1";
            this.l1.Size = new System.Drawing.Size(61, 13);
            this.l1.TabIndex = 85;
            this.l1.Text = "ROV Down";
            // 
            // pilotRightIndicator
            // 
            this.pilotRightIndicator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.pilotRightIndicator.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pilotRightIndicator.Location = new System.Drawing.Point(59, 55);
            this.pilotRightIndicator.Name = "pilotRightIndicator";
            this.pilotRightIndicator.Size = new System.Drawing.Size(17, 17);
            this.pilotRightIndicator.TabIndex = 84;
            this.pilotRightIndicator.UseVisualStyleBackColor = false;
            // 
            // pilotUpIndicator
            // 
            this.pilotUpIndicator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.pilotUpIndicator.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pilotUpIndicator.Location = new System.Drawing.Point(40, 38);
            this.pilotUpIndicator.Name = "pilotUpIndicator";
            this.pilotUpIndicator.Size = new System.Drawing.Size(17, 17);
            this.pilotUpIndicator.TabIndex = 83;
            this.pilotUpIndicator.UseVisualStyleBackColor = false;
            // 
            // pilotLeftIndicator
            // 
            this.pilotLeftIndicator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.pilotLeftIndicator.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pilotLeftIndicator.Location = new System.Drawing.Point(20, 54);
            this.pilotLeftIndicator.Name = "pilotLeftIndicator";
            this.pilotLeftIndicator.Size = new System.Drawing.Size(17, 17);
            this.pilotLeftIndicator.TabIndex = 82;
            this.pilotLeftIndicator.UseVisualStyleBackColor = false;
            // 
            // pilotDownIndicator
            // 
            this.pilotDownIndicator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.pilotDownIndicator.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pilotDownIndicator.Location = new System.Drawing.Point(41, 73);
            this.pilotDownIndicator.Name = "pilotDownIndicator";
            this.pilotDownIndicator.Size = new System.Drawing.Size(17, 17);
            this.pilotDownIndicator.TabIndex = 81;
            this.pilotDownIndicator.UseVisualStyleBackColor = false;
            // 
            // pilotBIndicator
            // 
            this.pilotBIndicator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.pilotBIndicator.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pilotBIndicator.Location = new System.Drawing.Point(216, 55);
            this.pilotBIndicator.Name = "pilotBIndicator";
            this.pilotBIndicator.Size = new System.Drawing.Size(17, 17);
            this.pilotBIndicator.TabIndex = 80;
            this.pilotBIndicator.UseVisualStyleBackColor = false;
            // 
            // pilotYIndicator
            // 
            this.pilotYIndicator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.pilotYIndicator.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pilotYIndicator.Location = new System.Drawing.Point(197, 38);
            this.pilotYIndicator.Name = "pilotYIndicator";
            this.pilotYIndicator.Size = new System.Drawing.Size(17, 17);
            this.pilotYIndicator.TabIndex = 79;
            this.pilotYIndicator.UseVisualStyleBackColor = false;
            // 
            // pilotXIndicator
            // 
            this.pilotXIndicator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.pilotXIndicator.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pilotXIndicator.Location = new System.Drawing.Point(177, 54);
            this.pilotXIndicator.Name = "pilotXIndicator";
            this.pilotXIndicator.Size = new System.Drawing.Size(17, 17);
            this.pilotXIndicator.TabIndex = 78;
            this.pilotXIndicator.UseVisualStyleBackColor = false;
            // 
            // pilotAIndicator
            // 
            this.pilotAIndicator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.pilotAIndicator.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pilotAIndicator.Location = new System.Drawing.Point(198, 73);
            this.pilotAIndicator.Name = "pilotAIndicator";
            this.pilotAIndicator.Size = new System.Drawing.Size(17, 17);
            this.pilotAIndicator.TabIndex = 77;
            this.pilotAIndicator.UseVisualStyleBackColor = false;
            // 
            // pilotRStickIndicator
            // 
            this.pilotRStickIndicator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.pilotRStickIndicator.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pilotRStickIndicator.Font = new System.Drawing.Font("Microsoft Sans Serif", 3.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pilotRStickIndicator.Location = new System.Drawing.Point(151, 81);
            this.pilotRStickIndicator.Name = "pilotRStickIndicator";
            this.pilotRStickIndicator.Size = new System.Drawing.Size(32, 27);
            this.pilotRStickIndicator.TabIndex = 76;
            this.pilotRStickIndicator.UseVisualStyleBackColor = false;
            // 
            // pilotLStickIndicator
            // 
            this.pilotLStickIndicator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.pilotLStickIndicator.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pilotLStickIndicator.Font = new System.Drawing.Font("Microsoft Sans Serif", 3.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pilotLStickIndicator.Location = new System.Drawing.Point(71, 81);
            this.pilotLStickIndicator.Name = "pilotLStickIndicator";
            this.pilotLStickIndicator.Size = new System.Drawing.Size(32, 27);
            this.pilotLStickIndicator.TabIndex = 75;
            this.pilotLStickIndicator.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.pilotLStickIndicator.UseVisualStyleBackColor = false;
            // 
            // pilotRBumperIndicator
            // 
            this.pilotRBumperIndicator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.pilotRBumperIndicator.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pilotRBumperIndicator.Location = new System.Drawing.Point(182, 19);
            this.pilotRBumperIndicator.Name = "pilotRBumperIndicator";
            this.pilotRBumperIndicator.Size = new System.Drawing.Size(43, 14);
            this.pilotRBumperIndicator.TabIndex = 74;
            this.pilotRBumperIndicator.UseVisualStyleBackColor = false;
            // 
            // pilotRTriggerIndicator
            // 
            this.pilotRTriggerIndicator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.pilotRTriggerIndicator.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pilotRTriggerIndicator.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pilotRTriggerIndicator.Location = new System.Drawing.Point(182, 0);
            this.pilotRTriggerIndicator.Name = "pilotRTriggerIndicator";
            this.pilotRTriggerIndicator.Size = new System.Drawing.Size(43, 18);
            this.pilotRTriggerIndicator.TabIndex = 73;
            this.pilotRTriggerIndicator.UseVisualStyleBackColor = false;
            // 
            // pilotLBumperIndicator
            // 
            this.pilotLBumperIndicator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.pilotLBumperIndicator.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pilotLBumperIndicator.Location = new System.Drawing.Point(32, 22);
            this.pilotLBumperIndicator.Name = "pilotLBumperIndicator";
            this.pilotLBumperIndicator.Size = new System.Drawing.Size(43, 14);
            this.pilotLBumperIndicator.TabIndex = 72;
            this.pilotLBumperIndicator.UseVisualStyleBackColor = false;
            // 
            // pilotLTriggerIndicator
            // 
            this.pilotLTriggerIndicator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.pilotLTriggerIndicator.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pilotLTriggerIndicator.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pilotLTriggerIndicator.Location = new System.Drawing.Point(32, 3);
            this.pilotLTriggerIndicator.Name = "pilotLTriggerIndicator";
            this.pilotLTriggerIndicator.Size = new System.Drawing.Size(43, 18);
            this.pilotLTriggerIndicator.TabIndex = 71;
            this.pilotLTriggerIndicator.UseVisualStyleBackColor = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox6.Image = global::GUI.Properties.Resources.controller;
            this.pictureBox6.Location = new System.Drawing.Point(0, 0);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(254, 174);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 70;
            this.pictureBox6.TabStop = false;
            // 
            // copilotPanel
            // 
            this.copilotPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.copilotPanel.Controls.Add(this.cl6);
            this.copilotPanel.Controls.Add(this.label6);
            this.copilotPanel.Controls.Add(this.cl3);
            this.copilotPanel.Controls.Add(this.cl5);
            this.copilotPanel.Controls.Add(this.cl4);
            this.copilotPanel.Controls.Add(this.cl2);
            this.copilotPanel.Controls.Add(this.cl1);
            this.copilotPanel.Controls.Add(this.copilotRightIndicator);
            this.copilotPanel.Controls.Add(this.copilotUpIndicator);
            this.copilotPanel.Controls.Add(this.copilotLeftIndicator);
            this.copilotPanel.Controls.Add(this.copilotDownIndicator);
            this.copilotPanel.Controls.Add(this.copilotBIndicator);
            this.copilotPanel.Controls.Add(this.copilotYIndicator);
            this.copilotPanel.Controls.Add(this.copilotXIndicator);
            this.copilotPanel.Controls.Add(this.copilotAIndicator);
            this.copilotPanel.Controls.Add(this.copilotRStickIndicator);
            this.copilotPanel.Controls.Add(this.copilotLStickIndicator);
            this.copilotPanel.Controls.Add(this.copilotRBumperIndicator);
            this.copilotPanel.Controls.Add(this.copilotRTriggerIndicator);
            this.copilotPanel.Controls.Add(this.copilotLBumperIndicator);
            this.copilotPanel.Controls.Add(this.copilotLTriggerIndicator);
            this.copilotPanel.Controls.Add(this.pictureBox7);
            this.copilotPanel.Location = new System.Drawing.Point(781, 472);
            this.copilotPanel.Name = "copilotPanel";
            this.copilotPanel.Size = new System.Drawing.Size(254, 174);
            this.copilotPanel.TabIndex = 85;
            // 
            // cl6
            // 
            this.cl6.AutoSize = true;
            this.cl6.Location = new System.Drawing.Point(167, 54);
            this.cl6.Name = "cl6";
            this.cl6.Size = new System.Drawing.Size(27, 13);
            this.cl6.TabIndex = 91;
            this.cl6.Text = "help";
            this.cl6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(103, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 13);
            this.label6.TabIndex = 90;
            // 
            // cl3
            // 
            this.cl3.AutoSize = true;
            this.cl3.Location = new System.Drawing.Point(182, 74);
            this.cl3.Name = "cl3";
            this.cl3.Size = new System.Drawing.Size(49, 13);
            this.cl3.TabIndex = 89;
            this.cl3.Text = "MiniROV";
            // 
            // cl5
            // 
            this.cl5.AutoSize = true;
            this.cl5.Location = new System.Drawing.Point(204, 56);
            this.cl5.Name = "cl5";
            this.cl5.Size = new System.Drawing.Size(52, 13);
            this.cl5.TabIndex = 88;
            this.cl5.Text = "Container";
            // 
            // cl4
            // 
            this.cl4.AutoSize = true;
            this.cl4.Location = new System.Drawing.Point(193, 38);
            this.cl4.Name = "cl4";
            this.cl4.Size = new System.Drawing.Size(30, 13);
            this.cl4.TabIndex = 87;
            this.cl4.Text = "Claw";
            // 
            // cl2
            // 
            this.cl2.AutoSize = true;
            this.cl2.Location = new System.Drawing.Point(56, 56);
            this.cl2.Name = "cl2";
            this.cl2.Size = new System.Drawing.Size(21, 13);
            this.cl2.TabIndex = 86;
            this.cl2.Text = "CV";
            // 
            // cl1
            // 
            this.cl1.AutoSize = true;
            this.cl1.Location = new System.Drawing.Point(17, 38);
            this.cl1.Name = "cl1";
            this.cl1.Size = new System.Drawing.Size(68, 13);
            this.cl1.TabIndex = 85;
            this.cl1.Text = "Start Camera";
            // 
            // copilotRightIndicator
            // 
            this.copilotRightIndicator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.copilotRightIndicator.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.copilotRightIndicator.Location = new System.Drawing.Point(59, 55);
            this.copilotRightIndicator.Name = "copilotRightIndicator";
            this.copilotRightIndicator.Size = new System.Drawing.Size(17, 17);
            this.copilotRightIndicator.TabIndex = 84;
            this.copilotRightIndicator.UseVisualStyleBackColor = false;
            // 
            // copilotUpIndicator
            // 
            this.copilotUpIndicator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.copilotUpIndicator.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.copilotUpIndicator.Location = new System.Drawing.Point(40, 38);
            this.copilotUpIndicator.Name = "copilotUpIndicator";
            this.copilotUpIndicator.Size = new System.Drawing.Size(17, 17);
            this.copilotUpIndicator.TabIndex = 83;
            this.copilotUpIndicator.UseVisualStyleBackColor = false;
            // 
            // copilotLeftIndicator
            // 
            this.copilotLeftIndicator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.copilotLeftIndicator.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.copilotLeftIndicator.Location = new System.Drawing.Point(20, 54);
            this.copilotLeftIndicator.Name = "copilotLeftIndicator";
            this.copilotLeftIndicator.Size = new System.Drawing.Size(17, 17);
            this.copilotLeftIndicator.TabIndex = 82;
            this.copilotLeftIndicator.UseVisualStyleBackColor = false;
            // 
            // copilotDownIndicator
            // 
            this.copilotDownIndicator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.copilotDownIndicator.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.copilotDownIndicator.Location = new System.Drawing.Point(41, 73);
            this.copilotDownIndicator.Name = "copilotDownIndicator";
            this.copilotDownIndicator.Size = new System.Drawing.Size(17, 17);
            this.copilotDownIndicator.TabIndex = 81;
            this.copilotDownIndicator.UseVisualStyleBackColor = false;
            // 
            // copilotBIndicator
            // 
            this.copilotBIndicator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.copilotBIndicator.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.copilotBIndicator.Location = new System.Drawing.Point(216, 55);
            this.copilotBIndicator.Name = "copilotBIndicator";
            this.copilotBIndicator.Size = new System.Drawing.Size(17, 17);
            this.copilotBIndicator.TabIndex = 80;
            this.copilotBIndicator.UseVisualStyleBackColor = false;
            // 
            // copilotYIndicator
            // 
            this.copilotYIndicator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.copilotYIndicator.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.copilotYIndicator.Location = new System.Drawing.Point(197, 38);
            this.copilotYIndicator.Name = "copilotYIndicator";
            this.copilotYIndicator.Size = new System.Drawing.Size(17, 17);
            this.copilotYIndicator.TabIndex = 79;
            this.copilotYIndicator.UseVisualStyleBackColor = false;
            // 
            // copilotXIndicator
            // 
            this.copilotXIndicator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.copilotXIndicator.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.copilotXIndicator.Location = new System.Drawing.Point(177, 54);
            this.copilotXIndicator.Name = "copilotXIndicator";
            this.copilotXIndicator.Size = new System.Drawing.Size(17, 17);
            this.copilotXIndicator.TabIndex = 78;
            this.copilotXIndicator.UseVisualStyleBackColor = false;
            // 
            // copilotAIndicator
            // 
            this.copilotAIndicator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.copilotAIndicator.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.copilotAIndicator.Location = new System.Drawing.Point(198, 73);
            this.copilotAIndicator.Name = "copilotAIndicator";
            this.copilotAIndicator.Size = new System.Drawing.Size(17, 17);
            this.copilotAIndicator.TabIndex = 77;
            this.copilotAIndicator.UseVisualStyleBackColor = false;
            // 
            // copilotRStickIndicator
            // 
            this.copilotRStickIndicator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.copilotRStickIndicator.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.copilotRStickIndicator.Font = new System.Drawing.Font("Microsoft Sans Serif", 3.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.copilotRStickIndicator.Location = new System.Drawing.Point(151, 81);
            this.copilotRStickIndicator.Name = "copilotRStickIndicator";
            this.copilotRStickIndicator.Size = new System.Drawing.Size(32, 27);
            this.copilotRStickIndicator.TabIndex = 76;
            this.copilotRStickIndicator.UseVisualStyleBackColor = false;
            // 
            // copilotLStickIndicator
            // 
            this.copilotLStickIndicator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.copilotLStickIndicator.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.copilotLStickIndicator.Font = new System.Drawing.Font("Microsoft Sans Serif", 3.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.copilotLStickIndicator.Location = new System.Drawing.Point(71, 81);
            this.copilotLStickIndicator.Name = "copilotLStickIndicator";
            this.copilotLStickIndicator.Size = new System.Drawing.Size(32, 27);
            this.copilotLStickIndicator.TabIndex = 75;
            this.copilotLStickIndicator.UseVisualStyleBackColor = false;
            // 
            // copilotRBumperIndicator
            // 
            this.copilotRBumperIndicator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.copilotRBumperIndicator.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.copilotRBumperIndicator.Location = new System.Drawing.Point(182, 19);
            this.copilotRBumperIndicator.Name = "copilotRBumperIndicator";
            this.copilotRBumperIndicator.Size = new System.Drawing.Size(43, 14);
            this.copilotRBumperIndicator.TabIndex = 74;
            this.copilotRBumperIndicator.UseVisualStyleBackColor = false;
            // 
            // copilotRTriggerIndicator
            // 
            this.copilotRTriggerIndicator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.copilotRTriggerIndicator.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.copilotRTriggerIndicator.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.copilotRTriggerIndicator.Location = new System.Drawing.Point(182, 0);
            this.copilotRTriggerIndicator.Name = "copilotRTriggerIndicator";
            this.copilotRTriggerIndicator.Size = new System.Drawing.Size(43, 18);
            this.copilotRTriggerIndicator.TabIndex = 73;
            this.copilotRTriggerIndicator.UseVisualStyleBackColor = false;
            // 
            // copilotLBumperIndicator
            // 
            this.copilotLBumperIndicator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.copilotLBumperIndicator.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.copilotLBumperIndicator.Location = new System.Drawing.Point(32, 22);
            this.copilotLBumperIndicator.Name = "copilotLBumperIndicator";
            this.copilotLBumperIndicator.Size = new System.Drawing.Size(43, 14);
            this.copilotLBumperIndicator.TabIndex = 72;
            this.copilotLBumperIndicator.UseVisualStyleBackColor = false;
            // 
            // copilotLTriggerIndicator
            // 
            this.copilotLTriggerIndicator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.copilotLTriggerIndicator.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.copilotLTriggerIndicator.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.copilotLTriggerIndicator.Location = new System.Drawing.Point(32, 3);
            this.copilotLTriggerIndicator.Name = "copilotLTriggerIndicator";
            this.copilotLTriggerIndicator.Size = new System.Drawing.Size(43, 18);
            this.copilotLTriggerIndicator.TabIndex = 71;
            this.copilotLTriggerIndicator.UseVisualStyleBackColor = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox7.Image = global::GUI.Properties.Resources.controller;
            this.pictureBox7.Location = new System.Drawing.Point(0, 0);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(254, 174);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 70;
            this.pictureBox7.TabStop = false;
            // 
            // CopilotConnectionLabel
            // 
            this.CopilotConnectionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CopilotConnectionLabel.AutoSize = true;
            this.CopilotConnectionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CopilotConnectionLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.CopilotConnectionLabel.Location = new System.Drawing.Point(797, 649);
            this.CopilotConnectionLabel.Name = "CopilotConnectionLabel";
            this.CopilotConnectionLabel.Size = new System.Drawing.Size(217, 15);
            this.CopilotConnectionLabel.TabIndex = 86;
            this.CopilotConnectionLabel.Text = "Copilot Controller Not Connected";
            this.CopilotConnectionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // headingLockEngageLabel
            // 
            this.headingLockEngageLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.headingLockEngageLabel.AutoSize = true;
            this.headingLockEngageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headingLockEngageLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.headingLockEngageLabel.Location = new System.Drawing.Point(1170, 24);
            this.headingLockEngageLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.headingLockEngageLabel.Name = "headingLockEngageLabel";
            this.headingLockEngageLabel.Size = new System.Drawing.Size(176, 15);
            this.headingLockEngageLabel.TabIndex = 89;
            this.headingLockEngageLabel.Text = "Heading Lock Disengaged";
            this.headingLockEngageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rollLockEngageLabel
            // 
            this.rollLockEngageLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rollLockEngageLabel.AutoSize = true;
            this.rollLockEngageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rollLockEngageLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.rollLockEngageLabel.Location = new System.Drawing.Point(1198, 41);
            this.rollLockEngageLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.rollLockEngageLabel.Name = "rollLockEngageLabel";
            this.rollLockEngageLabel.Size = new System.Drawing.Size(148, 15);
            this.rollLockEngageLabel.TabIndex = 90;
            this.rollLockEngageLabel.Text = "Roll Lock Disengaged";
            this.rollLockEngageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // containerPicture
            // 
            this.containerPicture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.containerPicture.Image = global::GUI.Properties.Resources.open_container;
            this.containerPicture.Location = new System.Drawing.Point(1108, 319);
            this.containerPicture.Name = "containerPicture";
            this.containerPicture.Size = new System.Drawing.Size(91, 74);
            this.containerPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.containerPicture.TabIndex = 88;
            this.containerPicture.TabStop = false;
            // 
            // clawPicture
            // 
            this.clawPicture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.clawPicture.Image = global::GUI.Properties.Resources.open_claw;
            this.clawPicture.Location = new System.Drawing.Point(1255, 318);
            this.clawPicture.Name = "clawPicture";
            this.clawPicture.Size = new System.Drawing.Size(91, 74);
            this.clawPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.clawPicture.TabIndex = 87;
            this.clawPicture.TabStop = false;
            // 
            // cvFinalImage
            // 
            this.cvFinalImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cvFinalImage.Location = new System.Drawing.Point(1108, 131);
            this.cvFinalImage.Name = "cvFinalImage";
            this.cvFinalImage.Size = new System.Drawing.Size(238, 181);
            this.cvFinalImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.cvFinalImage.TabIndex = 91;
            this.cvFinalImage.TabStop = false;
            // 
            // cvFinalProcessedImage
            // 
            this.cvFinalProcessedImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cvFinalProcessedImage.Location = new System.Drawing.Point(1108, -57);
            this.cvFinalProcessedImage.Name = "cvFinalProcessedImage";
            this.cvFinalProcessedImage.Size = new System.Drawing.Size(238, 182);
            this.cvFinalProcessedImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.cvFinalProcessedImage.TabIndex = 92;
            this.cvFinalProcessedImage.TabStop = false;
            // 
            // cameraFeed
            // 
            this.cameraFeed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cameraFeed.Location = new System.Drawing.Point(0, 0);
            this.cameraFeed.Name = "cameraFeed";
            this.cameraFeed.Size = new System.Drawing.Size(1358, 670);
            this.cameraFeed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.cameraFeed.TabIndex = 93;
            this.cameraFeed.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1358, 670);
            this.Controls.Add(this.cvFinalImage);
            this.Controls.Add(this.rollLockEngageLabel);
            this.Controls.Add(this.headingLockEngageLabel);
            this.Controls.Add(this.containerPicture);
            this.Controls.Add(this.clawPicture);
            this.Controls.Add(this.trackBar4);
            this.Controls.Add(this.trackBar2);
            this.Controls.Add(this.trackBar3);
            this.Controls.Add(this.CopilotConnectionLabel);
            this.Controls.Add(this.copilotPanel);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.pilotPanel);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.PilotConnectionLabel);
            this.Controls.Add(this.rovPanel);
            this.Controls.Add(this.tableLayoutPanel4);
            this.Controls.Add(this.cvButton);
            this.Controls.Add(this.capButton);
            this.Controls.Add(this.queueLabel);
            this.Controls.Add(this.depthLockEngageLabel);
            this.Controls.Add(this.armButton);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.portLabel);
            this.Controls.Add(this.cvFinalProcessedImage);
            this.Controls.Add(this.cameraFeed);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "TJROV - GUI";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar4)).EndInit();
            this.rovPanel.ResumeLayout(false);
            this.rovPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.pilotPanel.ResumeLayout(false);
            this.pilotPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            this.copilotPanel.ResumeLayout(false);
            this.copilotPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.containerPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clawPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cvFinalImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cvFinalProcessedImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cameraFeed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer500;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Label queueLabel;
        private System.Windows.Forms.Button armButton;
        private System.Windows.Forms.Label portLabel;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Label PilotConnectionLabel;
        private System.Windows.Forms.Timer controllerUpdateTimer;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label topLeft;
        private System.Windows.Forms.Label topRight;
        private System.Windows.Forms.Label midLeft;
        private System.Windows.Forms.Label midRight;
        private System.Windows.Forms.Label botLeft;
        private System.Windows.Forms.Label botRight;
        private PropulsionActuator propulsionActuator1;
        private PropulsionActuator propulsionActuator2;
        private System.Windows.Forms.Label depthLockEngageLabel;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.TrackBar trackBar3;
        private System.Windows.Forms.TrackBar trackBar4;
        private System.Windows.Forms.Button cvButton;
        private System.Windows.Forms.Button forPrefButton;
        private System.Windows.Forms.Button backPrefButton;
        private System.Windows.Forms.Button rightPrefButton;
        private System.Windows.Forms.Button leftPrefButton;
        private System.Windows.Forms.Button capButton;
        private System.Windows.Forms.Panel rovPanel;
        private System.Windows.Forms.Label SquareCount;
        private System.Windows.Forms.Label CircleCount;
        private System.Windows.Forms.Label RectangleCount;
        private System.Windows.Forms.Label triangleCount;

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Panel pilotPanel;
        private System.Windows.Forms.Button pilotRBumperIndicator;
        private System.Windows.Forms.Button pilotRTriggerIndicator;
        private System.Windows.Forms.Button pilotLBumperIndicator;
        private System.Windows.Forms.Button pilotLTriggerIndicator;
        private System.Windows.Forms.Button pilotRightIndicator;
        private System.Windows.Forms.Button pilotUpIndicator;
        private System.Windows.Forms.Button pilotLeftIndicator;
        private System.Windows.Forms.Button pilotDownIndicator;
        private System.Windows.Forms.Button pilotBIndicator;
        private System.Windows.Forms.Button pilotYIndicator;
        private System.Windows.Forms.Button pilotXIndicator;
        private System.Windows.Forms.Button pilotAIndicator;
        private System.Windows.Forms.Button pilotRStickIndicator;
        private System.Windows.Forms.Button pilotLStickIndicator;
        private System.Windows.Forms.Panel copilotPanel;
        private System.Windows.Forms.Button copilotRightIndicator;
        private System.Windows.Forms.Button copilotUpIndicator;
        private System.Windows.Forms.Button copilotLeftIndicator;
        private System.Windows.Forms.Button copilotDownIndicator;
        private System.Windows.Forms.Button copilotBIndicator;
        private System.Windows.Forms.Button copilotYIndicator;
        private System.Windows.Forms.Button copilotXIndicator;
        private System.Windows.Forms.Button copilotAIndicator;
        private System.Windows.Forms.Button copilotRStickIndicator;
        private System.Windows.Forms.Button copilotLStickIndicator;
        private System.Windows.Forms.Button copilotRBumperIndicator;
        private System.Windows.Forms.Button copilotRTriggerIndicator;
        private System.Windows.Forms.Button copilotLBumperIndicator;
        private System.Windows.Forms.Button copilotLTriggerIndicator;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Label CopilotConnectionLabel;
        private System.Windows.Forms.PictureBox clawPicture;
        private System.Windows.Forms.PictureBox containerPicture;
        private System.Windows.Forms.Label headingLockEngageLabel;
        private System.Windows.Forms.Label rollLockEngageLabel;
        private System.Windows.Forms.Label l1;
        private System.Windows.Forms.Label l4;
        private System.Windows.Forms.Label l3;
        private System.Windows.Forms.Label l2;
        private System.Windows.Forms.Label l9;
        private System.Windows.Forms.Label l8;
        private System.Windows.Forms.Label l7;
        private System.Windows.Forms.Label l6;
        private System.Windows.Forms.Label l5;
        private System.Windows.Forms.Label cl2;
        private System.Windows.Forms.Label cl1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label cl3;
        private System.Windows.Forms.Label cl5;
        private System.Windows.Forms.Label cl4;
        private System.Windows.Forms.Label cl6;
        private System.Windows.Forms.PictureBox cvFinalImage;
        private System.Windows.Forms.PictureBox cvFinalProcessedImage;
        private System.Windows.Forms.PictureBox cameraFeed;
    }
}

