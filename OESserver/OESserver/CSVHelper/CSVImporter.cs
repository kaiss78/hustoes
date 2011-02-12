using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace OES.CVSHelper
{
    public class CSVImporter
    {
        //从csv文件中读取数据 path:文件路径 dataCount:一行的数据个数
        public static List<string[]> getObjectInCSV(string path, int dataCount) 
        {
            List<string[]> ret = new List<string[]>();
            string[] value;
            StreamReader sr = new StreamReader(path, Encoding.GetEncoding("gb2312"));
            string buf;
            string cur;
            int pos, state, len;
            char ch;
            while ((buf = sr.ReadLine()) != null)
            {
                /*      原始的csv读入
                value = new string[dataCount];
                data = buf.Split(',');
                for (int i = 0; i < data.Length; i++)
                    value[i] = data[i];
                for (int i = data.Length; i < dataCount; i++)
                    value[i] = "";
                ret.Add(value);
                */
                //修改后的csv读入
                buf += ',';
                state = pos = len = 0;
                cur = "";
                value = new string[dataCount];
                while (pos < buf.Length && len < dataCount)
                {
                    ch = buf[pos++];
                    if (state == 0)
                    {
                        if (ch != ',' && ch != '\"')
                            cur += ch;
                        else if (ch == ',')
                        {
                            value[len++] = cur;
                            cur = "";
                        }
                        else
                            state = 1;
                    }
                    else if (state == 1)
                    {
                        if (ch != '\"')
                            cur += ch;
                        else
                        {
                            if (buf[pos++] == '\"')
                                cur += '\"';
                            else
                            {
                                pos--;
                                state = 0;
                            }
                        }
                    }
                }
                for (; len < dataCount; len++)
                    value[len] = "";
                ret.Add(value);
            }
            sr.Close();
            return ret;
        }
    }
}
