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

namespace testWordApp
{
    public partial class testWord : UserControl
    {
        Word.Application word;
        Word.Document doc;

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

        private void testPointView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node == Root) return;
            ItemObject itm = e.Node.Tag as ItemObject;
            listProperty(itm);
            showSomething(itm);
        }

        //public void Test()
        //{
        //    doc.Paragraphs.Last.Range.Text = "abcdefdfdsfs";
        //}

        //构造考点树
        void generateTree()
        {
            #region CreateTree
            stack = new List<TreeNode>(500);
            Root = new TreeNode();
            Root.Tag = new ItemObject(fileName, doc, WordType.Null);
            Root.Text = (Root.Tag as ItemObject).name;
            Push(Root);
            #region Paragraph Layer
            tmpNode = AddNode(new ItemObject
                ("段落", null, WordType.Null));
            Push(tmpNode);
            int paraCount = 0;
            foreach (Word.Paragraph p in doc.Paragraphs)
            {
                if (p.Parent is Word.Table)
                    MessageBox.Show("fuck");
                tmpNode = AddNode(new ItemObject
                    ("段落 " + (++paraCount).ToString(), p, WordType.Paragraph));
                Push(tmpNode);
                Pop();
            }
            Pop();
            #endregion
            #region Table Layer
            tmpNode = AddNode(new ItemObject
                ("表格", null, WordType.Null));
            Push(tmpNode);
            int tableCount = 0;
            foreach (Word.Table t in doc.Tables)
            {
                tmpNode = AddNode(new ItemObject
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
                #region Cells Layer
                tmpNode = AddNode(new ItemObject
                    ("单元格属性", null, WordType.Null));
                Push(tmpNode);
                #region Cells Detail
                for (int row = 1; row <= t.Rows.Count; row++)
                    for (int col = 1; col <= t.Columns.Count; col++)
                        try
                        {
                            tmpNode = AddNode(new ItemObject
                                ("Cell (" + row + ", " + col + ")", t.Cell(row, col), WordType.Cell));
                        }
                        catch { }
                #endregion
                Pop();
                #endregion
                Pop();
            }
            Pop();
            #endregion
            Pop();
            #endregion
            #region ShowTree
            testPointView.BeginUpdate();
            testPointView.Nodes.Clear();
            testPointView.Nodes.Add(Root);          //把树放在TreeView中
            testPointView.EndUpdate();
            testPointView.ExpandAll();              //展开整棵树
            testPointView.SelectedNode = Root;      //选中根节点
            #endregion
        }

        //列出可以成为考点的属性
        void listProperty(ItemObject obj)
        {
            checkedListBox1.Items.Clear();
            displayInfo.Clear();
            switch (obj.type)
            {
                case WordType.Paragraph:
                    Word.Paragraph p = (Word.Paragraph)obj.o;
                    displayInfo.Add(new DisplayObject("文字", "Text", p.Range.Text));
                    displayInfo.Add(new DisplayObject("对齐方式", "Alignment", p.Alignment));
                    displayInfo.Add(new DisplayObject("首行/悬挂缩进", "CharacterUnitFirstLineIndent", p.CharacterUnitFirstLineIndent));
                    displayInfo.Add(new DisplayObject("左缩进", "CharacterUnitLeftIndent", p.CharacterUnitLeftIndent));
                    displayInfo.Add(new DisplayObject("右缩进", "CharacterUnitRightIndent", p.CharacterUnitRightIndent));
                    break;
                case WordType.Table:
                    Word.Table t = (Word.Table)obj.o;
                    displayInfo.Add(new DisplayObject("行数", "Rows", t.Rows.Count));
                    displayInfo.Add(new DisplayObject("列数", "Columns", t.Columns.Count));
                    break;
                case WordType.Cell:
                    Word.Cell cell = (Word.Cell)obj.o;
                    displayInfo.Add(new DisplayObject("文字", "Text", cell.Range.Text));
                    displayInfo.Add(new DisplayObject("高度", "Height", cell.Height));
                    displayInfo.Add(new DisplayObject("宽度", "Width", cell.Width));
                    //displayInfo.Add(new DisplayObject("行索引", "RowIndex", cell.RowIndex));
                    //displayInfo.Add(new DisplayObject("列索引", "ColumnIndex", cell.ColumnIndex));
                    break;
                default:
                    break;
            }
            foreach (DisplayObject d in displayInfo)
                checkedListBox1.Items.Add(d.ToString());
        }

        //在WORD中显示当前的item
        void showSomething(ItemObject obj)
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

        TreeNode AddNode(ItemObject itm)
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
    }

    public class ItemObject
    {
        public object o;
        public WordType type;
        public string name;

        public ItemObject(string name, object o, WordType type)
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

    public class DisplayObject
    {
        public string displayText;
        public string useText;
        public object value;

        public DisplayObject(string dt, string ut, object v)
        {
            displayText = dt;
            useText = ut;
            value = v;
        }

        public override string ToString()
        {
            return displayText + ":" + value.ToString();
        }
    }


    public enum WordType
    {
        Paragraph,          //段落
        Table,              //表格
        Row,                //表格行
        Cell,               //表格格子
        Null                //指示标签，无意义
    }

}
