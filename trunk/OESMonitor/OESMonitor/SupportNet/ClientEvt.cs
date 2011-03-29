using System;
using System.Collections.Generic;
 
using System.Text;
using OESMonitor.PaperControl;

namespace OESMonitor.SupportNet
{
    public class ClientEvt
    {
        public OESClient Client;
        public Config conf;
        public ClientEvt()
        {
            conf=new Config();
            Client = new OESClient();
            Client.ReceivedTxt += new EventHandler(Client_ReceivedTxt);
            Client.InitializeClient();
        }

        void Client_ReceivedTxt(object sender, EventArgs e)
        {
            Console.WriteLine(sender.ToString());
        }
    }
}
