namespace ControlStation
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
        COMMUNICATION_FAILURE = 2,
        ESC_FAILURE = 3,
        PRESSURE_SENSOR_FAILURE = 4
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
                string temp;
                switch (Error)
                {
                    case ROVError.ALL_SYSTEMS_GO:
                        temp = "All systems go";
                        break;
                    case ROVError.IMU_FAILURE:
                        temp = "IMU failure";
                        break;
                    case ROVError.COMMUNICATION_FAILURE:
                        temp = "Communication failure";
                        break;
                    case ROVError.ESC_FAILURE:
                        temp = "ESC failure";
                        break;
                    case ROVError.PRESSURE_SENSOR_FAILURE:
                        temp = "Pressure sensor failure";
                        break;
                    default:
                        temp = "Unknown. Welllllllll, s&*t.";
                        break;
                }
                return "Error " + (int)Error + ": " + temp;
            }
        }
        public string StatusString
        {
            get
            {
                switch (Status)
                {
                    case ROVStatus.DISARMED:
                        return "Disarmed";
                    case ROVStatus.ARMED:
                        return "Armed";
                    case ROVStatus.DISCONNECTED:
                        return "Disconnected";
                    case ROVStatus.REBOOT:
                        return "Reboot";
                    default:
                        return "Unknown status, hijo de puta.";
                }
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