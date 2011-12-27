using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace OES.CSVHelper
{
    public class CSVImporter
    {
        //从csv文件中读取数据 path:文件路径 dataCount:一行的数据个数
        public static List<string[]> getObjectInCSV(string path, int dataCount) 
        {
            List<string[]> ret = new List<string[]>();
            string content = "";
            int bese = 0;
            int pos = 0;
            int state = 0;
            int len = 0;
            string[] value = new string[dataCount];
            using (StreamReader sr = new StreamReader(path, Encoding.Default))
            {
                content = sr.ReadToEnd();
            }
            content = content.Replace("\"\"", "\0");
            while (pos < content.Length)
            {
                if (state == 0)
                {
                    if (content[pos] == ',')
                    {
                        value[len++] = content.Substring(bese, pos - bese).Replace("\"","").Replace('\0', '\"');
                        bese = pos+1;
                    }
                    else if(content[pos]=='\"')
                    {
                        state=1;
                    }
                    else if (content[pos] == '\n')
                    {
                        value[len++] = content.Substring(bese, pos - bese).Replace("\"", "").Replace('\0', '\"');
                        bese = pos + 1;
                        ret.Add(value);
                        len = 0;
                        value = new string[dataCount];
                    }
                    pos++;
                }
                else if (state == 1)
                {
                    if (content[pos] == '\"')
                    {
                        state = 0;
                    }
                    pos++;
                }
            }
            return ret;
        }
    }
}
