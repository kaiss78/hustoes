using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OES.Model
{
    public class Teacher                //教师类
    {
        public int Id;                  //教师ID
        public string TeacherName;      //教师姓名     
        public string UserName;         //教师登录账号
        public string password;         //教师密码
        //定义教师的权限，0：普通教师，1：超级管理员
        public int permission;

        public Teacher(int id, string tn, string un, string pw, int pm)
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
