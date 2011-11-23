using System;
using System.Collections.Generic;
 
using System.Text;
using ClientNet;

namespace OESMonitor.Net
{
    public class ClientEvt
    {
        public OESClient Client;
        public static CommandLine cmdForm = new CommandLine("Support2Monitor.log");
        public ClientEvt()
        {
            cmdForm.Text = "与服务端（support）的通信命令";
            Client = new OESClient();
            Client.ReceivedMsg += new EventHandler(Client_ReceivedMsg);
            Client.WrittenMsg += new EventHandler(Client_WrittenMsg);
            Client.ReceivedTxt += new EventHandler(Client_ReceivedTxt);
            Client.ConnectedServer += new EventHandler(Client_ConnectedServer);
            cmdForm.Show();
        }

        void Client_ReceivedMsg(object sender, EventArgs e)
        {
            cmdForm.showMessage("Read:\t" + sender.ToString());
        }

        void Client_WrittenMsg(object sender, EventArgs e)
        {
            cmdForm.showMessage("Write:\t" + sender.ToString());
        }

        void Client_ConnectedServer(object sender, EventArgs e)
        {
            Client.SendTxt("monitor$0");
        }

        void Client_ReceivedTxt(object sender, EventArgs e)
        {
            
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
