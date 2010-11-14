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
            if (proID + 1 < ClientControl.paper.completion.Count)
            {
                this.SetQuestion(++proID);
            }
            else
            {
                MessageBox.Show("这是最后一题");
            }
        }

        private void Answer_richbox_TextChanged(object sender, EventArgs e)
        {
            ClientControl.GetCompletion(proID).stuAns = this.Answer.Text;
        }
    }
}
