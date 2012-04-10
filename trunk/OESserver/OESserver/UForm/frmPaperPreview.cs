using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OES.Model;
using OES.XMLFile;
using OES.Net;

namespace OES
{
    public partial class frmPaperPreview : Form
    {

        private DataTable dtPaperPreview;
        private Paper NewPaper;
        private frmQuesChange ProChange;
        private bool isNew;

        private int CountScore()
        {
            int s;
            s = 0;
            foreach (Problem pro in NewPaper.problemList)
            {
                s = s + pro.score;
            }
            return s;
        }
        private void Init()
        {
            int i;
            for (i = 0; i < NewPaper.choice.Count; i++)
            {
                dtPaperPreview.Rows.Add(new object[5] { NewPaper.choice[i].problem, Paper.GetPTypeName(NewPaper.choice[i].type), NewPaper.choice[i].Plevel, NewPaper.choice[i].score, i });
            }
            for (i = 0; i < NewPaper.completion.Count; i++)
            {
                dtPaperPreview.Rows.Add(new object[5] { NewPaper.completion[i].problem, Paper.GetPTypeName(NewPaper.completion[i].type), NewPaper.completion[i].Plevel, NewPaper.completion[i].score, i });
            }

            for (i = 0; i < NewPaper.judge.Count; i++)
            {
                dtPaperPreview.Rows.Add(new object[5] { NewPaper.judge[i].problem, Paper.GetPTypeName(NewPaper.judge[i].type), NewPaper.judge[i].Plevel, NewPaper.judge[i].score, i });
            }
            for (i = 0; i < NewPaper.pCompletion.Count; i++)
            {
                dtPaperPreview.Rows.Add(new object[5] { NewPaper.pCompletion[i].problem, Paper.GetPTypeName(NewPaper.pCompletion[i].type), NewPaper.pCompletion[i].Plevel, NewPaper.pCompletion[i].score, i });
            }
            for (i = 0; i < NewPaper.pModif.Count; i++)
            {
                dtPaperPreview.Rows.Add(new object[5] { NewPaper.pModif[i].problem, Paper.GetPTypeName(NewPaper.pModif[i].type), NewPaper.pModif[i].Plevel, NewPaper.pModif[i].score, i });
            }
            for (i = 0; i < NewPaper.pFunction.Count; i++)
            {
                dtPaperPreview.Rows.Add(new object[5] { NewPaper.pFunction[i].problem, Paper.GetPTypeName(NewPaper.pFunction[i].type), NewPaper.pFunction[i].Plevel, NewPaper.pFunction[i].score, i });
            }
        }

        //public frmPaperPreview()
        //{
        //    InitializeComponent();
        //    isNew = false;
        //    dtPaperPreview = new DataTable();
        //    dtPaperPreview.Columns.Add("题干");
        //    dtPaperPreview.Columns.Add("题目类型");
        //    dtPaperPreview.Columns.Add("难度值");
        //    dtPaperPreview.Columns.Add("分值");
        //    dtPaperPreview.Columns.Add("Index");

        //    dgvPaperPreview.DataSource = dtPaperPreview;
        //    dgvPaperPreview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        //    dgvPaperPreview.Columns["Index"].Visible = false;
        //    dgvPaperPreview.Columns[0].FillWeight = 40;
        //    dgvPaperPreview.Columns[1].FillWeight = 15;
        //    dgvPaperPreview.Columns[2].FillWeight = 15;
        //    dgvPaperPreview.Columns[3].FillWeight = 15;
        //    dgvPaperPreview.Columns[4].FillWeight = 15;

        //    dgvPaperPreview.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
        //    dgvPaperPreview.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
        //    dgvPaperPreview.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
        //    dgvPaperPreview.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
        //    NewPaper = InfoControl.TmpPaper;
        //    foreach (Problem pro in NewPaper.problemList)
        //    {
        //        dtPaperPreview.Rows.Add(new object[5] { pro.problem, Paper.GetPTypeName(pro.type), pro.Plevel, pro.score, 0 });
        //    }
        //}

        public frmPaperPreview(Paper paper)
        {
            InitializeComponent();
            isNew = (paper.paperID == -1);
            NewPaper = paper;
            tbPaperName.Text = NewPaper.paperName;
            dtPaperPreview = new DataTable();
            dtPaperPreview.Columns.Add("题干");
            dtPaperPreview.Columns.Add("题目类型");
            dtPaperPreview.Columns.Add("难度值");
            dtPaperPreview.Columns.Add("分值");
            dtPaperPreview.Columns.Add("Index");

            dgvPaperPreview.DataSource = dtPaperPreview;
            dgvPaperPreview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPaperPreview.Columns["Index"].Visible = false;
            dgvPaperPreview.Columns[0].FillWeight = 40;
            dgvPaperPreview.Columns[1].FillWeight = 15;
            dgvPaperPreview.Columns[2].FillWeight = 15;
            dgvPaperPreview.Columns[3].FillWeight = 15;
            dgvPaperPreview.Columns[4].FillWeight = 15;

            dgvPaperPreview.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvPaperPreview.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvPaperPreview.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvPaperPreview.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            foreach (Problem pro in NewPaper.problemList)
            {
                dtPaperPreview.Rows.Add(new object[5] { pro.problem, Paper.GetPTypeName(pro.type), pro.Plevel, pro.score, 0 });
            }
            lbTScore.Text = CountScore().ToString();
        }

