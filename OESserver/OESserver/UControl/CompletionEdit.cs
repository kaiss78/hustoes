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
        public bool isnew = false;

        public CompletionEdit(ProMan pm)
        {
            InitializeComponent();
            aProMan = pm;
            RichTextBox temp = new RichTextBox();
            temp.Size = new Size(495, 83);
            AnswerList.Add(temp);
            flowLayoutPanel1.Controls.Add(temp);
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
            chptlbl.Text = ChptList.click_name;
            procon.Text = acompletion[0].problem;

            flowLayoutPanel1.Controls.Remove(AnswerList[AnswerList.Count - 1]);
            AnswerList.Clear();
            for (int i = 0; i < acompletion[0].ans.Count; i++)
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
            aProMan.titlePanel.Show();
            aProMan.aProList.Show();
            this.Hide(); 
        }

        //提取标准答案
        private List<string> AnswerString()
        {
            List<string> aList = new List<string>();
            for (int i = 0; i < AnswerList.Count; i++)
            {
                aList.Add(AnswerList[i].Text);
            }
            return aList;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!isnew)
            {
                InfoControl.OesData.UpdateCompletion(ProList.click_proid, procon.Text, Convert.ToInt32(ChptList.click_num), AnswerString());
            }
            else
            {
                InfoControl.OesData.AddCompletion(procon.Text,"", Convert.ToInt32(ChptList.click_num), AnswerString());
            }
            
            MessageBox.Show("保存成功！");
            aProMan.bottomPanel.Show();
            aProMan.titlePanel.Show();
            this.Hide();
            aProMan.aChptList.newpl();
        }
    }
}
