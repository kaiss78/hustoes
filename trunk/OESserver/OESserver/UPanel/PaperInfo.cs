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
                tmpRule = frmAddRule.NewRule;
                if (tmpRule != null)
                {
                    Rules[dgvRule.SelectedRows[0].Index] = tmpRule;
                    dtRule.Rows[dgvRule.SelectedRows[0].Index][0] = false;
                    dtRule.Rows[dgvRule.SelectedRows[0].Index][1] = tmpRule.ChapterName;
                    dtRule.Rows[dgvRule.SelectedRows[0].Index][2] = tmpRule.PTypeName;
                    dtRule.Rows[dgvRule.SelectedRows[0].Index][3] = tmpRule.PLevel;
                    dtRule.Rows[dgvRule.SelectedRows[0].Index][4] = tmpRule.Score;
                    dtRule.Rows[dgvRule.SelectedRows[0].Index][5] = tmpRule.Count;
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
            foreach (PaperRule rule in Rules)
            { 

            }
        }
    }
}