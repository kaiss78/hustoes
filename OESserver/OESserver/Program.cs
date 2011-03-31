using System;
using System.Windows.Forms;

namespace OES
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Config config=new Config("\\config.ini");
            Application.Run(InfoControl.LoginForm);
        }
    }
}