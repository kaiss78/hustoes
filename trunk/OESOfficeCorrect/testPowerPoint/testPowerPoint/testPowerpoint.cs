using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;
using OESXML;

namespace testPowerPoint
{
    public partial class testPowerpoint : UserControl
    {

        PowerPoint.Application powerpoint;
        PowerPoint.Presentation ppt;
        PptTestPointHelper helper;
        string xmlPath;
        string filePath;
        string fileName;

        List<TreeNode> stack;
        TreeNode tmpNode;
        TreeNode Root;

        Microsoft.Office.Core.MsoTriState False = Microsoft.Office.Core.MsoTriState.msoFalse;
        Microsoft.Office.Core.MsoTriState True = Microsoft.Office.Core.MsoTriState.msoTrue;

        public testPowerpoint()
        {
            InitializeComponent();
        }

        public void LoadPowerpoint(string ppt_path, string xml_path)
        {
            filePath = ppt_path;
            xmlPath = xml_path;
            helper = new PptTestPointHelper(xmlPath);
            openFile(filePath);
            generateTree();
        }

        private void testPointView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode tmpNode;
            ItemObject tmpObj;
            List<ItemObject> stack;
            if (e.Node == Root) return;                     //根节点返回
            ItemObject itm = e.Node.Tag as ItemObject;
            listProperty(itm);
            #region 在PPT中显示当前的item
            stack = new List<ItemObject>(10);
            tmpNode = e.Node;
            stack.Add(tmpNode.Tag as ItemObject);
            while ((tmpNode.Tag as ItemObject).type != PptType.Slide)
            {
                tmpNode = tmpNode.Parent;
                stack.Add(tmpNode.Tag as ItemObject);
            }
            while (stack.Count > 0)
            {
                try
                {
                    tmpObj = stack[stack.Count - 1];
                    showSomething(tmpObj);
                    stack.RemoveAt(stack.Count - 1);
                }
                catch
                {
                    throw;
                }
            }
            #endregion
        }

        /// <summary>
        /// 在PPT中显示Item的方法
        /// </summary>
        /// <param name="itm">考点信息</param>
        private void showSomething(ItemObject itm)
        {
            switch (itm.type)
            {
                case PptType.Slide:
                    (itm.o as PowerPoint.Slide).Select();
                    break;
                case PptType.TextContainer:
                case PptType.EmbeddedObject:
                case PptType.WordArt:
                case PptType.Picture:
                    (itm.o as PowerPoint.Shape).Select(True);
                    break;
                case PptType.Run:
                    (itm.o as PowerPoint.TextRange).Select();
                    break;
                case PptType.Effect:
                    PowerPoint.Effect ef = itm.o as PowerPoint.Effect;
                    (ef.Shape as PowerPoint.Shape).Select(True);
                    break;
            }
        }

        //打开文件
        void openFile(string file)
        {
            fileName = file.Substring(file.LastIndexOf('\\') + 1);
            powerpoint = new PowerPoint.ApplicationClass();
            powerpoint.Visible = True;                              //一定要放在Open前！
            ppt = powerpoint.Presentations.Open(file, False, True, True);
        }

        //注销PPT资源
        public void ClosePPT()
        {
            try
            {
                ppt.Close();
                ppt = null;
                //if (powerpoint.Presentations.Count == 0)
                //{
                powerpoint.Quit();
                powerpoint = null;
                //}
            }
            catch (Exception ex){ }
            GC.Collect();
        }

