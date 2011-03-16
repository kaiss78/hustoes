using System;
using System.Collections.Generic;
 
using System.Text;
using System.IO;
using OES.Model;
using System.Windows.Forms;

namespace OES
{
    class ReadTxt
    {
        public static void ReadChoice(string path)
        {
            path = path + "a.txt";
            if (File.Exists(path))
            {                                
                using (StreamReader sr = new StreamReader(path, System.Text.Encoding.GetEncoding("GB2312")))
                {
                    String st;
                    String[] s;
                    Choice choice;
                    int i;
                    st = sr.ReadToEnd();
                    s = st.Split('\n');
                    for (i = 0; i < s.Length; i = i + 5)
                    {
                        choice = new Choice(s[i], s[i + 1], s[i + 2], s[i + 3], s[i + 4]);
                        choice.orderId = i / 5;
                        ClientControl.paper.Add(choice);
                    }
                }
                ClientControl.MainForm.addPage(ProblemType.Choice);
            }
        }

        public static void ReadCompletion(string path)
        {
            path = path + "b.txt";
            if (File.Exists(path))
            {                                
                using (StreamReader sr = new StreamReader(path, System.Text.Encoding.GetEncoding("GB2312")))
                {
                    String st;
                    String[] s;
                    Completion completion;
                    int i;
                    st = sr.ReadToEnd();
                    s = st.Split('\n');
                    for (i = 0; i < s.Length; i = i + 1)
                    {
                        completion = new Completion(s[i]);
                        completion.orderId = i;
                        ClientControl.paper.Add(completion);
                    }
                }
                ClientControl.MainForm.addPage(ProblemType.Completion);
            }
        }

        public static void ReadJudge(string path)
        {
            path = path + "c.txt";
            if (File.Exists(path))
            {                
                using (StreamReader sr = new StreamReader(path, System.Text.Encoding.GetEncoding("GB2312")))
                {
                    String st;
                    String[] s;
                    Judge judge;
                    int i;
                    st = sr.ReadToEnd();
                    s = st.Split('\n');
                    for (i = 0; i < s.Length; i = i + 1)
                    {
                        judge = new Judge(s[i]);
                        judge.orderId = i;
                        ClientControl.paper.Add(judge);
                    }
                }
                ClientControl.MainForm.addPage(ProblemType.Tof);
            }
        }

        public static void ReadPCompletion(string path)
        {
            path = path + "h.txt";
            if (File.Exists(path))
            {                
                using (StreamReader sr = new StreamReader(path, System.Text.Encoding.GetEncoding("GB2312")))
                {
                    String st;
                    PCompletion pCompletion;
                    st = sr.ReadToEnd();
                    pCompletion = new PCompletion(st);                    
                    ClientControl.paper.Add(pCompletion);                    
                }
            }
            ClientControl.MainForm.addPage(ProblemType.ProgramCompletion);
        }

        public static void ReadPModif(string path)
        {
            path = path + "g.txt";
            if (File.Exists(path))
            {                
                using (StreamReader sr = new StreamReader(path, System.Text.Encoding.GetEncoding("GB2312")))
                {
                    String st;
                    PModif pModif;
                    st = sr.ReadToEnd();
                    pModif = new PModif(st);
                    ClientControl.paper.Add(pModif);
                }
            }
            ClientControl.MainForm.addPage(ProblemType.ProgramModification); 
        }

        public static void ReadPFunction(string path)
        {
            path = path + "i.txt";
            if (File.Exists(path))
            {                
                using (StreamReader sr = new StreamReader(path, System.Text.Encoding.GetEncoding("GB2312")))
                {
                    String st;
                    PFunction pFunction;
                    st = sr.ReadToEnd();
                    pFunction = new PFunction(st);
                    ClientControl.paper.Add(pFunction);
                }
                ClientControl.MainForm.addPage(ProblemType.ProgramFun);
            }
        }

        public static void ReadOfficeWord(string path)
        {
            path = path + "d.txt";
            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path, System.Text.Encoding.GetEncoding("GB2312")))
                {
                    String st;
                    OfficeWord oWord;
                    st = sr.ReadToEnd();
                    oWord = new OfficeWord(st);                    
                    ClientControl.paper.Add(oWord);
                }
                ClientControl.MainForm.addPage(ProblemType.Word);
            }
        }

        public static void ReadOfficePPT(string path)
        {
            path = path + "e.txt";
            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path, System.Text.Encoding.GetEncoding("GB2312")))
                {
                    String st;
                    OfficePowerPoint oPPT;
                    st = sr.ReadToEnd();
                    oPPT = new OfficePowerPoint(st);
                    ClientControl.paper.Add(oPPT);
                }
                ClientControl.MainForm.addPage(ProblemType.PowerPoint);
            }
        }

        public static void ReadOfficeExcel(string path)
        {
            path = path + "f.txt";
            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path, System.Text.Encoding.GetEncoding("GB2312")))
                {
                    String st;
                    OfficeExcel oExcel;
                    st = sr.ReadToEnd();
                    oExcel = new OfficeExcel(st);                    
                    ClientControl.paper.Add(oExcel);
                }
                ClientControl.MainForm.addPage(ProblemType.Excel);
            }
        }

        public static void ReadPaper(string path)
        {
            ReadTxt.ReadChoice(path);
            ReadTxt.ReadCompletion(path);
            ReadTxt.ReadJudge(path);
            ReadTxt.ReadOfficeWord(path);
            ReadTxt.ReadOfficePPT(path);
            ReadTxt.ReadOfficeExcel(path);
            ReadTxt.ReadPModif(path);
            ReadTxt.ReadPCompletion(path);           
            ReadTxt.ReadPFunction(path);                                                                        
        }
    }
}
