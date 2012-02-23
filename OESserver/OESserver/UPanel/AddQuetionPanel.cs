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
        ProModify proModify = new ProModify();
        AddPowerpoint proPPT = new AddPowerpoint();
        AddWord proWord = new AddWord();
        ProFunction proFunction = new ProFunction();
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
            plAddQuestion.Controls.Add(proModify);
            plAddQuestion.Controls.Add(proFunction);
            plAddQuestion.Controls.Add(proPPT);
            plAddQuestion.Controls.Add(proWord);

            PanelList = new List<UserPanel>();
            PanelList.Add(SingleChoice);
            PanelList.Add(fillblank);
            PanelList.Add(judge);
            PanelList.Add(proCompletion);
            PanelList.Add(proModify);
            PanelList.Add(proFunction);
            PanelList.Add(proPPT);
            PanelList.Add(proWord);

            dtQeueType = new DataTable();
            dtQeueType.Columns.Add("Type", typeof(string));
            dtQeueType.Columns.Add("Value", typeof(int));
            dtQeueType.Rows.Add(new object[2] { "选择题", 1 });
            dtQeueType.Rows.Add(new object[2] { "填空题", 2 });
            dtQeueType.Rows.Add(new object[2] { "判断题", 3 });
            dtQeueType.Rows.Add(new object[2] { "程序填空题", 4 });
            dtQeueType.Rows.Add(new object[2] { "程序改错题", 5 });
            dtQeueType.Rows.Add(new object[2] { "程序综合题", 6 });
            dtQeueType.Rows.Add(new object[2] { "PPT操作题", 7 });
            dtQeueType.Rows.Add(new object[2] { "Word操作题", 8 });
            cbQueStyle.DataSource = dtQeueType;
            cbQueStyle.DisplayMember = "Type";
            cbQueStyle.ValueMember = "Value";

            cbCourse.DataSource = InfoControl.OesData.FindAllCourse_DataSet().Tables[0];
            cbCourse.DisplayMember = "CourseName";
            cbCourse.ValueMember = "CourseId";

            cbCapater.DataSource = InfoControl.OesData.FindUnitByCourseId_DataSet(Convert.ToInt32(cbCourse.SelectedValue)).Tables[0];
            cbCapater.DisplayMember = "UnitName";
            cbCapater.ValueMember = "Unit";
          
                

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


            for (int i = 0; i < PanelList.Count; i++)
            {
                PanelList[i].Dock = DockStyle.Fill;
            }

            //    proCompletion.Dock = DockStyle.Fill;
            //SingleChoice.Dock = DockStyle.Fill;
            //fillblank.Dock = DockStyle.Fill;
            //judge.Dock = DockStyle.Fill;
            //proFunction.Dock = DockStyle.Fill;
            //proModify.Dock = DockStyle.Fill;
            
            //proCompletion.Visible = false;
            //SingleChoice.Visible = false;
            //fillblank.Visible = false;
            //judge.Visible = false;
            HidePanel();
        }

        public override void ReLoad()
        {
            HidePanel();
            this.Visible = true;

            int result;
            cbQueStyle.Enabled = true;
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
                    PanelList[result - 1].ReLoad();
                }
        }

        public int QueStyle
        {
            set
            {
                cbQueStyle.SelectedValue = value;
            }
        }
        public int  Capter
        {
            get
            {
                return Convert.ToInt32(cbCapater.SelectedValue);
            }
            set
            {
                cbCapater.SelectedValue = value;
            }

        }

   

        public int  Difficulity
        {

            get
            {
                return Convert.ToInt32( cbDifficultyValue.SelectedValue);
            }
            set 
            {
                cbDifficultyValue.SelectedValue = value;
            }
        }

        public int Teststyle
        {
            get
            {
                return Convert.ToInt32( cbQueStyle.SelectedValue) ;
            }
        }

        public override void  ReLoad(int PID, int PType)
        {
            this.Visible = true;
            this.QueStyle = PType + 1;
            PanelList[PType].ReLoad(PID);
            this.cbQueStyle.Enabled = false;
        }

        public void ChangeCb(int x)
        {
            cbQueStyle.SelectedValue = x;
        }

        private void cbCourse_TextChanged(object sender, EventArgs e)
        {
            cbCapater.DataSource = InfoControl.OesData.FindUnitByCourseId_DataSet(Convert.ToInt32(cbCourse.SelectedIndex)+1).Tables[0];
        }

        public int GetCbCourse
        {
            get
            {
                return cbCourse.SelectedIndex;

            }
            set
            {
                cbCourse.SelectedIndex = value;
            }
        }

      

      
    }
}
