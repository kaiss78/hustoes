using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OES.Model;
using OES.XMLFile;

namespace OES.UPanel
{
    public partial class PaperListPanel : UserPanel
    {
        private DataTable paperListDataTable;
        public Paper paper = new Paper();
        public List<Paper> paperList;
        private int findtype = 1;
        private List<IdScoreType> ISTList;
        private frmPaperPreview paperPreview;

        public void InitDT()
        {
            paperListDataTable = new DataTable("PaperList");
            paperListDataTable.Columns.Add("选中", typeof(bool));
            paperListDataTable.Columns.Add("试卷ID");
            paperListDataTable.Columns.Add("试卷名称");
            paperListDataTable.Columns.Add("组卷时间");
            paperListDataTable.Columns.Add("作者");
        }

        public void InitList()
        {
            InitDT();
            object[] values = new object[5];

            paperList = InfoControl.OesData.FindAllPaper();

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

            PaperListDGV.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            PaperListDGV.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            PaperListDGV.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            PaperListDGV.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            PaperListDGV.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        public PaperListPanel()
        {
            InitializeComponent();
            changeFindType(findtype);               //一开始是按年份查询
        }

        override public void ReLoad()
        {
            this.Visible = true;
            InitList();
        }

        private void PaperListDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int RIndex = e.RowIndex;
            if (RIndex > -1)
            {
                paperListDataTable.Rows[RIndex][0] = !Convert.ToBoolean(paperListDataTable.Rows[RIndex][0]);
            }
        }

        //跳转到试卷编辑
        private void PaperListDGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {            
            int RIndex = e.RowIndex;
            if (RIndex > -1)
            {
                InfoControl.getPaper(paperList[RIndex].paperID);                
                PanelControl.EditPaper();
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("确定删除记录", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                for (int i = 0; i < paperListDataTable.Rows.Count; i++)
                {
                    if ((bool)paperListDataTable.Rows[i][0])
                    {
                        InfoControl.OesData.DeletePaper(Convert.ToInt32(paperListDataTable.Rows[i]["试卷ID"]));
                        InfoControl.ClientObj.DelPaper(Convert.ToInt32(paperListDataTable.Rows[i]["试卷ID"]),InfoControl.User.Id);
                    }
                }
                InitList();
            }
        }

        private void changeFindType(int findtype)
        {
            this.year.Visible = false;
            this.paperName.Visible = false;
            this.startTime.Visible = false;
            this.endTime.Visible = false;
            switch (findtype)
            {
                case 1:
                    this.year.Visible = true;
                    break;
                case 2:
                    this.paperName.Visible = true;
                    break;
                case 3:
                    this.startTime.Visible = true;
                    this.endTime.Visible = true;
                    break;
            }
        }

        private void cbtnFindByYear_Click(object sender, EventArgs e)
        {

            findtype = 1;
            changeFindType(findtype);
        }

        private void cbtnFindByTime_Click(object sender, EventArgs e)
        {
            findtype = 3;
            changeFindType(findtype);
        }

        private void cbtnFindByName_Click(object sender, EventArgs e)
        {
            findtype = 2;
            changeFindType(findtype);
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            InitDT();
            object[] values = new object[5];
            switch (findtype)
            {
                case 1:
                    paperList = InfoControl.OesData.FindPaperByYear(Convert.ToString(year.Value));
                    break;
                case 2:
                    paperList = InfoControl.OesData.FindPaperByTitle(paperName.Text);
                    break;
                case 3:
                    paperList = InfoControl.OesData.FindPaperByTwoDates(startTime.Value, endTime.Value);
                    break;
            }
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

            PaperListDGV.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            PaperListDGV.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            PaperListDGV.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            PaperListDGV.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            PaperListDGV.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            InfoControl.getPaper(Convert.ToInt32(PaperListDGV.SelectedRows[0].Cells[1].Value));
            paperPreview = new frmPaperPreview();
            paperPreview.Show();
            //PanelControl.EditPaper();
        }
    }
}
