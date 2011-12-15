using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OES.Model
{
    class PaperRule
    {
        public int Chapter;
        public ProblemType PType;
        public int PLevel;
        public int Score;
        public int Count;

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