        //构造考点树
        void generateTree()
        {
            #region CreateTree
            stack = new List<TreeNode>(500);
            Root = new TreeNode();
            Root.Tag = new ItemObject(fileName, ppt, PptType.Null);   //添加根节点(仅用于分级显示)
            Root.Text = (Root.Tag as ItemObject).name;
            Push(Root);
            #region Slides Layer
            foreach (PowerPoint.Slide s in ppt.Slides)
            {
                tmpNode = AddNode(new ItemObject(s.Name, s, PptType.Slide));     //添加幻灯片节点
                Push(tmpNode);
                #region Slide's attribute Layer
                AddNode(new ItemObject("过渡动画", s.SlideShowTransition, PptType.Transition));      //过渡动画节点
                AddNode(new ItemObject("幻灯片背景", s.Background, PptType.Background));        //背景节点
                AddNode(new ItemObject("设计模板", s.Design, PptType.Design));                    //设计模板节点
                AddNode(new ItemObject(s.Master.Name, s.Master, PptType.Master));                    //Master节点

                if (s.TimeLine.MainSequence.Count > 0)
                {
                    tmpNode = AddNode(new ItemObject("动画效果", null, PptType.Null));                   //动画节点(仅用于分级显示)
                    Push(tmpNode);
                    #region Animation Layer
                    foreach (PowerPoint.Effect effect in s.TimeLine.MainSequence)
                    {
                        //MessageBox.Show(effect.EffectType.ToString());
                        //MessageBox.Show(effect.Shape.Name);
                        AddNode(new ItemObject(effect.EffectType + "动画", effect, PptType.Effect));     //具体各种动画的节点
                    }
                    #endregion
                    Pop();
                }

                if (s.Shapes.Count > 0)
                {
                    tmpNode = AddNode(new ItemObject("文字及图形", null, PptType.Null));                 //文字及图形区域节点(仅用于分级显示)
                    Push(tmpNode);
                    #region Shape Layer
                    foreach (PowerPoint.Shape shape in s.Shapes)
                    {
                        PptType tp;
                        #region determine shape's category
                        switch (shape.Type)
                        {
                            case Microsoft.Office.Core.MsoShapeType.msoPicture:
                                tp = PptType.Picture;
                                break;
                            case Microsoft.Office.Core.MsoShapeType.msoPlaceholder:
                                tp = PptType.TextContainer;
                                break;
                            case Microsoft.Office.Core.MsoShapeType.msoTextEffect:
                                tp = PptType.WordArt;
                                break;
                            case Microsoft.Office.Core.MsoShapeType.msoEmbeddedOLEObject:
                                tp = PptType.EmbeddedObject;
                                break;
                            default:
                                tp = PptType.Null;
                                break;
                        }
                        #endregion
                        tmpNode = AddNode(new ItemObject(shape.Name, shape, tp));                        //具体区域的节点
                        Push(tmpNode);
                        #region Shape's attribute Layer
                        #region comments
                        //shape.Select(Microsoft.Office.Core.MsoTriState.msoFalse);
                        //if(shape.AnimationSettings.Animate==True)
                        //    listBox1.Items.Add(new ItemObject(shape.Name + "动画", shape.AnimationSettings,PptType.Action, 2));
                        #endregion
                        if (shape.HasTextFrame == True)
                        {
                            #region comments
                            //MessageBox.Show(shape.TextFrame.TextRange.Count.ToString());
                            //foreach (PowerPoint.TextRange textrange in shape.TextFrame.TextRange.Paragraphs(0, 100))
                            //{
                            //    MessageBox.Show(textrange.Text);

                            //}
                            #endregion
                            foreach (PowerPoint.TextRange textrange in shape.TextFrame.TextRange.Runs(0, 100))
                            {
                                AddNode(new ItemObject(textrange.Text, textrange, PptType.Run));         //文字Run节点
                                //MessageBox.Show(((PowerPoint.Shape)textrange.Parent).AnimationSettings.Animate.ToString());
                            }
                            #region comments
                            //foreach (PowerPoint.TextRange textrange in shape.TextFrame.TextRange.Paragraphs(0, 100))
                            //{
                            //    MessageBox.Show(textrange.Text);
                            //}
                            //foreach (PowerPoint.TextRange textrange in shape.TextFrame.TextRange.Sentences(0, 100))
                            //{
                            //    MessageBox.Show(textrange.Text);
                            //}
                            //foreach (PowerPoint.TextRange textrange in shape.TextFrame.TextRange.Words(0, 100))
                            //{
                            //    MessageBox.Show(textrange.Text);
                            //}
                            //foreach (PowerPoint.TextRange textrange in shape.TextFrame.TextRange.Characters(0, 100))
                            //{
                            //    MessageBox.Show(textrange.Text);
                            //}
                            #endregion
                        }
                        if (shape.HasDiagram == True)
                        {
                        }
                        if (shape.HasTable == True)
                        {
                        }
                        #endregion
                        Pop();
                    }
                    #endregion
                    Pop();
                }

                #endregion
                Pop();
            }
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
        void listProperty(ItemObject io)
        {
            checkedListBox1.Items.Clear();
            switch (io.type)
            {
                case PptType.Slide:
                    {
                        #region 幻灯片属性
                        PowerPoint.Slide slide = (PowerPoint.Slide)io.o;
                        checkedListBox1.Items.Add("Name:" + slide.Name);
                        checkedListBox1.Items.Add("SlideID:" + slide.SlideID);
                        checkedListBox1.Items.Add("SlideIndex:" + slide.SlideIndex);
                        checkedListBox1.Items.Add("SlideNumber:" + slide.SlideNumber);
                        checkedListBox1.Items.Add("Layout:" + slide.Layout.ToString());
                        #endregion
                        break;
                    }
                case PptType.EmbeddedObject:
                case PptType.TextContainer:
                    {
                        PowerPoint.Shape shape = (PowerPoint.Shape)io.o;
                        checkedListBox1.Items.Add("Name:" + shape.Name);
                        checkedListBox1.Items.Add("Type:" + shape.Type);
                        checkedListBox1.Items.Add("Top:" + shape.Top.ToString());
                        checkedListBox1.Items.Add("Left:" + shape.Left.ToString());
                        //checkedListBox1.Items.Add("Line:" + shape.Line.ToString());
                        break;
                    }
                case PptType.WordArt:                   //艺术字的一系列属性
                    {
                        #region 艺术字属性
                        PowerPoint.Shape shape = (PowerPoint.Shape)io.o;
                        checkedListBox1.Items.Add("Name:" + shape.Name);
                        checkedListBox1.Items.Add("Type:" + shape.Type);
                        checkedListBox1.Items.Add("Height:" + shape.Height.ToString());
                        checkedListBox1.Items.Add("Width:" + shape.Width.ToString());
                        checkedListBox1.Items.Add("Top:" + shape.Top.ToString());
                        checkedListBox1.Items.Add("Left:" + shape.Left.ToString());
                        checkedListBox1.Items.Add("Text:" + shape.TextEffect.Text);
                        checkedListBox1.Items.Add("FontBold:" + shape.TextEffect.FontBold);
                        checkedListBox1.Items.Add("FontItalic:" + shape.TextEffect.FontItalic);
                        checkedListBox1.Items.Add("FontName:" + shape.TextEffect.FontName);
                        checkedListBox1.Items.Add("FontSize:" + shape.TextEffect.FontSize.ToString());
                        checkedListBox1.Items.Add("Alignment:" + shape.TextEffect.Alignment.ToString());
                        checkedListBox1.Items.Add("PresetTextEffect(格式):" + shape.TextEffect.PresetTextEffect.ToString());
                        checkedListBox1.Items.Add("PresetShape(形状):" + shape.TextEffect.PresetShape.ToString());
                        checkedListBox1.Items.Add("RotatedChars(文字是否垂直排列):" + shape.TextEffect.RotatedChars.ToString());
                        checkedListBox1.Items.Add("Tracking(字符间距):" + shape.TextEffect.Tracking.ToString());
                        //checkedListBox1.Items.Add("是否自动缩紧字符对:" + shape.TextEffect.KernedPairs.ToString());
                        #endregion
                        break;
                    }
                case PptType.Background:
                    {
                        #region 背景属性
                        PowerPoint.ShapeRange background = (PowerPoint.ShapeRange)io.o;
                        checkedListBox1.Items.Add("Fill(填充模式):" + background.Fill.Type);
                        checkedListBox1.Items.Add("GradientType(背景颜色预设填充):" + background.Fill.PresetGradientType);
                        checkedListBox1.Items.Add("GradientDegree(背景颜色预设填充方向):" + background.Fill.GradientStyle);
                        #endregion
                        break;
                    }
                case PptType.Design:
                    {
                        PowerPoint.Design design = ((PowerPoint.Design)io.o);
                        //checkedListBox1.Items.Add("Name:" + design.Name);
                        //checkedListBox1.Items.Add("HasTitleMaster:" + design.HasTitleMaster.ToString());
                        break;
                    }
                case PptType.Master:
                    {
                        break;
                    }
                case PptType.Run:
                    {
                        #region 文字块属性
                        PowerPoint.TextRange textrange = (PowerPoint.TextRange)io.o;
                        checkedListBox1.Items.Add("Text:" + textrange.Text);
                        checkedListBox1.Items.Add("Bold:" + textrange.Font.Bold);
                        checkedListBox1.Items.Add("Italic:" + textrange.Font.Italic);
                        checkedListBox1.Items.Add("Underline:" + textrange.Font.Underline);
                        checkedListBox1.Items.Add("FontName:" + textrange.Font.Name);
                        checkedListBox1.Items.Add("FontSize:" + textrange.Font.Size.ToString());
                        checkedListBox1.Items.Add("ForeColor:" + textrange.Font.Color.RGB);
                        checkedListBox1.Items.Add("Shadow(文字阴影):" + textrange.Font.Shadow);
                        checkedListBox1.Items.Add("Superscript(上标):" + textrange.Font.Superscript);
                        checkedListBox1.Items.Add("Subscript(下标):" + textrange.Font.Subscript);
                        #endregion
                        break;
                    }
                case PptType.Action:
                    {
                        #region Action属性
                        try
                        {
                            PowerPoint.AnimationSettings action = (PowerPoint.AnimationSettings)io.o;
                            checkedListBox1.Items.Add("AdvanceMode:" + action.AdvanceMode);
                            checkedListBox1.Items.Add("AdvanceTime:" + action.AdvanceTime);
                            checkedListBox1.Items.Add("AfterEffect:" + action.AfterEffect);
                            checkedListBox1.Items.Add("Animate:" + action.Animate);
                            checkedListBox1.Items.Add("AnimateBackground:" + action.AnimateBackground);
                            checkedListBox1.Items.Add("AnimateTextInReverse:" + action.AnimateTextInReverse);
                            checkedListBox1.Items.Add("AnimationOrder:" + action.AnimationOrder);
                            checkedListBox1.Items.Add("ChartUnitEffect:" + action.ChartUnitEffect);
                            checkedListBox1.Items.Add("DimColor:" + action.DimColor.RGB);
                            checkedListBox1.Items.Add("EntryEffect:" + action.EntryEffect);
                            checkedListBox1.Items.Add("SoundEffect:" + action.SoundEffect);
                            checkedListBox1.Items.Add("TextLevelEffect:" + action.TextLevelEffect);
                            checkedListBox1.Items.Add("TextUnitEffect:" + action.TextUnitEffect);
                            //checkedListBox1.Items.Add("EntryEffect:" + action.PlaySettings.);

                        }
                        catch { }
                        #endregion
                        break;
                    }
                case PptType.Effect:
                    {
                        #region 动画属性
                        PowerPoint.Effect effect = (PowerPoint.Effect)io.o;
                        //checkedListBox1.Items.Add("AdvanceMode:" + effect.Behaviors);
                        //checkedListBox1.Items.Add("AdvanceMode:" + effect.EffectInformation);
                        //checkedListBox1.Items.Add("AdvanceMode:" + effect.EffectParameters);
                        checkedListBox1.Items.Add("DisplayName(动画名称):" + effect.DisplayName);
                        checkedListBox1.Items.Add("EffectType(动画类型):" + effect.EffectType);
                        checkedListBox1.Items.Add("Exit(是否为退出动画):" + effect.Exit);
                        checkedListBox1.Items.Add("Index(动画顺序):" + effect.Index);
                        checkedListBox1.Items.Add("ShapeName(矩形区域):" + effect.Shape.Name);
                        checkedListBox1.Items.Add("Duration(动画运行时间):" + effect.Timing.Duration);
                        try
                        {
                            checkedListBox1.Items.Add("Paragraph(段落):" + effect.Paragraph);
                            checkedListBox1.Items.Add("TextRangeStart(开始区域):" + effect.TextRangeStart);
                            checkedListBox1.Items.Add("TextRangeLength(区域长度):" + effect.TextRangeLength);
                        }
                        catch { }
                        #endregion
                        break;
                    }
                case PptType.Transition:                    //幻灯片切换的一系列属性
                    {
                        #region 幻灯片切换属性
                        PowerPoint.SlideShowTransition transition = (PowerPoint.SlideShowTransition)io.o;
                        checkedListBox1.Items.Add("AdvanceOnClick(是否点击触发):" + transition.AdvanceOnClick);
                        checkedListBox1.Items.Add("AdvanceOnTime(是否时间触发):" + transition.AdvanceOnTime);
                        checkedListBox1.Items.Add("AdvanceTime(时间提前):" + transition.AdvanceTime);
                        checkedListBox1.Items.Add("EntryEffect(效果):" + transition.EntryEffect);
                        checkedListBox1.Items.Add("Speed(速度):" + transition.Speed);
                        //checkedListBox1.Items.Add("声音:" + transition.SoundEffect.Name);
                        #endregion
                        break;
                    }
                case PptType.Picture:
                    {
                        #region 图片属性
                        PowerPoint.Shape shape = (PowerPoint.Shape)io.o;
                        PowerPoint.PictureFormat pf = shape.PictureFormat;
                        checkedListBox1.Items.Add("Name:" + shape.Name);
                        checkedListBox1.Items.Add("Type:" + shape.Type);
                        checkedListBox1.Items.Add("Height:" + shape.Height.ToString());
                        checkedListBox1.Items.Add("Width:" + shape.Width.ToString());
                        checkedListBox1.Items.Add("Top:" + shape.Top.ToString());
                        checkedListBox1.Items.Add("Left:" + shape.Left.ToString());
                        checkedListBox1.Items.Add("CropLeft(左裁剪距离):" + pf.CropLeft.ToString());
                        checkedListBox1.Items.Add("CropTop(上裁剪距离):" + pf.CropTop.ToString());
                        checkedListBox1.Items.Add("CropRight(右裁剪距离):" + pf.CropRight.ToString());
                        checkedListBox1.Items.Add("CropBottom(下裁剪距离):" + pf.CropBottom.ToString());
                        #endregion
                        break;
                    }
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

        string getInfoString(string str)
        {
            string res = "";
            int idx1 = str.IndexOf(':');
            int idx2 = str.IndexOf('(');
            if (idx2 == -1)
                res = str.Substring(0, idx1);
            else
            {
                int min = Math.Min(idx1, idx2);
                res = str.Substring(0, min);
            }
            return res;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = testPointView.SelectedNode;
            TreeNode tmpNode;
            ItemObject tmpObj;
            List<TreeNode> nodeStack;
            List<OfficeElement> rootList;
            int idx;

            if (selectedNode.Parent == null)
                return;
            if ((selectedNode.Tag as ItemObject).type == PptType.Null)
                return;

            #region Create Tree Structure
            rootList = new List<OfficeElement>();
            nodeStack = new List<TreeNode>(10);
            nodeStack.Add(selectedNode);
            tmpNode = selectedNode;
            while ((tmpNode.Tag as ItemObject).type != PptType.Slide)
            {
                tmpNode = tmpNode.Parent;
                nodeStack.Add(tmpNode);
            }
            while (nodeStack.Count > 0)
            {
                tmpNode = nodeStack[nodeStack.Count - 1];
                tmpObj = tmpNode.Tag as ItemObject;
                nodeStack.RemoveAt(nodeStack.Count - 1);
                idx = FindNodeIndex(tmpNode);
                switch (tmpObj.type)
                {
                    case PptType.Transition:
                        helper.addTransition();
                        break;
                    case PptType.Background:
                        helper.addBackground();
                        break;
                    case PptType.Slide:
                        helper.addSlide(idx + 1);
                        break;
                    case PptType.Picture:
                    case PptType.TextContainer:
                    case PptType.EmbeddedObject:
                    case PptType.WordArt:
                        helper.addShape(tmpObj.type.ToString(), idx + 1);
                        break;
                    case PptType.Run:
                        helper.addRun(idx);
                        break;
                    case PptType.Effect:
                        helper.addEffect(idx + 1);
                        break;
                }
            }
            rootList.AddRange(helper.Path);
            helper.ClearPath();
            #endregion
            #region Add Leaf Info
            for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
            {
                helper.Path.AddRange(rootList);
                string str = checkedListBox1.CheckedItems[i].ToString();
                helper.AddFinalNode(getInfoString(str));
                helper.WriteToXml();
            }
            #endregion
        }

        private void btnRet_Click(object sender, EventArgs e)
        {
            ClosePPT();
        }
    }

    public class PptTestPointHelper
    {
        OfficeXML oxml;

        public List<OfficeElement> Path
        {
            get { return oxml.Path; }
            set { oxml.Path = value; }
        }

        public PptTestPointHelper(string xmlPath)
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
        public void addSlide(int slideIdx)
        {
            oxml.Path.Add(new OfficeElement("Presentations", "0"));
            oxml.Path.Add(new OfficeElement(PptType.Slide.ToString(), slideIdx.ToString()));
        }

        public void addShape(string shapeName, int shapeIdx)
        {
            oxml.Path.Add(new OfficeElement(shapeName, shapeIdx.ToString()));
        }

        public void addTransition()
        {
            oxml.Path.Add(new OfficeElement(PptType.Transition.ToString(), "0"));
        }

        public void addBackground()
        {
            oxml.Path.Add(new OfficeElement(PptType.Background.ToString(), "0"));
        }

        public void addEffect(int effectIdx)
        {
            oxml.Path.Add(new OfficeElement(PptType.Effect.ToString(), effectIdx.ToString()));
        }

        public void addRun(int runIdx)
        {
            oxml.Path.Add(new OfficeElement(PptType.Run.ToString(), runIdx.ToString()));
        }
        #endregion
    }

    public class ItemObject
    {
        public object o;
        public PptType type;
        public string name;

        public ItemObject(string name, object o, PptType type)
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

    public enum PptType
    {
        Slide,              //幻灯片
        TextContainer,      //文字区域
        Background,         //幻灯片背景
        Design,             //?????????
        Master,             //???
        Run,                //文字块
        Action,             //???
        Effect,             //动画效果
        Transition,         //幻灯片切换
        WordArt,            //艺术字
        EmbeddedObject,     //嵌入式内容
        Picture,            //图片
        Null                //指示标签，无意义
    }
}
