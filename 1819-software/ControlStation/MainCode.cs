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
        [STAThread]
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
            //show an error box - this one doesn't work either
            //MessageBox.Show(e.Exception.Message + e.Exception.StackTrace, "General exception", 
                //MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

}
