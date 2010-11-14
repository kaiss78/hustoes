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
                        MessageBox.Show(s[i]);
                        ClientControl.AddChoice(choice);
                    }
                }
            }
        }

        public static void ReadCompletion(string path)
        {
        }

        public static void ReadJudge(string path)
        {
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
