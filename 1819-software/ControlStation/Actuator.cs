using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlStation
{
    public abstract class Actuator<TData> : Device<TData> where TData : new()
    {
        public TData Data
        {
            get
            {
                return data;
            }
            set
            {
                this.data = value;
            }
        }
        public Actuator(byte messageCommand, TData data) : base(messageCommand, data)
        {
            NeedsResponse = false;
        }
        public override MessageStruct GetMessage()
        {
            return new MessageStruct
            {
                command = messageCommand,
                data = Convert(data)
            };
        }
        protected abstract byte[] Convert(TData controlData);
        public override void UpdateData(MessageStruct msg)
        {
        }
    }
    public class PropulsionActuator : Actuator<List<ESC>>
    {
        /*
         * Message format:
         * CMD: 0x81
         * LEN: 12
         * [0][1] First ESC's speed value (-100 to 100 percent)
         * ... and so on for all 6 ESCs
         */
        public PropulsionActuator(List<ESC> data) : base(0x81, data)
        {
        }

        public override void UpdateControls()
        {
        }

        protected override byte[] Convert(List<ESC> controlData)
        {
            byte[] result = new byte[controlData.Count * 2];
            int i = 0;
            foreach (ESC esc in controlData)
            {
                Tuple<byte, byte> bytes = ConvertUtils.DoubleToBytes(esc.Speed, -100, 100);
                result[i] = bytes.Item1;
                result[i + 1] = bytes.Item2;
                i += 2;
            }
            return result;
        }
    }
    public class ToolsActuator : Actuator<List<Tool>>
    {
        public ToolsActuator(List<Tool> data) : base(0x82, data)
        {
        }

        public override void UpdateControls()
        {
        }

        protected override byte[] Convert(List<Tool> controlData)
        {
            byte[] result = new byte[controlData.Count];
            int i = 0;
            foreach (Tool tool in controlData)
            {
                result[i] = ConvertUtils.DoubleToByte(tool.Speed, -100, 100);
            }
            return result;
        }
    }
    public class StatusActuator : Actuator<State>
    {
        private Button arm, reboot, upload;
        private Timer flasher;
        public StatusActuator(State data) : base(0x83, data)
        {
            //FlowDirection = FlowDirection.TopDown;
            arm = new Button
            {
                Text = "Arm",
                BackColor = Color.Green,
                AutoSize = true
            };
            arm.Click += OnArmClick;
            reboot = new Button
            {
                Text = "Reboot",
                AutoSize = true
            };
            reboot.Click += OnRebootClick;
            upload = new Button
            {
                Text = "Upload",
                AutoSize = true
            };
            upload.Click += OnUploadClick;
            flasher = new Timer
            {
                Interval = 500,
            };
            flasher.Tick += OnFlasherTick;
            Controls.Add(arm);
            Controls.Add(reboot);
            Controls.Add(upload);
        }

        protected override byte[] Convert(State controlData)
        {
            byte[] result = new byte[1];
            result[0] = (byte)controlData.DesiredStatus;

            return result;
        }

        public override void UpdateControls()
        {
            //flash button for armed state
            if (Data.Status == ROVStatus.ARMED)
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
            Data.DesiredStatus = ROVStatus.REBOOT;
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
            if (Data.DesiredStatus == ROVStatus.ARMED)
            {
                //send disarm command
                Data.DesiredStatus = ROVStatus.DISARMED;
            }
            else
            {
                //arm
                Data.DesiredStatus = ROVStatus.ARMED;
            }
        }
        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            Data.DesiredStatus = ROVStatus.DISCONNECTED;
        }
    }
}
