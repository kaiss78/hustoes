using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using Word = Microsoft.Office.Interop.Word;
using OESXML;

namespace OESOffice
{
    public partial class testWord : UserControl
    {
        Word.Application word;
        Word.Document doc;
        TestWordHelper helper;

        const double SCALE_CM = 28.3466;    //程序得到的小数转成厘米的比例尺
        const double SCALE_CHAR = 10.50;    //程序得到的小数转成字符长度的比例尺

        private Word.DocumentEvents2_OpenEventHandler openEvent;
        private Word.DocumentEvents2_CloseEventHandler closeEvent;

        string xmlPath, filePath, fileName;

        //构造考点树时存放的堆栈信息
        List<TreeNode> stack;
        //在CheckListBox里面显示的属性信息
        List<DisplayObject> displayInfo = new List<DisplayObject>();
        TreeNode tmpNode;
        TreeNode Root;

        Microsoft.Office.Core.MsoTriState False = Microsoft.Office.Core.MsoTriState.msoFalse;
        Microsoft.Office.Core.MsoTriState True = Microsoft.Office.Core.MsoTriState.msoTrue;

        #region 单位转换
        double ptcm(double p)    //把程序得出的小数转成厘米
        {
            double c = p / SCALE_CM;
            return Math.Round(c, 2);
        }

        double ptch(double p)   //把程序得出的小数转成字符长度
        {
            double c = p / SCALE_CHAR;
            return Math.Round(c, 2);
        }
        #endregion

        public testWord()
        {
            InitializeComponent();
        }

        #region Application Method
        //装载相关文件，传入参数：word标答地址、xml存放地址
        public void LoadWord(string word_path, string xml_path)
        {
            filePath = word_path;
            xmlPath = xml_path;
            helper = new TestWordHelper(xmlPath);
            openDocument(filePath);
            generateTree();
        }

        //打开Word文档
        private void openDocument(string filePath)
        {
            fileName = filePath.Substring(filePath.LastIndexOf('\\') + 1);
            word = new Word.Application();
            Object file_path = filePath;
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
            doc = word.Documents.Open(ref file_path, ref confirmConversions,
                ref readOnly, ref addToRecentFiles, ref passwordDocument,
                ref passwordTemplate, ref revert, ref writePasswordDocument,
                ref writePasswordTemplate, ref format, ref encoding, ref visible,
                ref openConflictDocument, ref openAndRepair, ref documentDirection,
                ref noEncodingDialog);
            word.Visible = true;
        }

        //关闭Word文档
        public void CloseDocument()
        {
            try
            {
                Object saveChanges = Word.WdSaveOptions.wdDoNotSaveChanges;
                Object originalFormat = Type.Missing;
                Object routeDocument = Type.Missing;

                doc.Close(ref saveChanges,
                  ref originalFormat, ref routeDocument);
                doc = null;

                word.Quit(ref saveChanges,
                    ref originalFormat, ref routeDocument);
                word = null;

            }
            catch { }
            GC.Collect();
        }
        #endregion

