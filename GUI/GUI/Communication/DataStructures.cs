using System;
using System.Collections.Generic;

namespace GUI
{
    public class ToolData
    {
        public double[] Speeds = new double[4];
    }
    public class DepthData
    {
        public double DepthValue;
    }
    public class ESCSensorData
    {
        public double[] Temperatures = new double[6];
        public int[] RPMs = new int[6];
    }
    public class ESCActuatorData
    {
        public double[] Speeds = new double[6];
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
    public class StatusSensorData
    {
        public ROVStatus Status = ROVStatus.DISCONNECTED;
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
    public class StatusActuatorData
    {
        public ROVStatus DesiredStatus = ROVStatus.DISCONNECTED;
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