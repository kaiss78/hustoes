using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using OESXML;

namespace testExcel
{
    public partial class Form1 : Form
    {

        Excel.Application excel;
        Excel.Workbook xls;
        Excel.Worksheet ws;
        Excel.Chart ch;
        Excel.ChartObjects chobjs;
        Excel.ChartObject chobj;
        Excel.Range range;
        OfficeXML oxml; 
        object nullobj = System.Reflection.Missing.Value;
        int[] sheetCate;
        int[] worksheetIndex;           //工作表在整个工作簿的索引
        int[] chartIndex;               //图表在整个工作簿的索引
            

        public Form1()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
        }

        void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            { 
                //xls.Save();
                xls.Close(false, nullobj, nullobj);
                xls = null;

                excel.Quit();
                excel = null;
                GC.Collect();
            }
            catch
            { }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string file = @"D:\Test\Test.xls";
            excel = new Excel.Application();
            xls = excel.Workbooks.Open(file, nullobj, nullobj, 
                nullobj, nullobj, nullobj, nullobj, nullobj, 
                nullobj, nullobj, nullobj, nullobj, nullobj,
                nullobj,nullobj);
            excel.Visible = true;
            sheetCate = new int[xls.Sheets.Count + 1];
            worksheetIndex = new int[xls.Sheets.Count + 1];
            chartIndex = new int[xls.Sheets.Count + 1];
            sheetCate[0] = -1;
            for (int i = 1; i <= xls.Sheets.Count; i++)
            {
                string str = "";
                try
                { 
                    str = ((Excel.Worksheet)xls.Sheets[i]).Name; 
                    sheetCate[i] = 0;
                    worksheetIndex[comboWorksheet.Items.Count] = i;
                    comboWorksheet.Items.Add(str);
                    comboSheet.Items.Add(str);
                }   //工作簿
                catch 
                { 
                    str = ((Excel.Chart)xls.Sheets[i]).Name; 
                    sheetCate[i] = 1;
                    chartIndex[comboChart.Items.Count] = i;
                    comboChart.Items.Add(str);
                }   //图表
            }
            if (comboChart.Items.Count == 0)
                comboChart.Items.Add("(没有单独存在的图表！)");
            if (comboSheet.Items.Count == 0)
            {
                comboSheet.Items.Add("(没有工作表！)");
                comboWorksheet.Items.Add("(没有工作表！)");
            }
            comboWorksheet.SelectedIndex = comboWorksheet.Items.Count > 0 ? 0 : -1;
            comboSheet.SelectedIndex = comboSheet.Items.Count > 0 ? 0 : -1;
            comboChart.SelectedIndex = comboChart.Items.Count > 0 ? 0 : -1;

            radioCell.Checked = true;
            radioSingleChart.Checked = true;

            ws = (Excel.Worksheet)(xls.Worksheets[1]);
            
            //Console.WriteLine(ws.Name);

