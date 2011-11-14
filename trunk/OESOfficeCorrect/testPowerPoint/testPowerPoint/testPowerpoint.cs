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

        //构造考点树时存放的堆栈信息
        List<TreeNode> stack;
        //在CheckListBox里面显示的属性信息
        List<DisplayObject> displayInfo = new List<DisplayObject>();
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
                case PptType.Location:
                case PptType.Shape:
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
            #region 幻灯片部分
            int slideCnt = 0;
            foreach (PowerPoint.Slide s in ppt.Slides)
            {
                tmpNode = AddNode(new ItemObject("幻灯片 " + (++slideCnt).ToString(), s, PptType.Slide));     //添加幻灯片节点
                Push(tmpNode);
                #region 提取一张幻灯片的信息
                AddNode(new ItemObject("过渡动画", s.SlideShowTransition, PptType.Transition));         //过渡动画节点
                AddNode(new ItemObject("幻灯片背景", s.Background, PptType.Background));              //背景节点
                //AddNode(new ItemObject("设计模板", s.Design, PptType.Design));                           //设计模板节点
                //AddNode(new ItemObject(s.Master.Name, s.Master, PptType.Master));                       //Master节点
                #region 动画效果属性
                tmpNode = AddNode(new ItemObject("幻灯片动画效果", null, PptType.Effects));                   //动画节点(仅用于分级显示)
                Push(tmpNode);
                int effectCnt = 0;
                foreach (PowerPoint.Effect effect in s.TimeLine.MainSequence)
                {
                    AddNode(new ItemObject("动画 " + (++effectCnt).ToString(), effect, PptType.Effect)); //具体各种动画的节点
                }
                Pop();
                #endregion
                #region 文字及图形属性
                tmpNode = AddNode(new ItemObject("文字及图形对象", null, PptType.Shapes));                     //文字及图形区域节点(仅用于分级显示)
                Push(tmpNode);
                foreach (PowerPoint.Shape shape in s.Shapes)
                {
                    String sInfo = shape.Name.Substring(0, shape.Name.IndexOf(' '));
                    tmpNode = AddNode(new ItemObject(shape.Name, shape, PptType.Shape));            //具体区域的节点
                    Push(tmpNode);
                    tmpNode = AddNode(new ItemObject("类型、定位、大小信息", shape, PptType.Location));
                    #region 确定Shape的种类及各自属性
                    switch (shape.Type)
                    {
                        case Microsoft.Office.Core.MsoShapeType.msoPicture:             //图片
                            tmpNode = AddNode(new ItemObject("图片属性", shape, PptType.Picture));
                            break;
                        case Microsoft.Office.Core.MsoShapeType.msoPlaceholder:         //文字填充框
                        case Microsoft.Office.Core.MsoShapeType.msoTextBox:             //文本框
                            tmpNode = AddNode(new ItemObject("文字属性", shape, PptType.TextContainer));
                            Push(tmpNode);
                            int textCnt = 0;
                            foreach (PowerPoint.TextRange textrange in shape.TextFrame.TextRange.Runs(0, 100))
                            {
                                AddNode(new ItemObject("文字段 " + (++textCnt).ToString(), textrange, PptType.Run));         //文字Run节点
                            }
                            Pop();
                            break;
                        case Microsoft.Office.Core.MsoShapeType.msoAutoShape:           //自选图形
                            if (sInfo == "WordArt")
                                tmpNode = AddNode(new ItemObject("艺术字属性", shape, PptType.WordArt));
                            else
                            {
                                try 
                                {
                                    if (shape.ThreeD.Perspective == True)
                                        tmpNode = AddNode(new ItemObject("三维属性", shape, PptType.ThreeD)); 
                                }
                                catch { }
                            }
                            break;
                        case Microsoft.Office.Core.MsoShapeType.msoTextEffect:          //艺术字
                            tmpNode = AddNode(new ItemObject("艺术字属性", shape, PptType.WordArt));
                            break;
                    }
                    #endregion
                    if (shape.AnimationSettings.Animate == True)                                    //shape有动画
                        tmpNode = AddNode(new ItemObject("自定义动画", shape.AnimationSettings, PptType.Animation));
                    if (shape.ActionSettings.Count > 0)
                    {
                        tmpNode = AddNode(new ItemObject("动作设置", null, PptType.Actions));
                        Push(tmpNode);
                        tmpNode = AddNode(new ItemObject("单击鼠标", shape.ActionSettings[PowerPoint.PpMouseActivation.ppMouseClick], PptType.ClickAction));
                        tmpNode = AddNode(new ItemObject("鼠标划过", shape.ActionSettings[PowerPoint.PpMouseActivation.ppMouseOver], PptType.MoveAction));
                        Pop();
                    }
                    Pop();
                }
                Pop();
                #endregion
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
            //testPointView.ExpandAll();              //展开整棵树
            testPointView.SelectedNode = Root;      //选中根节点
            #endregion
        }

        //列出可以成为考点的属性
        void listProperty(ItemObject io)
        {
            checkedListBox1.Items.Clear();
            displayInfo.Clear();
            switch (io.type)
            {
                case PptType.Design:
                    PowerPoint.Design ds = (PowerPoint.Design)io.o;
                    displayInfo.Add(new DisplayObject("Name", "Name", ds.Name));
                    displayInfo.Add(new DisplayObject("HasTM", "HasTM", ds.HasTitleMaster));
                    displayInfo.Add(new DisplayObject("Index", "Index", ds.Index));
                    break;
                case PptType.Slide:
                    #region 幻灯片属性
                    PowerPoint.Slide slide = (PowerPoint.Slide)io.o;
                    displayInfo.Add(new DisplayObject("幻灯片名称", "SlideName", slide.Name));
                    displayInfo.Add(new DisplayObject("幻灯片编号", "SlideIndex", slide.SlideIndex));
                    displayInfo.Add(new DisplayObject("幻灯片版式", "Layout", slide.Layout.ToString()));
                    #endregion
                    break;
                case PptType.Location:
                    #region Shape名称、类型与定位属性
                    PowerPoint.Shape shape = (PowerPoint.Shape)io.o;
                    displayInfo.Add(new DisplayObject("名称", "ShapeName", shape.Name));
                    displayInfo.Add(new DisplayObject("类型", "Type", shape.Type));
                    displayInfo.Add(new DisplayObject("上边距", "Top", shape.Top));
                    displayInfo.Add(new DisplayObject("上边距", "Top", shape.Top));
                    displayInfo.Add(new DisplayObject("左边距", "Left", shape.Left));
                    displayInfo.Add(new DisplayObject("高度", "Height", shape.Height));
                    displayInfo.Add(new DisplayObject("宽度", "Width", shape.Width));
                    //displayInfo.Add("Line:" + shape.Line.ToString());
                    #endregion
                    break;
                case PptType.WordArt:                   //艺术字的一系列属性
                    #region 艺术字属性
                    PowerPoint.Shape wordart = (PowerPoint.Shape)io.o;
                    //displayInfo.Add(new DisplayObject("文字", "Name", wordart.Name));
                    //displayInfo.Add(new DisplayObject("Type", wordart.Type));
                    displayInfo.Add(new DisplayObject("文字", "Text", wordart.TextEffect.Text));
                    displayInfo.Add(new DisplayObject("粗体", "Bold", wordart.TextEffect.FontBold));
                    displayInfo.Add(new DisplayObject("斜体", "Italic", wordart.TextEffect.FontItalic));
                    displayInfo.Add(new DisplayObject("字体", "FontName", wordart.TextEffect.FontName));
                    displayInfo.Add(new DisplayObject("字号", "FontSize", wordart.TextEffect.FontSize.ToString()));
                    displayInfo.Add(new DisplayObject("对齐方式", "Alignment", wordart.TextEffect.Alignment.ToString()));
                    //displayInfo.Add(new DisplayObject("艺术字格式", "PresetTextEffect", wordart.TextEffect.PresetTextEffect.ToString()));
                    displayInfo.Add(new DisplayObject("艺术字形状", "PresetShape", wordart.TextEffect.PresetShape.ToString()));
                    displayInfo.Add(new DisplayObject("文字是否垂直排列", "RotatedChars", wordart.TextEffect.RotatedChars.ToString()));
                    displayInfo.Add(new DisplayObject("字符间距", "Tracking", wordart.TextEffect.Tracking.ToString()));
                    //displayInfo.Add("是否自动缩紧字符对:" + shape.TextEffect.KernedPairs.ToString());
                    #endregion
                    break;
                case PptType.Background:
                    #region 背景属性
                    PowerPoint.ShapeRange background = (PowerPoint.ShapeRange)io.o;
                    displayInfo.Add(new DisplayObject("填充模式", "FillType", background.Fill.Type));
                    displayInfo.Add(new DisplayObject("背景颜色预设填充类型", "GradientType", background.Fill.PresetGradientType));
                    displayInfo.Add(new DisplayObject("背景颜色预设填充方向", "GradientDegree", background.Fill.GradientStyle));
                    #endregion
                    break;
                case PptType.Run:
                    #region 文字块属性
                    PowerPoint.TextRange textrange = (PowerPoint.TextRange)io.o;
                    displayInfo.Add(new DisplayObject("文字", "Text", textrange.Text));
                    displayInfo.Add(new DisplayObject("粗体", "Bold", textrange.Font.Bold));
                    displayInfo.Add(new DisplayObject("斜体", "Italic", textrange.Font.Italic));
                    displayInfo.Add(new DisplayObject("下划线", "Underline", textrange.Font.Underline));
                    displayInfo.Add(new DisplayObject("字体", "FontName", textrange.Font.Name));
                    displayInfo.Add(new DisplayObject("字号", "FontSize", textrange.Font.Size.ToString()));
                    displayInfo.Add(new DisplayObject("字体颜色", "ForeColor", textrange.Font.Color.RGB));
                    displayInfo.Add(new DisplayObject("文字阴影", "Shadow", textrange.Font.Shadow));
                    displayInfo.Add(new DisplayObject("上标", "Superscript", textrange.Font.Superscript));
                    displayInfo.Add(new DisplayObject("下标", "Subscript", textrange.Font.Subscript));
                    #endregion
                    break;
                case PptType.Animation:
                    #region 对象自定义动画属性
                    PowerPoint.AnimationSettings action = (PowerPoint.AnimationSettings)io.o;
                    displayInfo.Add(new DisplayObject("动画顺序", "AnimationOrder", action.AnimationOrder));
                    displayInfo.Add(new DisplayObject("进入动画效果", "EntryEffect", action.EntryEffect));
                    displayInfo.Add(new DisplayObject("动画触发方式", "AdvanceMode", action.AdvanceMode));
                    //OnTime OnClick ModeMixed(混合模式)
                    displayInfo.Add(new DisplayObject("触发计时延迟时间", "AdvanceTime", action.AdvanceTime));
                    //displayInfo.Add("EntryEffect:" + action.PlaySettings.);
                    #endregion
                    break;
                case PptType.Effect:
                    #region 幻灯片动画属性
                        PowerPoint.Effect effect = (PowerPoint.Effect)io.o;
                        //displayInfo.Add("AdvanceMode:" + effect.Behaviors);
                        //displayInfo.Add("AdvanceMode:" + effect.EffectInformation);
                        //displayInfo.Add("AdvanceMode:" + effect.EffectParameters);
                        displayInfo.Add(new DisplayObject("动画名称", "DisplayName", effect.DisplayName));
                        displayInfo.Add(new DisplayObject("动画效果", "EffectType", effect.EffectType));
                        displayInfo.Add(new DisplayObject("是否为退出动画", "Exit", effect.Exit));
                        displayInfo.Add(new DisplayObject("动画顺序", "Index", effect.Index));
                        displayInfo.Add(new DisplayObject("动画所作用的对象名称", "ShapeName", effect.Shape.Name));
                        displayInfo.Add(new DisplayObject("动画运行时间", "Duration", effect.Timing.Duration));
                        try
                        {
                            displayInfo.Add(new DisplayObject("段落", "Paragraph", effect.Paragraph));
                            displayInfo.Add(new DisplayObject("开始区域", "TextRangeStart", effect.TextRangeStart));
                            displayInfo.Add(new DisplayObject("区域长度", "TextRangeLength", effect.TextRangeLength));
                        }
                        catch { }
                        #endregion
                    break;
                case PptType.Transition:                    //幻灯片切换的一系列属性
                    #region 幻灯片切换属性
                    PowerPoint.SlideShowTransition transition = (PowerPoint.SlideShowTransition)io.o;
                    displayInfo.Add(new DisplayObject("是否通过点击触发", "AdvanceOnClick", transition.AdvanceOnClick));
                    displayInfo.Add(new DisplayObject("是否设置自动触发动画效果", "AdvanceOnTime", transition.AdvanceOnTime));
                    displayInfo.Add(new DisplayObject("自动触发效果延迟时间", "AdvanceTime", transition.AdvanceTime));
                    displayInfo.Add(new DisplayObject("幻灯片切换效果名称", "EntryEffect", transition.EntryEffect));
                    displayInfo.Add(new DisplayObject("切换速度", "Speed", transition.Speed));
                    //displayInfo.Add("声音:" + transition.SoundEffect.Name);
                    #endregion
                    break;
                case PptType.Picture:
                    #region 图片属性
                        PowerPoint.Shape pic = (PowerPoint.Shape)io.o;
                        PowerPoint.PictureFormat pf = pic.PictureFormat;
                        //displayInfo.Add(new DisplayObject("名称", "Name", pic.Name));
                        //displayInfo.Add(new DisplayObject("类型", "Type", pic.Type));
                        //displayInfo.Add(new DisplayObject("高度", "Height", pic.Height.ToString()));
                        //displayInfo.Add(new DisplayObject("宽度", "Width", pic.Width.ToString()));
                        //displayInfo.Add(new DisplayObject("上边距", "Top", pic.Top.ToString()));
                        //displayInfo.Add(new DisplayObject("左边距", "Left", pic.Left.ToString()));
                        displayInfo.Add(new DisplayObject("左裁剪距离", "CropLeft", pf.CropLeft.ToString()));
                        displayInfo.Add(new DisplayObject("上裁剪距离", "CropTop", pf.CropTop.ToString()));
                        displayInfo.Add(new DisplayObject("右裁剪距离", "CropRight", pf.CropRight.ToString()));
                        displayInfo.Add(new DisplayObject("下裁剪距离", "CropBottom", pf.CropBottom.ToString()));
                        #endregion
                    break;
                case PptType.ThreeD:
                    #region 三维属性
                    PowerPoint.Shape shape3d = (PowerPoint.Shape)io.o;
                    displayInfo.Add(new DisplayObject("三维效果", "ThreeDFormat", shape3d.ThreeD.PresetThreeDFormat));
                    displayInfo.Add(new DisplayObject("照明角度", "LightingDirection", shape3d.ThreeD.PresetLightingDirection));
                    displayInfo.Add(new DisplayObject("照明亮度", "LightingSoftness", shape3d.ThreeD.PresetLightingSoftness));
                    displayInfo.Add(new DisplayObject("表面效果", "Material", shape3d.ThreeD.PresetMaterial));
                    displayInfo.Add(new DisplayObject("图形深度", "Depth", shape3d.ThreeD.Depth));
                    displayInfo.Add(new DisplayObject("延伸方向", "ExtrusionDirection", shape3d.ThreeD.PresetExtrusionDirection));
                    #endregion
                    break;
                case PptType.ClickAction:
                case PptType.MoveAction:
                    #region 动作设置
                    PowerPoint.ActionSetting acs = (PowerPoint.ActionSetting)io.o;
                    //displayInfo.Add(new DisplayObject("Verb", "ActionVerb", acs.ActionVerb));
                    //displayInfo.Add(new DisplayObject("AA", "AnimateAction", acs.AnimateAction));
                    displayInfo.Add(new DisplayObject("执行的动作", "Action", acs.Action));
                    if (acs.Action == PowerPoint.PpActionType.ppActionHyperlink)
                    {
                        if (acs.Hyperlink.Address != null)
                            displayInfo.Add(new DisplayObject("超链接地址", "HyperlinkAddr", acs.Hyperlink.Address));
                        if (acs.Hyperlink.SubAddress != null)
                            displayInfo.Add(new DisplayObject("超链接本地地址", "HyperlinkSubAddr", acs.Hyperlink.SubAddress));
                    }
                    #endregion
                    break;
            }
            foreach (DisplayObject d in displayInfo)
                checkedListBox1.Items.Add(d.ToString());
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
                    case PptType.Slide:
                        helper.addSlide(idx + 1);
                        break;
                    case PptType.Effect:
                        helper.addEffect(idx + 1);
                        break;
                    case PptType.Shape:
                        helper.addShape(idx + 1);
                        break;
                    case PptType.Run:
                        helper.addRun(idx);
                        break;
                    case PptType.Transition:
                    case PptType.Background:
                    case PptType.Location:
                    case PptType.Picture:
                    case PptType.WordArt:
                    case PptType.ThreeD:
                    case PptType.Animation:
                    case PptType.ClickAction:
                    case PptType.MoveAction:
                        helper.addSingleNode(tmpObj.type);
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

        public void addSingleNode(PptType pt)
        {
            oxml.Path.Add(new OfficeElement(pt.ToString(), "0"));
        }

        public void addSlide(int slideIdx)
        {
            oxml.Path.Add(new OfficeElement("Presentations", "0"));
            oxml.Path.Add(new OfficeElement(PptType.Slide.ToString(), slideIdx.ToString()));
        }

        public void addShape(int shapeIdx)
        {
            oxml.Path.Add(new OfficeElement(PptType.Shape.ToString(), shapeIdx.ToString()));
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

        public void addLocation()
        {
            oxml.Path.Add(new OfficeElement(PptType.Location.ToString(), "0"));
        }

        public void addRun(int runIdx)
        {
            oxml.Path.Add(new OfficeElement(PptType.Run.ToString(), runIdx.ToString()));
        }

        public void addPicture()
        {
            oxml.Path.Add(new OfficeElement(PptType.Picture.ToString(), "0"));
        }

        public void addWordArt()
        {
            oxml.Path.Add(new OfficeElement(PptType.WordArt.ToString(), "0"));
        }

        public void addThreeD()
        {
            oxml.Path.Add(new OfficeElement(PptType.ThreeD.ToString(), "0"));
        }

        public void addAnimation()
        {
            oxml.Path.Add(new OfficeElement(PptType.Animation.ToString(), "0"));
        }

        public void addClickAction()
        {
            oxml.Path.Add(new OfficeElement(PptType.ClickAction.ToString(), "0"));
        }

        public void addMoveAction()
        {
            oxml.Path.Add(new OfficeElement(PptType.MoveAction.ToString(), "0"));
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

    public enum PptType
    {
        Slide,              //幻灯片
        Shapes,             //文字图片对象(指示标签)
        TextContainer,      //文字区域
        Background,         //幻灯片背景
        Design,             //?????????
        Master,             //???
        Run,                //文字块
        ClickAction,        //单击时的动作设置
        MoveAction,         //鼠标划过时的动作设置
        Actions,            //动作设置(指示标签)
        Animation,          //自定义动画
        Effect,             //动画效果
        Effects,            //幻灯片动画(指示标签)
        Transition,         //幻灯片切换
        Shape,              //形状（包括图片、文字等信息）
        WordArt,            //艺术字
        EmbeddedObject,     //嵌入式内容
        Picture,            //图片
        Location,           //位置信息
        ThreeD,             //三维信息
        Null                //指示标签，无意义
    }
}
