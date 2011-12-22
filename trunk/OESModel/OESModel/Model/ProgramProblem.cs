using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OES.Model
{
    public class ProgramProblem:Problem
    {
        public PLanguage language;
        public ProgramPType Type;
        public List<ProgramAnswer> ansList;

        public ProgramProblem()
        {
            ansList = new List<ProgramAnswer>();
        }
    }
    public enum ProgramPType
    {
        Null = -1,
        Completion = 0,
        Modify = 1,
        Function = 2
    }
    public enum PLanguage
    {
        Null = -1,
        C = 0,
        CPP = 1,
        VB = 2
    }
}
