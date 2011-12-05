using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
 
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using OES.Model;

namespace OES.UControl
{
    public partial class CustomExcel : UserControl
    {
        [DllImport("user32", EntryPoint = "HideCaret")]
        private static extern bool HideCaret(IntPtr hWnd);

        //static string paperPath = Config.paperPath;
        //static string name = "f.xls";
        //static string stuPath = Config.stuPath + "stu_" + name;
        private string filename = "";
        private int proid;

        public int proID
        {
            get { return proid; }
            set
            {
                proid = value;
                if (proid == ClientControl.paper.officeExcel.Count - 1)
                {
                    NextProblem.Enabled = false;
                }
                else if (proid == 0)
                {
                    LastProblem.Enabled = false;
                }
                else
                {
                    NextProblem.Enabled = true;
                    LastProblem.Enabled = true;
                }
            }
        }

        private OfficeExcel excel = new OfficeExcel();

        public CustomExcel()
        {
            InitializeComponent();
            proID = 0;
            this.SetQuestion(proID);
            this.Dock = DockStyle.Fill;
        }

        public void SetQuestion(int x)
        {
            proID = x;
            excel = ClientControl.GetOfficeExcel(proID);
            this.Question.Text = excel.problem;
            this.filename = "e" + proID.ToString() + ".xls";
        }

        private void nextstep_Click(object sender, EventArgs e)
        {
            if (proID < ClientControl.paper.officeExcel.Count - 1)
            {
                this.SetQuestion(++proID);
                ClientControl.CurrentProblemNum++;
            }
        }

        private void laststep_Click(object sender, EventArgs e)
        {
            if (proID > 0)
            {
                this.SetQuestion(--proID);
                ClientControl.CurrentProblemNum--;
            }

        }

        public int GetQuestion()
        {
            return proID;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!File.Exists(Config.stuPath + filename))
            {
                File.Copy(Config.paperPath + filename, Config.stuPath + filename, true);
            }
            while (!File.Exists(Config.stuPath + filename)) ;
            System.Diagnostics.Process.Start(Config.stuPath + filename);
            ClientControl.SetDone(ClientControl.CurrentProblemNum);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            if (MessageBox.Show("继续将会删除之前答案", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                File.Copy(Config.paperPath + filename, Config.stuPath + filename, true);
                System.Diagnostics.Process.Start(Config.stuPath + filename);
            }
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            System.Diagnostics.Process[] pro = System.Diagnostics.Process.GetProcesses();
            foreach (System.Diagnostics.Process pro1 in pro)
            {
                if (pro1.ProcessName == "EXCEL" | pro1.ProcessName == "excel")
                {
                    pro1.Kill();
                }
            }
        }

        //private void button4_Click(object sender, EventArgs e)
        //{

        //    MessageBox.Show(Correct.Correctppt(path2, path3).ToString());
        //}


        private void Hide_MouseDown(object sender, MouseEventArgs e)
        {
            HideCaret(((RichTextBox)sender).Handle);
        }
        private void Hide1_MouseDown(object sender, MouseEventArgs e)
        {

        }
    }
}

//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Drawing;
//using System.Data;
// 
//using System.Text;
//using System.Windows.Forms;
//using System.Xml;
//using System.IO;
//using System.Web;
//using Microsoft.Office.Interop.Excel;
//using System.Reflection;
//using System.Runtime.InteropServices;


//namespace OES.UControl
//{
//    public partial class CustomExcel : UserControl
//    {
//        [DllImport("user32", EntryPoint = "HideCaret")]
//        private static extern bool HideCaret(IntPtr hWnd);

//        /*负责解压文件的类*/
//        private clsWinrar winRar;
//        private int row_s, cell_s, row_e, cell_e;


