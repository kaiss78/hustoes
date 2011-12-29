using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data;
using OES.XMLFile;
using OES.Model;

namespace OES.UPanel
{
    public partial class PaperInfo : UserPanel
    {
        private DataTable dtRule;
        private DataTable dtCourse;
        private frmAddRule frmAddRule;
        private List<PaperRule> Rules;
        private Paper NewPaper;
        private Random rd;
        private int TotScore;
        private bool EndLoad;
        private frmPaperPreview paperPreview;

        public PaperInfo()
        {
            InitializeComponent();
            EndLoad = false;
            dtRule = new DataTable();
            dtRule.Columns.Add("选中", typeof(bool));
            dtRule.Columns.Add("章节");
            dtRule.Columns.Add("题目类型");
            dtRule.Columns.Add("难度值");
            dtRule.Columns.Add("分值");
            dtRule.Columns.Add("数量");
            dgvRule.DataSource = dtRule;
            dgvRule.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvRule.Columns[0].FillWeight = 5;
            dgvRule.Columns[1].FillWeight = 28;
            dgvRule.Columns[2].FillWeight = 28;
            dgvRule.Columns[3].FillWeight = 13;
            dgvRule.Columns[4].FillWeight = 13;
            dgvRule.Columns[5].FillWeight = 13;

            dgvRule.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvRule.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvRule.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvRule.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvRule.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvRule.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;

            dtCourse = InfoControl.OesData.FindAllCourse_DataSet().Tables[0];
            cboCourse.DataSource = dtCourse;
            this.cboCourse.SelectedIndexChanged += new System.EventHandler(this.cboCourse_SelectedIndexChanged);
            cboCourse.DisplayMember = "CourseName";
            cboCourse.ValueMember = "CourseId";                                    

            
        }

        override public void ReLoad()
        {
            Rules = new List<PaperRule>();
            dtRule.Clear();
            lbTotScore.Text = "0";
            TotScore = 0;
            EndLoad = true;
            this.Visible = true;
        }

