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
                        ClientControl.AddChoice(choice);
                    }
                }
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
                        ClientControl.AddCompletion(completion);
                    }
                }
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
                        ClientControl.AddJudge(judge);
                    }
                }
            }
        }

        public static void ReadPCompletion(string path)
        {
        }

        public static void ReadPModif(string path)
        {
        }

        public static void ReadPFunction(string path)
        {
        }
    }
}