            #region Set Value
            /*
            range = ws.get_Range(ws.Cells[11, 6], ws.Cells[15, 10]);
             
            object[,] value = new object[5, 5];
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                    value[i, j] = 10;
            range.Value2 = value;
            ((Excel.Range)range.Cells[12, 8]).Value2 = 22;      //range左上角为原点，往下11行，往右5列，便是目的地
            
             * */
            #endregion
            #region 合并单元格
            //只有左上角的单元格有值，其他的为空
            /*
            range = getCell(22, 11);
            Console.WriteLine(range.Value2);
            range = getCell(22, 12);
            Console.WriteLine(range.Value2);
            range = getCell(22, 13);
            Console.WriteLine(range.Value2);                
            */
            #endregion
            #region chart
            /*
                    ch = (Excel.Chart)xls.Charts[1];


                    Excel.ChartObjects charts = (Excel.ChartObjects)ws.ChartObjects(nullobj);
                    Excel.ChartObject chartObj = charts.Add(0, 0, 400, 300);
                    ch = chartObj.Chart;
                    Excel.Range range = ws.get_Range("B5", "D15");
                    ch.ChartWizard(range, Excel.XlChartType.xlXYScatter, nullobj, Excel.XlRowCol.xlColumns, 1, 1, true, "标题", "X轴标题", "Y轴标题", nullobj);
                    //ch.ChartWizard(range, Excel.XlChartType.xlXYScatterSmooth, nullobj, Excel.XlRowCol.xlColumns, 1, 1, true, "Title", "Category", "Value", nullobj);
                    chartObj.Left = Convert.ToDouble(range.Left);
                    chartObj.Top = Convert.ToDouble(range.Top) + Convert.ToDouble(range.Height);

                    //ch.ChartArea.Fill.TwoColorGradient(Microsoft.Office.Core.MsoGradientStyle.msoGradientHorizontal,1); 

                     */
            //ch = (Excel.Chart)xls.Charts[1];
            //ch.Name = "fsffsfsfsfsfs";
            //ch.HasLegend = true;
            //ch.Legend.Position = Microsoft.Office.Interop.Excel.XlLegendPosition.xlLegendPositionBottom;
            
            #region 数据标志
            
            //Excel.SeriesCollection sc = (Excel.SeriesCollection)ch.SeriesCollection(nullobj);       //读图表中的数据！！！！！！！！！！！！！！！！！！！！！！
            //Test(sc);
            //Excel.Series ser = (Excel.SeriesCollection)ch.SeriesCollection(1);
            //ser.HasDataLabels = true;           //数据标志
            //ser.ApplyDataLabels(Microsoft.Office.Interop.Excel.XlDataLabelsType.xlDataLabelsShowPercent, false, true, false, true, true, true, nullobj, nullobj, "~");
            //ser.MarkerBackgroundColor = System.Drawing.ColorTranslator.ToOle(Color.Wheat);
            #endregion
            #endregion

