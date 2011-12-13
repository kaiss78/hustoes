using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OES.Model
{
    public class Problem
    {
        public int score;
        public int problemId;//数据库Id
        public int orderId;//
        public Unit unit=new Unit();
        public int Plevel;
        
        public string problem;
        public ProblemType type=new ProblemType();
        public bool exist;
        virtual public string getAns()
        {
            return "";
        }
    }
}
