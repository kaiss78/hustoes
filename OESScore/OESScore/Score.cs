using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using OES.Model;

namespace OESScore
{
    public partial class formScore : Form
    {
        private DataTable ScoreTable=new DataTable();
        private string folderpath;
        private List<StuAns> AnsList = new List<StuAns>();

        public formScore(string path)
        {
            InitializeComponent();
            folderpath = path;
            InitTable();
        }

        public void InitDT()
        {
            ScoreTable = new DataTable("ScoreTable");            
            ScoreTable.Columns.Add("学号");
            ScoreTable.Columns.Add("姓名");
            ScoreTable.Columns.Add("成绩");            
        }

        public void InitTable()
        {
            List<DirectoryInfo> anslist = ScoreControl.GetFolderInfo(folderpath);
            object[] values = new object[3];
            StuAns tmpSA;
            List<Student> tmpS;
            InitDT();


            foreach (DirectoryInfo ans in anslist)
            {                
                tmpS = ScoreControl.OesData.FindStudentByStudentId(ans.Name);
                if (tmpS != null)
                {
                    tmpSA = new StuAns();
                    tmpSA.StuInfo = tmpS[0];
                    tmpSA.Score = 0;
                    values[0] = tmpSA.StuInfo.ID;
                    values[1] = tmpSA.StuInfo.sName;
                    values[2] = tmpSA.Score;
                    ScoreTable.Rows.Add(values);
                }
            }

            dgvPaperTable.DataSource = ScoreTable;
            //dgvPaperTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //dgvPaperTable.Columns[0].FillWeight =10;
            //dgvPaperTable.Columns[1].FillWeight = 20;
            //dgvPaperTable.Columns[2].FillWeight = 45;

            //dgvPaperTable.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            //dgvPaperTable.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            //dgvPaperTable.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;

        }
    }
}
