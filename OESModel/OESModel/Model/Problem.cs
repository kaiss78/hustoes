using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OES.Model
{
    public class Problem
    {
        //分值
        public int score;
        //题目Id
        public int problemId;
        public int orderId;//
        //题目章节
        public Unit unit=new Unit();
        //难度值
        public int Plevel;
        //题干
        public string problem;
        //题目类型
        public ProblemType type=new ProblemType();
        //
        public bool exist;

        virtual public string getAns()
        {
            return "";
        }
    }
}
