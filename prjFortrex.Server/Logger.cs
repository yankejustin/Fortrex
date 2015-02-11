using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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