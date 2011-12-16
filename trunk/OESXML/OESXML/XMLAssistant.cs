using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using OES.Model;

namespace OES.XMLFile
{
    public class XMLAssistant
    {
        private String fileName;
        private XMLType xmlType;
        private XmlDocument xd = new XmlDocument();
        /// <summary>
        /// XMLAssistance构造函数
        /// </summary>
        /// <param name="s">xml文件名</param>
        /// <param name="x">xml文件类型（一个XMLType的枚举）</param>
        /// <param name="o">文件头属性  试卷XML中需要试卷ID  考生答案XML中需要试卷ID和考生ID   试卷答案XML中需要试卷ID</param>
        public XMLAssistant(String s, XMLType x, Object o)
        {
            fileName = s;
            xmlType = x;
            if (fileName != "")
            {

                XmlElement xmlelem, xmlelem1;
                XmlNode xmlnode;
                if (File.Exists(fileName))
                {
                    try
                    {
                        xd.Load(fileName);
                    }
                    catch
                    {
                        xd.RemoveAll();
                        //加入xml声明
                        xmlnode = xd.CreateNode(XmlNodeType.XmlDeclaration, "", "");
                        xd.AppendChild(xmlnode);
                        //加入一个根元素
                        xmlelem = xd.CreateElement("", "ROOT", "");
                        xd.AppendChild(xmlelem);
                    }
                }
                else
                {
                    //加入xml声明
                    xmlnode = xd.CreateNode(XmlNodeType.XmlDeclaration, "", "");
                    xd.AppendChild(xmlnode);
                    //加入一个根元素
                    xmlelem = xd.CreateElement("", "ROOT", "");
                    xd.AppendChild(xmlelem);
                }
                if (o != null)
                {
                    switch (xmlType)
                    {
                        case XMLType.Log:
                            {
                                break;
                            }
                        case XMLType.Paper:
                            {
                                if (xd.ChildNodes.Item(1).ChildNodes.Count == 0 || Find(xd.ChildNodes.Item(1).ChildNodes.Item(0), "Paper") == null)
                                {
                                    xmlelem = xd.CreateElement("Paper");
                                    XmlAttribute xa = xd.CreateAttribute("id");
                                    xmlelem.Attributes.Append(xa);
                                    xmlelem.SetAttribute("id", ((string)o));
                                    xmlelem1 = xd.CreateElement("Choice");
                                    xmlelem.AppendChild(xmlelem1);
                                    xmlelem1 = xd.CreateElement("Completion");
                                    xmlelem.AppendChild(xmlelem1);
                                    xmlelem1 = xd.CreateElement("Judgment");
                                    xmlelem.AppendChild(xmlelem1);
                                    xmlelem1 = xd.CreateElement("Word");
                                    xmlelem.AppendChild(xmlelem1);
                                    xmlelem1 = xd.CreateElement("Excel");
                                    xmlelem.AppendChild(xmlelem1);
                                    xmlelem1 = xd.CreateElement("PowerPoint");
                                    xmlelem.AppendChild(xmlelem1);
                                    xmlelem1 = xd.CreateElement("CProgramCompletion");
                                    xmlelem.AppendChild(xmlelem1);
                                    xmlelem1 = xd.CreateElement("CProgramModification");
                                    xmlelem.AppendChild(xmlelem1);
                                    xmlelem1 = xd.CreateElement("CProgramFun");
                                    xmlelem.AppendChild(xmlelem1);
                                    xmlelem1 = xd.CreateElement("CppProgramCompletion");
                                    xmlelem.AppendChild(xmlelem1);
                                    xmlelem1 = xd.CreateElement("CppProgramModification");
                                    xmlelem.AppendChild(xmlelem1);
                                    xmlelem1 = xd.CreateElement("CppProgramFun");
                                    xmlelem.AppendChild(xmlelem1);
                                    xmlelem1 = xd.CreateElement("VbProgramCompletion");
                                    xmlelem.AppendChild(xmlelem1);
                                    xmlelem1 = xd.CreateElement("VbProgramModification");
                                    xmlelem.AppendChild(xmlelem1);
                                    xmlelem1 = xd.CreateElement("VbProgramFun");
                                    xmlelem.AppendChild(xmlelem1);
                                    xd.ChildNodes.Item(1).AppendChild(xmlelem);
                                }
                                else { }
                                break;
                            }
                        case XMLType.PaperAnswer:
                            {
                                if (xd.ChildNodes.Item(1).ChildNodes.Count == 0 || Find(xd.ChildNodes.Item(1).ChildNodes.Item(0), "Answer") == null)
                                {
                                    xmlelem = xd.CreateElement("Answer");
                                    XmlAttribute xa = xd.CreateAttribute("id");
                                    xmlelem.Attributes.Append(xa);
                                    xmlelem.SetAttribute("id", ((string[])o)[0]);
                                    xa = xd.CreateAttribute("type");
                                    xmlelem.Attributes.Append(xa);
                                    xmlelem.SetAttribute("type", "Paper");
                                    xmlelem1 = xd.CreateElement("Choice");
                                    xmlelem.AppendChild(xmlelem1);
                                    xmlelem1 = xd.CreateElement("Completion");
                                    xmlelem.AppendChild(xmlelem1);
                                    xmlelem1 = xd.CreateElement("Judgment");
                                    xmlelem.AppendChild(xmlelem1);
                                    xmlelem1 = xd.CreateElement("Word");
                                    xmlelem.AppendChild(xmlelem1);
                                    xmlelem1 = xd.CreateElement("Excel");
                                    xmlelem.AppendChild(xmlelem1);
                                    xmlelem1 = xd.CreateElement("PowerPoint");
                                    xmlelem.AppendChild(xmlelem1);
                                    xmlelem1 = xd.CreateElement("CProgramCompletion");
                                    xmlelem.AppendChild(xmlelem1);
                                    xmlelem1 = xd.CreateElement("CProgramModification");
                                    xmlelem.AppendChild(xmlelem1);
                                    xmlelem1 = xd.CreateElement("CProgramFun");
                                    xmlelem.AppendChild(xmlelem1);
                                    xmlelem1 = xd.CreateElement("CppProgramCompletion");
                                    xmlelem.AppendChild(xmlelem1);
                                    xmlelem1 = xd.CreateElement("CppProgramModification");
                                    xmlelem.AppendChild(xmlelem1);
                                    xmlelem1 = xd.CreateElement("CppProgramFun");
                                    xmlelem.AppendChild(xmlelem1);
                                    xmlelem1 = xd.CreateElement("VbProgramCompletion");
                                    xmlelem.AppendChild(xmlelem1);
                                    xmlelem1 = xd.CreateElement("VbProgramModification");
                                    xmlelem.AppendChild(xmlelem1);
                                    xmlelem1 = xd.CreateElement("VbProgramFun");
                                    xmlelem.AppendChild(xmlelem1);
                                    xd.ChildNodes.Item(1).AppendChild(xmlelem);
                                }
                                else { }
                                break;
                            }
                        case XMLType.StudentAnswer:
                            {
                                xmlelem = xd.CreateElement("Answer");
                                XmlAttribute xa = xd.CreateAttribute("id");
                                xmlelem.Attributes.Append(xa);
                                xmlelem.SetAttribute("id", ((string[])o)[0]);
                                xa = xd.CreateAttribute("type");
                                xmlelem.Attributes.Append(xa);
                                xmlelem.SetAttribute("type", "Student");
                                xa = xd.CreateAttribute("pid");
                                xmlelem.Attributes.Append(xa);
                                xmlelem.SetAttribute("pid", ((string[])o)[1]);
                                xmlelem1 = xd.CreateElement("Choice");
                                xmlelem.AppendChild(xmlelem1);
                                xmlelem1 = xd.CreateElement("Completion");
                                xmlelem.AppendChild(xmlelem1);
                                xmlelem1 = xd.CreateElement("Judgment");
                                xmlelem.AppendChild(xmlelem1);
                                xmlelem1 = xd.CreateElement("Word");
                                xmlelem.AppendChild(xmlelem1);
                                xmlelem1 = xd.CreateElement("Excel");
                                xmlelem.AppendChild(xmlelem1);
                                xmlelem1 = xd.CreateElement("PowerPoint");
                                xmlelem.AppendChild(xmlelem1);
                                xmlelem1 = xd.CreateElement("CProgramCompletion");
                                xmlelem.AppendChild(xmlelem1);
                                xmlelem1 = xd.CreateElement("CProgramModification");
                                xmlelem.AppendChild(xmlelem1);
                                xmlelem1 = xd.CreateElement("CProgramFun");
                                xmlelem.AppendChild(xmlelem1);
                                xmlelem1 = xd.CreateElement("CppProgramCompletion");
                                xmlelem.AppendChild(xmlelem1);
                                xmlelem1 = xd.CreateElement("CppProgramModification");
                                xmlelem.AppendChild(xmlelem1);
                                xmlelem1 = xd.CreateElement("CppProgramFun");
                                xmlelem.AppendChild(xmlelem1);
                                xmlelem1 = xd.CreateElement("VbProgramCompletion");
                                xmlelem.AppendChild(xmlelem1);
                                xmlelem1 = xd.CreateElement("VbProgramModification");
                                xmlelem.AppendChild(xmlelem1);
                                xmlelem1 = xd.CreateElement("VbProgramFun");
                                xmlelem.AppendChild(xmlelem1);
                                xd.ChildNodes.Item(1).AppendChild(xmlelem);
                                break;
                            }
                        case XMLType.StudentScore:
                            {
                                xmlelem = xd.CreateElement("StudentScore");
                                XmlAttribute xa = xd.CreateAttribute("paperId");
                                xmlelem.Attributes.Append(xa);
                                xmlelem.SetAttribute("paperId", ((string[])o)[0]);
                                xa = xd.CreateAttribute("studentId");
                                xmlelem.Attributes.Append(xa);
                                xmlelem.SetAttribute("studentId", ((string[])o)[1]);
                                xmlelem1 = xd.CreateElement("Choice");
                                xmlelem.AppendChild(xmlelem1);
                                xmlelem1 = xd.CreateElement("Completion");
                                xmlelem.AppendChild(xmlelem1);
                                xmlelem1 = xd.CreateElement("Judgment");
                                xmlelem.AppendChild(xmlelem1);
                                xmlelem1 = xd.CreateElement("Word");
                                xmlelem.AppendChild(xmlelem1);
                                xmlelem1 = xd.CreateElement("Excel");
                                xmlelem.AppendChild(xmlelem1);
                                xmlelem1 = xd.CreateElement("PowerPoint");
                                xmlelem.AppendChild(xmlelem1);
                                xmlelem1 = xd.CreateElement("CProgramCompletion");
                                xmlelem.AppendChild(xmlelem1);
                                xmlelem1 = xd.CreateElement("CProgramModification");
                                xmlelem.AppendChild(xmlelem1);
                                xmlelem1 = xd.CreateElement("CProgramFun");
                                xmlelem.AppendChild(xmlelem1);
                                xmlelem1 = xd.CreateElement("CppProgramCompletion");
                                xmlelem.AppendChild(xmlelem1);
                                xmlelem1 = xd.CreateElement("CppProgramModification");
                                xmlelem.AppendChild(xmlelem1);
                                xmlelem1 = xd.CreateElement("CppProgramFun");
                                xmlelem.AppendChild(xmlelem1);
                                xmlelem1 = xd.CreateElement("VbProgramCompletion");
                                xmlelem.AppendChild(xmlelem1);
                                xmlelem1 = xd.CreateElement("VbProgramModification");
                                xmlelem.AppendChild(xmlelem1);
                                xmlelem1 = xd.CreateElement("VbProgramFun");
                                xmlelem.AppendChild(xmlelem1);
                                xd.ChildNodes.Item(1).AppendChild(xmlelem);
                                break;
                            }
                        default:
                            {
                                break;
                            }
                    }
                    xd.Save(fileName);
                }
                else
                { 
                }
            }
        }

