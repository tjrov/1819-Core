using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlStation
{
    public abstract class Widget<TData> : Panel where TData : new()
    {
        protected byte messageCommand;
        protected TData value;
        protected SerialCommunication comms;
        public Widget(SerialCommunication comms, byte messageCommand)
        {
            this.comms = comms;
            this.messageCommand = messageCommand;
            value = new TData();

            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BorderStyle = BorderStyle.Fixed3D;
        }
        public abstract new void Update();
        protected abstract override void OnPaint(PaintEventArgs e);
    }
}
