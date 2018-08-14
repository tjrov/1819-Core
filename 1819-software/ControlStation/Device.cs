using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlStation
{
    public abstract class GenericDevice : FlowLayoutPanel
    {
        protected byte messageCommand;
        protected SerialCommunication comms;
        public GenericDevice(SerialCommunication comms, byte messageCommand)
        {
            this.comms = comms;
            this.messageCommand = messageCommand;

            //fit around components
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BorderStyle = BorderStyle.Fixed3D;

            OnUpdated += OnUpdatedHandler;
        }

        private void OnUpdatedHandler(object sender, EventArgs e)
        {
            Invalidate(); //repaint the panel
        }
        public abstract new void Update();
        public event EventHandler OnUpdated; //runs when Update completes
        protected void FireOnUpdated() //for subclasses
        {
            if (OnUpdated != null)
            {
                OnUpdated(this, null);
            }
        }
    }
    //class that both sensors and actuators extend from
    public abstract class Device<TData> : GenericDevice where TData : new()
    {
        protected TData value;
        protected Device<TData> linkedDevice;
        public Device(SerialCommunication comms, byte messageCommand) : base(comms, messageCommand)
        {
            value = new TData();
        }
        public void LinkTo(Device<TData> t)
        {
            linkedDevice = t;
            linkedDevice.OnUpdated += OnLinkedDeviceUpdated;
        }

        private void OnLinkedDeviceUpdated(object sender, EventArgs e)
        {
            value = linkedDevice.value;
        }
    }
}
