using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using OES;
using OES.XMLFile;
using OES.Model;
using System.IO;
using Microsoft.Win32;
using System.Diagnostics;
using OES.Net;

namespace OESScore
{
    public class ScoreControl
    {

        public static StaAns staAns;

        public static ClientEvt scoreNet = new ClientEvt();
        /// <summary>
        /// 配置文件设置
        /// </summary>
        public static OESConfig config = new OESConfig("PathConfig.xml",
        new string[,] {
                        {"PaperPath","c:\\"},
                        {"AnswerPath","c:\\"}
                      });

        /// <summary>
        /// 数据库工厂
        /// </summary>
        private static OESData oesData = null;
        public static OESData OesData
        {
            get
            {
                if (oesData == null) { oesData = new OESData(); }
                return ScoreControl.oesData;
            }
            set { ScoreControl.oesData = value; }
        }

        /// <summary>
        /// 获取文件夹信息
        /// 获取文件夹中的目录信息，只获取文件夹的信息
        /// </summary>
        /// <param name="path">文件夹目录</param>
        /// <returns></returns>
        public static List<DirectoryInfo> GetFolderInfo(string path)
        {

            return new DirectoryInfo(path).GetDirectories().ToList<DirectoryInfo>();
        }

        /// <summary>
        /// 获得路径指向的文件名
        /// </summary>
        /// <param name="path">路径</param>
        /// <returns>文件名</returns>
        private static string GetText(String path)
        {
            string text = "";
            if (path.Length > 0)
            {
                StreamReader TxtReader = new StreamReader(path);
                text = TxtReader.ReadToEnd();
                TxtReader.Close();
            }
            return text;
        }

        /// <summary>
        /// 获取安装软件和路径，通过注册表得到。
        /// </summary>
        /// <returns></returns>
        public static string FindVC()
        {
            RegistryKey key = Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Uninstall", false);
            {
                if (key != null)//判断对象存在
                {
                    foreach (string keyName in key.GetSubKeyNames())//遍历子项名称的字符串数组
                    {
                        using (RegistryKey key2 = key.OpenSubKey(keyName, false))//遍历子项节点
                        {
                            if (key2 != null)
                            {
                                string softwareName = key2.GetValue("DisplayName", "").ToString();//获取软件名
                                string installLocation = key2.GetValue("UninstallString", "").ToString();//获取安装路径
                                if (softwareName.Contains("Microsoft Visual C++ 6.0") == true)
                                {
                                    installLocation = installLocation.Remove(installLocation.IndexOf("Setup"));
                                    return installLocation + @"Bin\";
                                }
                            }
                        }
                    }
                }
            }
            return "";
        }

        private static Thread t;
        private static bool isTimeOut = false;
        /// <summary>
        /// 程序综合题评分
        /// </summary>
        /// <param name="path">文件路径</param>
        public static string correctPF(string path, string input)
        {
            string clPath = FindVC();
            string st, name;
            Process cmd = new Process();
            FileInfo cpppath = new FileInfo(path);
            st = "";
            if (clPath != "")
            {
                cmd.StartInfo.FileName = "cmd.exe";//***
                cmd.StartInfo.UseShellExecute = false; //此处必须为false否则引发异常
                cmd.StartInfo.RedirectStandardInput = true; //标准输入
                cmd.StartInfo.RedirectStandardOutput = true; //标准输出            
                cmd.StartInfo.CreateNoWindow = true;//不显示命令行窗口界面                         
                cmd.Start(); //启动进程
                cmd.StandardInput.WriteLine(clPath[1] + ":");
                cmd.StandardInput.WriteLine("cd " + clPath);   //编译生成.exe文件
                cmd.StandardInput.WriteLine("VCVARS32.BAT");
                cmd.StandardInput.WriteLine(cpppath.DirectoryName[0] + ":");
                cmd.StandardInput.WriteLine("cd " + cpppath.DirectoryName);
                cmd.StandardInput.WriteLine("cl " + cpppath.Name);
                name = (cpppath.Name.Split('.'))[0] + ".exe";
                cmd.StandardInput.WriteLine("Exit");
                cmd.WaitForExit();//等待控制台程序执行完成               
                cmd.Close();//关闭该进程
                isTimeOut = false;
                t = new Thread(new ThreadStart(() =>
                {

                    Thread.Sleep(3000);
                    isTimeOut = true;

                }
                                          ));

                t.Start();
                cmd.StartInfo.FileName = cpppath.DirectoryName + "\\" + name;
                if (File.Exists(cmd.StartInfo.FileName))
                {
                    cmd.Start();
                    cmd.StandardInput.WriteLine(input);

                    while (!cmd.HasExited && !isTimeOut)
                    {
                    }
                    if (isTimeOut)
                    {
                        cmd.Kill();
                    }
                    st = cmd.StandardOutput.ReadToEnd();
                    cmd.Close(); //关闭该进程     
                    t.Abort();
                    isTimeOut = false;
                }
            }
            return ScoreControl.Clean(st);
        }


