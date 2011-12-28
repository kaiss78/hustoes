using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Microsoft.Win32;
using OES.Model;

namespace OES
{
    public partial class frmAddProData : Form
    {
        private string Path;
        private ProgramAnswer ProAns;
        public bool Result;

        public frmAddProData(string path)
        {
            InitializeComponent();
            Path = path;
            Result = false;            
        }

        public static string FindVC()
        {
            RegistryKey key = Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Uninstall", false);
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

                cmd.StartInfo.FileName = cpppath.DirectoryName + "\\" + name;
                cmd.Start();
                cmd.StandardInput.WriteLine(input);
                st = cmd.StandardOutput.ReadToEnd();
                cmd.WaitForExit();//等待控制台程序执行完成
                cmd.Close();//关闭该进程
            }
            return st;
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Result = true;
            ProAns = new ProgramAnswer(0, rtbInput.Text, rtbOutput.Text);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {            
            this.Close();
        }
    }
}
