using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OES.Model;
using OES.XMLFile;

namespace OES.UPanel
{
    public partial class PaperListPanel : UserPanel
    {
        private DataTable paperListDataTable;
        public Paper paper = new Paper();
        public List<Paper> paperList;
        private int findtype = 1;
        private List<IdScoreType> ISTList;
        public void InitDT()
        {
            paperListDataTable = new DataTable("PaperList");
            paperListDataTable.Columns.Add("选中", typeof(bool));
            paperListDataTable.Columns.Add("试卷ID");
            paperListDataTable.Columns.Add("试卷名称");
            paperListDataTable.Columns.Add("组卷时间");
            paperListDataTable.Columns.Add("作者");
        }

        public void InitList()
        {
            InitDT();
            object[] values = new object[5];

            paperList = InfoControl.OesData.FindPaper();

            for (int i = 0; i < paperList.Count; i++)
            {
                values[0] = false;
                values[1] = paperList[i].paperID;
                values[2] = paperList[i].paperName;
                values[3] = paperList[i].createTime;
                values[4] = paperList[i].author;
                paperListDataTable.Rows.Add(values);
            }

            PaperListDGV.DataSource = paperListDataTable;
            PaperListDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            PaperListDGV.Columns[0].FillWeight = 5;
            PaperListDGV.Columns[1].FillWeight = 12;
            PaperListDGV.Columns[2].FillWeight = 45;
            PaperListDGV.Columns[3].FillWeight = 20;
            PaperListDGV.Columns[4].FillWeight = 18;

            PaperListDGV.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            PaperListDGV.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            PaperListDGV.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            PaperListDGV.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            PaperListDGV.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        public PaperListPanel()
        {
            InitializeComponent();
            changeFindType(findtype);               //一开始是按年份查询
        }

        override public void ReLoad()
        {
            this.Visible = true;
            InitList();
        }

        private void PaperListDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int RIndex = e.RowIndex;
            if (RIndex > -1)
            {
                paperListDataTable.Rows[RIndex][0] = !Convert.ToBoolean(paperListDataTable.Rows[RIndex][0]);
            }
        }

