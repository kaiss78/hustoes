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
            PaperListDGV.DataSource = paperListDataTable;
        }
        override public void ReLoad()
        {
            this.Visible = true;
        }
    }
}
