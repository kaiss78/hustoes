
﻿using System;
using System.Collections.Generic;
 
using System.Text;
namespace OESMonitor.Model
{
    public  class Student
    {
        public string sName;
        public string ID;
        public string examID;
        public string password;
        public string classId;
        public string dept;
        public string className;

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
    }
}