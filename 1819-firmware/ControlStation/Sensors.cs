using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlStation
{
    //All ROV devices that generate information extend from this class
    public abstract class Sensor<T> : Panel
    {
        private byte messageCommand, messageLength;
        private SerialCommunication comms;
        private T value;
        public T Value
        {
            get
            {
                return value;
            }
        }
        //messageCommand is the command byte used to signal a read from this specific type of sensor
        public Sensor(SerialCommunication comms, byte messageCommand, byte messageLength) : base()
        {
            this.messageCommand = messageCommand;
            this.messageLength = messageLength;
            this.comms = comms;
        }
        public new void Update()
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
                Draw();
            }
            else
            {
                throw new Exception("Attempted to update with invalid data message");
            }
        }
        public abstract void Draw();
        protected abstract void Convert(byte[] data, ref T result);
    }
    public class IMU : Sensor<Orientation>
    {
        /*
         * Message format:
         * CMD: 0x01
         * LEN: 6
         * [0][1] Heading (-180 to 180 degrees)
         * [2][3] Pitch ...
         * [4][5] Roll ...
         */

        public IMU(SerialCommunication comms) : base(comms, (byte)0x01, (byte)8)
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
        public override void Draw()
        {
            throw new NotImplementedException();
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

        public override void Draw()
        {
            throw new NotImplementedException();
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
    public class StatusSensor : Sensor<ROVStatus>
    {
        /*
         * Message format:
         * CMD: 0x05
         * LEN: 2
         * [0] one's bit signals connection state. two's bit signals arming state
         * [1] error code
         */
        public StatusSensor(SerialCommunication comms) : base(comms, 0x05, 2)
        {

        }

        public override void Draw()
        {
            throw new NotImplementedException();
        }

        protected override void Convert(byte[] data, ref ROVStatus result)
        {
            if ((data[0] & 0x01) != 0)
                result.Connected = true;
            else
                result.Connected = false;
            if ((data[0] & 0x02) != 0)
                result.Armed = true;
            else
                result.Armed = false;
            result.ErrorCode = data[1];
        }
    }
}
