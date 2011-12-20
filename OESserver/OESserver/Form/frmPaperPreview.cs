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

        }

        public frmPaperPreview(Paper paper)
        {
            InitializeComponent();
            NewPaper = paper;
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
            Init();
            
        }

        private string GetAnswer(ProblemType PT,int ID)
        {
            string ans = "";
            List<Choice> choice;
            List<Completion> completion;
            List<Judgment> judgt;
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
            }
            return "";
        }


        private void CreatPaper()
        {
            int i;
            NewPaper.paperID = InfoControl.OesData.AddPaper(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), NewPaper.paperName, NewPaper.authorId);
            XMLControl.CreatePaperXML(InfoControl.config["TempPaperPath"] + NewPaper.paperID.ToString() + ".xml", NewPaper.paperID.ToString());
            XMLControl.CreatePaperAnsXML(InfoControl.config["TempPaperPath"] + "A" + NewPaper.paperID.ToString() + ".xml", NewPaper.paperID.ToString());

            for (i = 0; i < NewPaper.choice.Count; i++)
            {
                XMLControl.AddProblemToPaper(NewPaper.choice[i].type, NewPaper.choice[i].problemId, NewPaper.choice[i].score);
                XMLControl.AddPaperAns(NewPaper.choice[i].type, NewPaper.choice[i].problemId, GetAnswer(NewPaper.choice[i].type, NewPaper.choice[i].problemId));
            }
            for (i = 0; i < NewPaper.completion.Count; i++)
            {
                XMLControl.AddProblemToPaper(NewPaper.completion[i].type, NewPaper.completion[i].problemId, NewPaper.completion[i].score);
                XMLControl.AddPaperAns(NewPaper.completion[i].type, NewPaper.completion[i].problemId, GetAnswer(NewPaper.completion[i].type, NewPaper.completion[i].problemId));
            }
            for (i = 0; i < NewPaper.judge.Count; i++)
            {
                XMLControl.AddProblemToPaper(NewPaper.judge[i].type, NewPaper.judge[i].problemId, NewPaper.judge[i].score);
                XMLControl.AddPaperAns(NewPaper.judge[i].type, NewPaper.judge[i].problemId, GetAnswer(NewPaper.judge[i].type, NewPaper.judge[i].problemId));
            }
            InfoControl.ClientObj.SavePaper(Convert.ToInt32(NewPaper.paperID), Convert.ToInt32(InfoControl.User.Id));
            InfoControl.ClientObj.SendFiles();
            while (!ClientEvt.isOver) ;
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            CreatPaper();
            this.Close();
        }
    }
}
