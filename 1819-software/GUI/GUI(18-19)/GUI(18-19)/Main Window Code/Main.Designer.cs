namespace GUI
{
    partial class Main
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.comButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.ControllerTimer = new System.Windows.Forms.Timer(this.components);
            this.portInfoButton = new System.Windows.Forms.Button();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.connectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loggingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.portNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.baudRateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.placeholderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.placeholderToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.viewLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.portNameComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.baudRateComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keyboardShortcutsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gold;
            this.panel2.Controls.Add(this.portInfoButton);
            this.panel2.Controls.Add(this.comButton);
            this.panel2.Location = new System.Drawing.Point(24, 79);
            this.panel2.Margin = new System.Windows.Forms.Padding(6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(736, 688);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Cyan;
            this.panel3.Location = new System.Drawing.Point(24, 779);
            this.panel3.Margin = new System.Windows.Forms.Padding(6);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(736, 957);
            this.panel3.TabIndex = 2;
            // 
            // comButton
            // 
            this.comButton.AutoSize = true;
            this.comButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.comButton.BackColor = System.Drawing.Color.OrangeRed;
            this.comButton.Location = new System.Drawing.Point(-9, -12);
            this.comButton.Margin = new System.Windows.Forms.Padding(6);
            this.comButton.Name = "comButton";
            this.comButton.Size = new System.Drawing.Size(198, 42);
            this.comButton.TabIndex = 3;
            this.comButton.Text = "Disconnected";
            this.comButton.UseMnemonic = false;
            this.comButton.UseVisualStyleBackColor = false;
            this.comButton.Click += new System.EventHandler(this.ComButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.OliveDrab;
            this.panel1.Location = new System.Drawing.Point(774, 779);
            this.panel1.Margin = new System.Windows.Forms.Padding(6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 957);
            this.panel1.TabIndex = 4;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.DarkCyan;
            this.panel4.Location = new System.Drawing.Point(1188, 779);
            this.panel4.Margin = new System.Windows.Forms.Padding(6);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(2316, 957);
            this.panel4.TabIndex = 5;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.DarkCyan;
            this.panel5.Location = new System.Drawing.Point(774, 79);
            this.panel5.Margin = new System.Windows.Forms.Padding(6);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(2730, 688);
            this.panel5.TabIndex = 7;
            // 
            // ControllerTimer
            // 
            this.ControllerTimer.Enabled = true;
            // 
            // portInfoButton
            // 
            this.portInfoButton.AutoSize = true;
            this.portInfoButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.portInfoButton.Location = new System.Drawing.Point(198, -12);
            this.portInfoButton.Name = "portInfoButton";
            this.portInfoButton.Size = new System.Drawing.Size(258, 42);
            this.portInfoButton.TabIndex = 8;
            this.portInfoButton.Text = "COMX@XXXbaud";
            this.portInfoButton.UseVisualStyleBackColor = true;
            this.portInfoButton.Click += new System.EventHandler(this.portInfoButton_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.connectionToolStripMenuItem,
            this.inputToolStripMenuItem,
            this.loggingToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(3528, 49);
            this.menuStrip.TabIndex = 9;
            this.menuStrip.Text = "menuStrip1";
            // 
            // connectionToolStripMenuItem
            // 
            this.connectionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.portNameToolStripMenuItem,
            this.baudRateToolStripMenuItem});
            this.connectionToolStripMenuItem.Name = "connectionToolStripMenuItem";
            this.connectionToolStripMenuItem.Size = new System.Drawing.Size(183, 45);
            this.connectionToolStripMenuItem.Text = "Connection";
            // 
            // inputToolStripMenuItem
            // 
            this.inputToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.placeholderToolStripMenuItem,
            this.placeholderToolStripMenuItem1});
            this.inputToolStripMenuItem.Name = "inputToolStripMenuItem";
            this.inputToolStripMenuItem.Size = new System.Drawing.Size(100, 48);
            this.inputToolStripMenuItem.Text = "Input";
            // 
            // loggingToolStripMenuItem
            // 
            this.loggingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewLogToolStripMenuItem});
            this.loggingToolStripMenuItem.Name = "loggingToolStripMenuItem";
            this.loggingToolStripMenuItem.Size = new System.Drawing.Size(140, 48);
            this.loggingToolStripMenuItem.Text = "Logging";
            // 
            // portNameToolStripMenuItem
            // 
            this.portNameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.portNameComboBox});
            this.portNameToolStripMenuItem.Name = "portNameToolStripMenuItem";
            this.portNameToolStripMenuItem.Size = new System.Drawing.Size(396, 46);
            this.portNameToolStripMenuItem.Text = "PortName";
            // 
            // baudRateToolStripMenuItem
            // 
            this.baudRateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.baudRateComboBox});
            this.baudRateToolStripMenuItem.Name = "baudRateToolStripMenuItem";
            this.baudRateToolStripMenuItem.Size = new System.Drawing.Size(396, 46);
            this.baudRateToolStripMenuItem.Text = "BaudRate";
            // 
            // placeholderToolStripMenuItem
            // 
            this.placeholderToolStripMenuItem.Name = "placeholderToolStripMenuItem";
            this.placeholderToolStripMenuItem.Size = new System.Drawing.Size(396, 46);
            this.placeholderToolStripMenuItem.Text = "Placeholder";
            // 
            // placeholderToolStripMenuItem1
            // 
            this.placeholderToolStripMenuItem1.Name = "placeholderToolStripMenuItem1";
            this.placeholderToolStripMenuItem1.Size = new System.Drawing.Size(396, 46);
            this.placeholderToolStripMenuItem1.Text = "Placeholder";
            // 
            // viewLogToolStripMenuItem
            // 
            this.viewLogToolStripMenuItem.Name = "viewLogToolStripMenuItem";
            this.viewLogToolStripMenuItem.Size = new System.Drawing.Size(396, 46);
            this.viewLogToolStripMenuItem.Text = "View Log";
            // 
            // portNameComboBox
            // 
            this.portNameComboBox.Name = "portNameComboBox";
            this.portNameComboBox.Size = new System.Drawing.Size(121, 49);
            // 
            // baudRateComboBox
            // 
            this.baudRateComboBox.Items.AddRange(new object[] {
            "9600",
            "19200",
            "38400",
            "57600",
            "115200",
            "250000",
            "500000",
            "1000000"});
            this.baudRateComboBox.Name = "baudRateComboBox";
            this.baudRateComboBox.Size = new System.Drawing.Size(121, 49);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.keyboardShortcutsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(92, 48);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // keyboardShortcutsToolStripMenuItem
            // 
            this.keyboardShortcutsToolStripMenuItem.Name = "keyboardShortcutsToolStripMenuItem";
            this.keyboardShortcutsToolStripMenuItem.Size = new System.Drawing.Size(396, 46);
            this.keyboardShortcutsToolStripMenuItem.Text = "Keyboard Shortcuts";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(396, 46);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(75, 48);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(396, 46);
            this.quitToolStripMenuItem.Text = "Quit";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(3528, 1759);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.menuStrip);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "TJROV Control Station";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Main_KeyDown);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button comButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Timer ControllerTimer;
        private System.Windows.Forms.Button portInfoButton;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem portNameToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox portNameComboBox;
        private System.Windows.Forms.ToolStripMenuItem baudRateToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox baudRateComboBox;
        private System.Windows.Forms.ToolStripMenuItem inputToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem placeholderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem placeholderToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem loggingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem keyboardShortcutsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}

