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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += OnThreadException;
            gui = new GUI();
            Application.Run(new GUI());
            //Application.Run(new ControlStationInterface());
        }

        private static void OnThreadException(object sender, ThreadExceptionEventArgs e)
        {
            MessageBox.Show(gui, e.Exception.Message + e.Exception.StackTrace, "Error", 
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
