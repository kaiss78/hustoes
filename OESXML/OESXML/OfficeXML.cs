using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Windows.Forms;
using System.Collections;

namespace OESXML
{
    public class OfficeXML
    {
        //表示每个考点的路径 例如 段->字->颜色
        public List<OfficeElement> Path = new List<OfficeElement>();
        //输出成Path考点集合
        public List<List<OfficeElement>> AnsPaths = new List<List<OfficeElement>>();
        //OfficeXML文件的路径
        public String FileName;
        //初始化OfficeXML对象，需要指定文件路径
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
                      xd.Load(filename);
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

        //根据XML节点的名称查找parent节点下的子节点
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

        //将每个考点路径加入XML文件,节点存在继续遍历,不存在新建路径上的节点
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

        //获取考点Path的集合,并存入AnsPaths里面
        public void getAllAnsPath()
        {
            XmlDocument xd =new XmlDocument();
            xd.Load(FileName);
            getAllAnsPathDFS(xd.ChildNodes.Item(1));
        }

        //利用深度搜索方式获取到所有考点路径
        private void getAllAnsPathDFS(XmlNode xn)
        {
            //当前节点已经为叶子节点,表明考点路径已经获取完整
            if (xn.ChildNodes.Count == 0)
            {
                AnsPaths.Add(new List<OfficeElement>(Path));
            }
            //当前节点还有子节点,重复调用自己
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

        //另外一种对OfficeXML读取方式,获取返回TreeNode形式
        public TreeNode getAllAnsPath_Tree()
        {
            XmlDocument xd = new XmlDocument();
            xd.Load(FileName);
            TreeNode res = new TreeNode();
            res = getAllAnsPathDFS_Tree(xd.ChildNodes.Item(1));
            return res;
        }

        //利用深度搜索方式获取到所有考点路径
        private TreeNode getAllAnsPathDFS_Tree(XmlNode xn)
        {
            TreeNode res = new TreeNode();
            if (xn.Name == "ROOT")
                res.Tag = new OfficeElement("ROOT", "0");
            else
                res.Tag = new OfficeElement(xn.Name, xn.Attributes["value"].Value);
            foreach (XmlNode xxn in xn.ChildNodes)
                res.Nodes.Add(getAllAnsPathDFS_Tree(xxn));
            return res;
        }
    }

    //每个Office元素结构
    public class OfficeElement
    {
        //Office属性名称
        public String AttribName;
        //Office属性值
        public String AttribValue;
        //Office构造函数
        public OfficeElement(String AttN,String AttV)
        {
            AttribName = AttN;
            AttribValue = AttV;
        }
       
    }
}
