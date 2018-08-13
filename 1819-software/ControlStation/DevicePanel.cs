using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlStation
{
    public abstract class DevicePanel : FlowLayoutPanel
    {
        protected IDevice device;
        public DevicePanel(IDevice attachedDevice)
        {
            //size to fit components
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BorderStyle = BorderStyle.Fixed3D;

            device = attachedDevice;
            //connect event handler to attached device
            device.OnUpdated += OnDeviceUpdated;
        }
        protected void OnDeviceUpdated(object sender, EventArgs e)
        {
            UpdateControls(); //refresh controls
            Invalidate(); //repaint the panel
        }
        protected abstract void UpdateControls();
    }
    public abstract class SensorPanel : DevicePanel
    {
        public SensorPanel(ISensor attachedDevice) : base(attachedDevice)
        {
        }
    }
    public abstract class ActuatorPanel : DevicePanel
    {
        public ActuatorPanel(IActuator attachedDevice) : base(attachedDevice)
        {
        }
    }
}
