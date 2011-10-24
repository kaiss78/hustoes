using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OESSupport.Net;
using OES;

namespace OESSupport
{
    class Program
    {
        static ServerEvt server=new ServerEvt();
        public static List<Teacher> TeacherList = new List<Teacher>();
        public static OESConfig config = new OESConfig("serverconfig.xml",
        new string[,] {
        {"Root","D:\\OES\\DataFiles\\"},
        {"Paper","Paper\\"},
        {"PaperPkg","PaperPkg\\"},
        {"Word","Word\\"},
        {"Excel","Excel\\"},
        {"PowerPoint","PowerPoint\\"},
        {"CCompletion","CCompletion\\"},
        {"CModification","CModification\\"},
        {"CFunction","CFunction\\"},
        {"CModification","CppCompletion\\"},
        {"CppCompletion","CppModification\\"},
        {"CppModification","CCompletion\\"},
        {"CppFunction","CppFunction\\"},
        {"VbCompletion","VbCompletion\\"},
        {"VbModification","VbModification\\"},
        {"VbFunction","VbFunction\\"}       
            });
        static void Main(string[] args)
        {
            //Configuration.Config.InitConfig();

            while(Console.ReadLine() != "exit")
            {
            }
        }
    }
}
