using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OES.Model;

namespace OES.UControl
{
    public partial class ProblemDGV : UserControl
    {
        private DataTable dt;

        public ProblemDGV()
        {
            InitializeComponent();
        }

        public void LoadPro<T>(List<T> proList) where T:Problem
        {
            dt=new DataTable();
            dt.Columns.Add("题号", typeof (int));
            dt.Columns.Add("题干", typeof (Button));
            object[] values = new object[2];
            for(int i=0;i<proList.Capacity;i++)
            {
                values[0] = i;
                Button tmp = new Button();
                tmp.Text = "-";
                //values[1] = "-";
                if(!proList[i].Equals(null))
                {
                    //values[1] = proList[i].problem;
                    tmp.Text = proList[i].problem;
                }
                values[1] = tmp;
                dt.Rows.Add(values);
            }

            proDGV.DataSource = dt;
            proDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            proListBox.DataSource = dt;
            proDGV.Columns[0].FillWeight = 10;
            proDGV.Columns[1].FillWeight = 90;

            proDGV.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            proDGV.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
        }
    }
}
