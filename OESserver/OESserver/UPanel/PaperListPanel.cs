using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OES.Model;

namespace OES.UPanel
{
    public partial class PaperListPanel : UserPanel
    {
        private DataTable paperListDataTable;
        public Paper paper=new Paper();
        public List<Paper> paperList;    
        public void InitList()
        {
            paperListDataTable=new DataTable("PaperList");
            paperListDataTable.Columns.Add("选中", typeof(bool));
            paperListDataTable.Columns.Add("试卷ID");
            paperListDataTable.Columns.Add("试卷名称");
            paperListDataTable.Columns.Add("组卷时间");
            paperListDataTable.Columns.Add("作者");
            object[] values = new object[5];

            paperList = InfoControl.OesData.FindPaper();
            
            for (int i = 0; i < paperList.Count; i++)
            {
                values[0] = false;
                values[1] = paperList[i].paperID;
                values[2] = paperList[i].paperName;
                values[3] = paperList[i].createTime;
                values[4] = paperList[i].author;
                paperListDataTable.Rows.Add(values);
            }
                                    
            PaperListDGV.DataSource = paperListDataTable;
            PaperListDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            
            PaperListDGV.Columns[0].FillWeight = 5;
            PaperListDGV.Columns[1].FillWeight = 12;
            PaperListDGV.Columns[2].FillWeight = 45;
            PaperListDGV.Columns[3].FillWeight = 20;
            PaperListDGV.Columns[4].FillWeight = 18;       
            
        }

        public PaperListPanel()
        {
            InitializeComponent();            
        }

        override public void ReLoad()
        {
            this.Visible = true;
            InitList();
        }

        private void PaperListDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int RIndex = e.RowIndex;
            if(RIndex>-1)
            {
                paperListDataTable.Rows[RIndex][0] = !Convert.ToBoolean(paperListDataTable.Rows[RIndex][0]);
            }
            
        }

        private void PaperListDGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int RIndex = e.RowIndex;
            if (RIndex > -1)
            {
                MessageBox.Show(RIndex.ToString());
            }
        }

    }
}
