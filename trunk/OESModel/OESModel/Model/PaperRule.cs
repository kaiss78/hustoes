using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OES.Model
{
    public class PaperRule
    {
        public int Chapter;
        public ProblemType PType;
        public int PLevel;
        public int Score;
        public int Count;
        public string ChapterName;
        public string PTypeName;
        public int Course;

        public PaperRule()
        { 

        }

        public PaperRule(int unit,ProblemType pt,int pl,int score,int count)
        { 
            Chapter=unit;
            PType = pt;
            PLevel = pl;
            Score = score;
            Count = count;
        }
    }
}