//        /*表示工作簿*/
//        private Microsoft.Office.Interop.Excel.Workbook xlwook;
//        private Microsoft.Office.Interop.Excel.Workbook xlwook_answer;
//        /*表示整个excel程序*/
//        private Microsoft.Office.Interop.Excel.Application excel_handle;
//        /*该对象表示excel中的一张工作表*/
//        private Microsoft.Office.Interop.Excel.Worksheet ws;
//        private Microsoft.Office.Interop.Excel.Worksheet ws_answer;
//        /*该对象代表单元格区域*/
//        private Microsoft.Office.Interop.Excel.Range r;
//        private Microsoft.Office.Interop.Excel.Range r_answer;
//        /*工程文件夹的路径*/
//        private string pathProName;
//        private string area;
//        private string bookTitle;
//        /*这道题的总分*/
//        private double sumScore;
//        private IntPtr t;
//        /*进程的ID号*/
//        private int k;
//        /*表示excel进程*/
//        private System.Diagnostics.Process p;

//        public CustomExcel()
//        {
//            InitializeComponent();
//            this.Question.Text = ClientControl.paper.officeExcel.problem;
//            winRar = new clsWinrar();
//            pathProName = Environment.CurrentDirectory.Substring(0, Environment.CurrentDirectory.LastIndexOf("\\")).Substring(0,
//    Environment.CurrentDirectory.Substring(0, Environment.CurrentDirectory.LastIndexOf("\\")).LastIndexOf("\\"));
//            sumScore = 30;
//        }


//        private void button_getPro_Click(object sender, EventArgs e)
//        {
//            string rarPath = pathProName + "\\client\\";
//            string rarName = "client_exam.rar";
//            winRar.unCompressRAR(rarPath, rarPath, rarName);

//            /*输入题目和题干*/
//            string txtPathName = pathProName + "\\client\\12.txt";
//            StreamReader sr = new StreamReader(@txtPathName, Encoding.Default);
//            string content = sr.ReadToEnd();
//            richTextBox1.Text = content;
//            Question.Text = content;
//            sr.Close();
//        }


//        [DllImport("User32.dll", CharSet = CharSet.Auto)]
//        public static extern int GetWindowThreadProcessId(IntPtr hwnd, out int ID);
//        private void button_open_Click(object sender, EventArgs e)
//        {
//            string fileName = "\\client\\exam.xls";
//            string pathName = pathProName + fileName;
//            object MissingValue = Type.Missing;
//            excel_handle = new Microsoft.Office.Interop.Excel.Application();

//            t = new IntPtr(excel_handle.Hwnd);
//            k = 0;
//            GetWindowThreadProcessId(t, out k);
//            p = System.Diagnostics.Process.GetProcessById(k);

//            xlwook = excel_handle.Workbooks.Open(pathName, MissingValue, MissingValue, MissingValue, MissingValue,
//                MissingValue, MissingValue, MissingValue, MissingValue, MissingValue, MissingValue, MissingValue, MissingValue, MissingValue, MissingValue);
//            excel_handle.Visible = true;
//            ClientControl.SetDone(ClientControl.CurrentProblemNum);
//        }

//        /*响应“检查”那个按钮的事件*/
//        private void button_check_Click(object sender, EventArgs e)
//        {
//            int wrongNum = 0;
//            int i, j;
//            string xls = pathProName + "\\client\\exam.xls";
//            string xmlFileName = pathProName + "\\client\\answer.xml";
//            string xls_answer = pathProName + "\\client\\Subject_excel.xls";
//            excel_handle.Visible = false;
//            xlwook_answer = excel_handle.Workbooks.Add(xls_answer);
//            xlwook = excel_handle.Workbooks.Add(xls);
//            /*初始化xml文档操作类*/
//            XmlDocument myDoc = new XmlDocument();
//            /*加载xml文件*/
//            myDoc.Load(xmlFileName);
//            /*搜索指定某列，一般是主键列*/
//            XmlNodeList myNode = myDoc.SelectNodes("//Tip1");
//            /*判断是否有这个节点*/
//            if (!(myNode == null))
//            {
//                foreach (System.Xml.XmlNode xn in myNode)
//                {/*excel表格中有内容的区域*/
//                    area = xn.SelectSingleNode("second").InnerText;
//                }
//            }
//            /*顺序不能变，得到初始的行列值，和结束的行列值*/


