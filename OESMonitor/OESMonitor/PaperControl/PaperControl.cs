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
        public static OESConfig DbConfig = new OESConfig("DbConfig.xml", new string[,]{
            {"Ip","127.0.0.1"},
            {"User","oes"},
            {"Password","123456"}
        });
        public static OESData OesData = new OESData();
    }
}
