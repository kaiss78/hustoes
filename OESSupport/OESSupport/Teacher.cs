using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OESSupport.Net;
using ServerNet;

namespace OESSupport
{
    public class Teacher
    {
        public string name;
        public string pwd;
        public Client client;
        public string filepath;
        public Teacher(string name, Client client)
        {
            this.name = name;
            this.client = client;
        }
        public static Teacher FindTeacherByClient(List<Teacher> list,Client c)
        {
            foreach (Teacher t in list)
            {
                if (t.client == c)
                {
                    return t;
                }
            }
            return null;
        }
        public override string ToString()
        {
            return "{Name:" + this.name + " IpPort:" + this.client.ClientIp  + "}";
        }
    }
}