        private void testWordView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node == Root) return;
            ItemObject_Word itm = e.Node.Tag as ItemObject_Word;
            listProperty(itm);
            showSomething(itm);
        }

        //构造考点树
        void generateTree()
        {
            #region CreateTree
            stack = new List<TreeNode>(500);
            Root = new TreeNode();
            Root.Tag = new ItemObject_Word(fileName, doc, WordType.Null);
            Root.Text = (Root.Tag as ItemObject_Word).name;
            Push(Root);
            #region Paragraph Layer
            tmpNode = AddNode(new ItemObject_Word
                ("段落", null, WordType.Null));
            Push(tmpNode);
            int paraCount = 0;
            foreach (Word.Paragraph p in doc.Paragraphs)
            {
                tmpNode = AddNode(new ItemObject_Word
                    ("段落 " + (++paraCount).ToString(), p, WordType.Paragraph));
                Push(tmpNode);
                AddNode(new ItemObject_Word("对齐与缩进", p, WordType.Indent));
                AddNode(new ItemObject_Word("文字属性", p.Range, WordType.Font));
                AddNode(new ItemObject_Word("首字下沉", p.DropCap, WordType.DropCap));
                AddNode(new ItemObject_Word("分栏", p.Range.PageSetup.TextColumns, WordType.TextColumns));

                Pop();
            }
            Pop();
            #endregion
            #region Table Layer
            tmpNode = AddNode(new ItemObject_Word
                ("表格", null, WordType.Null));
            Push(tmpNode);
            int tableCount = 0;
            foreach (Word.Table t in doc.Tables)
            {
                tmpNode = AddNode(new ItemObject_Word
                    ("表格 " + (++tableCount).ToString(), t, WordType.Table));
                Push(tmpNode);
                #region Table Row Layer Unused
                //tmpNode = AddNode(new ItemObject
                //    ("行属性", null, WordType.Null));
                //Push(tmpNode);
                //#region Row Detail
                //for (int rowCount = 1; rowCount <= t.Rows.Count; rowCount++)
                //{
                //    tmpNode = AddNode(new ItemObject
                //        ("Row " + (++rowCount).ToString(), row, WordType.Row));
                //}
                //#endregion
                //Pop();
                #endregion
                //#region Cells Layer
                //tmpNode = AddNode(new ItemObject
                //    ("单元格属性", null, WordType.Null));
                //Push(tmpNode);
                #region Cells Detail
                for (int row = 1; row <= t.Rows.Count; row++)
                    for (int col = 1; col <= t.Columns.Count; col++)
                        try
                        {
                            tmpNode = AddNode(new ItemObject_Word
                                ("Cell (" + row + ", " + col + ")", t.Cell(row, col), WordType.Cell));
                        }
                        catch { }
                #endregion
                //Pop();
                //#endregion
                Pop();
            }
            Pop();
            #endregion
            #region Textbox Layer
            tmpNode = AddNode(new ItemObject_Word
                ("文本框", null, WordType.Null));
            Push(tmpNode);
            int tbCount = 0;
            int x = doc.Shapes.Count;
            foreach (Word.Shape sp in doc.Shapes)
                if (sp.Type == Microsoft.Office.Core.MsoShapeType.msoTextBox)
                    tmpNode = AddNode(new ItemObject_Word
                        ("文本框" + (++tbCount).ToString(), sp, WordType.Textbox));
            Pop();
            #endregion
            #region PageSetup Layer
            tmpNode = AddNode(new ItemObject_Word
                ("页面设置", doc.PageSetup, WordType.PageSetup));
            #endregion
            Pop();
            #endregion
            #region ShowTree
            testWordView.BeginUpdate();
            testWordView.Nodes.Clear();
            testWordView.Nodes.Add(Root);          //把树放在TreeView中
            testWordView.EndUpdate();
            //testPointView.ExpandAll();              //展开整棵树
            testWordView.SelectedNode = Root;      //选中根节点
            #endregion
        }

        //列出可以成为考点的属性
        void listProperty(ItemObject_Word obj)
        {
            checkedListBox1.Items.Clear();
            displayInfo.Clear();
            switch (obj.type)
            {
                case WordType.Indent:
                    #region 缩进
                    Word.Paragraph p = (Word.Paragraph)obj.o;
                    displayInfo.Add(new DisplayObject("对齐方式", "Alignment", p.Alignment));
                    displayInfo.Add(new DisplayObject("首行/悬挂缩进", "CharacterUnitFirstLineIndent", p.CharacterUnitFirstLineIndent));
                    displayInfo.Add(new DisplayObject("左缩进", "CharacterUnitLeftIndent", p.CharacterUnitLeftIndent));
                    displayInfo.Add(new DisplayObject("右缩进", "CharacterUnitRightIndent", p.CharacterUnitRightIndent));
                    displayInfo.Add(new DisplayObject("段前间距", "LineUnitBefore", p.LineUnitBefore));
                    displayInfo.Add(new DisplayObject("段后间距", "LineUnitAfter", p.LineUnitAfter));
                    displayInfo.Add(new DisplayObject("行距规则", "LineSpacingRule", p.LineSpacingRule));
                    displayInfo.Add(new DisplayObject("行距设置值", "LineSpacing", p.LineSpacing));
                    #endregion
                    break;
                case WordType.Font:
                    #region 字体
                    Word.Range range = (Word.Range)obj.o;
                    displayInfo.Add(new DisplayObject("文字", "Text", range.Text));
                    displayInfo.Add(new DisplayObject("字号", "FontSize", range.Font.Size));
                    displayInfo.Add(new DisplayObject("字体", "FontName", range.Font.Name));
                    displayInfo.Add(new DisplayObject("粗体", "Bold", range.Font.Bold));
                    displayInfo.Add(new DisplayObject("斜体", "Italic", range.Font.Italic));
                    displayInfo.Add(new DisplayObject("下划线", "Underline", range.Font.Underline));
                    displayInfo.Add(new DisplayObject("下划线颜色", "UnderlineColor", range.Font.UnderlineColor));
                    displayInfo.Add(new DisplayObject("文字颜色", "ForeColor", range.Font.Color));
                    displayInfo.Add(new DisplayObject("突出显示颜色", "HighLightColor", range.HighlightColorIndex));
                    displayInfo.Add(new DisplayObject("上标", "Superscript", range.Font.Superscript));
                    displayInfo.Add(new DisplayObject("下标", "Subscript", range.Font.Subscript));
                    displayInfo.Add(new DisplayObject("字符间距值", "Spacing", range.Font.Spacing));
                    displayInfo.Add(new DisplayObject("动态效果", "Animation", range.Font.Animation));
                    displayInfo.Add(new DisplayObject("底纹颜色", "BackgroundPatternColor", range.Shading.BackgroundPatternColor));
                    #endregion
                    break;
                case WordType.DropCap:
                    #region 首字下沉
                    Word.DropCap dc = (Word.DropCap)obj.o;
                    displayInfo.Add(new DisplayObject("首字下沉位置", "Position", dc.Position));
                    displayInfo.Add(new DisplayObject("首字下沉字体", "DcFontName", dc.FontName));
                    displayInfo.Add(new DisplayObject("首字下沉行数", "LinesToDrop", dc.LinesToDrop));
                    displayInfo.Add(new DisplayObject("与正文距离", "DistanceFromText", dc.DistanceFromText));
                    #endregion
                    break;
                case WordType.TextColumns:
                    #region  分栏与栏宽
                    Word.TextColumns tc = (Word.TextColumns)obj.o;
                    displayInfo.Add(new DisplayObject("分栏数", "TextColumnsCount", tc.Count));
                    displayInfo.Add(new DisplayObject("栏宽", "TextColumnsWidth", tc.Width));
                    //栏宽不为99999999 表示栏宽相等  否则表示栏宽不等
                    displayInfo.Add(new DisplayObject("栏间间隔", "TextColumnsSpacing", tc.Spacing));
                    displayInfo.Add(new DisplayObject("是否有分隔符", "TextColumnsLineBetween", tc.LineBetween));
                    //-1表示有 0表示没有
                    #endregion
                    break;
                case WordType.Textbox:
                    #region 文本框
                    Word.TextFrame tf = ((Word.Shape)obj.o).TextFrame;
                    displayInfo.Add(new DisplayObject("文字", "Text", tf.TextRange.Text));
                    displayInfo.Add(new DisplayObject("方向", "Orientation", tf.Orientation));
                    displayInfo.Add(new DisplayObject("字体", "FontName", tf.TextRange.Font.Name));
                    displayInfo.Add(new DisplayObject("字号", "FontSize", tf.TextRange.Font.Size));
                    displayInfo.Add(new DisplayObject("文字颜色", "ForeColor", tf.TextRange.Font.Color));
                    displayInfo.Add(new DisplayObject("突出显示颜色", "HighLightColor", tf.TextRange.HighlightColorIndex));
                    displayInfo.Add(new DisplayObject("字符间距值", "Spacing", tf.TextRange.Font.Spacing));
                    displayInfo.Add(new DisplayObject("对齐方式", "Alignment", tf.TextRange.ParagraphFormat.Alignment));
                    //Horizontal, Vertical, VerticalFarEast
                    #endregion
                    break;
                case WordType.Table:
                    #region 表格
                    Word.Table t = (Word.Table)obj.o;
                    displayInfo.Add(new DisplayObject("行数", "Rows", t.Rows.Count));
                    displayInfo.Add(new DisplayObject("列数", "Columns", t.Columns.Count));
                    #endregion
                    break;
                case WordType.Cell:
                    #region 单元格
                    Word.Cell cell = (Word.Cell)obj.o;
                    displayInfo.Add(new DisplayObject("文字", "Text", cell.Range.Text));
                    displayInfo.Add(new DisplayObject("高度", "Height", cell.Height));
                    displayInfo.Add(new DisplayObject("宽度", "Width", cell.Width));
                    //displayInfo.Add(new DisplayObject("行索引", "RowIndex", cell.RowIndex));
                    //displayInfo.Add(new DisplayObject("列索引", "ColumnIndex", cell.ColumnIndex));
                    #endregion
                    break;
                case WordType.PageSetup:
                    #region 页面设置
                    Word.PageSetup ps = (Word.PageSetup)obj.o;
                    displayInfo.Add(new DisplayObject("页面上边距", "TopMargin", ps.TopMargin));
                    displayInfo.Add(new DisplayObject("页面下边距", "BottomMargin", ps.BottomMargin));
                    displayInfo.Add(new DisplayObject("页面左边距", "LeftMargin", ps.LeftMargin));
                    displayInfo.Add(new DisplayObject("页面右边距", "RightMargin", ps.RightMargin));
                    displayInfo.Add(new DisplayObject("页眉距边界", "HeaderDistance", ps.HeaderDistance));
                    displayInfo.Add(new DisplayObject("页脚距边界", "FooterDistance", ps.FooterDistance));
                    displayInfo.Add(new DisplayObject("页面方向", "Orientation", ps.Orientation));
                    //页面方向  Landscape为横向 Protrait为纵向
                    displayInfo.Add(new DisplayObject("装订线位置", "GutterPos", ps.GutterPos));
                    //GutterPosLeft为左  GutterPosTop为上
                    #endregion
                    break;
                default:
                    break;
            }
            foreach (DisplayObject d in displayInfo)
                checkedListBox1.Items.Add(d.ToString());
        }

        //在WORD中显示当前的item
        void showSomething(ItemObject_Word obj)
        {
            switch (obj.type)
            {
                case WordType.Paragraph:
                    (obj.o as Word.Paragraph).Range.Select();
                    break;
                case WordType.Table:
                    (obj.o as Word.Table).Select();
                    break;
                case WordType.Cell:
                    (obj.o as Word.Cell).Select();
                    break;
                case WordType.Textbox:
                    (obj.o as Word.Shape).TextFrame.TextRange.Select();
                    break;
            }
        }

        #region 树形操作
        void Push(TreeNode item)
        {
            stack.Add(item);
        }

        void Pop()
        {
            stack.RemoveAt(stack.Count - 1);
        }

        TreeNode TopElement()
        {
            return stack[stack.Count - 1];
        }

        TreeNode AddNode(ItemObject_Word itm)
        {
            TreeNode tr = new TreeNode();
            tr.Tag = itm;
            tr.Text = itm.name;
            TopElement().Nodes.Add(tr);
            return tr;
        }

        /// <summary>
        /// 找到这个节点是父节点的第几个孩子
        /// </summary>
        /// <param name="tr">节点信息</param>
        /// <returns>孩子编号，从0开始编号</returns>
        int FindNodeIndex(TreeNode tr)
        {
            if (tr.Parent == null) return -1;
            TreeNode tmpNode = tr.Parent;
            for (int i = 0; i < tmpNode.Nodes.Count; i++)
                if (tmpNode.Nodes[i].Index == tr.Index)
                    return i;
            return -1;
        }
        #endregion

        private void btnOK_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = testWordView.SelectedNode;
            TreeNode tmpNode;
            ItemObject_Word tmpObj;
            List<TreeNode> nodeStack;       //存放路径节点的栈
            List<OfficeElement> rootList;   //存放路径考点定位信息的栈
            int idx;

            if (selectedNode.Parent == null)
                return;
            if ((selectedNode.Tag as ItemObject_Word).type == WordType.Null)
                return;

            #region Create Tree Structure
            rootList = new List<OfficeElement>();
            nodeStack = new List<TreeNode>(10);
            nodeStack.Add(selectedNode);
            tmpNode = selectedNode;
            while ((tmpNode.Tag as ItemObject_Word).type != WordType.Null)       //获取路径上的节点
            {
                tmpNode = tmpNode.Parent;
                nodeStack.Add(tmpNode);
            }
            while (nodeStack.Count > 0)                             //每个节点对类型进行分析
            {
                tmpNode = nodeStack[nodeStack.Count - 1];
                tmpObj = tmpNode.Tag as ItemObject_Word;
                nodeStack.RemoveAt(nodeStack.Count - 1);
                idx = FindNodeIndex(tmpNode);
                switch (tmpObj.type)
                { 
                    case WordType.Paragraph:
                        helper.addParagraph(idx + 1);
                        break;
                    case WordType.Font:
                        helper.addFont();
                        break;
                    case WordType.Indent:
                        helper.addIndent();
                        break;
                    case WordType.DropCap:
                        helper.addDropcap();
                        break;
                    case WordType.TextColumns:
                        helper.addTextColumns();
                        break;
                    case WordType.Table:
                        helper.addTable(idx + 1);
                        break;
                    case WordType.Cell:
                        string str = tmpObj.name;
                        int idx1 = str.IndexOf('('), idx2 = str.IndexOf(',');
                        int idx3 = str.LastIndexOf(' '), idx4 = str.IndexOf(')');
                        string use = str.Substring(idx1 + 1, idx2 - idx1 - 1) + "," 
                                + str.Substring(idx3 + 1, idx4 - idx3 - 1);
                        helper.addCell(use);
                        break;
                    case WordType.PageSetup:
                        helper.addPageSetup();
                        break;
                    case WordType.Textbox:
                        helper.addTextbox(idx + 1);
                        break;
                }
            }
            rootList.AddRange(helper.Path);
            helper.ClearPath();
            #endregion
            #region Add Leaf Info
            foreach (int checkedIdx in checkedListBox1.CheckedIndices)
            { 
                helper.Path.AddRange(rootList);
                string str = displayInfo[checkedIdx].useText;           //最终考点名称
                helper.AddFinalNode(str);
                helper.WriteToXml();
            }
            #endregion
        }

        private void btnRet_Click(object sender, EventArgs e)
        {
            CloseDocument();
            Application.Exit();
        }
    }

    public class TestWordHelper
    {
        OfficeXML oxml;

        public List<OfficeElement> Path
        {
            get { return oxml.Path; }
            set { oxml.Path = value; }
        }

        public TestWordHelper(string xmlPath)
        {
            oxml = new OfficeXML(xmlPath);
        }

        public void ClearPath()
        {
            oxml.Path.Clear();
        }

        public void WriteToXml()
        {
            oxml.addPathtoXML();
        }

        /// <summary>
        /// 加入最终考点信息，默认分数为1分
        /// </summary>
        /// <param name="name">考点名称</param>
        public void AddFinalNode(string name)
        {
            oxml.Path.Add(new OfficeElement(name, "1"));
        }

        /// <summary>
        /// 加入最终考点信息
        /// </summary>
        /// <param name="name">考点名称</param>
        /// <param name="pts">考点分数</param>
        public void AddFinalNode(string name, int pts)
        {
            oxml.Path.Add(new OfficeElement(name, pts.ToString()));
        }

        #region 添加节点
        public void addParagraph(int paraIdx)
        {
            oxml.Path.Add(new OfficeElement("Documents", "0"));
            oxml.Path.Add(new OfficeElement(WordType.Paragraph.ToString(), paraIdx.ToString()));
        }

        public void addTable(int tabIdx)
        {
            oxml.Path.Add(new OfficeElement("Documents", "0"));
            oxml.Path.Add(new OfficeElement(WordType.Table.ToString(), tabIdx.ToString()));
        }

        public void addCell(string cellIdx)
        {
            oxml.Path.Add(new OfficeElement(WordType.Cell.ToString(), cellIdx));
        }

        public void addPageSetup()
        {
            oxml.Path.Add(new OfficeElement("Documents", "0"));
            oxml.Path.Add(new OfficeElement(WordType.PageSetup.ToString(), "0"));
        }

        public void addTextbox(int tbIdx)
        {
            oxml.Path.Add(new OfficeElement("Documents", "0"));
            oxml.Path.Add(new OfficeElement(WordType.Textbox.ToString(), tbIdx.ToString()));
        }

        public void addFont()
        {
            oxml.Path.Add(new OfficeElement(WordType.Font.ToString(), "0"));
        }

        public void addIndent()
        {
            oxml.Path.Add(new OfficeElement(WordType.Indent.ToString(), "0"));
        }

        public void addDropcap()
        {
            oxml.Path.Add(new OfficeElement(WordType.DropCap.ToString(), "0"));
        }

        public void addTextColumns()
        {
            oxml.Path.Add(new OfficeElement(WordType.TextColumns.ToString(), "0"));
        }
        #endregion
    }

    public class ItemObject_Word
    {
        public object o;
        public WordType type;
        public string name;

        public ItemObject_Word(string name, object o, WordType type)
        {
            this.name = name;
            this.o = o;
            this.type = type;
        }

        public override string ToString()
        {
            return name;
        }
    }

    public enum WordType
    {
        Paragraph,          //段落
        Table,              //表格
        Row,                //表格行
        Cell,               //表格单元格
        Range,              //文字区域
        Font,               //字体标签
        DropCap,            //首字下沉
        Indent,             //缩进标签
        Null,               //指示标签，无意义
        TextColumns,        //分栏标签
        PageSetup,          //页面设置
        Textbox             //文本框
    }

}
