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
            String diffcuty = (this.Parent.Parent as AddQuetionPanel).Diffucity;
            String teststyle = (this.Parent.Parent as AddQuetionPanel).Teststyle;
            if (textBox1.Text==""||capter == "" || diffcuty == "" || teststyle == ""||radioButton1.Checked==false||radioButton2.Checked==false)
            {
                MessageBox.Show("请完成试题信息");
            }


            else if (MessageBox.Show("确定提交吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定返回么？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

            }
        }


        public override void  ReLoad()
        {
            this.textBox1.Text = "";
            this.radioButton1.Checked = false;
            this.radioButton2.Checked = false;
            this.Visible = true;
        }

       
    }
}
