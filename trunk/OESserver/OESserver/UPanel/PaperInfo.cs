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

        public PaperInfo()
        {
            InitializeComponent();
            dtRule = new DataTable();
            dtRule.Columns.Add("章节");
            dtRule.Columns.Add("题目类型");
            dtRule.Columns.Add("难度值");
            dtRule.Columns.Add("分值");
            dtRule.Columns.Add("数量");
            dgvRule.DataSource = dtRule;            
        }

        override public void ReLoad()
        {
            this.Visible = true;
        }

        private void btnAddRule_Click(object sender, EventArgs e)
        {
            //frmAddRule
        }



    }

}