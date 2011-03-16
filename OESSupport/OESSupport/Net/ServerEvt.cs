using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OESSupport;

namespace OESMonitor.Net
{
    public class ServerEvt
    {
        public OESServer Server = new OESServer();
        public List<Teacher> TeacherList = new List<Teacher>();
        public ServerEvt()
        {
            Server.ip = System.Net.IPAddress.Parse("115.156.227.238");
            Server.AcceptedClient += new EventHandler(Server_AcceptedClient);
            Server.FileReceiveEnd += new DataPortEventHandler(Server_FileReceiveEnd);
            Server.FileSendEnd += new DataPortEventHandler(Server_FileSendEnd);
            Server.SendDataReady += new ClientEventHandel(Server_SendDataReady);
            Server.ReceivedMsg += new ClientEventHandel(Server_ReceivedMsg);
            Server.ReceivedTxt += new ClientEventHandel(Server_ReceivedTxt);
            Server.StartServer();
           
        }

        void Server_ReceivedTxt(Client client, string msg)
        {
            string[] msgs = msg.Split('$');
            if (msgs[0] == "server")
            {
                switch (msgs[1])
                {
                    case "0":
                        switch (msgs[2])
                        {
                            case "0":
                                

                                break;
                            case"1":

                                break;
                        }
                        break;
                    case "1":
                        switch (msgs[2])
                        {
                            case "0":

                                break;
                            case "1":

                                break;
                        }
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    case "5":
                        break;
                    case "6":
                        break;
                }
            }
        }

        void Server_ReceivedMsg(Client client, string msg)
        {
            Console.WriteLine(msg);
        }

        void Server_SendDataReady(Client client, string msg)
        {
            
        }

        void Server_FileSendEnd(DataPort dataPort)
        {
            
        }

        void Server_FileReceiveEnd(DataPort dataPort)
        {
            
        }

        void Server_AcceptedClient(object sender, EventArgs e)
        {
            
        }
    }
}
