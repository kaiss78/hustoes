using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OES.Model
{
    public class PCompletion : ProgramProblem
    {
        /// <summary>
        /// 构造一个程序填空题对象
        /// 根据题目类型设置语言
        /// </summary>
        /// <param name="pt">题目类型</param>
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

        /// <summary>
        /// 构造一个程序填空题
        /// 设置语言及题干
        /// </summary>
        /// <param name="pt">题目类型</param>
        /// <param name="p">题干</param>
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
