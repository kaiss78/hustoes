using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace OESAnalyse
{
    public partial class PieChart : Form
    {
        public PieChart()
        {
            InitializeComponent();

            //初始化饼状图
            ScoreAnalyse s1 = new ScoreAnalyse();
            String path = "F:\\Student";
            s1.getDisNum(path);
            s1.getStuNum(path);
            float a = s1.ScoreDistribution[0] / s1.StuNum * 100, b = s1.ScoreDistribution[1] / s1.StuNum * 100, c = s1.ScoreDistribution[2] / s1.StuNum * 100, d = (s1.ScoreDistribution[3] / s1.StuNum) * 100, e = s1.ScoreDistribution[4] / s1.StuNum * 100;
            PieChartHelper.Init_PieChart(_pieChartShowObj);
            _pieChartShowObj.SliceRelativeDisplacements = new float[] { 0.01f, 0.01f, 0.10f };
            PieChartHelper.SetPieChartControl_Colors(_pieChartShowObj, new Color[] { Color.Yellow, Color.Red, Color.Green });
            PieChartHelper.SetPieChartControl_Texts(_pieChartShowObj, new string[] { Convert.ToInt32(a).ToString(), Convert.ToInt32(b).ToString(), Convert.ToInt32(c).ToString(), Convert.ToInt32(d).ToString(), Convert.ToInt32(e).ToString() });
            PieChartHelper.SetPieChartControl_Values(_pieChartShowObj, new decimal[] { Convert.ToInt32(a), Convert.ToInt32(b), Convert.ToInt32(c), Convert.ToInt32(d), Convert.ToInt32(e) });
            PieChartHelper.SetPieChartControl_ToolTips(_pieChartShowObj, new string[] { "90-100分", "80-90分", "70-80分", "60-70分", "不及格" });
        }
    }
}