//            ws = (Worksheet)xlwook.ActiveSheet;
//            ws_answer = (Worksheet)xlwook_answer.ActiveSheet;
//            getRange();

//            /*用来评测单元格的内容*/
//            for (i = row_s; i <= row_e; i++)
//                for (j = cell_s; j <= cell_e; j++)
//                {
//                    if (ws.get_Range(ws.Cells[i, j], ws.Cells[i, j]).Value2 == null || ws_answer.get_Range(ws_answer.Cells[i, j], ws_answer.Cells[i, j]).Value2 == null)
//                    {
//                        wrongNum++;
//                        continue;
//                    }
//                    if (ws.get_Range(ws.Cells[i, j], ws.Cells[i, j]).Value2 == null && ws_answer.get_Range(ws_answer.Cells[i, j], ws_answer.Cells[i, j]).Value2 == null)
//                        continue;
//                    if (ws.get_Range(ws.Cells[i, j], ws.Cells[i, j]).Value2.ToString().Trim() != ws_answer.get_Range(ws_answer.Cells[i, j], ws_answer.Cells[i, j]).Value2.ToString().Trim())
//                        wrongNum++;
//                }
//            sumScore -= wrongNum * 1;

//            /*确定对齐方式*/
//            for (i = cell_s; i <= cell_e; i++)
//            {
//                Range r1, r2;
//                r1 = ws.get_Range(ws.Cells[row_s, i], ws.Cells[row_e, i]);
//                r2 = ws_answer.get_Range(ws_answer.Cells[row_s, i], ws_answer.Cells[row_e, i]);
//                if (r1.HorizontalAlignment != r2.HorizontalAlignment)
//                {
//                    sumScore -= 0.5;
//                }
//            }
//            for (i = row_s; i < row_e; i++)
//            {
//                Range r1, r2;
//                r1 = ws.get_Range(ws.Cells[i, cell_s], ws.Cells[i, cell_e]);
//                r2 = ws_answer.get_Range(ws_answer.Cells[i, cell_s], ws_answer.Cells[i, cell_e]);
//                if (r1.VerticalAlignment != r2.VerticalAlignment)
//                {
//                    sumScore -= 0.5;
//                }
//            }

//            /*确定合并单元格*/
//            for (i = row_s; i <= row_e; i++)
//                for (j = cell_s; j <= cell_e; j++)
//                {
//                    if (ws_answer.get_Range(ws_answer.Cells[i, j], ws_answer.Cells[i, j]).MergeArea != ws.get_Range(ws.Cells[i, j], ws.Cells[i, j]).MergeArea)
//                    {
//                        sumScore -= 2;
//                        goto next;
//                    }
//                }

//        next:
//            /*确定单元格的公式*/
//            for (i = row_s; i <= row_e; i++)
//                for (j = cell_s; j <= cell_e; j++)
//                {
//                    if (ws_answer.get_Range(ws_answer.Cells[i, j], ws_answer.Cells[i, j]).Formula != ws.get_Range(ws.Cells[i, j], ws.Cells[i, j]).Formula)
//                    {
//                        sumScore -= 2;
//                    }
//                }

//            /*确定表单的名字*/
//            if (ws.Name != ws_answer.Name)
//                sumScore -= 2;

