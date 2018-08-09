using System;
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
    public class Tools : Actuator<Dictionary<string, double>>
    {
        public Tools(SerialCommunication comms) : base(comms, 0x82)
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
}
