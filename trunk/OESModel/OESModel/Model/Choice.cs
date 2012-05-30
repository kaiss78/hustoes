using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OES.Model
{
    public class Choice:Problem 
    {
        //四个选项的值
        public string optionA;
        public string optionB;
        public string optionC;
        public string optionD;
        //答案选项，值为ABCD之一 
        public string ans;
        //考生所选的答案
        public string stuAns;

        /// <summary>
        /// 创建一个空的Choice对象，设置题目类型为Choice
        /// </summary>
        public Choice()
        {
            type = ProblemType.Choice;
        }
        /// <summary>
        /// 构造函数，创建一个Choice对象
        /// </summary>
        /// <param name="p">题干</param>
        /// <param name="oa">选项A</param>
        /// <param name="ob">选项B</param>
        /// <param name="oc">选项C</param>
        /// <param name="od">选项D</param>
        public Choice(string p, string oa, string ob, string oc, string od)
        {
            problem = p;
            optionA = oa;
            optionB = ob;
            optionC = oc;
            optionD = od;
            stuAns = "";
            ans = "";
            type = ProblemType.Choice;
        }
        /// <summary>
        /// 获取当前Choice对象的考生答案
        /// </summary>
        /// <returns>考生答案</returns>
        public override string getAns()
        {
            return stuAns;
        }
    }
}


