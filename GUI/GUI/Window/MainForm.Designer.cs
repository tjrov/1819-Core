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
            this.ConnectionLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Label();
            this.button8 = new System.Windows.Forms.Label();
            this.button16 = new System.Windows.Forms.Label();
            this.button17 = new System.Windows.Forms.Label();
            this.button0 = new System.Windows.Forms.Label();
            this.button14 = new System.Windows.Forms.Label();
            this.button13 = new System.Windows.Forms.Label();
            this.button12 = new System.Windows.Forms.Label();
            this.button11 = new System.Windows.Forms.Label();
            this.button10 = new System.Windows.Forms.Label();
            this.button9 = new System.Windows.Forms.Label();
            this.button15 = new System.Windows.Forms.Label();
            this.ConnectionB = new System.Windows.Forms.Button();
            this.controllerUpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.topLeft = new System.Windows.Forms.Label();
            this.topRight = new System.Windows.Forms.Label();
            this.midLeft = new System.Windows.Forms.Label();
            this.midRight = new System.Windows.Forms.Label();
            this.botLeft = new System.Windows.Forms.Label();
            this.botRight = new System.Windows.Forms.Label();
            this.depthLockButton = new System.Windows.Forms.Button();
            this.propulsionActuator1 = new GUI.PropulsionActuator();
            this.propulsionActuator2 = new GUI.PropulsionActuator();
            this.depthLockEngageLabel = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.trackBar3 = new System.Windows.Forms.TrackBar();
            this.trackBar4 = new System.Windows.Forms.TrackBar();
            this.LengthOfBarrel = new System.Windows.Forms.TextBox();
            this.InnerRadius1 = new System.Windows.Forms.TextBox();
            this.InnerRadius3 = new System.Windows.Forms.TextBox();
            this.calcButton = new System.Windows.Forms.Button();
            this.answerBox = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar4)).BeginInit();
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
            this.connectButton.Location = new System.Drawing.Point(12, 12);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(156, 42);
            this.connectButton.TabIndex = 0;
            this.connectButton.Text = "Disconnected";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // queueLabel
            // 
            this.queueLabel.AutoSize = true;
            this.queueLabel.Location = new System.Drawing.Point(250, 20);
            this.queueLabel.Name = "queueLabel";
            this.queueLabel.Size = new System.Drawing.Size(153, 25);
            this.queueLabel.TabIndex = 1;
            this.queueLabel.Text = "Queue length: ";
            // 
            // armButton
            // 
            this.armButton.AutoSize = true;
            this.armButton.Location = new System.Drawing.Point(12, 59);
            this.armButton.Name = "armButton";
            this.armButton.Size = new System.Drawing.Size(94, 42);
            this.armButton.TabIndex = 2;
            this.armButton.Text = "Arm";
            this.armButton.UseVisualStyleBackColor = true;
            this.armButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // portLabel
            // 
            this.portLabel.AutoSize = true;
            this.portLabel.Location = new System.Drawing.Point(174, 20);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(0, 25);
            this.portLabel.TabIndex = 3;
            // 
            // resetButton
            // 
            this.resetButton.AutoSize = true;
            this.resetButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.resetButton.Location = new System.Drawing.Point(112, 61);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(78, 35);
            this.resetButton.TabIndex = 4;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // ConnectionLabel
            // 
            this.ConnectionLabel.AutoSize = true;
            this.ConnectionLabel.Location = new System.Drawing.Point(12, 111);
            this.ConnectionLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ConnectionLabel.Name = "ConnectionLabel";
            this.ConnectionLabel.Size = new System.Drawing.Size(280, 25);
            this.ConnectionLabel.TabIndex = 5;
            this.ConnectionLabel.Text = "Controller Connected: False";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1533, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(275, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "Controller Buttons Pressed:";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.AutoSize = true;
            this.button1.Location = new System.Drawing.Point(1600, 70);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(47, 25);
            this.button1.TabIndex = 7;
            this.button1.Text = "N/A";
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.AutoSize = true;
            this.button2.Location = new System.Drawing.Point(1600, 97);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(47, 25);
            this.button2.TabIndex = 8;
            this.button2.Text = "N/A";
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.AutoSize = true;
            this.button3.Location = new System.Drawing.Point(1600, 127);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(47, 25);
            this.button3.TabIndex = 9;
            this.button3.Text = "N/A";
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.AutoSize = true;
            this.button4.Location = new System.Drawing.Point(1600, 153);
            this.button4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(47, 25);
            this.button4.TabIndex = 10;
            this.button4.Text = "N/A";
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button5.AutoSize = true;
            this.button5.Location = new System.Drawing.Point(1600, 180);
            this.button5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(47, 25);
            this.button5.TabIndex = 11;
            this.button5.Text = "N/A";
            // 
            // button6
            // 
            this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button6.AutoSize = true;
            this.button6.Location = new System.Drawing.Point(1600, 206);
            this.button6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(47, 25);
            this.button6.TabIndex = 12;
            this.button6.Text = "N/A";
            // 
            // button7
            // 
            this.button7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button7.AutoSize = true;
            this.button7.Location = new System.Drawing.Point(1600, 233);
            this.button7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(47, 25);
            this.button7.TabIndex = 13;
            this.button7.Text = "N/A";
            // 
            // button8
            // 
            this.button8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button8.AutoSize = true;
            this.button8.Location = new System.Drawing.Point(1600, 259);
            this.button8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(47, 25);
            this.button8.TabIndex = 14;
            this.button8.Text = "N/A";
            // 
            // button16
            // 
            this.button16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button16.AutoSize = true;
            this.button16.Location = new System.Drawing.Point(1600, 473);
            this.button16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(47, 25);
            this.button16.TabIndex = 17;
            this.button16.Text = "N/A";
            // 
            // button17
            // 
            this.button17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button17.AutoSize = true;
            this.button17.Location = new System.Drawing.Point(1600, 498);
            this.button17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(47, 25);
            this.button17.TabIndex = 18;
            this.button17.Text = "N/A";
            // 
            // button0
            // 
            this.button0.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button0.AutoSize = true;
            this.button0.Location = new System.Drawing.Point(1600, 45);
            this.button0.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.button0.Name = "button0";
            this.button0.Size = new System.Drawing.Size(47, 25);
            this.button0.TabIndex = 19;
            this.button0.Text = "N/A";
            // 
            // button14
            // 
            this.button14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button14.AutoSize = true;
            this.button14.Location = new System.Drawing.Point(1600, 422);
            this.button14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(47, 25);
            this.button14.TabIndex = 25;
            this.button14.Text = "N/A";
            // 
            // button13
            // 
            this.button13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button13.AutoSize = true;
            this.button13.Location = new System.Drawing.Point(1600, 395);
            this.button13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(47, 25);
            this.button13.TabIndex = 24;
            this.button13.Text = "N/A";
            // 
            // button12
            // 
            this.button12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button12.AutoSize = true;
            this.button12.Location = new System.Drawing.Point(1600, 369);
            this.button12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(47, 25);
            this.button12.TabIndex = 23;
            this.button12.Text = "N/A";
            // 
            // button11
            // 
            this.button11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button11.AutoSize = true;
            this.button11.Location = new System.Drawing.Point(1600, 342);
            this.button11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(47, 25);
            this.button11.TabIndex = 22;
            this.button11.Text = "N/A";
            // 
            // button10
            // 
            this.button10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button10.AutoSize = true;
            this.button10.Location = new System.Drawing.Point(1600, 316);
            this.button10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(47, 25);
            this.button10.TabIndex = 21;
            this.button10.Text = "N/A";
            // 
            // button9
            // 
            this.button9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button9.AutoSize = true;
            this.button9.Location = new System.Drawing.Point(1600, 289);
            this.button9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(47, 25);
            this.button9.TabIndex = 20;
            this.button9.Text = "N/A";
            // 
            // button15
            // 
            this.button15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button15.AutoSize = true;
            this.button15.Location = new System.Drawing.Point(1600, 448);
            this.button15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(47, 25);
            this.button15.TabIndex = 26;
            this.button15.Text = "N/A";
            // 
            // ConnectionB
            // 
            this.ConnectionB.BackColor = System.Drawing.Color.DarkRed;
            this.ConnectionB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ConnectionB.Location = new System.Drawing.Point(297, 111);
            this.ConnectionB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ConnectionB.Name = "ConnectionB";
            this.ConnectionB.Size = new System.Drawing.Size(112, 36);
            this.ConnectionB.TabIndex = 27;
            this.ConnectionB.UseVisualStyleBackColor = false;
            // 
            // controllerUpdateTimer
            // 
            this.controllerUpdateTimer.Enabled = true;
            this.controllerUpdateTimer.Interval = 5;
            this.controllerUpdateTimer.Tick += new System.EventHandler(this.controllerUpdateTimer_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox1.Image = global::GUI.Properties.Resources.rov_thrusters;
            this.pictureBox1.InitialImage = global::GUI.Properties.Resources.rov_thrusters;
            this.pictureBox1.Location = new System.Drawing.Point(0, 367);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(874, 873);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 29;
            this.pictureBox1.TabStop = false;
            // 
            // topLeft
            // 
            this.topLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.topLeft.AutoSize = true;
            this.topLeft.Location = new System.Drawing.Point(164, 530);
            this.topLeft.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.topLeft.Name = "topLeft";
            this.topLeft.Size = new System.Drawing.Size(47, 25);
            this.topLeft.TabIndex = 30;
            this.topLeft.Text = "N/A";
            // 
            // topRight
            // 
            this.topRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.topRight.AutoSize = true;
            this.topRight.Location = new System.Drawing.Point(668, 530);
            this.topRight.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.topRight.Name = "topRight";
            this.topRight.Size = new System.Drawing.Size(47, 25);
            this.topRight.TabIndex = 31;
            this.topRight.Text = "N/A";
            // 
            // midLeft
            // 
            this.midLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.midLeft.AutoSize = true;
            this.midLeft.Location = new System.Drawing.Point(164, 789);
            this.midLeft.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.midLeft.Name = "midLeft";
            this.midLeft.Size = new System.Drawing.Size(47, 25);
            this.midLeft.TabIndex = 32;
            this.midLeft.Text = "N/A";
            // 
            // midRight
            // 
            this.midRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.midRight.AutoSize = true;
            this.midRight.Location = new System.Drawing.Point(668, 789);
            this.midRight.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.midRight.Name = "midRight";
            this.midRight.Size = new System.Drawing.Size(47, 25);
            this.midRight.TabIndex = 33;
            this.midRight.Text = "N/A";
            // 
            // botLeft
            // 
            this.botLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.botLeft.AutoSize = true;
            this.botLeft.Location = new System.Drawing.Point(174, 1077);
            this.botLeft.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.botLeft.Name = "botLeft";
            this.botLeft.Size = new System.Drawing.Size(47, 25);
            this.botLeft.TabIndex = 34;
            this.botLeft.Text = "N/A";
            // 
            // botRight
            // 
            this.botRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.botRight.AutoSize = true;
            this.botRight.Location = new System.Drawing.Point(668, 1077);
            this.botRight.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.botRight.Name = "botRight";
            this.botRight.Size = new System.Drawing.Size(47, 25);
            this.botRight.TabIndex = 35;
            this.botRight.Text = "N/A";
            // 
            // depthLockButton
            // 
            this.depthLockButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.depthLockButton.BackColor = System.Drawing.Color.Red;
            this.depthLockButton.Location = new System.Drawing.Point(1605, 1173);
            this.depthLockButton.Name = "depthLockButton";
            this.depthLockButton.Size = new System.Drawing.Size(122, 55);
            this.depthLockButton.TabIndex = 36;
            this.depthLockButton.UseVisualStyleBackColor = false;
            // 
            // depthLockEngageLabel
            // 
            this.depthLockEngageLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.depthLockEngageLabel.AutoSize = true;
            this.depthLockEngageLabel.Location = new System.Drawing.Point(1472, 1187);
            this.depthLockEngageLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.depthLockEngageLabel.Name = "depthLockEngageLabel";
            this.depthLockEngageLabel.Size = new System.Drawing.Size(127, 25);
            this.depthLockEngageLabel.TabIndex = 41;
            this.depthLockEngageLabel.Text = "Depth Lock:";
            // 
            // trackBar1
            // 
            this.trackBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar1.Location = new System.Drawing.Point(1718, 566);
            this.trackBar1.Maximum = 200;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar1.Size = new System.Drawing.Size(90, 271);
            this.trackBar1.TabIndex = 42;
            this.trackBar1.Value = 100;
            // 
            // trackBar2
            // 
            this.trackBar2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar2.Location = new System.Drawing.Point(1412, 657);
            this.trackBar2.Maximum = 200;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(271, 90);
            this.trackBar2.TabIndex = 43;
            this.trackBar2.Value = 108;
            // 
            // trackBar3
            // 
            this.trackBar3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar3.Location = new System.Drawing.Point(1718, 843);
            this.trackBar3.Maximum = 200;
            this.trackBar3.Name = "trackBar3";
            this.trackBar3.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar3.Size = new System.Drawing.Size(90, 271);
            this.trackBar3.TabIndex = 44;
            this.trackBar3.Value = 100;
            // 
            // trackBar4
            // 
            this.trackBar4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar4.Location = new System.Drawing.Point(1412, 910);
            this.trackBar4.Maximum = 200;
            this.trackBar4.Name = "trackBar4";
            this.trackBar4.Size = new System.Drawing.Size(271, 90);
            this.trackBar4.TabIndex = 45;
            this.trackBar4.Value = 100;
            // 
            // LengthOfBarrel
            // 
            this.LengthOfBarrel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LengthOfBarrel.Location = new System.Drawing.Point(925, 1113);
            this.LengthOfBarrel.Name = "LengthOfBarrel";
            this.LengthOfBarrel.Size = new System.Drawing.Size(216, 31);
            this.LengthOfBarrel.TabIndex = 46;
            this.LengthOfBarrel.Text = "Length of Barrel";
            // 
            // InnerRadius1
            // 
            this.InnerRadius1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.InnerRadius1.Location = new System.Drawing.Point(925, 1150);
            this.InnerRadius1.Name = "InnerRadius1";
            this.InnerRadius1.Size = new System.Drawing.Size(216, 31);
            this.InnerRadius1.TabIndex = 47;
            this.InnerRadius1.Text = "Inner Radius 1";
            // 
            // InnerRadius3
            // 
            this.InnerRadius3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.InnerRadius3.Location = new System.Drawing.Point(925, 1222);
            this.InnerRadius3.Name = "InnerRadius3";
            this.InnerRadius3.Size = new System.Drawing.Size(216, 31);
            this.InnerRadius3.TabIndex = 49;
            this.InnerRadius3.Text = "Inner Radius 3";
            // 
            // calcButton
            // 
            this.calcButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.calcButton.Location = new System.Drawing.Point(1179, 1194);
            this.calcButton.Name = "calcButton";
            this.calcButton.Size = new System.Drawing.Size(137, 72);
            this.calcButton.TabIndex = 50;
            this.calcButton.Text = "Calculate";
            this.calcButton.UseVisualStyleBackColor = true;
            this.calcButton.Click += new System.EventHandler(this.button18_Click);
            // 
            // answerBox
            // 
            this.answerBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.answerBox.Location = new System.Drawing.Point(1335, 1215);
            this.answerBox.Name = "answerBox";
            this.answerBox.Size = new System.Drawing.Size(100, 31);
            this.answerBox.TabIndex = 51;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(925, 1185);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(216, 31);
            this.textBox1.TabIndex = 52;
            this.textBox1.Text = "Inner Radius 2";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1822, 1294);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.answerBox);
            this.Controls.Add(this.calcButton);
            this.Controls.Add(this.InnerRadius3);
            this.Controls.Add(this.InnerRadius1);
            this.Controls.Add(this.LengthOfBarrel);
            this.Controls.Add(this.trackBar4);
            this.Controls.Add(this.trackBar3);
            this.Controls.Add(this.trackBar2);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.depthLockEngageLabel);
            this.Controls.Add(this.depthLockButton);
            this.Controls.Add(this.botRight);
            this.Controls.Add(this.botLeft);
            this.Controls.Add(this.midRight);
            this.Controls.Add(this.midLeft);
            this.Controls.Add(this.topRight);
            this.Controls.Add(this.topLeft);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.ConnectionB);
            this.Controls.Add(this.button15);
            this.Controls.Add(this.button14);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button0);
            this.Controls.Add(this.button17);
            this.Controls.Add(this.button16);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ConnectionLabel);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.portLabel);
            this.Controls.Add(this.armButton);
            this.Controls.Add(this.queueLabel);
            this.Controls.Add(this.connectButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.Text = "TJROV - GUI";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar4)).EndInit();
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
        private System.Windows.Forms.Label ConnectionLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label button1;
        private System.Windows.Forms.Label button2;
        private System.Windows.Forms.Label button3;
        private System.Windows.Forms.Label button4;
        private System.Windows.Forms.Label button5;
        private System.Windows.Forms.Label button6;
        private System.Windows.Forms.Label button7;
        private System.Windows.Forms.Label button8;
        private System.Windows.Forms.Label button16;
        private System.Windows.Forms.Label button17;
        private System.Windows.Forms.Label button0;
        private System.Windows.Forms.Label button14;
        private System.Windows.Forms.Label button13;
        private System.Windows.Forms.Label button12;
        private System.Windows.Forms.Label button11;
        private System.Windows.Forms.Label button10;
        private System.Windows.Forms.Label button9;
        private System.Windows.Forms.Label button15;
        private System.Windows.Forms.Button ConnectionB;
        private System.Windows.Forms.Timer controllerUpdateTimer;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label topLeft;
        private System.Windows.Forms.Label topRight;
        private System.Windows.Forms.Label midLeft;
        private System.Windows.Forms.Label midRight;
        private System.Windows.Forms.Label botLeft;
        private System.Windows.Forms.Label botRight;
        private System.Windows.Forms.Button depthLockButton;
        private PropulsionActuator propulsionActuator1;
        private PropulsionActuator propulsionActuator2;
        private System.Windows.Forms.Label depthLockEngageLabel;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.TrackBar trackBar3;
        private System.Windows.Forms.TrackBar trackBar4;
        private System.Windows.Forms.TextBox LengthOfBarrel;
        private System.Windows.Forms.TextBox InnerRadius1;
        private System.Windows.Forms.TextBox InnerRadius3;
        private System.Windows.Forms.Button calcButton;
        private System.Windows.Forms.TextBox answerBox;
        private System.Windows.Forms.TextBox textBox1;
    }
}

