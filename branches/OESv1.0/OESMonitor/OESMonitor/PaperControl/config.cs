//using System;
//using System.Collections.Generic;
 
//using System.Text;
//using System.Xml;
//using System.IO;

//namespace OESMonitor.PaperControl
//{
//    public class Config
//    {        
//        private static XmlDocument root = new XmlDocument();
//        public  string stuAns;
//        public  string tmpPaper;
//        public  string DBIP;
//        public  string DBUser;
//        public  string DBPassword;
//        private XmlElement xmlelem;
//        private XmlNode xmlnode;
//        private XmlNode xmltext;

//        public Config()
//        {
//            if(File.Exists("Config.xml"))
//            {
//                root.Load("Config.xml");
//            }
//            else
//            {
//                root.RemoveAll();
//                //加入xml声明
//                xmlnode = root.CreateNode(XmlNodeType.XmlDeclaration, "", "");
//                root.AppendChild(xmlnode);
//                //加入一个根元素
//                xmlelem = root.CreateElement("", "Config", "");
//                root.AppendChild(xmlelem);
//                xmlnode = root.SelectSingleNode("Config");

//                xmlelem = root.CreateElement("stuAns");                
//                xmlnode.AppendChild(xmlelem);
//                xmltext = root.CreateTextNode(@"D:\OES\Student\");
//                xmlelem.AppendChild(xmltext);

//                xmlelem = root.CreateElement("TmpPaper");                
//                xmlnode.AppendChild(xmlelem);
//                xmltext = root.CreateTextNode(@"D:\OES\TempPaper\");
//                xmlelem.AppendChild(xmltext);

//                xmlelem = root.CreateElement("DBInfo");
//                xmlnode.AppendChild(xmlelem);
//                xmlnode = root.SelectSingleNode("Config//DBInfo");

//                xmlelem = root.CreateElement("IP");
//                xmlnode.AppendChild(xmlelem);
//                xmltext = root.CreateTextNode("IP...");
//                xmlelem.AppendChild(xmltext);

//                xmlelem = root.CreateElement("User");
//                xmlnode.AppendChild(xmlelem);
//                xmltext = root.CreateTextNode("User...");
//                xmlelem.AppendChild(xmltext);

//                xmlelem = root.CreateElement("Password");
//                xmlnode.AppendChild(xmlelem);
//                xmltext = root.CreateTextNode("Password");
//                xmlelem.AppendChild(xmltext);

//                root.Save("Config.xml");
//            }
//            stuAns=root.SelectSingleNode("Config//stuAns").ChildNodes.Item(0).InnerText;
//            tmpPaper = root.SelectSingleNode("Config//TmpPaper").ChildNodes.Item(0).InnerText;
//            DBIP = root.SelectSingleNode("Config//DBInfo//IP").ChildNodes.Item(0).InnerText;
//            DBUser = root.SelectSingleNode("Config//DBInfo//User").ChildNodes.Item(0).InnerText;
//            DBPassword = root.SelectSingleNode("Config//DBInfo//Password").ChildNodes.Item(0).InnerText;
//        }
//    }
//}

