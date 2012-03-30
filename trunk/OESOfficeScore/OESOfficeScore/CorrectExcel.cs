using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using OESXML;


namespace OESOfficeScore
{
    public class CorrectExcel
    {
        Excel.Application stuExcel, ansExcel;           //学生和标答（下同）使用的Excel应用程序
        Excel.Workbook stuXls, ansXls;                  //Excel工作表
        Excel.Worksheet stuWs, ansWs;                   //Excel工作簿
        Excel.Chart stuCh, ansCh;                       //Excel图表
        Excel.Range stuRange, ansRange;                 //Excel选择区域
        Excel.ChartObject stuObj, ansObj;               //Excel图表对象
        object nullobj = System.Reflection.Missing.Value;
        OfficeXML oxml;                                 //考点文件
        int[] stuCate;                                  //学生工作表中每张工作簿的类型
        int[] ansCate;                                  //标答工作表中每张工作簿的类型

        //外部调用函数 返回该题得分
        public int checkPoints(string stu, string ans, string xml)
        {
            int totalPoints = 0;
            init(stu, ans, xml);
            foreach (List<OfficeElement> oel in oxml.AnsPaths)
            {
                totalPoints += check_Kernel(oel);
            }
            dispose();
            return totalPoints;
        }

        //评分初始化
        private void init(string stu, string ans, string xml)
        {
            try
            {
                stuExcel = new Excel.Application();
                stuXls = stuExcel.Workbooks.Open(stu, nullobj, nullobj,
                    nullobj, nullobj, nullobj, nullobj, nullobj, nullobj,
                    nullobj, nullobj, nullobj, nullobj, nullobj, nullobj);  //载入学生xls
                ansExcel = new Excel.Application();
                ansXls = ansExcel.Workbooks.Open(ans, nullobj, nullobj,
                    nullobj, nullobj, nullobj, nullobj, nullobj, nullobj,
                    nullobj, nullobj, nullobj, nullobj, nullobj, nullobj);  //载入标答xls
                oxml = new OfficeXML(xml);                                  //读入考点文件
                getPoint(oxml);                                             //获取考点信息                 
                stuCate = getSheetCate(stuXls);              //检查学生工作表的类型
                ansCate = getSheetCate(ansXls);              //检查标答工作表的类型
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Load file error!");
                throw Ex;
            }
        }

        //评分结束
        private void dispose()
        {
            try
            {
                stuXls.Close(false, nullobj, nullobj);
                stuXls = null;
                ansXls.Close(false, nullobj, nullobj);
                ansXls = null;
                stuExcel.Quit();
                stuExcel = null;
                ansExcel.Quit();
                ansExcel = null;
                GC.Collect();
            }
            catch { }
        }

        //检查Excel工作表中工作簿的类型 0为普通工作簿， 1为单独图表
        private int[] getSheetCate(Excel.Workbook xls)
        {
            Excel.Worksheet tmpSheet;
            int[] arr = new int[xls.Sheets.Count + 1];
            for (int i = 1; i <= xls.Sheets.Count; i++)
            {
                try
                {
                    tmpSheet = (Excel.Worksheet)xls.Sheets[i];
                    arr[i] = 0;
                }
                catch { arr[i] = 1; }
            }
            return arr; 
        }

        //从xml文件中读出考点
        private void getPoint(OfficeXML ox)
        {
            try { ox.getAllAnsPath(); }
            catch(Exception Ex) 
            {
                MessageBox.Show("Get exam point error!");
                throw Ex;
            }
        }

