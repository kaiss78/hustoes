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
        public static List<Object[]> getObjectInCSV(string path, int dataCount) 
        {
            List<Object[]> ret = new List<object[]>();
            Object[] value;
            StreamReader sr = new StreamReader(path, Encoding.GetEncoding("gb2312"));
            string buf;
            string[] data;
            while ((buf = sr.ReadLine()) != null)
            {
                value = new Object[dataCount];
                data = buf.Split(',');
                for (int i = 0; i < dataCount; i++)
                    value[i] = data[i];
                ret.Add(value);
            }
            return ret;
        }
    }
}
