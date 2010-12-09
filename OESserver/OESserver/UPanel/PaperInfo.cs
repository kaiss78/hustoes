using System;
using System.Windows.Forms;

namespace OESserver.UPanel
{
    public partial class PaperInfo : UserControl
    {
        public PaperInfo()
        {
            InitializeComponent();
        }

        private void TotalPro_Click(object sender, EventArgs e)
        {
            int count = 0;
            if (this.ChoiceCount.Enabled)
            {
                count = Convert.ToInt32(this.ChoiceCount.Text) + count;
            }
            if (this.CompletionCount.Enabled)
            {
                count = Convert.ToInt32(this.CompletionCount.Text) + count;
            }
            if (this.JudgeCount.Enabled)
            {
                count = Convert.ToInt32(this.JudgeCount.Text) + count;
            }
            if (this.WordCount.Enabled)
            {
                count = 1 + count;
            }
            if (this.ExcelCount.Enabled)
            {
                count = 1 + count;
            }
            if (this.PPTCount.Enabled)
            {
                count = 1 + count;
            }
            if (this.PCompletionCount.Enabled)
            {
                count = 1 + count;
            }
            if (this.PModifCount.Enabled)
            {
                count = 1 + count;
            }
            if (this.PFunctionCount.Enabled)
            {
                count = 1 + count;
            }
            this.ProCount.Text = count.ToString() + "题";
        }

        private void TotalScore_Click(object sender, EventArgs e)
        {
            int count = 0;
            if (this.ChoiceWeight.Enabled)
            {
                count = Convert.ToInt32(this.ChoiceWeight.Text) * Convert.ToInt32(this.ChoiceCount.Text) + count;
            }
            if (this.CompletionWeight.Enabled)
            {
                count = Convert.ToInt32(this.CompletionWeight.Text) * Convert.ToInt32(this.CompletionCount.Text) + count;
            }
            if (this.JudgeWeight.Enabled)
            {
                count = Convert.ToInt32(this.JudgeWeight.Text) * Convert.ToInt32(this.JudgeCount.Text) + count;
            }
            if (this.WordWeight.Enabled)
            {
                count = Convert.ToInt32(this.WordWeight.Text) + count;
            }
            if (this.ExcelWeight.Enabled)
            {
                count = Convert.ToInt32(this.ExcelWeight.Text) + count;
            }
            if (this.PPTWeight.Enabled)
            {
                count = Convert.ToInt32(this.PPTWeight.Text) + count;
            }
            if (this.PCompletionWeight.Enabled)
            {
                count = Convert.ToInt32(this.PCompletionWeight.Text) + count;
            }
            if (this.PModifWeight.Enabled)
            {
                count = Convert.ToInt32(this.PModifWeight.Text) + count;
            }
            if (this.PFunctionWeight.Enabled)
            {
                count = Convert.ToInt32(this.PFunctionWeight.Text) + count;
            }
            this.Score.Text = count.ToString() + "分";
        }
    }
}