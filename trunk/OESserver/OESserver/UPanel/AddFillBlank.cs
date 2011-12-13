using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OES.UPanel;
using System.Collections;
namespace OES.UPanel
{
    
    public partial class AddFillBlank : UserPanel
    {
        public static ArrayList addanswer = new ArrayList();
        public static List<Answer_Of_FiilBlank> panel = new List<Answer_Of_FiilBlank>();
        public AddFillBlank()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Answer_Of_FiilBlank fillblanks = new Answer_Of_FiilBlank();
            this.flowLayoutPanel1.Controls.Add(fillblanks);
            panel.Add(fillblanks);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            String capter = (this.Parent as AddQuetionPanel).Capter;
            String diffcuty = (this.Parent as AddQuetionPanel).Diffucity;
            String teststyle = (this.Parent as AddQuetionPanel).Teststyle;
            if (capter == "" || diffcuty == "" || teststyle == "")
            {
                MessageBox.Show("请完成试题信息");
            }


            else if (MessageBox.Show("确定提交吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                foreach (Answer_Of_FiilBlank up in panel)
                {
                     
                    if(up.Visible==true&&up.getAnser!="")
                        addanswer.Add(up.getAnser);
                }
                if (addanswer.Count > 0)
                {
                    MessageBox.Show((String)addanswer[0]);
                }
                else MessageBox.Show("请添加试题答案");
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定返回么？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

            }
        }
        public void Reset()
        {
            this.contentOfFillblank.Text = "";
        }
    }
}
