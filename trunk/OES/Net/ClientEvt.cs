using System;
using System.Collections.Generic;
 
using System.Text;

namespace OES.Net
{
    public class ClientEvt
    {
        public static OESClient Client = new OESClient();
        public static event EventHandler LoginReturn;
        public static event EventHandler ConfirmReStart;
      
        public static void validStudent(string name, string id, string pwd)
        {
            Net.ClientEvt.Client.ReceivedTxt += new EventHandler(Client_ReceivedTxt);
            Client.SendTxt("oes$0$" + name + "$" + id + "$" + pwd);
        }

        static void Client_ReceivedTxt(object sender, EventArgs e)
        {
            string[] msgs=sender.ToString().Split('$');
            if (msgs[0] == "oes")
            {
                switch (msgs[1])
                {
                    case "1":
                        switch (msgs[2])
                        {
                            case "1":
                                if (LoginReturn != null)
                                {
                                    LoginReturn(msgs[3], null);
                                }
                                break;
                            case "0":
                                if (LoginReturn != null)
                                {
                                    LoginReturn(null, null);
                                }
                                break;
                        }
                        break;
                    case "2":
                        if (msgs[2] == "4")
                        {
                            if (ConfirmReStart != null)
                            {
                                ConfirmReStart(null, null);
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
        }


        public static void beginExam(int p,string pwd)
        {
            switch (p)
            {
                case 0:
                case 1:
                case 2:
                    Client.SendTxt("oes$2$" + p.ToString());
                    break;
                case 3:
                    Client.SendTxt("oes$2$3$" + pwd);
                    break;
            }
        }

        public static void logout()
        {
            Client.SendTxt("oes$3");
        }

        public static string Paper
        {
            get 
            {
                return ClientEvt.Client.Port.FilePath;
            }
            set 
            {
                ClientEvt.Client.Port.FilePath = value;
            }
        }

        public static string Answer
        {
            get
            {
                return ClientEvt.Client.Port.FilePath;
            }
            set 
            {
                ClientEvt.Client.Port.FilePath = value;
            }
        }
    }
}
