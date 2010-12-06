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
    public partial class CustomCompletion : UserControl
    {

        private static int proID;
        private Completion completion;

        [DllImport("user32", EntryPoint = "HideCaret")]
        private static extern bool HideCaret(IntPtr hWnd);

        public void CheckAns()
        {
            if (this.Answer.Text != ClientControl.GetCompletion(proID).stuAns)
            {
                ClientControl.GetCompletion(proID).stuAns = this.Answer.Text;
                ClientControl.SetDone(ClientControl.CurrentProblemNum);
            }
        }

        public void SetQuestion(int x)
        {
            proID = x;
            completion = ClientControl.GetCompletion(proID);
            this.Question.Text = completion.problem;
            this.Answer.TextChanged -= Answer_TextChanged;
            this.Answer.Text = completion.stuAns;
            this.Answer.TextChanged += Answer_TextChanged;
        }
        public int GetQuestion()
        {
            return proID;
        }
        public CustomCompletion()
        {
            InitializeComponent();
            proID = 0;
            this.SetQuestion(proID);
        }

        private void lastproblem_Click(object sender, EventArgs e)
        {
           
            if (proID >0)
            {
                this.SetQuestion(--proID);
                ClientControl.CurrentProblemNum--;
            }
            else
            {
                MessageBox.Show("这是第一题");
            }
        }

        private void nextproblem_Click(object sender, EventArgs e)
        {
           
            if (proID + 1 < ClientControl.paper.completion.Count)
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

        private void Answer_TextChanged(object sender, EventArgs e)
        {
            if (this.Answer.Text != ClientControl.GetCompletion(proID).stuAns)
            {
                this.CheckAns();
                ClientControl.GetCompletion(proID).stuAns = this.Answer.Text;
                XMLControl.WriteLogXML(ProblemType.Completion, proID, this.Answer.Text);
            }
        }
    }
}
