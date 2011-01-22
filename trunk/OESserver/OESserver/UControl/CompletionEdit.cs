using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OES.UPanel;

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
