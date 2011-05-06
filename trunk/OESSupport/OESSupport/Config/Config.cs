using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;

namespace OESSupport.Configuration
{
    public class Config
    {
        public static string Root = "";
        public static string Paper = "";
        public static string PaperPkg = "";
        public static string Word = "";
        public static string Excel = "";
        public static string PowerPoint = "";
        public static string CCompletion = "";
        public static string CModification = "";
        public static string CFunction = "";
        public static string CppCompletion = "";
        public static string CppModification = "";
        public static string CppFunction = "";
        public static string VbCompletion = "";
        public static string VbModification = "";
        public static string VbFunction = "";

        private static XmlDocument root = new XmlDocument();
        private static XmlElement xmlelem;
        private static XmlNode xmlnode;
        private static XmlNode xmltext;
        public static void InitConfig()
        {
            if (File.Exists("Config.xml"))
            {
                root.Load("Config.xml");
            }
            else
            {
                root.RemoveAll();
                //加入xml声明
                xmlnode = root.CreateNode(XmlNodeType.XmlDeclaration, "", "");
                root.AppendChild(xmlnode);
                //加入一个根元素
                xmlelem = root.CreateElement("", "Config", "");
                root.AppendChild(xmlelem);
                xmlnode = root.SelectSingleNode("Config");

                xmlelem = root.CreateElement("Root");
                xmlnode.AppendChild(xmlelem);
                xmltext = root.CreateTextNode(@"D:\OES\DataFiles\");
                xmlelem.AppendChild(xmltext);

                xmlelem = root.CreateElement("Paper");
                xmlnode.AppendChild(xmlelem);
                xmltext = root.CreateTextNode(@"Paper\");
                xmlelem.AppendChild(xmltext);

                xmlelem = root.CreateElement("PaperPkg");
                xmlnode.AppendChild(xmlelem);
                xmltext = root.CreateTextNode(@"PaperPkg\");
                xmlelem.AppendChild(xmltext);

                xmlelem = root.CreateElement("Word");
                xmlnode.AppendChild(xmlelem);
                xmltext = root.CreateTextNode(@"Word\");
                xmlelem.AppendChild(xmltext);

                xmlelem = root.CreateElement("Excel");
                xmlnode.AppendChild(xmlelem);
                xmltext = root.CreateTextNode(@"Excel\");
                xmlelem.AppendChild(xmltext);

                xmlelem = root.CreateElement("PowerPoint");
                xmlnode.AppendChild(xmlelem);
                xmltext = root.CreateTextNode(@"PowerPoint\");
                xmlelem.AppendChild(xmltext);

                xmlelem = root.CreateElement("CCompletion");
                xmlnode.AppendChild(xmlelem);
                xmltext = root.CreateTextNode(@"CCompletion\");
                xmlelem.AppendChild(xmltext);

                xmlelem = root.CreateElement("CModification");
                xmlnode.AppendChild(xmlelem);
                xmltext = root.CreateTextNode(@"CModification\");
                xmlelem.AppendChild(xmltext);


                xmlelem = root.CreateElement("CFunction");
                xmlnode.AppendChild(xmlelem);
                xmltext = root.CreateTextNode(@"CFunction\");
                xmlelem.AppendChild(xmltext);

                xmlelem = root.CreateElement("CModification");
                xmlnode.AppendChild(xmlelem);
                xmltext = root.CreateTextNode(@"CppCompletion\");
                xmlelem.AppendChild(xmltext);

                xmlelem = root.CreateElement("CppCompletion");
                xmlnode.AppendChild(xmlelem);
                xmltext = root.CreateTextNode(@"CppModification\");
                xmlelem.AppendChild(xmltext);

                xmlelem = root.CreateElement("CppModification");
                xmlnode.AppendChild(xmlelem);
                xmltext = root.CreateTextNode(@"CCompletion\");
                xmlelem.AppendChild(xmltext);

                xmlelem = root.CreateElement("CppFunction");
                xmlnode.AppendChild(xmlelem);
                xmltext = root.CreateTextNode(@"CppFunction\");
                xmlelem.AppendChild(xmltext);

                xmlelem = root.CreateElement("VbCompletion");
                xmlnode.AppendChild(xmlelem);
                xmltext = root.CreateTextNode(@"VbCompletion\");
                xmlelem.AppendChild(xmltext);

                xmlelem = root.CreateElement("VbModification");
                xmlnode.AppendChild(xmlelem);
                xmltext = root.CreateTextNode(@"VbModification\");
                xmlelem.AppendChild(xmltext);

                xmlelem = root.CreateElement("VbFunction");
                xmlnode.AppendChild(xmlelem);
                xmltext = root.CreateTextNode(@"VbFunction\");
                xmlelem.AppendChild(xmltext);

                root.Save("Config.xml");
            }
            Root = root.SelectSingleNode("Config//Root").ChildNodes.Item(0).InnerText;
            Paper = root.SelectSingleNode("Config//Paper").ChildNodes.Item(0).InnerText;
            PaperPkg = root.SelectSingleNode("Config//PaperPkg").ChildNodes.Item(0).InnerText;
            Word = root.SelectSingleNode("Config//Word").ChildNodes.Item(0).InnerText;
            Excel = root.SelectSingleNode("Config//Excel").ChildNodes.Item(0).InnerText;
            PowerPoint = root.SelectSingleNode("Config//PowerPoint").ChildNodes.Item(0).InnerText;
            CCompletion = root.SelectSingleNode("Config//CCompletion").ChildNodes.Item(0).InnerText;
            CModification = root.SelectSingleNode("Config//CModification").ChildNodes.Item(0).InnerText;
            CFunction = root.SelectSingleNode("Config//CFunction").ChildNodes.Item(0).InnerText;
            CppCompletion = root.SelectSingleNode("Config//CppCompletion").ChildNodes.Item(0).InnerText;
            CppModification = root.SelectSingleNode("Config//CppModification").ChildNodes.Item(0).InnerText;
            CppFunction = root.SelectSingleNode("Config//CppFunction").ChildNodes.Item(0).InnerText;
            VbCompletion = root.SelectSingleNode("Config//VbCompletion").ChildNodes.Item(0).InnerText;
            VbModification = root.SelectSingleNode("Config//VbModification").ChildNodes.Item(0).InnerText;
            VbFunction = root.SelectSingleNode("Config//VbFunction").ChildNodes.Item(0).InnerText;
        }

    }
}
