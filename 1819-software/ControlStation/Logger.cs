using System;
using System.IO;

namespace ControlStation {
    //static to prevent multiple instances of file writing
    public static class Logger
    {
        public static void ClearLog()
        {
            File.WriteAllText(Properties.Settings.Default.LogFile, "");
        }
        public static void LogString(string msg)
        {
            File.AppendAllText(Properties.Settings.Default.LogFile, string.Format("{0:HH:mm:ss.fff}: {1}\n", DateTime.Now, msg));
        }
        public static void LogException(Exception ex)
        {
            LogString("Exception: " + ex.Message + ex.StackTrace);
        }
    }
}