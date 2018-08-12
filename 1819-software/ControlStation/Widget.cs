using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlStation
{
    //class that both sensors and actuators extend from
    public abstract class Widget<TData> : FlowLayoutPanel where TData : new()
    {
        protected byte messageCommand;
        protected TData value;
        protected SerialCommunication comms;
        public Widget(SerialCommunication comms, byte messageCommand)
        {
            this.comms = comms;
            this.messageCommand = messageCommand;
            value = new TData(); //instantiate value object to avoid null pointer

            this.comms.OnConnectionStatusChange += OnConnectionStatusChanged;

            AutoSize = true; //fit components
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BorderStyle = BorderStyle.Fixed3D;
            Enabled = false; //start greyed out (assume disconnected)
        }

        //only enabled when port connected
        private void OnConnectionStatusChanged(object sender, EventArgs e)
        {
            Enabled = comms.IsPortOpen;
        }

        public abstract new void Update();
        protected abstract override void OnPaint(PaintEventArgs e);
    }
}
