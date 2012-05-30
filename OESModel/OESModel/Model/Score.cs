using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OES.Model
{
    public class Score
    {
        //考试名
        public string examName;
        //考生名
        public string stuName;
        //考生ID
        public string studentID;
        //试卷标题
        public string paperTitle;
        //分数
        public int Value;
        //考生班级
        public string stuClassName;
        //统计信息，统计各类题目的得分
        public List<Sum> sum;
        //详细得分情况，记录各个题目的得分
        public List<IdScoreType> detail;

        /// <summary>
        /// 初始化成绩单
        /// </summary>
        public Score()
        {
            detail = new List<IdScoreType>();
            sum = new List<Sum>();
        }

        /// <summary>
        /// 添加一道题目的得分情况
        /// </summary>
        /// <param name="pt">题目类型</param>
        /// <param name="score">所得分数</param>
        public void addDetail(ProblemType pt, int score)
        {
            foreach (Sum dt in sum)
            {
                if (dt.PType == pt)
                {
                    dt.score += score;
                    return;
                }
            }
            sum.Add(new Sum(pt, score));
        }
    }

    public class Sum
    {

        public ProblemType PType;
        public int score;
        public Sum(ProblemType pt, int score)
        {
            this.PType = pt;
            this.score = score;
        }
    }
}