        //评分核心函数
        private int check_Kernel(List<OfficeElement> ls)
        {
            int stuPage = 0, ansPage = 0;                       //学生和标答使用的工作表页码
            int points = 0;                                     //考生考点得分
            int i;                         
            for (i = 0; i < ls.Count; i++)
            {
                OfficeElement oe = ls[i];
                if (oe.AttribName == "Root")
                    continue;
                if (oe.AttribName == "Workbooks")
                    continue;
                if (oe.AttribName == "Sheets")          //文字考点
                {
                    #region 获取学生和标答工作表位置
                    stuPage = ansPage = int.Parse(oe.AttribValue);
                    ansWs = (Excel.Worksheet)ansXls.Worksheets[ansPage];
                    if (stuXls.Worksheets.Count >= int.Parse(oe.AttribValue))   //学生的xls能找到第AttribValue张工作表
                        stuWs = (Excel.Worksheet)stuXls.Worksheets[stuPage];
                    else                                                        //学生的xls不能找到第AttribValue张工作表
                    {
                        try
                        {
                            stuWs = (Excel.Worksheet)stuXls.Worksheets[1];  //取这个学生的第一个工作表代替
                        }
                        catch                                               //天哪，居然一个工作表都没有
                        {
                            stuWs = null;
                        }
                    }
                    #endregion
                    points = check_Words(ls, i + 1, stuWs, ansWs);
                    break;
                }
                if (oe.AttribName == "Charts")          //图表考点
                {
                    ansCh = getAnsChartPosition(oe.AttribValue);
                    stuCh = getStudentChartPosition();
                    points = check_Chart(ls, i + 1, stuCh, ansCh, stuObj, ansObj);
                    break;
                }
            }
            return points;
        }

        //通过AttribValue获取标答图表位置
        private Excel.Chart getAnsChartPosition(string str)
        {
            Excel.Chart res = null;
            string[] tstr;
            int sheet = 0, chart = 0;
            tstr = str.Split(':');
            sheet = int.Parse(tstr[0]);
            chart = int.Parse(tstr[1]);
            if (chart == 0)     //独立图表
            {
                res = (Excel.Chart)ansXls.Charts[sheet];
                ansObj = null;
            }
            else            //嵌入图表
            {
                res = ((Excel.ChartObject)((Excel.Worksheet)ansXls.Worksheets[sheet]).ChartObjects(chart)).Chart;
                ansObj = (Excel.ChartObject)((Excel.Worksheet)ansXls.Worksheets[sheet]).ChartObjects(chart);
            }
            return res;
        }

        //获取学生文件的第一幅图表
        private Excel.Chart getStudentChartPosition()
        {
            Excel.Chart res = null;
            int tot = stuXls.Sheets.Count;
            int ch_in_work_tot = 0;                             //工作簿中的图表数
            for (int i = 1; i <= tot; i++)
            {
                if (stuCate[i] == 0)                            //工作簿
                {
                    ch_in_work_tot = ((Excel.ChartObjects)((Excel.Worksheet)stuXls.Sheets[i]).ChartObjects(nullobj)).Count;
                    if (ch_in_work_tot > 0)
                    {
                        res = ((Excel.ChartObject)((Excel.Worksheet)stuXls.Sheets[i]).ChartObjects(1)).Chart;
                        stuObj = (Excel.ChartObject)((Excel.Worksheet)stuXls.Sheets[i]).ChartObjects(1);
                        break;
                    }
                }
                else                                            //单独图表
                {
                    res = (Excel.Chart)stuXls.Sheets[i];
                    stuObj = null;
                    break;
                }
            }
            return res;
        }

