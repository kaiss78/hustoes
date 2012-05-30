using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OES.Model;

namespace OESScore
{
    public class StaAns
    {
        //试卷ID
        public string PaperID;
        //程序题类型（C,C++,VB）
        public string ProType;
        //文件夹路径
        public string FolderPath;
        //考生答案
        public List<Answer> Ans;        
        public List<List<Answer>> ProAns;
        //程序题信息
        public List<ProgramProblem> PMList;
        public List<ProgramProblem> PCList;
        public List<ProgramProblem> PFList;
        //office题答案
        public List<OfficeAnswer> WordList;
        public List<OfficeAnswer> PowerPointList;
        public List<OfficeAnswer> ExcelList;
    }

}
