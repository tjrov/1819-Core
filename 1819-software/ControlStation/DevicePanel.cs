/*using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlStation
{
    public interface IDevicePanel { };
    public abstract class DevicePanel<TDevice> : FlowLayoutPanel, IDevicePanel where TDevice : IDevice
    {
        protected TDevice device;
        public DevicePanel(TDevice attachedDevice)
        {
            //size to fit components
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BorderStyle = BorderStyle.Fixed3D;

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
    public class StatusReadout : DevicePanel<StatusSensor>
    {
        private Label status, error, voltage;
        public StatusReadout(StatusSensor attachedDevice) : base(attachedDevice)
        {
            
        }

        protected override void UpdateControls()
        {
            status.Text = device.Value.StatusString;
            error.Text = device.Value.ErrorString;
            voltage.Text = string.Format("{0:00.0}V", device.Value.Voltage);
        }
    }
    public class StatusControl : DevicePanel<StatusActuator> {
        private Button arm, reboot, upload;
        private Timer flasher;
        public StatusControl(StatusActuator attachedDevice) : base(attachedDevice)
        {
            arm = new Button
            {
                Text = "Arm",
                BackColor = Color.Green,
                AutoSize = true
            };
            reboot = new Button
            {
                Text = "Arm",
                BackColor = Color.Green,
                AutoSize = true
            };
            upload = new Button
            {
                Text = "Arm",
                BackColor = Color.Green,
                AutoSize = true
            };
            flasher = new Timer
            {
                Interval = 500,
            };
            flasher.Tick += OnFlasherTick;
            Controls.Add(arm);
            Controls.Add(reboot);
            Controls.Add(upload);
        }

        protected override void UpdateControls()
        {
            //flash button for armed state
            if (device.Value.Status == ROVStatus.ARMED)
            {
                arm.Text = "Disarm";
                flasher.Start();
            }
            //solid green for disarmed state
            else
            {
                arm.Text = "Arm";
                flasher.Stop();
                arm.BackColor = Color.Green;
            }
        }

        private void OnFlasherTick(object sender, EventArgs e)
        {
            if (arm.BackColor == Color.Green)
            {
                arm.BackColor = Color.White;
            }
            else
            {
                arm.BackColor = Color.Green;
            }
        }

        private void OnRebootClick(object sender, EventArgs e)
        {
            device.Value.Status = ROVStatus.REBOOT;
        }

        private void OnUploadClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
            //Show dialog box with settings
            //Send reboot command
            //Call Visual Studio project compile and upload
        }

        private void OnArmClick(object sender, EventArgs e)
        {
            if(device.Value.Status == ROVStatus.ARMED)
            {
                //send disarm command
                device.Value.Status = ROVStatus.DISARMED;
            } else
            {
                //arm
                device.Value.Status = ROVStatus.ARMED;
            }
        }
    }
}*/
