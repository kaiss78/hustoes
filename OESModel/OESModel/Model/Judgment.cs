using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace OES.Model
{
    public class Judgment:Problem
    {
        //判断题 标准答案，考生答案
        public string ans, stuAns;
        /// <summary>
        /// 构造空的Judgment对象
        /// </summary>
        public Judgment()
        {
            type = ProblemType.Judgment;
        }
        /// <summary>
        /// 构造一个Judgment对象，设置题干
        /// </summary>
        /// <param name="p">题干</param>
        public Judgment(string p)
        {
            problem = p;
            stuAns = "";
            ans = "";
            type = ProblemType.Judgment;
        }
        /// <summary>
        /// 获取考生答案
        /// </summary>
        /// <returns>考生答案</returns>
        public override string getAns()
        {
            return stuAns;
        }
    }
}
