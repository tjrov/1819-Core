/*namespace ControlStation
{
    partial class ControlStationInterface
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
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ControlStationInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1213, 646);
            this.Name = "ControlStationInterface";
            this.Text = "ROV Interface";
            this.Load += new System.EventHandler(this.ControlStationInterface_Load);
            this.ResumeLayout(false);

            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlStationInterface));
            this.comBox = new System.Windows.Forms.TextBox();
            this.comNameLabel = new System.Windows.Forms.Label();
            this.newPortButton = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.rpmNameLabel = new System.Windows.Forms.Label();
            this.speedNameLabel = new System.Windows.Forms.Label();
            this.accelNameLabel = new System.Windows.Forms.Label();
            this.maniOneNameLabel = new System.Windows.Forms.Label();
            this.maniTwoLabel = new System.Windows.Forms.Label();
            this.maniThreeLabel = new System.Windows.Forms.Label();
            this.maniFourLabel = new System.Windows.Forms.Label();
            this.voltNameLabel = new System.Windows.Forms.Label();
            this.voltBar = new System.Windows.Forms.TextBox();
            this.motorBar = new System.Windows.Forms.TextBox();
            this.speedBar = new System.Windows.Forms.TextBox();
            this.accelBar = new System.Windows.Forms.TextBox();
            this.maniOneBar = new System.Windows.Forms.TextBox();
            this.maniTwoBar = new System.Windows.Forms.TextBox();
            this.maniThreeBar = new System.Windows.Forms.TextBox();
            this.maniFourBar = new System.Windows.Forms.TextBox();
            this.robotDiagram = new System.Windows.Forms.GroupBox();
            this.coPilotBox = new System.Windows.Forms.GroupBox();
            this.pilotBox = new System.Windows.Forms.GroupBox();
            this.horizontalLabel = new System.Windows.Forms.Label();
            this.verticalLabel = new System.Windows.Forms.Label();
            this.recordHorizontalBtn = new System.Windows.Forms.Button();
            this.verticalRecordBtn = new System.Windows.Forms.Button();
            this.horizontalDistanceLabel = new System.Windows.Forms.Label();
            this.verticalDistanceLabel = new System.Windows.Forms.Label();
            this.clickyBoi = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comBox
            // 
            this.comBox.Location = new System.Drawing.Point(91, 587);
            this.comBox.Name = "comBox";
            this.comBox.Size = new System.Drawing.Size(801, 22);
            this.comBox.TabIndex = 2;
            this.comBox.Text = "COM 3";
            // 
            // comNameLabel
            // 
            this.comNameLabel.AutoSize = true;
            this.comNameLabel.Location = new System.Drawing.Point(16, 590);
            this.comNameLabel.Name = "comNameLabel";
            this.comNameLabel.Size = new System.Drawing.Size(69, 17);
            this.comNameLabel.TabIndex = 3;
            this.comNameLabel.Text = "COM Port";
            // 
            // newPortButton
            // 
            this.newPortButton.Location = new System.Drawing.Point(898, 583);
            this.newPortButton.Name = "newPortButton";
            this.newPortButton.Size = new System.Drawing.Size(92, 30);
            this.newPortButton.TabIndex = 4;
            this.newPortButton.Text = "New Port";
            this.newPortButton.UseVisualStyleBackColor = true;
            this.newPortButton.Click += new System.EventHandler(this.newPortButton_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1369, 27);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(46, 24);
            this.toolStripDropDownButton1.Text = "File";
            this.toolStripDropDownButton1.ToolTipText = "File";
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.refreshToolStripMenuItem.Text = "Refresh";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(178, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(88, 24);
            this.toolStripButton1.Text = "Commands";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(49, 24);
            this.toolStripButton2.Text = "Reset";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(45, 24);
            this.toolStripButton3.Text = "Help";
            // 
            // rpmNameLabel
            // 
            this.rpmNameLabel.AutoSize = true;
            this.rpmNameLabel.Location = new System.Drawing.Point(1020, 383);
            this.rpmNameLabel.Name = "rpmNameLabel";
            this.rpmNameLabel.Size = new System.Drawing.Size(78, 17);
            this.rpmNameLabel.TabIndex = 6;
            this.rpmNameLabel.Text = "Motor RPM";
            // 
            // speedNameLabel
            // 
            this.speedNameLabel.AutoSize = true;
            this.speedNameLabel.Location = new System.Drawing.Point(1020, 417);
            this.speedNameLabel.Name = "speedNameLabel";
            this.speedNameLabel.Size = new System.Drawing.Size(49, 17);
            this.speedNameLabel.TabIndex = 7;
            this.speedNameLabel.Text = "Speed";
            // 
            // accelNameLabel
            // 
            this.accelNameLabel.AutoSize = true;
            this.accelNameLabel.Location = new System.Drawing.Point(1020, 451);
            this.accelNameLabel.Name = "accelNameLabel";
            this.accelNameLabel.Size = new System.Drawing.Size(86, 17);
            this.accelNameLabel.TabIndex = 8;
            this.accelNameLabel.Text = "Acceleration";
            // 
            // maniOneNameLabel
            // 
            this.maniOneNameLabel.AutoSize = true;
            this.maniOneNameLabel.Location = new System.Drawing.Point(1020, 482);
            this.maniOneNameLabel.Name = "maniOneNameLabel";
            this.maniOneNameLabel.Size = new System.Drawing.Size(94, 17);
            this.maniOneNameLabel.TabIndex = 9;
            this.maniOneNameLabel.Text = "Manipulator 1";
            // 
            // maniTwoLabel
            // 
            this.maniTwoLabel.AutoSize = true;
            this.maniTwoLabel.Location = new System.Drawing.Point(1020, 512);
            this.maniTwoLabel.Name = "maniTwoLabel";
            this.maniTwoLabel.Size = new System.Drawing.Size(94, 17);
            this.maniTwoLabel.TabIndex = 10;
            this.maniTwoLabel.Text = "Manipulator 2";
            // 
            // maniThreeLabel
            // 
            this.maniThreeLabel.AutoSize = true;
            this.maniThreeLabel.Location = new System.Drawing.Point(1020, 543);
            this.maniThreeLabel.Name = "maniThreeLabel";
            this.maniThreeLabel.Size = new System.Drawing.Size(94, 17);
            this.maniThreeLabel.TabIndex = 11;
            this.maniThreeLabel.Text = "Manipulator 3";
            // 
            // maniFourLabel
            // 
            this.maniFourLabel.AutoSize = true;
            this.maniFourLabel.Location = new System.Drawing.Point(1020, 574);
            this.maniFourLabel.Name = "maniFourLabel";
            this.maniFourLabel.Size = new System.Drawing.Size(94, 17);
            this.maniFourLabel.TabIndex = 12;
            this.maniFourLabel.Text = "Manipulator 4";
            // 
            // voltNameLabel
            // 
            this.voltNameLabel.AutoSize = true;
            this.voltNameLabel.Location = new System.Drawing.Point(1020, 348);
            this.voltNameLabel.Name = "voltNameLabel";
            this.voltNameLabel.Size = new System.Drawing.Size(56, 17);
            this.voltNameLabel.TabIndex = 13;
            this.voltNameLabel.Text = "Voltage";
            // 
            // voltBar
            // 
            this.voltBar.Location = new System.Drawing.Point(1133, 345);
            this.voltBar.Name = "voltBar";
            this.voltBar.Size = new System.Drawing.Size(208, 22);
            this.voltBar.TabIndex = 14;
            // 
            // motorBar
            // 
            this.motorBar.Location = new System.Drawing.Point(1133, 380);
            this.motorBar.Name = "motorBar";
            this.motorBar.Size = new System.Drawing.Size(208, 22);
            this.motorBar.TabIndex = 15;
            // 
            // speedBar
            // 
            this.speedBar.Location = new System.Drawing.Point(1133, 414);
            this.speedBar.Name = "speedBar";
            this.speedBar.Size = new System.Drawing.Size(208, 22);
            this.speedBar.TabIndex = 16;
            // 
            // accelBar
            // 
            this.accelBar.Location = new System.Drawing.Point(1133, 448);
            this.accelBar.Name = "accelBar";
            this.accelBar.Size = new System.Drawing.Size(208, 22);
            this.accelBar.TabIndex = 17;
            // 
            // maniOneBar
            // 
            this.maniOneBar.Location = new System.Drawing.Point(1133, 479);
            this.maniOneBar.Name = "maniOneBar";
            this.maniOneBar.Size = new System.Drawing.Size(208, 22);
            this.maniOneBar.TabIndex = 18;
            // 
            // maniTwoBar
            // 
            this.maniTwoBar.Location = new System.Drawing.Point(1133, 509);
            this.maniTwoBar.Name = "maniTwoBar";
            this.maniTwoBar.Size = new System.Drawing.Size(208, 22);
            this.maniTwoBar.TabIndex = 19;
            // 
            // maniThreeBar
            // 
            this.maniThreeBar.Location = new System.Drawing.Point(1133, 540);
            this.maniThreeBar.Name = "maniThreeBar";
            this.maniThreeBar.Size = new System.Drawing.Size(208, 22);
            this.maniThreeBar.TabIndex = 20;
            // 
            // maniFourBar
            // 
            this.maniFourBar.Location = new System.Drawing.Point(1133, 571);
            this.maniFourBar.Name = "maniFourBar";
            this.maniFourBar.Size = new System.Drawing.Size(208, 22);
            this.maniFourBar.TabIndex = 21;
            // 
            // robotDiagram
            // 
            this.robotDiagram.Location = new System.Drawing.Point(1048, 31);
            this.robotDiagram.Name = "robotDiagram";
            this.robotDiagram.Size = new System.Drawing.Size(293, 285);
            this.robotDiagram.TabIndex = 22;
            this.robotDiagram.TabStop = false;
            this.robotDiagram.Text = "visualization of robot placeholder";
            // 
            // coPilotBox
            // 
            this.coPilotBox.Location = new System.Drawing.Point(533, 312);
            this.coPilotBox.Name = "coPilotBox";
            this.coPilotBox.Size = new System.Drawing.Size(457, 250);
            this.coPilotBox.TabIndex = 23;
            this.coPilotBox.TabStop = false;
            this.coPilotBox.Text = "pilot two controller diagram placeholder";
            // 
            // pilotBox
            // 
            this.pilotBox.Location = new System.Drawing.Point(19, 312);
            this.pilotBox.Name = "pilotBox";
            this.pilotBox.Size = new System.Drawing.Size(445, 250);
            this.pilotBox.TabIndex = 24;
            this.pilotBox.TabStop = false;
            this.pilotBox.Text = "pilot one controller diagram placeholder";
            // 
            // horizontalLabel
            // 
            this.horizontalLabel.AutoSize = true;
            this.horizontalLabel.Location = new System.Drawing.Point(16, 40);
            this.horizontalLabel.Name = "horizontalLabel";
            this.horizontalLabel.Size = new System.Drawing.Size(170, 17);
            this.horizontalLabel.TabIndex = 25;
            this.horizontalLabel.Text = "HORIZONTAL DISTANCE";
            // 
            // verticalLabel
            // 
            this.verticalLabel.AutoSize = true;
            this.verticalLabel.Location = new System.Drawing.Point(16, 179);
            this.verticalLabel.Name = "verticalLabel";
            this.verticalLabel.Size = new System.Drawing.Size(146, 17);
            this.verticalLabel.TabIndex = 26;
            this.verticalLabel.Text = "VERTICAL DISTANCE";
            // 
            // recordHorizontalBtn
            // 
            this.recordHorizontalBtn.Location = new System.Drawing.Point(19, 60);
            this.recordHorizontalBtn.Name = "recordHorizontalBtn";
            this.recordHorizontalBtn.Size = new System.Drawing.Size(117, 116);
            this.recordHorizontalBtn.TabIndex = 27;
            this.recordHorizontalBtn.Text = "Record";
            this.recordHorizontalBtn.UseVisualStyleBackColor = true;
            // 
            // verticalRecordBtn
            // 
            this.verticalRecordBtn.Location = new System.Drawing.Point(19, 199);
            this.verticalRecordBtn.Name = "verticalRecordBtn";
            this.verticalRecordBtn.Size = new System.Drawing.Size(117, 107);
            this.verticalRecordBtn.TabIndex = 28;
            this.verticalRecordBtn.Text = "Record";
            this.verticalRecordBtn.UseVisualStyleBackColor = true;
            // 
            // horizontalDistanceLabel
            // 
            this.horizontalDistanceLabel.AutoSize = true;
            this.horizontalDistanceLabel.Location = new System.Drawing.Point(219, 110);
            this.horizontalDistanceLabel.Name = "horizontalDistanceLabel";
            this.horizontalDistanceLabel.Size = new System.Drawing.Size(263, 17);
            this.horizontalDistanceLabel.TabIndex = 29;
            this.horizontalDistanceLabel.Text = "horizontal distance travelled placeholder";
            // 
            // verticalDistanceLabel
            // 
            this.verticalDistanceLabel.AutoSize = true;
            this.verticalDistanceLabel.Location = new System.Drawing.Point(219, 244);
            this.verticalDistanceLabel.Name = "verticalDistanceLabel";
            this.verticalDistanceLabel.Size = new System.Drawing.Size(246, 17);
            this.verticalDistanceLabel.TabIndex = 30;
            this.verticalDistanceLabel.Text = "vertical distance travelled placeholder";
            // 
            // clickyBoi
            // 
            this.clickyBoi.Location = new System.Drawing.Point(721, 77);
            this.clickyBoi.Name = "clickyBoi";
            this.clickyBoi.Size = new System.Drawing.Size(171, 158);
            this.clickyBoi.TabIndex = 32;
            this.clickyBoi.Text = "Clicky Boi";
            this.clickyBoi.UseVisualStyleBackColor = true;
            this.clickyBoi.Click += new System.EventHandler(this.clickyBoi_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1369, 621);
            this.Controls.Add(this.clickyBoi);
            this.Controls.Add(this.verticalDistanceLabel);
            this.Controls.Add(this.horizontalDistanceLabel);
            this.Controls.Add(this.verticalRecordBtn);
            this.Controls.Add(this.recordHorizontalBtn);
            this.Controls.Add(this.verticalLabel);
            this.Controls.Add(this.horizontalLabel);
            this.Controls.Add(this.pilotBox);
            this.Controls.Add(this.coPilotBox);
            this.Controls.Add(this.robotDiagram);
            this.Controls.Add(this.maniFourBar);
            this.Controls.Add(this.maniThreeBar);
            this.Controls.Add(this.maniTwoBar);
            this.Controls.Add(this.maniOneBar);
            this.Controls.Add(this.accelBar);
            this.Controls.Add(this.speedBar);
            this.Controls.Add(this.motorBar);
            this.Controls.Add(this.voltBar);
            this.Controls.Add(this.voltNameLabel);
            this.Controls.Add(this.maniFourLabel);
            this.Controls.Add(this.maniThreeLabel);
            this.Controls.Add(this.maniTwoLabel);
            this.Controls.Add(this.maniOneNameLabel);
            this.Controls.Add(this.accelNameLabel);
            this.Controls.Add(this.speedNameLabel);
            this.Controls.Add(this.rpmNameLabel);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.newPortButton);
            this.Controls.Add(this.comNameLabel);
            this.Controls.Add(this.comBox);
            this.Name = "Form1";
            this.Text = "ROV GUI";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.TextBox comBox;
        private System.Windows.Forms.Label comNameLabel;
        private System.Windows.Forms.Button newPortButton;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.Label rpmNameLabel;
        private System.Windows.Forms.Label speedNameLabel;
        private System.Windows.Forms.Label accelNameLabel;
        private System.Windows.Forms.Label maniOneNameLabel;
        private System.Windows.Forms.Label maniTwoLabel;
        private System.Windows.Forms.Label maniThreeLabel;
        private System.Windows.Forms.Label maniFourLabel;
        private System.Windows.Forms.Label voltNameLabel;
        private System.Windows.Forms.TextBox voltBar;
        private System.Windows.Forms.TextBox motorBar;
        private System.Windows.Forms.TextBox speedBar;
        private System.Windows.Forms.TextBox accelBar;
        private System.Windows.Forms.TextBox maniOneBar;
        private System.Windows.Forms.TextBox maniTwoBar;
        private System.Windows.Forms.TextBox maniThreeBar;
        private System.Windows.Forms.TextBox maniFourBar;
        private System.Windows.Forms.GroupBox robotDiagram;
        private System.Windows.Forms.GroupBox coPilotBox;
        private System.Windows.Forms.GroupBox pilotBox;
        private System.Windows.Forms.Label horizontalLabel;
        private System.Windows.Forms.Label verticalLabel;
        private System.Windows.Forms.Button recordHorizontalBtn;
        private System.Windows.Forms.Button verticalRecordBtn;
        private System.Windows.Forms.Label horizontalDistanceLabel;
        private System.Windows.Forms.Label verticalDistanceLabel;
        private System.Windows.Forms.Button clickyBoi;
    }
}*/

