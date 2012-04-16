using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OES.Model;

namespace OESAnalyse
{
    public partial class PieChart : Form
    {
        private float[] scoDistri = new float[5];
        private float[] distribution = new float[5];
        private List<Student> students = new List<Student>();
        public PieChart(List<Student> stu)
        {
            InitializeComponent();
            Pie pie = new Pie();
            this.Controls.Add(pie);
            pie.Visible = true;
            //students = stu;
            ////初始化饼状图
            //getDistri();
            //PieChartHelper.Init_PieChart(_pieChartShowObj);
            //_pieChartShowObj.SliceRelativeDisplacements = new float[] { 0.01f, 0.01f, 0.10f };
            //PieChartHelper.SetPieChartControl_Colors(_pieChartShowObj, new Color[] { Color.Yellow, Color.Red, Color.Green });
            //PieChartHelper.SetPieChartControl_Texts(_pieChartShowObj, new string[] { Convert.ToInt32(distribution[0]).ToString(), Convert.ToInt32(distribution[1]).ToString(), Convert.ToInt32(distribution[2]).ToString(), Convert.ToInt32(distribution[3]).ToString(), Convert.ToInt32(distribution[4]).ToString() });
            //PieChartHelper.SetPieChartControl_Values(_pieChartShowObj, new decimal[] { Convert.ToInt32(distribution[0]), Convert.ToInt32(distribution[1]), Convert.ToInt32(distribution[2]), Convert.ToInt32(distribution[3]), Convert.ToInt32(distribution[4]) });
            //PieChartHelper.SetPieChartControl_ToolTips(_pieChartShowObj, new string[] { "90-100分", "80-90分", "70-80分", "60-70分", "不及格" });
        }

        public void getDistri()
        {
            for (int i = 0; i < students.Count; i++)
            {
                //scoDistri[0]是90分以上，接着是80至90,70至80,60至70和不及格
                if (Convert.ToInt32(students[i].password) >= 90)
                    scoDistri[0]++;
                else if (Convert.ToInt32(students[i].password) >= 80)
                    scoDistri[1]++;
                else if (Convert.ToInt32(students[i].password) >= 70)
                    scoDistri[2]++;
                else if (Convert.ToInt32(students[i].password) >= 60)
                    scoDistri[3]++;
                else
                    scoDistri[4]++;
            }
            for (int i = 0; i < 5; i++)
            {
                distribution[i] = scoDistri[i] / students.Count*100;
            }
        }
    }
}
