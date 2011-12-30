using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OES.Model
{
    public class PFunction : ProgramProblem
    {
 
        public PFunction(ProblemType pt)
        {
            type = pt;
            switch (pt)
            {
                case ProblemType.CProgramFun:
                    language = PLanguage.C;
                    break;
                case ProblemType.CppProgramFun:
                    language = PLanguage.CPP;
                    break;
                case ProblemType.VbProgramFun:
                    language = PLanguage.VB;
                    break;
            }
            this.Type = ProgramPType.Function;
        }
        public PFunction(ProblemType pt, string p)
        {
            problem = p;
            type = pt;
            switch (pt)
            {
                case ProblemType.CProgramFun:
                    language = PLanguage.C;
                    break;
                case ProblemType.CppProgramFun:
                    language = PLanguage.CPP;
                    break;
                case ProblemType.VbProgramFun:
                    language = PLanguage.VB;
                    break;
            }
            this.Type = ProgramPType.Function;
        }
        public override string getAns()
        {
            return "";
        }
    }
}
