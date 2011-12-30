using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OES.Model
{
    public class PCompletion : ProgramProblem
    {

        public PCompletion(ProblemType pt)
        {
            type = pt;
            switch (pt)
            {
                case ProblemType.CProgramCompletion:
                    language = PLanguage.C;
                    break;
                case ProblemType.CppProgramCompletion:
                    language = PLanguage.CPP;
                    break;
                case ProblemType.VbProgramCompletion:
                    language = PLanguage.VB;
                    break;
            }
            this.Type = ProgramPType.Completion;
        }
        public PCompletion(ProblemType pt,string p)
        {
            problem = p;

            type = pt;
            switch (pt)
            {
                case ProblemType.CProgramCompletion:
                    language = PLanguage.C;
                    break;
                case ProblemType.CppProgramCompletion:
                    language = PLanguage.CPP;
                    break;
                case ProblemType.VbProgramCompletion:
                    language = PLanguage.VB;
                    break;
            }
            this.Type = ProgramPType.Completion;
        }

        public override string getAns()
        {
            return "";
        }
    }
}
