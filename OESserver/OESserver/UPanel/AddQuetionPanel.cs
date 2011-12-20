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
using OES.Model;

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
        private DataTable dtUnit=new DataTable();
        private DataTable dtDiffcult=new DataTable();

        
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
            dtQeueType.Rows.Add(new object[2] { "选择题", 1 });
            dtQeueType.Rows.Add(new object[2] { "填空题", 2 });
            dtQeueType.Rows.Add(new object[2] { "判断题", 3 });
            dtQeueType.Rows.Add(new object[2] { "程序填空题", 4 });
           // dtQeueType.Rows.Add(new object[2] { "", 0 });
            cbQueStyle.DataSource = dtQeueType;
            cbQueStyle.DisplayMember = "Type";
            cbQueStyle.ValueMember = "Value";
            dtUnit.Columns.Add("Unit", typeof(string));
            dtUnit.Columns.Add("Value", typeof(int));
            dtUnit.Rows.Add(new object[2] { "第一章", 1 });
            dtUnit.Rows.Add(new object[2] { "第二章" ,2 });
            dtUnit.Rows.Add(new object[2] { "第三章", 3 });
            dtUnit.Rows.Add(new object[2] { "第四章", 4 });
            dtUnit.Rows.Add(new object[2] { "第五章", 5 });
            dtUnit.Rows.Add(new object[2] { "第六章", 6 });
            dtUnit.Rows.Add(new object[2] { "第七章", 7 });
            cbCapater.DataSource = dtUnit;
            cbCapater.DisplayMember = "Unit";
            cbCapater.ValueMember = "Value";

            dtDiffcult.Columns.Add("diffcult", typeof(string));
            dtDiffcult.Columns.Add("value", typeof(int));
            dtDiffcult.Rows.Add(new object[2]{"1",1 });
            dtDiffcult.Rows.Add(new object[2] { "2", 2});
            dtDiffcult.Rows.Add(new object[2] { "3",3 });
            dtDiffcult.Rows.Add(new object[2] { "4",4 });
            dtDiffcult.Rows.Add(new object[2] { "5", 5});
            cbDifficultyValue.DataSource = dtDiffcult;
            cbDifficultyValue.DisplayMember = "diffcult";
            cbDifficultyValue.ValueMember = "value";
            proCompletion.Dock = DockStyle.Fill;
            SingleChoice.Dock = DockStyle.Fill;
            fillblank.Dock = DockStyle.Fill;
            judge.Dock = DockStyle.Fill;
       
            proCompletion.Visible = false;
            SingleChoice.Visible = false;
            fillblank.Visible = false;
            judge.Visible = false;

        }

        public override void ReLoad()
        {
            this.Visible = true;
            HidePanel();
            int result;
            if (Int32.TryParse(cbQueStyle.SelectedValue.ToString(), out result))
            {
                PanelList[result - 1].ReLoad();
            }
        }

        private void cbQueStyle_TextChanged(object sender, EventArgs e)
        {
            HidePanel();
            int result;
            if (Int32.TryParse(cbQueStyle.SelectedValue.ToString(), out result))
            {
                PanelList[result-1].ReLoad();
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
                return cbCapater.SelectedValue.ToString();
            }

        }

        public string Difficulity
        {
            get
            {
                return cbDifficultyValue.SelectedValue.ToString();
            }
        }

        public string Teststyle
        {
            get
            {
                return cbQueStyle.SelectedValue.ToString();
            }
        }
        public static void  CheckQue(int style,int ID)
        { 

        }
    }
}
