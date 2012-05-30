using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OES.Model;
using System.IO;
using OES.XMLFile;


namespace OESScore
{
    public enum ScoreState
    {
        None = 0,     //未开始评分
        Success = 1,  //评分成功
        PaperNotFound = 2,//试卷不存在
        AnswerNotFound = 3//考生答案不存在
    }

    public class StuFolder
    {
        //考生基本信息
        public Student StuInfo=new Student();
        //文件存放的路径
        public DirectoryInfo path;
        //考生答案
        public StaAns StuAns;        
        //考生得分
        public Score Score;
        //试卷信息
        public Paper PaperInfo;
        //评分状态
        public ScoreState state;

        /// <summary>
        /// 读取评分结果
        /// 已经评过分的试卷会生成评分结果
        /// </summary>
        /// <param name="path">评分结果存放路径</param>
        public void ReadResult(string path)
        {            
            int tot = 0;
            List<IdScoreType> result;
            Score.detail = XMLControl.ReadScoreSheet(path);
            Score.sum = new List<Sum>();
            foreach (IdScoreType ist in Score.detail)
            {
                Score.addDetail(ist.pt, ist.score);
                tot = tot + ist.score;
            }
            Score.Value = tot;
        }
    }
}
