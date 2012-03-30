using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OES.Model;

namespace OESScore
{
    public class StaAns
    {
        public string PaperID;
        public string ProType;
        public string FolderPath;
        public List<Answer> Ans;
        public List<List<Answer>> ProAns;
        public List<ProgramProblem> PMList;
        public List<ProgramProblem> PCList;
        public List<ProgramProblem> PFList;
        public List<OfficeAnswer> WordList;
        public List<OfficeAnswer> PowerPointList;
        public List<OfficeAnswer> ExcelList;
    }

}
