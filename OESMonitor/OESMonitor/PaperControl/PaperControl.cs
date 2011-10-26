using System;
using System.Collections.Generic;
 
using System.Text;
using OES;

namespace OESMonitor
{
    public class PaperControl
    {
        public static OESConfig PathConfig = new OESConfig("PathConfig.xml",new string[,]{
            {"StuAns","C:/OES/Student/"},
            {"TmpPaper","C:/OES/TmpPaper/"}
        });
        public static OESData OesData = new OESData();
    }
}
