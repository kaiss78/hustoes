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
        public Student StuInfo=new Student();
        public DirectoryInfo path;
        public StaAns StuAns;        
        public Score Score;
        public Paper PaperInfo;
        public ScoreState state;
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