        #region 添加题目
        private void AddChoice(int Plevel, int Chaptet, int Course, int Count, int Score)
        {
            rd = new Random();
            List<Choice> list = InfoControl.OesData.FindAllChoice("", Chaptet, Course, Plevel, 1, int.MaxValue);
            if (list.Count < Count)
            {
                MessageBox.Show("数据库中题目不足！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            while (Count > 0)
            {
                int tmp = rd.Next(list.Count);
                bool flag = true;
                foreach (Choice pro in NewPaper.choice)
                {
                    if (pro.problemId == list[tmp].problemId)
                    {
                        flag = false;
                    }
                }
                if (flag)
                {
                    list[tmp].score = Score;
                    NewPaper.choice.Add(list[tmp]);
                    Count--;
                }
            }

        }

        private void AddJudgement(int Plevel, int Chaptet, int Course, int Count, int Score)
        {
            rd = new Random();
            List<Judgment> list = InfoControl.OesData.FindAllJudgment("", Chaptet, Course, Plevel, 1, int.MaxValue);
            if (list.Count < Count)
            {
                MessageBox.Show("数据库中题目不足！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            while (Count > 0)
            {
                int tmp = rd.Next(list.Count);
                bool flag = true;
                foreach (Judgment pro in NewPaper.judge)
                {
                    if (pro.problemId == list[tmp].problemId)
                    {
                        flag = false;
                    }
                }
                if (flag)
                {
                    list[tmp].score = Score;
                    NewPaper.judge.Add(list[tmp]);
                    Count--;
                }
            }
        }

        private void AddCompletion(int Plevel, int Chaptet, int Course, int Count, int Score)
        {
            rd = new Random();
            List<Completion> list = InfoControl.OesData.FindAllCompletion("", Chaptet, Course, Plevel, 1, int.MaxValue);
            if (list.Count < Count)
            {
                MessageBox.Show("数据库中题目不足！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            while (Count > 0)
            {
                int tmp = rd.Next(list.Count);
                bool flag = true;
                foreach (Completion pro in NewPaper.completion)
                {
                    if (pro.problemId == list[tmp].problemId)
                    {
                        flag = false;
                    }
                }
                if (flag)
                {
                    list[tmp].score = Score;
                    NewPaper.completion.Add(list[tmp]);
                    Count--;
                }
            }
        }

        private void AddProgramProblem(ProgramPType pType,PLanguage language, int Plevel, int Chaptet, int Course, int Count, int Score, ref List<ProgramProblem> ProList)
        {
            rd = new Random();
            List<ProgramProblem> list = InfoControl.OesData.FindAllProgram("", pType, language, Chaptet, Course, Plevel, 1, int.MaxValue);
            if (list.Count < Count)
            {
                MessageBox.Show("数据库中题目不足！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            while (Count > 0)
            {
                int tmp = rd.Next(list.Count);
                bool flag = true;
                foreach (ProgramProblem pro in NewPaper.pCompletion)
                {
                    if (pro.problemId == list[tmp].problemId)
                    {
                        flag = false;
                    }
                }
                if (flag)
                {
                    list[tmp].score = Score;
                    ProList.Add(list[tmp]);
                    Count--;
                }
            }
        }
        #endregion

        #region 事件
        private void btnAddRule_Click(object sender, EventArgs e)
        {
            frmAddRule = new frmAddRule(Convert.ToInt32(cboCourse.SelectedValue));
            frmAddRule.ShowDialog();
            PaperRule tmpRule;
            tmpRule = frmAddRule.NewRule;
            if (tmpRule != null)
            {
                Rules.Add(frmAddRule.NewRule);
                TotScore = TotScore + tmpRule.Score * tmpRule.Count;
                lbTotScore.Text = TotScore.ToString();
                dtRule.Rows.Add(new object[6] { false, tmpRule.ChapterName, tmpRule.PTypeName, tmpRule.PLevel, tmpRule.Score, tmpRule.Count });
                //MessageBox.Show(
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvRule.SelectedRows.Count > 0 && dgvRule.SelectedRows[0].Index >= 0)
            {
                frmAddRule = new frmAddRule(Rules[dgvRule.SelectedRows[0].Index]);
                frmAddRule.ShowDialog();
                PaperRule tmpRule;
                int Index = dgvRule.SelectedRows[0].Index;
                tmpRule = frmAddRule.NewRule;
                if (tmpRule != null)
                {
                    TotScore = TotScore - Rules[Index].Score * Rules[Index].Count;
                    TotScore = TotScore + tmpRule.Count * tmpRule.Score;
                    Rules[Index] = tmpRule;
                    lbTotScore.Text = TotScore.ToString();
                    dtRule.Rows[Index][0] = false;
                    dtRule.Rows[Index][1] = tmpRule.ChapterName;
                    dtRule.Rows[Index][2] = tmpRule.PTypeName;
                    dtRule.Rows[Index][3] = tmpRule.PLevel;
                    dtRule.Rows[Index][4] = tmpRule.Score;
                    dtRule.Rows[Index][5] = tmpRule.Count;
                }
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            foreach (DataRow rows in dtRule.Select("选中=true"))
            {
                Rules.Remove(Rules[dtRule.Rows.IndexOf(rows)]);
                dtRule.Rows.Remove(rows);
            }
        }
        
        private void btnCreate_Click(object sender, EventArgs e)
        {
            NewPaper = new Paper();
            NewPaper.paperName = tbPaperName.Text;
            NewPaper.authorId = InfoControl.User.Id;
            NewPaper.author = InfoControl.User.UserName;
            foreach (PaperRule rule in Rules)
            {
                switch (rule.PType)
                {
                    case ProblemType.Choice:
                        AddChoice(rule.PLevel, rule.Chapter, rule.Course, rule.Count, rule.Score);
                        break;
                    case ProblemType.Completion:
                        AddCompletion(rule.PLevel, rule.Chapter, rule.Course, rule.Count, rule.Score);
                        break;
                    case ProblemType.Judgment:
                        AddJudgement(rule.PLevel, rule.Chapter, rule.Course, rule.Count, rule.Score);
                        break;
                    case ProblemType.CppProgramCompletion:
                        AddProgramProblem(ProgramPType.Completion,  PLanguage.CPP, rule.PLevel, rule.Chapter, rule.Course, rule.Count, rule.Score, ref NewPaper.pCompletion);
                        break;
                    case ProblemType.CppProgramModification:
                        AddProgramProblem(ProgramPType.Modify, PLanguage.CPP, rule.PLevel, rule.Chapter, rule.Course, rule.Count, rule.Score, ref NewPaper.pModif);
                        break;
                    case ProblemType.CppProgramFun:
                        AddProgramProblem(ProgramPType.Function, PLanguage.CPP, rule.PLevel, rule.Chapter, rule.Course, rule.Count, rule.Score, ref NewPaper.pFunction);
                        break;
                    case ProblemType.CProgramCompletion:
                        AddProgramProblem(ProgramPType.Completion,PLanguage.C, rule.PLevel, rule.Chapter, rule.Course, rule.Count, rule.Score, ref NewPaper.pCompletion);
                        break;
                    case ProblemType.CProgramModification:
                        AddProgramProblem(ProgramPType.Modify, PLanguage.C, rule.PLevel, rule.Chapter, rule.Course, rule.Count, rule.Score, ref NewPaper.pModif);
                        break;
                    case ProblemType.CProgramFun:
                        AddProgramProblem(ProgramPType.Function,PLanguage.C, rule.PLevel, rule.Chapter, rule.Course, rule.Count, rule.Score, ref NewPaper.pFunction);
                        break;
                    case ProblemType.VbProgramCompletion:
                        AddProgramProblem(ProgramPType.Completion, PLanguage.VB, rule.PLevel, rule.Chapter, rule.Course, rule.Count, rule.Score, ref NewPaper.pCompletion);
                        break;
                    case ProblemType.VbProgramModification:
                        AddProgramProblem(ProgramPType.Modify, PLanguage.VB, rule.PLevel, rule.Chapter, rule.Course, rule.Count, rule.Score, ref NewPaper.pModif);
                        break;
                    case ProblemType.VbProgramFun:
                        AddProgramProblem(ProgramPType.Function, PLanguage.VB, rule.PLevel, rule.Chapter, rule.Course, rule.Count, rule.Score, ref NewPaper.pFunction);
                        break;
                }
            }
            paperPreview = new frmPaperPreview(NewPaper);
            paperPreview.ShowDialog();

        }

        private void cboCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((EndLoad)&&(MessageBox.Show("所有出卷规则将会清空", "警告", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning) == DialogResult.Yes))
            {
                Rules = new List<PaperRule>();
                dtRule.Clear();
                lbTotScore.Text = "0";
                TotScore = 0;
            }
        }
        #endregion
    }
}