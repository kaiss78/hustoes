using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Word = Microsoft.Office.Interop.Word;
using OESXML;
using System.Windows.Forms;

namespace OESOfficeScore
{
    public class WordScore
    {
        Word.Application word;
        Word.Document stuDoc, ansDoc;
        Word.Paragraph stuPara, ansPara;
        Word.Shape stuSp, ansSp;
        Word.PageSetup stuPs, ansPs;
        Word.Table stuTab, ansTab;
        Word.Cell stuCell, ansCell;
        Word.Range stuRange, ansRange;
        Word.DropCap stuDc, ansDc;
        Word.TextColumns stuTc, ansTc;
        Word.TextFrame stuTf, ansTf;
        OfficeXML oxml;

        public const Microsoft.Office.Core.MsoTriState False = Microsoft.Office.Core.MsoTriState.msoFalse;
        public const Microsoft.Office.Core.MsoTriState True = Microsoft.Office.Core.MsoTriState.msoTrue;

        const int PART_PARAGRAPH = 0;           //正在分析段落属性部分
        const int PART_TABLE = 1;               //正在分析表格属性部分
        const int PART_CELL = 2;                //正在分析单元格属性部分
        const int PART_TEXTBOX = 3;             //正在分析文本框属性部分
        const int PART_PAGESETUP = 4;           //正在分析页面设置属性部分

        //外部调用函数，返回总分
        public int checkPoints(string stu, string ans, string xml)
        {
            int totalPoints = 0;
            openFile(stu, ans, xml);
            foreach (List<OfficeElement> oel in oxml.AnsPaths)
                totalPoints += check_Kernel(oel);
            dispose();
            return totalPoints;
        }

