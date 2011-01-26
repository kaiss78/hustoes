using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OES.Model
{
    public class Classes
    {
        public string classID;
        public string dept;
        public string className;
        public string teacherUserName;
        public string teacherName;

        public Classes(string id, string dp, string cn, string tun, string tn)
        {
            classID = id;
            dept = dp;
            className = cn;
            teacherUserName = tun;
            teacherName = tn;
        }

        public Classes()
        { }
    }
}
