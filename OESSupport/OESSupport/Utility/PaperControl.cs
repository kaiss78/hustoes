using System;
using System.Collections.Generic;
 
using System.Text;
using OES;
using System.IO;

namespace OESSupport.Utility
{
    public class PaperControl
    {
        private static OESData oesData = null;
        public static OESData OesData
        {
            get
            {
                if (oesData == null) { oesData = new OESData(); }
                return PaperControl.oesData;
            }
            set { PaperControl.oesData = value; }
        }
        public static string LogFile = "Teacher2Support.log";
        public static void Console_Color_WriteLine_Log(string msg, ConsoleColor c)
        {
            Console.ForegroundColor = c;
            Console.WriteLine("[" + DateTime.Now.ToString() + "] " + msg);
            Console.ForegroundColor = ConsoleColor.White;
            if (!string.IsNullOrEmpty(LogFile))
            {
                using (StreamWriter sw = new StreamWriter(LogFile, true, Encoding.Default))
                {
                    sw.WriteLine("[" + DateTime.Now.ToString() + "] " + msg);
                }
            }
        }
        public static void Console_Color_WriteLine(string msg, ConsoleColor c)
        {
            Console.ForegroundColor = c;
            Console.WriteLine(msg);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