        public string getPaperId()
        {
            return xd.ChildNodes.Item(1).ChildNodes.Item(0).Attributes["id"].Value.ToString();
        }

        public string getStuAnsPaperId()
        {
            return xd.ChildNodes.Item(1).ChildNodes.Item(0).Attributes["pid"].Value.ToString();
        }

        public string Get(ProblemType pt)
        {
            string s = "";
            XmlNode xn = Find(xd.ChildNodes.Item(1).ChildNodes.Item(0), pt.ToString());
            if (xn != null)
            {
                foreach (XmlNode xnn in xn.ChildNodes)
                {
                    if (xnn.Name == "StudentAns")
                    {
                        s += xnn.ChildNodes.Item(0).Value + ",";
                    }
                    if (xnn.Name == "AnsPath")
                    {
                        return xnn.ChildNodes.Item(0).Value;
                    }
                }
                s = s.Remove(s.Length - 1);
            }
            return s;
        }

        List<ProblemType> ProblemTypeCollection = new List<ProblemType>() { ProblemType.Choice, ProblemType.Completion, ProblemType.Judgment, ProblemType.Word, ProblemType.Excel, ProblemType.PowerPoint, ProblemType.CProgramCompletion, ProblemType.CProgramModification, ProblemType.CProgramFun, ProblemType.CppProgramCompletion, ProblemType.CppProgramModification, ProblemType.CppProgramFun, ProblemType.VbProgramCompletion, ProblemType.VbProgramModification, ProblemType.VbProgramFun };

