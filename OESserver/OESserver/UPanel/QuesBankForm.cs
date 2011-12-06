using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OES.UPanel
{
    public partial class QuesBankForm : UserPanel
    {
        private DataTable questionTable;

        public void InitDT()
        {
            questionTable = new DataTable("questionlist");
            questionTable.Columns.Add("选择",typeof(bool));
            questionTable.Columns.Add("题名");
            questionTable.Columns.Add("题型");
            questionTable.Columns.Add("章节");
            questionTable.Columns.Add("难度");
        }

        public QuesBankForm()
        {
            InitializeComponent();

        }

        public override void ReLoad()
        {
            this.Visible = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PanelControl.ChangPanel(8);
        }
    }
}
