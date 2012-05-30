using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OES.Model
{
    public class Classes
    {
        //班级ID
        public string classID;
        //院系名称
        public string dept;
        //专业名称
        public string className;
        //教师的登录账号
        public string teacherUserName;
        //教师姓名
        public string teacherName;

        //班级构造函数
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