        public static string Clean(string str)
        {
            int j = 0;
            string st = str;
            while (j < st.Length)
            {
                if ((st[j] == '\t') || (st[j] == ' ') || (st[j] == '\r') || (st[j] == '\n'))
                {
                    st=st.Remove(j, 1);
                }
                else
                {
                    j++;
                }
            }
            return st;
        }

        /// <summary>
        /// 程序改错、填空题评分
        /// </summary>
        /// <param name="path">文件路径</param>
        public static List<string> correctPC(string path)
        {
            string cpptext, st;
            int i, j;
            List<string> result;
            result = new List<string>();
            cpptext = ScoreControl.GetText(path);
            string[] str = cpptext.Split('\n');
            i = 0;
            while (i < str.Length)
            {
                if (str[i].IndexOf(@"//") >= 0)
                {
                    st = str[i + 1];
                    i = i + 2;                    
                    result.Add(Clean(st));
                }
                else
                {
                    i++;
                }
            }
            return result;

        }

        /// <summary>
        /// 获取客观题答案
        /// </summary>
        /// <param name="pro">所要获取答案的客观题</param>
        /// <param name="ansList">答案列表</param>
        /// <returns></returns>
        static private Answer getAnswer(IdScoreType pro, List<IdAnswerType> ansList)
        {
            Answer ans;
            ans = new Answer();
            ans.ID = pro.id;
            ans.Score = pro.score;
            ans.Type = pro.pt;
            foreach (IdAnswerType a in ansList)
            {
                if ((a.id == pro.id) && (a.pt == pro.pt))
                {
                    ans.Ans = a.answer;
                    break;
                }
            }
            return ans;
        }
        /// <summary>
        /// 获取程序题答案
        /// </summary>
        /// <param name="pro">所要获取答案的程序题</param>
        /// <returns></returns>
        static private ProgramProblem getPAnswer(IdScoreType pro)
        {
            ProgramProblem programProblem = new ProgramProblem();
            switch (pro.pt)
            {
                case ProblemType.CProgramCompletion:
                case ProblemType.CProgramModification:
                case ProblemType.CProgramFun:
                    programProblem.language = PLanguage.C;
                    break;
                case ProblemType.CppProgramCompletion:
                case ProblemType.CppProgramModification:
                case ProblemType.CppProgramFun:
                    programProblem.language = PLanguage.CPP;
                    break;
                case ProblemType.VbProgramCompletion:
                case ProblemType.VbProgramModification:
                case ProblemType.VbProgramFun:
                    programProblem.language = PLanguage.VB;
                    break;
            }
            switch (pro.pt)
            {
                case ProblemType.CProgramCompletion:
                case ProblemType.CppProgramCompletion:
                case ProblemType.VbProgramCompletion:
                    programProblem.Type = ProgramPType.Completion;
                    break;
                case ProblemType.CppProgramFun:
                case ProblemType.VbProgramFun:
                case ProblemType.CProgramFun:
                    programProblem.Type = ProgramPType.Function;
                    break;
                case ProblemType.CppProgramModification:
                case ProblemType.CProgramModification:
                case ProblemType.VbProgramModification:
                    programProblem.Type = ProgramPType.Modify;
                    break;
            }
            programProblem.score = pro.score;
            programProblem.ansList = ScoreControl.oesData.FindProgramAnswerByPID(pro.id);
            return programProblem;

        }

