using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OESSupport.Net;

namespace OESSupport
{
    class Program
    {
        static ServerEvt server=new ServerEvt();
        public static List<Teacher> TeacherList = new List<Teacher>();
        static void Main(string[] args)
        {
            Configuration.Config.InitConfig();
            while(Console.ReadLine() != "exit")
            {
            }
        }
    }
}
