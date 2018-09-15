using GUI.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace GUI
{
    static class Program
    {
        /// The main entry point for the application.
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }

        public static void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            OnApplicationExit(sender, e);
            Logger.LogString("Unhandled exception: " + ((Exception)e.ExceptionObject).Message);
            Logger.LogString("This build is cursed, getting the foh");
        }

        private static void OnApplicationExit(object sender, EventArgs e)
        {
            Logger.LogString("Application exit.");
        }

        //log and display exceptions
        private static void OnThreadException(object sender, ThreadExceptionEventArgs e)
        {
            Logger.LogException(e.Exception);
            MessageBox.Show(e.Exception.Message + " (see log.txt for details)", "Exception Unhandled in UI Thread", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
