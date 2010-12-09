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
                count = Convert.ToInt32(this.WordCount.Text) + count;
            }
            if (this.ExcelCount.Enabled)
            {
                count = Convert.ToInt32(this.ExcelCount.Text) + count;
            }
            if (this.PPTCount.Enabled)
            {
                count = Convert.ToInt32(this.PPTCount.Text) + count;
            }
            if (this.PCompletionCount.Enabled)
            {
                count = Convert.ToInt32(this.PCompletionCount.Text) + count;
            }
            if (this.PModifCount.Enabled)
            {
                count = Convert.ToInt32(this.PModifCount.Text) + count;
            }
            if (this.PFunctionCount.Enabled)
            {
                count = Convert.ToInt32(this.PFunctionCount.Text) + count;
            }
            this.ProCount.Text = count.ToString() + "题";
        }
    }
}