        private int check_Kernel(List<OfficeElement> ls)
        {
            int points = 0, i;
            int curPart = -1;            //当前正在分析哪一部分的考点
            for (i = 0; i < ls.Count; i++)
            {
                OfficeElement oe = ls[i];
                #region 具体考点对象定位
                if (oe.AttribName == "Root")
                    continue;
                if (oe.AttribName == "Documents")
                    continue;
                if (oe.AttribName == "Paragraph")
                {
                    #region 段落定位
                    try
                    {
                        int paraIdx = int.Parse(oe.AttribValue);
                        stuPara = stuDoc.Paragraphs[paraIdx];
                        ansPara = ansDoc.Paragraphs[paraIdx];
                    }
                    catch
                    {
                        points = 0;
                        break;
                    }
                    #endregion
                    curPart = PART_PARAGRAPH;
                    continue;
                }
                if (oe.AttribName == "Table")
                {
                    #region 表格定位
                    try
                    {
                        int tabIdx = int.Parse(oe.AttribValue);
                        stuTab = stuDoc.Tables[tabIdx];
                        ansTab = ansDoc.Tables[tabIdx];
                    }
                    catch
                    {
                        points = 0;
                        break;
                    }
                    #endregion
                    curPart = PART_TABLE;
                    continue;
                }
                if (oe.AttribName == "Cell")
                {
                    #region 单元格定位
                    try
                    {
                        int rowIdx, colIdx, commaIdx;
                        commaIdx = oe.AttribValue.IndexOf(',');
                        rowIdx = int.Parse(oe.AttribValue.Substring(0, commaIdx));
                        colIdx = int.Parse(oe.AttribValue.Substring(commaIdx + 1));
                        stuCell = stuTab.Cell(rowIdx, colIdx);
                        ansCell = ansTab.Cell(rowIdx, colIdx);
                    }
                    catch
                    {
                        points = 0;
                        break;
                    }
                    #endregion
                    curPart = PART_CELL;
                    continue;
                }
                if (oe.AttribName == "Textbox")
                {
                    #region 文本框定位
                    try
                    {
                        int tbIdx = int.Parse(oe.AttribValue);
                        object ob = tbIdx;
                        stuSp = stuDoc.Shapes.get_Item(ref ob);
                        ansSp = ansDoc.Shapes.get_Item(ref ob);
                        stuTf = stuSp.TextFrame;
                        ansTf = ansSp.TextFrame;
                    }
                    catch
                    {
                        points = 0;
                        break;
                    }
                    #endregion
                    curPart = PART_TEXTBOX;
                    continue;
                }
                if (oe.AttribName == "PageSetup")
                {
                    #region 页面设置定位
                    try
                    {
                        stuPs = stuDoc.PageSetup;
                        ansPs = ansDoc.PageSetup;
                    }
                    catch
                    {
                        points = 0;
                        break;
                    }
                    #endregion
                    continue;
                }
                #endregion
                #region 段落属性判分
                if (curPart == PART_PARAGRAPH)
                {
                    switch (oe.AttribName)
                    {
                        case "Indent":
                            break;
                        case "Font":
                            stuRange = stuPara.Range;
                            ansRange = ansPara.Range;
                            break;
                        case "Dropcap":
                            stuDc = stuPara.DropCap;
                            ansDc = ansPara.DropCap;
                            break;
                        case "TextColumns":
                            stuTc = stuPara.Range.PageSetup.TextColumns;
                            ansTc = ansPara.Range.PageSetup.TextColumns;
                            break;
                        #region 段落部分
                        case "Alignment":
                            if (stuPara.Alignment == ansPara.Alignment)
                                points = int.Parse(oe.AttribValue);
                            break;
                        case "CharacterUnitFirstLineIndent":
                            if (stuPara.CharacterUnitFirstLineIndent == ansPara.CharacterUnitFirstLineIndent)
                                points = int.Parse(oe.AttribValue);
                            break;
                        case "CharacterUnitLeftIndent":
                            if (stuPara.CharacterUnitLeftIndent == ansPara.CharacterUnitLeftIndent)
                                points = int.Parse(oe.AttribValue);
                            break;
                        case "CharacterUnitRightIndent":
                            if (stuPara.CharacterUnitRightIndent == ansPara.CharacterUnitRightIndent)
                                points = int.Parse(oe.AttribValue);
                            break;
                        case "LineUnitBefore":
                            if (stuPara.LineUnitBefore == ansPara.LineUnitBefore)
                                points = int.Parse(oe.AttribValue);
                            break;
                        case "LineUnitAfter":
                            if (stuPara.LineUnitAfter == ansPara.LineUnitAfter)
                                points = int.Parse(oe.AttribValue);
                            break;
                        case "LineSpacingRule":
                            if (stuPara.LineSpacingRule == ansPara.LineSpacingRule)
                                points = int.Parse(oe.AttribValue);
                            break;
                        case "LineSpacing":
                            if (stuPara.LineSpacing == ansPara.LineSpacing)
                                points = int.Parse(oe.AttribValue);
                            break;
                        #endregion
                        #region 文字部分
                        case "Text":
                            if (stuRange.Text == ansRange.Text)
                                points = int.Parse(oe.AttribValue);
                            break;
                        case "FontSize":
                            if (stuRange.Font.Size == ansRange.Font.Size)
                                points = int.Parse(oe.AttribValue);
                            break;
                        case "FontName":
                            if (stuRange.Font.Name == ansRange.Font.Name)
                                points = int.Parse(oe.AttribValue);
                            break;
                        case "Bold":
                            if (stuRange.Font.Bold == ansRange.Font.Bold)
                                points = int.Parse(oe.AttribValue);
                            break;
                        case "Italic":
                            if (stuRange.Font.Italic == ansRange.Font.Italic)
                                points = int.Parse(oe.AttribValue);
                            break;
                        case "Underline":
                            if (stuRange.Font.Underline == ansRange.Font.Underline)
                                points = int.Parse(oe.AttribValue);
                            break;
                        case "UnderlineColor":
                            if (stuRange.Font.UnderlineColor == ansRange.Font.UnderlineColor)
                                points = int.Parse(oe.AttribValue);
                            break;
                        case "ForeColor":
                            if (stuRange.Font.Color == ansRange.Font.Color)
                                points = int.Parse(oe.AttribValue);
                            break;
                        case "HighLightColor":
                            if (stuRange.HighlightColorIndex == ansRange.HighlightColorIndex)
                                points = int.Parse(oe.AttribValue);
                            break;
                        case "Superscript":
                            if (stuRange.Font.Superscript == ansRange.Font.Superscript)
                                points = int.Parse(oe.AttribValue);
                            break;
                        case "Subscript":
                            if (stuRange.Font.Subscript == ansRange.Font.Subscript)
                                points = int.Parse(oe.AttribValue);
                            break;
                        case "Spacing":
                            if (stuRange.Font.Spacing == ansRange.Font.Spacing)
                                points = int.Parse(oe.AttribValue);
                            break;
                        case "Animation":
                            if (stuRange.Font.Animation == ansRange.Font.Animation)
                                points = int.Parse(oe.AttribValue);
                            break;
                        case "BackgroundPatternColor":
                            if (stuRange.Shading.BackgroundPatternColor == ansRange.Shading.BackgroundPatternColor)
                                points = int.Parse(oe.AttribValue);
                            break;
                        #endregion
                        #region 首字下沉
                        case "Position":
                            if (stuDc.Position == ansDc.Position)
                                points = int.Parse(oe.AttribValue);
                            break;
                        case "DcFontName":
                            if (stuDc.FontName == ansDc.FontName)
                                points = int.Parse(oe.AttribValue);
                            break;
                        case "LinesToDrop":
                            if (stuDc.LinesToDrop == ansDc.LinesToDrop)
                                points = int.Parse(oe.AttribValue);
                            break;
                        case "DistanceFromText":
                            if (stuDc.DistanceFromText == ansDc.DistanceFromText)
                                points = int.Parse(oe.AttribValue);
                            break;
                        #endregion
                        #region 分栏与栏宽
                        case "TextColumnsCount":
                            if (stuTc.Count == ansTc.Count)
                                points = int.Parse(oe.AttribValue);
                            break;
                        case "TextColumnsWidth":
                            if (stuTc.Width == ansTc.Width)
                                points = int.Parse(oe.AttribValue);
                            break;
                        case "TextColumnsSpacing":
                            if (stuTc.Spacing == ansTc.Spacing)
                                points = int.Parse(oe.AttribValue);
                            break;
                        case "TextColumnsLineBetween":
                            if (stuTc.LineBetween == ansTc.LineBetween)
                                points = int.Parse(oe.AttribValue);
                            break;
                        #endregion
                    }
                    continue;
                }
                #endregion
                #region 表格属性判分
                if (curPart == PART_TABLE)
                {
                    switch (oe.AttribName)
                    {
                        case "Rows":
                            if (stuTab.Rows.Count == ansTab.Rows.Count)
                                points = int.Parse(oe.AttribValue);
                            break;
                        case "Columns":
                            if (stuTab.Columns.Count == ansTab.Columns.Count)
                                points = int.Parse(oe.AttribValue);
                            break;
                    }
                    continue;
                }
                #endregion
                #region 单元格属性判分
                if (curPart == PART_CELL)
                {
                    switch (oe.AttribName)
                    { 
                        case "Text":
                            if (stuCell.Range.Text == ansCell.Range.Text)
                                points = int.Parse(oe.AttribValue);
                            break;
                        case "Height":
                            if (stuCell.Height == ansCell.Height)
                                points = int.Parse(oe.AttribValue);
                            break;
                        case "Width":
                            if (stuCell.Width == ansCell.Width)
                                points = int.Parse(oe.AttribValue);
                            break;
                    }
                    continue;
                }
                #endregion
                #region 文本框属性判分
                if (curPart == PART_TEXTBOX)
                {
                    switch (oe.AttribName)
                    {
                        case "Text":
                            if (stuTf.TextRange.Text == ansTf.TextRange.Text)
                                points = int.Parse(oe.AttribValue);
                            break;
                        case "Orientation":
                            if (stuTf.Orientation == ansTf.Orientation)
                                points = int.Parse(oe.AttribValue);
                            break;
                        case "FontName":
                            if (stuTf.TextRange.Font.Name == ansTf.TextRange.Font.Name)
                                points = int.Parse(oe.AttribValue);
                            break;
                        case "FontSize":
                            if (stuTf.TextRange.Font.Size == ansTf.TextRange.Font.Size)
                                points = int.Parse(oe.AttribValue);
                            break;
                        case "ForeColor":
                            if (stuTf.TextRange.Font.Color == ansTf.TextRange.Font.Color)
                                points = int.Parse(oe.AttribValue);
                            break;
                        case "HighLightColor":
                            if (stuTf.TextRange.HighlightColorIndex == ansTf.TextRange.HighlightColorIndex)
                                points = int.Parse(oe.AttribValue);
                            break;
                        case "Spacing":
                            if (stuTf.TextRange.Font.Spacing == ansTf.TextRange.Font.Spacing)
                                points = int.Parse(oe.AttribValue);
                            break;
                        case "Alignment":
                            if (stuTf.TextRange.ParagraphFormat.Alignment == ansTf.TextRange.ParagraphFormat.Alignment)
                                points = int.Parse(oe.AttribValue);
                            break;
                    }
                    continue;
                }
                #endregion
                #region 页面设置属性判分
                if (curPart == PART_PAGESETUP)
                {
                    switch (oe.AttribName)
                    { 
                        case "TopMargin":
                            if (stuPs.TopMargin == ansPs.TopMargin)
                                points = int.Parse(oe.AttribValue);
                            break;
                        case "BottomMargin":
                            if (stuPs.BottomMargin == ansPs.BottomMargin)
                                points = int.Parse(oe.AttribValue);
                            break;
                        case "LeftMargin":
                            if (stuPs.LeftMargin == ansPs.LeftMargin)
                                points = int.Parse(oe.AttribValue);
                            break;
                        case "RightMargin":
                            if (stuPs.RightMargin == ansPs.RightMargin)
                                points = int.Parse(oe.AttribValue);
                            break;
                        case "HeaderDistance":
                            if (stuPs.HeaderDistance == ansPs.HeaderDistance)
                                points = int.Parse(oe.AttribValue);
                            break;
                        case "FooterDistance":
                            if (stuPs.FooterDistance == ansPs.FooterDistance)
                                points = int.Parse(oe.AttribValue);
                            break;
                        case "Orientation":
                            if (stuPs.Orientation == ansPs.Orientation)
                                points = int.Parse(oe.AttribValue);
                            break;
                        case "GutterPos":
                            if (stuPs.GutterPos == ansPs.GutterPos)
                                points = int.Parse(oe.AttribValue);
                            break;
                    }
                    continue;
                }
                #endregion
            }
            return points;
        }

