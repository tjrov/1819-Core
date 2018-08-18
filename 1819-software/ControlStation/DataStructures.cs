using System;
using System.Collections.Generic;

namespace ControlStation
{
    public struct MessageStruct
    {
        public byte command;
        public byte[] data;
    }
    public class ToolData
    {
        public double Speed;
    }
    public class DepthData
    {
        public double DepthValue;
    }
    public class ESCData
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
    public class OrientationData
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
    [Flags]
    public enum ROVError
    {
        ALL_SYSTEMS_GO = 0,
        IMU_FAILURE = 1,
        ESC_FAILURE = 2,
        PRESSURE_SENSOR_FAILURE = 4,
        TOOLS_FAILURE = 8,
        INVALID_CHECKSUM = 16,
        INVALID_COMMAND = 32
    }
    public class StatusData
    {
        public ROVStatus Status = ROVStatus.DISCONNECTED;
        public ROVStatus DesiredStatus = ROVStatus.DISCONNECTED;
        public ROVError Error = ROVError.ALL_SYSTEMS_GO;
        public double Voltage;
        public bool IsUndervolt
        {
            get
            {
                return (Voltage < 7);
            }
        }
    }
    public class VersionData
    {
        public byte Major, Minor;
        public string VersionString
        {
            get
            {
                return "v" + Major + "." + Minor;
            }
        }
    }
}