        //检查文字考点，参数为考点列表、继续检索的位置、学生工作表、标答工作表
        private int check_Words(List<OfficeElement> ls, int startPosition, Excel.Worksheet stuWs, Excel.Worksheet ansWs)
        {
            int thisPoint = 0;
            int i;
            if (stuWs == null)
                return 0;
            for (i = startPosition; i < ls.Count; i++)
            {
                OfficeElement oe = ls[i];
                if (oe.AttribName == "Name")
                {
                    if (stuWs.Name == ansWs.Name)
                        thisPoint += int.Parse(oe.AttribValue);
                    continue;
                }
                if (oe.AttribName == "Range")
                {
                    stuRange = stuWs.get_Range(oe.AttribValue, nullobj);
                    ansRange = ansWs.get_Range(oe.AttribValue, nullobj);
                    continue;
                }
                if (oe.AttribName == "Font")
                {
                    continue;
                }
                #region Fonts
                if (oe.AttribName == "FontName")
                {
                    if (stuRange.Font.Name.ToString() == ansRange.Font.Name.ToString())
                        thisPoint += int.Parse(oe.AttribValue);
                    continue;
                }
                if (oe.AttribName == "Size")
                {
                    if (stuRange.Font.Size.ToString() == ansRange.Font.Size.ToString())
                        thisPoint += int.Parse(oe.AttribValue);
                    continue;
                }
                if (oe.AttribName == "Bold")
                {
                    if (stuRange.Font.Bold.ToString() == ansRange.Font.Bold.ToString())
                        thisPoint += int.Parse(oe.AttribValue);
                    continue;
                }
                if (oe.AttribName == "Italic")
                {
                    if (stuRange.Font.Italic.ToString() == ansRange.Font.Italic.ToString())
                        thisPoint += int.Parse(oe.AttribValue);
                    continue;
                }
                if (oe.AttribName == "Underline")
                {
                    if (stuRange.Font.Underline.ToString() == ansRange.Font.Underline.ToString())
                        thisPoint += int.Parse(oe.AttribValue);
                    continue;
                }
                if (oe.AttribName == "Color")
                {
                    if (stuRange.Font.Color.ToString() == ansRange.Font.Color.ToString())
                        thisPoint += int.Parse(oe.AttribValue);
                    continue;
                }
                #endregion
                #region Manipulation
                if (oe.AttribName == "SubTotal" || oe.AttribName == "Sort")
                {
                    int row = ansRange.Rows.Count, col = ansRange.Columns.Count;
                    int check = 1;
                    Excel.Range stuCmp, ansCmp;
                    int p, q;
                    
                    if (check == 0) { continue; }

                    for (p = 1; p <= row; p++)
                    {
                        for (q = 1; q <= col; q++)
                        {
                            stuCmp = (Excel.Range)stuRange.Cells[p, q];
                            ansCmp = (Excel.Range)ansRange.Cells[p, q];
                            if (stuCmp.Text.ToString() != ansCmp.Text.ToString())
                            {
                                check = 0;
                                break;
                            }
                        }
                        if (check == 0)
                            break;
                    }
                    if (check == 0)
                        continue;
                    if (oe.AttribName == "SubTotal")                                                //分类汇总还需要判断大纲层次是否一致
                    {
                        for (p = 1; p <= ansRange.Rows.Count; p++)
                        {
                            if (((Excel.Range)ansRange.Rows[p, nullobj]).ShowDetail.ToString() !=
                                ((Excel.Range)stuRange.Rows[p, nullobj]).ShowDetail.ToString())                     //判断大纲层次是否一致
                            {
                                check = 0;
                                break;
                            }
                        }
                    }
                    if (check == 1)
                        thisPoint += int.Parse(oe.AttribValue);
                    continue;
                }
                #endregion
                #region Contents
                if (oe.AttribName == "NumberFormat")
                {
                    try
                    {
                        if (stuRange.NumberFormat.ToString() == ansRange.NumberFormat.ToString())
                            thisPoint += int.Parse(oe.AttribValue);
                    }
                    catch { }
                    continue;
                }
                if (oe.AttribName == "Text")
                {
                    try
                    {
                        if (stuRange.Text.ToString() == ansRange.Text.ToString())
                            thisPoint += int.Parse(oe.AttribValue);
                    }
                    catch { }
                    continue;
                }
                if (oe.AttribName == "Formula")
                {
                    string stuFormula = stuRange.Formula.ToString(), ansFormula = ansRange.Formula.ToString();
                    if (stuFormula == ansFormula)
                        thisPoint += int.Parse(oe.AttribValue);
                    else
                    { 
                        stuFormula = stuFormula.Replace("$", "");
                        stuFormula = stuFormula.Replace(" ", "");
                        ansFormula = ansFormula.Replace("$", "");
                        ansFormula = ansFormula.Replace(" ", "");
                        if (stuFormula == ansFormula)
                            thisPoint += int.Parse(oe.AttribValue);
                    }
                    continue;
                }
                #endregion
                #region Styles
                if (oe.AttribName == "Border")
                {
                    #region 边框线型
                    if (((Excel.XlLineStyle)stuRange.Borders.get_Item(Excel.XlBordersIndex.xlEdgeLeft).LineStyle).ToString() !=
                        ((Excel.XlLineStyle)ansRange.Borders.get_Item(Excel.XlBordersIndex.xlEdgeLeft).LineStyle).ToString())
                        continue;
                    if (((Excel.XlLineStyle)stuRange.Borders.get_Item(Excel.XlBordersIndex.xlEdgeRight).LineStyle).ToString() !=
                        ((Excel.XlLineStyle)ansRange.Borders.get_Item(Excel.XlBordersIndex.xlEdgeRight).LineStyle).ToString())
                        continue;
                    if (((Excel.XlLineStyle)stuRange.Borders.get_Item(Excel.XlBordersIndex.xlEdgeTop).LineStyle).ToString() !=
                        ((Excel.XlLineStyle)ansRange.Borders.get_Item(Excel.XlBordersIndex.xlEdgeTop).LineStyle).ToString())
                        continue;
                    if (((Excel.XlLineStyle)stuRange.Borders.get_Item(Excel.XlBordersIndex.xlEdgeBottom).LineStyle).ToString() !=
                        ((Excel.XlLineStyle)ansRange.Borders.get_Item(Excel.XlBordersIndex.xlEdgeBottom).LineStyle).ToString())
                        continue;
                    if (((Excel.XlLineStyle)stuRange.Borders.get_Item(Excel.XlBordersIndex.xlInsideHorizontal).LineStyle).ToString() !=
                        ((Excel.XlLineStyle)ansRange.Borders.get_Item(Excel.XlBordersIndex.xlInsideHorizontal).LineStyle).ToString())
                        continue;
                    if (((Excel.XlLineStyle)stuRange.Borders.get_Item(Excel.XlBordersIndex.xlInsideVertical).LineStyle).ToString() !=
                        ((Excel.XlLineStyle)ansRange.Borders.get_Item(Excel.XlBordersIndex.xlInsideVertical).LineStyle).ToString())
                        continue;
                    #endregion
                    #region 边框粗细
                    if (((Excel.XlBorderWeight)stuRange.Borders.get_Item(Excel.XlBordersIndex.xlEdgeLeft).Weight).ToString() !=
                        ((Excel.XlBorderWeight)ansRange.Borders.get_Item(Excel.XlBordersIndex.xlEdgeLeft).Weight).ToString())
                        continue;
                    if (((Excel.XlBorderWeight)stuRange.Borders.get_Item(Excel.XlBordersIndex.xlEdgeRight).Weight).ToString() !=
                        ((Excel.XlBorderWeight)ansRange.Borders.get_Item(Excel.XlBordersIndex.xlEdgeRight).Weight).ToString())
                        continue;
                    if (((Excel.XlBorderWeight)stuRange.Borders.get_Item(Excel.XlBordersIndex.xlEdgeTop).Weight).ToString() !=
                        ((Excel.XlBorderWeight)ansRange.Borders.get_Item(Excel.XlBordersIndex.xlEdgeTop).Weight).ToString())
                        continue;
                    if (((Excel.XlBorderWeight)stuRange.Borders.get_Item(Excel.XlBordersIndex.xlEdgeBottom).Weight).ToString() !=
                        ((Excel.XlBorderWeight)ansRange.Borders.get_Item(Excel.XlBordersIndex.xlEdgeBottom).Weight).ToString())
                        continue;
                    if (((Excel.XlBorderWeight)stuRange.Borders.get_Item(Excel.XlBordersIndex.xlInsideHorizontal).Weight).ToString() !=
                        ((Excel.XlBorderWeight)ansRange.Borders.get_Item(Excel.XlBordersIndex.xlInsideHorizontal).Weight).ToString())
                        continue;
                    if (((Excel.XlBorderWeight)stuRange.Borders.get_Item(Excel.XlBordersIndex.xlInsideVertical).Weight).ToString() !=
                        ((Excel.XlBorderWeight)ansRange.Borders.get_Item(Excel.XlBordersIndex.xlInsideVertical).Weight).ToString())
                        continue;
                    #endregion
                    thisPoint += int.Parse(oe.AttribValue);
                    continue;
                }
                if (oe.AttribName == "InteriorPattern")
                {
                    if (((Excel.XlPattern)stuRange.Interior.Pattern).ToString() ==
                        ((Excel.XlPattern)ansRange.Interior.Pattern).ToString())
                        thisPoint += int.Parse(oe.AttribValue);
                    continue;
                }
                if (oe.AttribName == "RowHeight")
                {
                    if (stuRange.RowHeight.ToString() == ansRange.RowHeight.ToString())
                        thisPoint += int.Parse(oe.AttribValue);
                    continue;
                }
                if (oe.AttribName == "ColWidth")
                {
                    if (stuRange.ColumnWidth.ToString() == ansRange.ColumnWidth.ToString())
                        thisPoint += int.Parse(oe.AttribValue);
                    continue;
                }
                if (oe.AttribName == "Align")
                {
                    if (((Excel.XlHAlign)stuRange.HorizontalAlignment).ToString() == 
                        ((Excel.XlHAlign)ansRange.HorizontalAlignment).ToString())
                        thisPoint += int.Parse(oe.AttribValue);
                    continue;
                }
                if (oe.AttribName == "Merge")
                {
                    if (ansRange.MergeArea.Count != stuRange.MergeArea.Count)               //先判断包含的单元格数量是否一致
                        continue;
                    Excel.Range stuFirstRange, ansFirstRange;
                    ansFirstRange = ansRange.MergeArea;
                    stuFirstRange = stuRange.MergeArea;
                    if (checkRangeSame(stuFirstRange, ansFirstRange) == false)              //判断左上角单元格是否一致
                        continue;
                    #region unused
                    //for (p = 1; ; p++)
                    //{
                    //    tmpRange = (Excel.Range)ansFirstRange.Cells[p, 1];
                    //    if (checkRangeSame(tmpRange.MergeArea, ansRange.MergeArea) == false)
                    //    { ansRow = p - 1; break; }
                    //}
                    //for (p = 1; ; p++)
                    //{
                    //    tmpRange = (Excel.Range)ansFirstRange.Cells[1, p];
                    //    if (checkRangeSame(tmpRange.MergeArea, ansRange.MergeArea) == false)
                    //    { ansCol = p - 1; break; }
                    //}
                    //for (p = 1; ; p++)
                    //{
                    //    tmpRange = (Excel.Range)stuFirstRange.Cells[p, 1];
                    //    if (checkRangeSame(tmpRange.MergeArea, stuRange.MergeArea) == false)
                    //    { stuRow = p - 1; break; }
                    //}
                    //for (p = 1; ; p++)
                    //{
                    //    tmpRange = (Excel.Range)stuFirstRange.Cells[1, p];
                    //    if (checkRangeSame(tmpRange.MergeArea, stuRange.MergeArea) == false)
                    //    { stuCol = p - 1; break; }
                    //}                                                                           //计算合并单元格的行数和列数
                    #endregion
                    if (ansRange.MergeArea.Rows.Count == stuRange.MergeArea.Rows.Count
                        && ansRange.MergeArea.Columns.Count == stuRange.MergeArea.Columns.Count)
                        thisPoint += int.Parse(oe.AttribValue);
                    continue;
                }
                #endregion
            }
            return thisPoint;
        }

