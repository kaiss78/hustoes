using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OES.Model
{
    public class PFunction : ProgramProblem
    {

        /// <summary>
        /// 构造一个程序编程题对象
        /// 根据题目类型设置语言
        /// </summary>
        /// <param name="pt">题目类型</param>
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

        /// <summary>
        /// 构造一个程序编程题
        /// 设置语言及题干
        /// </summary>
        /// <param name="pt">题目类型</param>
        /// <param name="p">题干</param>
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
