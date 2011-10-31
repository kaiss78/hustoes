using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Windows.Forms;

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
                    sw.Close();
                }
            }
            catch
            {
                MessageBox.Show("");
            }
        }
        public static bool CheckMD5(string msg)
        {
            byte[] key = md5.ComputeHash(Encoding.UTF8.GetBytes(msg.ToCharArray()));
            string keymsg = new string(Encoding.UTF8.GetChars(key));
            string filekey = "";
         
            using (StreamReader sr = new StreamReader(Config.stuPath + "k.key"))
            {
                filekey = sr.ReadToEnd();
                sr.Close();
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