        private string GetAnswer(ProblemType PT, int ID)
        {
            string ans = "";
            List<Choice> choice;
            List<Completion> completion;
            List<Judgment> judgt;
            List<ProgramProblem> ProProblem;
            switch (PT)
            {
                case ProblemType.Choice:
                    choice = InfoControl.OesData.FindChoiceByPID(ID);
                    if (choice.Count > 0)
                    {
                        return choice[0].ans;
                    }
                    break;
                case ProblemType.Judgment:
                    judgt = InfoControl.OesData.FindJudgmentByPID(ID);
                    if (judgt.Count > 0)
                    {
                        return judgt[0].ans;
                    }
                    break;
                case ProblemType.Completion:
                    completion = InfoControl.OesData.FindCompletionByPID(ID);
                    if (completion.Count > 0)
                    {
                        ans = "";
                        foreach (string st in completion[0].ans)
                        {
                            ans = ans + st + "\n";
                        }
                        return ans;
                    }
                    break;
                case ProblemType.CProgramCompletion:
                case ProblemType.CppProgramCompletion:
                case ProblemType.VbProgramCompletion:
                    ProProblem = InfoControl.OesData.FindProgramByPID(ID);
                    if (ProProblem.Count > 0)
                    {
                        ans = "";
                    }
                    break;
            }
            return "";
        }

        private void AddProgramProblem(List<ProgramProblem> ProList)
        {
            foreach (ProgramProblem problem in ProList)
            {
                XMLControl.AddProblemToPaper(problem.type, problem.problemId, problem.score);
            }
        }

        private void CreatPaper()
        {
            int i;
            NewPaper.paperName = tbPaperName.Text;
            if (isNew)
            {
                NewPaper.paperID = InfoControl.OesData.AddPaper(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), NewPaper.paperName, NewPaper.authorId);
            }
            else
            {
                InfoControl.OesData.UpdatePaper(NewPaper.paperID, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), NewPaper.paperName, InfoControl.User.Id);
            }
            XMLControl.CreatePaperXML(InfoControl.config["TempPaperPath"] + NewPaper.paperID.ToString() + ".xml", NewPaper.paperID.ToString());
            XMLControl.CreatePaperAnsXML(InfoControl.config["TempPaperPath"] + "A" + NewPaper.paperID.ToString() + ".xml", NewPaper.paperID.ToString());

            foreach (Problem pro in NewPaper.problemList)
            {
                XMLControl.AddProblemToPaper(pro.type, pro.problemId, pro.score);
                if ((pro.type == ProblemType.Choice) || (pro.type == ProblemType.Completion) || (pro.type == ProblemType.Judgment))
                {
                    XMLControl.AddPaperAns(pro.type, pro.problemId, GetAnswer(pro.type, pro.problemId));
                }

            }
            InfoControl.ClientObj.SavePaper(Convert.ToInt32(NewPaper.paperID), Convert.ToInt32(InfoControl.User.Id));
            InfoControl.ClientObj.SendFiles();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            ClientEvt.FilesComplete += new Action(ClientEvt_FilesComplete);
            CreatPaper();

        }

        void ClientEvt_FilesComplete()
        {
            this.Close();
            ClientEvt.FilesComplete -= ClientEvt_FilesComplete;
        }

        private void btnReplace_Click(object sender, EventArgs e)
        {
            int index = dgvPaperPreview.SelectedRows[0].Index;
            ProChange = new frmQuesChange(NewPaper.problemList[index]);
            ProChange.ShowDialog();
            if (ProChange.thePro != null)
            {
                NewPaper.problemList[index] = ProChange.thePro;
                dgvPaperPreview.SelectedRows[0].Cells[0].Value = ProChange.thePro.problem;
                dgvPaperPreview.SelectedRows[0].Cells[1].Value = Paper.GetPTypeName(ProChange.thePro.type);
                dgvPaperPreview.SelectedRows[0].Cells[2].Value = ProChange.thePro.Plevel;
                dgvPaperPreview.SelectedRows[0].Cells[3].Value = ProChange.thePro.score;
                lbTScore.Text = CountScore().ToString();
            }
            
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (dgvPaperPreview.RowCount > 0)
            {
                int index = dgvPaperPreview.SelectedRows[0].Index;
                if (MessageBox.Show("确定删除记录", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    NewPaper.problemList.Remove(NewPaper.problemList[index]);
                    dtPaperPreview.Rows[index].Delete();
                    lbTScore.Text = CountScore().ToString();
                }
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ProChange = new frmQuesChange(null);
            ProChange.ShowDialog();
            if (ProChange.thePro != null)
            {
                NewPaper.problemList.Add(ProChange.thePro);
                dtPaperPreview.Rows.Add(new object[5] { ProChange.thePro.problem, Paper.GetPTypeName(ProChange.thePro.type), ProChange.thePro.Plevel, ProChange.thePro.score, 0 });
                lbTScore.Text = CountScore().ToString();
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
