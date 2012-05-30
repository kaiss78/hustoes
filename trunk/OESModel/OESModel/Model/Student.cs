
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace OES.Model
{
    public  class Student               //学生类
    {
        public string sName="";         //学生姓名
        public string ID="";            //学号
        public string examID="";        //学生所参加的考试ID
        public string password="";      //学生密码
        public string classId="";       //班级ID
        public string dept="";          //所在院系名称
        public string className="";     //专业名称
        public string ip = "";          //学生所在机器IP

        public Student(string name, string examid, string id, string pword)
        {
            sName = name;
            examID = examid;
            ID = id;
            password = pword;
        }

        public Student(string id, string name, string cid, string dp, string cn, string pw)
        {
            ID = id;
            sName = name;
            classId = cid;
            dept = dp;
            className = cn;
            password = pw;
        }

        public Student() { }

        //比较两个学生是否一致
        public override bool Equals(object obj)
        {
            if (obj is Student)
            {
                if (this.ID.ToLower() == (obj as Student).ID.ToLower() && this.sName == (obj as Student).sName)
                {
                    return true;
                }
            }
            return false;
        }

        public override int GetHashCode()
        {
            return 1;
        }
    }
}