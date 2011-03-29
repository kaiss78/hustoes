using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;

namespace OESMonitor.Net
{
    public class ServerConfig
    {
        const string FileTemplate = 
@"HostIp=127.0.0.1
HostPort=20000
DataPortNum=20";
        const string ConfName = "ServerConfig.ini";
        private Dictionary<string, string> dirc = new Dictionary<string, string>();
        private static ServerConfig instence=null;
        private ServerConfig()
        {
            if (File.Exists(ConfName))
            {
                using (StreamReader sr = new StreamReader(ConfName))
                {
                    dirc.Clear();
                    string[] eachLine = sr.ReadToEnd().Split('\n');
                    foreach (string line in eachLine)
                    {
                        string[] sep = line.Split('=');
                        dirc.Add(sep[0].Trim(), sep[1].Trim());
                    }
                }
            }
            else
            {
                using (StreamWriter sr = new StreamWriter(ConfName))
                {
                    dirc.Clear();
                    sr.Write(FileTemplate);
                }
            }
        }
        private static ServerConfig GetInstence()
        {
            if(instence==null)
            {
                return new ServerConfig();
            }
            else
            {
                return instence;
            }
        }
        public static IPAddress HostIp
        {
            get
            {
                return IPAddress.Parse(GetInstence().dirc["HostIp"]);
            }
        }
        public static int HostPort
        {
            get
            {
                return Convert.ToInt32(GetInstence().dirc["HostPort"]);
            }
        }
        public static int DataPortNum
        {
            get
            {
                return Convert.ToInt32(GetInstence().dirc["DataPortNum"]);
            }
        }
    }
}
