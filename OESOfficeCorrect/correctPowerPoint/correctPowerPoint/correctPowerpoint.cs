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
        PowerPoint.Slide stuSld, ansSld;
        PowerPoint.ShapeRange stuBg, ansBg;
        PowerPoint.SlideShowTransition stuTrans, ansTrans;
        PowerPoint.Effect stuEffect, ansEffect;
        PowerPoint.Shape stuShape, ansShape;
        PowerPoint.PictureFormat stuPf, ansPf;
        OfficeXML oxml;
        //TreeNode Root;

        public const Microsoft.Office.Core.MsoTriState False = Microsoft.Office.Core.MsoTriState.msoFalse;
        public const Microsoft.Office.Core.MsoTriState True = Microsoft.Office.Core.MsoTriState.msoTrue;

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

        public int check_Kernel(List<OfficeElement> ls)
        {
            int points = 0;
            int i;
            for (i = 0; i < ls.Count; i++)
            {
                OfficeElement oe = ls[i];
                #region 上层固定标签
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
                    continue;
                }
                #endregion
                #region Slide的孩子标签
                if (oe.AttribName == "Transition")  //过渡动画属性检查
                {
                    stuTrans = stuSld.SlideShowTransition;
                    ansTrans = ansSld.SlideShowTransition;
                    #region 叶节点判分
                    oe = ls[++i];
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
                    #endregion
                    break;
                }
                if (oe.AttribName == "Background")  //幻灯片背景属性检查
                {
                    stuBg = stuSld.Background;
                    ansBg = ansSld.Background;
                    #region 叶节点判分
                    oe = ls[++i];
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
                    #endregion
                    break;
                }
                if (oe.AttribName == "Design")      //幻灯片模板属性检查
                {
                    //currentCheck = "Design";
                    //叶节点判分
                    break;
                }
                if (oe.AttribName == "Master")      //???属性检查
                {
                    //currentCheck = "Master";
                    //叶节点判分
                    break;
                }
                if (oe.AttribName == "Effect")      //幻灯片动画属性检查
                {
                    #region 动画定位
                    try
                    {
                        int effId = int.Parse(oe.AttribValue);
                        stuEffect = stuSld.TimeLine.MainSequence[effId];
                        ansEffect = stuSld.TimeLine.MainSequence[effId];
                    }
                    catch
                    {
                        points = 0;
                        break;
                    }
                    #endregion
                    #region 叶节点判分
                    oe = ls[++i];
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
                            if (stuEffect.Paragraph == ansEffect.Paragraph)
                                points = int.Parse(oe.AttribValue);
                            break;
                        case "TextRangeStart":
                            if (stuEffect.TextRangeStart == ansEffect.TextRangeStart)
                                points = int.Parse(oe.AttribValue);
                            break;
                        case "TextRangeLength":
                            if (stuEffect.TextRangeLength == ansEffect.TextRangeLength)
                                points = int.Parse(oe.AttribValue);
                            break;
                    }
                    #endregion
                    break;
                }
                if (oe.AttribName == "TextContainer")   //文字区域属性检查
                {
                    #region 文字区域定位
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
                    #region 判断类型是否一致
                    if (stuShape.Type != ansShape.Type) //shape类型不一致
                    {
                        points = 0;
                        break;
                    }
                    #endregion
                    if (ansShape.Type ==
                        Microsoft.Office.Core.MsoShapeType.msoPlaceholder)  //文本(Run)
                    { }
                    else if (ansShape.Type ==
                        Microsoft.Office.Core.MsoShapeType.msoTextEffect)   //艺术字(WordArt)
                    { }
                    break;
                }
                if (oe.AttribName == "Picture")     //图片属性检查
                {
                    #region 图片区域定位
                    try
                    {
                        int shapeId = int.Parse(oe.AttribValue);
                        stuShape = stuSld.Shapes[shapeId];
                        ansShape = ansSld.Shapes[shapeId];
                        stuPf = stuShape.PictureFormat;
                        ansPf = ansShape.PictureFormat;
                    }
                    catch
                    {
                        points = 0;
                        break;
                    }
                    #endregion
                    //#region 叶节点判分
                    //#endregion
                    break;
                }
                #endregion
            }
            return points;
        }

        //通过考点栈获取当前考点信息
        string generateTestInfo()
        {
            return "";
        }
    }
}
