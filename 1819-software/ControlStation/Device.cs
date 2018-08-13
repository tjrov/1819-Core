using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlStation
{
    public interface IDevice
    {
        void Update();
        event EventHandler OnUpdated;
    }
    //class that both sensors and actuators extend from
    public abstract class Device<TData> : IDevice where TData : new()
    {
        protected byte messageCommand;
        protected TData value;
        protected SerialCommunication comms;
        public Device(SerialCommunication comms, byte messageCommand)
        {
            this.comms = comms;
            this.messageCommand = messageCommand;
            value = new TData(); //instantiate value object to avoid null pointer
        }
        public abstract void Update();
        public event EventHandler OnUpdated; //runs when Update completes
        protected void FireOnUpdated() //for subclasses
        {
            if(OnUpdated != null)
            {
                OnUpdated(this, null);
            }
        }
    }
}
