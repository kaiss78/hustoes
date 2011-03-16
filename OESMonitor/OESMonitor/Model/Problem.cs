using System;
using System.Collections.Generic;
 
using System.Text;

namespace OESMonitor.Model
{
    public class Problem
    {
        public int score;
        public int problemId;//数据库Id
        public int orderId;//
        public string problem;
        public string type;
        public bool exist;
    }
}