            //range = getRegion(20, 10, 22, 12);
            //Excel.Range r1 = getCell(22, 11);
            //Excel.Range r2 = getCell(22, 11);
            //Console.WriteLine(r1.Top + " " + r1.Height + " " + r1.Left + " " + r1.Width + " " + r1.Value2);
            //Console.WriteLine(r2.Top + " " + r2.Height + " " + r2.Left + " " + r2.Width + " " + r2.Value2);
            //range = getRegion(11, 6, 15, 10);
            #region 边框设置
            /*
            range.Borders.Weight = 2;
            range.Borders.get_Item(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous;
            range.Borders.get_Item(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous;
            range.Borders.get_Item(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous;
            range.Borders.get_Item(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous;
            range.Borders.get_Item(Excel.XlBordersIndex.xlDiagonalDown).LineStyle = Excel.XlLineStyle.xlLineStyleNone;
            range.Borders.get_Item(Excel.XlBordersIndex.xlDiagonalUp).LineStyle = Excel.XlLineStyle.xlLineStyleNone;
            range.Borders.get_Item(Excel.XlBordersIndex.xlInsideHorizontal).LineStyle = Excel.XlLineStyle.xlLineStyleNone;
            range.Borders.get_Item(Excel.XlBordersIndex.xlInsideVertical).LineStyle = Excel.XlLineStyle.xlLineStyleNone;
            range.Borders.get_Item(Excel.XlBordersIndex.xlEdgeLeft).Color = System.Drawing.ColorTranslator.ToOle(Color.Blue);
            */
            #endregion
            #region 底纹设置
            //range.Interior.Pattern = Excel.XlPattern.xlPatternNone;                                     //底纹样式
            //range.Interior.PatternColor = System.Drawing.ColorTranslator.ToOle(Color.Transparent);    //底纹线条颜色
            //range.Interior.Color = System.Drawing.ColorTranslator.ToOle(Color.Transparent);           //背景颜色
            #endregion
            //range.Merge(false);               //合并单元格
            //range = getCell(16, 10);
            //range.Formula = "=SUM(J11:J15)";    //公式设置
            #region 字体设置
            /*
            range.Font.Strikethrough = true;    //删除线
            range.Font.Underline = true;        //下划线
            range.Font.Superscript = false;     //上标
            range.Font.Subscript = false;       //下标
            range.Font.Bold = true;             //粗体
            range.Font.Italic = true;           //斜体
            range.Font.Name = "华文琥珀";       //字体
            range.Font.Size = 20;               //字号
            range.Font.Color = System.Drawing.ColorTranslator.ToOle(Color.OrangeRed);   //颜色
             */
            #endregion
            #region 自动筛选
            //range = getRegion(5, 11, 31, 14);
            //range.AutoFilter(3, "=6", Microsoft.Office.Interop.Excel.XlAutoFilterOperator.xlOr, "<=3", true);
            //Console.WriteLine(ws.AutoFilter.Filters.Count);
            //Console.WriteLine(ws.AutoFilter.Filters[3].Criteria1.ToString());\
            //Console.WriteLine(ws.AutoFilter.Range.Rows.Count);
            #endregion
            #region 对齐方式
            //range.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
            //Console.WriteLine(range.HorizontalAlignment.ToString());
            #endregion
            #region 数字格式&行高列宽
            //range = getCell(27, 4);
            //MessageBox.Show(range.Formula.ToString() + "\r\n" +
            //                range.FormulaLocal.ToString() + "\r\n" +
            //                range.FormulaR1C1.ToString() + "\r\n" +
            //                range.FormulaR1C1Local.ToString());
            //range.Value2 = "4-Apr-1974";
            //range.NumberFormat = "m/d/yyyy";
            //range.RowHeight = 20;
            //range.ColumnWidth = 40;
            //MessageBox.Show(range.NumberFormat.ToString());
            #endregion
            #region 排序
            //range = getRegion(5, 11, 31, 13);
            //range.Activate();
            
            //range.Sort("URL", Microsoft.Office.Interop.Excel.XlSortOrder.xlAscending,
            //            nullobj, nullobj, Microsoft.Office.Interop.Excel.XlSortOrder.xlAscending,
            //            nullobj, Microsoft.Office.Interop.Excel.XlSortOrder.xlAscending, 
            //            Microsoft.Office.Interop.Excel.XlYesNoGuess.xlYes, nullobj, false, 
            //            Microsoft.Office.Interop.Excel.XlSortOrientation.xlSortColumns,
            //            Microsoft.Office.Interop.Excel.XlSortMethod.xlPinYin, 
            //            Microsoft.Office.Interop.Excel.XlSortDataOption.xlSortNormal, 
            //            Microsoft.Office.Interop.Excel.XlSortDataOption.xlSortNormal,
            //            Microsoft.Office.Interop.Excel.XlSortDataOption.xlSortNormal);
            //MessageBox.Show(((Excel.Range)range.Cells[2, 2]).Formula.ToString());
            #endregion
            #region 分类汇总
            //range = getRegion(1, 1, 12, 3);
            //int[] field = new int[]{3};
            //range.Subtotal(
            //    2,                                                                  //对第几列进行分类
            //    Microsoft.Office.Interop.Excel.XlConsolidationFunction.xlSum,       //汇总方式
            //    field,                                                              //对哪些列进行汇总
            //    true,                                                               //是否替换原来的分类汇总
            //    false,                                                              //是否分页显示
            //    Microsoft.Office.Interop.Excel.XlSummaryRow.xlSummaryBelow          //汇总信息显示在上面还是下面
            //    );
            //MessageBox.Show(range.OutlineLevel.ToString());

            //range = getRegion(1, 1, 12, 3);
            //range.Rows.OutlineLevel = 3;

