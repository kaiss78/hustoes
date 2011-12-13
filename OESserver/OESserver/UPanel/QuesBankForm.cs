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
    public partial class QuesBankForm : UserPanel
    {
        private DataTable questionTable;
        public List<Problem> problemList;

        public void InitDT()
        {
            questionTable = new DataTable("questionlist");
            questionTable.Columns.Add("选择",typeof(bool));
            questionTable.Columns.Add("题目ID");
            questionTable.Columns.Add("题干");
            questionTable.Columns.Add("章节");
            questionTable.Columns.Add("难度");

        }

        public void InitList(int n)
        {
            InitDT();
            object[] values = new object[5];

            switch (n)
            {
                case 0: problemList = InfoControl.OesData.FindAllChoice("",-1,-1); break;
                case 1: problemList = InfoControl.OesData.FindAllCompletion("",-1,-1); break;
                case 2: problemList = InfoControl.OesData.FindAllJudgment("",-1,-1); break;
            }

            for (int i = 0; i < problemList.Count; i++)
            {
                values[0] = false;
                values[1] = problemList[i].problemId;
                values[2] = problemList[i].problem;
                
                questionTable.Rows.Add(values);
            }

            ProblemDGV.DataSource = questionTable;
            ProblemDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            ProblemDGV.Columns[0].FillWeight = 5;
            ProblemDGV.Columns[1].FillWeight = 5;
            ProblemDGV.Columns[2].FillWeight = 20;
            ProblemDGV.Columns[3].FillWeight = 10;
            ProblemDGV.Columns[4].FillWeight = 8;

            ProblemDGV.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            ProblemDGV.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            ProblemDGV.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            ProblemDGV.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            ProblemDGV.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;


        }

        public QuesBankForm()
        {
            InitializeComponent();

        }

        public override void ReLoad()
        {
            this.Visible = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBox1.SelectedIndex == 0)
                InitList(0);
            if (this.comboBox1.SelectedIndex == 1)
                InitList(1);
            if (this.comboBox1.SelectedIndex == 2)
                InitList(2);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            PanelControl.ChangPanel(8);
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void ProblemDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int theIndex = e.RowIndex;
            if (theIndex > -1)
            {
                questionTable.Rows[theIndex][0] = !Convert.ToBoolean(questionTable.Rows[theIndex][0]);
            }
        }

       
    }
}
