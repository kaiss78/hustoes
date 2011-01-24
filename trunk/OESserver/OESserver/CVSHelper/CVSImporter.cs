using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace OES.CVSHelper
{
    public class CVSImporter
    {
        //从csv文件中读取数据 path:文件路径 dataCount:一行的数据个数
        public static List<Object[]> getObjectInCSV(string path, int dataCount) 
        {
            List<Object[]> ret = new List<object[]>();
            Object[] value = new Object[dataCount];
            StreamReader sr = new StreamReader(path, Encoding.UTF8);
            string buf;
            string[] data;
            while ((buf = sr.ReadLine()) != null)
            {
                buf = sr.ReadLine();
                if (buf == "") { break; }
                data = buf.Split(',');
                for (int i = 0; i < dataCount; i++)
                    value[i] = data[i];
                ret.Add(value);
            }
            return ret;
        }
    }
}
