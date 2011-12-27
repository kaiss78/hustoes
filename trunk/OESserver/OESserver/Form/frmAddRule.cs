using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OES.Model;

namespace OES
{
    public partial class frmAddRule : Form
    {
        private DataTable dtChapter;
        private DataView dvChapter;
        public DataTable dtCourse;
        private DataTable dtPType;
        public PaperRule NewRule;

        private void Init()
        {
            dtCourse = InfoControl.OesData.FindAllCourse_DataSet().Tables[0];
            cboCourse.DataSource = dtCourse;
            cboCourse.DisplayMember = "CourseName";
            cboCourse.ValueMember = "CourseId";
            cboCourse.SelectedIndexChanged += new System.EventHandler(this.cboCourse_SelectedIndexChanged);            

            dtChapter = InfoControl.OesData.FindAllUnit_DataSet().Tables[0];
            dvChapter = new DataView(dtChapter);
            cboChapterList.DataSource = dvChapter;
            cboChapterList.DisplayMember = "UnitName";
            cboChapterList.ValueMember = "Unit";

            dtPType = new DataTable();
            dtPType.Columns.Add("PType");
            dtPType.Columns.Add("Value");
            dtPType.Rows.Add(new object[2] { "选择题", 0 });
            dtPType.Rows.Add(new object[2] { "填空题", 1 });
            dtPType.Rows.Add(new object[2] { "判断题", 2 });
            dtPType.Rows.Add(new object[2] { "Word题", 3 });
            dtPType.Rows.Add(new object[2] { "Excel题", 4 });
            dtPType.Rows.Add(new object[2] { "PowerPoint题", 5 });
            dtPType.Rows.Add(new object[2] { "C程序填空题", 6 });
            dtPType.Rows.Add(new object[2] { "C程序改错题", 7 });
            dtPType.Rows.Add(new object[2] { "C程序综合题", 8 });
            dtPType.Rows.Add(new object[2] { "C++程序填空题", 9 });
            dtPType.Rows.Add(new object[2] { "C++程序改错题", 10 });
            dtPType.Rows.Add(new object[2] { "C++程序综合题", 11 });
            dtPType.Rows.Add(new object[2] { "VB程序填空题", 12 });
            dtPType.Rows.Add(new object[2] { "VB程序改错题", 13 });
            dtPType.Rows.Add(new object[2] { "VB程序综合题", 14 });

            cboPType.DataSource = dtPType;
            cboPType.DisplayMember = "PType";
            cboPType.ValueMember = "Value";
        }

        public frmAddRule()
        {         
            InitializeComponent();
            Init();
        }

        public frmAddRule(PaperRule rule)
        {
            InitializeComponent();
            Init();
            nupdCount.Value = rule.Count;
            nupdPLevel.Value = rule.PLevel;
            nupdScore.Value = rule.Score;
            cboChapterList.SelectedIndex = dtChapter.Rows.IndexOf(dtChapter.Select("UnitName=\'" + rule.ChapterName + "\'").First());
            cboPType.SelectedIndex = dtPType.Rows.IndexOf(dtPType.Select("PType=\'" + rule.PTypeName + "\'").First());
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            NewRule = new PaperRule();
            NewRule.Chapter = Convert.ToInt32(cboChapterList.SelectedValue);
            NewRule.Course = Convert.ToInt32(cboCourse.SelectedValue);
            NewRule.PType = (ProblemType)(Convert.ToInt32(cboPType.SelectedValue));
            NewRule.PLevel = (int)nupdPLevel.Value;
            NewRule.Score = (int)nupdScore.Value;
            NewRule.Count = (int)nupdCount.Value;
            
            NewRule.ChapterName = dtChapter.Rows[cboChapterList.SelectedIndex][0].ToString();
            NewRule.PTypeName = dtPType.Rows[cboPType.SelectedIndex][0].ToString();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            NewRule = null;
            this.Close();
        }


        private void cboCourse_SelectedIndexChanged(object sender, EventArgs e)
        {            
            if (cboCourse.SelectedValue != null)
            {
                dvChapter.RowFilter = "CourseId=" + cboCourse.SelectedValue;
            }
        }
    }


}
