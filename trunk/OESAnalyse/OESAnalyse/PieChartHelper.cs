using System;
using System.Collections;
using System.Drawing;
using System.Text;

/// <summary>
/// 立体饼状图操作类
/// </summary>
public class PieChartHelper
{
    /// <summary>
    /// 饼状图初始化设置
    /// </summary>
    /// <param name="pieChart"></param>
    public static void Init_PieChart(System.Drawing.PieChart.PieChartControl pieChart)
    {
        pieChart.EdgeColorType = System.Drawing.PieChart.EdgeColorType.Contrast;
        pieChart.EdgeLineWidth = 1;//设置饼块的边框线的宽度
        //饼状图(上下左右)距离边框(PieChart控件的边框)都为5
        pieChart.LeftMargin = 5f;
        pieChart.RightMargin = 5f;
        pieChart.TopMargin = 5f;
        pieChart.BottomMargin = 5f;
        pieChart.FitChart = true;
        pieChart.SliceRelativeHeight = 0.15f;//设置饼块的厚(高)度
        pieChart.InitialAngle = 30;
        pieChart.ShadowStyle = System.Drawing.PieChart.ShadowStyle.GradualShadow;
        pieChart.BackColor = System.Drawing.Color.Transparent;
    }

    /// <summary>
    /// 设置饼状图各项对应的值
    /// </summary>
    /// <param name="pieChart"></param>
    /// <param name="valArray"></param>
    public static void SetPieChartControl_Values(System.Drawing.PieChart.PieChartControl pieChart, decimal[] valArray)
    {
        pieChart.Values = valArray;
    }

    /// <summary>
    /// 设置饼状图各项对应的颜色
    /// </summary>
    /// <param name="pieChart"></param>
    /// <param name="colArray"></param>
    public static void SetPieChartControl_Colors(System.Drawing.PieChart.PieChartControl pieChart, Color[] colArray)
    {
        ArrayList colors = new ArrayList();
        foreach (Color col in colArray)
        {
            colors.Add(Color.FromArgb(125, col));
        }
        pieChart.Colors = (Color[])colors.ToArray(typeof(Color)); ;
    }

    /// <summary>
    /// 设置饼状图各项对应的文本
    /// </summary>
    /// <param name="pieChart"></param>
    /// <param name="textArray"></param>
    public static void SetPieChartControl_Texts(System.Drawing.PieChart.PieChartControl pieChart, string[] textArray)
    {
        pieChart.Texts = textArray;
    }

    /// <summary>
    /// 设置饼状图各项对应的文本提示
    /// </summary>
    /// <param name="pieChart"></param>
    /// <param name="tipArray"></param>
    public static void SetPieChartControl_ToolTips(System.Drawing.PieChart.PieChartControl pieChart, string[] tipArray)
    {
        pieChart.ToolTips = tipArray;
    }
}
