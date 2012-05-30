using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OES.Model
{
    /// <summary>
    /// 生成试卷的规则
    /// </summary>
    public class PaperRule
    {
        //章节
        public int Chapter;
        //题目类型
        public ProblemType PType;
        //难度系数
        public int PLevel;
        //每道题的分值
        public int Score;
        //题目数量
        public int Count;
        //章节名
        public string ChapterName;
        //题目类型名
        public string PTypeName;
        //课程ID
        public int Course;

        /// <summary>
        /// 构造一个空的出卷规则
        /// </summary>
        public PaperRule()
        { 

        }
        /// <summary>
        /// 构造一个出卷规则
        /// </summary>
        /// <param name="unit">章节</param>
        /// <param name="pt">题目类型</param>
        /// <param name="pl">难度系数</param>
        /// <param name="score">题目分数</param>
        /// <param name="count">题目数量</param>
        public PaperRule(int unit,ProblemType pt,int pl,int score,int count)
        { 
            Chapter=unit;
            PType = pt;
            PLevel = pl;
            Score = score;
            Count = count;
        }
    }
}
