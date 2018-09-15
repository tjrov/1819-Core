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
            Logger.ClearLog();
            Logger.LogString("Application started.");
            //empty the log file at the start of each session
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += OnThreadException;
            AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;
            AppDomain.CurrentDomain.ProcessExit += OnApplicationExit;
            Application.ApplicationExit += OnApplicationExit;
            gui = new GUI();
            Application.Run(new GUI());
            //Application.Run(new ControlStationInterface());
        }

        private static void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            OnApplicationExit(sender, e);
            Logger.LogString("Unhandled exception: " + ((Exception)e.ExceptionObject).Message);
            Logger.LogString("This build is cursed, getting the foh");
        }

        private static void OnApplicationExit(object sender, EventArgs e)
        {
            gui.ShutDown();
            Logger.LogString("Application exit.");
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
