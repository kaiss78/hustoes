
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace OES.Model
{
    public  class Student
    {
        public string sName="";
        public string ID="";
        public string examID="";
        public string password="";
        public string classId="";
        public string dept="";
        public string className="";
        public string ip = "";

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