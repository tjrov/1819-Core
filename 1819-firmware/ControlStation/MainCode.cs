using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlStation
{
    static class MainCode
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread] //I commented this out and the GUI stopped crashing. Why? Do we need this for winforms?
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GUI());
            //Application.Run(new ControlStationInterface());
        }
<<<<<<< HEAD:1819-software/ControlStation/MainCode.cs

        private static void OnThreadException(object sender, ThreadExceptionEventArgs e)
        {
            //show an error box
            ThreadExceptionDialog ted = new ThreadExceptionDialog(e.Exception);
            //quit the app
            //Application.ExitThread();
        }
=======
>>>>>>> e6a6f88f9162c68e4745f655ca11c1e3719f4511:1819-firmware/ControlStation/MainCode.cs
    }

}
