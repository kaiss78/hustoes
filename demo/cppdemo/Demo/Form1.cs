using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace Demo
{
    public partial class Form1 : Form
    {
        private Process cmd = new Process();
        //private Process c2 = new Process();
        private FileInfo cpppath;
        private string clpath;
        public Form1()
        {
            InitializeComponent();
            clpath = @"C:\Program Files\Microsoft Visual Studio\VC98\Bin\";            
            cpppath=new FileInfo(@"C:\Documents and Settings\Administrator\桌面\oestest\test.cpp");
            folderBrowserDialog1.SelectedPath = clpath;
            openFileDialog2.FileName = cpppath.FullName;
            textBox1.Text = folderBrowserDialog1.SelectedPath;
            textBox4.Text = openFileDialog2.FileName;
            textBox3.Text = "2 3";
            
            //cmd.StartInfo.FileName = "systeminfo.exe";
            
            //cmd.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;                       
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string st,name;
            st = textBox3.Text+"/n";
            cmd.StartInfo.FileName = "cmd.exe";//***
            
            cmd.StartInfo.UseShellExecute = false; //此处必须为false否则引发异常
            cmd.StartInfo.RedirectStandardInput = true; //标准输入
            cmd.StartInfo.RedirectStandardOutput = true; //标准输出            
            cmd.StartInfo.CreateNoWindow = true;//不显示命令行窗口界面            
            cmd.Start(); //启动进程
            cmd.StandardInput.WriteLine("cd " + clpath);
            cmd.StandardInput.WriteLine("VCVARS32.BAT");
            cmd.StandardInput.WriteLine("cd "+cpppath.DirectoryName);
            cmd.StandardInput.WriteLine("cl "+cpppath.Name);

            name = (cpppath.Name.Split('.'))[0]+".exe";            
            /*cmd.StandardInput.WriteLine(name);
            cmd.StandardInput.WriteLine(st);
            cmd.StandardInput.WriteLine("0");*/
            //cmd.StandardInput.Close();
            cmd.StandardInput.WriteLine("Exit");            
            this.textBox2.Text = cmd.StandardOutput.ReadToEnd();
            cmd.WaitForExit();//等待控制台程序执行完成
            cmd.Close();//关闭该进程

            cmd.StartInfo.FileName = cpppath.DirectoryName + "\\" + name;
            cmd.Start();
            cmd.StandardInput.WriteLine(st);
            MessageBox.Show("输出结果为："+cmd.StandardOutput.ReadToEnd());            
            cmd.WaitForExit();//等待控制台程序执行完成
            cmd.Close();//关闭该进程

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;
                clpath = folderBrowserDialog1.SelectedPath;
            }                        
        }
        private void openFileDialog2_FileOk(object sender, CancelEventArgs e)
        {
            textBox4.Text = openFileDialog2.FileName;
            cpppath = new FileInfo(openFileDialog2.FileName);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog2.ShowDialog();
        }


    }
}
