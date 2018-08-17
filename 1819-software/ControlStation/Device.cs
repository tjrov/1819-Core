using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlStation
{
    public abstract class GenericDevice : FlowLayoutPanel
    {
        protected byte messageCommand;
        public GenericDevice(byte messageCommand)
        {
            //size to fit components
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BorderStyle = BorderStyle.FixedSingle;
            BackColor = Color.Black;

            this.messageCommand = messageCommand;
        }
        public abstract MessageStruct GetMessage();
        public abstract void UpdateData(MessageStruct msg);
        public abstract void UpdateControls();
        public bool NeedsResponse { get; protected set; }
    }
    //class that both sensors and actuators extend from
    public abstract class Device<TData> : GenericDevice where TData : new()
    {
        protected TData data;
        public Device(byte messageCommand, TData data) : base(messageCommand)
        {
            this.data = data;
        }
    }
}