        //打开文件，读入xml信息
        private void openFile(string stu, string ans, string xml)
        {
            word = new Word.Application();
            Object confirmConversions = Type.Missing;
            Object readOnly = true;
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
            Object file_path;
            file_path = stu;
            stuDoc = word.Documents.Open(ref file_path, ref confirmConversions,
                ref readOnly, ref addToRecentFiles, ref passwordDocument,
                ref passwordTemplate, ref revert, ref writePasswordDocument,
                ref writePasswordTemplate, ref format, ref encoding, ref visible,
                ref openConflictDocument, ref openAndRepair, ref documentDirection,
                ref noEncodingDialog);
            file_path = ans;
            ansDoc = word.Documents.Open(ref file_path, ref confirmConversions,
                ref readOnly, ref addToRecentFiles, ref passwordDocument,
                ref passwordTemplate, ref revert, ref writePasswordDocument,
                ref writePasswordTemplate, ref format, ref encoding, ref visible,
                ref openConflictDocument, ref openAndRepair, ref documentDirection,
                ref noEncodingDialog);
            oxml = new OfficeXML(xml);
            getPoint(oxml);
        }

        //获取考点信息
        private void getPoint(OfficeXML ox)
        {
            try { ox.getAllAnsPath(); }
            catch
            {
                MessageBox.Show("获取考点信息失败！");
                throw;
            }
        }

        //结束评分
        private void dispose()
        {
            try
            {
                Object saveChanges = Word.WdSaveOptions.wdDoNotSaveChanges;
                Object originalFormat = Type.Missing;
                Object routeDocument = Type.Missing;

                stuDoc.Close(ref saveChanges,
                  ref originalFormat, ref routeDocument);
                stuDoc = null;

                ansDoc.Close(ref saveChanges,
                  ref originalFormat, ref routeDocument);
                ansDoc = null;

                word.Quit(ref saveChanges,
                    ref originalFormat, ref routeDocument);
                word = null;
            }
            catch { }
            GC.Collect();
        }
    }
}
