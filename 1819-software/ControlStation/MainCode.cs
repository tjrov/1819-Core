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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += OnThreadException;
            Application.ApplicationExit += OnApplicationExit;
            gui = new GUI();
            Application.Run(new GUI());
            //Application.Run(new ControlStationInterface());
        }

        private static void OnApplicationExit(object sender, EventArgs e)
        {
            gui.ShutDown();
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
