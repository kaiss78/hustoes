using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace OES.DAO
{
    public class MD5File
    {
        static MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
        public static void GenerateSecurityFile(string msg)
        {
            byte[] key=md5.ComputeHash(Encoding.UTF8.GetBytes(msg.ToCharArray()));
            string keymsg = new string(Encoding.UTF8.GetChars(key));
            try
            {
                using (StreamWriter sw = new StreamWriter(Config.stuPath + "k.key"))
                {
                    sw.Write(keymsg);
                }
            }
            catch
            {
            }
            FileInfo fi = new FileInfo(Config.stuPath + "k.key");
            fi.Attributes = fi.Attributes | FileAttributes.Hidden;
        }
        public static bool CheckMD5(string msg)
        {
            byte[] key = md5.ComputeHash(Encoding.UTF8.GetBytes(msg.ToCharArray()));
            string keymsg = new string(Encoding.UTF8.GetChars(key));
            string filekey = "";
            using (StreamReader sr = new StreamReader(Config.stuPath + "k.key"))
            {
                filekey = sr.ReadToEnd();
            }
            if (filekey == keymsg)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
