using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Web;

namespace oesdemoliuyuan
{
    class ReadEMFile
    {
        string []strline;
        public string read()
        {
            try
            {
                FileStream aFile = new FileStream("C:\\Users\\Administrator\\Desktop\\choice.txt", FileMode.Open);
                StreamReader sr = new StreamReader(aFile);
                strline[0] = sr.Readline();
                for (int j = 1; j < 6; j++)
                {
                    if (strline[j - 1] != null)
                        strline[j] = sr.ReadLine();

                }

                sr.Close();
            }
            catch (IOException e)
            {
                MessageBox.Show(e.ToString);
            }
            return strline;

        }
}
}
