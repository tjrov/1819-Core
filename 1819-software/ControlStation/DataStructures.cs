using System;

namespace ControlStation
{
    public struct MessageStruct
    {
        public byte command;
        public byte[] data;
    }
    public class Tool
    {
        public double Speed;
    }
    public class Depth
    {
        public double DepthValue;
    }
    public class ESC
    {
        public double Temperature, Speed;
        public int RPM;
        public bool IsOvertemp
        {
            get
            {
                return Temperature > 45;
            }
        }
    }
    public class Orientation
    {
        public double Yaw, Pitch, Roll;
    }
    public enum ROVStatus
    {
        DISCONNECTED = 0,
        DISARMED = 1,
        ARMED = 2,
        REBOOT = 3
    }
    public enum ROVError
    {
        ALL_SYSTEMS_GO = 0,
        IMU_FAILURE = 1,
        ESC_FAILURE = 2,
        PRESSURE_SENSOR_FAILURE = 3,
        TOOLS_FAILURE = 4,
        INVALID_CHECKSUM = 5,
        INVALID_COMMAND = 6
    }
    public class State
    {
        public ROVStatus Status = ROVStatus.DISCONNECTED;
        public ROVStatus DesiredStatus = ROVStatus.DISCONNECTED;
        public ROVError Error;
        public double Voltage;
        public string ErrorString
        {
            get
            {
                return string.Format("{0} ({1})", Error.ToString(), (int)Error);
            }
        }
        public string StatusString
        {
            get
            {
                return string.Format("{0} ({1})", Status.ToString(), (int)Status);
            }
        }
        public bool IsUndervolt
        {
            get
            {
                return (Voltage < 7);
            }
        }
    }
}