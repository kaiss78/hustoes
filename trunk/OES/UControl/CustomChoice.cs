﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
 
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
                NextProblem.Visible = true;
                LastProblem.Visible = true;
                if (proid == ClientControl.paper.choice.Count - 1)
                {
                    NextProblem.Visible = false;
                }
                if (proid == 0)
                {
                    LastProblem.Visible = false;
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
            this.OptionA.InText = choice.optionA;
            this.OptionB.InText = choice.optionB;
            this.OptionC.InText = choice.optionC;
            this.OptionD.InText = choice.optionD;
            radioButtonA.Checked = choice.stuAns == "A";
            radioButtonB.Checked = choice.stuAns == "B";
            radioButtonC.Checked = choice.stuAns == "C";
            radioButtonD.Checked = choice.stuAns == "D";
            if (!string.IsNullOrEmpty(choice.stuAns))
            {
                ClientControl.SetDone(choice.problemId);
            }
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
            this.Dock = DockStyle.Fill;
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
            XMLControl.WriteLogXML(Config.stuPath,ProblemType.Choice, proID, "A");
        }

        private void radioButtonB_MouseClick(object sender, MouseEventArgs e)
        {
           
            this.CheckAns("B");
            XMLControl.WriteLogXML(Config.stuPath, ProblemType.Choice, proID, "B");
        }

        private void radioButtonC_MouseClick(object sender, MouseEventArgs e)
        {
            
            this.CheckAns("C");
            XMLControl.WriteLogXML(Config.stuPath, ProblemType.Choice, proID, "C");
        }

        private void radioButtonD_MouseClick(object sender, MouseEventArgs e)
        {
            
            this.CheckAns("D");
            XMLControl.WriteLogXML(Config.stuPath, ProblemType.Choice, proID, "D");
        }

        private void flowLayoutPanel1_SizeChanged(object sender, EventArgs e)
        {
            OptionA.Width = flowLayoutPanel1.Width-50;
            OptionB.Width = flowLayoutPanel1.Width-50;
            OptionC.Width = flowLayoutPanel1.Width-50;
            OptionD.Width = flowLayoutPanel1.Width-50;
            flowLayoutPanel1.Refresh();
        }

    }

}


