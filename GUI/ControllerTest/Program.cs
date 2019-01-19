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

            Console.WriteLine(X.Gamepad_1.IsConnected);
            Console.ReadKey();
        }
    }
}
