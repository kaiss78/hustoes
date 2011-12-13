using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OES.Model;
using OES.keyandValue;


namespace OES.UPanel
{
    public partial class QuesBankForm : UserPanel
    {
        private DataTable questionTable;
        public List<Problem> problemList;
        public List<Unit> unitList;
        public List<ListItem> listItem = new List<ListItem>();

        public void InitCombUnit()
        {
            //ListItem cmpList;

            unitList = InfoControl.OesData.FindAllUnit();

            listItem.Add(new ListItem("-1","全部"));
            for (int i = 0; i < unitList.Count; i++)
                listItem.Add(new ListItem(Convert.ToString(unitList[i].UnitId), Convert.ToString(unitList[i].UnitName)));

            //for (int i = 0; i < listItem.Count; i++)
            //{
            //    cmpList = listItem[i];
            //    for (int j = i + 1; j < unitList.Count; j++)
            //    {
            //        if (listItem[i].value.Length > listItem[j].value.Length)
            //        {
            //            listItem[i] = listItem[j];
            //            listItem[j] = cmpList;
            //            cmpList = listItem[i];
            //        }
            //    }
            //}

            for(int i=0;i<unitList.Count;i++)
                this.comboBox2.Items.Add(listItem[i]);

            this.comboBox2.DisplayMember = "value";
            this.comboBox2.ValueMember = "key";

        }

        public void InitCombPage(int problemNum)
        {
            int i = 1;
            int pageNum=0;
            if (pageNum % 12 != 0)
                pageNum = problemNum / 12 + 1;
            else
                pageNum = problemNum / 12;

            String num = "第" + "'"+i+"'" + "页";
            for (; i <= pageNum; i++)
                this.comboBox4.Items.Add(num);
        }

        public void InitDT()
        {
            questionTable = new DataTable("questionlist");
            questionTable.Columns.Add("选择",typeof(bool));
            questionTable.Columns.Add("题目ID");
            questionTable.Columns.Add("题干");
            questionTable.Columns.Add("章节");
            questionTable.Columns.Add("难度");

        }

        public void InitList(int pattern,int unit,int difficulty,String pointwords,int pageIndex)
        {
            InitDT();
            
            
            object[] values = new object[5];
            problemList = new List<Problem>();
            //switch (pattern)
            //{
            //    case 0: problemList = InfoControl.OesData.FindAllChoice(pointwords,unit,difficulty,pageIndex,12); break;
            //    case 1: problemList = InfoControl.OesData.FindAllCompletion(pointwords,unit,difficulty,pageIndex,12); break;
            //    case 2: problemList = InfoControl.OesData.FindAllJudgment(pointwords,unit,difficulty,pageIndex,12); break;
            //}

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

            InitCombUnit();

            this.comboBox1.SelectedIndex = 0;
            this.comboBox2.SelectedIndex = 0;
            this.comboBox3.SelectedIndex = 0;
        }

    
        public override void ReLoad()
        {
            this.Visible = true;
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
        
        private void button3_Click(object sender, EventArgs e)
        {
            ListItem aList = (ListItem)this.comboBox2.SelectedItem;
            String pointWords = this.textBox1.Text;
            InitList(this.comboBox1.SelectedIndex,Convert.ToInt32(aList.key),this.comboBox3.SelectedIndex-1,pointWords,1);

        }

       
        
    }
}
