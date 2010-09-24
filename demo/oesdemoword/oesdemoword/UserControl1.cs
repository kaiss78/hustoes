using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using oesdemo;


namespace oesdemoword
{
    public partial class UserControl1 : UserControl
    {
        static string path1 = @"C:\Documents and Settings\Solaryan\My Documents\Visual Studio 2008\Projects\oesdemoword\oesdemoword\bin\Debug\oes\";
        static string name = "a.doc";
        static string path2 = path1 + "ans_" + name;
        static string path3 = path1 + "cor_" + name;
        public UserControl1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(path2);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            if (MessageBox.Show("继续将会删除之前答案", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                File.Copy(path1 + name, path2,true);
                System.Diagnostics.Process.Start(path2);
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader(path1 + "大枪刷图点.txt", Encoding.GetEncoding("GB2312"), false);

            string str = sr.ReadToEnd();

            sr.Close();

            this.richTextBox1.Text = str;
            this.richTextBox2.Text = str;

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show(Correct.Correctword(path2, path3).ToString());
        }

        private void UserControl1_Load_1(object sender, EventArgs e)
        {

/*************防止copy出错，关闭所有word进程****************************************************/
            System.Diagnostics.Process[] pro = System.Diagnostics.Process.GetProcesses();
            foreach (System.Diagnostics.Process pro1 in pro)
            {
                if (pro1.ProcessName == "WINWORD")
                {
                    pro1.Kill();
                }
            }

            File.Copy(path1 + name, path2, true);


        }
        
    }
}
