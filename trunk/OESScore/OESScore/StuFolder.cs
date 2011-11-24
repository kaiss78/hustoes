using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OES.Model;
using System.IO;
using OES.XMLFile;

namespace OESScore
{
    public class StuFolder
    {
        public Student StuInfo=new Student();
        public DirectoryInfo path;
        public StaAns StuAns;        
        public Score Score;
        public Paper PaperInfo;
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
            Score.score = tot.ToString();
        }
    }
}
