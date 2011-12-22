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
        public List<Problem> problemList = new List<Problem>();
        public List<Unit> unitList;
        public List<ListItem> listItem = new List<ListItem>();
        public int quesNum;
        public ListItem aList;
        public String pointWords;
        public int pageNum = 0;

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
            int i = 2;
            String num = "第1页";

            if (problemNum != 0)
            {
                this.comboBox4.Items.Add(num);
                this.comboBox4.SelectedIndex = 0;
            }

            if (problemNum % 20 != 0)
                pageNum = problemNum / 20 + 1;
            else
                pageNum = problemNum / 20;

            for (; i <= pageNum; i++)
            {
                num = "第" + "" + i + "" + "页";
                this.comboBox4.Items.Add(num);
            }
            
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
            String tableName="";    
            object[] values = new object[5];

            if (difficulty == 0)
                difficulty = -1;
            
            switch (pattern)
            {
                case 0: {
                    tableName = "Choice";
                    List<Choice> choiceList = InfoControl.OesData.FindAllChoice(pointwords, unit, difficulty, pageIndex, 20);
                    for (int i = 0; i < choiceList.Count; i++)
                        problemList.Add(choiceList[i]);

                    quesNum = InfoControl.OesData.FindItemsCount(tableName, pointwords, unit, difficulty, -1, -1);

                } break;
                case 1: {
                    tableName = "Completion";
                    List<Completion> completionList = InfoControl.OesData.FindAllCompletion(pointwords, unit, difficulty, pageIndex, 20);
                    for (int i = 0; i < completionList.Count; i++)
                        problemList.Add(completionList[i]);

                    quesNum = InfoControl.OesData.FindItemsCount(tableName, pointwords, unit, difficulty, -1, -1);
                    
                }  break;
                case 2: {
                    tableName = "Judgment";
                    List<Judgment> judgmentList = InfoControl.OesData.FindAllJudgment(pointwords, unit, difficulty, pageIndex, 20);
                    for(int i=0;i<judgmentList.Count;i++)
                        problemList.Add(judgmentList[i]);

                    quesNum = InfoControl.OesData.FindItemsCount(tableName, pointwords, unit, difficulty, -1, -1);
                    
                }  break;
                case 3: {
                    tableName = "Program";
                    List<ProgramProblem> programList = InfoControl.OesData.FindAllProgram(pointwords, ProgramPType.Completion, PLanguage.Null, unit, difficulty, pageIndex, 20);
                    for (int i = 0; i < programList.Count; i++)
                        programList.Add(programList[i]);

                    quesNum = InfoControl.OesData.FindItemsCount(tableName, pointwords, unit, difficulty, 0, -1);

                } break;
            }


            for (int i = 0; i < problemList.Count; i++)
            {
                values[0] = false;
                values[1] = problemList[i].problemId;
                values[2] = problemList[i].problem;
                values[3] = problemList[i].unit.UnitName;
                values[4] = problemList[i].Plevel;
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

            problemList.Clear();
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
            //AddQuetionPanel.CheckQue(this.comboBox1.SelectedIndex,Convert.ToInt32(this.ProblemDGV.Rows[Convert.ToInt32(this.ProblemDGV.SelectedRows)].Cells[1].Value));
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.ProblemDGV.Rows.Count; i++)
            {
                if(Convert.ToBoolean(this.ProblemDGV.Rows[i].Cells[0].Value)==true)
                    switch (this.comboBox1.SelectedIndex)
                    {
                        case 0: InfoControl.OesData.DeleteChoice(Convert.ToInt32(ProblemDGV.Rows[i].Cells[1].Value)); break;
                        case 1: InfoControl.OesData.DeleteCompletion(Convert.ToInt32(this.ProblemDGV.Rows[i].Cells[1].Value)); break;
                        case 2: InfoControl.OesData.DeleteJudgment(Convert.ToInt32(this.ProblemDGV.Rows[i].Cells[1].Value)); break;
                    }
               
            }
            aList = (ListItem)this.comboBox2.SelectedItem;
            pointWords = this.textBox1.Text;

            InitList(this.comboBox1.SelectedIndex, Convert.ToInt32(aList.key), this.comboBox3.SelectedIndex, pointWords, 1);
            this.comboBox4.Items.Clear();
            InitCombPage(quesNum);
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
            aList = (ListItem)this.comboBox2.SelectedItem;
            pointWords = this.textBox1.Text;
         
            InitList(this.comboBox1.SelectedIndex,Convert.ToInt32(aList.key),this.comboBox3.SelectedIndex,pointWords,1);
            this.comboBox4.Items.Clear();
            InitCombPage(quesNum);

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitList(this.comboBox1.SelectedIndex, Convert.ToInt32(aList.key), this.comboBox3.SelectedIndex, pointWords,this.comboBox4.SelectedIndex+1);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.comboBox4.SelectedIndex > 0)
                this.comboBox4.SelectedIndex = this.comboBox4.SelectedIndex - 1;
            else
                MessageBox.Show("当前为第一页");

            InitList(this.comboBox1.SelectedIndex, Convert.ToInt32(aList.key), this.comboBox3.SelectedIndex, pointWords, this.comboBox4.SelectedIndex+1);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.comboBox4.SelectedIndex < pageNum - 1)
                this.comboBox4.SelectedIndex = this.comboBox4.SelectedIndex + 1;
            else
                MessageBox.Show("当前为最后一页");

            InitList(this.comboBox1.SelectedIndex, Convert.ToInt32(aList.key), this.comboBox3.SelectedIndex, pointWords, this.comboBox4.SelectedIndex+1);
        }

       
        
    }
}
