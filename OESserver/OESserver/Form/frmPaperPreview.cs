using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OES.Model;

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
    }
}
