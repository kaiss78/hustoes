using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OES.Model;
using System.Xml;
using System.Collections;
using System.IO;

namespace OESAnalyse
{
    class Percentage
    {
        public String type;
        public String ID;
        public Int32 total;
        public Int32 right;
        public Int32 percentage;
        public ArrayList printPercentage(string path,List<Student>myList ,string paperID)
        {
            ArrayList list = new ArrayList();
            Percentage oneStu1 = new Percentage();
            oneStu1.type = "";
            oneStu1.ID = "";
            oneStu1.total = 0;
            oneStu1.right = 0;
            oneStu1.percentage = 0;
            list.Add(oneStu1);
            DirectoryInfo root = new DirectoryInfo(path);
            DirectoryInfo[] stu = root.GetDirectories("*");
            for (int j = 0; j < stu.Length; j++)
            {
                FileInfo[] result = stu[j].GetFiles("Result*");
                if (result.Length == 1)
                {
                    XmlDocument document = new XmlDocument();
                    document.Load(result[0].FullName);
                    XmlNode root1 = document.DocumentElement;
                    XmlNode node, node1, node2, node3;
                    int i;
                    node = root1.FirstChild.FirstChild;
                    node1 = node.FirstChild;
                    node2 = node.NextSibling.FirstChild;
                    node3 = node.NextSibling.NextSibling.FirstChild;
                    for (int x = 0; x < myList.Count; x++)
                    {
                        if (root1.FirstChild.Attributes["studentId"].Value == myList[x].ID && root1.FirstChild.Attributes["paperId"].Value == myList[x].examID)
                        {
                            node1 = node.FirstChild;
                            if (node1.FirstChild != null)
                            {
                                while (node1 != null)
                                {
                                    Percentage oneStu = new Percentage();
                                    oneStu.ID = node1.InnerText;
                                    oneStu.total = 1;
                                    oneStu.type = node.Name;
                                    if ((Convert.ToInt32(node1.NextSibling.InnerText)) != 0)
                                        oneStu.right = 1;
                                    else
                                        oneStu.right = 0;
                                    oneStu.percentage = 100 * oneStu.right / oneStu.total;
                                    int c;
                                    for (c = 1; c <= list.Count; c++)
                                    {
                                        if (((Percentage)list[c - 1]).ID == oneStu.ID && ((Percentage)list[c - 1]).type == oneStu.type)
                                        {
                                            ((Percentage)list[c - 1]).total++;
                                            if ((Convert.ToInt32(node1.NextSibling.InnerText)) != 0)
                                                ((Percentage)list[c - 1]).right++;
                                            ((Percentage)list[c - 1]).percentage = 100 * ((Percentage)list[c - 1]).right / ((Percentage)list[c - 1]).total;
                                            break;
                                        }
                                        if (((Percentage)list[c - 1]).ID != oneStu.ID && list.Count == c)
                                        {
                                            list.Add(oneStu);
                                            break;
                                        }
                                    }
                                    node1 = node1.NextSibling.NextSibling;
                                }
                            }
                            for (i = 0; i <= 9; i++)
                            {
                                Percentage oneStu = new Percentage();
                                oneStu.ID = node2.InnerText;
                                oneStu.total = 1;
                                oneStu.type = node.NextSibling.Name;
                                if ((Convert.ToInt32(node2.NextSibling.InnerText)) != 0)
                                    oneStu.right = 1;
                                else
                                    oneStu.right = 0;
                                oneStu.percentage = 100 * oneStu.right / oneStu.total;
                                int c;
                                for (c = 1; c <= list.Count; c++)
                                {
                                    if (((Percentage)list[c - 1]).ID == oneStu.ID && ((Percentage)list[c - 1]).type == oneStu.type)
                                    {
                                        ((Percentage)list[c - 1]).total++;
                                        if ((Convert.ToInt32(node2.NextSibling.InnerText)) != 0)
                                            ((Percentage)list[c - 1]).right++;
                                        ((Percentage)list[c - 1]).percentage = 100 * ((Percentage)list[c - 1]).right / ((Percentage)list[c - 1]).total;
                                        break;
                                    }
                                    if (((Percentage)list[c - 1]).ID != oneStu.ID && list.Count == c)
                                    {
                                        list.Add(oneStu);
                                        break;
                                    }
                                }
                                node2 = node2.NextSibling.NextSibling;
                            }
                            for (i = 0; i <= 9; i++)
                            {
                                Percentage oneStu = new Percentage();
                                oneStu.ID = node3.InnerText;
                                oneStu.total = 1;
                                oneStu.type = node.NextSibling.NextSibling.Name;
                                if ((Convert.ToInt32(node3.NextSibling.InnerText)) != 0)
                                    oneStu.right = 1;
                                else
                                    oneStu.right = 0;
                                oneStu.percentage = 100 * oneStu.right / oneStu.total;
                                int c;
                                for (c = 1; c <= list.Count; c++)
                                {
                                    if (((Percentage)list[c - 1]).ID == oneStu.ID && ((Percentage)list[c - 1]).type == oneStu.type)
                                    {
                                        ((Percentage)list[c - 1]).total++;
                                        if ((Convert.ToInt32(node3.NextSibling.InnerText)) != 0)
                                            ((Percentage)list[c - 1]).right++;
                                        ((Percentage)list[c - 1]).percentage = 100 * ((Percentage)list[c - 1]).right / ((Percentage)list[c - 1]).total;
                                        break;
                                    }
                                    if (((Percentage)list[c - 1]).ID != oneStu.ID && list.Count == c)
                                    {
                                        list.Add(oneStu);
                                        break;
                                    }
                                }
                                node3 = node3.NextSibling.NextSibling;
                            }
                            break;
                        }
                    }
                }
            }
            return list;
        }
            
    }
    }
