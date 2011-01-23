using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OES.UPanel;
using OES.Model;

namespace OES.UControl
{
    public partial class CompletionEdit : UserControl
    {
        ProMan aProMan;
        List<RichTextBox> AnswerList = new List<RichTextBox>();
        public CompletionEdit(ProMan pm)
        {
            InitializeComponent();
            aProMan = pm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RichTextBox temp=new RichTextBox();
            temp.Size = new Size(495, 83);
            AnswerList.Add(temp);
            flowLayoutPanel1.Controls.Add(temp);
        }

        public void fill(List<Completion> acompletion)
        {
            procon.Text = acompletion[0].problem;
            anstxt.Text = acompletion[0].ans[0];
            for (int i = 1; i < acompletion[0].ans.Count; i++)
            {
                RichTextBox temp = new RichTextBox();
                temp.Size = new Size(495, 83);
                temp.Text = acompletion[0].ans[i];
                AnswerList.Add(temp);
                flowLayoutPanel1.Controls.Add(temp);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (AnswerList.Count > 0)
            {
                flowLayoutPanel1.Controls.Remove(AnswerList[AnswerList.Count - 1]);
                AnswerList.RemoveAt(AnswerList.Count - 1);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            aProMan.bottomPanel.Show();
            aProMan.aProList.Show();
            this.Hide(); 
        }
    }
}
