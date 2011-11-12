using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OESSupport.Net;
using OES;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;

namespace OESSupport
{
    class Program
    {
        static ServerEvt server=new ServerEvt();
        public static List<Teacher> TeacherList = new List<Teacher>();
        public static OESConfig config = new OESConfig("PathConfig.xml",
        new string[,] {
        {"Root","D:\\OES\\DataFiles\\"},
        {"Paper","Paper\\"},
        {"PaperPkg","PaperPkg\\"},
        {"Word","Word\\"},
        {"Excel","Excel\\"},
        {"PowerPoint","PowerPoint\\"},
        {"CCompletion","CCompletion\\"},
        {"CModification","CModification\\"},
        {"CFunction","CFunction\\"},
        {"CppCompletion","CppCompletion\\"},
        {"CppModification","CppModification\\"},
        {"CppFunction","CppFunction\\"},
        {"VbCompletion","VbCompletion\\"},
        {"VbModification","VbModification\\"},
        {"VbFunction","VbFunction\\"}       
            });
        static void Main(string[] args)
        {
            //Get   the   running   instance.  
            Process instance = RunningInstance();
            if (instance != null)
            {
                //There   is   another   instance   of   this   process.  
                //HandleRunningInstance(instance);
                return;
            }
            string cmd = Console.ReadLine();
            while(cmd != "exit")
            {
                switch (cmd)
                {
                    case "teacher":
                        foreach (Teacher t in TeacherList)
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine(t.ToString());
                        }
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }
                cmd = Console.ReadLine();
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
    }
}
