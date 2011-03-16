using System;
using System.Collections.Generic;
 
using System.Text;

namespace OES.Model
{
    public class Problem
    {
        public int score;
        public int problemId;
        public int orderId;
        public string problem;
        public ProblemType type;
        virtual public string getAns()
        {
            return "";
        }
    }
    public enum ProblemType
    {
        Choice,
        Completion,
        Tof,
        Word,
        Excel,
        PowerPoint,
        ProgramCompletion,
        ProgramModification,
        ProgramFun,
        Start,
        Blank
    }
    public class Pid_Ans
    {
        public int id;
        public string ans;
        public Pid_Ans(int i, string s)
        {
            id = i;
            ans = s;
        }
    }
    public class Pid_Score
    {
        public int id;
        public int score;
        public Pid_Score(int i, int s)
        {
            id = i;
            score = s;
        }
    }
}
