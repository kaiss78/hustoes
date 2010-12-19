using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OESserver.UPanel
{
    public partial class PaperListPanel : UserPanel
    {
        private DataTable paperListDataTable;
        public PaperListPanel()
        {
            InitializeComponent();
            paperListDataTable=new DataTable("PaperList");
            paperListDataTable.Columns.Add("试卷ID");            
            paperListDataTable.Columns.Add("试卷名称");
            paperListDataTable.Columns.Add("组卷时间");
            paperListDataTable.Columns.Add("作者");
            object[] values = new object[4];
            values[0] = 1;
            values[1] = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";
            values[2] = "2010.12.19";
            values[3] = "PL";
            paperListDataTable.Rows.Add(values);
            PaperListDGV.DataSource = paperListDataTable;
            PaperListDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            PaperListDGV.Columns[0].FillWeight = 15;
            PaperListDGV.Columns[1].FillWeight = 55;
            PaperListDGV.Columns[2].FillWeight = 15;
            PaperListDGV.Columns[3].FillWeight = 15;
            //PaperListDGV.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            
        }
        override public void ReLoad()
        {
            this.Visible = true;
        }
    }
}
