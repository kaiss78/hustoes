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
            paperListDataTable.Columns.Add("选中", typeof(bool));
            paperListDataTable.Columns.Add("试卷ID");
            paperListDataTable.Columns.Add("试卷名称");
            paperListDataTable.Columns.Add("组卷时间");
            paperListDataTable.Columns.Add("作者");
            object[] values = new object[5];
            values[0] = false;
            values[1] = 1;
            values[2] = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";
            values[3] = "2010.12.19";
            values[4] = "PL";

            paperListDataTable.Rows.Add(values);
            paperListDataTable.Rows.Add(values);
            paperListDataTable.Rows.Add(values);
            paperListDataTable.Rows.Add(values);
            paperListDataTable.Rows.Add(values);
            paperListDataTable.Rows.Add(values);

            PaperListDGV.DataSource = paperListDataTable;
            PaperListDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            PaperListDGV.Columns[0].FillWeight = 5;
            PaperListDGV.Columns[1].FillWeight = 12;
            PaperListDGV.Columns[2].FillWeight = 55;
            PaperListDGV.Columns[3].FillWeight = 15;
            PaperListDGV.Columns[4].FillWeight = 13;
            //PaperListDGV.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            
        }
        override public void ReLoad()
        {
            this.Visible = true;
        }

        private void PaperListDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int RIndex = e.RowIndex;
            if(RIndex>-1)
            {
                paperListDataTable.Rows[RIndex][0] = !Convert.ToBoolean(paperListDataTable.Rows[RIndex][0]);
            }
            
        }
    }
}
