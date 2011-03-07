using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using OESMonitor.PaperControl;

namespace OESMonitor
{
     static class Program
    {
        public static Net.OESServer server ;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);            
            XMLtoTXT.xmltotxt("paper.xml");
            Application.Run(new OESMonitor());
        }
    }
}
