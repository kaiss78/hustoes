using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OES.Model
{
    public class PModif : ProgramProblem
    {
        /// <summary>
        /// 构造一个程序改错题对象
        /// 根据题目类型设置语言
        /// </summary>
        /// <param name="pt">题目类型</param>
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
        /// <summary>
        /// 构造一个程序改错题
        /// 设置语言及题干
        /// </summary>
        /// <param name="pt">题目类型</param>
        /// <param name="p">题干</param>
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
