using System;
using System.Collections.Generic;
 
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
                //Net.ClientEvt.Client.server = Config.server;
                //Net.ClientEvt.Client.portNum = Config.portNum;
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Net.ClientEvt.Client.ConnectedServer += new EventHandler(Client_ConnectedServer);
                Net.ClientEvt.Client.DisConnectError += new System.IO.ErrorEventHandler(Client_DisConnectError);
                ClientControl.LoginForm.SetNetState(2);
                if (!Net.ClientEvt.Client.InitializeClient())
                {
                    MessageBox.Show("");
                }
                

                Application.Run(ClientControl.LoginForm);
            }
            catch
            {
                //
            }
        }

        static void Client_DisConnectError(object sender, System.IO.ErrorEventArgs e)
        {
            ClientControl.LoginForm.Invoke(new MethodInvoker(() =>
                        { 
                            ClientControl.LoginForm.SetNetState(0);
                            
                        }));
        }

        static void Client_ConnectedServer(object sender, EventArgs e)
        {
            ClientControl.LoginForm.Invoke(new MethodInvoker(() =>
            {
                ClientControl.LoginForm.SetNetState(1);

            }));
        }
    }
}
