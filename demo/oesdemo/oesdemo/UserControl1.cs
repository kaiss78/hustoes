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
        static string path1 = @"C:/oes/";
        static string name = "a.ppt";
        static string path2 = path1 + "ans_" + name;   
        public UserControl1()
        {     
            InitializeComponent();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader(@"C:\oes\大枪刷图点.txt", Encoding.GetEncoding("GB2312"), false);

            string str = sr.ReadToEnd();

            sr.Close();

            this.richTextBox1.Text = str; 

        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("C:/oes/ans_a.ppt");
        }

        private void button2_Click(object sender, EventArgs e)
        {

            

            if (MessageBox.Show("继续将会删除之前答案", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                //   Ensure   that   the   target   does   not   exist. 
                File.Delete(path2);
                //   Copy   the   file. 
                File.Copy(path1 + name, path2);
            }
            System.Diagnostics.Process.Start("C:/oes/ans_a.ppt");

        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            
            //   Ensure   that   the   target   does   not   exist. 
            File.Delete(path2);
            //   Copy   the   file. 
            File.Copy(path1 + name, path2);
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
            MessageBox.Show(Correct.Correctppt(path1+name,path2).ToString());
        }

        
    }
}
