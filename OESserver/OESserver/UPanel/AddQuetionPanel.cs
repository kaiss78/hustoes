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
        //声明每种试题的控件
        AddSingleChoice SingleChoice = new AddSingleChoice();
        AddFillBlank fillblank = new AddFillBlank();
        AddJudge judge = new AddJudge();
        ProCompletion proCompletion = new ProCompletion();
        ProModify proModify = new ProModify();
        AddPowerpoint proPPT = new AddPowerpoint();
        AddWord proWord = new AddWord();
        AddExcel proExcel = new AddExcel();
        ProFunction proFunction = new ProFunction();
        //用于存储每个控件的集合
        List<UserPanel> PanelList = new List<UserPanel>();
        //添加数据表格 数据表中有两列，一列 dispaly 一列 value
        private DataTable dtQeueType;
        private DataTable dtUnit=new DataTable();
        private DataTable dtDiffcult=new DataTable();
        
        //隐藏panel中的所有控件 
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
            //在addquestion控件中存在一个pladdquestion 的panel
            plAddQuestion.Controls.Add(SingleChoice);
            plAddQuestion.Controls.Add(fillblank);
            plAddQuestion.Controls.Add(judge);
            plAddQuestion.Controls.Add(proCompletion);
            plAddQuestion.Controls.Add(proModify);
            plAddQuestion.Controls.Add(proFunction);
            plAddQuestion.Controls.Add(proPPT);
            plAddQuestion.Controls.Add(proWord);
            plAddQuestion.Controls.Add(proExcel);

            PanelList = new List<UserPanel>();
            //把每个控件添加到PanelList中
            PanelList.Add(SingleChoice);
            PanelList.Add(fillblank);
            PanelList.Add(judge);
            PanelList.Add(proCompletion);
            PanelList.Add(proModify);
            PanelList.Add(proFunction);
            PanelList.Add(proPPT);
            PanelList.Add(proWord);
            PanelList.Add(proExcel);

            dtQeueType = new DataTable();
            //在dtQeueType数据表中添加两列，用于确定试题类型
            dtQeueType.Columns.Add("Type", typeof(string));//第二个属性声明该之的类型
            dtQeueType.Columns.Add("Value", typeof(int));
            dtQeueType.Rows.Add(new object[2] { "选择题", 1 });
            dtQeueType.Rows.Add(new object[2] { "填空题", 2 });
            dtQeueType.Rows.Add(new object[2] { "判断题", 3 });
            dtQeueType.Rows.Add(new object[2] { "程序填空题", 4 });
            dtQeueType.Rows.Add(new object[2] { "程序改错题", 5 });
            dtQeueType.Rows.Add(new object[2] { "程序综合题", 6 });
            dtQeueType.Rows.Add(new object[2] { "PPT操作题", 7 });
            dtQeueType.Rows.Add(new object[2] { "Word操作题", 8 });
            dtQeueType.Rows.Add(new object[2] { "Excel操作题", 9 });
            cbQueStyle.DataSource = dtQeueType;
            //displayMember为显示的值
            cbQueStyle.DisplayMember = "Type";
            
            cbQueStyle.ValueMember = "Value";

            //返回一个dataset 用于确定课程 
            cbCourse.DataSource = InfoControl.OesData.FindAllCourse_DataSet().Tables[0];
            cbCourse.DisplayMember = "CourseName";
            cbCourse.ValueMember = "CourseId";

            //返回一个dataset 用于确定章节
            cbCapater.DataSource = InfoControl.OesData.FindUnitByCourseId_DataSet(Convert.ToInt32(cbCourse.SelectedValue)).Tables[0];
            cbCapater.DisplayMember = "UnitName";
            cbCapater.ValueMember = "Unit";
          
                
            //难度数据表
            dtDiffcult.Columns.Add("diffcult", typeof(string));
            dtDiffcult.Columns.Add("value", typeof(int));
            dtDiffcult.Rows.Add(new object[2] { "1", 1 });
            dtDiffcult.Rows.Add(new object[2] { "2", 2 });
            dtDiffcult.Rows.Add(new object[2] { "3", 3 });
            dtDiffcult.Rows.Add(new object[2] { "4", 4 });
            dtDiffcult.Rows.Add(new object[2] { "5", 5 });
            cbDifficultyValue.DataSource = dtDiffcult;
            cbDifficultyValue.DisplayMember = "diffcult";
            cbDifficultyValue.ValueMember = "value";


            //每个控件的都要fix这个panel
            for (int i = 0; i < PanelList.Count; i++)
            {
                PanelList[i].Dock = DockStyle.Fill;
            }

    
            HidePanel();
        }

        //进入被选择的页面
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

        

        //查找试题
        public override void  ReLoad(int PID, int PType,int Course,String Chapter,int level)
        {
            this.Visible = true;
            this.QueStyle = PType + 1;
            //Ptype为试题的类型 PId为题目的编号
            PanelList[PType].ReLoad(PID);
            this.cbQueStyle.Enabled = false;
            this.cbCourse.SelectedIndex = Course;
            this.cbCapater.Text = Chapter;
            this.cbDifficultyValue.SelectedIndex = level-1;
        }

     

         //当课程更改是，对应的章节也随着变动

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