        /// <summary>
        /// 获取正确答案
        /// </summary>
        /// <param name="ID">试卷ID</param>
        /// <param name="path">试卷路径</param>
        /// <returns></returns>
        public static StaAns SetStandardAnswer(string ID)
        {
            StaAns newAnswer;
            List<IdScoreType> proList;
            List<IdAnswerType> ansList;
            proList = new List<IdScoreType>();
            ansList = new List<IdAnswerType>();

            if ((!File.Exists(ScoreControl.config["AnswerPath"] + ID + "\\" + ID + ".xml")) || (!File.Exists(ScoreControl.config["AnswerPath"] + ID + "\\A" + ID + ".xml")))
            {
                ClientEvt.RootPath = ScoreControl.config["AnswerPath"] + ID + "\\";
                if (!Directory.Exists(ClientEvt.RootPath))
                {
                    Directory.CreateDirectory(ClientEvt.RootPath);
                }
                scoreNet.LoadPaper(Convert.ToInt32(ID), -1);
                scoreNet.ReceiveFiles();
                while (!ClientEvt.isOver) ;

                //return null;
            }

            proList = XMLControl.ReadPaper(ScoreControl.config["AnswerPath"] + ID + "\\" + ID + ".xml");
            ansList = XMLControl.ReadPaperAns(ScoreControl.config["AnswerPath"] + ID + "\\A" + ID + ".xml");
            newAnswer = new StaAns();
            newAnswer.Ans = new List<Answer>();
            newAnswer.PaperID = ID;
            //ProgramProblem programProblem;
            newAnswer.PCList = new List<ProgramProblem>();
            newAnswer.PFList = new List<ProgramProblem>();
            newAnswer.PMList = new List<ProgramProblem>();

            foreach (IdScoreType pro in proList)
            {
                switch (pro.pt)
                {
                    case ProblemType.Choice:
                    case ProblemType.Completion:
                    case ProblemType.Judgment:
                        newAnswer.Ans.Add(getAnswer(pro, ansList));
                        break;
                    case ProblemType.CProgramCompletion:
                    case ProblemType.CppProgramCompletion:
                    case ProblemType.VbProgramCompletion:
                        newAnswer.PCList.Add(getPAnswer(pro));
                        break;
                    case ProblemType.CppProgramFun:
                    case ProblemType.VbProgramFun:
                    case ProblemType.CProgramFun:
                        newAnswer.PFList.Add(getPAnswer(pro));
                        break;
                    case ProblemType.CppProgramModification:
                    case ProblemType.CProgramModification:
                    case ProblemType.VbProgramModification:
                        newAnswer.PMList.Add(getPAnswer(pro));
                        break;
                }
            }
            return newAnswer;

        }

        public static StaAns GetStuAns(string path)
        {
            StaAns stuAns = new StaAns();
            stuAns.Ans = new List<Answer>();
            stuAns.ProAns = new List<List<Answer>>();

            Answer ans;
            List<IdAnswerType> ansList = new List<IdAnswerType>();
            ansList = XMLControl.ReadPaperAns(path + "\\studentAns.xml");
            foreach (IdAnswerType pro in ansList)
            {
                ans = new Answer();
                ans.ID = pro.id;
                ans.Type = pro.pt;
                ans.Ans = pro.answer;
                stuAns.Ans.Add(ans);
            }
            return stuAns;
        }

    }
}
