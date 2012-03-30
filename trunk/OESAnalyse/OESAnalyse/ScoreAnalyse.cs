using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;

namespace OESAnalyse
{
    class ScoreAnalyse
    {
        private int stuNum;
        public int StuNum
        {
            get
            {
                return stuNum;
            }
            set
            {
                stuNum = value;
            }
        }
        private float[] scoreDistribution;
        public float[] ScoreDistribution
        {
            get
            {
                return scoreDistribution;
            }
            set
            {
                scoreDistribution = value;
            }
        }      //scoreDistribution[0]是90分以上，接着是80至90,70至80,60至70和不及格

        XmlDocument document = new XmlDocument();
        XmlElement element;

        public string getStuID(String filePath)
        {
            document.Load(filePath);
            element = document.DocumentElement;
            XmlNode node = element.FirstChild;

            return node.Attributes["studentId"].Value;
        }

        public void getStuNum(String path)
        {
            DirectoryInfo root = new DirectoryInfo(path);
            DirectoryInfo[] stu = root.GetDirectories("*");

            for (int i = 0; i < stu.Length; i++)
            {
                FileInfo[] result = stu[i].GetFiles("Result*");
                if (result.Length == 1)
                    stuNum++;
            }
        }

        public int getScore(String filePath)
        {
            XmlNode node1, node2;
            int score = 0;
            document.Load(filePath);
            element = document.DocumentElement;

            if (element.FirstChild.HasChildNodes)
            {
                node1 = element.FirstChild.FirstChild;
                do
                {
                    while (!node1.HasChildNodes)
                    {
                        node1 = node1.NextSibling;
                    }
                    node2 = node1.FirstChild.NextSibling;
                    score += Convert.ToInt32(node2.InnerText);
                    while (node2.NextSibling != null)
                    {
                        node2 = node2.NextSibling.NextSibling;
                        score += Convert.ToInt32(node2.InnerText);
                    }
                    node1 = node1.NextSibling;
                    while (!node1.HasChildNodes)
                    {
                        node1 = node1.NextSibling;
                        if (node1 == null)
                            break;
                    }
                }
                while (node1 != null);

            }
            return score;
        }

        public void getDisNum(String path)
        {
            DirectoryInfo root = new DirectoryInfo(path);
            DirectoryInfo[] stu = root.GetDirectories("*");
            int score = 0;
            scoreDistribution = new float[5];

            for (int i = 0; i < stu.Length; i++)
            {
                FileInfo[] result = stu[i].GetFiles("Result*");
                if (result.Length == 1)
                {
                    score = getScore(result[0].FullName);
                    if (score >= 90)
                        scoreDistribution[0]++;
                    else if (score >= 80)
                        scoreDistribution[1]++;
                    else if (score >= 70)
                        scoreDistribution[2]++;
                    else if (score >= 60)
                        scoreDistribution[3]++;
                    else
                        scoreDistribution[4]++;
                }

            }
        }

    }

}
