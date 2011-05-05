using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OES.XMLFile;
using OES.Model;

namespace OES.UPanel
{
    public partial class PaperInfo : UserPanel
    {
        public List<TextBox> scoreList = new List<TextBox>(9);
        public List<TextBox> countList = new List<TextBox>(3);        
        public int[] flag = new int[9];        
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
            this.PaperName.Text = "";
            countList[0].Enabled = true;
            countList[1].Enabled = true;
            countList[2].Enabled = true;
            this.count();
        }

        override public void ReLoad(Paper p)
        {
            this.Visible = true;
            this.PaperName.Text = InfoControl.TmpPaper.paperName;
           // this.TestTime.Value =Convert.ToDateTime( InfoControl.TmpPaper.testTime);
            for (int i = 0; i < 3; i++)
            {
                if (InfoControl.TmpPaper.ProList[i].Count > 0)
                {
                    countList[i].Text = InfoControl.TmpPaper.ProList[i].Count.ToString();
                }
                else
                {
                    countList[i].Text = "0";
                }
            }
            for (int i = 0; i < 9; i++)
            {
                if (InfoControl.TmpPaper.ProList[i].Count > 0)
                {
                    scoreList[i].Text = InfoControl.TmpPaper.ProList[i][0].score.ToString();
                    flag[i] = 1;
                }
                else
                {
                    scoreList[i].Text = "0";
                    flag[i] = 0;                    
                }
                setButton(i);
            }
        }

        private void setButton(int x)
        {            
            scoreList[x].Enabled = Convert.ToBoolean(flag[x]);
            if (x < 3)
            {
                countList[x].Enabled = Convert.ToBoolean(flag[x]);
            }
        }

        private void CountButton_Click(object sender, EventArgs e)
        {
            int x = this.GetTag((Control)sender);
            flag[x] = 1 - flag[x];
            this.setButton(x);
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
            InfoControl.TmpPaper.paperName = PaperName.Text;
            InfoControl.TmpPaper.programState = programstate;
            InfoControl.TmpPaper.score_choice = Convert.ToInt32(this.ChoiceWeight.Text);
            InfoControl.TmpPaper.score_completion = Convert.ToInt32(this.CompletionWeight.Text);
            InfoControl.TmpPaper.score_judge = Convert.ToInt32(this.JudgeWeight.Text);
            InfoControl.TmpPaper.score_officeExcel = Convert.ToInt32(this.ExcelWeight.Text);
            InfoControl.TmpPaper.score_officePPT = Convert.ToInt32(this.PPTWeight.Text);
            InfoControl.TmpPaper.score_officeWord = Convert.ToInt32(this.WordWeight.Text);
            InfoControl.TmpPaper.score_pCompletion = Convert.ToInt32(this.PCompletionWeight.Text);
            InfoControl.TmpPaper.score_pFunction = Convert.ToInt32(this.PFunctionWeight.Text);
            InfoControl.TmpPaper.score_pModif = Convert.ToInt32(this.PModifWeight.Text);

            if (InfoControl.TmpPaper.paperID == "-")
            {
                InfoControl.TmpPaper.paperID = InfoControl.OesData.AddPaper(DateTime.Today.ToString(), TestTime.Text, Config.TempPaperPath, PaperName.Text, InfoControl.User.Id, programstate);
                InfoControl.TmpPaper.paperPath = Config.TempPaperPath + InfoControl.TmpPaper.paperID + ".xml";
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < Convert.ToInt32(this.countList[i].Text); j++)
                    {
                        Problem tmpPro = new Problem();
                        tmpPro.problemId = -1;
                        tmpPro.problem = "-";
                        InfoControl.TmpPaper.ProList[i].Add(tmpPro);
                    }
                }
                for (int i = 3; i < 9; i++)
                {
                    Problem tmpPro = new Problem();
                    tmpPro.problemId = -1;
                    tmpPro.problem = "-";
                    InfoControl.TmpPaper.ProList[i].Add(tmpPro);
                }
                InfoControl.TmpPaper.officeExcel = new OfficeExcel();
                InfoControl.TmpPaper.officeExcel.exist = flag[4] == 1;
            
                InfoControl.TmpPaper.officePPT = new OfficePowerPoint();
                InfoControl.TmpPaper.officePPT.exist = flag[5] == 1;

                InfoControl.TmpPaper.officeWord = new OfficeWord();
                InfoControl.TmpPaper.officeWord.exist = flag[3] == 1;
                InfoControl.TmpPaper.officeWord.problemId = -1;

                InfoControl.TmpPaper.pCompletion = new PCompletion();
                InfoControl.TmpPaper.pCompletion.exist = flag[6] == 1;
   
                InfoControl.TmpPaper.pModif = new PModif();
                InfoControl.TmpPaper.pModif.exist = flag[7] == 1;

                InfoControl.TmpPaper.pFunction = new PFunction();
                InfoControl.TmpPaper.pFunction.exist = flag[8] == 1;
            }
            else
            { 
            }        
            PanelControl.ChangPanel(19);
        }        
    }

}