        //检查图表考点，参数分别为考点列表、继续检索的位置、学生图表、答案图表、学生图表对象、答案图表对象
        private int check_Chart(List<OfficeElement> ls, int startPosition, 
            Excel.Chart stuCh, Excel.Chart ansCh, Excel.ChartObject stuObj, Excel.ChartObject ansObj) 
        {
            int thisPoint = 0;
            int i, j;
            if (stuCh == null)
                return 0;
            for (i = startPosition; i < ls.Count; i++)
            {
                OfficeElement oe = ls[i];
                if (oe.AttribName == "Value")          //图表数值
                {
                    List<List<string>> stuList, ansList;
                    stuList = GetValue(stuCh, stuXls);
                    ansList = GetValue(ansCh, ansXls);
                    for (i = 0; i < stuList.Count && i < ansList.Count; i++)
                    {
                        for (j = 0; j < stuList[i].Count && j < ansList[i].Count; j++ )
                            if (stuList[i][j] == ansList[i][j])
                                thisPoint++;
                    }
                    continue;
                }
                if (oe.AttribName == "Title")          //图表标题
                {
                    if (ansCh.ChartTitle.Text == stuCh.ChartTitle.Text)
                        thisPoint += int.Parse(oe.AttribValue);
                    continue;
                }
                if (oe.AttribName == "Type")            //图表类型
                {
                    if (ansCh.ChartType == stuCh.ChartType)
                        thisPoint += int.Parse(oe.AttribValue);
                    continue;
                }
                if (oe.AttribName == "Name")            //图表的工作表名称(只对独立图表有效)
                {
                    if (stuObj == null && stuCh.Name == ansCh.Name)
                            thisPoint += int.Parse(oe.AttribValue);
                    continue;
                }
                if (oe.AttribName == "Legend")          //图例
                {
                    if (stuCh.HasLegend == true && stuCh.Legend.Position == ansCh.Legend.Position)
                        thisPoint += int.Parse(oe.AttribValue);
                    continue;
                }
                if (oe.AttribName == "Position")        //图表位置(只对嵌入式的图表有效)
                {
                    if (stuObj != null && checkRangeSame(stuObj.TopLeftCell, ansObj.TopLeftCell)
                        && checkRangeSame(stuObj.BottomRightCell, ansObj.BottomRightCell))
                        thisPoint += int.Parse(oe.AttribValue);
                    continue;
                }
                if (oe.AttribName == "DataLabels")      //数据标志
                { 
                    bool check = false, right = true;
                    foreach (Excel.Series ser in (Excel.SeriesCollection)ansCh.SeriesCollection(nullobj))
                        if (ser.HasDataLabels == true)
                        {
                            check = true;
                            break;
                        }
                    foreach (Excel.Series ser in (Excel.SeriesCollection)stuCh.SeriesCollection(nullobj))
                        if (ser.HasDataLabels != check)
                        {
                            right = false;
                            break;
                        }
                    if (right)
                        thisPoint += int.Parse(oe.AttribValue);
                    continue;
                }
            }
            return thisPoint;
        }

