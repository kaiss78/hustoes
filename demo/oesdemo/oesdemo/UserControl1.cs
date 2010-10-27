using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace oesdemo
{
     
    public partial class UserControl1 : UserControl
    {
        static string path = @"C:\Documents and Settings\Solaryan\My Documents\Visual Studio 2008\Projects\oesdemoppt\oesdemo\bin\Debug\oes\";
        static string name = "a.ppt";
        static string path1 = path +  name;
        static string path2 = path + "ans_" + name;
        static string path3 = path + "cor_" + name;
        public UserControl1()
        {     
            InitializeComponent();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader(path+"大枪刷图点.txt", Encoding.GetEncoding("GB2312"), false);

            string str = sr.ReadToEnd();

            sr.Close();

            this.richTextBox1.Text = str; 

        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(path2);
        }

        private void button2_Click(object sender, EventArgs e)
        {

            

            if (MessageBox.Show("继续将会删除之前答案", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                
                File.Copy(path + name, path2,true);
                System.Diagnostics.Process.Start(path2);
            }
            

        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            System.Diagnostics.Process[] pro = System.Diagnostics.Process.GetProcesses();
            foreach (System.Diagnostics.Process pro1 in pro)
            {
                if (pro1.ProcessName == "POWERPNT" | pro1.ProcessName == "Powerpnt")
                {
                    pro1.Kill();
                }
            }          
            File.Copy(path + name, path2,true);
            
        }

        private void button4_Click(object sender, EventArgs e)
        {

            MessageBox.Show(Correct.Correctppt(path1,path2,path3).ToString());
        }

        
    }
}
