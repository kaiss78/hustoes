using System;
using System.Collections.Generic;
 
using System.Text;
using OES;

namespace OESMonitor
{
    public class PaperControl
    {
        public static OESConfig PathConfig = new OESConfig("PathConfig.xml",new string[,]{
            {"StuAns",@"C:\OES\Student\"},
            {"TmpPaper",@"C:\OES\TmpPaper\"}
        });
        public static OESConfig PwdConfig = new OESConfig("PwdConfig.xml", new string[,]{
            {"Password","123"}
        });
        public static OESData OesData = new OESData();
    }
}
