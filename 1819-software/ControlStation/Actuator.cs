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
    public class PropulsionActuator : Actuator<List<ESCData>>
    {
        /*
         * Message format:
         * CMD: 0x81
         * LEN: 12
         * [0][1] First ESC's speed value (-100 to 100 percent)
         * ... and so on for all 6 ESCs
         */
        private List<ESCPanel> escPanels;
        public PropulsionActuator(List<ESCData> data) : base(0x81, data)
        {
            escPanels = new List<ESCPanel>();
            for (int i = 0; i < data.Count; i++)
            {
                ESCPanel panel = new ESCPanel();
                escPanels.Add(panel);
                Controls.Add(panel);
            }
            //new line for each of the three panels
            SetFlowBreak(Controls[2], true);
        }

        public override void UpdateControls()
        {
            for (int i = 0; i < data.Count; i++)
            {
                escPanels[i].Speed.Value = data[i].Speed;
                escPanels[i].Temperature.Value = data[i].Temperature;
                escPanels[i].RPM.Value = data[i].RPM;
            }
        }

        protected override byte[] Convert(List<ESCData> controlData)
        {
            byte[] result = new byte[controlData.Count * 2];
            int i = 0;
            foreach (ESCData esc in controlData)
            {
                Tuple<byte, byte> bytes = ConvertUtils.DoubleToBytes(esc.Speed, -100, 100);
                result[i] = bytes.Item1;
                result[i + 1] = bytes.Item2;
                i += 2;
            }
            return result;
        }
        private class ESCPanel : FlowLayoutPanel
        {
            public BarGraph Temperature, RPM, Speed;
            public ESCPanel()
            {
                FlowDirection = FlowDirection.TopDown;
                Size = new Size(100, 150);
                BackgroundImageLayout = ImageLayout.Center;
                Temperature = new BarGraph("Temp", "C", Color.Green, 0, 100, 50);
                RPM = new BarGraph("RPM", "", Color.Green, 0, 5000, 50);
                Speed = new BarGraph("Speed", "%", Color.Green, -100, 100, 50);
                Controls.Add(Speed);
                Controls.Add(RPM);
                Controls.Add(Temperature);
            }
        }
    }
    public class ToolsActuator : Actuator<List<ToolData>>
    {
        private List<ToolPanel> toolPanels;
        public ToolsActuator(List<ToolData> data) : base(0x82, data)
        {
            toolPanels = new List<ToolPanel>();
            for(int i = 0; i < data.Count; i++)
            {
                ToolPanel panel = new ToolPanel();
                toolPanels.Add(panel);
                Controls.Add(panel);
            }
        }

        public override void UpdateControls()
        {
            for(int i = 0; i < data.Count; i++)
            {
                toolPanels[i].Speed.Value = data[i].Speed;
            }
        }

        protected override byte[] Convert(List<ToolData> controlData)
        {
            byte[] result = new byte[controlData.Count];
            int i = 0;
            foreach (ToolData tool in controlData)
            {
                if (tool.Speed == 0)
                {
                    result[i] = 128;
                }
                else
                {
                    result[i] = ConvertUtils.DoubleToByte(tool.Speed, -100, 100);
                }
                i++;
            }
            return result;
        }

        private class ToolPanel : FlowLayoutPanel
        {
            Bitmap toolBitmap = new Bitmap(Properties.Resources.dcmotor);
            public BarGraph Speed;
            public ToolPanel()
            {
                FlowDirection = FlowDirection.TopDown;
                Size = new Size(100, 100);
                BackgroundImage = toolBitmap;
                BackgroundImageLayout = ImageLayout.Center;
                Speed = new BarGraph("Speed", "%", Color.Green, -100, 100, 50);
                Controls.Add(Speed);
            }
        }
    }
    public class StatusActuator : Actuator<StatusData>
    {
        private Button arm, reboot, upload;
        private Timer flasher;
        public StatusActuator(StatusData data) : base(0x83, data)
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

        protected override byte[] Convert(StatusData controlData)
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
