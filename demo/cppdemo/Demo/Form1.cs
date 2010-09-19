using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace Demo
{
    public partial class Form1 : Form
    {
        private Process cmd = new Process(); 
        public Form1()
        {
            InitializeComponent();
            //cmd.StartInfo.FileName = "systeminfo.exe";
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.UseShellExecute = false; //此处必须为false否则引发异常
            cmd.StartInfo.RedirectStandardInput = true; //标准输入
            cmd.StartInfo.RedirectStandardOutput = true; //标准输出
            //cmd.StartInfo.RedirectStanderError = true;
            cmd.StartInfo.CreateNoWindow = false;//不显示命令行窗口界面            
            
            //cmd.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;                       
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string st;
            st = textBox1.Text;
            cmd.Start(); //启动进程
            cmd.StandardInput.WriteLine(st);
            cmd.StandardInput.WriteLine("Exit");
            this.textBox2.Text = cmd.StandardOutput.ReadToEnd();
            //cmd.WaitForExit();//等待控制台程序执行完成
            //cmd.Close();//关闭该进程

            
        }
    }
}
