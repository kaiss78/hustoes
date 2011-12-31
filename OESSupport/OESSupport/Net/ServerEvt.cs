using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OESSupport;
using System.IO;
using ServerNet;
using OESSupport.Utility;

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
            PaperControl.Console_Color_WriteLine_Log("Send:\t" + msg, ConsoleColor.White);
        }

        void Server_ReceivedMsg(Client client, string msg)
        {
            PaperControl.Console_Color_WriteLine_Log("Recieve:\t" + msg, ConsoleColor.White);
        }

        void Server_ReceivedTxt(Client client, string msg)
        {
            string[] msgs = msg.Split('$');
            if (msgs[0] == "server")
            {
                switch (msgs[1])
                {
                    case "0":
                        #region 接收客户端发来的文件
                        if (Teacher.FindTeacherByClient(Program.TeacherList, client).name == msgs[3])
                        {
                            switch (msgs[2])
                            {
                                case "0":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Program.config["Root"] + Program.config["Paper"] + msgs[4] + ".xml";
                                    break;
                                case "1":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Program.config["Root"] + Program.config["Root"] + Program.config["Word"] + "a" + msgs[4] + ".doc";
                                    break;
                                case "2":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Program.config["Root"] + Program.config["Word"] + "p" + msgs[4] + ".doc";
                                    break;
                                case "3":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Program.config["Root"] + Program.config["Word"] + "t" + msgs[4] + ".xml";
                                    break;
                                case "4":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Program.config["Root"] + Program.config["Excel"] + "a" + msgs[4] + ".xls";
                                    break;
                                case "5":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Program.config["Root"] + Program.config["Excel"] + "p" + msgs[4] + ".xls";
                                    break;
                                case "6":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Program.config["Root"] + Program.config["Excel"] + "t" + msgs[4] + ".xml";
                                    break;
                                case "7":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Program.config["Root"] + Program.config["PowerPoint"] + "a" + msgs[4] + ".ppt";
                                    break;
                                case "8":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Program.config["Root"] + Program.config["PowerPoint"] + "p" + msgs[4] + ".ppt";
                                    break;
                                case "9":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Program.config["Root"] + Program.config["PowerPoint"] + "t" + msgs[4] + ".xml";
                                    break;
                                case "A":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Program.config["Root"] + Program.config["CCompletion"] + "p" + msgs[4] + ".c";
                                    break;
                                case "B":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Program.config["Root"] + Program.config["CModification"] + "p" + msgs[4] + ".c";
                                    break;
                                case "C":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Program.config["Root"] + Program.config["CFunction"] + "a" + msgs[4] + ".c";
                                    break;
                                case "D":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Program.config["Root"] + Program.config["CFunction"] + "p" + msgs[4] + ".c";
                                    break;
                                case "E":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Program.config["Root"] + Program.config["CppCompletion"] + "p" + msgs[4] + ".cpp";
                                    break;
                                case "F":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Program.config["Root"] + Program.config["CppModification"] + "p" + msgs[4] + ".cpp";
                                    break;
                                case "G":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Program.config["Root"] + Program.config["CppFunction"] + "a" + msgs[4] + ".cpp";
                                    break;
                                case "H":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Program.config["Root"] + Program.config["CppFunction"] + "p" + msgs[4] + ".cpp";
                                    break;
                                case "I":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Program.config["Root"] + Program.config["VbCompletion"] + "p" + msgs[4] + ".vb";
                                    break;
                                case "J":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Program.config["Root"] + Program.config["VbModification"] + "p" + msgs[4] + ".vb";
                                    break;
                                case "K":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Program.config["Root"] + Program.config["VbFunction"] + "a" + msgs[4] + ".vb";
                                    break;
                                case "L":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Program.config["Root"] + Program.config["VbFunction"] + "p" + msgs[4] + ".vb";
                                    break;
                                case "M":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Program.config["Root"] + Program.config["PaperPkg"] + msgs[4] + ".rar";
                                    break;
                                case "N":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Program.config["Root"] + Program.config["Paper"] + 'A' + msgs[4] + ".xml";
                                    break;
                            }

                        }
                        #endregion
                        break;
                    case "2":
                        #region 发送给客户端文件
                        if (Teacher.FindTeacherByClient(Program.TeacherList, client).name == msgs[3])
                        {
                            switch (msgs[2])
                            {
                                case "0":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Program.config["Root"] + Program.config["Paper"] + msgs[4] + ".xml";
                                    break;
                                case "1":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Program.config["Root"] + Program.config["Word"] + "a" + msgs[4] + ".doc";
                                    break;
                                case "2":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Program.config["Root"] + Program.config["Word"] + "p" + msgs[4] + ".doc";
                                    break;
                                case "3":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Program.config["Root"] + Program.config["Word"] + "t" + msgs[4] + ".xml";
                                    break;
                                case "4":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Program.config["Root"] + Program.config["Excel"] + "a" + msgs[4] + ".xls";
                                    break;
                                case "5":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Program.config["Root"] + Program.config["Excel"] + "p" + msgs[4] + ".xls";
                                    break;
                                case "6":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Program.config["Root"] + Program.config["Excel"] + "t" + msgs[4] + ".xml";
                                    break;
                                case "7":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Program.config["Root"] + Program.config["PowerPoint"] + "a" + msgs[4] + ".ppt";
                                    break;
                                case "8":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Program.config["Root"] + Program.config["PowerPoint"] + "p" + msgs[4] + ".ppt";
                                    break;
                                case "9":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Program.config["Root"] + Program.config["PowerPoint"] + "t" + msgs[4] + ".xml";
                                    break;
                                case "A":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Program.config["Root"] + Program.config["CCompletion"] + "p" + msgs[4] + ".c";
                                    break;
                                case "B":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Program.config["Root"] + Program.config["CModification"] + "p" + msgs[4] + ".c";
                                    break;
                                case "C":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Program.config["Root"] + Program.config["CFunction"] + "a" + msgs[4] + ".c";
                                    break;
                                case "D":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Program.config["Root"] + Program.config["CFunction"] + "p" + msgs[4] + ".c";
                                    break;
                                case "E":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Program.config["Root"] + Program.config["CppCompletion"] + "p" + msgs[4] + ".cpp";
                                    break;
                                case "F":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Program.config["Root"] + Program.config["CppModification"] + "p" + msgs[4] + ".cpp";
                                    break;
                                case "G":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Program.config["Root"] + Program.config["CppFunction"] + "a" + msgs[4] + ".cpp";
                                    break;
                                case "H":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Program.config["Root"] + Program.config["CppFunction"] + "p" + msgs[4] + ".cpp";
                                    break;
                                case "I":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Program.config["Root"] + Program.config["VbCompletion"] + "p" + msgs[4] + ".vb";
                                    break;
                                case "J":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Program.config["Root"] + Program.config["VbModification"] + "p" + msgs[4] + ".vb";
                                    break;
                                case "K":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Program.config["Root"] + Program.config["VbFunction"] + "a" + msgs[4] + ".vb";
                                    break;
                                case "L":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Program.config["Root"] + Program.config["VbFunction"] + "p" + msgs[4] + ".vb";
                                    break;
                                case "M":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Program.config["Root"] + Program.config["PaperPkg"] + msgs[4] + ".rar";
                                    if (!File.Exists(Teacher.FindTeacherByClient(Program.TeacherList, client).filepath))
                                    {
                                        XMLtoXML.xmltoxml(Program.config["Root"] + Program.config["Paper"] + msgs[4] + ".xml");
                                    }
                                    break;
                                case "N":
                                    Teacher.FindTeacherByClient(Program.TeacherList, client).filepath = Program.config["Root"] + Program.config["Paper"] + 'A' + msgs[4] + ".xml";
                                    break;
                            }

                        }
                        #endregion
                        break;
                    case "4":
                        #region 教师登录
                        Program.TeacherList.Add(new Teacher(msgs[2], client));
                        client.DisConnect += new EventHandler(client_DisConnect);
                        #endregion
                        break;
                    case "6":
                        #region 删除数据库文件
                        if (Teacher.FindTeacherByClient(Program.TeacherList, client).name == msgs[3])
                        {
                            switch (msgs[2])
                            {
                                case "0":
                                    if (File.Exists(Program.config["Root"] + Program.config["Paper"] + msgs[4] + ".xml"))
                                    {
                                        File.Delete(Program.config["Root"] + Program.config["Paper"] + msgs[4] + ".xml");
                                    }
                                    break;
                                case "1":
                                    if (File.Exists(Program.config["Root"] + Program.config["Word"] + "a" + msgs[4] + ".doc"))
                                    {
                                        File.Delete(Program.config["Root"] + Program.config["Word"] + "a" + msgs[4] + ".doc");
                                    }
                                    break;
                                case "2":
                                    if (File.Exists(Program.config["Root"] + Program.config["Word"] + "p" + msgs[4] + ".doc"))
                                    {
                                        File.Delete(Program.config["Root"] + Program.config["Word"] + "p" + msgs[4] + ".doc");
                                    } 
                                    break;
                                case "3":
                                    if (File.Exists(Program.config["Root"] + Program.config["Word"] + "t" + msgs[4] + ".xml"))
                                    {
                                        File.Delete(Program.config["Root"] + Program.config["Word"] + "t" + msgs[4] + ".xml");
                                    }
                                    break;
                                case "4":
                                    if (File.Exists(Program.config["Root"] + Program.config["Excel"] + "a" + msgs[4] + ".xls"))
                                    {
                                        File.Delete(Program.config["Root"] + Program.config["Excel"] + "a" + msgs[4] + ".xls");
                                    } 
                                    break;
                                case "5":
                                    if (File.Exists(Program.config["Root"] + Program.config["Excel"] + "p" + msgs[4] + ".xls"))
                                    {
                                        File.Delete(Program.config["Root"] + Program.config["Excel"] + "p" + msgs[4] + ".xls");
                                    }
                                    break;
                                case "6":
                                    if (File.Exists(Program.config["Root"] + Program.config["Excel"] + "t" + msgs[4] + ".xml"))
                                    {
                                        File.Delete(Program.config["Root"] + Program.config["Excel"] + "t" + msgs[4] + ".xml");
                                    } 
                                    break;
                                case "7":
                                    if (File.Exists(Program.config["Root"] + Program.config["PowerPoint"] + "a" + msgs[4] + ".ppt"))
                                    {
                                        File.Delete(Program.config["Root"] + Program.config["PowerPoint"] + "a" + msgs[4] + ".ppt");
                                    } 
                                    break;
                                case "8":
                                    if (File.Exists(Program.config["Root"] + Program.config["PowerPoint"] + "p" + msgs[4] + ".ppt"))
                                    {
                                        File.Delete(Program.config["Root"] + Program.config["PowerPoint"] + "p" + msgs[4] + ".ppt");
                                    } 
                                    break;
                                case "9":
                                    if (File.Exists(Program.config["Root"] + Program.config["PowerPoint"] + "t" + msgs[4] + ".xml"))
                                    {
                                        File.Delete(Program.config["Root"] + Program.config["PowerPoint"] + "t" + msgs[4] + ".xml");
                                    } 
                                    break;
                                case "A":
                                    if (File.Exists(Program.config["Root"] + Program.config["CCompletion"] + "p" + msgs[4] + ".c"))
                                    {
                                        File.Delete(Program.config["Root"] + Program.config["CCompletion"] + "p" + msgs[4] + ".c");
                                    } 
                                    break;
                                case "B":
                                    if (File.Exists(Program.config["Root"] + Program.config["CModification"] + "p" + msgs[4] + ".c"))
                                    {
                                        File.Delete(Program.config["Root"] + Program.config["CModification"] + "p" + msgs[4] + ".c");
                                    } 
                                    break;
                                case "C":
                                    if (File.Exists(Program.config["Root"] + Program.config["CFunction"] + "a" + msgs[4] + ".c"))
                                    {
                                        File.Delete(Program.config["Root"] + Program.config["CFunction"] + "a" + msgs[4] + ".c");
                                    }
                                    break;
                                case "D":
                                    if (File.Exists(Program.config["Root"] + Program.config["CFunction"] + "p" + msgs[4] + ".c"))
                                    {
                                        File.Delete(Program.config["Root"] + Program.config["CFunction"] + "p" + msgs[4] + ".c");
                                    }
                                    break;
                                case "E":
                                    if (File.Exists(Program.config["Root"] + Program.config["CppCompletion"] + "p" + msgs[4] + ".cpp"))
                                    {
                                        File.Delete(Program.config["Root"] + Program.config["CppCompletion"] + "p" + msgs[4] + ".cpp");
                                    }
                                    break;
                                case "F":
                                    if (File.Exists(Program.config["Root"] + Program.config["CppModification"] + "p" + msgs[4] + ".cpp"))
                                    {
                                        File.Delete(Program.config["Root"] + Program.config["CppModification"] + "p" + msgs[4] + ".cpp");
                                    }
                                    break;
                                case "G":
                                    if (File.Exists(Program.config["Root"] + Program.config["CppFunction"] + "a" + msgs[4] + ".cpp"))
                                    {
                                        File.Delete(Program.config["Root"] + Program.config["CppFunction"] + "a" + msgs[4] + ".cpp");
                                    }
                                    break;
                                case "H":
                                    if (File.Exists(Program.config["Root"] + Program.config["CppFunction"] + "p" + msgs[4] + ".cpp"))
                                    {
                                        File.Delete(Program.config["Root"] + Program.config["CppFunction"] + "p" + msgs[4] + ".cpp");
                                    }
                                    break;
                                case "I":
                                    if (File.Exists(Program.config["Root"] + Program.config["VbCompletion"] + "p" + msgs[4] + ".vb"))
                                    {
                                        File.Delete(Program.config["Root"] + Program.config["VbCompletion"] + "p" + msgs[4] + ".vb");
                                    }
                                    break;
                                case "J":
                                    if (File.Exists(Program.config["Root"] + Program.config["VbModification"] + "p" + msgs[4] + ".vb"))
                                    {
                                        File.Delete(Program.config["Root"] + Program.config["VbModification"] + "p" + msgs[4] + ".vb");
                                    }
                                    break;
                                case "K":
                                    if (File.Exists(Program.config["Root"] + Program.config["VbFunction"] + "a" + msgs[4] + ".vb"))
                                    {
                                        File.Delete(Program.config["Root"] + Program.config["VbFunction"] + "a" + msgs[4] + ".vb");
                                    }
                                    break;
                                case "L":
                                    if (File.Exists(Program.config["Root"] + Program.config["VbFunction"] + "p" + msgs[4] + ".vb"))
                                    {
                                        File.Delete(Program.config["Root"] + Program.config["VbFunction"] + "p" + msgs[4] + ".vb");
                                    }
                                    break;
                                case "M":
                                    if (File.Exists(Program.config["Root"] + Program.config["PaperPkg"] + msgs[4] + ".rar"))
                                    {
                                        File.Delete(Program.config["Root"] + Program.config["PaperPkg"] + msgs[4] + ".rar");
                                    }
                                    break;
                                case "N":
                                    if (File.Exists(Program.config["Root"] + Program.config["Paper"] + 'A' + msgs[4] + ".xml"))
                                    {
                                        File.Delete(Program.config["Root"] + Program.config["Paper"] + 'A' + msgs[4] + ".xml");
                                    }
                                    break;
                            }

                        }
                        #endregion
                        break;
                }
            }
            else if (msgs[0] == "monitor")
            {
                switch (msgs[1])
                {
                    case "0":
                        #region Monitor端登录
                        Program.TeacherList.Add(new Teacher("0", client));
                        client.DisConnect += new EventHandler(client_DisConnect);
                        string temp = "monitor$1";
                        client.SendTxt(temp);
                        #endregion
                        break;
                    case "2":

                        break;
                }
            }
            else if (msgs[0] == "score")
            {
                switch (msgs[1])
                {
                    case "0":
                        #region Score端登录
                        Program.TeacherList.Add(new Teacher("-1", client));
                        client.DisConnect += new EventHandler(client_DisConnect);
                        string temp = "score$1";
                        client.SendTxt(temp);
                        #endregion
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
                    PaperControl.Console_Color_WriteLine_Log(t.ToString() + " Logout...", ConsoleColor.DarkYellow);
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
            PaperControl.Console_Color_WriteLine_Log("File Send End!", ConsoleColor.Green);
        }

        void Server_FileReceiveEnd(DataPort dataPort)
        {
            PaperControl.Console_Color_WriteLine_Log("File Receive End!", ConsoleColor.Green);
        }

        void Server_AcceptedClient(object sender, EventArgs e)
        {
            PaperControl.Console_Color_WriteLine_Log("A Teacher Login...", ConsoleColor.Yellow);
        }


    }
}
