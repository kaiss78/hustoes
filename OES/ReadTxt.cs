using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using OES.Model;
using System.Windows.Forms;

namespace OES
{
    class ReadTxt
    {
        public static void ReadChoice(string path, MainForm mf)
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
                mf.addChoicePage();
            }
        }

        public static void ReadCompletion(string path, MainForm mf)
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
                mf.addCompletionPage();
            }
        }

        public static void ReadJudge(string path, MainForm mf)
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
                mf.addJudgePage();
            }
        }

        public static void ReadPCompletion(string path, MainForm mf)
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
            mf.addPCompletionPage();
        }

        public static void ReadPModif(string path, MainForm mf)
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
            mf.addPModifPage();
        }

        public static void ReadPFunction(string path, MainForm mf)
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
                mf.addpFunctionPage();
            }
        }
        public static void ReadPaper(string path,MainForm mf)
        {
            ReadTxt.ReadChoice(path, mf);
            ReadTxt.ReadCompletion(path, mf);
            ReadTxt.ReadJudge(path, mf);
            ReadTxt.ReadPCompletion(path, mf);
            ReadTxt.ReadPModif(path, mf);
            ReadTxt.ReadPFunction(path, mf);                                    
            mf.addWordPage();
            mf.addPptPage();
            mf.addExcelPage();                                    
        }
    }
}
