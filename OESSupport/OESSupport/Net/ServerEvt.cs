using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OESSupport;
using OESSupport.Configuration;

namespace OESSupport.Net
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
            Server.ReceiveDataReady += new ClientEventHandel(Server_ReceiveDataReady);
            Server.ReceivedMsg += new ClientEventHandel(Server_ReceivedMsg);
            Server.ReceivedTxt += new ClientEventHandel(Server_ReceivedTxt);
            Server.WrittenMsg += new ClientEventHandel(Server_WrittenMsg);
            Server.StartServer();
        }

        void Server_WrittenMsg(Client client, string msg)
        {
            Console.WriteLine("Send:\t"+msg);
        }

        void Server_ReceivedMsg(Client client, string msg)
        {
            Console.WriteLine("Recieve:\t"+msg);
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
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Config.Root+ Config.Paper + msgs[4]+".xml";
                                    break;
                                case "1":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Config.Root + Config.Root + Config.Word + "a" + msgs[4] + ".doc";
                                    break;
                                case "2":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Config.Root + Config.Word + "p" + msgs[4] + ".doc";
                                    break;
                                case "3":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Config.Root + Config.Word + "t" + msgs[4] + ".xml";
                                    break;
                                case "4":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Config.Root + Config.Excel + "a" + msgs[4] + ".xls";
                                    break;
                                case "5":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Config.Root + Config.Excel + "p" + msgs[4] + ".xls";
                                    break;
                                case "6":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Config.Root + Config.Excel + "t" + msgs[4] + ".xml";
                                    break;
                                case "7":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Config.Root + Config.PowerPoint + "a" + msgs[4] + ".ppt";
                                    break;
                                case "8":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Config.Root + Config.PowerPoint + "p" + msgs[4] + ".ppt";
                                    break;
                                case "9":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Config.Root + Config.PowerPoint + "t" + msgs[4] + ".xml";
                                    break;
                                case "A":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Config.Root + Config.CCompletion + "p" + msgs[4] + ".c";
                                    break;
                                case "B":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Config.Root + Config.CModification + "p" + msgs[4] + ".c";
                                    break;
                                case "C":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Config.Root + Config.CFunction + "a" + msgs[4] + ".c";
                                    break;
                                case "D":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Config.Root + Config.CFunction + "p" + msgs[4] + ".c";
                                    break;
                                case "E":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Config.Root + Config.CppCompletion + "p" + msgs[4] + ".cpp";
                                    break;
                                case "F":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Config.Root + Config.CppModification + "p" + msgs[4] + ".cpp";
                                    break;
                                case "G":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Config.Root + Config.CppFunction + "a" + msgs[4] + ".cpp";
                                    break;
                                case "H":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Config.Root + Config.CppFunction + "p" + msgs[4] + ".cpp";
                                    break;
                                case "I":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Config.Root + Config.VbCompletion + "p" + msgs[4] + ".vb";
                                    break;
                                case "J":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Config.Root + Config.VbModification + "p" + msgs[4] + ".vb";
                                    break;
                                case "K":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Config.Root + Config.VbFunction + "a" + msgs[4] + ".vb";
                                    break;
                                case "L":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Config.Root + Config.VbFunction + "p" + msgs[4] + ".vb";
                                    break;
                                case "M":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Config.Root + Config.PaperPkg + msgs[4] + ".rar";
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
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Config.Root + Config.Paper + msgs[4] + ".xml";
                                    break;
                                case "1":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Config.Root + Config.Word + "a" + msgs[4] + ".doc";
                                    break;
                                case "2":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Config.Root + Config.Word + "p" + msgs[4] + ".doc";
                                    break;
                                case "3":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Config.Root + Config.Word + "t" + msgs[4] + ".xml";
                                    break;
                                case "4":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Config.Root + Config.Excel + "a" + msgs[4] + ".xls";
                                    break;
                                case "5":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Config.Root + Config.Excel + "p" + msgs[4] + ".xls";
                                    break;
                                case "6":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Config.Root + Config.Excel + "t" + msgs[4] + ".xml";
                                    break;
                                case "7":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Config.Root + Config.PowerPoint + "a" + msgs[4] + ".ppt";
                                    break;
                                case "8":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Config.Root + Config.PowerPoint + "p" + msgs[4] + ".ppt";
                                    break;
                                case "9":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Config.Root + Config.PowerPoint + "t" + msgs[4] + ".xml";
                                    break;
                                case "A":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Config.Root + Config.CCompletion + "p" + msgs[4] + ".c";
                                    break;
                                case "B":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Config.Root + Config.CModification + "p" + msgs[4] + ".c";
                                    break;
                                case "C":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Config.Root + Config.CFunction + "a" + msgs[4] + ".c";
                                    break;
                                case "D":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Config.Root + Config.CFunction + "p" + msgs[4] + ".c";
                                    break;
                                case "E":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Config.Root + Config.CppCompletion + "p" + msgs[4] + ".cpp";
                                    break;
                                case "F":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Config.Root + Config.CppModification + "p" + msgs[4] + ".cpp";
                                    break;
                                case "G":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Config.Root + Config.CppFunction + "a" + msgs[4] + ".cpp";
                                    break;
                                case "H":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Config.Root + Config.CppFunction + "p" + msgs[4] + ".cpp";
                                    break;
                                case "I":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Config.Root + Config.VbCompletion + "p" + msgs[4] + ".vb";
                                    break;
                                case "J":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Config.Root + Config.VbModification + "p" + msgs[4] + ".vb";
                                    break;
                                case "K":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Config.Root + Config.VbFunction + "a" + msgs[4] + ".vb";
                                    break;
                                case "L":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Config.Root + Config.VbFunction + "p" + msgs[4] + ".vb";
                                    break;
                                case "M":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Config.Root + Config.PaperPkg + msgs[4] + ".rar";
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
                        Program.TeacherList.Add(new Teacher("0", client));
                        client.DisConnect += new EventHandler(client_DisConnect);
                        string temp = "monitor$1";
                        //foreach (Paper p in DataControl.getPaperList())
                        //{
                        //    temp += "$" + p.id + "$" + p.name;
                        //}
                        client.SendTxt(temp);
                        break;
                    case "2":
                        
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
