using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OES.Model
{
    public class Teacher
    {
        public string Id;
        public string TeacherName;        
        public string UserName;
        public string password;
        //定义教师的权限，0：普通教师，1：超级管理员
        public int permission;

        public Teacher(string id, string tn, string un, string pw, int pm)
        {
            Id = id;
            TeacherName = tn;
            UserName = un;
            password = pw;
            permission = pm;
        }

        public Teacher()
        { }
    }
}
