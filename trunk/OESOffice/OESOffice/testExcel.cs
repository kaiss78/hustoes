using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using OESXML;

namespace OESOffice
{
    public partial class testExcel : UserControl
    {
        public testExcel()
        {
            InitializeComponent();
        }

        Excel.Application excel;
        Excel.Workbook xls;
        Excel.Worksheet ws;
        Excel.Chart ch;
        Excel.ChartObjects chobjs;
        Excel.ChartObject chobj;
        Excel.Range range;
        string xmlPath, filePath, fileName;
        OfficeXML oxml; 
        object nullobj = System.Reflection.Missing.Value;
        int[] sheetCate;
        int[] worksheetIndex;           //工作表在整个工作簿的索引
        int[] chartIndex;               //图表在整个工作簿的索引

        public void CloseExcel()
        {
            try
            { 
                xls.Close(false, nullobj, nullobj);
                xls = null;

                excel.Quit();
                excel = null;
                GC.Collect();
            }
            catch
            { }
        }

        public void LoadExcel(string excel_path, string xml_path)
        {
            filePath = excel_path;
            xmlPath = xml_path;
            openExcel(filePath, xmlPath);
        }

        private void openExcel(string excel_path, string xml_path)
        {
            MessageBox.Show("");
            string file = excel_path;
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

            oxml = new OfficeXML(xml_path);
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

        private void btnComplete_Click(object sender, EventArgs e)
        {
            CloseExcel();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CloseExcel();
        }
    }
}
