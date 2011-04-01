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
        List<String> paper = new List<string>();

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
            comboDept.SelectedIndex = 0;

            //在combox中显示paper信息
            //paper = InfoControl.OesData.FindAllPaper();
            //object[] obp = new object[paper.Count];
            //for (int i = 0; i < paper.Count; i++)
              //  obp[i] = paper[i];
            //comboPaper.Items.AddRange(obp);
            comboDept.SelectedIndex = 0;

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
            comboClass.Items.Add("所有学生");
            comboClass.Items.AddRange(ob);
            comboClass.SelectedIndex = 0;
        }

        private void comboDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            showClassInDept(comboDept.Text);
        }

        private void getScoreTable(List<Score> data)
        {
            dt = new DataTable("Score");
            object[] values = new object[3];
            dt.Columns.Add("姓名");
            dt.Columns.Add("班级");
            dt.Columns.Add("成绩");
            
            foreach (Score st in data)
            {
                values[0] = st.stuName;
                values[1] = st.stuClassName;
                values[2] = st.score;
                
                dt.Rows.Add(values);
            }
            DataGridViewScoreList.DataSource = dt;
            DataGridViewScoreList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataGridViewScoreList.Columns[0].FillWeight = 20;
            DataGridViewScoreList.Columns[1].FillWeight = 60;
            DataGridViewScoreList.Columns[2].FillWeight = 20;


            DataGridViewScoreList.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            DataGridViewScoreList.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            DataGridViewScoreList.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            //studentInfoDGV.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            //studentInfoDGV.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
            //studentInfoDGV.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
            //studentInfoDGV.Columns[6].SortMode = DataGridViewColumnSortMode.NotSortable;

           // DataGridViewScoreList.Columns[3].Visible = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string Class = comboClass.SelectedItem.ToString();
            string Paper = comboPaper.SelectedItem.ToString();
           // MessageBox.Show(comboClass.SelectedItem);
            MessageBox.Show(Paper);
            getScoreTable(InfoControl.OesData.FindScoreByClassPaper(Class, Paper));

        }

    }
}
