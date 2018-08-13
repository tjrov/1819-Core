<<<<<<< HEAD:1819-software/ControlStation/Actuators.cs
﻿using System;
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
        public TData Value
        {
            get
            {
                return value;
            }
            set
            {
                this.value = value;
                Update();
            }
        }
        public Actuator(SerialCommunication comms, byte messageCommand) : base(comms, messageCommand)
        {
        }
        public override void Update()
        {
            comms.SendMessage(new MessageStruct(messageCommand, Convert(value)));
            FireOnUpdated();
        }
        protected abstract byte[] Convert(TData controlData);
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
        public PropulsionActuator(SerialCommunication comms) : base(comms, 0x81)
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
        public ToolsActuator(SerialCommunication comms) : base(comms, 0x82)
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
        public StatusActuator(SerialCommunication comms) : base(comms, 0x83)
        {
            /*flasher = new Timer
            {
                Interval = 500
            };
            flasher.Tick += OnFlasherTick;
            arm = new Button
            {
                Text = "Arm",
                AutoSize = true,
                BackColor = Color.Green
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

            Controls.Add(arm);
            Controls.Add(reboot);
            Controls.Add(upload);*/
        }

        /*private void OnFlasherTick(object sender, EventArgs e)
        {
            if(arm.BackColor == Color.Green)
            {
                arm.BackColor = Color.White;
            } else
            {
                arm.BackColor = Color.Green;
            }
        }

        private void OnRebootClick(object sender, EventArgs e)
        {
            value.Status = ROVStatus.REBOOT;
            Update(this, null);
        }

        private void OnUploadClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnArmClick(object sender, EventArgs e)
        {
            if(arm.Text == "Arm")
            {
                arm.Text = "Disarm";
                value.Status = ROVStatus.ARMED;
                flasher.Start();
            }
            if(arm.Text == "Disarm")
            {
                arm.Text = "Arm";
                value.Status = ROVStatus.DISARMED;
                flasher.Stop();
                arm.BackColor = Color.Green;
            }
            Update();
        }*/

        protected override byte[] Convert(SystemStatus controlData)
        {
            byte[] result = new byte[1];
            result[0] = (byte)controlData.Status;
            return result;
        }
    }
}
=======
﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlStation
{
    public abstract class Actuator<T> : Panel where T : new()
    {
        private byte messageCommand;
        private T value;
        public T Value
        {
            get
            {
                return value;
            }
            set
            {
                this.value = value;
                Update();
                Draw();
            }
        }
        private SerialCommunication comms;

        public Actuator(SerialCommunication comms, byte messageCommand) : base()
        {
            this.messageCommand = messageCommand;
            this.comms = comms;
            value = new T();
        }
        public new void Update()
        {
            comms.SendMessage(new MessageStruct(messageCommand, Convert(value)));
        }
        protected abstract byte[] Convert(T controlData);
        protected abstract void Draw();
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
        public PropulsionActuator(SerialCommunication comms) : base(comms, (byte)0x81)
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

        protected override void Draw()
        {
            throw new NotImplementedException();
        }
    }
    public class ToolsActuator : Actuator<Dictionary<string, double>>
    {
        public ToolsActuator(SerialCommunication comms) : base(comms, 0x82)
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

        protected override void Draw()
        {
            throw new NotImplementedException();
        }
    }
    public class StatusActuator : Actuator<SystemStatus>
    {
        public StatusActuator(SerialCommunication comms) : base(comms, 0x83)
        {
        }

        protected override byte[] Convert(SystemStatus controlData)
        {
            byte[] result = new byte[1];
            result[0] = (byte)controlData.Status;
            return result;
        }

        protected override void Draw()
        {
            throw new NotImplementedException();
        }
    }
}
>>>>>>> e6a6f88f9162c68e4745f655ca11c1e3719f4511:1819-firmware/ControlStation/Actuators.cs
