using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;

namespace OES.UControl
{     
    public partial class CustomPPT : UserControl
    {
        [DllImport("user32", EntryPoint = "HideCaret")]
        private static extern bool HideCaret(IntPtr hWnd);

        static string paperPath = Config.paperPath;
        static string name = "e.ppt";
        static string stuPath = paperPath + "stu_" + name;
      
        public CustomPPT()
        {     
            InitializeComponent();
            this.Question.Text = ClientControl.paper.officePPT.problem;
        }


        //private void button3_Click(object sender, EventArgs e)
        //{
        //    StreamReader sr = new StreamReader(path+"大枪刷图点.txt", Encoding.GetEncoding("GB2312"), false);

        //    string str = sr.ReadToEnd();

        //    sr.Close();

        //    this.Question.Text = str;
        //    this.richTextBox2.Text = str; 

        //}

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(stuPath);
            ClientControl.SetDone(ClientControl.CurrentProblemNum);
        }

        private void button2_Click(object sender, EventArgs e)
        {

            

            if (MessageBox.Show("继续将会删除之前答案", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                
                File.Copy(paperPath+name, stuPath,true);
                System.Diagnostics.Process.Start(stuPath);
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
            File.Copy(paperPath+name, stuPath,true);
            
        }

        //private void button4_Click(object sender, EventArgs e)
        //{

        //    MessageBox.Show(Correct.Correctppt(path2, path3).ToString());
        //}


        private void Hide_MouseDown(object sender, MouseEventArgs e)
        {
            HideCaret(((RichTextBox)sender).Handle);
        }
        private void Hide1_MouseDown(object sender, MouseEventArgs e)
        {

        }
    }
}
