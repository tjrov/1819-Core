using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace Resetter
{
    class Program
    {
        //cmdline syntax:
        //port name, baud rate
        static void Main(string[] args)
        {
            SerialPort port = new SerialPort(args[0], int.Parse(args[1]));
            port.Open();
            byte[] buffer = { 0x42, 0x83, 0x01, 0x03, 0x02 };
            port.Write(buffer, 0, 5);
            port.Close();
        }
    }
}
