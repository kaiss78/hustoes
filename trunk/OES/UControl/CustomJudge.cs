using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using OES.Model;
using OES.XMLFile;

namespace OES.UControl
{
    public partial class CustomJudge : UserControl
    {
        [DllImport("user32", EntryPoint = "HideCaret")]
        private static extern bool HideCaret(IntPtr hWnd);
        private int proID;
        private Judge judge;

        public void CheckAns(string ans)
        {
            if (ans != judge.stuAns)
            {
                ClientControl.GetJudge(proID).stuAns = ans;
                ClientControl.SetDone(ClientControl.CurrentProblemNum);
            }
        }

        public void SetQuestion(int x)
        {
            proID = x;
            judge = ClientControl.GetJudge(proID);
            this.Question.Text = judge.problem;
            this.TrueButton.Checked = judge.stuAns == "T";
            this.FalseButton.Checked = judge.stuAns == "F";
        }

        public int GetQuestion()
        {
            return proID;
        }

        public CustomJudge()
        {
            InitializeComponent();
            proID = 0;
            this.SetQuestion(proID);
        }


        private void LastProblem_Click(object sender, EventArgs e)
        {            
            if (proID > 0)
            {
                this.SetQuestion(--proID);
                ClientControl.CurrentProblemNum--;
            }
            else
            {
                MessageBox.Show("这是第一题");
            }
        }

        private void NestProblem_Click(object sender, EventArgs e)
        {           
            if (proID + 1 < ClientControl.paper.judge.Count)
            {
                this.SetQuestion(++proID);
                ClientControl.CurrentProblemNum++;
            }
            else
            {
                MessageBox.Show("这是最后一题");
            }
        }

        private void Hide_MouseDown(object sender, MouseEventArgs e)
        {
            HideCaret(((RichTextBox)sender).Handle);
        }

        private void TrueButton_MouseClick(object sender, MouseEventArgs e)
        {
            this.CheckAns("T");
            XMLControl.WriteLogXML(ProblemType.Tof, proID, "T");
        }

        private void FalseButton_MouseClick(object sender, MouseEventArgs e)
        {
            this.CheckAns("F");
            XMLControl.WriteLogXML(ProblemType.Tof, proID, "F");
        }
        
    }
}
