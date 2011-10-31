using System;
using System.Collections.Generic;
 
using System.Text;
using ClientNet;

namespace OESMonitor.Net
{
    public class ClientEvt
    {
        public OESClient Client;
      
        public ClientEvt()
        {
            Client = new OESClient();
            Client.ReceivedTxt += new EventHandler(Client_ReceivedTxt);
            Client.ConnectedServer += new EventHandler(Client_ConnectedServer);
            Client.InitializeClient();
        }

        void Client_ConnectedServer(object sender, EventArgs e)
        {
            Client.SendTxt("monitor$0");
        }

        void Client_ReceivedTxt(object sender, EventArgs e)
        {
            Console.WriteLine(sender.ToString());
        }

        public string LoadPaper(int id, int tid)
        {
            return "server$2$0$" + tid.ToString() + "$" + id.ToString();
        }
        public string LoadPaperPkg(int id, int tid)
        {
            return "server$2$M$" + tid.ToString() + "$" + id.ToString();
        }
        
    }
}
