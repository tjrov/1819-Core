using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    
    public abstract class Actuator<TData> : AbstractDevice<TData> where TData : new()
    {
        public Actuator(byte messageCommand, TData data) : base(messageCommand, data)
        {
            NeedsResponse = false;
        }
        public override ROVMessage GetMessage()
        {
            FireUpdated();
            return new ROVMessage
            {
                command = messageCommand,
                data = Convert(data)
            };
        }
        protected abstract byte[] Convert(TData controlData);
        public override void UpdateData(ROVMessage msg)
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
        //private List<BarGraph> speeds;
        public PropulsionActuator(List<ESCData> data) : base(0x81, data)
        {
            /*speeds = new List<BarGraph>();
            Dock = DockStyle.Fill;
            for (int y = 50; y < 410; y+=120)
            {
                BarGraph graph = new BarGraph("Speed", "{0:##0.0}", "%", Color.Green, -100, 100, 50);
                speeds.Add(graph);
                graph.Location = new Point(0, y);
                BarGraph graph2 = new BarGraph("Speed", "{0:##0.0}", "%", Color.Green, -100, 100, 50);
                speeds.Add(graph2);
                graph2.Location = new Point(520, y);
                Controls.Add(graph);
                Controls.Add(graph2);
            }*/

            //UpdateControls();
        }

        /*public override void UpdateControls()
        {
            for (int i = 0; i < data.Count; i++)
            {
                speeds[i].Value = data[i].Speed;
            }
        }*/

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
    }
    public class ToolsActuator : Actuator<List<ToolData>>
    {
        //private List<BarGraph> speeds;
        public ToolsActuator(List<ToolData> data) : base(0x82, data)
        {
            //speeds = new List<BarGraph>();
           /* for(int i = 0; i < 3; i++)
            {
                //BarGraph graph = new BarGraph("Speed", "{0:##0.0}", "%", Color.Green, -100, 100, 50);
                /speeds.Add(graph);
                Controls.Add(graph);
            }
            speeds[0].Location = new Point(300, 0);
            speeds[1].Location = new Point(0, 0);
            speeds[2].Location = new Point(350, 350);*/
            //UpdateControls();
        }

        /*public override void UpdateControls()
        {
            for(int i = 0; i < data.Count; i++)
            {
                speeds[i].Value = data[i].Speed;
            }
        }*/

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
    }
    public class StatusActuator : Actuator<StatusData>
    {
        /*private Button arm, reboot, upload, estop;
        private Timer flasher;
        private FlowLayoutPanel panel;
        private Bitmap estopBitmap = new Bitmap(GUI.Properties.GUI_18_19_.Properties.);*/
        public StatusActuator(StatusData data) : base(0x83, data) 
        {
            /*estopBitmap.MakeTransparent(Color.White);
            panel = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.TopDown,
                Dock = DockStyle.Fill
            };
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
            estop = new Button
            {
                BackColor = Color.Red,
                BackgroundImage = estopBitmap,
                BackgroundImageLayout = ImageLayout.Zoom,
                Size = new Size(75, 75)
            };
            estop.Click += OnArmClick;
            flasher = new Timer
            {
                Interval = 500,
            };
            flasher.Tick += OnFlasherTick;
            panel.Controls.Add(estop);
            panel.Controls.Add(arm);
            panel.Controls.Add(reboot);
            panel.Controls.Add(upload);
            Controls.Add(panel);*/
        }

        protected override byte[] Convert(StatusData controlData)
        {
            byte[] result = new byte[1];
            result[0] = (byte)controlData.DesiredStatus;

            return result;
        }

        /*public override void UpdateControls()
        {
            //flash button for armed state
            if (Data.Status == ROVStatus.ARMED)
            {
                estop.Visible = true;
                arm.Text = "Disarm";
                flasher.Start();
            }
            //solid green for disarmed state
            else
            {
                estop.Visible = false;
                arm.Text = "Arm";
                flasher.Stop();
                arm.BackColor = Color.Green;
            }
        }*/

        /*private void OnFlasherTick(object sender, EventArgs e)
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
            Data.Status = ROVStatus.DISCONNECTED;
            UpdateControls();
        }*/
    }
}