        //跳转到试卷编辑
        private void PaperListDGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Problem pro;
            int RIndex = e.RowIndex;
            if (RIndex > -1)
            {
                ISTList = XMLControl.ReadPaper(paperList[RIndex].paperPath);
                InfoControl.TmpPaper = new Paper();
                InfoControl.TmpPaper.paperID = paperList[RIndex].paperID;
                InfoControl.TmpPaper.paperName = paperList[RIndex].paperName;
                InfoControl.TmpPaper.programState = paperList[RIndex].programState;
                InfoControl.TmpPaper.createTime = paperList[RIndex].createTime;
                InfoControl.TmpPaper.testTime = paperList[RIndex].testTime;
                InfoControl.TmpPaper.author = paperList[RIndex].author;
                InfoControl.TmpPaper.authorId = paperList[RIndex].authorId;
                for (int i = 0; i < 9; i++)
                {
                    InfoControl.TmpPaper.ProList[i] = new List<Problem>();
                }
                for (int i = 0; i < ISTList.Count; i++)
                {
                    pro = new Problem();
                    pro.problemId = ISTList[i].id;
                    pro.score = ISTList[i].score;
                    switch (ISTList[i].pt)
                    {
                        case ProblemType.Choice:
                            pro.problem = InfoControl.OesData.FindChoiceById(ISTList[i].id.ToString())[0].problem;
                            InfoControl.TmpPaper.ProList[0].Add(pro);
                            InfoControl.TmpPaper.score_choice = ISTList[i].score;
                            break;
                        case ProblemType.Completion:
                            pro.problem = InfoControl.OesData.FindCompletionById(ISTList[i].id.ToString())[0].problem;

                            InfoControl.TmpPaper.ProList[1].Add(pro);
                            InfoControl.TmpPaper.score_completion = ISTList[i].score;
                            break;
                        case ProblemType.Tof:
                            pro.problem = InfoControl.OesData.FindTofById(ISTList[i].id.ToString())[0].problem;
                            InfoControl.TmpPaper.ProList[2].Add(pro);
                            InfoControl.TmpPaper.score_judge = ISTList[i].score;
                            break;
                        case ProblemType.Excel:
                            pro.problem = InfoControl.OesData.FindOfficeExcelById(ISTList[i].id.ToString())[0].problem;
                            InfoControl.TmpPaper.ProList[3].Add(pro);
                            InfoControl.TmpPaper.score_officeExcel = ISTList[i].score;
                            break;
                        case ProblemType.PowerPoint:
                            pro.problem = InfoControl.OesData.FindOfficePowerPointById(ISTList[i].id.ToString())[0].problem;
                            InfoControl.TmpPaper.ProList[4].Add(pro);
                            InfoControl.TmpPaper.score_officePPT = ISTList[i].score;
                            break;
                        case ProblemType.Word:
                            pro.problem = InfoControl.OesData.FindOfficeWordById(ISTList[i].id.ToString())[0].problem;
                            InfoControl.TmpPaper.ProList[5].Add(pro);
                            InfoControl.TmpPaper.score_officeWord = ISTList[i].score;
                            break;
                        case ProblemType.ProgramCompletion:
                            pro.problem = InfoControl.OesData.FindCompletionById(ISTList[i].id.ToString())[0].problem;
                            InfoControl.TmpPaper.ProList[6].Add(pro);
                            InfoControl.TmpPaper.score_pCompletion = ISTList[i].score;
                            break;
                        case ProblemType.ProgramModification:
                            pro.problem = InfoControl.OesData.FindModificationProgramById(ISTList[i].id.ToString())[0].problem;
                            InfoControl.TmpPaper.ProList[7].Add(pro);
                            InfoControl.TmpPaper.score_pModif = ISTList[i].score;
                            break;
                        case ProblemType.ProgramFun:
                            pro.problem = InfoControl.OesData.FindFunProgramById(ISTList[i].id.ToString())[0].problem;
                            InfoControl.TmpPaper.ProList[8].Add(pro);
                            InfoControl.TmpPaper.score_pFunction = ISTList[i].score;
                            break;
                    }
                }
                PanelControl.EditPaper();
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("确定删除记录", "确认删除", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                for (int i = 0; i < paperListDataTable.Rows.Count; i++)
                {
                    if ((bool)paperListDataTable.Rows[i][0])
                    {
                        InfoControl.OesData.DeletePaper(paperListDataTable.Rows[i]["试卷ID"].ToString());
                    }
                }
                InitList();
            }
        }

        private void changeFindType(int findtype)
        {
            this.year.Visible = false;
            this.paperName.Visible = false;
            this.startTime.Visible = false;
            this.endTime.Visible = false;
            switch (findtype)
            {
                case 1:
                    this.year.Visible = true;
                    break;
                case 2:
                    this.paperName.Visible = true;
                    break;
                case 3:
                    this.startTime.Visible = true;
                    this.endTime.Visible = true;
                    break;
            }
        }

        private void cbtnFindByYear_Click(object sender, EventArgs e)
        {

            findtype = 1;
            changeFindType(findtype);
        }

        private void cbtnFindByTime_Click(object sender, EventArgs e)
        {
            findtype = 3;
            changeFindType(findtype);
        }

