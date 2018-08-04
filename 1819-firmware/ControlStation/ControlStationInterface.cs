using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ControlStation
{
    public partial class ControlStationInterface : Form
    {
        private int current;
        private int clicker;
        private string myCOMPort;
        private Timer t = new Timer();

        public static extern bool isConnected();

        public ControlStationInterface()
        {
            InitializeComponent();
            clicker = 0;
            myCOMPort = "\\\\.\\COM";
            comBox.Text = myCOMPort;
            t.Interval = 250;
            t.Tick += T_Tick;
        }

        private void ControlStationInterface_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;//For maximum memes
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void newPortButton_Click(object sender, EventArgs e)
        {
            myCOMPort = comBox.Text;
        }

        private void clickyBoi_Click(object sender, EventArgs e)
        {
            clicker++;
            clickyBoi.Text = "Clicky Boi " + clicker;
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.F11 | Keys.Shift))
            {
                MessageBox.Show("What the fuck did you just fucking say about me, you little bitch? I’ll have you know I graduated top of my class in the Navy Seals, and I’ve been involved in numerous secret raids on Al-Quaeda, and I have over 300 confirmed kills. I am trained in gorilla warfare and I’m the top sniper in the entire US armed forces. You are nothing to me but just another target. I will wipe you the fuck out with precision the likes of which has never been seen before on this Earth, mark my fucking words. You think you can get away with saying that shit to me over the Internet? Think again, fucker. As we speak I am contacting my secret network of spies across the USA and your IP is being traced right now so you better prepare for the storm, maggot. The storm that wipes out the pathetic little thing you call your life. You’re fucking dead, kid. I can be anywhere, anytime, and I can kill you in over seven hundred ways, and that’s just with my bare hands. Not only am I extensively trained in unarmed combat, but I have access to the entire arsenal of the United States Marine Corps and I will use it to its full extent to wipe your miserable ass off the face of the continent, you little shit. If only you could have known what unholy retribution your little “clever” comment was about to bring down upon you, maybe you would have held your fucking tongue. But you couldn’t, you didn’t, and now you’re paying the price, you goddamn idiot. I will shit fury all over you and you will drown in it. You’re fucking dead, kiddo.");
                t.Start();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        public List<Color> colors = new List<Color> {
            Color.Red,
            Color.Orange,
            Color.Yellow,
            Color.Green,
            Color.Blue,
            Color.DarkViolet
        };
        private void T_Tick(object sender, System.EventArgs e)
        {
            this.BackColor = colors[current++];
            current %= colors.Count;
        }
    }
}
