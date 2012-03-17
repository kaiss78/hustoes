using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OESSupport.Net;
using ServerNet;
using System.IO;

namespace OESSupport
{
    public class Teacher
    {
        public string name;
        public string pwd;
        public Client client;
        public bool isFileExist=true;
        private string filepath;

        public string Filepath
        {
            get 
            {
                return filepath; 
            }
            set 
            {
                filepath = value;
                if (File.Exists(filepath))
                {
                    isFileExist = true;
                }
                else
                {
                    isFileExist = false;
                }
            }
        }

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
            if (this.name == "0")
            {
                return "{Monitor IpPort:" + this.client.ClientIp + "}";
            }
            else if (this.name == "-1")
            {
                return "{Score IpPort:" + this.client.ClientIp + "}";
            }
            else
            {
                return "{Name:" + this.name + " IpPort:" + this.client.ClientIp + "}";
            }
        }
    }
}
