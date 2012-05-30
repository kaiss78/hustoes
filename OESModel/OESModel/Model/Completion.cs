using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OES.Model
{
    public class Completion:Problem
    {
        //考生答案
        public string stuAns;
        //标准答案（单空多答案）
        public List<string> ans;      
        /// <summary>
        /// 构造一个空的Completion对象
        /// </summary>
        public Completion()
        {
            type = ProblemType.Completion;
        }
        /// <summary>
        /// 构造一个Completion对象，设置题干
        /// 初始化标准答案列表
        /// </summary>
        /// <param name="p">题干</param>
        public Completion(string p)
        {
            problem = p;
            stuAns = "";
            ans = new List<string>();
            type =ProblemType.Completion;
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
