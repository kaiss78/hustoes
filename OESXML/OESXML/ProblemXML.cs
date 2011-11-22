using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using OES.Model;

namespace OESXML
{
    public class ProblemXML
    {
        public String FileName;
        private XmlDocument xd;
        public ProblemXML(String filename,bool isReadOnly)
        {
            FileName = filename;
            xd = new XmlDocument();
            if (isReadOnly)
            {
                if (File.Exists(FileName))
                {
                    try
                    {
                        xd.Load(FileName);
                    }
                    catch
                    {
                        Console.WriteLine("文件不是有效的XML");
                    }
                }
                else
                {
                    Console.WriteLine("文件不存在");
                }
            }
            else
            {
                if (FileName != "")
                {
                    XmlElement xmlelem;
                    XmlNode xmlnode;

                    xd.RemoveAll();
                    //加入xml声明
                    xmlnode = xd.CreateNode(XmlNodeType.XmlDeclaration, "", "");
                    xd.AppendChild(xmlnode);
                    //加入一个根元素
                    xmlelem = xd.CreateElement("", "ROOT", "");
                    xd.AppendChild(xmlelem);

                    xd.Save(FileName);
                }
                else
                {
                    Console.WriteLine("文件不存在");
                }
            }
            
        }
        XmlElement xmlelem, xmlelem1;
        XmlNode xmlnode;
        public void SetChoiceProbelms(List<Choice> list)
        {
            foreach (Choice c in list)
            {
                xmlelem = xd.CreateElement("Choice");
                XmlAttribute xa = xd.CreateAttribute("ProblemId");
                xmlelem.Attributes.Append(xa);
                xmlelem.SetAttribute("ProblemId", c.problemId.ToString());
                xa = xd.CreateAttribute("OrderId");
                xmlelem.Attributes.Append(xa);
                xmlelem.SetAttribute("OrderId", c.orderId.ToString());

                xmlelem1 = xd.CreateElement("Problem");
                xmlelem1.AppendChild(xd.CreateTextNode(c.problem));
                xmlelem.AppendChild(xmlelem1);
                xmlelem1 = xd.CreateElement("OptionA");
                xmlelem1.AppendChild(xd.CreateTextNode(c.optionA));
                xmlelem.AppendChild(xmlelem1);
                xmlelem1 = xd.CreateElement("OptionB");
                xmlelem1.AppendChild(xd.CreateTextNode(c.optionB));
                xmlelem.AppendChild(xmlelem1);
                xmlelem1 = xd.CreateElement("OptionC");
                xmlelem1.AppendChild(xd.CreateTextNode(c.optionC));
                xmlelem.AppendChild(xmlelem1);
                xmlelem1 = xd.CreateElement("OptionD");
                xmlelem1.AppendChild(xd.CreateTextNode(c.optionD));
                xmlelem.AppendChild(xmlelem1);

                xd.ChildNodes.Item(1).AppendChild(xmlelem);
            }
            xd.Save(FileName);
        }
        public void SetCompletionProbelms(List<Completion> list)
        {
            foreach (Completion c in list)
            {
                xmlelem = xd.CreateElement("Completion");
                XmlAttribute xa = xd.CreateAttribute("ProblemId");
                xmlelem.Attributes.Append(xa);
                xmlelem.SetAttribute("ProblemId", c.problemId.ToString());
                xa = xd.CreateAttribute("OrderId");
                xmlelem.Attributes.Append(xa);
                xmlelem.SetAttribute("OrderId", c.orderId.ToString());

                xmlelem1 = xd.CreateElement("Problem");
                xmlelem1.AppendChild(xd.CreateTextNode(c.problem));
                xmlelem.AppendChild(xmlelem1);

                xd.ChildNodes.Item(1).AppendChild(xmlelem);
            }
            xd.Save(FileName);
        }
        public void SetJudgeProbelms(List<Judge> list)
        {
            foreach (Judge c in list)
            {
                xmlelem = xd.CreateElement("Tof");
                XmlAttribute xa = xd.CreateAttribute("ProblemId");
                xmlelem.Attributes.Append(xa);
                xmlelem.SetAttribute("ProblemId", c.problemId.ToString());
                xa = xd.CreateAttribute("OrderId");
                xmlelem.Attributes.Append(xa);
                xmlelem.SetAttribute("OrderId", c.orderId.ToString());

                xmlelem1 = xd.CreateElement("Problem");
                xmlelem1.AppendChild(xd.CreateTextNode(c.problem));
                xmlelem.AppendChild(xmlelem1);

                xd.ChildNodes.Item(1).AppendChild(xmlelem);
            }
            xd.Save(FileName);
        }
        public void SetWordProbelm(OfficeWord obj)
        {
            xmlelem = xd.CreateElement("Word");
            XmlAttribute xa = xd.CreateAttribute("ProblemId");
            xmlelem.Attributes.Append(xa);
            xmlelem.SetAttribute("ProblemId", obj.problemId.ToString());
            xa = xd.CreateAttribute("OrderId");
            xmlelem.Attributes.Append(xa);
            xmlelem.SetAttribute("OrderId", obj.orderId.ToString());

            xmlelem1 = xd.CreateElement("Problem");
            xmlelem1.AppendChild(xd.CreateTextNode(obj.problem));
            xmlelem.AppendChild(xmlelem1);

            xd.ChildNodes.Item(1).AppendChild(xmlelem);
            
            xd.Save(FileName);
        }
        public void SetExcelProbelm(OfficeExcel obj)
        {
            xmlelem = xd.CreateElement("Excel");
            XmlAttribute xa = xd.CreateAttribute("ProblemId");
            xmlelem.Attributes.Append(xa);
            xmlelem.SetAttribute("ProblemId", obj.problemId.ToString());
            xa = xd.CreateAttribute("OrderId");
            xmlelem.Attributes.Append(xa);
            xmlelem.SetAttribute("OrderId", obj.orderId.ToString());

            xmlelem1 = xd.CreateElement("Problem");
            xmlelem1.AppendChild(xd.CreateTextNode(obj.problem));
            xmlelem.AppendChild(xmlelem1);

            xd.ChildNodes.Item(1).AppendChild(xmlelem);

            xd.Save(FileName);
        }
        public void SetPowerPointProbelm(OfficePowerPoint obj)
        {
            xmlelem = xd.CreateElement("PowerPoint");
            XmlAttribute xa = xd.CreateAttribute("ProblemId");
            xmlelem.Attributes.Append(xa);
            xmlelem.SetAttribute("ProblemId", obj.problemId.ToString());
            xa = xd.CreateAttribute("OrderId");
            xmlelem.Attributes.Append(xa);
            xmlelem.SetAttribute("OrderId", obj.orderId.ToString());

            xmlelem1 = xd.CreateElement("Problem");
            xmlelem1.AppendChild(xd.CreateTextNode(obj.problem));
            xmlelem.AppendChild(xmlelem1);

            xd.ChildNodes.Item(1).AppendChild(xmlelem);

            xd.Save(FileName);
        }
        public void SetPCompletionProbelm(PCompletion obj)
        {
            xmlelem = xd.CreateElement("ProgramCompletion");
            XmlAttribute xa = xd.CreateAttribute("ProblemId");
            xmlelem.Attributes.Append(xa);
            xmlelem.SetAttribute("ProblemId", obj.problemId.ToString());
            xa = xd.CreateAttribute("OrderId");
            xmlelem.Attributes.Append(xa);
            xmlelem.SetAttribute("OrderId", obj.orderId.ToString());

            xmlelem1 = xd.CreateElement("Problem");
            xmlelem1.AppendChild(xd.CreateTextNode(obj.problem));
            xmlelem.AppendChild(xmlelem1);

            xd.ChildNodes.Item(1).AppendChild(xmlelem);

            xd.Save(FileName);
        }
        public void SetPModifProbelm(PModif obj)
        {
            xmlelem = xd.CreateElement("ProgramModification");
            XmlAttribute xa = xd.CreateAttribute("ProblemId");
            xmlelem.Attributes.Append(xa);
            xmlelem.SetAttribute("ProblemId", obj.problemId.ToString());
            xa = xd.CreateAttribute("OrderId");
            xmlelem.Attributes.Append(xa);
            xmlelem.SetAttribute("OrderId", obj.orderId.ToString());

            xmlelem1 = xd.CreateElement("Problem");
            xmlelem1.AppendChild(xd.CreateTextNode(obj.problem));
            xmlelem.AppendChild(xmlelem1);

            xd.ChildNodes.Item(1).AppendChild(xmlelem);

            xd.Save(FileName);
        }
        public void SetPFunctionProbelm(PFunction obj)
        {
            xmlelem = xd.CreateElement("ProgramFun");
            XmlAttribute xa = xd.CreateAttribute("ProblemId");
            xmlelem.Attributes.Append(xa);
            xmlelem.SetAttribute("ProblemId", obj.problemId.ToString());
            xa = xd.CreateAttribute("OrderId");
            xmlelem.Attributes.Append(xa);
            xmlelem.SetAttribute("OrderId", obj.orderId.ToString());

            xmlelem1 = xd.CreateElement("Problem");
            xmlelem1.AppendChild(xd.CreateTextNode(obj.problem));
            xmlelem.AppendChild(xmlelem1);

            xd.ChildNodes.Item(1).AppendChild(xmlelem);

            xd.Save(FileName);
        }
        public List<Choice> GetChoiceProbelms()
        {
            List<Choice> list = new List<Choice>();
            foreach (XmlNode xnn in xd.ChildNodes.Item(1).ChildNodes)
            {
                if (xnn.Name == "Choice")
                {
                    Choice c = new Choice();
                    c.problemId = Convert.ToInt32(xnn.Attributes["ProblemId"].Value);
                    c.orderId = Convert.ToInt32(xnn.Attributes["OrderId"].Value);
                    foreach (XmlNode option in xnn.ChildNodes)
                    {
                        switch (option.Name)
                        {
                            case "Problem":
                                c.problem = option.ChildNodes.Item(0).Value;
                                break;
                            case "OptionA":
                                c.optionA = option.ChildNodes.Item(0).Value;
                                break;
                            case "OptionB":
                                c.optionB = option.ChildNodes.Item(0).Value;
                                break;
                            case "OptionC":
                                c.optionC = option.ChildNodes.Item(0).Value;
                                break;
                            case "OptionD":
                                c.optionD = option.ChildNodes.Item(0).Value;
                                break;
                        }
                    }
                    list.Add(c);
                }
            }
            return list;
        }
        public List<Completion> GetCompletionProbelms()
        {
            List<Completion> list = new List<Completion>();
            foreach (XmlNode xnn in xd.ChildNodes.Item(1).ChildNodes)
            {
                if (xnn.Name == "Completion")
                {
                    Completion c = new Completion();
                    c.problemId = Convert.ToInt32(xnn.Attributes["ProblemId"].Value);
                    c.orderId = Convert.ToInt32(xnn.Attributes["OrderId"].Value);
                    foreach (XmlNode option in xnn.ChildNodes)
                    {
                        switch (option.Name)
                        {
                            case "Problem":
                                c.problem = option.ChildNodes.Item(0).Value;
                                break;
                        }
                    }
                    list.Add(c);
                }
            }
            return list;
        }
        public List<Judge> GetJudgeProbelms()
        {
            List<Judge> list = new List<Judge>();
            foreach (XmlNode xnn in xd.ChildNodes.Item(1).ChildNodes)
            {
                if (xnn.Name == "Tof")
                {
                    Judge c = new Judge();
                    c.problemId = Convert.ToInt32(xnn.Attributes["ProblemId"].Value);
                    c.orderId = Convert.ToInt32(xnn.Attributes["OrderId"].Value);
                    foreach (XmlNode option in xnn.ChildNodes)
                    {
                        switch (option.Name)
                        {
                            case "Problem":
                                c.problem = option.ChildNodes.Item(0).Value;
                                break;
                        }
                    }
                    list.Add(c);
                }
            }
            return list;
        }
        public OfficeWord GetWordProbelm()
        {
            OfficeWord obj = new OfficeWord();
            foreach (XmlNode xnn in xd.ChildNodes.Item(1).ChildNodes)
            {
                if (xnn.Name == "Word")
                {
                    obj.problemId = Convert.ToInt32(xnn.Attributes["ProblemId"].Value);
                    obj.orderId = Convert.ToInt32(xnn.Attributes["OrderId"].Value);
                    foreach (XmlNode option in xnn.ChildNodes)
                    {
                        switch (option.Name)
                        {
                            case "Problem":
                                obj.problem = option.ChildNodes.Item(0).Value;
                                break;
                        }
                    }
                }
            }
            return obj;
        }
        public OfficeExcel GetExcelProbelm()
        {
            OfficeExcel obj = new OfficeExcel();
            foreach (XmlNode xnn in xd.ChildNodes.Item(1).ChildNodes)
            {
                if (xnn.Name == "Excel")
                {
                    obj.problemId = Convert.ToInt32(xnn.Attributes["ProblemId"].Value);
                    obj.orderId = Convert.ToInt32(xnn.Attributes["OrderId"].Value);
                    foreach (XmlNode option in xnn.ChildNodes)
                    {
                        switch (option.Name)
                        {
                            case "Problem":
                                obj.problem = option.ChildNodes.Item(0).Value;
                                break;
                        }
                    }
                }
            }
            return obj;
        }
        public OfficePowerPoint GetPowerPointProbelm()
        {
            OfficePowerPoint obj = new OfficePowerPoint();
            foreach (XmlNode xnn in xd.ChildNodes.Item(1).ChildNodes)
            {
                if (xnn.Name == "PowerPoint")
                {
                    obj.problemId = Convert.ToInt32(xnn.Attributes["ProblemId"].Value);
                    obj.orderId = Convert.ToInt32(xnn.Attributes["OrderId"].Value);
                    foreach (XmlNode option in xnn.ChildNodes)
                    {
                        switch (option.Name)
                        {
                            case "Problem":
                                obj.problem = option.ChildNodes.Item(0).Value;
                                break;
                        }
                    }
                }
            }
            return obj;
        }
        public PCompletion GetPCompletionProbelm()
        {
            PCompletion obj = new PCompletion();
            foreach (XmlNode xnn in xd.ChildNodes.Item(1).ChildNodes)
            {
                if (xnn.Name == "ProgramCompletion")
                {
                    obj.problemId = Convert.ToInt32(xnn.Attributes["ProblemId"].Value);
                    obj.orderId = Convert.ToInt32(xnn.Attributes["OrderId"].Value);
                    foreach (XmlNode option in xnn.ChildNodes)
                    {
                        switch (option.Name)
                        {
                            case "Problem":
                                obj.problem = option.ChildNodes.Item(0).Value;
                                break;
                        }
                    }
                }
            }
            return obj;
        }
        public PModif GetPModifProbelm()
        {
            PModif obj = new PModif();
            foreach (XmlNode xnn in xd.ChildNodes.Item(1).ChildNodes)
            {
                if (xnn.Name == "ProgramModification")
                {
                    obj.problemId = Convert.ToInt32(xnn.Attributes["ProblemId"].Value);
                    obj.orderId = Convert.ToInt32(xnn.Attributes["OrderId"].Value);
                    foreach (XmlNode option in xnn.ChildNodes)
                    {
                        switch (option.Name)
                        {
                            case "Problem":
                                obj.problem = option.ChildNodes.Item(0).Value;
                                break;
                        }
                    }
                }
            }
            return obj;
        }
        public PFunction GetPFunctionProbelm()
        {
            PFunction obj = new PFunction();
            foreach (XmlNode xnn in xd.ChildNodes.Item(1).ChildNodes)
            {
                if (xnn.Name == "ProgramFun")
                {
                    obj.problemId = Convert.ToInt32(xnn.Attributes["ProblemId"].Value);
                    obj.orderId = Convert.ToInt32(xnn.Attributes["OrderId"].Value);
                    foreach (XmlNode option in xnn.ChildNodes)
                    {
                        switch (option.Name)
                        {
                            case "Problem":
                                obj.problem = option.ChildNodes.Item(0).Value;
                                break;
                        }
                    }
                }
            }
            return obj;
        }
    }
}
