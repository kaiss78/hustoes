using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace OES
{
    static class Program
    {
        public static Config config = new Config(System.Environment.CurrentDirectory + @"\config.ini");
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Net.ClientEvt.Client.server = Config.server;
                Net.ClientEvt.Client.portNum = Config.portNum;
                if (!Net.ClientEvt.Client.InitializeClient())
                {
                    MessageBox.Show("");
                }
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new LoginForm());
            }
            catch
            {
                //
            }
        }
    }
}
