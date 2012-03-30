using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OES.Model
{
    public class OfficeAnswer
    {
        public string OfficeFile;
        public string XMLFile;
        public int score;
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
