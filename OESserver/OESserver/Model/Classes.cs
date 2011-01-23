using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OES.Model
{
    public class Classes
    {
        public int classID;
        public string dept;
        public string className;
        public string teacherUserName;

        public Classes(int id, string dp, string cn, string tun)
        {
            classID = id;
            dept = dp;
            className = cn;
            teacherUserName = tun;
        }
    }
}
