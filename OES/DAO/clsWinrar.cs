using System;
using System.Collections.Generic;
 
using System.Text;
using System.IO;
using Microsoft.Win32;
using System.Diagnostics;

namespace OES.UControl
{
    class clsWinrar
    {
        /*是否安装了Winrar*/
        static public bool Exists()
        {
            RegistryKey the_Reg = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows
\CurrentVersion\App Paths\WinRAR.exe");
            return !string.IsNullOrEmpty(the_Reg.GetValue("").ToString());
        }

        /*解压缩rar文件*/
        public string unCompressRAR(string unRarPatch, string rarPatch, string rarName)
        {
            string the_rar;
            RegistryKey the_Reg;
            object the_Obj;
            string the_info;

            try
            {
                the_Reg = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\WinRAR.exe");
                the_Obj = the_Reg.GetValue("");
                the_rar = the_Obj.ToString();
                the_Reg.Close();
                /*确定给定目录是否引用磁盘的现有目录*/
                if (Directory.Exists(unRarPatch) == false)
                {/*按 path 的指定创建所有目录和子目录*/
                    Directory.CreateDirectory(unRarPatch);
                }
                /*这个解压缩的参数信息格式，特别要注意啊！*/
                the_info = "e " + rarName + " " + unRarPatch + " -y";
                /*指定启动进程时是使用的一组值*/
                ProcessStartInfo the_startInfo = new ProcessStartInfo();
                /*获取或设置要启动的应用程序或文档*/
                the_startInfo.FileName = the_rar;
                /*获取或设置要启动的应用程序时要使用的一组命令行参数*/
                the_startInfo.Arguments = the_info;
                /*设置启动进程时的使用的窗口状态是隐藏窗口样式*/
                the_startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                /*设置压缩包路径*/
                the_startInfo.WorkingDirectory = rarPatch;

                Process the_Process = new Process();
                the_Process.StartInfo = the_startInfo;
                the_Process.Start();
                /*指示Process组件无限期的等待关联进程的退出*/
                the_Process.WaitForExit();
                the_Process.Close();
            }
            catch (Exception err)
            {
                throw err;
            }
            return unRarPatch;
        }
    }
}
