using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using System.Windows.Forms;

namespace oesdemoliuyuan
{
    class ReadEMFile
    {
        string [] strline=new string[200];
        public void read(string []strline)
        {
            try
            {
                //string path = @"C:\Users\Administrator\Desktop\Choice.txt";
                FileStream path = new FileStream(@"C:\Users\Administrator\Desktop\Choice.txt", FileMode.Open);
                StreamReader sr = new StreamReader(path);
                strline[0] = sr.ReadLine();
                for (int j = 1; j < 6; j++)
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
