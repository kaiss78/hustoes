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
            int state = 0;//标志位
            int len = 0;//字符串数组的索引
            string[] value = new string[dataCount];
            using (StreamReader sr = new StreamReader(path, Encoding.Default))
            {
                content = sr.ReadToEnd();
            }
            content = content.Replace("\"\"", "\0");//将字符串中有两个"的地方替换为 \0;
            while (pos < content.Length)
            {
                if (state == 0)
                {   //完成对字符串引号的处理
                    if (content[pos] == ',')//遇到逗号，需要处理已经读入的文本
                    {
                        value[len++] = content.Substring(bese, pos - bese).Replace("\""," ").Replace('\0', '\"');//将"替换为空 再将原来的\0替换回引号
                        bese = pos+1;
                    }
                    else if(content[pos]=='\"')//遇到第一个引号，state变为1，进入下一个状态
                    {
                        state=1;
                    }
                    else if (content[pos] == '\n')//换行。 
                    {
                        value[len++] = content.Substring(bese, pos - bese).Replace("\"", "").Replace('\0', '\"');
                        bese = pos + 1;
                        ret.Add(value);
                        len = 0;
                        value = new string[dataCount];
                    }
                    pos++;
                }
                else if (state == 1)//如果state=1，文本里有转义字符，放过文本里的所有符号
                {
                    if (content[pos] == '\"')//遇到第二个引号后，整个文本结束，回到状态1处理文本
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