//            /*确定图表的正确性*/
//            if (ws_answer.ChartObjects(1) != null)
//            {
//                if (((ChartObjects)ws.ChartObjects(Type.Missing)).Count == 0)
//                {
//                    sumScore -= 5;
//                }
//                else
//                {
//                    ChartObject chartobj_s = (ChartObject)((ChartObjects)(ws.ChartObjects(Type.Missing))).Item(1);
//                    Chart chart_s = chartobj_s.Chart;
//                    ChartObject chartobj_a = (ChartObject)((ChartObjects)(ws_answer.ChartObjects(Type.Missing))).Item(1);
//                    Chart chart_a = chartobj_a.Chart;
//                    if (chart_s.ChartType != chart_a.ChartType)
//                    {
//                        sumScore -= 5;
//                    }
//                    else
//                    {
//                        if (chartobj_s.TopLeftCell != chartobj_a.TopLeftCell || chartobj_s.BottomRightCell != chartobj_a.BottomRightCell)
//                        {
//                            sumScore -= 2;
//                        }
//                        if (chart_s.ChartTitle.Text != chart_a.ChartTitle.Text)
//                        {
//                            sumScore -= 3;
//                        }
//                    }
//                }
//            }

//            ChartObjects charts = (ChartObjects)ws_answer.ChartObjects(Type.Missing);
//            ChartObject chartObject = (ChartObject)charts.Item(1);
//            Chart chart = chartObject.Chart;
//            if (chart.ChartType == Microsoft.Office.Interop.Excel.XlChartType.xlPie)
//            {
//                //MessageBox.Show("Sucess!");
//            }
//            if (chartObject.TopLeftCell.Column == 5 && chartObject.TopLeftCell.Row == 5)
//            {
//                //MessageBox.Show("sucess again!");
//            }
//            /*图表的标题*/
//            if (chart.ChartTitle.Text == "")
//            {
//            }

//            //ws.get_Range(ws.Cells[6, 9], ws.Cells[12, 15]);

//            excel_handle.ActiveWorkbook.Saved = true;
//            excel_handle.Workbooks.Close();
//            excel_handle.Quit();
//            p.Kill();
//            MessageBox.Show("the score is 8");
//        }


//        private int getRow(string areas)
//        {
//            int i, j;
//            int row = 0;
//            char c;

//            for (i = 0; i < area.Length; i++)
//            {
//                c = areas[i];
//                if (c < 65)
//                    break;
//            }
//            for (j = 0; j < i; j++)
//            {
//                row += (int)Math.Pow(26, i - j - 1) * (area[j] - 64);
//            }
//            area = area.Substring(i, area.Length - i);
//            return row;
//        }

//        private int getCell(string areas)
//        {
//            int cell;
//            string outcome;
//            int i, j;
//            char c;
//            for (i = 0; i < areas.Length; i++)
//            {
//                c = area[i];
//                if (c > 57)
//                    break;
//            }
//            outcome = areas.Substring(0, i);
//            area = area.Substring(i, area.Length - i);
//            cell = Convert.ToInt32(outcome);
//            return cell;
//        }

//        private void button_repeat_Click(object sender, EventArgs e)
//        {
//            string rarPath = pathProName + "\\client\\";
//            string rarName = "client_exam.rar";
//            winRar.unCompressRAR(rarPath, rarPath, rarName);


//        }

//        public void getRange()
//        {
//            int i, j;
//            int begin_i = 50, begin_j = 50;
//            int end_i = 0, end_j = 0;
//            for (i = 1; i <= 50; i++)
//            {
//                for (j = 1; j <= 50; j++)
//                {
//                    if (ws_answer.get_Range(ws_answer.Cells[i, j], ws_answer.Cells[i, j]).Value2 != null)
//                    {
//                        if (i < begin_i)
//                            begin_i = i;
//                        if (j < begin_j)
//                            begin_j = j;
//                        if (end_i < i)
//                            end_i = i;
//                        if (end_j < j)
//                            end_j = j;
//                    }
//                }
//            }
//            row_s = begin_i;
//            cell_s = begin_j;
//            row_e = end_i;
//            cell_e = end_j;
//            r_answer = ws_answer.get_Range(ws_answer.Cells[begin_i, begin_j], ws_answer.Cells[end_i, end_j]);
//        }


//        private void Hide_MouseDown(object sender, MouseEventArgs e)
//        {
//            HideCaret(((RichTextBox)sender).Handle);
//        }
//        private void Hide1_MouseDown(object sender, MouseEventArgs e)
//        {

//        }
//    }
//}
