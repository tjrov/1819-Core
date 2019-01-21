using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using XInput.Wrapper;


namespace ControllerTest
{
    class Program
    {
        static void Main(string[] args)
        {
            X.Gamepad g = X.Gamepad_1;
            g.Enable = true;
            while(true)
            {
                g.Update();
                Console.WriteLine(g.IsConnected);//g.RStick.X + "\t" + g.RStick.Y);
                Thread.Sleep(100);
            }
        }
    }
}
