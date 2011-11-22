using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;
using System.Windows.Forms;
using OESXML;

namespace correctPowerPoint
{
    public class correctPowerpoint
    {
        PowerPoint.Application powerpoint;
        PowerPoint.Presentation stuPpt, ansPpt;
        PowerPoint.Slide stuSld, ansSld;                        //幻灯片属性
        PowerPoint.ShapeRange stuBg, ansBg;                     //幻灯片背景属性
        PowerPoint.SlideShowTransition stuTrans, ansTrans;      //幻灯片过渡动画属性
        PowerPoint.Effect stuEffect, ansEffect;                 //幻灯片动画属性
        PowerPoint.Shape stuShape, ansShape;                    //Shape对象属性
        PowerPoint.PictureFormat stuPf, ansPf;                  //图形属性
        PowerPoint.ThreeDFormat stu3d, ans3d;                   //三维属性
        PowerPoint.TextRange stuTr, ansTr;                      //文字块属性
        PowerPoint.ShapeRange stuSr, ansSr;                     //背景属性
        PowerPoint.TextEffectFormat stuTf, ansTf;               //艺术字属性
        PowerPoint.AnimationSettings stuAm, ansAm;              //对象自定义动画属性
        PowerPoint.ActionSetting stuAcs, ansAcs;                //对象动作设置
        OfficeXML oxml;
        
        public const Microsoft.Office.Core.MsoTriState False = Microsoft.Office.Core.MsoTriState.msoFalse;
        public const Microsoft.Office.Core.MsoTriState True = Microsoft.Office.Core.MsoTriState.msoTrue;

        const int PART_SLIDE = 0;               //正在分析幻灯片部分
        const int PART_BACKGROUND = 1;          //正在分析幻灯片背景部分
        const int PART_TRANSITION = 2;          //正在分析幻灯片过渡动画部分
        const int PART_EFFECT = 3;              //正在分析幻灯片动画部分
        const int PART_SHAPE = 4;               //正在分析幻灯片Shape对象部分
        const int PART_LOCATION = 5;            //正在分析对象类型及定位部分
        const int PART_PICTURE = 6;             //正在分析对象图片部分
        const int PART_TEXTRANGE = 7;           //正在分析对象文本部分
        const int PART_WORDART = 8;             //正在分析对象艺术字部分
        const int PART_3D = 9;                  //正在分析对象三维部分
        const int PART_ANIMATION = 10;          //正在分析幻灯片自定义动画部分
        const int PART_ACTION = 11;             //正在分析对象动作部分
        //const int PART_CLICKACTION = 11;        //正在分析幻灯片单击动作部分
        //const int PART_MOVEACTION = 12;         //正在分析幻灯片鼠标划过动作部分

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

