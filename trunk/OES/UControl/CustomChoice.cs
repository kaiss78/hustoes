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
using OES.Model;
using OES.XMLFile;

namespace OES.UControl
{
    public partial class CustomChoice : UserControl
    {
        [DllImport("user32", EntryPoint = "HideCaret")]
        private static extern bool HideCaret(IntPtr hWnd);
        private int proid;

        public int proID
        {
            get { return proid; }
            set 
            { 
                proid = value;
                if (proid == ClientControl.paper.choice.Count - 1)
                {
                    NextProblem.Enabled = false;
                }
                else if (proid == 0)
                {
                    LastProblem.Enabled = false;
                }
                else
                {
                    NextProblem.Enabled = true;
                    LastProblem.Enabled = true;
                }
            }
        }
        private Choice choice;

        public void CheckAns(string ans)
        {
            if (ans != ClientControl.GetChoice(proID).stuAns)
            {
                ClientControl.GetChoice(proID).stuAns = ans;
                ClientControl.SetDone(ClientControl.CurrentProblemNum);
            }
        }

        public void SetQuestion(int x)
        {
            proID = x;
            choice = ClientControl.GetChoice(proID);
            this.Question.Text = choice.problem;
            this.OptionA.Text = choice.optionA;
            this.OptionB.Text = choice.optionB;
            this.OptionC.Text = choice.optionC;
            this.OptionD.Text = choice.optionD;
            radioButtonA.Checked = choice.stuAns == "A";
            radioButtonB.Checked = choice.stuAns == "B";
            radioButtonC.Checked = choice.stuAns == "C";
            radioButtonD.Checked = choice.stuAns == "D";
        }
        public int GetQuestion()
        {
            return proID;
        }
        public CustomChoice()
        {
            InitializeComponent();
            proID = 0;
            this.SetQuestion(proID);
        }

        private void nextstep_Click(object sender, EventArgs e)
        {
            if (proID < ClientControl.paper.choice.Count - 1)
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

        private void Hide_MouseDown(object sender, MouseEventArgs e)
        {
            HideCaret(((RichTextBox)sender).Handle);
        }
        private void Hide1_MouseDown(object sender, MouseEventArgs e)
        {
            HideCaret(((TextBox)sender).Handle);
        }

        private void radioButtonA_MouseClick(object sender, MouseEventArgs e)
        {
            
            this.CheckAns("A");
            XMLControl.WriteLogXML(ProblemType.Choice, proID, "A");
        }

        private void radioButtonB_MouseClick(object sender, MouseEventArgs e)
        {
           
            this.CheckAns("B");
            XMLControl.WriteLogXML(ProblemType.Choice, proID, "B");
        }

        private void radioButtonC_MouseClick(object sender, MouseEventArgs e)
        {
            
            this.CheckAns("C");
            XMLControl.WriteLogXML(ProblemType.Choice, proID, "C");
        }

        private void radioButtonD_MouseClick(object sender, MouseEventArgs e)
        {
            
            this.CheckAns("D");
            XMLControl.WriteLogXML(ProblemType.Choice, proID, "D");
        }
    }

}


