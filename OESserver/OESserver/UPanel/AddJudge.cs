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


namespace OES
{
    public partial class AddJudge : UserPanel
    {
        public  int flag;
        public static int proId;
        public AddJudge()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            int capter = (this.Parent.Parent as AddQuetionPanel).Capter;
            int diffcuty = (this.Parent.Parent as AddQuetionPanel).Difficulity;
          
            if (Content.Text==""  ||(True.Checked==false && Flase.Checked==false))
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
                if (flag == 0)
                {
                    InfoControl.OesData.AddJudgment(Content.Text, Answer, capter, diffcuty);
                    MessageBox.Show("保存成功");
                }
                else if (flag == 1)
                {
                    InfoControl.OesData.UpdateJudgment(proId, Content.Text, Answer, capter, diffcuty);
                    MessageBox.Show("保存成功");
                    PanelControl.ChangPanel(0);
                }
                    this.ReLoad();//重置界面
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
            flag = 0;
            this.Content.Text = "";
            this.True.Checked = false;
            this.Flase.Checked = false;
            this.Visible = true;
        }

        public override void ReLoad(int x)
        {
        
            proId = x;
            List<Judgment> judge = new List<Judgment>();
            judge = InfoControl.OesData.FindJudgmentByPID(proId);
           

            flag = 1;//将标志位变为1 进入 更改/查询 状态

            this.Content.Text = judge[0].problem;
            if (judge[0].ans == "Y")
            {
                this.True.Checked = true;
            }
            if(judge[0].ans=="N")
            {
                this.Flase.Checked = true;
            }

            this.Visible = true;
        }
       
    }
}
