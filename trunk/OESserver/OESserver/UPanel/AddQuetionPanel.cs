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
    public partial class AddQuetionPanel : UserPanel
    {
        int flag = 0;
        AddSingleChoice SingleChoice = new AddSingleChoice();
        AddFillBlank fillblank = new AddFillBlank();
        AddJudge judge = new AddJudge();
        ProCompletion proCompletion = new ProCompletion();

        public void HideAll()
        {

        }

        public AddQuetionPanel()
        {
            InitializeComponent();
            plAddQuestion.Controls.Add(SingleChoice);
            plAddQuestion.Controls.Add(fillblank);
            plAddQuestion.Controls.Add(proCompletion);

            proCompletion.Dock = DockStyle.Fill;
            SingleChoice.Dock = DockStyle.Fill;
            fillblank.Dock = DockStyle.Fill;

            proCompletion.Visible = false;
            SingleChoice.Visible = false;
            fillblank.Visible = false;

        }

        public override void ReLoad()
        {
            this.Visible = true;
        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            flag++;
            if (flag > 1)
            {
                if (MessageBox.Show("确定切换吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (QueStyle.Text == "选择")
                    {
                        judge.Visible = false;
                        fillblank.Visible = false;
                        SingleChoice.Reset();
                        SingleChoice.Show();
                        //SingleChoice.Location = new Point(0, 120);
                    }

                    if (QueStyle.Text == "填空")
                    {
                        judge.Visible = false;
                        SingleChoice.Visible = false;
                        fillblank.Reset();
                        fillblank.Show();
                        // fillblank.Location = new Point(0, 120);
                    }
                    if (QueStyle.Text == "判断")
                    {
                        SingleChoice.Visible = false;
                        fillblank.Visible = false;
                        judge.Reset();
                        judge.Show();
                        // judge.Location = new Point(0, 120);  
                    }
                    if (QueStyle.Text == "程序填空题")
                    {
                        SingleChoice.Visible = false;
                        fillblank.Visible = false;
                        proCompletion.Visible = true;
                        //proCompletion.Reset();
                        proCompletion.Show();
                        // judge.Location = new Point(0, 120);  
                    }

                }
            }
        }
        public string Capter
        {
            get
            {
                return Chapater.Text;
            }

        }

        public string Diffucity
        {
            get
            {
                return comboBox1.Text;
            }
        }

        public string Teststyle
        {
            get
            {
                return QueStyle.Text;
            }
        }










    }
}
