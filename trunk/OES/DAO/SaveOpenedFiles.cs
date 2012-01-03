using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Word = Microsoft.Office.Interop.Word;
using Excel = Microsoft.Office.Interop.Excel;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;

namespace OES.DAO
{
    public class SaveOpenedFiles
    {
        private static Word.Application word;
        private static Word.Document doc;
        //打开Word文档
        public static void OpenWord(string filePath)
        {
            try
            {
                word = new Word.Application();
                Object file_path = filePath;
                Object confirmConversions = Type.Missing;
                Object readOnly = false;
                Object addToRecentFiles = Type.Missing;
                Object passwordDocument = Type.Missing;
                Object passwordTemplate = Type.Missing;
                Object revert = Type.Missing;
                Object writePasswordDocument = Type.Missing;
                Object writePasswordTemplate = Type.Missing;
                Object format = Type.Missing;
                Object encoding = Type.Missing;
                Object visible = Type.Missing;
                Object openConflictDocument = Type.Missing;
                Object openAndRepair = Type.Missing;
                Object documentDirection = Type.Missing;
                Object noEncodingDialog = Type.Missing;
                doc = word.Documents.Open(ref file_path, ref confirmConversions,
                    ref readOnly, ref addToRecentFiles, ref passwordDocument,
                    ref passwordTemplate, ref revert, ref writePasswordDocument,
                    ref writePasswordTemplate, ref format, ref encoding, ref visible,
                    ref openConflictDocument, ref openAndRepair, ref documentDirection,
                    ref noEncodingDialog);
                word.Visible = true;
                word.DocumentBeforeClose += new Microsoft.Office.Interop.Word.ApplicationEvents4_DocumentBeforeCloseEventHandler(word_DocumentBeforeClose);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private static void word_DocumentBeforeClose(Microsoft.Office.Interop.Word.Document Doc, ref bool Cancel)
        {
            CloseWord();
            Cancel = true;
        }
        //关闭Word文档
        public static void CloseWord()
        {
            if (doc != null)
            {
                try
                {

                    Object saveChanges = Word.WdSaveOptions.wdSaveChanges;
                    Object originalFormat = Type.Missing;
                    Object routeDocument = Type.Missing;

                    doc.Close(ref saveChanges,
                      ref originalFormat, ref routeDocument);
                    doc = null;

                    word.Quit(ref saveChanges,
                        ref originalFormat, ref routeDocument);
                    word = null;

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
                GC.Collect();
            }
        }
        private static Excel.Application excel;
        private static Excel.Workbook xls;
        private static object nullobj = System.Reflection.Missing.Value;
        //打开Excel文档
        public static void OpenExcel(string filePath)
        {
            try
            {
                excel = new Excel.Application();
                xls = excel.Workbooks.Open(filePath, nullobj, False, nullobj,
                     nullobj, nullobj, nullobj, nullobj,
                    nullobj, nullobj, nullobj, nullobj, nullobj,
                    nullobj, nullobj);
                excel.Visible = true;
                //excel.WorkbookBeforeClose += new Microsoft.Office.Interop.Excel.AppEvents_WorkbookBeforeCloseEventHandler(excel_WorkbookBeforeClose);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        static void excel_WorkbookBeforeClose(Microsoft.Office.Interop.Excel.Workbook Wb, ref bool Cancel)
        {
            CloseExcel();
            Cancel = true;
        }
        //关闭Excel文档
        public static void CloseExcel()
        {
            if (xls != null)
            {
                try
                {
                    Object saveChanges = Excel.XlSaveAction.xlSaveChanges;
                    Object originalFormat = Type.Missing;
                    Object routeDocument = Type.Missing;
                    xls.Save();
                    xls.Close(saveChanges, originalFormat, routeDocument);
                    xls = null;

                    excel.Quit();
                    excel = null;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
                GC.Collect();
            }
        }
        private static PowerPoint.Application powerpoint;
        private static PowerPoint.Presentation ppt;
        private static Microsoft.Office.Core.MsoTriState False = Microsoft.Office.Core.MsoTriState.msoFalse;
        private static Microsoft.Office.Core.MsoTriState True = Microsoft.Office.Core.MsoTriState.msoTrue;
        private static string pptPath="";
        //打开Powerpoint文档
        public static void OpenPowerPoint(string filePath)
        {
            try
            {
                pptPath = filePath;
                powerpoint = new PowerPoint.ApplicationClass();
                powerpoint.Visible = True;                              //一定要放在Open前！
                //powerpoint.PresentationClose += new Microsoft.Office.Interop.PowerPoint.EApplication_PresentationCloseEventHandler(powerpoint_PresentationClose);
                ppt = powerpoint.Presentations.Open(filePath, False, False, True);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        static void powerpoint_PresentationClose(Microsoft.Office.Interop.PowerPoint.Presentation Pres)
        {
            ClosePowerPoint();
        }
        //关闭Powerpoint文档
        public static void ClosePowerPoint()
        {
            if (ppt != null)
            {
                try
                {
                    ppt.SaveAs(pptPath, PowerPoint.PpSaveAsFileType.ppSaveAsPresentation, True);
                    ppt.Close();
                    ppt = null;

                    powerpoint.Quit();
                    powerpoint = null;

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
                GC.Collect();
            }
        }

        public static void CloseAll()
        {
            CloseWord();
            CloseExcel();
            ClosePowerPoint();
        }
    }
}
