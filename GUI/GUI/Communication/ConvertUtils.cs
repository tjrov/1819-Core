using System;

namespace GUI
{
    public class ConvertUtils
    {
        public static Tuple<byte, byte> DoubleToBytes(double val, double minVal, double maxVal)
        {
            return IntToBytes((int)Map(val, minVal, maxVal, UInt16.MinValue, UInt16.MaxValue));
        }
        public static byte DoubleToByte(double val, double minVal, double maxVal)
        {
            return (byte)Map(val, minVal, maxVal, Byte.MinValue, Byte.MaxValue);
        }
        public static double BytesToDouble(byte low, byte high, double minResult, double maxResult)
        {
            return Map(BytesToInt(low, high), UInt16.MinValue, UInt16.MaxValue, minResult, maxResult);
        }
        public static double ByteToDouble(byte val, double minResult, double maxResult)
        {
            return Map(val, Byte.MinValue, Byte.MaxValue, minResult, maxResult);
        }
        public static int BytesToInt(byte low, byte high)
        {
            return (high << 8) | low;
        }
        public static Tuple<byte, byte> IntToBytes(int val)
        {
            if (val > UInt16.MaxValue || val < UInt16.MinValue)
            {
                throw new Exception("Could not convert to bytes, out of UInt16 range");
            }
            return Tuple.Create<byte, byte>((byte)(val & 0x000000FF), (byte)(val & 0x0000FF00));
        }
        public static double Map(double val, double minVal, double maxVal, double minResult, double maxResult)
        {
            if (val > maxVal || val < minVal)
            {
                throw new Exception("Tried to map value that was not in specified starting range");
            }
            if (minVal >= maxVal || minResult >= maxResult)
            {
                throw new Exception("Tried to map with an invalid range specified");
            }
            return ((val - minVal) / (maxVal - minVal) * (maxResult - minResult)) + minResult;
        }
    }
}