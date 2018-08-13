using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException); //handle exceptions
            Application.ThreadException += OnThreadException; //in a method below
            Application.Run(new GUI());
            //Application.Run(new ControlStationInterface());
        }

        private static void OnThreadException(object sender, ThreadExceptionEventArgs e)
        {
            //show an error box
            ThreadExceptionDialog ted = new ThreadExceptionDialog(e.Exception);
            //quit the app
            //Application.ExitThread();
        }
    }

}
