using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlStation
{
    //All ROV devices that generate information extend from this class
    public abstract class Sensor<TData> : Device<TData> where TData : new()
    {
        private byte messageLength;
        public TData Data
        {
            get
            {
                return data;
            }
        }
        //messageCommand is the command byte used to signal a read from this specific type of sensor
        public Sensor(byte messageCommand, byte messageLength, TData data) : base(messageCommand, data)
        {
            NeedsResponse = true;
            this.messageLength = messageLength;
        }
        public override MessageStruct GetMessage()
        {
            return new MessageStruct
            {
                command = messageCommand,
                data = new byte[0]
            };
        }
        public override void UpdateData(MessageStruct msg)
        {
            //check if it matches this type of sensor
            if (msg.data.Length == messageLength)
            {
                if (msg.command == messageCommand)
                {
                    //turn the bytes into usable values
                    Convert(msg.data, ref data);
                }
                else
                {
                    throw new Exception(string.Format("Attempted to update with invalid data " +
                        "message (command was {0} instead of {1})", msg.command, messageCommand));
                }
            }
            else
            {
                throw new Exception(string.Format("Attempted to update with invalid data " +
                    "message (length was {0} instead of {1})", msg.data.Length, messageLength));
            }
        }
        protected abstract void Convert(byte[] data, ref TData result);
    }
    public class OrientationSensor : Sensor<OrientationData>
    {
        /*
         * Message format:
         * CMD: 0x01
         * LEN: 6
         * [0][1] Heading (-180 to 180 degrees)
         * [2][3] Pitch ...
         * [4][5] Roll ...
         */
        private AttitudeIndicator attitudeIndicator;
        private HeadingIndicator headingIndicator;
        public OrientationSensor(OrientationData data) : base((byte)0x01, (byte)6, data)
        {
            attitudeIndicator = new AttitudeIndicator();
            headingIndicator = new HeadingIndicator();
            Controls.Add(attitudeIndicator);
            Controls.Add(headingIndicator);
        }

        public override void UpdateControls()
        {
            attitudeIndicator.YawAngle = data.Yaw;
            attitudeIndicator.PitchAngle = data.Pitch;
            attitudeIndicator.RollAngle = data.Roll;
            attitudeIndicator.Invalidate();
            headingIndicator.Heading = data.Yaw;
        }

        protected override void Convert(byte[] data, ref OrientationData result)
        {
            double[] ypr = new double[3];
            for (int i = 0; i < 3; i++)
            {
                ypr[i] = ConvertUtils.BytesToDouble(data[i * 2], data[i * 2 + 1], 0, 360);
            }
            result.Yaw = ypr[0]; result.Pitch = ypr[1]; result.Roll = ypr[2];
        }
    }
    public class PropulsionSensor : Sensor<List<ESCData>>
    {
        /*
         * Message format:
         * CMD: 0x02
         * LEN: 12
         * [0] First ESC's RPM (0 to 5000 rev/min)
         * [1] First ESC's temp (0 to 100 deg C)
         * ... and so on for all 6 ESCs
         */
        public PropulsionSensor(List<ESCData> data) : base(0x02, 12, data)
        {
            
        }

        public override void UpdateControls()
        {

        }

        protected override void Convert(byte[] data, ref List<ESCData> result)
        {
            int i = 0;
            foreach (ESCData esc in result)
            {
                esc.RPM = (int)ConvertUtils.ByteToDouble(data[i], 0, 5000);
                esc.Temperature = (int)ConvertUtils.ByteToDouble(data[i + 1], 0, 100);
                i += 2;
            }
        }
    }
    public class DepthSensor : Sensor<DepthData>
    {
        /*
         * Message format:
         * CMD: 0x03
         * LEN: 2
         * [0][2] Vehicle depth (0 to 30 meters)
         */
        private DepthIndicator depthIndicator;
        public DepthSensor(DepthData data) : base(0x03, 2, data)
        {
            depthIndicator = new DepthIndicator();
            Controls.Add(depthIndicator);
        }

        public override void UpdateControls()
        {
            depthIndicator.Depth = data.DepthValue;
        }

        protected override void Convert(byte[] data, ref DepthData result)
        {
            result.DepthValue = ConvertUtils.BytesToDouble(data[0], data[1], 0, 30);
        }
    }
    public class StatusSensor : Sensor<StatusData>
    {
        /*
         * Message format:
         * CMD: 0x04
         * LEN: 2
         * [0] system status
         * [1] error code
         * [2] voltage available at ROV (0 to 20 volts)
         */
        private Label status, error;
        private BarGraph voltage;

        public StatusSensor(StatusData data) : base(0x04, 3, data)
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
            voltage = new BarGraph("Voltage", "", Color.Green, 0, 20, 100);

            Controls.Add(status);
            Controls.Add(error);
            Controls.Add(voltage);
        }

        public override void UpdateControls()
        {
            status.Text = Data.StatusString;
            error.Text = Data.ErrorString;
            voltage.Value = Data.Voltage;
        }

        protected override void Convert(byte[] data, ref StatusData result)
        {
            result.Status = (ROVStatus)data[0];
            result.Error = (ROVError)data[1];
            result.Voltage = ConvertUtils.ByteToDouble(data[2], 0, 20);
        }
    }
}
