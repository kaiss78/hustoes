using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace OES
{
    class ReadProblemFile
    {
        string[] strline = new string[200];
        public void readfile(string[] strline)
        {
            try
            {
                //如果有汉字，必需要加入第二个编码参数，要不读出来就是乱码，如果全是英文，可以不加这个参数。
                FileStream path = new FileStream(@"OESTEST\fillintheblank.txt", FileMode.Open);
                StreamReader sr = new StreamReader(path, System.Text.Encoding.GetEncoding("GB2312"));

                strline[0] = sr.ReadLine();
                for (int j = 1; j < 100; j++)
                {
                    if (strline[j - 1] != null)
                        strline[j] = sr.ReadLine();

                }

                sr.Close();

            }
            catch (IOException e)
            {
                MessageBox.Show(e.ToString());
            }
        }   
    }
}