        //获取图表中的数据
        private List<List<string>> GetValue(Excel.Chart ch, Excel.Workbook xls)
        {
            int i, j, k, state;
            Excel.SeriesCollection sc = (Excel.SeriesCollection)ch.SeriesCollection(nullobj);
            List<List<string>> res = new List<List<string>>();
            for (i = 1; i <= sc.Count; i++)
            {
                res.Add(new List<string>());
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
                        for (j = 1; j <= yRange.Cells.Count; j++)
                        {
                            Excel.Range cell = (Excel.Range)yRange.Cells[j, nullobj];
                            res[i - 1].Add(cell.Value2.ToString());
                        }
                        state = 1;
                    }
                    catch { }
                }
            }
            return res;
        }

        //判断两个单元格是否位置一致
        private bool checkRangeSame(Excel.Range r1, Excel.Range r2)
        {
            if (r1.Column != r2.Column) return false;
            if (r1.Row != r2.Row) return false;
            return true;
        }

        //获取单个单元格
        private Excel.Range getCell(Excel.Worksheet ws, int row, int col)
        {
            return (Excel.Range)ws.get_Range(ws.Cells[row, col], ws.Cells[row, col]);
        }

        //获取单元格区域
        private Excel.Range getRegion(Excel.Worksheet ws, int row0, int col0, int row1, int col1)
        {
            return (Excel.Range)ws.get_Range(ws.Cells[row0, col0], ws.Cells[row1, col1]);
        }
    }
}
