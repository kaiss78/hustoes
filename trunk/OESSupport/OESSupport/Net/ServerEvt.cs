using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OESMonitor.Net
{
    public class ServerEvt
    {
        public OESServer Server = new OESServer();
        public ServerEvt()
        {
            Server.AcceptedClient += new EventHandler(Server_AcceptedClient);
            Server.FileReceiveEnd += new DataPortEventHandler(Server_FileReceiveEnd);
            Server.FileSendEnd += new DataPortEventHandler(Server_FileSendEnd);
            Server.SendDataReady += new ClientEventHandel(Server_SendDataReady);
            Server.ReceivedMsg += new ClientEventHandel(Server_ReceivedMsg);
            Server.StartServer();
        }

        void Server_ReceivedMsg(Client client, string msg)
        {
            throw new NotImplementedException();
        }

        void Server_SendDataReady(Client client, string msg)
        {
            throw new NotImplementedException();
        }

        void Server_FileSendEnd(DataPort dataPort)
        {
            throw new NotImplementedException();
        }

        void Server_FileReceiveEnd(DataPort dataPort)
        {
            throw new NotImplementedException();
        }

        void Server_AcceptedClient(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
