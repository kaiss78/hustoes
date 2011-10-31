using System;
using System.Collections.Generic;
using System.Text;

namespace OES
{
    class Program
    {
        static OESConfig config = new OESConfig("con1.xml");
        static void Main(string[] args)
        {
            config["ip"] = "";
            Console.WriteLine(config["port"]);
            Dictionary<string,string> a= config.GetAllConfig();
        }
    }
}
