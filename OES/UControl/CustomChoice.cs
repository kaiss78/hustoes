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

namespace OES.UControl
{
    public partial class CustomChoice : UserControl
    {
        [DllImport("user32", EntryPoint = "HideCaret")]
        private static extern bool HideCaret(IntPtr hWnd);
        private int proID;
        private Choice choice;

        public void CheckAns(string ans)
        {
            if (ans != ClientControl.GetChoice(proID).stuAns)
            {
                ClientControl.GetChoice(proID).stuAns = ans;
            }
        }

        public void SetQuestion(int proID)
        {
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

        public CustomChoice()
        {
            InitializeComponent();
            proID = 0;
            this.SetQuestion(proID);
        }

        private void nextstep_Click(object sender, EventArgs e)
        {
            if (proID + 1 < ClientControl.paper.choice.Count)
            {
                this.SetQuestion(++proID);
            }
            else
            {
                MessageBox.Show("这是最后一题");
            }
        }

        private void laststep_Click(object sender, EventArgs e)
        {            
            if (proID > 0)
            {
                this.SetQuestion(--proID);
            }
            else
            {
                MessageBox.Show("这是第一题");
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
        }

        private void radioButtonB_MouseClick(object sender, MouseEventArgs e)
        {
            this.CheckAns("B");
        }

        private void radioButtonC_MouseClick(object sender, MouseEventArgs e)
        {
            this.CheckAns("C");
        }

        private void radioButtonD_MouseClick(object sender, MouseEventArgs e)
        {
            this.CheckAns("D");
        }
    }

}


