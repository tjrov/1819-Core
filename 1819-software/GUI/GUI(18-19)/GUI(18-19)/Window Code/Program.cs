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
            Application.ThreadException += OnThreadException;
            Application.ApplicationExit += OnApplicationExit;
            Application.Run(new Main());
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