        /// <summary>
        /// 返回考生答案XML的所有内容
        /// </summary>
        /// <returns></returns>
        public List<IdAnswerType> GetAnswer()
        {
            List<IdAnswerType> list = new List<IdAnswerType>();
            foreach (ProblemType pt in ProblemTypeCollection)
            {
                XmlNode xn = Find(xd.ChildNodes.Item(1).ChildNodes.Item(0), pt.ToString());
                if (xn != null)
                {
                    for (int s = 0; s < xn.ChildNodes.Count; )
                    {
                        IdAnswerType iat = new IdAnswerType();
                        iat.id = Convert.ToInt32(xn.ChildNodes.Item(s).ChildNodes.Item(0).Value);
                        s++;
                        iat.pt = pt;
                        if (xn.ChildNodes.Item(s).ChildNodes.Item(0) != null)
                        {
                            iat.answer = xn.ChildNodes.Item(s).ChildNodes.Item(0).Value;
                        }
                        s++;
                        list.Add(iat);
                    }
                }
            }
            return list;
        }

        /// <summary>
        /// 返回试卷XML的所有内容
        /// </summary>
        /// <returns></returns>
        public List<IdScoreType> GetPaper()
        {
            List<IdScoreType> list = new List<IdScoreType>();
            foreach (ProblemType pt in ProblemTypeCollection)
            {
                XmlNode xn = Find(xd.ChildNodes.Item(1).ChildNodes.Item(0), pt.ToString());
                if (xn != null)
                {
                    for (int s = 0; s < xn.ChildNodes.Count; )
                    {
                        IdScoreType ist = new IdScoreType();
                        ist.id = Convert.ToInt32(xn.ChildNodes.Item(s++).ChildNodes.Item(0).Value);
                        ist.pt = pt;
                        ist.score = Convert.ToInt32(xn.ChildNodes.Item(s++).ChildNodes.Item(0).Value);
                        list.Add(ist);
                    }
                }
            }
            return list;
        }
        private XmlNode Find(XmlNode e, String name)
        {
            foreach (XmlNode xn in e.ChildNodes)
            {
                if (xn.Name == name)
                {
                    return xn;
                }
            }
            return null;
        }
        public string FindLogAns(ProblemType pt, int id)
        {
            string temp = "";
            foreach (XmlNode xn in xd.ChildNodes.Item(1).ChildNodes)
            {
                if (xn.Attributes[1].Value == pt.ToString() && xn.ChildNodes[0].LastChild.Value == id.ToString())
                {
                    temp = xn.ChildNodes[1].LastChild.Value;
                }
            }
            return temp;
        }
        public int TotleLogSecond()
        {
            string per = "00:00:00";
            string now = "00:00:00";
            int second = 0;
            foreach (XmlNode xn in xd.ChildNodes.Item(1).ChildNodes)
            {
                if (xn.Attributes[1].Value == ProblemType.Start.ToString())
                {
                    second += (int)(Convert.ToDateTime(per) - Convert.ToDateTime(now)).TotalSeconds;
                    now = xn.Attributes[0].Value;
                }
                per = xn.Attributes[0].Value;
            }
            return second;
        }

