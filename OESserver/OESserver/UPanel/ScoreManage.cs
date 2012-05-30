using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OES.Model;

namespace OES.UPanel
{
    public partial class ScoreManage : UserPanel
    {

        List<String> dps = new List<string>();
        List<String> cls = new List<string>();
        List<String> exams = new List<string>();

        private DataTable dt;

        public ScoreManage()
        {
            InitializeComponent();
           
        }

        public override void ReLoad()
        {
            this.Visible = true;
            DataGridViewScoreList.Visible = true;
            //将显示学院信息
            if (InfoControl.User.permission == 1)           //admin
                dps = InfoControl.OesData.FindAllDept();
            else
                dps = InfoControl.OesData.FindAllDeptWithTeacher(InfoControl.User.UserName);
            object[] ob = new object[dps.Count];
            for (int i = 0; i < dps.Count; i++)
                ob[i] = dps[i];
            comboDept.Items.AddRange(ob);
            #region unused
            //comboDept.SelectedIndex = 0;
            //在combox中显示paper信息
            //paper = InfoControl.OesData.FindAllPaper();
            //object[] obp = new object[paper.Count];
            //for (int i = 0; i < paper.Count; i++)
              //  obp[i] = paper[i];
            //comboPaper.Items.AddRange(obp);
            #endregion
            comboDept.SelectedIndex = 0;
        }

        private void showExamInClass(string className)
        {
            exams = InfoControl.OesData.FindExamByClass(className);
            object[] ob = new object[exams.Count];
            for (int i = 0; i < exams.Count; i++)
                ob[i] = exams[i];
            comboExam.Items.Clear();
            comboExam.Items.AddRange(ob);
            if (comboExam.Items.Count > 0)
                comboExam.SelectedIndex = 0;
            else
                comboExam.SelectedIndex = -1;
        }

        private void showClassInDept(string dept)
        {
            if (InfoControl.User.permission == 1)
                cls = InfoControl.OesData.FindClassNameOfDept(dept);
            else
                cls = InfoControl.OesData.FindClassNameOfDeptWithTeacher(dept, InfoControl.User.UserName);
            object[] ob = new object[cls.Count];
            for (int i = 0; i < cls.Count; i++)
                ob[i] = cls[i];
            comboClass.Items.Clear();
            comboClass.Items.AddRange(ob);
            if (comboClass.Items.Count > 0)
                comboClass.SelectedIndex = 0;
            else
                comboClass.SelectedIndex = -1;
        }

        private void comboDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            showClassInDept(comboDept.Text);
        }

        private void comboClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            showExamInClass(comboClass.Text);
        }

        private void getScoreTable(List<Score> data)
        {
            dt = new DataTable("Score");
            object[] values = new object[6];
            dt.Columns.Add("班级");
            dt.Columns.Add("学号");
            dt.Columns.Add("姓名");
            dt.Columns.Add("考试名称");
            dt.Columns.Add("试卷名称");
            dt.Columns.Add("成绩");
            
            foreach (Score st in data)
            {
                values[0] = st.stuClassName;
                values[1] = st.studentID;
                values[2] = st.stuName;
                values[3] = st.examName;
                values[4] = st.paperTitle;
                values[5] = st.Value;
                dt.Rows.Add(values);
            }
            DataGridViewScoreList.DataSource = dt;
            DataGridViewScoreList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataGridViewScoreList.Columns[0].FillWeight = 20;
            DataGridViewScoreList.Columns[1].FillWeight = 15;
            DataGridViewScoreList.Columns[2].FillWeight = 10;
            DataGridViewScoreList.Columns[3].FillWeight = 20;
            DataGridViewScoreList.Columns[4].FillWeight = 25;
            DataGridViewScoreList.Columns[5].FillWeight = 10;

            foreach (DataGridViewColumn col in DataGridViewScoreList.Columns)
                col.SortMode = DataGridViewColumnSortMode.Automatic;
        }
        private void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                string Class = comboClass.SelectedItem.ToString();
                string Exam = comboExam.SelectedItem.ToString();
                // MessageBox.Show(comboClass.SelectedItem);
                // MessageBox.Show(Paper);
                getScoreTable(InfoControl.OesData.FindScoreByClassExam(Class, Exam));
            }
            catch
            {
                MessageBox.Show("未选择正确试卷");
            }
        }

    }
}
