using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlStation
{
    //All ROV devices that generate information extend from this class
    public abstract class Sensor<TData> : Widget<TData> where TData : new()
    {
        private byte messageLength;
        public TData Value
        {
            get
            {
                return value;
            }
        }
        //messageCommand is the command byte used to signal a read from this specific type of sensor
        public Sensor(SerialCommunication comms, byte messageCommand, byte messageLength) : base(comms, messageCommand)
        {
            this.messageLength = messageLength;
        }
        public override void Update()
        {
            //send an empty message with the command byte to request data from this sensor
            comms.SendMessage(new MessageStruct(messageCommand, 0));
            //wait for a response
            MessageStruct dataMessage = comms.ReceiveMessage();
            //check if it matches this type of sensor
            if (dataMessage.data.Length == messageLength
                && dataMessage.command == messageCommand)
            {
                //turn the bytes into usable values, then refresh the screen
                Convert(dataMessage.data, ref value);
                Invalidate();
            }
            else
            {
                throw new Exception("Attempted to update with invalid data message");
            }
        }
        protected abstract void Convert(byte[] data, ref TData result);
        protected override void OnPaint(PaintEventArgs e) //default look of sensor
        {
            Graphics g = e.Graphics;
            g.DrawString("Sensor\nPlaceholder", new Font(FontFamily.GenericSansSerif, 12), Brushes.Black, new Point(0, 0));
        }
    }
    public class OrientationSensor : Sensor<Orientation>
    {
        /*
         * Message format:
         * CMD: 0x01
         * LEN: 6
         * [0][1] Heading (-180 to 180 degrees)
         * [2][3] Pitch ...
         * [4][5] Roll ...
         */

        public OrientationSensor(SerialCommunication comms) : base(comms, (byte)0x01, (byte)8)
        {
        }
        protected override void Convert(byte[] data, ref Orientation result)
        {
            double[] ypr = new double[3];
            for (int i = 0; i < 3; i++)
            {
                ypr[i] = ConvertUtils.BytesToDouble(data[i], data[i + 1], -180, 180);
                i += 2;
            }
            result.Heading = ypr[0]; result.Pitch = ypr[1]; result.Roll = ypr[2];
        }
    }
    public class PropulsionSensor : Sensor<Dictionary<string, ESCStatus>>
    {
        /*
         * Message format:
         * CMD: 0x02
         * LEN: 12
         * [0] First ESC's RPM (0 to 5000 rev/min)
         * [1] First ESC's temp (0 to 100 deg C)
         * ... and so on for all 6 ESCs
         */
        public PropulsionSensor(SerialCommunication comms) : base(comms, 0x02, 12)
        {
        }

        protected override void Convert(byte[] data, ref Dictionary<string, ESCStatus> result)
        {
            int i = 0;
            foreach(string escName in result.Keys)
            {
                result.TryGetValue(escName, out ESCStatus esc);
                esc.RPM = (int)ConvertUtils.ByteToDouble(data[i], -5000, 5000);
                esc.Temperature = (int)ConvertUtils.ByteToDouble(data[i + 1], 0, 100);
                result.Add(escName, esc);
                i += 2;
            }
        }
    }
    public class DepthSensor : Sensor<Double>
    {
        /*
         * Message format:
         * CMD: 0x02
         * LEN: 2
         * [0][2] Vehicle depth (0 to 30 meters)
         */
        public DepthSensor(SerialCommunication comms) : base(comms, 0x02, 2)
        {
        }

        protected override void Convert(byte[] data, ref double result)
        {
            result = ConvertUtils.BytesToDouble(data[0], data[1], 0, 30);
        }
    }
    public class StatusSensor : Sensor<SystemStatus>
    {
        /*
         * Message format:
         * CMD: 0x05
         * LEN: 2
         * [0] system status
         * [1] error code
         * [2] voltage available at ROV (0 to 20 volts)
         */
        private Label status, error, voltage;
        public StatusSensor(SerialCommunication comms) : base(comms, 0x05, 3)
        {
            status = new Label
            {
                Text = "Status: *",
                AutoSize = true
            };
            error = new Label
            {
                Text = "Error: *",
                AutoSize = true
            };
            voltage = new Label
            {
                Text = "* V",
                AutoSize = true
            };
            Controls.Add(status);
            Controls.Add(error);
            Controls.Add(voltage);
        }

        protected override void Convert(byte[] data, ref SystemStatus result)
        {
            result.Status = (ROVStatus)data[0];
            result.Error = (ROVError)data[1];
            result.Voltage = ConvertUtils.ByteToDouble(data[2], 0, 20);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            status.Text = value.StatusString;
            error.Text = value.ErrorString;
            voltage.Text = string.Format("{0:00.0}V", value.Voltage);
        }
    }
}
