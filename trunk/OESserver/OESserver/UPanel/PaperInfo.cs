using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OES.XMLFile;
using OES.Model;

//using OES.XMLFile;

namespace OES.UPanel
{
    public partial class PaperInfo : UserPanel
    {
        public List<TextBox> scoreList = new List<TextBox>(9);
        public List<TextBox> countList = new List<TextBox>(3);
        public int[] flag = new int[9];
        public OESData oesData;
        public int programstate;

        public PaperInfo()
        {
            InitializeComponent();

            countList.Add(ChoiceCount);
            countList.Add(CompletionCount);
            countList.Add(JudgeCount);

            scoreList.Add(ChoiceWeight);
            scoreList.Add(CompletionWeight);
            scoreList.Add(JudgeWeight);
            scoreList.Add(WordWeight);
            scoreList.Add(ExcelWeight);
            scoreList.Add(PPTWeight);
            scoreList.Add(PCompletionWeight);
            scoreList.Add(PModifWeight);
            scoreList.Add(PFunctionWeight);

            this.ReLoad();
            this.Visible = false;
        }

        public void count()
        {
            int count = 0;
            int score = 0;
            for (int i = 0; i < 3; i++)
            {
                count = count + flag[i] * Convert.ToInt32(countList[i].Text);
                score = score + flag[i] * Convert.ToInt32(countList[i].Text) * Convert.ToInt32(scoreList[i].Text);
            }
            for (int i = 3; i < 9; i++)
            {
                count = count + flag[i];
                score = score + flag[i] * Convert.ToInt32(scoreList[i].Text);
            }
            this.ProCount.Text = count.ToString() + "题";
            this.Score.Text = score.ToString() + "分";
        }

        public int GetTag(Control con)
        {
            return Convert.ToInt32(con.Tag);
        }

        private void Count_Click(object sender, EventArgs e)
        {
            this.count();
        }

        override public void ReLoad()
        {
            this.Visible = true;
           
            for (int i = 0; i < 9; i++)
            {
                flag[i] = 1;
                scoreList[i].Enabled = true;
                scoreList[i].Text = "0";
            }
            CppPro.Checked = true;
            this.ChoiceCount.Text = "0";
            this.JudgeCount.Text = "0";
            this.CompletionCount.Text = "0";
            countList[0].Enabled = true;
            countList[1].Enabled = true;
            countList[2].Enabled = true;
            this.count();
        }

        override public void ReLoad(Paper p)
        {
            this.Visible = true;
        }

        private void CountButton_Click(object sender, EventArgs e)
        {
            int x = this.GetTag((Control)sender);
            flag[x] = 1 - flag[x];
            scoreList[x].Enabled = Convert.ToBoolean(flag[x]);
            if (x < 3)
            {
                countList[x].Enabled = Convert.ToBoolean(flag[x]);
            }
        }

        private void OK_Click(object sender, EventArgs e)
        {
            if (flag[6] + flag[7] + flag[8] > 0)
            {
                if (CPro.Checked)
                {
                    programstate = 2;
                }
                if (CppPro.Checked)
                {
                    programstate = 1;
                }
            }
            else
            {
                programstate = 0;
            }

            InfoControl.TmpPaper.paperID = InfoControl.OesData.AddPaper(DateTime.Today.ToString(), TestTime.Text, Config.TempPaperPath, PaperName.Text, InfoControl.User.Id, programstate);
            InfoControl.TmpPaper.paperName = PaperName.Text;
            InfoControl.TmpPaper.programState = programstate;
            InfoControl.TmpPaper.paperPath = Config.TempPaperPath + InfoControl.TmpPaper.paperID + ".xml";

            InfoControl.TmpPaper.choice = new List<Choice>(Convert.ToInt32(countList[0].Text));
            InfoControl.TmpPaper.completion = new List<Completion>(Convert.ToInt32(countList[1].Text));
            InfoControl.TmpPaper.judge = new List<Judge>(Convert.ToInt32(countList[2].Text));

            Choice tmpChoice = new Choice();
            tmpChoice.problemId = -1;
            tmpChoice.problem = "-";

            Completion tmpCompletion = new Completion();
            tmpCompletion.problemId = -1;
            tmpCompletion.problem = "-";

            Judge tmpJudge = new Judge();
            tmpJudge.problemId = -1;
            tmpJudge.problem = "-";

            for (int i = 0; i < InfoControl.TmpPaper.choice.Capacity; i++)
            {
                InfoControl.TmpPaper.choice.Add(tmpChoice);
            }
            for (int i = 0; i < InfoControl.TmpPaper.completion.Capacity; i++)
            {
                InfoControl.TmpPaper.completion.Add(tmpCompletion);
            }
            for (int i = 0; i < InfoControl.TmpPaper.judge.Capacity; i++)
            {
                InfoControl.TmpPaper.judge.Add(tmpJudge);
            }

            InfoControl.TmpPaper.ProList[0] = new List<Problem>();
            foreach (Choice c in InfoControl.TmpPaper.choice)
            {
                InfoControl.TmpPaper.ProList[0].Add(c);
            }
            InfoControl.TmpPaper.ProList[1] = new List<Problem>();
            foreach (Completion c in InfoControl.TmpPaper.completion)
            {
                InfoControl.TmpPaper.ProList[1].Add(c);
            }
            InfoControl.TmpPaper.ProList[2] = new List<Problem>();
            foreach (Judge c in InfoControl.TmpPaper.judge)
            {
                InfoControl.TmpPaper.ProList[2].Add(c);
            }

            InfoControl.TmpPaper.officeWord.exist = flag[3] == 1;
            InfoControl.TmpPaper.officeWord.problemId = -1;
            InfoControl.TmpPaper.officeExcel.exist = flag[4] == 1;
            InfoControl.TmpPaper.officeExcel.problemId = -1;
            InfoControl.TmpPaper.officePPT.exist = flag[5] == 1;
            InfoControl.TmpPaper.officePPT.problemId = -1;
            InfoControl.TmpPaper.pCompletion.exist = flag[6] == 1;
            InfoControl.TmpPaper.pCompletion.problemId = -1;
            InfoControl.TmpPaper.pModif.exist = flag[7] == 1;
            InfoControl.TmpPaper.pModif.problemId = -1;
            InfoControl.TmpPaper.pFunction.exist = flag[8] == 1;
            InfoControl.TmpPaper.pFunction.problemId = -1;                        
            PanelControl.ChangPanel(19);
        }        
    }

}