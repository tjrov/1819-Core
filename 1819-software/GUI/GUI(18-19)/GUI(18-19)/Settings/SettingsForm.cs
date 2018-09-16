using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace GUI
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            portNameBox.Items.AddRange(SerialPort.GetPortNames());
            baudRateBox.Items.AddRange(
                new string[] { "9600", "19200", "38400", "57600", "115200", "250000", "500000", "1000000"});
        }

        private void portNameBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Properties.Settings.Default.PortName = (string)portNameBox.Items[portNameBox.SelectedIndex];
        }

        private void baudRateBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Properties.Settings.Default.BaudRate = int.Parse((string)baudRateBox.Items[baudRateBox.SelectedIndex]);
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
            Close();
        }
    }
}
