using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
 
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using OES.Model;
using OES.DAO;

namespace OES.UControl
{
    public partial class CustomWord : UserControl
    {
        [DllImport("user32", EntryPoint = "HideCaret")]
        private static extern bool HideCaret(IntPtr hWnd);
        //static string paperPath = Config.paperPath;
        //static string name = "d.doc";
        //static string stuPath = Config.stuPath + "stu_" + name;
        private string filename = "";
        private int proid;

        public int proID
        {
            get { return proid; }
            set
            {
                proid = value;
                NextProblem.Visible = true;
                LastProblem.Visible = true;
                if (proid == ClientControl.paper.officeWord.Count - 1)
                {
                    NextProblem.Visible = false;
                }
                if (proid == 0)
                {
                    LastProblem.Visible = false;
                }
            }
        }

        private OfficeWord word = new OfficeWord();

        public CustomWord()
        {
            InitializeComponent();
            proID = 0;
            this.SetQuestion(proID);
            this.Dock = DockStyle.Fill;
        }

        public void SetQuestion(int x)
        {
            SaveOpenedFiles.CloseWord();
            proID = x;
            word = ClientControl.GetOfficeWord(proID);
            this.Question.Text = word.problem;
            this.filename = "d" + proID.ToString() + ".doc";
        }

        private void nextstep_Click(object sender, EventArgs e)
        {
            if (proID < ClientControl.paper.officeWord.Count - 1)
            {
                this.SetQuestion(++proID);
                ClientControl.CurrentProblemNum++;
            }
        }

        private void laststep_Click(object sender, EventArgs e)
        {
            if (proID > 0)
            {
                this.SetQuestion(--proID);
                ClientControl.CurrentProblemNum--;
            }

        }

        public int GetQuestion()
        {
            return proID;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveOpenedFiles.CloseWord();
            if (!File.Exists(Config.stuPath + filename))
            {
                File.Copy(Config.paperPath + filename, Config.stuPath + filename, true);
            }
            while (!File.Exists(Config.stuPath + filename)) ;
            SaveOpenedFiles.OpenWord(Config.stuPath + filename);
            //System.Diagnostics.Process.Start(Config.stuPath+filename);
            ClientControl.SetDone(ClientControl.CurrentProblemNum);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("继续将会删除之前答案", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                SaveOpenedFiles.CloseWord();
                File.Copy(Config.paperPath + filename, Config.stuPath+filename,true);
                SaveOpenedFiles.OpenWord(Config.stuPath + filename);
                //System.Diagnostics.Process.Start(Config.stuPath+filename);
            }
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
        }

        private void Hide_MouseDown(object sender, MouseEventArgs e)
        {
            HideCaret(((RichTextBox)sender).Handle);
        }
        private void Hide1_MouseDown(object sender, MouseEventArgs e)
        {

        }
    }
}
