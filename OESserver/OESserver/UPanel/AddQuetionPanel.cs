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

namespace OES
{
    public partial class AddQuetionPanel : UserPanel
    {
        AddSingleChoice SingleChoice = new AddSingleChoice();
        AddFillBlank fillblank = new AddFillBlank();
        AddJudge judge = new AddJudge();
        ProCompletion proCompletion = new ProCompletion();
        List<UserPanel> PanelList = new List<UserPanel>();
        private DataTable dtQeueType;

        
        public void HidePanel()
        {
            foreach (UserPanel up in PanelList)
            {
                up.Visible = false;
            }
        }

        public AddQuetionPanel()
        {
            InitializeComponent();
            plAddQuestion.Controls.Add(SingleChoice);
            plAddQuestion.Controls.Add(fillblank);
            plAddQuestion.Controls.Add(judge);
            plAddQuestion.Controls.Add(proCompletion);

            PanelList = new List<UserPanel>();
            PanelList.Add(SingleChoice);
            PanelList.Add(fillblank);
            PanelList.Add(judge);
            PanelList.Add(proCompletion);

            dtQeueType = new DataTable();
            dtQeueType.Columns.Add("Type", typeof(string));
            dtQeueType.Columns.Add("Value", typeof(int));
            dtQeueType.Rows.Add(new object[2] { "选择题", 0 });
            dtQeueType.Rows.Add(new object[2] { "填空题", 1 });
            dtQeueType.Rows.Add(new object[2] { "判断题", 2 });
            dtQeueType.Rows.Add(new object[2] { "程序填空题", 3 });
           // dtQeueType.Rows.Add(new object[2] { "", 0 });

            cbQueStyle.DataSource = dtQeueType;
            cbQueStyle.DisplayMember = "Type";
            cbQueStyle.ValueMember = "Value";
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
            HidePanel();
            int result;
            if (Int32.TryParse(cbQueStyle.SelectedValue.ToString(), out result))
            {
                PanelList[result].ReLoad();
            }
            //flag++;
            //if (flag > 1)
            //{
            //    if (MessageBox.Show("确定切换吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //    {
            //        if (cbQueStyle.Text == "选择")
            //        {
            //            judge.Visible = false;
            //            fillblank.Visible = false;
            //            SingleChoice.Reset();
            //            SingleChoice.Show();
            //            //SingleChoice.Location = new Point(0, 120);
            //        }

            //        if (cbQueStyle.Text == "填空")
            //        {
            //            judge.Visible = false;
            //            SingleChoice.Visible = false;
            //            fillblank.Reset();
            //            fillblank.Show();
            //            // fillblank.Location = new Point(0, 120);
            //        }
            //        if (cbQueStyle.Text == "判断")
            //        {
            //            SingleChoice.Visible = false;
            //            fillblank.Visible = false;
            //            judge.Reset();
            //            judge.Show();
            //            // judge.Location = new Point(0, 120);  
            //        }
            //        if (cbQueStyle.Text == "程序填空题")
            //        {
            //            SingleChoice.Visible = false;
            //            fillblank.Visible = false;
            //            proCompletion.Visible = true;
            //            //proCompletion.Reset();
            //            proCompletion.Show();
            //            // judge.Location = new Point(0, 120);  
            //        }

            //    }
            //}
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
                return DifficultyValue.Text;
            }
        }

        public string Teststyle
        {
            get
            {
                return cbQueStyle.Text;
            }
        }










    }
}
