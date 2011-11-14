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
using OES.XMLFile;

namespace OESScore
{
    public partial class formScore : Form
    {
        private DataTable ScoreTable = new DataTable();
        private string folderpath;
        private List<StuFolder> StuList = new List<StuFolder>();

        public formScore(string path)
        {
            InitializeComponent();
            folderpath = path;
            InitTable();
        }


        /// <summary>
        /// 初始化表格
        /// </summary>
        public void InitDT()
        {
            ScoreTable = new DataTable("ScoreTable");
            ScoreTable.Columns.Add("学号");
            ScoreTable.Columns.Add("姓名");
            ScoreTable.Columns.Add("成绩");
        }



        /// <summary>
        /// 填充表格数据
        /// </summary>
        public void InitTable()
        {
            List<DirectoryInfo> anslist = ScoreControl.GetFolderInfo(folderpath);
            StuList = new List<StuFolder>();
            object[] values = new object[3];
            StuFolder tmpSA;
            List<Student> tmpS;
            InitDT();
            foreach (DirectoryInfo ans in anslist)
            {
                tmpS = ScoreControl.OesData.FindStudentByStudentId(ans.Name);
                if (tmpS != null)
                {
                    tmpSA = new StuFolder();
                    tmpSA.StuInfo = tmpS[0];
                    tmpSA.Score = new Score();
                    tmpSA.Score.score = "0";
                    tmpSA.path = ans;
                    tmpSA.StuAns = new StaAns();
                    tmpSA.StuAns.Ans = ScoreControl.GetStuAns(ans.FullName);
                    if (File.Exists(ans.FullName + "\\Result.xml"))
                    {
                        tmpSA.ReadResult(ans.FullName + "\\Result.xml");
                    }
                    StuList.Add(tmpSA);
                    values[0] = tmpSA.StuInfo.ID;
                    values[1] = tmpSA.StuInfo.sName;

                    values[2] = tmpSA.Score.score;
                    ScoreTable.Rows.Add(values);
                }
            }

            dgvPaperTable.DataSource = ScoreTable;
            dgvPaperTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvPaperTable.Columns[0].FillWeight = 10;
            dgvPaperTable.Columns[1].FillWeight = 20;
            dgvPaperTable.Columns[2].FillWeight = 45;

            dgvPaperTable.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvPaperTable.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvPaperTable.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        public void MarkAll()
        {
            for (int i = 0; i < StuList.Count; i++)
            {
                Mark(i);
            }
        }

        public int Mark(int RIndex)
        {
            int Score = 0, dScore = 0;
            StuList[RIndex].Score.sum = new List<Sum>();
            XMLControl.CreateScoreXML(StuList[RIndex].path.FullName + "\\Result.xml", ScoreControl.staAns.PaperID, StuList[RIndex].StuInfo.ID);
            foreach (Answer ans in StuList[RIndex].StuAns.Ans)
            {
                dScore = 0;
                if ((ScoreControl.staAns.Ans[ans.ID].Ans.Split('\n').Contains(ans.Ans)))
                {
                    dScore = ScoreControl.staAns.Ans[ans.ID].Score;

                }
                StuList[RIndex].Score.addDetail(ans.Type, dScore);
                XMLControl.AddScore(ans.Type, ScoreControl.staAns.Ans[ans.ID].ID, dScore);
            }
            return Score;
        }

        private void dgvPaperTable_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int RIndex = dgvPaperTable.CurrentRow.Index;
            if (RIndex > -1)
            {
                MessageBox.Show(Mark(RIndex).ToString());
            }
        }
    }
}
