using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OES.Model
{
    public class Student
    {
        public string sName;
        public string ID;
        public string examID;
        public string password;
        public Student(string name,string examid,string id,string pword)
        {
            sName = name;
            examID = examid;
            ID = id;
            password = pword;
        }
    }
}
