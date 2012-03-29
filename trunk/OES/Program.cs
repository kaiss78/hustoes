
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using OES.Net;
using System.Threading;
using System.IO;

namespace OES
{
    static class Program
    {
        public static Config config = new Config(System.Environment.CurrentDirectory + @"\config.ini");
#if MultiDebug
        public static string[] Args;
#endif
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
#if MultiDebug
            Args = args;
#endif
#if !MultiDebug
            //Get   the   running   instance.  
            Process instance = RunningInstance();
            if (instance != null)
            {
                //There   is   another   instance   of   this   process.  
                HandleRunningInstance(instance);
                return;
            }
#endif
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
                Net.ClientEvt.Client.ReceivedTxt += new EventHandler(Net.ClientEvt.Client_ReceivedTxt);
                Net.ClientEvt.BroadcastHelper.OnReceiveMsg += (Net.ClientEvt.ChangeServerIpPort);
                Net.ClientEvt.BroadcastHelper.Listening();
                Application.Run(ClientControl.LoginForm);
            }
            catch(Exception e)
            {
                //
                Console.WriteLine(e.ToString());
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
            if (ClientControl.State == 0)
            {
                //如果考试端的状态为未启动，修改为未登录
                ClientControl.State = 1;
            }
            else if (ClientControl.State == 2)
            {
                ClientControl.ExamForm.Invoke(new MethodInvoker(() =>
                {
                    Directory.Delete(Config.paperPath, true);
                    ClientEvt.Client.Port.FileReceiveEnd -= ClientControl.ExamForm.Port_FileReceiveEnd;
                    ClientEvt.Client.Port.RecieveFileRate -= ClientControl.ExamForm.Port_RecieveFileRate;
                    ClientControl.State = 1;      //设置考试端为未登入状态
                    ClientControl.ExamForm.Dispose();
                    ClientControl.LoginForm.Show();
                }));
            }
            else if (ClientControl.State != 1)
            {
                Thread.Sleep(1000);
                //如果考试端状态为其他，说明监考端异常退出，需要状态恢复
                ClientEvt.Client.SendTxt("oes$5$" + ClientControl.student.sName + "$" + ClientControl.student.ID + "$" + ClientControl.student.password + "$" + ClientControl.State.ToString());
            }
        }
    }
}
