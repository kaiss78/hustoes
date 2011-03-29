using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OESSupport;
using OESSupport.DB;
using OESSupport.Config;

namespace OESMonitor.Net
{
    public class ServerEvt
    {
        public OESServer Server = new OESServer();
        
        public ServerEvt()
        {
            Server.ip = System.Net.IPAddress.Parse("115.156.227.99");
            Server.AcceptedClient += new EventHandler(Server_AcceptedClient);
            Server.FileReceiveEnd += new DataPortEventHandler(Server_FileReceiveEnd);
            Server.FileSendEnd += new DataPortEventHandler(Server_FileSendEnd);
            Server.SendDataReady += new ClientEventHandel(Server_SendDataReady);
            Server.ReceiveDataReady += new ClientEventHandel(Server_ReceiveDataReady);
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
                        if (Teacher.FindTeacherByClient(Program.TeacherList, client).name == msgs[3])
                        {

                            switch (msgs[2])
                            {
                                case "0":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Config.Paper + msgs[4];
                                    break;
                                case "1":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Config.Word + msgs[4];
                                    break;
                                case "2":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Config.Word + msgs[4];
                                    break;
                                case "3":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Config.Excel + msgs[4];
                                    break;
                                case "4":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Config.Excel + msgs[4];
                                    break;
                                case "5":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Config.PowerPoint + msgs[4];
                                    break;
                                case "6":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Config.PowerPoint + msgs[4];
                                    break;
                                case "7":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Config.CCompletion + msgs[4];
                                    break;
                                case "8":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Config.CModification + msgs[4];
                                    break;
                                case "9":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Config.CFunction + msgs[4];
                                    break;
                                case "A":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Config.CFunction + msgs[4];
                                    break;
                                case "B":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Config.CppCompletion + msgs[4];
                                    break;
                                case "C":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Config.CppModification + msgs[4];
                                    break;
                                case "D":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Config.CppFunction + msgs[4];
                                    break;
                                case "E":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Config.CppFunction + msgs[4];
                                    break;
                                case "F":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Config.VbCompletion + msgs[4];
                                    break;
                                case "G":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Config.VbModification + msgs[4];
                                    break;
                                case "H":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Config.VbCunction + msgs[4];
                                    break;
                                case "I":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Config.VbCunction + msgs[4];
                                    break;
                            }
                        }
                        break;
                    case "2":
                        if (Teacher.FindTeacherByClient(Program.TeacherList, client).name == msgs[3])
                        {
                            switch (msgs[2])
                            {
                                case "0":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = DataControl.getPaper(msgs[4]);
                                    break;
                                case "1":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = DataControl.getWordA(msgs[4]);
                                    break;
                                case "2":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = DataControl.getWordB(msgs[4]);
                                    break;
                                case "3":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = DataControl.getExcelA(msgs[4]);
                                    break;
                                case "4":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = DataControl.getExcelB(msgs[4]);
                                    break;
                                case "5":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = DataControl.getPowerPointA(msgs[4]);
                                    break;
                                case "6":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = DataControl.getPowerPointB(msgs[4]);
                                    break;
                                case "7":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = DataControl.getCCompletion(msgs[4]);
                                    break;
                                case "8":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = DataControl.getCModification(msgs[4]);
                                    break;
                                case "9":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = DataControl.getCFunctionA(msgs[4]);
                                    break;
                                case "A":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = DataControl.getCFunctionB(msgs[4]);
                                    break;
                                case "B":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = DataControl.getCppCompletion(msgs[4]);
                                    break;
                                case "C":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = DataControl.getCppModification(msgs[4]);
                                    break;
                                case "D":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = DataControl.getCppFunctionA(msgs[4]);
                                    break;
                                case "E":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = DataControl.getCppFunctionB(msgs[4]);
                                    break;
                                case "F":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = DataControl.getVbCompletion(msgs[4]);
                                    break;
                                case "G":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = DataControl.getVbModification(msgs[4]);
                                    break;
                                case "H":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = DataControl.getVbFunctionA(msgs[4]);
                                    break;
                                case "I":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = DataControl.getVbFunctionB(msgs[4]);
                                    break;
                            }
                        }
                        break;
                    case "4":
                        Program.TeacherList.Add(new Teacher(msgs[2], client));
                        client.DisConnect += new EventHandler(client_DisConnect);
                        break;
                }
            }
            else if (msgs[0] == "monitor")
            {
                switch (msgs[1])
                {
                    case "0":
                        Program.TeacherList.Add(new Teacher("Monitor", client));
                        client.DisConnect += new EventHandler(client_DisConnect);
                        string temp = "monitor$1";
                        //foreach (Paper p in DataControl.getPaperList())
                        //{
                        //    temp += "$" + p.id + "$" + p.name;
                        //}
                        client.SendTxt(temp);
                        break;
                    case "2":
                        Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = DataControl.getPaper(msgs[2]);
                        break;
                }
            }
        }

        void client_DisConnect(object sender, EventArgs e)
        {
            foreach (Teacher t in Program.TeacherList)
            {
                if (t.client == sender as Client)
                {
                    Program.TeacherList.Remove(t);
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
            client.Port.FilePath = Teacher.FindTeacherByClient(Program.TeacherList, client).filepath;
        }

        void Server_ReceiveDataReady(Client client, string msg)
        {
            client.Port.FilePath = Teacher.FindTeacherByClient(Program.TeacherList, client).filepath;
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
