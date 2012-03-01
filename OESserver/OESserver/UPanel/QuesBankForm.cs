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
        public List<ListItem> chapterItem = new List<ListItem>();
        public List<ListItem> courseItem = new List<ListItem>();
        public List<Course> courseList = new List<Course>();
        public int quesNum;
        public ListItem aList,bList;
        public String pointWords;
        public int pageNum = 0;
        public int theRowIndex;
        public int theType;
       

        public void InitCombText()
        {
            courseList = InfoControl.OesData.FindAllCourse();

            for (int i = 0; i < courseList.Count; i++)
                courseItem.Add(new ListItem(Convert.ToString(courseList[i].CourseId),Convert.ToString(courseList[i].CourseName)));

            for (int i = 0; i < courseList.Count; i++)
                this.Textcombo.Items.Add(courseItem[i]);

            this.Textcombo.DisplayMember = "value";
            this.Textcombo.ValueMember = "key";
            
        }
        
        public void InitCombUnit(int courseId)
        {
            //ListItem cmpList;
            chapterItem.Clear();
            unitList = InfoControl.OesData.FindUnitByCourseId(courseId);

            chapterItem.Add(new ListItem("-1", "全部"));
            for (int i = 0; i < unitList.Count; i++)
                chapterItem.Add(new ListItem(Convert.ToString(unitList[i].UnitId), Convert.ToString(unitList[i].UnitName)));

            for(int i=0;i<unitList.Count;i++)
                this.Unitcombo.Items.Add(chapterItem[i]);

            this.Unitcombo.DisplayMember = "value";
            this.Unitcombo.ValueMember = "key";

            if(this.Unitcombo.Items.Count!=0)
            this.Unitcombo.SelectedIndex = 0;
        }

        public void InitCombPage(int problemNum)
        {
            int i = 2;
            String num = "第1页";

            if (problemNum != 0)
            {
                this.Pagecombo.Items.Add(num);
                this.Pagecombo.SelectedIndex = 0;
            }

            if (problemNum % 20 != 0)
                pageNum = problemNum / 20 + 1;
            else
                pageNum = problemNum / 20;

            for (; i <= pageNum; i++)
            {
                num = "第" + "" + i + "" + "页";
                this.Pagecombo.Items.Add(num);
            }
            
        }

        public void InitDT()
        {
            questionTable = new DataTable("questionlist");
            questionTable.Columns.Add("删除选择",typeof(bool));
            questionTable.Columns.Add("题目ID");
            questionTable.Columns.Add("题干");
            questionTable.Columns.Add("章节");
            questionTable.Columns.Add("难度");

        }

        public void InitList(int pattern,int unit,int course,int difficulty,String pointwords,int pageIndex)
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
                    List<Choice> choiceList = InfoControl.OesData.FindAllChoice(pointwords, unit, course, difficulty, pageIndex, 20);
                    for (int i = 0; i < choiceList.Count; i++)
                        problemList.Add(choiceList[i]);

                    quesNum = InfoControl.OesData.FindItemsCount(tableName, pointwords, unit,course, difficulty, -1, -1);

                } break;

                case 1: {
                    tableName = "Completion";
                    List<Completion> completionList = InfoControl.OesData.FindAllCompletion(pointwords, unit, course, difficulty, pageIndex, 20);
                    for (int i = 0; i < completionList.Count; i++)
                        problemList.Add(completionList[i]);

                    quesNum = InfoControl.OesData.FindItemsCount(tableName, pointwords, unit,course, difficulty, -1, -1);
                    
                }  break;

                case 2: {
                    tableName = "Judgment";
                    List<Judgment> judgmentList = InfoControl.OesData.FindAllJudgment(pointwords, unit, course, difficulty, pageIndex, 20);
                    for(int i=0;i<judgmentList.Count;i++)
                        problemList.Add(judgmentList[i]);

                    quesNum = InfoControl.OesData.FindItemsCount(tableName, pointwords, unit,course, difficulty, -1, -1);
                    
                }  break;

                case 3: {
                    tableName = "Program";

                    List<ProgramProblem> proComList = InfoControl.OesData.FindAllProgram(pointwords, ProgramPType.Completion, PLanguage.Null, unit, course, difficulty, pageIndex, 20);
                    for (int i = 0; i < proComList.Count; i++)
                        problemList.Add(proComList[i]);


                    quesNum = InfoControl.OesData.FindItemsCount(tableName, pointwords, unit,course, difficulty, 0, -1);

                } break;

                case 4: {
                    tableName = "Program";
                    List<ProgramProblem> proModList = InfoControl.OesData.FindAllProgram(pointwords, ProgramPType.Modify, PLanguage.Null, unit, course, difficulty, pageIndex, 20);
                    for (int i = 0; i < proModList.Count; i++)
                        problemList.Add(proModList[i]);

                    quesNum = InfoControl.OesData.FindItemsCount(tableName,pointwords,unit,course,difficulty,pageIndex,-1);

                } break;

                case 5: {
                    tableName = "Program";
                    List<ProgramProblem> proFuncList = InfoControl.OesData.FindAllProgram(pointwords, ProgramPType.Function, PLanguage.Null, unit, course, difficulty, pageIndex, 20);
                    for (int i = 0; i < proFuncList.Count; i++)
                        problemList.Add(proFuncList[i]);

                    quesNum = InfoControl.OesData.FindItemsCount(tableName, pointwords, unit,course, difficulty, 2, -1);

                } break;

                case 6: {
                    tableName = "Office";
                    List<Office> wordList = InfoControl.OesData.FindAllOffice(pointwords, unit, course, difficulty, Office.OfficeType.Word, pageIndex, 20);
                    for (int i = 0; i < wordList.Count; i++)
                        problemList.Add(wordList[i]);

                    quesNum = InfoControl.OesData.FindItemsCount(tableName,pointwords,unit,course,difficulty,0,-1);

                } break;

                case 7:{
                    tableName = "Office";
                    List<Office> excelList = InfoControl.OesData.FindAllOffice(pointwords, unit, course, difficulty, Office.OfficeType.Excel, pageIndex, 20);
                    for (int i = 0; i < excelList.Count; i++)
                        problemList.Add(excelList[i]);

                    quesNum = InfoControl.OesData.FindItemsCount(tableName,pointwords,unit,course,difficulty,1,-1);

                } break;

                case 8:{
                    tableName = "Office";
                    List<Office> powerList = InfoControl.OesData.FindAllOffice(pointwords, unit, course, difficulty, Office.OfficeType.PowerPoint, pageIndex, 20);
                    for (int i = 0; i < powerList.Count; i++)
                        problemList.Add(powerList[i]);

                    quesNum = InfoControl.OesData.FindItemsCount(tableName,pointwords,unit,course,difficulty,2,-1);

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

            InitCombText();

            this.Typecombo.SelectedIndex = 0;
            this.Diffcombo.SelectedIndex = 0;
            this.Textcombo.SelectedIndex = 0;
        }

    
        public override void ReLoad()
        {
            this.Visible = true;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            PanelControl.ChangPanel(8);
        }

        private void UpdateBut_Click(object sender, EventArgs e)
        {
            if (this.ProblemDGV.CurrentRow==null)
                MessageBox.Show("请选择题目！");
            else
                PanelControl.QueUpdate(Convert.ToInt32(this.ProblemDGV.Rows[this.ProblemDGV.CurrentRow.Index].Cells[1].Value), theType, this.Textcombo.SelectedIndex, Convert.ToString(this.ProblemDGV.Rows[this.ProblemDGV.CurrentRow.Index].Cells[3].Value), Convert.ToInt32(this.ProblemDGV.Rows[this.ProblemDGV.CurrentRow.Index].Cells[4].Value));
            //AddQuetionPanel.CheckQue(this.comboBox1.SelectedIndex,Convert.ToInt32(this.ProblemDGV.Rows[this.ProblemDGV.SelectedRows].Cells[1].Value));

            //MessageBox.Show(Convert.ToString(this.ProblemDGV.Rows[this.ProblemDGV.CurrentRow.Index].Cells[1].Value));
        }

        private void DeleteBut_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.ProblemDGV.Rows.Count; i++)
            {
                if(Convert.ToBoolean(this.ProblemDGV.Rows[i].Cells[0].Value)==true)
                    switch (this.Typecombo.SelectedIndex)
                    {
                        case 0: InfoControl.OesData.DeleteChoice(Convert.ToInt32(ProblemDGV.Rows[i].Cells[1].Value)); break;
                        case 1: InfoControl.OesData.DeleteCompletion(Convert.ToInt32(this.ProblemDGV.Rows[i].Cells[1].Value)); break;
                        case 2: InfoControl.OesData.DeleteJudgment(Convert.ToInt32(this.ProblemDGV.Rows[i].Cells[1].Value)); break;
                        case 3: 
                        case 4: 
                        case 5: InfoControl.OesData.DeleteProgram(Convert.ToInt32(this.ProblemDGV.Rows[i].Cells[1].Value)); break;
                        case 6:
                        case 7:
                        case 8: InfoControl.OesData.DeleteOffice(Convert.ToInt32(this.ProblemDGV.Rows[i].Cells[1].Value)); break;

                    }
               
            }

            InitList(this.Typecombo.SelectedIndex, Convert.ToInt32(aList.key), Convert.ToInt32(bList.key), this.Diffcombo.SelectedIndex, pointWords, this.Pagecombo.SelectedIndex);
            this.Pagecombo.Items.Clear();
            InitCombPage(quesNum);
        }

        private void ProblemDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            theRowIndex = e.RowIndex;
            if (theRowIndex > -1)
            {
                questionTable.Rows[theRowIndex][0] = !Convert.ToBoolean(questionTable.Rows[theRowIndex][0]);
            }
        }
        
        private void SearchBut_Click(object sender, EventArgs e)
        {
            aList = (ListItem)this.Unitcombo.SelectedItem;
            pointWords = this.PcontentText.Text;
            theType = this.Typecombo.SelectedIndex;
            InitList(this.Typecombo.SelectedIndex,Convert.ToInt32(aList.key),Convert.ToInt32(bList.key),this.Diffcombo.SelectedIndex,pointWords,1);
            this.Pagecombo.Items.Clear();
            InitCombPage(quesNum);

        }

        private void Pagecombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitList(this.Typecombo.SelectedIndex, Convert.ToInt32(aList.key), Convert.ToInt32(bList.key), this.Diffcombo.SelectedIndex, pointWords, this.Pagecombo.SelectedIndex + 1);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.Pagecombo.SelectedIndex > 0)
                this.Pagecombo.SelectedIndex = this.Pagecombo.SelectedIndex - 1;
            else
                MessageBox.Show("当前为第一页");

            InitList(this.Typecombo.SelectedIndex, Convert.ToInt32(aList.key), Convert.ToInt32(bList.key), this.Diffcombo.SelectedIndex, pointWords, this.Pagecombo.SelectedIndex + 1);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.Pagecombo.SelectedIndex < pageNum - 1)
                this.Pagecombo.SelectedIndex = this.Pagecombo.SelectedIndex + 1;
            else
                MessageBox.Show("当前为最后一页");

            InitList(this.Typecombo.SelectedIndex, Convert.ToInt32(aList.key), Convert.ToInt32(bList.key), this.Diffcombo.SelectedIndex, pointWords, this.Pagecombo.SelectedIndex + 1);
        }

        private void Textcombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Unitcombo.Items.Clear();
            bList = (ListItem)this.Textcombo.SelectedItem;
            InitCombUnit(Convert.ToInt32(bList.key));
        }

       

        
       
        
    }
}
