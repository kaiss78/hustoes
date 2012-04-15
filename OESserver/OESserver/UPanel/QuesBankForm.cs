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

                    quesNum = InfoControl.OesData.FindItemsCount(tableName, pointwords, unit,course, difficulty, (int)ProgramPType.Null, (int)PLanguage.Null);

                } break;

                case 1: {
                    tableName = "Completion";
                    List<Completion> completionList = InfoControl.OesData.FindAllCompletion(pointwords, unit, course, difficulty, pageIndex, 20);
                    for (int i = 0; i < completionList.Count; i++)
                        problemList.Add(completionList[i]);

                    quesNum = InfoControl.OesData.FindItemsCount(tableName, pointwords, unit, course, difficulty, (int)ProgramPType.Null, (int)PLanguage.Null);
                    
                }  break;

                case 2: {
                    tableName = "Judgment";
                    List<Judgment> judgmentList = InfoControl.OesData.FindAllJudgment(pointwords, unit, course, difficulty, pageIndex, 20);
                    for(int i=0;i<judgmentList.Count;i++)
                        problemList.Add(judgmentList[i]);

                    quesNum = InfoControl.OesData.FindItemsCount(tableName, pointwords, unit, course, difficulty, (int)ProgramPType.Null, (int)PLanguage.Null);
                    
                }  break;

                case 3:
                    {
                        tableName = "Office";
                        List<Office> wordList = InfoControl.OesData.FindAllOffice(pointwords, unit, course, difficulty, Office.OfficeType.Word, pageIndex, 20);
                        for (int i = 0; i < wordList.Count; i++)
                            problemList.Add(wordList[i]);

                        quesNum = InfoControl.OesData.FindItemsCount(tableName, pointwords, unit, course, difficulty, (int)ProgramPType.Completion, (int)PLanguage.Null);

                    } break;

                case 4:
                    {
                        tableName = "Office";
                        List<Office> excelList = InfoControl.OesData.FindAllOffice(pointwords, unit, course, difficulty, Office.OfficeType.Excel, pageIndex, 20);
                        for (int i = 0; i < excelList.Count; i++)
                            problemList.Add(excelList[i]);

                        quesNum = InfoControl.OesData.FindItemsCount(tableName, pointwords, unit, course, difficulty, (int)ProgramPType.Modify, (int)PLanguage.Null);

                    } break;

                case 5:
                    {
                        tableName = "Office";
                        List<Office> powerList = InfoControl.OesData.FindAllOffice(pointwords, unit, course, difficulty, Office.OfficeType.PowerPoint, pageIndex, 20);
                        for (int i = 0; i < powerList.Count; i++)
                            problemList.Add(powerList[i]);

                        quesNum = InfoControl.OesData.FindItemsCount(tableName, pointwords, unit, course, difficulty, (int)ProgramPType.Function, (int)PLanguage.Null);

                    } break;

                case 6: {
                    tableName = "Program";
                    List<ProgramProblem> proCComList = InfoControl.OesData.FindAllProgram(pointwords, ProgramPType.Completion, PLanguage.C, unit, course, difficulty, pageIndex, 20);
                    for (int i = 0; i < proCComList.Count; i++)
                        problemList.Add(proCComList[i]);


                    quesNum = InfoControl.OesData.FindItemsCount(tableName, pointwords, unit, course, difficulty, (int)ProgramPType.Completion, (int)PLanguage.Null);

                } break;

                case 7: {
                    tableName = "Program";
                    List<ProgramProblem> proCModList = InfoControl.OesData.FindAllProgram(pointwords, ProgramPType.Modify, PLanguage.C, unit, course, difficulty, pageIndex, 20);
                    for (int i = 0; i < proCModList.Count; i++)
                        problemList.Add(proCModList[i]);

                    quesNum = InfoControl.OesData.FindItemsCount(tableName, pointwords, unit, course, difficulty, (int)ProgramPType.Modify, (int)PLanguage.Null);

                } break;

                case 8: {
                    tableName = "Program";
                    List<ProgramProblem> proCFuncList = InfoControl.OesData.FindAllProgram(pointwords, ProgramPType.Function, PLanguage.C, unit, course, difficulty, pageIndex, 20);
                    for (int i = 0; i < proCFuncList.Count; i++)
                        problemList.Add(proCFuncList[i]);

                    quesNum = InfoControl.OesData.FindItemsCount(tableName, pointwords, unit, course, difficulty, (int)ProgramPType.Function, (int)PLanguage.Null);

                } break;

                case 9:
                    {
                        tableName = "Program";
                        List<ProgramProblem> proCPPComList = InfoControl.OesData.FindAllProgram(pointwords, ProgramPType.Completion, PLanguage.CPP, unit, course, difficulty, pageIndex, 20);
                        for (int i = 0; i < proCPPComList.Count; i++)
                            problemList.Add(proCPPComList[i]);


                        quesNum = InfoControl.OesData.FindItemsCount(tableName, pointwords, unit, course, difficulty, (int)ProgramPType.Completion, (int)PLanguage.Null);

                    } break;

                case 10:
                    {
                        tableName = "Program";
                        List<ProgramProblem> proCPPModList = InfoControl.OesData.FindAllProgram(pointwords, ProgramPType.Modify, PLanguage.CPP, unit, course, difficulty, pageIndex, 20);
                        for (int i = 0; i < proCPPModList.Count; i++)
                            problemList.Add(proCPPModList[i]);

                        quesNum = InfoControl.OesData.FindItemsCount(tableName, pointwords, unit, course, difficulty, (int)ProgramPType.Modify, (int)PLanguage.Null);

                    } break;

                case 11:
                    {
                        tableName = "Program";
                        List<ProgramProblem> proCPPFuncList = InfoControl.OesData.FindAllProgram(pointwords, ProgramPType.Function, PLanguage.CPP, unit, course, difficulty, pageIndex, 20);
                        for (int i = 0; i < proCPPFuncList.Count; i++)
                            problemList.Add(proCPPFuncList[i]);

                        quesNum = InfoControl.OesData.FindItemsCount(tableName, pointwords, unit, course, difficulty, (int)ProgramPType.Function, (int)PLanguage.Null);

                    } break;

                case 12:
                    {
                        tableName = "Program";
                        List<ProgramProblem> proVBComList = InfoControl.OesData.FindAllProgram(pointwords, ProgramPType.Completion, PLanguage.VB, unit, course, difficulty, pageIndex, 20);
                        for (int i = 0; i < proVBComList.Count; i++)
                            problemList.Add(proVBComList[i]);


                        quesNum = InfoControl.OesData.FindItemsCount(tableName, pointwords, unit, course, difficulty, (int)ProgramPType.Completion, (int)PLanguage.Null);

                    } break;

                case 13:
                    {
                        tableName = "Program";
                        List<ProgramProblem> proVBModList = InfoControl.OesData.FindAllProgram(pointwords, ProgramPType.Modify, PLanguage.VB, unit, course, difficulty, pageIndex, 20);
                        for (int i = 0; i < proVBModList.Count; i++)
                            problemList.Add(proVBModList[i]);

                        quesNum = InfoControl.OesData.FindItemsCount(tableName, pointwords, unit, course, difficulty, (int)ProgramPType.Modify, (int)PLanguage.Null);

                    } break;

                case 14:
                    {
                        tableName = "Program";
                        List<ProgramProblem> proVBFuncList = InfoControl.OesData.FindAllProgram(pointwords, ProgramPType.Function, PLanguage.VB, unit, course, difficulty, pageIndex, 20);
                        for (int i = 0; i < proVBFuncList.Count; i++)
                            problemList.Add(proVBFuncList[i]);

                        quesNum = InfoControl.OesData.FindItemsCount(tableName, pointwords, unit, course, difficulty, (int)ProgramPType.Function, (int)PLanguage.Null);

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
            //this.ProblemDGV.Rows[this.ProblemDGV.CurrentRow.Index].Cells[]
        }

        private void DeleteBut_Click(object sender, EventArgs e)
        {
            string a = "sdg";
            InfoControl.OesData.FindStudentByStudentId(a);

            if (MessageBox.Show("确定删除？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                for (int i = 0; i < this.ProblemDGV.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(this.ProblemDGV.Rows[i].Cells[0].Value) == true)
                        switch (this.Typecombo.SelectedIndex)
                        {
                            case 0:     //Choice删除
                                InfoControl.OesData.DeleteChoice(Convert.ToInt32(ProblemDGV.Rows[i].Cells[1].Value)); 
                                break;
                            case 1:     //Completion删除
                                InfoControl.OesData.DeleteCompletion(Convert.ToInt32(this.ProblemDGV.Rows[i].Cells[1].Value)); 
                                break;
                            case 2:     //Judgement删除
                                InfoControl.OesData.DeleteJudgment(Convert.ToInt32(this.ProblemDGV.Rows[i].Cells[1].Value)); 
                                break;
                            case 3:     //Word删除
                            case 4:     //Excel删除
                            case 5:     //PPT删除
                                deleteOfficeFile(Convert.ToInt32(this.ProblemDGV.Rows[i].Cells[1].Value), Typecombo.SelectedIndex);
                                InfoControl.OesData.DeleteOffice(Convert.ToInt32(this.ProblemDGV.Rows[i].Cells[1].Value));
                                break;
                            case 6:     //C_Completion删除
                            case 7:     //C_Modification删除
                            case 8:     //C_Function删除
                            case 9:     //Cpp_Completion删除
                            case 10:    //Cpp_Modification删除
                            case 11:    //Cpp_Function删除
                            case 12:    //Vb_Completion删除
                            case 13:    //Vb_Modification删除
                            case 14:    //Vb_Function删除
                                InfoControl.OesData.DeleteProgram(Convert.ToInt32(this.ProblemDGV.Rows[i].Cells[1].Value)); 
                                break;
                        }

                }

                InitList(this.Typecombo.SelectedIndex, Convert.ToInt32(aList.key), Convert.ToInt32(bList.key), this.Diffcombo.SelectedIndex, pointWords, this.Pagecombo.SelectedIndex);
                this.Pagecombo.Items.Clear();
                InitCombPage(quesNum);
            }
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

        /// <summary>
        /// 删除Office题目文件
        /// </summary>
        /// <param name="pid">Office题的编号</param>
        /// <param name="type">Office题类型</param>
        private void deleteOfficeFile(int pid, int type)
        { 
            int tid = InfoControl.User.Id;
            if (type == 3)              //Word
            {
                InfoControl.ClientObj.DelWordA(pid, tid);
                InfoControl.ClientObj.DelWordP(pid, tid);
                InfoControl.ClientObj.DelWordT(pid, tid);
            }
            else if (type == 4)         //Excel
            {
                InfoControl.ClientObj.DelExcelA(pid, tid);
                InfoControl.ClientObj.DelExcelP(pid, tid);
                InfoControl.ClientObj.DelExcelT(pid, tid);
            }
            else                        //Powerpoint
            {
                InfoControl.ClientObj.DelPowerPointA(pid, tid);
                InfoControl.ClientObj.DelPowerPointP(pid, tid);
                InfoControl.ClientObj.DelPowerPointT(pid, tid);
            }
            InfoControl.ClientObj.DelFiles();
        }
        
    }
}
