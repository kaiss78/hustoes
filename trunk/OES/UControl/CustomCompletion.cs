using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace OES.UControl
{
    public partial class CustomCompletion : UserControl
    {

        static int proID;
        [DllImport("user32", EntryPoint = "HideCaret")]
        private static extern bool HideCaret(IntPtr hWnd);

        public void CheckAns()
        {
            if (this.Answer.Text != ClientControl.GetCompletion(proID).stuAns)
            {
                ClientControl.GetCompletion(proID).stuAns = this.Answer.Text;
            }
        }

        public void SetQuestion(int proID)
        {
            this.Question.Text=ClientControl.GetCompletion(proID).problem;
            this.Answer.Text = ClientControl.GetCompletion(proID).stuAns;
        }

        public CustomCompletion()
        {
            InitializeComponent();
            proID = 0;
            this.SetQuestion(proID);
        }

        private void lastproblem_Click(object sender, EventArgs e)
        {
            this.CheckAns();
            if (proID >0)
            {
                this.SetQuestion(--proID);
            }
            else
            {
                MessageBox.Show("这是第一题");
            }
        }

        private void nextproblem_Click(object sender, EventArgs e)
        {
            this.CheckAns();
            if (proID + 1 < ClientControl.paper.completion.Count)
            {
                this.SetQuestion(++proID);
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
    }
}
