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
        public static List<string> addanswer = new List<string>();
        public static List<Answer_Of_FiilBlank> panel = new List<Answer_Of_FiilBlank>();
        public AddFillBlank()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            Answer_Of_FiilBlank fillblanks = new Answer_Of_FiilBlank();
            this.flowLayoutPanel1.Controls.Add(fillblanks);
            panel.Add(fillblanks);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            int capter = (this.Parent.Parent as AddQuetionPanel).Capter;
            String diffcuty = (this.Parent.Parent as AddQuetionPanel).Difficulity;
            String teststyle = (this.Parent.Parent as AddQuetionPanel).Teststyle;
            if ( teststyle == ""||contentOfFillblank.Text=="")
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
                    InfoControl.OesData.AddCompletion(contentOfFillblank.Text, Convert.ToInt32(capter), Convert.ToInt32(diffcuty), addanswer);
                    MessageBox.Show("保存成功");
                    this.ReLoad();
                }
                else MessageBox.Show("请添加试题答案");
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定返回么？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                PanelControl.ChangPanel(0);

            }
        }

        public override void ReLoad()
        {
            this.contentOfFillblank.Text = "";
            flowLayoutPanel1.Controls.Clear();
            this.Visible = true;
        }

        public override void ReLoad(int PID)
        {
            InfoControl.OesData.FindCompletionByPID(PID);
        }

     

    }
}
