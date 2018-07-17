using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlStation
{
    
    public class Test
    {
        static void Main()
        {
            ROV rov = new ROV(new SerialPort("COM1", 250000, Parity.None, 8, StopBits.One));
            while (true) ;
        }
    }
    public class ROV
    {
        SerialPort port;
        public ROV(SerialPort port)
        {
            this.port = port;
            Queue<MessageStruct> txQueue = new Queue<MessageStruct>();
        }
    }
    public abstract class Sensor<T> : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public MessageStruct RequestMessage;
        public T Value { get; }
        public Sensor(byte messageCommand, byte messageLength)
        {
            RequestMessage.command = messageCommand;
            RequestMessage.data = new byte[messageLength];
        }
        public void Update(MessageStruct dataMessage)
        {
            if (dataMessage.data.Length == 8
                && dataMessage.command == RequestMessage.command)
            {
                UpdateHelper(dataMessage);
                PropertyChanged(this, null);
            }
        }
        public abstract void UpdateHelper(MessageStruct dataMessage);
    }
    /*public class IMU : Sensor<Orientation>
    {
        Don't know wtf this is
    }*/
    public class Avionics : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private byte messageCommand;
        private Conversion toDegrees, toMeters;

        public Orientation Orientation { get; private set; }

        public double Depth { get; private set; }

        public Avionics(byte messageCommand) //abstract add length
        {
            this.messageCommand = messageCommand;
            toDegrees = new Conversion(-180, 180);
            toMeters = new Conversion(0, 30);
        }
        public void Update(MessageStruct dataMessage) //abstract
        {
            if(dataMessage.data.Length == 8 
                && dataMessage.command == (messageCommand | (byte)0x02))
            {
                Orientation.Heading = toDegrees.Convert(dataMessage.data[0], dataMessage.data[1]);
                Orientation.Pitch = toDegrees.Convert(dataMessage.data[2], dataMessage.data[3]);
                Orientation.Roll = toDegrees.Convert(dataMessage.data[4], dataMessage.data[5]);
                Depth = toMeters.Convert(dataMessage.data[6], dataMessage.data[7]);
                PropertyChanged(this, null);
            }
        }
    }
    public class Conversion
    {
        private double minOut, maxOut;
        public Conversion(double minOut, double maxOut)
        {
            this.minOut = minOut;
            this.maxOut = maxOut;
        }
        public double Convert(byte b1, byte b2)
        {
            int temp = (b1 << 8) | b2; //combine bytes together
            return temp / 65535.0 * (maxOut - minOut) + minOut; //map to max, min range specified
        }
    }
    public class Orientation
    {
        public double Heading, Pitch, Roll;
    }
}
