using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ControlStation.Communication;

namespace ControlStation.Devices
{
    public abstract class GenericDevice : Panel
    {
        protected byte messageCommand;
        public GenericDevice(byte messageCommand)
        {
            //size to fill parents
            Dock = DockStyle.Fill;
            BackColor = Color.Transparent;
            this.messageCommand = messageCommand;
        }
        public abstract ROVMessage GetMessage();
        public abstract void UpdateData(ROVMessage msg);
        public abstract void UpdateControls();
        public bool NeedsResponse { get; protected set; }
    }
    //class that both sensors and actuators extend from
    public abstract class Device<TData> : GenericDevice where TData : new()
    {
        protected TData data;
        public TData Data
        {
            get
            {
                return data;
            } set
            {
                data = value;
            }
        }
        public Device(byte messageCommand, TData data) : base(messageCommand)
        {
            this.data = data;
        }
        public event EventHandler<TData> DataUpdated;
        protected void FireDataUpdated()
        {
            if(DataUpdated != null)
            {
                DataUpdated(this, data);
            }
        }
    }
}
