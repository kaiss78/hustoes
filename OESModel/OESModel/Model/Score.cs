using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OES.Model
{
    public class Score
    {
        public string stuName;
        public string paperTitle;
        public string score;
        public string stuClassName;
        public List<Detail> detail;
        public Score()
        {
            detail = new List<Detail>();
        }
        public void addDetail(ProblemType pt,int score)
        {
            foreach (Detail dt in detail)
            {
                if (dt.PType == pt)
                {
                    dt.score += score;
                    return;
                }
            }
            detail.Add(new Detail(pt, score));
        }
    }

    public class Detail
    {

        public ProblemType PType;
        public int score;
        public Detail(ProblemType pt, int score)
        {
            this.PType = pt;
            this.score = score;
        }
    }
}
