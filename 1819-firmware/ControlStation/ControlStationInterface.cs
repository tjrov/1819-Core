using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlStation
{
    public partial class ControlStationInterface : Form
    {
        public ControlStationInterface()
        {
            InitializeComponent();
        }

        private void ControlStationInterface_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;//For maximum memes
        }
    }
}
