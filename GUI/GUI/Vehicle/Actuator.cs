using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{

    public abstract class Actuator<TData> : AbstractDevice<TData> where TData : new()
    {
        public Actuator(byte messageCommand) : base(messageCommand)
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
    public class PropulsionActuator : Actuator<ESCActuatorData>
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

        /*public override void UpdateControls()
        {
            for (int i = 0; i < data.Count; i++)
            {
                speeds[i].Value = data[i].Speed;
            }
        }*/

        protected override byte[] Convert(ESCActuatorData controlData)
        {
            byte[] result = new byte[6]; //[12]
            for (int i = 0; i < 6; i++) //0...11
            {
                /*Tuple<byte, byte> bytes = ConvertUtils.DoubleToBytes(controlData.Speeds[i / 2], -100, 100);
                result[i] = bytes.Item1;
                result[i + 1] = bytes.Item2;*/
                result[i] = ConvertUtils.DoubleToByte(controlData.Speeds[i], -100, 100);
            }
            return result;
        }
    }
    public class ToolsActuator : Actuator<ToolData>
    {
        public ToolsActuator() : base(0x82)
        {
        }

        /*public override void UpdateControls()
        {
            for(int i = 0; i < data.Count; i++)
            {
                speeds[i].Value = data[i].Speed;
            }
        }*/

        protected override byte[] Convert(ToolData controlData)
        {
            byte[] result = new byte[4];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = ConvertUtils.DoubleToByte(controlData.Speeds[i], -100, 100);
            }
            return result;
        }
    }

    public class ServoActuator : Actuator<ServoData>
    {
        public ServoActuator() : base(0x84)
        {
        }

        protected override byte[] Convert(ServoData controlData)
        {
            byte[] result = new byte[controlData.Positions.Length];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = ConvertUtils.DoubleToByte(controlData.Positions[i], 0, 180);
            }
            return result;
        }
    }

    public class MiniROVActuator : Actuator<MiniROVData>
    {
        public MiniROVActuator() : base(0x85)
        {
        }

        protected override byte[] Convert(MiniROVData controlData)
        {
            // TODO: send over actual data
            byte[] result = new byte[1];
            result[0] = ConvertUtils.DoubleToByte(2, 0, 100);
            return result;
        }
    }
    
    public class StatusActuator : Actuator<StatusActuatorData>
    {
        public StatusActuator() : base(0x83)
        {
        }

        protected override byte[] Convert(StatusActuatorData controlData)
        {
            byte[] result = new byte[1];
            result[0] = (byte)controlData.DesiredStatus;

            return result;
        }
    }
}
