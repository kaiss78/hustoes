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
        public List<Sum> sum;
        public List<IdScoreType> detail;
        public Score()
        {
            detail = new List<IdScoreType>();
            sum = new List<Sum>();
        }
        public void addDetail(ProblemType pt, int score)
        {
            foreach (Sum dt in sum)
            {
                if (dt.PType == pt)
                {
                    dt.score += score;
                    return;
                }
            }
            sum.Add(new Sum(pt, score));
        }
    }

    public class Sum
    {

        public ProblemType PType;
        public int score;
        public Sum(ProblemType pt, int score)
        {
            this.PType = pt;
            this.score = score;
        }
    }
}
