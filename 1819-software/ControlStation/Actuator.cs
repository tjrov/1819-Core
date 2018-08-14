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
        public Actuator(byte messageCommand) : base(messageCommand)
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
    public class PropulsionActuator : Actuator<Dictionary<string, ESCStatus>>
    {
        /*
         * Message format:
         * CMD: 0x81
         * LEN: 12
         * [0][1] First ESC's speed value (-100 to 100 percent)
         * ... and so on for all 6 ESCs
         */
        public PropulsionActuator() : base(0x81)
        {
        }

        protected override byte[] Convert(Dictionary<string, ESCStatus> controlData)
        {
            byte[] result = new byte[controlData.Count * 2];
            int i = 0;
            foreach (string escName in controlData.Keys)
            {
                controlData.TryGetValue(escName, out ESCStatus esc);
                Tuple<byte, byte> bytes = ConvertUtils.DoubleToBytes(esc.Speed, -100, 100);
                result[i] = bytes.Item1;
                result[i + 1] = bytes.Item2;
                i += 2;
            }
            return result;
        }
    }
    public class ToolsActuator : Actuator<Dictionary<string, double>>
    {
        public ToolsActuator() : base(0x82)
        {
        }

        protected override byte[] Convert(Dictionary<string, double> controlData)
        {
            byte[] result = new byte[controlData.Count];
            int i = 0;
            foreach (string toolName in controlData.Keys)
            {
                controlData.TryGetValue(toolName, out double toolSpeed);
                result[i] = ConvertUtils.DoubleToByte(toolSpeed, -100, 100);
            }
            return result;
        }
    }
    public class StatusActuator : Actuator<SystemStatus>
    {
        private Button arm, reboot, upload;
        private Timer flasher;
        public StatusActuator() : base(0x83)
        {
            FlowDirection = FlowDirection.TopDown;
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

        protected override byte[] Convert(SystemStatus controlData)
        {
            byte[] result = new byte[1];
            result[0] = (byte)controlData.Status;
            return result;
        }

        protected override void OnInvalidated(InvalidateEventArgs e)
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
            Data.Status = ROVStatus.REBOOT;
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
            if (Data.Status == ROVStatus.ARMED)
            {
                //send disarm command
                Data.Status = ROVStatus.DISARMED;
            }
            else
            {
                //arm
                Data.Status = ROVStatus.ARMED;
            }
        }
    }
}