            //range = getRegion(1, 1, 16, 3);
            //foreach (Excel.Range rg in range.Rows)
            //    MessageBox.Show(rg.ShowDetail.ToString());
            #endregion
            //range = getCell(3, 1);
            //range.Next.Interior.Color = System.Drawing.ColorTranslator.ToOle(Color.Bisque);
            //MessageBox.Show(range.Rows.Count.ToString() + " " + range.Columns.Count.ToString());
            //MessageBox.Show(range.MergeArea.Cells.Count);
            //MessageBox.Show(range.Row.ToString() + " " + range.Column.ToString() + " " + range.MergeArea.Cells.Count);
            //MessageBox.Show(range.MergeArea.Columns.Count.ToString());
            //MessageBox.Show(range.MergeArea.Cells.EntireColumn.Count.ToString());
            oxml = new OfficeXML("test.xml");
        }

        private List<string> Test(Excel.SeriesCollection sc)
        {
            List<string> res = new List<string>();
            for (int i = 1; i <= sc.Count; i++)
            {
                string seriesFormula = sc.Item(i).Formula;
                int firstComma = seriesFormula.IndexOf(',');
                int secondComma = seriesFormula.IndexOf(',', firstComma + 1);
                int thirdComma = seriesFormula.IndexOf(',', secondComma + 1);
                string yValues = seriesFormula.Substring(secondComma + 1, thirdComma - secondComma - 1);
                Excel.Range yRange = ws.get_Range(yValues, nullobj);
                for (int j = 1; j <= yRange.Cells.Count; j++)
                {
                    Excel.Range cell = (Excel.Range)yRange.Cells[j, nullobj];
                    res.Add(cell.Value2.ToString());
                }
            }
            return res;
       }


        #region Locate Methods

        private Excel.Range getCell(int row, int col)
        {
            return (Excel.Range)ws.get_Range(ws.Cells[row, col], ws.Cells[row, col]);
        }

        private Excel.Range getRegion(int row0, int col0, int row1, int col1)
        {
            return (Excel.Range)ws.get_Range(ws.Cells[row0, col0], ws.Cells[row1, col1]);
        }

        private void addWorksheet()
        {
            oxml.Path.Add(new OfficeElement("Workbooks", "0"));
            oxml.Path.Add(new OfficeElement("Sheets", (comboWorksheet.SelectedIndex + 1).ToString()));          //该工作表是所有工作表中的第几个
        }

        private void addWorksheetRange()
        {
            addWorksheet();
            if (radioRegion.Checked)
                oxml.Path.Add(new OfficeElement("Range", textLuPos.Text.ToUpper() + ":" + textRdPos.Text.ToUpper()));
            else
                oxml.Path.Add(new OfficeElement("Range", textPos.Text.ToUpper() + ":" + textPos.Text.ToUpper()));
        }

        private void addWorksheetRangeFont()
        {
            addWorksheetRange();
            oxml.Path.Add(new OfficeElement("Font", "0"));
        }

        private void addGraph()         //添加图表路径
        {
            oxml.Path.Add(new OfficeElement("Workbooks", "0"));
            if (radioSingleChart.Checked == true)
            {
                oxml.Path.Add(new OfficeElement("Charts",(comboChart.SelectedIndex + 1).ToString() + ":" + "0"));       //该图表是所有图表中的第几个
                ch = (Excel.Chart)xls.Sheets[chartIndex[comboChart.SelectedIndex]];                                     //获取图表
            }
            else
            {
                oxml.Path.Add(new OfficeElement("Charts", 
                    (comboSheet.SelectedIndex + 1).ToString()                                                   //该工作簿是所有工作簿的第几个
                    + ":" + (comboChartInSheet.SelectedIndex + 1).ToString()));                                 //该图表是工作簿里面的第几个图表
                ws = (Excel.Worksheet)xls.Sheets[worksheetIndex[comboSheet.SelectedIndex]];
                ch = ((Excel.ChartObject)ws.ChartObjects(comboChartInSheet.SelectedIndex + 1)).Chart;           //获取图表
            }
        }

        #endregion

        private bool checkCellFormat(string str)        //检查坐标的正确性
        {
            int i;
            string row = "", col = "";
            for (i = 0; i < str.Length; i++)
            {
                if ((str[i] >= 'a' && str[i] <= 'z') || (str[i] >= 'A' && str[i] <= 'Z'))
                    col += str[i].ToString().ToUpper();
                else
                    break;
            }
            if (col.Length == 0 || col.Length >= 3)
                return false;
            if (col.Length == 2 && col.CompareTo("IV") == 1)
                return false;
            for (; i < str.Length; i++)
            {
                if (str[i] >= '0' && str[i] <= '9')
                    row += str[i];
                else
                    return false;
            }
            if (Convert.ToInt64(row) > 65536)
                return false;
            return true;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (checkSheet.Checked)                     //选中工作表，而且必然没有选中其他东西
            {
                addWorksheet();
                oxml.Path.Add(new OfficeElement("Name", "1"));
                oxml.addPathtoXML();
                return;
            }
            #region Error Judge
            if (radioRegion.Checked)
            {
                if (!(checkCellFormat(textLuPos.Text) && checkCellFormat(textRdPos.Text)))
                {
                    MessageBox.Show("Error!");
                    return;
                }
            }
            else
            {
                if (!checkCellFormat(textPos.Text))
                {
                    MessageBox.Show("Error!");
                    return;
                }
            }
            #endregion
            #region Fonts
            if (checkName.Checked)
            {
                addWorksheetRangeFont();
                oxml.Path.Add(new OfficeElement("FontName", "1"));
                oxml.addPathtoXML();
            }
            if (checkSize.Checked)
            {
                addWorksheetRangeFont();
                oxml.Path.Add(new OfficeElement("Size", "1"));
                oxml.addPathtoXML();
            }
            if (checkForecolor.Checked)
            {
                addWorksheetRangeFont();
                oxml.Path.Add(new OfficeElement("Color", "1"));
                oxml.addPathtoXML();
            }
            if (checkBold.Checked)
            {
                addWorksheetRangeFont();
                oxml.Path.Add(new OfficeElement("Bold", "1"));
                oxml.addPathtoXML();
            }
            if (checkItalic.Checked)
            {
                addWorksheetRangeFont();
                oxml.Path.Add(new OfficeElement("Italic", "1"));
                oxml.addPathtoXML();
            }
            if (checkUnderline.Checked)
            {
                addWorksheetRangeFont();
                oxml.Path.Add(new OfficeElement("Underline", "1"));
                oxml.addPathtoXML();
            }
            #endregion
            #region Manipulation
            if (checkSubTotal.Checked)
            {
                addWorksheetRange();
                oxml.Path.Add(new OfficeElement("SubTotal", "1"));
                oxml.addPathtoXML();
            }
            if (checkSort.Checked)
            {
                addWorksheetRange();
                oxml.Path.Add(new OfficeElement("Sort", "1"));
                oxml.addPathtoXML();
            }
            #endregion
            #region Contents
            if (checkValue.Checked)
            {
                addWorksheetRange();
                oxml.Path.Add(new OfficeElement("Text", "1"));
                oxml.addPathtoXML();
            }
            if (checkFormula.Checked)
            {
                addWorksheetRange();
                oxml.Path.Add(new OfficeElement("Formula", "1"));
                oxml.addPathtoXML();
            }
            if (checkNumPattern.Checked)
            {
                addWorksheetRange();
                oxml.Path.Add(new OfficeElement("NumberFormat", "1"));
                oxml.addPathtoXML();
            }
            #endregion
            #region Styles
            if (checkRowHeight.Checked)
            {
                addWorksheetRange();
                oxml.Path.Add(new OfficeElement("RowHeight", "1"));
                oxml.addPathtoXML();
            }
            if (checkColWidth.Checked)
            {
                addWorksheetRange();
                oxml.Path.Add(new OfficeElement("ColWidth", "1"));
                oxml.addPathtoXML();
            }
            if (checkAlign.Checked)
            {
                addWorksheetRange();
                oxml.Path.Add(new OfficeElement("Align", "1"));
                oxml.addPathtoXML();
            }
            if (checkMerge.Checked)
            {
                addWorksheetRange();
                oxml.Path.Add(new OfficeElement("Merge", "1"));
                oxml.addPathtoXML();
            }
            if (checkBorder.Checked)
            {
                addWorksheetRange();
                oxml.Path.Add(new OfficeElement("Border", "1"));
                oxml.addPathtoXML();
            }
            if (checkInteriorPattern.Checked)
            {
                addWorksheetRange();
                oxml.Path.Add(new OfficeElement("InteriorPattern", "1"));
                oxml.addPathtoXML();
            }
            #endregion
        }

        private void getChartInSheet(int index)
        {
            comboChartInSheet.Items.Clear();
            if (index != 0)
            {
                ws = (Excel.Worksheet)xls.Sheets[index];
                chobjs = (Excel.ChartObjects)ws.ChartObjects(nullobj);
                //Console.WriteLine(chobjs.Count);
                for (int i = 1; i <= chobjs.Count; i++)
                {
                    chobj = (Excel.ChartObject)ws.ChartObjects(i);
                    ch = chobj.Chart;
                    string str = chobj.Name + ": ";
                    try
                    {
                        string title = ch.ChartTitle.Text;
                        str += title;
                    }
                    catch { str += "(未命名图表)"; }
                    comboChartInSheet.Items.Add(str);
                }
            }
            if (comboChartInSheet.Items.Count == 0)
            {
                comboChartInSheet.Items.Add("(该页无图表！)");
                buttonGraph.Enabled = false;
                groupGraphPoint.Enabled = false;
            }
            else
            {
                buttonGraph.Enabled = true;
                groupGraphPoint.Enabled = true;
            }
            comboChartInSheet.SelectedIndex = 0;
        }

        private void comboChart_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chartIndex[comboChart.SelectedIndex] == 0)
                buttonGraph.Enabled = groupGraphPoint.Enabled = false;
            else
                buttonGraph.Enabled = groupGraphPoint.Enabled = true;
        }

        private void comboSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            getChartInSheet(worksheetIndex[comboSheet.SelectedIndex]);
        }

        private void buttonGraph_Click(object sender, EventArgs e)
        {
            if (checkGraphValue.Checked)
            {
                addGraph();
                int cnt = GetGraphValueCount(ch, xls);                  //图表数据个数，一个数据一分
                oxml.Path.Add(new OfficeElement("Value", cnt.ToString()));
                oxml.addPathtoXML();
            }
            if (checkGraphPosition.Checked)
            {
                addGraph();
                oxml.Path.Add(new OfficeElement("Position", "1"));
                oxml.addPathtoXML();
            }
            if (checkGraphTitle.Checked)
            {
                addGraph();
                oxml.Path.Add(new OfficeElement("Title", "1"));
                oxml.addPathtoXML();
            }
            if (checkGraphType.Checked)
            {
                addGraph();
                oxml.Path.Add(new OfficeElement("Type", "1"));
                oxml.addPathtoXML();
            }
            if (checkGraphLabel.Checked)
            {
                addGraph();
                oxml.Path.Add(new OfficeElement("DataLabels", "1"));
                oxml.addPathtoXML();
            }
            if (checkGraphLegend.Checked)
            {
                addGraph();
                oxml.Path.Add(new OfficeElement("Legend", "1"));
                oxml.addPathtoXML();
            }
            if (checkGraphName.Checked)
            {
                addGraph();
                oxml.Path.Add(new OfficeElement("Name", "1"));
                oxml.addPathtoXML();
            }
        }

        private void radioSingleChart_CheckedChanged(object sender, EventArgs e)
        {
            comboChart.Enabled = true;
            comboSheet.Enabled = false;
            comboChartInSheet.Enabled = false;

            canChooseIt(checkGraphName);
            canNotChooseIt(checkGraphPosition);

            comboChart_SelectedIndexChanged(sender, e);
        }

        private void radioChartInSheet_CheckedChanged(object sender, EventArgs e)
        {
            comboChart.Enabled = false;
            comboSheet.Enabled = true;
            comboChartInSheet.Enabled = true;

            canNotChooseIt(checkGraphName);
            canChooseIt(checkGraphPosition);

            comboSheet_SelectedIndexChanged(sender, e);
        }

        private void radioCell_CheckedChanged(object sender, EventArgs e)
        {
            textPos.Enabled = true;
            textLuPos.Enabled = textRdPos.Enabled = false;
            foreach (object ob in groupPoint.Controls)
                if (ob is CheckBox)
                    canChooseIt((CheckBox)ob);
            canChooseIt(checkValue);
            canChooseIt(checkFormula);
            canChooseIt(checkMerge);
            canNotChooseIt(checkSheet);
        }

        private void radioRegion_CheckedChanged(object sender, EventArgs e)
        {
            textPos.Enabled = false;
            textLuPos.Enabled = textRdPos.Enabled = true;
            foreach (object ob in groupPoint.Controls)
                if (ob is CheckBox)
                    canChooseIt((CheckBox)ob);
            canNotChooseIt(checkValue);
            canNotChooseIt(checkFormula);
            canNotChooseIt(checkMerge);
            canNotChooseIt(checkSheet);
        }

        private void radioSheet_CheckedChanged(object sender, EventArgs e)
        {
            textPos.Enabled = textLuPos.Enabled = textRdPos.Enabled = false;
            canChooseIt(checkSheet);
            foreach (object ob in groupPoint.Controls)
                if (ob is CheckBox)
                    canNotChooseIt((CheckBox)ob);
            canChooseIt(checkSheet);
            checkSheet.Checked = true;
        }

        private void comboWorksheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (worksheetIndex[comboWorksheet.SelectedIndex] == 0)
                buttonOK.Enabled = groupPoint.Enabled = false;
            else
                buttonOK.Enabled = groupPoint.Enabled = true;
        }

        //禁止选某个考点
        private void canNotChooseIt(CheckBox ch)
        {
            ch.Enabled = ch.Checked = false;
        }

        //可选某个考点
        private void canChooseIt(CheckBox ch)
        {
            ch.Enabled = true;
            ch.Checked = false;
        }

        //获取图表中的数据个数
        private int GetGraphValueCount(Excel.Chart ch, Excel.Workbook xls)
        {
            int i, j, k, state, cnt = 0;
            Excel.SeriesCollection sc = (Excel.SeriesCollection)ch.SeriesCollection(nullobj);
            for (i = 1; i <= sc.Count; i++)
            {
                string seriesFormula = sc.Item(i).Formula;
                int firstComma = seriesFormula.IndexOf(',');
                int secondComma = seriesFormula.IndexOf(',', firstComma + 1);
                int thirdComma = seriesFormula.IndexOf(',', secondComma + 1);
                string yValues = seriesFormula.Substring(secondComma + 1, thirdComma - secondComma - 1);
                for (k = 1, state = 0; state == 0 && k <= xls.Worksheets.Count; k++)
                {
                    try
                    {
                        Excel.Worksheet ws = (Excel.Worksheet)xls.Worksheets[k];
                        Excel.Range yRange = ws.get_Range(yValues, nullobj);
                        cnt += yRange.Cells.Count;
                        state = 1;
                    }
                    catch { }
                }
            }
            return cnt;
        }

    }
}