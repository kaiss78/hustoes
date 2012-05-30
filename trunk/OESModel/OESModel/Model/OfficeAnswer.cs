using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OES.Model
{
    public class OfficeAnswer           //Office答案类
    {
        public string OfficeFile;       //Office题标答文件路径
        public string XMLFile;          //考点xml文件路径
        public int score;               //总分
        public OfficeAnswer(string office, string xml,int s)
        {
            OfficeFile = office;
            XMLFile = xml;
            score = s;
        
        }
        public OfficeAnswer()
        { }
    }
}