        private void cbtnFindByName_Click(object sender, EventArgs e)
        {
            findtype = 2;
            changeFindType(findtype);
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            InitDT();
            object[] values = new object[5];
            switch (findtype)
            {
                case 1:
                    paperList = InfoControl.OesData.FindPaperByYear(Convert.ToString(year.Value));
                    break;
                case 2:
                    paperList = InfoControl.OesData.FindPaperByTitle(paperName.Text);
                    break;
                case 3:
                    paperList = InfoControl.OesData.FindPaperByTwoDates(startTime.Value, endTime.Value);
                    break;
            }
            for (int i = 0; i < paperList.Count; i++)
            {
                values[0] = false;
                values[1] = paperList[i].paperID;
                values[2] = paperList[i].paperName;
                values[3] = paperList[i].createTime;
                values[4] = paperList[i].author;
                paperListDataTable.Rows.Add(values);
            }

            PaperListDGV.DataSource = paperListDataTable;
            PaperListDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            PaperListDGV.Columns[0].FillWeight = 5;
            PaperListDGV.Columns[1].FillWeight = 12;
            PaperListDGV.Columns[2].FillWeight = 45;
            PaperListDGV.Columns[3].FillWeight = 20;
            PaperListDGV.Columns[4].FillWeight = 18;

            PaperListDGV.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            PaperListDGV.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            PaperListDGV.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            PaperListDGV.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            PaperListDGV.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {            
            InfoControl.TmpPaper = InfoControl.OesData.FindPaperById(PaperListDGV.SelectedRows[0].Cells[1].Value.ToString())[0];
            List<IdScoreType> tmpList = XMLControl.ReadPaper(InfoControl.TmpPaper.paperPath);
            for (int i = 0; i < 9; i++)
            {
                InfoControl.TmpPaper.ProList[i] = new List<Problem>();
            }
            Problem tmpPro;
            foreach (IdScoreType pro in tmpList)
            {
                tmpPro = new Problem();

                switch (pro.pt)
                {
                    case ProblemType.Choice:                        
                        tmpPro=InfoControl.OesData.FindChoiceById(pro.id.ToString())[0];
                        InfoControl.TmpPaper.ProList[0].Add(tmpPro);
                        InfoControl.TmpPaper.score_choice = pro.score;
                        break;
                    case ProblemType.Tof:
                        tmpPro = InfoControl.OesData.FindTofById(pro.id.ToString())[0];
                        InfoControl.TmpPaper.ProList[2].Add(tmpPro);
                        InfoControl.TmpPaper.score_judge = pro.score;
                        break;
                    case ProblemType.Completion:
                        tmpPro = InfoControl.OesData.FindCompletionById(pro.id.ToString())[0];
                        InfoControl.TmpPaper.ProList[1].Add(tmpPro);
                        InfoControl.TmpPaper.score_completion = pro.score;
                        break;
                    case ProblemType.Word:
                        tmpPro = InfoControl.OesData.FindOfficeWordById(pro.id.ToString())[0];
                        InfoControl.TmpPaper.ProList[5].Add(tmpPro);
                        InfoControl.TmpPaper.score_officeWord = pro.score;
                        break;
                    case ProblemType.PowerPoint:
                        tmpPro = InfoControl.OesData.FindOfficePowerPointById(pro.id.ToString())[0];
                        InfoControl.TmpPaper.ProList[4].Add(tmpPro);
                        InfoControl.TmpPaper.score_officePPT = pro.score;
                        break;
                    case ProblemType.Excel:
                        tmpPro = InfoControl.OesData.FindOfficeExcelById(pro.id.ToString())[0];
                        InfoControl.TmpPaper.ProList[3].Add(tmpPro);
                        InfoControl.TmpPaper.score_officeExcel = pro.score;
                        break;
                    case ProblemType.ProgramModification:
                        tmpPro = InfoControl.OesData.FindModificationProgramById(pro.id.ToString())[0];
                        InfoControl.TmpPaper.ProList[7].Add(tmpPro);
                        InfoControl.TmpPaper.score_pModif = pro.score;
                        break;
                    case ProblemType.ProgramCompletion:
                        tmpPro = InfoControl.OesData.FindCompletionProgramById(pro.id.ToString())[0];
                        InfoControl.TmpPaper.ProList[6].Add(tmpPro);
                        InfoControl.TmpPaper.score_pCompletion = pro.score;
                        break;
                    case ProblemType.ProgramFun:
                        tmpPro = InfoControl.OesData.FindFunProgramById(pro.id.ToString())[0];
                        InfoControl.TmpPaper.ProList[8].Add(tmpPro);
                        InfoControl.TmpPaper.score_pFunction = pro.score;
                        break;
                }
                tmpPro.problemId = pro.id;
                tmpPro.score = pro.score;
            }
            PanelControl.EditPaper();
        }
    }
}