        //评分核心函数
        public int check_Kernel(List<OfficeElement> ls)
        {
            int points = 0, i;
            int curPart = -1;               //当前正在分析哪一部分的考点
            for (i = 0; i < ls.Count; i++)
            {
                OfficeElement oe = ls[i];
                #region 具体考点对象定位
                if (oe.AttribName == "Root")
                    continue;
                if (oe.AttribName == "Presentations")
                    continue;
                if (oe.AttribName == "Slide")
                {
                    #region 幻灯片定位
                    try
                    {
                        int slideId = int.Parse(oe.AttribValue);
                        stuSld = stuPpt.Slides[slideId];
                        ansSld = ansPpt.Slides[slideId];
                    }
                    catch
                    {
                        points = 0;
                        break;
                    }
                    #endregion
                    curPart = PART_SLIDE;
                    continue;
                }
                if (oe.AttribName == "Background")
                {
                    #region 幻灯片背景定位
                    try
                    {
                        stuBg = stuSld.Background;
                        ansBg = ansSld.Background;
                    }
                    catch
                    {
                        points = 0;
                        break;
                    }
                    #endregion
                    curPart = PART_BACKGROUND;
                    continue;
                }
                if (oe.AttribName == "Transition")
                {
                    #region 过渡动画定位
                    try
                    {
                        stuTrans = stuSld.SlideShowTransition;
                        ansTrans = ansSld.SlideShowTransition;
                    }
                    catch
                    {
                        points = 0;
                        break;
                    }
                    #endregion
                    curPart = PART_TRANSITION;
                    continue;
                }
                if (oe.AttribName == "Effects")
                {
                    continue;
                }
                if (oe.AttribName == "Effect")
                {
                    #region 幻灯片动画定位
                    try
                    {
                        int effId = int.Parse(oe.AttribValue);
                        stuEffect = stuSld.TimeLine.MainSequence[effId];
                        ansEffect = ansSld.TimeLine.MainSequence[effId];
                    }
                    catch
                    {
                        points = 0;
                        break;
                    }
                    #endregion
                    curPart = PART_EFFECT;
                    continue;
                }
                if (oe.AttribName == "Shape")
                {
                    #region Shape定位
                    try
                    {
                        int shapeId = int.Parse(oe.AttribValue);
                        stuShape = stuSld.Shapes[shapeId];
                        ansShape = ansSld.Shapes[shapeId];
                    }
                    catch
                    {
                        points = 0;
                        break;
                    }
                    #endregion
                    curPart = PART_SHAPE;
                    continue;
                }
                if (oe.AttribName == "Location")
                {
                    curPart = PART_LOCATION;
                    continue;
                }
                if (oe.AttribName == "Picture")
                {
                    #region 图片属性定位
                    try
                    {
                        stuPf = stuShape.PictureFormat;
                        ansPf = ansShape.PictureFormat;
                    }
                    catch
                    {
                        points = 0;
                        break;
                    }
                    #endregion
                    curPart = PART_PICTURE;
                    continue;
                }
                if (oe.AttribName == "Run")
                {
                    #region 文字部分定位
                    try
                    {
                        int runId = int.Parse(oe.AttribValue);
                        stuTr = stuShape.TextFrame.TextRange.Runs(0, 100);
                        ansTr = ansShape.TextFrame.TextRange.Runs(0, 100);
                    }
                    catch
                    {
                        points = 0;
                        break;
                    }
                    #endregion
                    curPart = PART_TEXTRANGE;
                    continue;
                }
                if (oe.AttribName == "WordArt")
                {
                    #region 艺术字定位
                    try
                    {
                        stuTf = stuShape.TextEffect;
                        ansTf = ansShape.TextEffect;
                    }
                    catch
                    {
                        points = 0;
                        break;
                    }
                    #endregion
                    curPart = PART_WORDART;
                    continue;
                }
                if (oe.AttribName == "ThreeD")
                {
                    #region 三维属性定位
                    try
                    {
                        stu3d = stuShape.ThreeD;
                        ans3d = ansShape.ThreeD;
                    }
                    catch
                    {
                        points = 0;
                        break;
                    }
                    #endregion
                    curPart = PART_3D;
                    continue;
                }
                if (oe.AttribName == "Animation")
                {
                    #region 自定义动画定位
                    try
                    {
                        stuAm = stuShape.AnimationSettings;
                        ansAm = ansShape.AnimationSettings;
                    }
                    catch
                    {
                        points = 0;
                        break;
                    }
                    #endregion
                    curPart = PART_ANIMATION;
                    continue;
                }
                if (oe.AttribName == "ClickAction")
                {
                    #region 单击动作定位
                    try
                    {
                        stuAcs = stuShape.ActionSettings[PowerPoint.PpMouseActivation.ppMouseClick];
                        ansAcs = ansShape.ActionSettings[PowerPoint.PpMouseActivation.ppMouseClick];
                    }
                    catch
                    {
                        points = 0;
                        break;
                    }
                    #endregion
                    curPart = PART_ACTION;
                    continue;
                }
                if (oe.AttribName == "MoveAction")
                {
                    #region 鼠标移动动作定位
                    try
                    {
                        stuAcs = stuShape.ActionSettings[PowerPoint.PpMouseActivation.ppMouseOver];
                        ansAcs = ansShape.ActionSettings[PowerPoint.PpMouseActivation.ppMouseOver];
                    }
                    catch
                    {
                        points = 0;
                        break;
                    }
                    #endregion
                    curPart = PART_ACTION;
                    continue;
                }
                #endregion
                #region 幻灯片判分
                if (curPart == PART_SLIDE)
                {
                    switch (oe.AttribName)
                    { 
                        case "SlideName":
                            if (stuSld.Name == ansSld.Name)
                                points = int.Parse(oe.AttribValue);
                            break;
                        case "SlideIndex":
                            if (stuSld.SlideIndex == ansSld.SlideIndex)
                                points = int.Parse(oe.AttribValue);
                            break;
                        case "Layout":
                            if (stuSld.Layout == ansSld.Layout)
                                points = int.Parse(oe.AttribValue);
                            break;
                    }
                    continue;
                }
                #endregion
                #region 幻灯片背景判分
                if (curPart == PART_BACKGROUND)
                {
                    switch (oe.AttribName)
                    {
                        case "Fill":
                            if (stuBg.Fill.Type.Equals(ansBg.Fill.Type))
                                points = int.Parse(oe.AttribValue);
                            break;
                        case "GradientType":
                            if (stuBg.Fill.PresetGradientType == ansBg.Fill.PresetGradientType)
                                points = int.Parse(oe.AttribValue);
                            break;
                        case "GradientStyle":
                            if (stuBg.Fill.GradientStyle == ansBg.Fill.GradientStyle)
                                points = int.Parse(oe.AttribValue);
                            break;
                    }
                    continue;
                }
                #endregion
                #region 幻灯片过渡动画判分
                if (curPart == PART_TRANSITION)
                {
                    switch (oe.AttribName)
                    {
                        case "AdvanceOnClick":
                            if (stuTrans.AdvanceOnClick.Equals(ansTrans.AdvanceOnClick))
                                points = int.Parse(oe.AttribValue);
                            break;
                        case "AdvanceOnTime":
                            if (stuTrans.AdvanceOnTime.Equals(ansTrans.AdvanceOnTime))
                                points = int.Parse(oe.AttribValue);
                            break;
                        case "AdvanceTime":
                            if (stuTrans.AdvanceTime == ansTrans.AdvanceTime)
                                points = int.Parse(oe.AttribValue);
                            break;
                        case "EntryEffect":
                            if (stuTrans.EntryEffect.Equals(ansTrans.EntryEffect))
                                points = int.Parse(oe.AttribValue);
                            break;
                        case "Speed":
                            if (stuTrans.Speed.Equals(ansTrans.Speed))
                                points = int.Parse(oe.AttribValue);
                            break;
                    }
                    continue;
                }
                #endregion
                #region 幻灯片动画判分
                if (curPart == PART_EFFECT)
                {
                    switch (oe.AttribName)
                    {
                        case "DisplayName":
                            if (stuEffect.DisplayName == ansEffect.DisplayName)
                                points = int.Parse(oe.AttribValue);
                            break;
                        case "EffectType":
                            if (stuEffect.EffectType.Equals(ansEffect.EffectType))
                                points = int.Parse(oe.AttribValue);
                            break;
                        case "Exit":
                            if (stuEffect.Exit.Equals(ansEffect.Exit))
                                points = int.Parse(oe.AttribValue);
                            break;
                        case "Index":
                            if (stuEffect.Index == ansEffect.Index)
                                points = int.Parse(oe.AttribValue);
                            break;
                        case "ShapeName":
                            if (stuEffect.Shape.Name == ansEffect.Shape.Name)
                                points = int.Parse(oe.AttribValue);
                            break;
                        case "Duration":
                            if (stuEffect.Timing.Duration == ansEffect.Timing.Duration)
                                points = int.Parse(oe.AttribValue);
                            break;
                        case "Paragraph":
                            try
                            {
                                if (stuEffect.Paragraph == ansEffect.Paragraph)
                                    points = int.Parse(oe.AttribValue);
                            }
                            catch { points = 0; }
                            break;
                        case "TextRangeStart":
                            try
                            {
                                if (stuEffect.TextRangeStart == ansEffect.TextRangeStart)
                                    points = int.Parse(oe.AttribValue);
                            }
                            catch { points = 0; }
                            break;
                        case "TextRangeLength":
                            try
                            {
                                if (stuEffect.TextRangeLength == ansEffect.TextRangeLength)
                                    points = int.Parse(oe.AttribValue);
                            }
                            catch { points = 0; }
                            break;
                    }
                    continue;
                }
                #endregion
                #region 幻灯片对象判分
                if (curPart == PART_SHAPE)
                {
                    continue;
                }
                #endregion
                #region 对象类型、定位判分
                if (curPart == PART_LOCATION)
                {
                    switch (oe.AttribName)
                    { 
                        case "ShapeName":
                            if (stuShape.Name == ansShape.Name)
                                points = int.Parse(oe.AttribValue);
                            break;
                        case "Type":
                            if (stuShape.Type == ansShape.Type)
                                points = int.Parse(oe.AttribValue);
                            break;
                        case "Top":
                            if (stuShape.Top == ansShape.Top)
                                points = int.Parse(oe.AttribValue);
                            break;
                        case "Left":
                            if (stuShape.Left == ansShape.Left)
                                points = int.Parse(oe.AttribValue);
                            break;
                        case "Height":
                            if (stuShape.Height == ansShape.Height)
                                points = int.Parse(oe.AttribValue);
                            break;
                        case "Width":
                            if (stuShape.Width == ansShape.Width)
                                points = int.Parse(oe.AttribValue);
                            break;
                    }
                    continue;
                }
                #endregion
                #region 图片属性判分
                if (curPart == PART_PICTURE)
                {
                    switch (oe.AttribName)
                    {
                        case "CropLeft":
                            if (stuPf.CropLeft == ansPf.CropLeft)
                                points = int.Parse(oe.AttribValue);
                            break;
                        case "CropTop":
                            if (stuPf.CropTop == ansPf.CropTop)
                                points = int.Parse(oe.AttribValue);
                            break;
                        case "CropRight":
                            if (stuPf.CropRight == ansPf.CropRight)
                                points = int.Parse(oe.AttribValue);
                            break;
                        case "CropBottom":
                            if (stuPf.CropBottom == ansPf.CropBottom)
                                points = int.Parse(oe.AttribValue);
                            break;
                    }
                    continue;
                }
                #endregion
                #region 文本属性判分
                if (curPart == PART_TEXTRANGE)
                {
                    switch (oe.AttribName)
                    { 
                        case "Text":
                            if (stuTr.Text == ansTr.Text)
                                points = int.Parse(oe.AttribValue);
                            break;
                        case "Bold":
                            if (stuTr.Font.Bold == ansTr.Font.Bold)
                                points = int.Parse(oe.AttribValue);
                            break;
                        case "Italic":
                            if (stuTr.Font.Italic == ansTr.Font.Italic)
                                points = int.Parse(oe.AttribValue);
                            break;
                        case "Underline":
                            if (stuTr.Font.Underline == ansTr.Font.Underline)
                                points = int.Parse(oe.AttribValue);
                            break;
                        case "FontName":
                            if (stuTr.Font.Name == ansTr.Font.Name)
                                points = int.Parse(oe.AttribValue);
                            break;
                        case "FontSize":
                            if (stuTr.Font.Size == ansTr.Font.Size)
                                points = int.Parse(oe.AttribValue);
                            break;
                        case "Shadow":
                            if (stuTr.Font.Shadow == ansTr.Font.Shadow)
                                points = int.Parse(oe.AttribValue);
                            break;
                        case "Superscript":
                            if (stuTr.Font.Superscript == ansTr.Font.Superscript)
                                points = int.Parse(oe.AttribValue);
                            break;
                        case "Subscript":
                            if (stuTr.Font.Subscript == ansTr.Font.Subscript)
                                points = int.Parse(oe.AttribValue);
                            break;
                        case "ForeColor":
                            if (stuTr.Font.Color.RGB == ansTr.Font.Color.RGB)
                                points = int.Parse(oe.AttribValue);
                            break;
                    }
                    continue;
                }
                #endregion
                #region 艺术字属性判分
                if (curPart == PART_WORDART)
                {
                    switch (oe.AttribName)
                    {
                        case "Text":
                            if (stuTf.Text == ansTf.Text)
                                points = int.Parse(oe.AttribValue);
                            break;
                        case "Bold":
                            if (stuTf.FontBold == ansTf.FontBold)
                                points = int.Parse(oe.AttribValue);
                            break;
                        case "Italic":
                            if (stuTf.FontItalic == ansTf.FontItalic)
                                points = int.Parse(oe.AttribValue);
                            break;
                        case "FontName":
                            if (stuTf.FontName == ansTf.FontName)
                                points = int.Parse(oe.AttribValue);
                            break;
                        case "FontSize":
                            if (stuTf.FontSize == ansTf.FontSize)
                                points = int.Parse(oe.AttribValue);
                            break;
                        case "Alignment":
                            if (stuTf.Alignment.ToString() == ansTf.Alignment.ToString())
                                points = int.Parse(oe.AttribValue);
                            break;
                        case "PresetShape":
                            if (stuTf.PresetShape.ToString() == ansTf.PresetShape.ToString())
                                points = int.Parse(oe.AttribValue);
                            break;
                        case "RotatedChars":
                            if (stuTf.RotatedChars.ToString() == ansTf.RotatedChars.ToString())
                                points = int.Parse(oe.AttribValue);
                            break;
                        case "Tracking":
                            if (stuTf.Tracking.ToString() == ansTf.Tracking.ToString())
                                points = int.Parse(oe.AttribValue);
                            break;
                    }
                    continue;
                }
                #endregion
                #region 三维属性判分
                if (curPart == PART_3D)
                {
                    switch (oe.AttribName)
                    { 
                        case "ThreeDFormat":
                            if (stu3d.PresetThreeDFormat == ans3d.PresetThreeDFormat)
                                points = int.Parse(oe.AttribValue);
                            break;
                        case "LightingDirection":
                            if (stu3d.PresetLightingDirection == ans3d.PresetLightingDirection)
                                points = int.Parse(oe.AttribValue);
                            break;
                        case "LightingSoftness":
                            if (stu3d.PresetLightingSoftness == ans3d.PresetLightingSoftness)
                                points = int.Parse(oe.AttribValue);
                            break;
                        case "Material":
                            if (stu3d.PresetMaterial == ans3d.PresetMaterial)
                                points = int.Parse(oe.AttribValue);
                            break;
                        case "Depth":
                            if (stu3d.Depth == ans3d.Depth)
                                points = int.Parse(oe.AttribValue);
                            break;
                        case "ExtrusionDirection":
                            if (stu3d.PresetExtrusionDirection == ans3d.PresetExtrusionDirection)
                                points = int.Parse(oe.AttribValue);
                            break;
                    }
                    continue;
                }
                #endregion
                #region 自定义动画判分
                if (curPart == PART_ANIMATION)
                {
                    switch (oe.AttribName)
                    { 
                        case "AnimationOrder":
                            if (stuAm.AnimationOrder == ansAm.AnimationOrder)
                                points = int.Parse(oe.AttribValue);
                            break;
                        case "EntryEffect":
                            if (stuAm.EntryEffect == ansAm.EntryEffect)
                                points = int.Parse(oe.AttribValue);
                            break;
                        case "AdvanceMode":
                            if (stuAm.AdvanceMode == ansAm.AdvanceMode)
                                points = int.Parse(oe.AttribValue);
                            break;
                        case "AdvanceTime":
                            if (stuAm.AdvanceTime == ansAm.AdvanceTime)
                                points = int.Parse(oe.AttribValue);
                            break;
                    }
                    continue;
                }
                #endregion
                #region 对象动作判分
                if (curPart == PART_ACTION)
                {
                    switch (oe.AttribName)
                    { 
                        case "Action":
                            if (stuAcs.Action == ansAcs.Action)
                                points = int.Parse(oe.AttribValue);
                            break;
                        case "HyperlinkAddr":
                            if (stuAcs.Hyperlink.Address == ansAcs.Hyperlink.Address)
                                points = int.Parse(oe.AttribValue);
                            break;
                        case "HyperlinkSubAddr":
                            if (stuAcs.Hyperlink.SubAddress == ansAcs.Hyperlink.SubAddress)
                                points = int.Parse(oe.AttribValue);
                            break;
                    }
                    continue;
                }
                #endregion
            }
            return points;
        }

        //打开文件
        public void openFile(string stu, string ans, string xml)
        {
            powerpoint = new PowerPoint.ApplicationClass();
            //powerpoint.Visible = True;
            powerpoint.Activate();
            //powerpoint.Visible = False;
            //stuPpt = powerpoint.Presentations.Add(True);
            //ansPpt = powerpoint.Presentations.Add(True);
            stuPpt = powerpoint.Presentations.Open(stu, False, True, True);
            ansPpt = powerpoint.Presentations.Open(ans, False, True, True);
            oxml = new OfficeXML(xml);
            getPoint(oxml);
        }

        //获取考点信息
        public void getPoint(OfficeXML ox)
        {
            try { ox.getAllAnsPath(); }
            catch
            {
                MessageBox.Show("获取考点信息失败！");
                throw;
            }
        }

        //结束评分
        void dispose()
        {
            try
            {
                stuPpt.Close();
                ansPpt.Close();
                stuPpt = null;
                ansPpt = null;
                if (powerpoint.Presentations.Count == 0)
                {
                    powerpoint.Quit();
                    powerpoint = null;
                }
            }
            catch { }
            GC.Collect();
        }

    }
}
