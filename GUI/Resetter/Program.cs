using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Diagnostics;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using System.Reflection;

namespace Resetter
{
    class Program
    {
        //cmdline syntax:
        //port name, baud rate, avr file location, .hex firmware location
        static void Main(string[] args)
        {
            Console.WriteLine(string.Format("Sending reset command to port {0} at {1} baud (should match firmware baud)", args[0], args[1]));
            //send reset
            SerialPort port = new SerialPort(args[0], int.Parse(args[1]));
            port.Open();
            byte[] buffer = { 0x42, 0x83, 0x01, 0x03, 0x02 };
            port.Write(buffer, 0, 5);
            port.Close();

            Console.WriteLine("Starting avrdude to upload " + args[3]);

            Console.WriteLine("DO NOT RESET OR TURN OFF TILL THIS COMPLETES!");
            Process avrprog = new Process();
            StreamReader avrstdout, avrstderr;
            StreamWriter avrstdin;
            ProcessStartInfo psI = new ProcessStartInfo("cmd");


            psI.UseShellExecute = false;
            psI.RedirectStandardInput = true;
            psI.RedirectStandardOutput = true;
            psI.RedirectStandardError = true;
            psI.CreateNoWindow = true;
            avrprog.StartInfo = psI;
            avrprog.Start();
            avrstdin = avrprog.StandardInput;
            avrstdout = avrprog.StandardOutput;
            avrstderr = avrprog.StandardError;
            avrstdin.AutoFlush = true;
            avrstdin.WriteLine("cd " + args[2]);
            avrstdin.WriteLine(@"avrdude.exe -C avrdude.conf -p atmega328p -c arduino -P " + args[0] + " -b 57600 -v -D -U flash:w:" + args[3] + ":i");
            avrstdin.Close();
            Console.WriteLine(avrstdout.ReadToEnd());
            Console.WriteLine(avrstderr.ReadToEnd());

            Console.WriteLine("\n\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}