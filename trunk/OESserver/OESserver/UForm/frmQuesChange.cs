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

namespace OES
{
    public partial class frmQuesChange : Form
    {
        public Problem thePro=new Problem();
        private DataTable questionTable;
        public List<Problem> problemList = new List<Problem>();
        public List<Unit> unitList;
        public List<ListItem> chapterItem = new List<ListItem>();
        public List<ListItem> courseItem = new List<ListItem>();
        public List<Course> courseList = new List<Course>();
        public int quesNum;
        public ListItem aList, bList;
        public String pointWords;
        public int pageNum = 0;
        public int theRowIndex;
        public int theType;

        public void InitCombText()
        {
            courseList = InfoControl.OesData.FindAllCourse();

            for (int i = 0; i < courseList.Count; i++)
                courseItem.Add(new ListItem(Convert.ToString(courseList[i].CourseId), Convert.ToString(courseList[i].CourseName)));

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

            for (int i = 0; i < unitList.Count; i++)
                this.Unitcombo.Items.Add(chapterItem[i]);

            this.Unitcombo.DisplayMember = "value";
            this.Unitcombo.ValueMember = "key";

            if (this.Unitcombo.Items.Count != 0)
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
            questionTable.Columns.Add("删除选择", typeof(bool));
            questionTable.Columns.Add("题目ID");
            questionTable.Columns.Add("题干");
            questionTable.Columns.Add("章节");
            questionTable.Columns.Add("难度");

        }

