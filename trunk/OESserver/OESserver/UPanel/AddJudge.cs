using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OES.UPanel;

namespace OES
{
    public partial class AddJudge : UserPanel
    {
        public AddJudge()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            String capter = (this.Parent.Parent as AddQuetionPanel).Capter;
            String diffcuty = (this.Parent.Parent as AddQuetionPanel).Difficulity;
            String teststyle = (this.Parent.Parent as AddQuetionPanel).Teststyle;
            if (Content.Text==""||capter == "" || diffcuty == "" || teststyle == ""||(True.Checked==false && Flase.Checked==false))
            {
                MessageBox.Show("请完成试题信息");
            }


            else if (MessageBox.Show("确定提交吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                String Answer;
      

                if (True.Checked == true)
                    Answer = "Y";

                else
                    Answer = "N";
                InfoControl.OesData.AddJudgment(Content.Text, Answer, Convert.ToInt32(capter), Convert.ToInt32(diffcuty));
                MessageBox.Show("保存成功");
                this.ReLoad();
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定返回么？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                PanelControl.ChangPanel(0);
                
            }
        }


        public override void  ReLoad()
        {
            this.Content.Text = "";
            this.True.Checked = false;
            this.Flase.Checked = false;
            this.Visible = true;
        }

       
    }
}
