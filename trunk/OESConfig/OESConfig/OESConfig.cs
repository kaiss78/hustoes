using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using log4net;

namespace OES
{
    public class OESConfig
    {
        //日志记录
        private ILog log = log4net.LogManager.GetLogger(typeof(Program));
        //配置文件
        private XmlDocument xd = new XmlDocument();
        //文件路径
        private string filePath = "";

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="fileName">xml配置文件名</param>
        public OESConfig(string fileName):this(fileName,null)
        {
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="fileName">xml配置文件名</param>
        /// <param name="defsetting">默认配置</param>
        public OESConfig(string fileName,string[,] defsetting)
        {
            filePath = Environment.CurrentDirectory+"\\"+fileName;
            if (String.IsNullOrEmpty(fileName))
            {
                log.Error("FileName is Null or Empty.");
            }
            else
            {

                XmlElement xmlelem;
                XmlNode xmlnode;
                if (File.Exists(fileName))
                {
                    try
                    {
                        xd.Load(fileName);
                        log.Info("Load config file successfully.");
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
                        log.Warn("The file is illegal, but we recreate one.");
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
                    log.Warn("The file is not exist, but we create one.");

                    if (defsetting != null)
                    {
                        for (int i = 0; i < defsetting.GetLength(0); i++)
                        {
                            this[defsetting[i,0]] = defsetting[i,1];
                        }
                    }
                }
            }
            
        }

        /// <summary>
        /// 通过index索引需要的字段
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string this[string index]
        {
            get
            {
                return getXMLDetail(index);
            }
            set
            {
                if (String.IsNullOrEmpty(index))
                {
                    log.Error("Index is Null or Empty.");
                }
                else
                {
                    setXMLDetail(index, value);//如果value为空，则删除该节点!
                }
            }
        }

        /// <summary>
        /// 通过节点名字，查找XML节点
        /// </summary>
        /// <param name="e">父节点</param>
        /// <param name="name">子节点名称</param>
        /// <returns>子节点，若不存在则返回null</returns>
        private XmlNode Find(XmlNode e, String name)
        {
            if (e.ChildNodes == null) return null;
            foreach (XmlNode xn in e.ChildNodes)
            {
                if (xn.Name == name)
                {
                    return xn;
                }
            }
            return null;
        }

        /// <summary>
        /// 获取节点内容
        /// </summary>
        /// <param name="e">当前节点</param>
        /// <returns>节点内容</returns>
        private string Get(XmlNode e)
        {
            return e.ChildNodes.Item(0).Value;
        }

        /// <summary>
        /// 设置节点内容
        /// </summary>
        /// <param name="e">当前节点</param>
        /// <param name="value">节点内容</param>
        private void Set(XmlNode e,string value)
        {
            e.ChildNodes.Item(0).Value = value;
            xd.Save(filePath);
        }

        /// <summary>
        /// 添加一个节点
        /// </summary>
        /// <param name="e">父节点</param>
        /// <param name="index">节点名称</param>
        /// <param name="value">节点内容</param>
        private void Add(XmlNode e,string index, string value)
        {
            XmlElement xe = xd.CreateElement(index);
            xe.AppendChild(xd.CreateTextNode(value));
            e.AppendChild(xe);
            xd.Save(filePath);
        }

        /// <summary>
        /// 删除一个节点
        /// </summary>
        /// <param name="e">父节点</param>
        /// <param name="index">子节点名称</param>
        private void Del(XmlNode e,string index)
        {
            e.RemoveChild(Find(e, index));
            xd.Save(filePath);
        }

        /// <summary>
        /// 获取节点内容（检查节点不存在问题）
        /// </summary>
        /// <param name="index">节点名称</param>
        /// <returns>节点内容</returns>
        private string getXMLDetail(string index)
        {
            XmlNode xn;
            string result="";
            xn = Find(xd.ChildNodes.Item(1), index);
            if (xn == null)
            {
                Add(xd.ChildNodes.Item(1),index, "");
                log.Warn("The node can not found, but we create one.");
            }
            else
            {
                result = Get(xn);
                log.Info("Config string found!");
            }
            return result;
        }

        /// <summary>
        /// 设置节点内容（检查节点不存在问题）
        /// </summary>
        /// <param name="index">节点名称</param>
        /// <param name="value">节点内容</param>
        private void setXMLDetail(string index, string value)
        {
            XmlNode xn;
            if (String.IsNullOrEmpty(value))
            {
                xn=xd.ChildNodes.Item(1);
                if(xn!=null)
                    Del(xn, index);
            }
            else
            {
                xn = Find(xd.ChildNodes.Item(1), index);
                if (xn == null)
                {
                    Add(xd.ChildNodes.Item(1), index, value);
                    log.Warn("The node can not found, but we create one.");
                }
                else
                {
                    Set(xn, value);
                    log.Info("Config string set!");
                }
            }
        }

        /// <summary>
        /// 获取当前文件中的所有配置
        /// </summary>
        /// <returns>所有配置的一个Dictionary</returns>
        public Dictionary<string,string> GetAllConfig()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            XmlNode e = xd.ChildNodes.Item(1);
            if (e.ChildNodes == null) return dict;
            foreach (XmlNode xn in e.ChildNodes)
            {
                dict.Add(xn.Name, xn.ChildNodes.Item(0).Value);
            }
            return dict;
        }

        /// <summary>
        /// 清空配置文件
        /// </summary>
        public void Clear()
        {
            xd.RemoveAll();
        }

        
    }
}
