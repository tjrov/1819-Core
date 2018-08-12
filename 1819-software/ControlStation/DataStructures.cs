﻿namespace ControlStation
{
    public struct ESCStatus
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
    public struct Orientation
    {
        public double Heading, Pitch, Roll;
        public Orientation(double Heading, double Pitch, double Roll)
        {
            this.Heading = Heading;
            this.Pitch = Pitch;
            this.Roll = Roll;
        }
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
    public struct SystemStatus
    {
        public ROVStatus Status;
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