        public void InitList(int pattern, int unit, int course, int difficulty, String pointwords, int pageIndex)
        {
            InitDT();
            String tableName = "";
            object[] values = new object[5];

            if (difficulty == 0)
                difficulty = -1;

            switch (pattern)
            {
                case 0:
                    {
                        tableName = "Choice";
                        List<Choice> choiceList = InfoControl.OesData.FindAllChoice(pointwords, unit, course, difficulty, pageIndex, 20);
                        for (int i = 0; i < choiceList.Count; i++)
                            problemList.Add(choiceList[i]);

                        quesNum = InfoControl.OesData.FindItemsCount(tableName, pointwords, unit, course, difficulty, -1, -1);

                    } break;

                case 1:
                    {
                        tableName = "Completion";
                        List<Completion> completionList = InfoControl.OesData.FindAllCompletion(pointwords, unit, course, difficulty, pageIndex, 20);
                        for (int i = 0; i < completionList.Count; i++)
                            problemList.Add(completionList[i]);

                        quesNum = InfoControl.OesData.FindItemsCount(tableName, pointwords, unit, course, difficulty, -1, -1);

                    } break;

                case 2:
                    {
                        tableName = "Judgment";
                        List<Judgment> judgmentList = InfoControl.OesData.FindAllJudgment(pointwords, unit, course, difficulty, pageIndex, 20);
                        for (int i = 0; i < judgmentList.Count; i++)
                            problemList.Add(judgmentList[i]);

                        quesNum = InfoControl.OesData.FindItemsCount(tableName, pointwords, unit, course, difficulty, -1, -1);

                    } break;

                case 3:
                    {
                        tableName = "Office";
                        List<Office> wordList = InfoControl.OesData.FindAllOffice(pointwords, unit, course, difficulty, Office.OfficeType.Word, pageIndex, 20);
                        for (int i = 0; i < wordList.Count; i++)
                            problemList.Add(wordList[i]);

                        quesNum = InfoControl.OesData.FindItemsCount(tableName, pointwords, unit, course, difficulty, 0, -1);

                    } break;

                case 4:
                    {
                        tableName = "Office";
                        List<Office> excelList = InfoControl.OesData.FindAllOffice(pointwords, unit, course, difficulty, Office.OfficeType.Excel, pageIndex, 20);
                        for (int i = 0; i < excelList.Count; i++)
                            problemList.Add(excelList[i]);

                        quesNum = InfoControl.OesData.FindItemsCount(tableName, pointwords, unit, course, difficulty, 1, -1);

                    } break;

                case 5:
                    {
                        tableName = "Office";
                        List<Office> powerList = InfoControl.OesData.FindAllOffice(pointwords, unit, course, difficulty, Office.OfficeType.PowerPoint, pageIndex, 20);
                        for (int i = 0; i < powerList.Count; i++)
                            problemList.Add(powerList[i]);

                        quesNum = InfoControl.OesData.FindItemsCount(tableName, pointwords, unit, course, difficulty, 2, -1);

                    } break;

                case 6:
                    {
                        tableName = "Program";
                        List<ProgramProblem> proCComList = InfoControl.OesData.FindAllProgram(pointwords, ProgramPType.Completion, PLanguage.C, unit, course, difficulty, pageIndex, 20);
                        for (int i = 0; i < proCComList.Count; i++)
                            problemList.Add(proCComList[i]);


                        quesNum = InfoControl.OesData.FindItemsCount(tableName, pointwords, unit, course, difficulty, 0, -1);

                    } break;

                case 7:
                    {
                        tableName = "Program";
                        List<ProgramProblem> proCModList = InfoControl.OesData.FindAllProgram(pointwords, ProgramPType.Modify, PLanguage.C, unit, course, difficulty, pageIndex, 20);
                        for (int i = 0; i < proCModList.Count; i++)
                            problemList.Add(proCModList[i]);

                        quesNum = InfoControl.OesData.FindItemsCount(tableName, pointwords, unit, course, difficulty, pageIndex, -1);

                    } break;

                case 8:
                    {
                        tableName = "Program";
                        List<ProgramProblem> proCFuncList = InfoControl.OesData.FindAllProgram(pointwords, ProgramPType.Function, PLanguage.C, unit, course, difficulty, pageIndex, 20);
                        for (int i = 0; i < proCFuncList.Count; i++)
                            problemList.Add(proCFuncList[i]);

                        quesNum = InfoControl.OesData.FindItemsCount(tableName, pointwords, unit, course, difficulty, 2, -1);

                    } break;

                case 9:
                    {
                        tableName = "Program";
                        List<ProgramProblem> proCPPComList = InfoControl.OesData.FindAllProgram(pointwords, ProgramPType.Completion, PLanguage.CPP, unit, course, difficulty, pageIndex, 20);
                        for (int i = 0; i < proCPPComList.Count; i++)
                            problemList.Add(proCPPComList[i]);


                        quesNum = InfoControl.OesData.FindItemsCount(tableName, pointwords, unit, course, difficulty, 0, -1);

                    } break;

                case 10:
                    {
                        tableName = "Program";
                        List<ProgramProblem> proCPPModList = InfoControl.OesData.FindAllProgram(pointwords, ProgramPType.Modify, PLanguage.CPP, unit, course, difficulty, pageIndex, 20);
                        for (int i = 0; i < proCPPModList.Count; i++)
                            problemList.Add(proCPPModList[i]);

                        quesNum = InfoControl.OesData.FindItemsCount(tableName, pointwords, unit, course, difficulty, pageIndex, -1);

                    } break;

                case 11:
                    {
                        tableName = "Program";
                        List<ProgramProblem> proCPPFuncList = InfoControl.OesData.FindAllProgram(pointwords, ProgramPType.Function, PLanguage.CPP, unit, course, difficulty, pageIndex, 20);
                        for (int i = 0; i < proCPPFuncList.Count; i++)
                            problemList.Add(proCPPFuncList[i]);

                        quesNum = InfoControl.OesData.FindItemsCount(tableName, pointwords, unit, course, difficulty, 2, -1);

                    } break;

                case 12:
                    {
                        tableName = "Program";
                        List<ProgramProblem> proVBComList = InfoControl.OesData.FindAllProgram(pointwords, ProgramPType.Completion, PLanguage.VB, unit, course, difficulty, pageIndex, 20);
                        for (int i = 0; i < proVBComList.Count; i++)
                            problemList.Add(proVBComList[i]);


                        quesNum = InfoControl.OesData.FindItemsCount(tableName, pointwords, unit, course, difficulty, 0, -1);

                    } break;

                case 13:
                    {
                        tableName = "Program";
                        List<ProgramProblem> proVBModList = InfoControl.OesData.FindAllProgram(pointwords, ProgramPType.Modify, PLanguage.VB, unit, course, difficulty, pageIndex, 20);
                        for (int i = 0; i < proVBModList.Count; i++)
                            problemList.Add(proVBModList[i]);

                        quesNum = InfoControl.OesData.FindItemsCount(tableName, pointwords, unit, course, difficulty, pageIndex, -1);

                    } break;

                case 14:
                    {
                        tableName = "Program";
                        List<ProgramProblem> proVBFuncList = InfoControl.OesData.FindAllProgram(pointwords, ProgramPType.Function, PLanguage.VB, unit, course, difficulty, pageIndex, 20);
                        for (int i = 0; i < proVBFuncList.Count; i++)
                            problemList.Add(proVBFuncList[i]);

                        quesNum = InfoControl.OesData.FindItemsCount(tableName, pointwords, unit, course, difficulty, 2, -1);

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

        public frmQuesChange(Problem problem)
        {
            int quesType = Convert.ToInt32(problem.type);

            InitializeComponent();
            InitCombText();
            
            
            this.Typecombo.SelectedIndex = 0;
            this.Diffcombo.SelectedIndex = 0;
            this.Textcombo.SelectedIndex = 0;

            this.scoreBox.Text = Convert.ToString(problem.score);
            this.Typecombo.SelectedIndex = quesType;
            aList = (ListItem)this.Unitcombo.SelectedItem;
            pointWords = this.PcontentText.Text;
            theType = this.Typecombo.SelectedIndex;
            InitList(this.Typecombo.SelectedIndex, Convert.ToInt32(aList.key), Convert.ToInt32(bList.key), this.Diffcombo.SelectedIndex, pointWords, 1);
            this.Pagecombo.Items.Clear();
            InitCombPage(quesNum);
        }

        private void Textcombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Unitcombo.Items.Clear();
            bList = (ListItem)this.Textcombo.SelectedItem;
            InitCombUnit(Convert.ToInt32(bList.key));
        }

        private void SearchBut_Click(object sender, EventArgs e)
        {
            aList = (ListItem)this.Unitcombo.SelectedItem;
            pointWords = this.PcontentText.Text;
            theType = this.Typecombo.SelectedIndex;
            InitList(this.Typecombo.SelectedIndex, Convert.ToInt32(aList.key), Convert.ToInt32(bList.key), this.Diffcombo.SelectedIndex, pointWords, 1);
            this.Pagecombo.Items.Clear();
            InitCombPage(quesNum);

            
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            switch (this.Typecombo.SelectedIndex)
            {
                case 0: thePro = InfoControl.OesData.FindChoiceByPID(Convert.ToInt32(this.ProblemDGV.Rows[this.ProblemDGV.CurrentRow.Index].Cells[1].Value))[0]; break;
                case 1: thePro = InfoControl.OesData.FindCompletionByPID(Convert.ToInt32(this.ProblemDGV.Rows[this.ProblemDGV.CurrentRow.Index].Cells[1].Value))[0]; break;
                case 2: thePro = InfoControl.OesData.FindJudgmentByPID(Convert.ToInt32(this.ProblemDGV.Rows[this.ProblemDGV.CurrentRow.Index].Cells[1].Value))[0]; break;
                case 3: thePro = InfoControl.OesData.FindOfficeWordByPID(Convert.ToInt32(this.ProblemDGV.Rows[this.ProblemDGV.CurrentRow.Index].Cells[1].Value))[0]; break;
                case 4: thePro = InfoControl.OesData.FindOfficeExcelByPID(Convert.ToInt32(this.ProblemDGV.Rows[this.ProblemDGV.CurrentRow.Index].Cells[1].Value))[0]; break;
                case 5: thePro = InfoControl.OesData.FindOfficePowerPointByPID(Convert.ToInt32(this.ProblemDGV.Rows[this.ProblemDGV.CurrentRow.Index].Cells[1].Value))[0]; break;
                case 6: thePro = InfoControl.OesData.FindCompletionByPID(Convert.ToInt32(this.ProblemDGV.Rows[this.ProblemDGV.CurrentRow.Index].Cells[1].Value))[0]; break;
                case 7: thePro = InfoControl.OesData.FindModifyProgramByPID(Convert.ToInt32(this.ProblemDGV.Rows[this.ProblemDGV.CurrentRow.Index].Cells[1].Value))[0]; break;
                case 8: thePro = InfoControl.OesData.FindFunctionProgramByPID(Convert.ToInt32(this.ProblemDGV.Rows[this.ProblemDGV.CurrentRow.Index].Cells[1].Value))[0]; break;
                case 9: thePro = InfoControl.OesData.FindCompletionByPID(Convert.ToInt32(this.ProblemDGV.Rows[this.ProblemDGV.CurrentRow.Index].Cells[1].Value))[0]; break;
                case 10: thePro = InfoControl.OesData.FindModifyProgramByPID(Convert.ToInt32(this.ProblemDGV.Rows[this.ProblemDGV.CurrentRow.Index].Cells[1].Value))[0]; break;
                case 11: thePro = InfoControl.OesData.FindFunctionProgramByPID(Convert.ToInt32(this.ProblemDGV.Rows[this.ProblemDGV.CurrentRow.Index].Cells[1].Value))[0]; break;
                case 12: thePro = InfoControl.OesData.FindCompletionByPID(Convert.ToInt32(this.ProblemDGV.Rows[this.ProblemDGV.CurrentRow.Index].Cells[1].Value))[0]; break;
                case 13: thePro = InfoControl.OesData.FindModifyProgramByPID(Convert.ToInt32(this.ProblemDGV.Rows[this.ProblemDGV.CurrentRow.Index].Cells[1].Value))[0]; break;
                case 14: thePro = InfoControl.OesData.FindFunctionProgramByPID(Convert.ToInt32(this.ProblemDGV.Rows[this.ProblemDGV.CurrentRow.Index].Cells[1].Value))[0]; break;
            }
            thePro.score = Convert.ToInt32(scoreBox.Text);
            this.Visible = false;
        }

        private void UpdateBut_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void frmQuesChange_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void scoreBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar >= 48 && e.KeyChar <= 57 || e.KeyChar == 8))//8是BackSpace的键码
            {
                e.Handled = true;
            }
            if (this.scoreBox.Text.Length >= 2)
            {
                if(e.KeyChar!=8)
                    e.Handled = true;
                
            }
        }

       

      

     
    }
}
