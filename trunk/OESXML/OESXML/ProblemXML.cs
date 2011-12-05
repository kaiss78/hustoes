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
        private XmlDocument xd = null;
        public bool isError=false;
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
                        isError = true;
                    }
                }
                else
                {
                    Console.WriteLine("文件不存在");
                    isError = true;
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
                    isError = true;
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
        public void SetWordProbelm(List<OfficeWord> list)
        {
            foreach (OfficeWord c in list)
            {
                xmlelem = xd.CreateElement("Word");
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
        public void SetExcelProbelm(List<OfficeExcel> list)
        {
            foreach (OfficeExcel c in list)
            {
                xmlelem = xd.CreateElement("Excel");
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
        public void SetPowerPointProbelm(List<OfficePowerPoint> list)
        {
            foreach (OfficePowerPoint c in list)
            {
                xmlelem = xd.CreateElement("PowerPoint");
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
        public void SetPCompletionProbelm(List<PCompletion> list)
        {
            foreach (PCompletion c in list)
            {
                xmlelem = xd.CreateElement("ProgramCompletion");
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
        public void SetPModifProbelm(List<PModif> list)
        {
            foreach (PModif c in list)
            {
                xmlelem = xd.CreateElement("ProgramModification");
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
        public void SetPFunctionProbelm(List<PFunction> list)
        {
            foreach (PFunction c in list)
            {
                xmlelem = xd.CreateElement("ProgramFun");
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
        public List<OfficeWord> GetWordProbelm()
        {
            List<OfficeWord> list = new List<OfficeWord>();
            foreach (XmlNode xnn in xd.ChildNodes.Item(1).ChildNodes)
            {
                if (xnn.Name == "Word")
                {
                    OfficeWord c = new OfficeWord();
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
                        list.Add(c);
                    }
                }
            }
            return list;
        }
        public List<OfficeExcel> GetExcelProbelm()
        {
            List<OfficeExcel> list = new List<OfficeExcel>();
            foreach (XmlNode xnn in xd.ChildNodes.Item(1).ChildNodes)
            {
                if (xnn.Name == "Excel")
                {
                    OfficeExcel c = new OfficeExcel();
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
        public List<OfficePowerPoint> GetPowerPointProbelm()
        {
            List<OfficePowerPoint> list = new List<OfficePowerPoint>();
            foreach (XmlNode xnn in xd.ChildNodes.Item(1).ChildNodes)
            {
                if (xnn.Name == "PowerPoint")
                {
                    OfficePowerPoint c = new OfficePowerPoint();
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
        public List<PCompletion> GetPCompletionProbelm()
        {
            List<PCompletion> list = new List<PCompletion>();
            foreach (XmlNode xnn in xd.ChildNodes.Item(1).ChildNodes)
            {
                if (xnn.Name == "CProgramCompletion")
                {
                    PCompletion c = new PCompletion(ProblemType.CProgramCompletion);
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
                else if(xnn.Name == "CppProgramCompletion")
                {
                    PCompletion c = new PCompletion(ProblemType.CppProgramCompletion);
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
                else if (xnn.Name == "VbProgramCompletion")
                {
                    PCompletion c = new PCompletion(ProblemType.VbProgramCompletion);
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
        public List<PModif> GetPModifProbelm()
        {
            List<PModif> list = new List<PModif>();
            foreach (XmlNode xnn in xd.ChildNodes.Item(1).ChildNodes)
            {
                if (xnn.Name == "CProgramModification")
                {
                    PModif c = new PModif(ProblemType.CProgramModification);
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
                else if (xnn.Name == "CppProgramModification")
                {
                    PModif c = new PModif(ProblemType.CppProgramModification);
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
                else if (xnn.Name == "VbProgramModification")
                {
                    PModif c = new PModif(ProblemType.VbProgramModification);
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
        public List<PFunction> GetPFunctionProbelm()
        {
            List<PFunction> list = new List<PFunction>();

            foreach (XmlNode xnn in xd.ChildNodes.Item(1).ChildNodes)
            {
                if (xnn.Name == "CProgramFun")
                {
                    PFunction c = new PFunction(ProblemType.CProgramFun);
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
                else if (xnn.Name == "CppProgramFun")
                {
                    PFunction c = new PFunction(ProblemType.CppProgramFun);
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
                else if (xnn.Name == "VbProgramFun")
                {
                    PFunction c = new PFunction(ProblemType.VbProgramFun);
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
    }
}
