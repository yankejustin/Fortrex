using System;

namespace prjFortrex.Server
{
    static class Logger
    {
        public static void Log(this Exception sender)
        {
            Log(sender, string.Empty);
        }

        public static void Log(this Exception sender, string AdditionalInformation)
        {
            try
            {
                System.Diagnostics.Trace.WriteLine("Error::" + sender.Message + Environment.NewLine + AdditionalInformation);
            }
            catch
            { }
        }
    }
}