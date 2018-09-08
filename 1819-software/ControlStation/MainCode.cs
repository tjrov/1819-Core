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
        private static GUI gui;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //empty the log file at the start of each session
            Logger.ClearLog();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += OnThreadException;
            gui = new GUI();
            Application.Run(new GUI());
            //Application.Run(new ControlStationInterface());
        }

        //log and display exceptions
        private static void OnThreadException(object sender, ThreadExceptionEventArgs e)
        {
            Logger.LogException(e.Exception);
            MessageBox.Show(gui, e.Exception.Message + " (see log.txt for details)", "Exception Unhandled in UI Thread",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
