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
        private frmAddRule frmAddRule;
        private List<PaperRule> Rules;

        public PaperInfo()
        {
            InitializeComponent();
            dtRule = new DataTable();
            dtRule.Columns.Add("选中",typeof(bool));
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
        }

        override public void ReLoad()
        {
            Rules = new List<PaperRule>();
            dtRule.Clear();
            this.Visible = true;
        }

        private void btnAddRule_Click(object sender, EventArgs e)
        {
            frmAddRule = new frmAddRule();
            frmAddRule.ShowDialog();
            PaperRule tmpRule;
            tmpRule = frmAddRule.NewRule;
            if (tmpRule != null)
            {
                Rules.Add(frmAddRule.NewRule);
                dtRule.Rows.Add(new object[6] {false,tmpRule.ChapterName,tmpRule.PTypeName,tmpRule.PLevel,tmpRule.Score,tmpRule.Count});
                //MessageBox.Show(
            }
        }


    }
}