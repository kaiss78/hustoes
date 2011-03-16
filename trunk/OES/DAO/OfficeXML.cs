using System;
using System.Collections.Generic;
 
using System.Text;
using System.Xml;
using System.IO;

namespace OESXML
{
    public class OfficeXML
    {
        public List<OfficeElement> Path = new List<OfficeElement>();
        public List<List<OfficeElement>> AnsPaths = new List<List<OfficeElement>>();
        public String FileName;
        public OfficeXML(String filename)
        {
            FileName = filename;
            XmlDocument xd = new XmlDocument();
            if (FileName != "")
            {
                XmlElement xmlelem;
                XmlNode xmlnode;
                if (File.Exists(FileName))
                {
                    try
                    {
                        xd.Load(FileName);
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
                xd.Save(FileName);
            }
            
        }
        private XmlNode findNode(XmlNode parent, OfficeElement targed)
        {
            foreach (XmlNode xn in parent.ChildNodes)
            {
                if (xn.Name == targed.AttribName && xn.Attributes["value"].Value == targed.AttribValue)
                {
                    return xn;
                }
            }
            return null;
        }

        public void addPathtoXML()
        {
            XmlDocument xd = new XmlDocument();
            xd.Load(FileName);
            XmlNode current = xd.ChildNodes.Item(1);
            XmlNode preview = xd.ChildNodes.Item(1);
            XmlElement temp;
            foreach (OfficeElement oe in Path)
            {
                if (current != null)
                {
                    current = findNode(current, oe);
                    if (current != null) preview = current;
                    else
                    {
                        temp = xd.CreateElement(oe.AttribName);
                        temp.SetAttribute("value", oe.AttribValue);
                        preview = preview.AppendChild(temp);
                    }
                }
                else
                {
                    temp = xd.CreateElement(oe.AttribName);
                    temp.SetAttribute("value", oe.AttribValue);
                    preview = preview.AppendChild(temp);
                }
            }
            xd.Save(FileName);
            Path.Clear();
        }
        public void getAllAnsPath()
        {
            XmlDocument xd =new XmlDocument();
            xd.Load(FileName);
            getAllAnsPathDFS(xd.ChildNodes.Item(1));
        }
        private void getAllAnsPathDFS(XmlNode xn)
        {
            if (xn.ChildNodes.Count == 0)
            {
                AnsPaths.Add(new List<OfficeElement>(Path));
            }
            else
            {
                foreach (XmlNode xxn in xn.ChildNodes)
                {
                    Path.Add(new OfficeElement(xxn.Name, xxn.Attributes["value"].Value));
                    getAllAnsPathDFS(xxn);
                    Path.RemoveAt(Path.Count - 1);
                }
            }
        }
    }
    public class OfficeElement
    {
        public String AttribName;
        public String AttribValue;
        public OfficeElement(String AttN,String AttV)
        {
            AttribName = AttN;
            AttribValue = AttV;
        }
       
    }
}
