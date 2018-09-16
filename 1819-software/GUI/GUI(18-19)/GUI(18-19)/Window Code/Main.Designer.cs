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
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gold;
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
            this.comButton.Location = new System.Drawing.Point(24, 23);
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
            this.portInfoButton.Location = new System.Drawing.Point(241, 23);
            this.portInfoButton.Name = "portInfoButton";
            this.portInfoButton.Size = new System.Drawing.Size(258, 42);
            this.portInfoButton.TabIndex = 8;
            this.portInfoButton.Text = "COMX@XXXbaud";
            this.portInfoButton.UseVisualStyleBackColor = true;
            this.portInfoButton.Click += new System.EventHandler(this.portInfoButton_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(3528, 1759);
            this.Controls.Add(this.portInfoButton);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.comButton);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "TJROV Control Station";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Main_KeyDown);
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
    }
}

