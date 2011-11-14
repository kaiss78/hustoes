using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OES.Model
{
    public class IdAnswerType
    {
        public int id;
        public ProblemType pt;
        public string answer;
        public IdAnswerType()
        {
        }
        public IdAnswerType(int id, ProblemType pt, string answer)
        {
            this.id = id;
            this.pt = pt;
            this.answer = answer;
        }
    }
    public class IdScoreType
    {
        public int id;
        public ProblemType pt;
        public int score;
        public IdScoreType()
        {
        }
        public IdScoreType(int id, ProblemType pt, int score)
        {
            this.id = id;
            this.pt = pt;
            this.score = score;
        }
    }
}
