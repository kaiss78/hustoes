using System;
using System.Collections.Generic;
using System.Text;

namespace OESConfig
{
    class Program
    {
        static OESConfig config = new OESConfig("con1.xml");
        static void Main(string[] args)
        {
            config["ip"] = "123456";
            Console.WriteLine(config["port"]);
        }
    }
}
