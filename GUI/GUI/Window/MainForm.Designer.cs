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
            this.benthicButton = new System.Windows.Forms.Button();
            this.forPrefButton = new System.Windows.Forms.Button();
            this.backPrefButton = new System.Windows.Forms.Button();
            this.rightPrefButton = new System.Windows.Forms.Button();
            this.leftPrefButton = new System.Windows.Forms.Button();
            this.capButton = new System.Windows.Forms.Button();
            this.propulsionActuator1 = new GUI.PropulsionActuator();
            this.propulsionActuator2 = new GUI.PropulsionActuator();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.rovPanel = new System.Windows.Forms.Panel();
            this.RectangleCount = new System.Windows.Forms.Label();
            this.SquareCount = new System.Windows.Forms.Label();
            this.CircleCount = new System.Windows.Forms.Label();
            this.triangleCount = new System.Windows.Forms.Label();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.pilotPanel = new System.Windows.Forms.Panel();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.picture = new System.Windows.Forms.PictureBox();
            this.button18 = new System.Windows.Forms.Button();
            this.button19 = new System.Windows.Forms.Button();
            this.button20 = new System.Windows.Forms.Button();
            this.button21 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar4)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.rovPanel.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.pilotPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).BeginInit();
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
            this.connectButton.Click += new System.EventHandler(this.button1_Click);
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
            this.armButton.Click += new System.EventHandler(this.button2_Click);
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
            // ConnectionLabel
            // 
            this.ConnectionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ConnectionLabel.AutoSize = true;
            this.ConnectionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnectionLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.ConnectionLabel.Location = new System.Drawing.Point(1178, 30);
            this.ConnectionLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ConnectionLabel.Name = "ConnectionLabel";
            this.ConnectionLabel.Size = new System.Drawing.Size(168, 15);
            this.ConnectionLabel.TabIndex = 5;
            this.ConnectionLabel.Text = "Controller Not Connected";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(2, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Controller Buttons Pressed:";
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Location = new System.Drawing.Point(2, 32);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(200, 16);
            this.button1.TabIndex = 7;
            this.button1.Text = "N/A";
            // 
            // button2
            // 
            this.button2.AutoSize = true;
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.Location = new System.Drawing.Point(2, 48);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(200, 16);
            this.button2.TabIndex = 8;
            this.button2.Text = "N/A";
            // 
            // button3
            // 
            this.button3.AutoSize = true;
            this.button3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button3.Location = new System.Drawing.Point(2, 64);
            this.button3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(200, 16);
            this.button3.TabIndex = 9;
            this.button3.Text = "N/A";
            // 
            // button4
            // 
            this.button4.AutoSize = true;
            this.button4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button4.Location = new System.Drawing.Point(2, 80);
            this.button4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(200, 16);
            this.button4.TabIndex = 10;
            this.button4.Text = "N/A";
            // 
            // button5
            // 
            this.button5.AutoSize = true;
            this.button5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button5.Location = new System.Drawing.Point(2, 96);
            this.button5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(200, 16);
            this.button5.TabIndex = 11;
            this.button5.Text = "N/A";
            // 
            // button6
            // 
            this.button6.AutoSize = true;
            this.button6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button6.Location = new System.Drawing.Point(2, 112);
            this.button6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(200, 16);
            this.button6.TabIndex = 12;
            this.button6.Text = "N/A";
            // 
            // button7
            // 
            this.button7.AutoSize = true;
            this.button7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button7.Location = new System.Drawing.Point(2, 128);
            this.button7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(200, 16);
            this.button7.TabIndex = 13;
            this.button7.Text = "N/A";
            // 
            // button8
            // 
            this.button8.AutoSize = true;
            this.button8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button8.Location = new System.Drawing.Point(2, 144);
            this.button8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(200, 16);
            this.button8.TabIndex = 14;
            this.button8.Text = "N/A";
            // 
            // button16
            // 
            this.button16.AutoSize = true;
            this.button16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button16.Location = new System.Drawing.Point(2, 272);
            this.button16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(200, 16);
            this.button16.TabIndex = 17;
            this.button16.Text = "N/A";
            // 
            // button17
            // 
            this.button17.AutoSize = true;
            this.button17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button17.Location = new System.Drawing.Point(2, 288);
            this.button17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(200, 25);
            this.button17.TabIndex = 18;
            this.button17.Text = "N/A";
            // 
            // button0
            // 
            this.button0.AutoSize = true;
            this.button0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button0.Location = new System.Drawing.Point(2, 16);
            this.button0.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.button0.Name = "button0";
            this.button0.Size = new System.Drawing.Size(200, 16);
            this.button0.TabIndex = 19;
            this.button0.Text = "N/A";
            // 
            // button14
            // 
            this.button14.AutoSize = true;
            this.button14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button14.Location = new System.Drawing.Point(2, 240);
            this.button14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(200, 16);
            this.button14.TabIndex = 25;
            this.button14.Text = "N/A";
            // 
            // button13
            // 
            this.button13.AutoSize = true;
            this.button13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button13.Location = new System.Drawing.Point(2, 224);
            this.button13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(200, 16);
            this.button13.TabIndex = 24;
            this.button13.Text = "N/A";
            // 
            // button12
            // 
            this.button12.AutoSize = true;
            this.button12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button12.Location = new System.Drawing.Point(2, 208);
            this.button12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(200, 16);
            this.button12.TabIndex = 23;
            this.button12.Text = "N/A";
            // 
            // button11
            // 
            this.button11.AutoSize = true;
            this.button11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button11.Location = new System.Drawing.Point(2, 192);
            this.button11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(200, 16);
            this.button11.TabIndex = 22;
            this.button11.Text = "N/A";
            // 
            // button10
            // 
            this.button10.AutoSize = true;
            this.button10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button10.Location = new System.Drawing.Point(2, 176);
            this.button10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(200, 16);
            this.button10.TabIndex = 21;
            this.button10.Text = "N/A";
            // 
            // button9
            // 
            this.button9.AutoSize = true;
            this.button9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button9.Location = new System.Drawing.Point(2, 160);
            this.button9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(200, 16);
            this.button9.TabIndex = 20;
            this.button9.Text = "N/A";
            // 
            // button15
            // 
            this.button15.AutoSize = true;
            this.button15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button15.Location = new System.Drawing.Point(2, 256);
            this.button15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(200, 16);
            this.button15.TabIndex = 26;
            this.button15.Text = "N/A";
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
            // 
            // trackBar1
            // 
            this.trackBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar1.Location = new System.Drawing.Point(2, 2);
            this.trackBar1.Margin = new System.Windows.Forms.Padding(2);
            this.trackBar1.Maximum = 200;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar1.Size = new System.Drawing.Size(41, 15);
            this.trackBar1.TabIndex = 42;
            this.trackBar1.Value = 100;
            // 
            // trackBar2
            // 
            this.trackBar2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar2.Location = new System.Drawing.Point(47, 2);
            this.trackBar2.Margin = new System.Windows.Forms.Padding(2);
            this.trackBar2.Maximum = 200;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(42, 15);
            this.trackBar2.TabIndex = 43;
            this.trackBar2.Value = 108;
            // 
            // trackBar3
            // 
            this.trackBar3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar3.Location = new System.Drawing.Point(2, 21);
            this.trackBar3.Margin = new System.Windows.Forms.Padding(2);
            this.trackBar3.Maximum = 200;
            this.trackBar3.Name = "trackBar3";
            this.trackBar3.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar3.Size = new System.Drawing.Size(41, 15);
            this.trackBar3.TabIndex = 44;
            this.trackBar3.Value = 100;
            // 
            // trackBar4
            // 
            this.trackBar4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar4.Location = new System.Drawing.Point(47, 21);
            this.trackBar4.Margin = new System.Windows.Forms.Padding(2);
            this.trackBar4.Maximum = 200;
            this.trackBar4.Name = "trackBar4";
            this.trackBar4.Size = new System.Drawing.Size(42, 15);
            this.trackBar4.TabIndex = 45;
            this.trackBar4.Value = 100;
            // 
            // benthicButton
            // 
            this.benthicButton.Enabled = false;
            this.benthicButton.Location = new System.Drawing.Point(98, 40);
            this.benthicButton.Margin = new System.Windows.Forms.Padding(2);
            this.benthicButton.Name = "benthicButton";
            this.benthicButton.Size = new System.Drawing.Size(92, 19);
            this.benthicButton.TabIndex = 59;
            this.benthicButton.Text = "Find Organisms";
            this.benthicButton.UseMnemonic = false;
            this.benthicButton.UseVisualStyleBackColor = true;
            this.benthicButton.Click += new System.EventHandler(this.benthicButton_Click);
            // 
            // forPrefButton
            // 
            this.forPrefButton.BackColor = System.Drawing.Color.Green;
            this.forPrefButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.forPrefButton.Location = new System.Drawing.Point(32, 2);
            this.forPrefButton.Margin = new System.Windows.Forms.Padding(2);
            this.forPrefButton.Name = "forPrefButton";
            this.forPrefButton.Size = new System.Drawing.Size(26, 15);
            this.forPrefButton.TabIndex = 53;
            this.forPrefButton.Text = "↑";
            this.forPrefButton.UseVisualStyleBackColor = false;
            this.forPrefButton.Click += new System.EventHandler(this.forPrefButton_Click);
            // 
            // backPrefButton
            // 
            this.backPrefButton.BackColor = System.Drawing.Color.Red;
            this.backPrefButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.backPrefButton.Location = new System.Drawing.Point(32, 21);
            this.backPrefButton.Margin = new System.Windows.Forms.Padding(2);
            this.backPrefButton.Name = "backPrefButton";
            this.backPrefButton.Size = new System.Drawing.Size(26, 15);
            this.backPrefButton.TabIndex = 54;
            this.backPrefButton.Text = "↓";
            this.backPrefButton.UseVisualStyleBackColor = false;
            this.backPrefButton.Click += new System.EventHandler(this.backPrefButton_Click);
            // 
            // rightPrefButton
            // 
            this.rightPrefButton.BackColor = System.Drawing.Color.Red;
            this.rightPrefButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightPrefButton.Location = new System.Drawing.Point(62, 21);
            this.rightPrefButton.Margin = new System.Windows.Forms.Padding(2);
            this.rightPrefButton.Name = "rightPrefButton";
            this.rightPrefButton.Size = new System.Drawing.Size(27, 15);
            this.rightPrefButton.TabIndex = 55;
            this.rightPrefButton.Text = "→";
            this.rightPrefButton.UseVisualStyleBackColor = false;
            this.rightPrefButton.Click += new System.EventHandler(this.rightPrefButton_Click);
            // 
            // leftPrefButton
            // 
            this.leftPrefButton.BackColor = System.Drawing.Color.Red;
            this.leftPrefButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leftPrefButton.Location = new System.Drawing.Point(2, 21);
            this.leftPrefButton.Margin = new System.Windows.Forms.Padding(2);
            this.leftPrefButton.Name = "leftPrefButton";
            this.leftPrefButton.Size = new System.Drawing.Size(26, 15);
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
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.button17, 0, 18);
            this.tableLayoutPanel1.Controls.Add(this.button16, 0, 17);
            this.tableLayoutPanel1.Controls.Add(this.button15, 0, 16);
            this.tableLayoutPanel1.Controls.Add(this.button14, 0, 15);
            this.tableLayoutPanel1.Controls.Add(this.button13, 0, 14);
            this.tableLayoutPanel1.Controls.Add(this.button12, 0, 13);
            this.tableLayoutPanel1.Controls.Add(this.button11, 0, 12);
            this.tableLayoutPanel1.Controls.Add(this.button10, 0, 11);
            this.tableLayoutPanel1.Controls.Add(this.button9, 0, 10);
            this.tableLayoutPanel1.Controls.Add(this.button8, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.button7, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.button6, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.button5, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.button4, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.button3, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.button2, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.button1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.button0, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(1142, 74);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 19;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.263157F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.263157F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.263157F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.263157F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.263157F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.263157F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.263157F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.263157F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.263157F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.263157F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.263157F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.263157F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.263157F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.263157F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.263157F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.263157F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.263157F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.263157F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.263157F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(204, 313);
            this.tableLayoutPanel1.TabIndex = 0;
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
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel4.Controls.Add(this.backPrefButton, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.leftPrefButton, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.rightPrefButton, 2, 1);
            this.tableLayoutPanel4.Controls.Add(this.forPrefButton, 1, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(192, 103);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(91, 38);
            this.tableLayoutPanel4.TabIndex = 67;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Controls.Add(this.trackBar3, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.trackBar2, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.trackBar1, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.trackBar4, 1, 1);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(57, 106);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(91, 38);
            this.tableLayoutPanel5.TabIndex = 68;
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
            // pilotPanel
            // 
            this.pilotPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pilotPanel.Controls.Add(this.button20);
            this.pilotPanel.Controls.Add(this.button21);
            this.pilotPanel.Controls.Add(this.button19);
            this.pilotPanel.Controls.Add(this.button18);
            this.pilotPanel.Controls.Add(this.pictureBox6);
            this.pilotPanel.Location = new System.Drawing.Point(500, 427);
            this.pilotPanel.Name = "pilotPanel";
            this.pilotPanel.Size = new System.Drawing.Size(254, 174);
            this.pilotPanel.TabIndex = 71;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox6.Image = global::GUI.Properties.Resources.ps4controller;
            this.pictureBox6.Location = new System.Drawing.Point(0, 0);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(254, 174);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 70;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
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
            this.pictureBox5.Location = new System.Drawing.Point(207, 3);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(28, 23);
            this.pictureBox5.TabIndex = 62;
            this.pictureBox5.TabStop = false;
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
            // picture
            // 
            this.picture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picture.Location = new System.Drawing.Point(0, 0);
            this.picture.Margin = new System.Windows.Forms.Padding(2);
            this.picture.Name = "picture";
            this.picture.Size = new System.Drawing.Size(1358, 670);
            this.picture.TabIndex = 63;
            this.picture.TabStop = false;
            this.picture.Visible = false;
            // 
            // button18
            // 
            this.button18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button18.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button18.Location = new System.Drawing.Point(32, 3);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(43, 14);
            this.button18.TabIndex = 71;
            this.button18.UseVisualStyleBackColor = false;
            // 
            // button19
            // 
            this.button19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button19.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button19.Location = new System.Drawing.Point(32, 19);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(43, 14);
            this.button19.TabIndex = 72;
            this.button19.UseVisualStyleBackColor = false;
            // 
            // button20
            // 
            this.button20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button20.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button20.Location = new System.Drawing.Point(182, 16);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(43, 14);
            this.button20.TabIndex = 74;
            this.button20.UseVisualStyleBackColor = false;
            // 
            // button21
            // 
            this.button21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button21.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button21.Location = new System.Drawing.Point(182, 0);
            this.button21.Name = "button21";
            this.button21.Size = new System.Drawing.Size(43, 14);
            this.button21.TabIndex = 73;
            this.button21.UseVisualStyleBackColor = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1358, 670);
            this.Controls.Add(this.pilotPanel);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.ConnectionLabel);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.rovPanel);
            this.Controls.Add(this.tableLayoutPanel4);
            this.Controls.Add(this.tableLayoutPanel5);
            this.Controls.Add(this.benthicButton);
            this.Controls.Add(this.capButton);
            this.Controls.Add(this.queueLabel);
            this.Controls.Add(this.depthLockEngageLabel);
            this.Controls.Add(this.armButton);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.portLabel);
            this.Controls.Add(this.picture);
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
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.rovPanel.ResumeLayout(false);
            this.rovPanel.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.pilotPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).EndInit();
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
        private System.Windows.Forms.Button benthicButton;
        private System.Windows.Forms.Button forPrefButton;
        private System.Windows.Forms.Button backPrefButton;
        private System.Windows.Forms.Button rightPrefButton;
        private System.Windows.Forms.Button leftPrefButton;
        private System.Windows.Forms.Button capButton;
        private System.Windows.Forms.PictureBox picture;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel rovPanel;
        private System.Windows.Forms.Label SquareCount;
        private System.Windows.Forms.Label CircleCount;
        private System.Windows.Forms.Label RectangleCount;
        private System.Windows.Forms.Label triangleCount;

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Panel pilotPanel;
        private System.Windows.Forms.Button button20;
        private System.Windows.Forms.Button button21;
        private System.Windows.Forms.Button button19;
        private System.Windows.Forms.Button button18;
    }
}

