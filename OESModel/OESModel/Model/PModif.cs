using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OES.Model
{
    public class PModif : ProgramProblem
    {
        public PModif(ProblemType pt)
        {
            type = pt;
            switch (pt)
            {
                case ProblemType.CProgramModification:
                    language = PLanguage.C;
                    break;
                case ProblemType.CppProgramModification:
                    language = PLanguage.CPP;
                    break;
                case ProblemType.VbProgramModification:
                    language = PLanguage.VB;
                    break;
            }
            this.Type = ProgramPType.Modify;
        }
        public PModif(ProblemType pt, string p)
        {
            problem = p;
 
            type = pt;
            switch (pt)
            {
                case ProblemType.CProgramModification:
                    language = PLanguage.C;
                    break;
                case ProblemType.CppProgramModification:
                    language = PLanguage.CPP;
                    break;
                case ProblemType.VbProgramModification:
                    language = PLanguage.VB;
                    break;
            }
            this.Type = ProgramPType.Modify;
        }
        public override string getAns()
        {
            return "";
        }
    }
}
