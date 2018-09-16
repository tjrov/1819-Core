namespace GUI
{
    partial class SettingsForm
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
            this.portNameBox = new System.Windows.Forms.ComboBox();
            this.baudRateBox = new System.Windows.Forms.ComboBox();
            this.portNameLabel = new System.Windows.Forms.Label();
            this.baudRateLabel = new System.Windows.Forms.Label();
            this.applyButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // portNameBox
            // 
            this.portNameBox.FormattingEnabled = true;
            this.portNameBox.Location = new System.Drawing.Point(13, 13);
            this.portNameBox.Name = "portNameBox";
            this.portNameBox.Size = new System.Drawing.Size(500, 39);
            this.portNameBox.TabIndex = 0;
            this.portNameBox.SelectionChangeCommitted += new System.EventHandler(this.portNameBox_SelectionChangeCommitted);
            // 
            // baudRateBox
            // 
            this.baudRateBox.FormattingEnabled = true;
            this.baudRateBox.Location = new System.Drawing.Point(13, 59);
            this.baudRateBox.Name = "baudRateBox";
            this.baudRateBox.Size = new System.Drawing.Size(500, 39);
            this.baudRateBox.TabIndex = 1;
            this.baudRateBox.SelectionChangeCommitted += new System.EventHandler(this.baudRateBox_SelectionChangeCommitted);
            // 
            // portNameLabel
            // 
            this.portNameLabel.AutoSize = true;
            this.portNameLabel.Location = new System.Drawing.Point(519, 13);
            this.portNameLabel.Name = "portNameLabel";
            this.portNameLabel.Size = new System.Drawing.Size(142, 32);
            this.portNameLabel.TabIndex = 2;
            this.portNameLabel.Text = "PortName";
            // 
            // baudRateLabel
            // 
            this.baudRateLabel.AutoSize = true;
            this.baudRateLabel.Location = new System.Drawing.Point(519, 59);
            this.baudRateLabel.Name = "baudRateLabel";
            this.baudRateLabel.Size = new System.Drawing.Size(142, 32);
            this.baudRateLabel.TabIndex = 3;
            this.baudRateLabel.Text = "BaudRate";
            // 
            // applyButton
            // 
            this.applyButton.AutoSize = true;
            this.applyButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.applyButton.Location = new System.Drawing.Point(13, 105);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(97, 42);
            this.applyButton.TabIndex = 4;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.applyButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 312);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.baudRateLabel);
            this.Controls.Add(this.portNameLabel);
            this.Controls.Add(this.baudRateBox);
            this.Controls.Add(this.portNameBox);
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox portNameBox;
        private System.Windows.Forms.ComboBox baudRateBox;
        private System.Windows.Forms.Label portNameLabel;
        private System.Windows.Forms.Label baudRateLabel;
        private System.Windows.Forms.Button applyButton;
    }
}