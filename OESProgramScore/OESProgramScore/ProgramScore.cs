using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using Microsoft.Win32;

namespace OESScore
{
    public class ProgramScore
    {
        private static Thread t;
        private static bool isTimeOut = false;

        /// <summary>
        /// 获取安装软件和路径，通过注册表得到。
        /// </summary>
        /// <returns></returns>
        public static string FindVC()
        {
            RegistryKey key = Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Uninstall", false);
            {
                if (key != null)//判断对象存在
                {
                    foreach (string keyName in key.GetSubKeyNames())//遍历子项名称的字符串数组
                    {
                        using (RegistryKey key2 = key.OpenSubKey(keyName, false))//遍历子项节点
                        {
                            if (key2 != null)
                            {
                                string softwareName = key2.GetValue("DisplayName", "").ToString();//获取软件名
                                string installLocation = key2.GetValue("UninstallString", "").ToString();//获取安装路径
                                if (softwareName.Contains("Microsoft Visual C++ 6.0") == true)
                                {
                                    installLocation = installLocation.Remove(installLocation.IndexOf("Setup"));
                                    return installLocation + @"Bin\";
                                }
                            }
                        }
                    }
                }
            }
            return "";
        }

        /// <summary>
        /// 程序综合题评分
        /// </summary>
        /// <param name="path">文件路径</param>
        public static string correctPF(string path, string input)
        {
            string clPath = FindVC();
            string st, name;
            Process cmd = new Process();
            FileInfo cpppath = new FileInfo(path);
            st = "";
            if (clPath != "")
            {
                cmd.StartInfo.FileName = "cmd.exe";//***
                cmd.StartInfo.UseShellExecute = false; //此处必须为false否则引发异常
                cmd.StartInfo.RedirectStandardInput = true; //标准输入
                cmd.StartInfo.RedirectStandardOutput = true; //标准输出            
                cmd.StartInfo.CreateNoWindow = true;//不显示命令行窗口界面                         
                cmd.Start(); //启动进程
                cmd.StandardInput.WriteLine(clPath[1] + ":");
                cmd.StandardInput.WriteLine("cd " + clPath);   //编译生成.exe文件
                cmd.StandardInput.WriteLine("VCVARS32.BAT");
                cmd.StandardInput.WriteLine(cpppath.DirectoryName[0] + ":");
                cmd.StandardInput.WriteLine("cd " + cpppath.DirectoryName);
                cmd.StandardInput.WriteLine("cl " + cpppath.Name);
                name = (cpppath.Name.Split('.'))[0] + ".exe";
                cmd.StandardInput.WriteLine("Exit");
                cmd.WaitForExit();//等待控制台程序执行完成               
                cmd.Close();//关闭该进程
                isTimeOut = false;
                t = new Thread(new ThreadStart(() =>
                {

                    Thread.Sleep(3000);
                    isTimeOut = true;

                }
                                          ));
                t.Start();
                cmd.StartInfo.FileName = cpppath.DirectoryName + "\\" + name;
                if (File.Exists(cmd.StartInfo.FileName))
                {
                    cmd.Start();
                    cmd.StandardInput.WriteLine(input);

                    while (!cmd.HasExited && !isTimeOut)
                    {
                    }
                    if (isTimeOut)
                    {
                        cmd.Kill();
                    }
                    st = cmd.StandardOutput.ReadToEnd();
                    cmd.Close(); //关闭该进程     
                    t.Abort();
                    isTimeOut = false;
                }
            }
            return Clean(st);
        }


        public static string Clean(string str)
        {
            int j = 0;
            string st = str;
            while (j < st.Length)
            {
                if ((st[j] == '\t') || (st[j] == ' ') || (st[j] == '\r') || (st[j] == '\n'))
                {
                    st = st.Remove(j, 1);
                }
                else
                {
                    j++;
                }
            }
            return st;
        }

        /// <summary>
        /// 获得路径指向的文件名
        /// </summary>
        /// <param name="path">路径</param>
        /// <returns>文件名</returns>
        private static string GetText(String path)
        {
            string text = "";
            if (path.Length > 0)
            {
                StreamReader TxtReader = new StreamReader(path);
                text = TxtReader.ReadToEnd();
                TxtReader.Close();
            }
            return text;
        }


        /// <summary>
        /// 程序改错、填空题评分
        /// </summary>
        /// <param name="path">文件路径</param>
        public static List<string> correctPC(string path)
        {
            string cpptext, st;
            int i, j;
            List<string> result;
            result = new List<string>();
            cpptext = GetText(path);
            string[] str = cpptext.Split('\n');
            i = 0;
            while (i < str.Length)
            {
                if (str[i].IndexOf(@"//") >= 0)
                {
                    st = str[i + 1];
                    i = i + 2;
                    result.Add(Clean(st));
                }
                else
                {
                    i++;
                }
            }
            return result;

        }
    }
}