        public void AddPaper(ProblemType pt, Pid_Score ps)
        {
            XmlNode xn;
            switch (pt)
            {
                case ProblemType.Choice:
                case ProblemType.Completion:
                case ProblemType.Judgment:
                case ProblemType.Word:
                case ProblemType.Excel:
                case ProblemType.PowerPoint:
                case ProblemType.CProgramCompletion:
                case ProblemType.CProgramModification:
                case ProblemType.CProgramFun:
                case ProblemType.CppProgramCompletion:
                case ProblemType.CppProgramModification:
                case ProblemType.CppProgramFun:
                case ProblemType.VbProgramCompletion:
                case ProblemType.VbProgramModification:
                case ProblemType.VbProgramFun:
                    {
                        xn = Find(xd.ChildNodes.Item(1).ChildNodes.Item(0), pt.ToString());
                        XmlElement xmlelem;
                        xmlelem = xd.CreateElement("ProblemID");
                        xmlelem.AppendChild(xd.CreateTextNode(ps.id.ToString()));
                        xn.AppendChild(xmlelem);
                        xmlelem = xd.CreateElement("Score");
                        xmlelem.AppendChild(xd.CreateTextNode(ps.score.ToString()));
                        xn.AppendChild(xmlelem);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            xd.Save(fileName);
        }

        public void AddPaperAns(ProblemType pt, Pid_Ans pa)
        {
            XmlNode xn;
            switch (pt)
            {
                case ProblemType.Choice:
                case ProblemType.Completion:
                case ProblemType.Judgment:
                case ProblemType.Word:
                case ProblemType.Excel:
                case ProblemType.PowerPoint:
                case ProblemType.CProgramCompletion:
                case ProblemType.CProgramModification:
                case ProblemType.CProgramFun:
                case ProblemType.CppProgramCompletion:
                case ProblemType.CppProgramModification:
                case ProblemType.CppProgramFun:
                case ProblemType.VbProgramCompletion:
                case ProblemType.VbProgramModification:
                case ProblemType.VbProgramFun:
                    {
                        xn = Find(xd.ChildNodes.Item(1).ChildNodes.Item(0), pt.ToString());
                        XmlElement xmlelem;
                        xmlelem = xd.CreateElement("ProblemID");
                        xmlelem.AppendChild(xd.CreateTextNode(pa.id.ToString()));
                        xn.AppendChild(xmlelem);
                        xmlelem = xd.CreateElement("Ans");
                        xmlelem.AppendChild(xd.CreateTextNode(pa.ans));
                        xn.AppendChild(xmlelem);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            xd.Save(fileName);
        }

        public void AddStudentAns(ProblemType pt, Pid_Ans pa)
        {
            XmlNode xn;
            switch (pt)
            {
                case ProblemType.Choice:
                case ProblemType.Completion:
                case ProblemType.Judgment:
                case ProblemType.Word:
                case ProblemType.Excel:
                case ProblemType.PowerPoint:
                case ProblemType.CProgramCompletion:
                case ProblemType.CProgramModification:
                case ProblemType.CProgramFun:
                case ProblemType.CppProgramCompletion:
                case ProblemType.CppProgramModification:
                case ProblemType.CppProgramFun:
                case ProblemType.VbProgramCompletion:
                case ProblemType.VbProgramModification:
                case ProblemType.VbProgramFun:
                    {
                        xn = Find(xd.ChildNodes.Item(1).ChildNodes.Item(0), pt.ToString());
                        XmlElement xmlelem;
                        xmlelem = xd.CreateElement("ProblemID");
                        xmlelem.AppendChild(xd.CreateTextNode(pa.id.ToString()));
                        xn.AppendChild(xmlelem);
                        xmlelem = xd.CreateElement("StudentAns");
                        xmlelem.AppendChild(xd.CreateTextNode(pa.ans));
                        xn.AppendChild(xmlelem);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            xd.Save(fileName);
        }

        public void AddScore(ProblemType pt, Pid_Score ps)
        {
            XmlNode xn;
            switch (pt)
            {
                case ProblemType.Choice:
                case ProblemType.Completion:
                case ProblemType.Judgment:
                case ProblemType.Word:
                case ProblemType.Excel:
                case ProblemType.PowerPoint:
                case ProblemType.CProgramCompletion:
                case ProblemType.CProgramModification:
                case ProblemType.CProgramFun:
                case ProblemType.CppProgramCompletion:
                case ProblemType.CppProgramModification:
                case ProblemType.CppProgramFun:
                case ProblemType.VbProgramCompletion:
                case ProblemType.VbProgramModification:
                case ProblemType.VbProgramFun:
                    {
                        xn = Find(xd.ChildNodes.Item(1).ChildNodes.Item(0), pt.ToString());
                        XmlElement xmlelem;
                        xmlelem = xd.CreateElement("ProblemID");
                        xmlelem.AppendChild(xd.CreateTextNode(ps.id.ToString()));
                        xn.AppendChild(xmlelem);
                        xmlelem = xd.CreateElement("Score");
                        xmlelem.AppendChild(xd.CreateTextNode(ps.score.ToString()));
                        xn.AppendChild(xmlelem);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            xd.Save(fileName);
        }

        public void AddLog(ProblemType pt, Pid_Ans pa)
        {
            XmlNode xn;
            XmlElement xmlelem, xmlelem1;
            xmlelem = xd.CreateElement("Time");
            XmlAttribute xa = xd.CreateAttribute("value");
            xmlelem.Attributes.Append(xa);
            xmlelem.SetAttribute("value", DateTime.Now.ToLongTimeString());
            xa = xd.CreateAttribute("type");
            xmlelem.Attributes.Append(xa);
            xmlelem.SetAttribute("type", pt.ToString());
            switch (pt)
            {
                case ProblemType.Choice:
                case ProblemType.Completion:
                case ProblemType.Judgment:
                    {
                        xmlelem1 = xd.CreateElement("ProblemID");
                        xmlelem1.AppendChild(xd.CreateTextNode(pa.id.ToString()));
                        xmlelem.AppendChild(xmlelem1);
                        xmlelem1 = xd.CreateElement("StudentAns");
                        xmlelem1.AppendChild(xd.CreateTextNode(pa.ans));
                        xmlelem.AppendChild(xmlelem1);
                        break;
                    }
                case ProblemType.Word:
                case ProblemType.Excel:
                case ProblemType.PowerPoint:
                case ProblemType.CProgramCompletion:
                case ProblemType.CProgramModification:
                case ProblemType.CProgramFun:
                case ProblemType.CppProgramCompletion:
                case ProblemType.CppProgramModification:
                case ProblemType.CppProgramFun:
                case ProblemType.VbProgramCompletion:
                case ProblemType.VbProgramModification:
                case ProblemType.VbProgramFun:
                    {
                        xmlelem1 = xd.CreateElement("ProblemID");
                        xmlelem1.AppendChild(xd.CreateTextNode(pa.id.ToString()));
                        xmlelem.AppendChild(xmlelem1);
                        xmlelem1 = xd.CreateElement("AnsPath");
                        xmlelem1.AppendChild(xd.CreateTextNode(pa.ans));
                        xmlelem.AppendChild(xmlelem1);
                        break;
                    }
                case ProblemType.Start:
                case ProblemType.Blank:
                    {
                        xmlelem1 = xd.CreateElement("ProblemID");
                        xmlelem1.AppendChild(xd.CreateTextNode(pa.id.ToString()));
                        xmlelem.AppendChild(xmlelem1);
                        xmlelem1 = xd.CreateElement("StudentAns");
                        xmlelem1.AppendChild(xd.CreateTextNode(pa.ans));
                        xmlelem.AppendChild(xmlelem1);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            xd.ChildNodes[1].AppendChild(xmlelem);
            xd.Save(fileName);
        }
    }

    public enum XMLType
    {
        StudentScore,
        StudentAnswer,
        PaperAnswer,
        Paper,
        Log
    }

}
