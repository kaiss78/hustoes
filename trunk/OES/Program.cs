
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;

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
            //Get   the   running   instance.  
            Process instance = RunningInstance();
            if (instance != null)
            {
                //There   is   another   instance   of   this   process.  
                HandleRunningInstance(instance);
                return;
            }

            try
            {
                Application.EnableVisualStyles();
#if !DEBUG
                Application.SetCompatibleTextRenderingDefault(false);
#endif
                Net.ClientEvt.Client.ConnectedServer += new EventHandler(Client_ConnectedServer);
                Net.ClientEvt.Client.DisConnectError += new System.IO.ErrorEventHandler(Client_DisConnectError);
                ClientControl.LoginForm.SetNetState(2);
                if (!Net.ClientEvt.Client.InitializeClient())
                {
                    MessageBox.Show("");
                }
                Net.ClientEvt.BroadcastHelper.OnReceiveMsg += (Net.ClientEvt.ChangeServerIpPort);
                Net.ClientEvt.BroadcastHelper.Listening();
                Application.Run(ClientControl.LoginForm);
            }
            catch
            {
                //
            }
            
        }

        #region 单进程运行
        [DllImport("User32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int cmdShow);
        [DllImport("User32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
        private const int WS_SHOWNORMAL = 1;

        public static Process RunningInstance()
        {

            Process current = Process.GetCurrentProcess();
            Process[] processes = Process.GetProcessesByName(current.ProcessName);
            //Loop   through   the   running   processes   in   with   the   same   name  
            foreach (Process process in processes)
            {
                //Ignore   the   current   process  
                if (process.Id != current.Id)
                {
                    //Make   sure   that   the   process   is   running   from   the   exe   file.  

                    if (Assembly.GetExecutingAssembly().Location.Replace("/", "\\") == current.MainModule.FileName)
                    {
                        //Return   the   other   process   instance.  
                        return process;
                    }
                }
            }
            //No   other   instance   was   found,   return   null.
            return null;
        }
        public static void HandleRunningInstance(Process instance)
        {
            //Make   sure   the   window   is   not   minimized   or   maximized  
            ShowWindowAsync(instance.MainWindowHandle, WS_SHOWNORMAL);
            //Set   the   real   intance   to   foreground   window
            SetForegroundWindow(instance.MainWindowHandle);
        }

        #endregion

        static void Client_DisConnectError(object sender, System.IO.ErrorEventArgs e)
        {
            while (!ClientControl.LoginForm.IsHandleCreated) ;
            ClientControl.LoginForm.Invoke(new MethodInvoker(() =>
                        { 
                            ClientControl.LoginForm.SetNetState(0);
                            
                        }));
        }

        static void Client_ConnectedServer(object sender, EventArgs e)
        {
            while (!ClientControl.LoginForm.IsHandleCreated) ;
            ClientControl.LoginForm.Invoke(new MethodInvoker(() =>
            {
                ClientControl.LoginForm.SetNetState(1);

            }));
        }
    }
}
