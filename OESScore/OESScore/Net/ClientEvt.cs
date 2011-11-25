using System;
using System.Collections.Generic;

using System.Text;
using System.IO;
using ClientNet;
using OESScore;

namespace OES.Net
{
    public class ClientEvt
    {
        public static OESClient Client = new OESClient();
        public static event EventHandler LoginReturn;
        public static string RootPath = "";
        List<string> remoteCom = new List<string>();
        List<string> localPath = new List<string>();
        public static Boolean isOver = true;

        public ClientEvt()
        {
            
        }
        public void Init()
        {
            Client.InitializeClient();
            Client.ReceivedTxt += new EventHandler(Client_ReceivedTxt);
            Client.Port.FileReceiveEnd += new EventHandler(Port_FileReceiveEnd);
            Client.Port.FileSendEnd += new EventHandler(Port_FileSendEnd);
            Client.ConnectedServer += new EventHandler(Client_ConnectedServer);
        }

        void Client_ConnectedServer(object sender, EventArgs e)
        {
            this.Login();
        }
        void Port_FileSendEnd(object sender, EventArgs e)
        {

        }

        void Port_FileReceiveEnd(object sender, EventArgs e)
        {

        }

        public void SendFiles()
        {
            isOver = false;
            Client.SendFileList(remoteCom, localPath);
            Client.FileListSendEnd += new Action(Client_FileListSendEnd);
        }

        void Client_FileListSendEnd()
        {
            remoteCom.Clear();
            localPath.Clear();
            isOver = true;
        }

        public void ReceiveFiles()
        {
            isOver = false;
            Client.ReceiveFileList(remoteCom, localPath);
            Client.FileListRecieveEnd += new Action(Client_FileListRecieveEnd);

        }

        void Client_FileListRecieveEnd()
        {
            remoteCom.Clear();
            localPath.Clear();
            isOver = true;
        }

        static void Client_ReceivedTxt(object sender, EventArgs e)
        {
            
        }

        public void Login()
        {
            Client.SendTxt("score$0");
        }
        public void LoadPaper(int id, int tid)
        {
            localPath.Add(RootPath + id.ToString() + ".xml");
            remoteCom.Add("server$2$0$" + tid.ToString() + "$" + id.ToString());
            localPath.Add(RootPath + 'A' + id.ToString() + ".xml");
            remoteCom.Add("server$2$N$" + tid.ToString() + "$" + id.ToString());
        }
        public void LoadWordA(int id, int tid)
        {
            localPath.Add(RootPath + "a" + id.ToString() + ".doc");
            remoteCom.Add("server$2$1$" + tid.ToString() + "$" + id.ToString());
        }
        public void LoadWordP(int id, int tid)
        {
            localPath.Add(RootPath + "p" + id.ToString() + ".doc");
            remoteCom.Add("server$2$2$" + tid.ToString() + "$" + id.ToString());

        }
        public void LoadWordT(int id, int tid)
        {
            localPath.Add(RootPath + "t" + id.ToString() + ".xml");
            remoteCom.Add("server$2$3$" + tid.ToString() + "$" + id.ToString());

        }
        public void LoadExcelA(int id, int tid)
        {
            localPath.Add(RootPath + "a" + id.ToString() + ".xls");
            remoteCom.Add("server$2$4$" + tid.ToString() + "$" + id.ToString());

        }
        public void LoadExcelP(int id, int tid)
        {
            localPath.Add(RootPath + "p" + id.ToString() + ".xls");
            remoteCom.Add("server$2$5$" + tid.ToString() + "$" + id.ToString());

        }
        public void LoadExcelT(int id, int tid)
        {
            localPath.Add(RootPath + "t" + id.ToString() + ".xml");
            remoteCom.Add("server$2$6$" + tid.ToString() + "$" + id.ToString());

        }
        public void LoadPowerPointA(int id, int tid)
        {
            localPath.Add(RootPath + "a" + id.ToString() + ".ppt");
            remoteCom.Add("server$2$7$" + tid.ToString() + "$" + id.ToString());

        }
        public void LoadPowerPointP(int id, int tid)
        {
            localPath.Add(RootPath + "p" + id.ToString() + ".ppt");
            remoteCom.Add("server$2$8$" + tid.ToString() + "$" + id.ToString());

        }
        public void LoadPowerPointT(int id, int tid)
        {
            localPath.Add(RootPath + "t" + id.ToString() + ".xml");
            remoteCom.Add("server$2$9$" + tid.ToString() + "$" + id.ToString());

        }
        public void LoadCCompletion(int id, int tid)
        {
            localPath.Add(RootPath + id.ToString() + ".c");
            remoteCom.Add("server$2$A$" + tid.ToString() + "$" + id.ToString());

        }
        public void LoadCModification(int id, int tid)
        {
            localPath.Add(RootPath + id.ToString() + ".c");
            remoteCom.Add("server$2$B$" + tid.ToString() + "$" + id.ToString());

        }
        public void LoadCFunctionA(int id, int tid)
        {
            localPath.Add(RootPath + "a" + id.ToString() + ".c");
            remoteCom.Add("server$2$C$" + tid.ToString() + "$" + id.ToString());

        }
        public void LoadCFunctionP(int id, int tid)
        {
            localPath.Add(RootPath + "p" + id.ToString() + ".c");
            remoteCom.Add("server$2$D$" + tid.ToString() + "$" + id.ToString());

        }
        public void LoadCppCompletion(int id, int tid)
        {
            localPath.Add(RootPath + id.ToString() + ".cpp");
            remoteCom.Add("server$2$E$" + tid.ToString() + "$" + id.ToString());

        }
        public void LoadCppModification(int id, int tid)
        {
            localPath.Add(RootPath + id.ToString() + ".cpp");
            remoteCom.Add("server$2$F$" + tid.ToString() + "$" + id.ToString());

        }
        public void LoadCppFunctionA(int id, int tid)
        {
            localPath.Add(RootPath + "a" + id.ToString() + ".cpp");
            remoteCom.Add("server$2$G$" + tid.ToString() + "$" + id.ToString());

        }
        public void LoadCppFunctionP(int id, int tid)
        {
            localPath.Add(RootPath + "p" + id.ToString() + ".cpp");
            remoteCom.Add("server$2$H$" + tid.ToString() + "$" + id.ToString());

        }
        public void LoadVbCompletion(int id, int tid)
        {
            localPath.Add(RootPath + id.ToString() + ".vb");
            remoteCom.Add("server$2$I$" + tid.ToString() + "$" + id.ToString());

        }
        public void LoadVbModification(int id, int tid)
        {
            localPath.Add(RootPath + id.ToString() + ".vb");
            remoteCom.Add("server$2$J$" + tid.ToString() + "$" + id.ToString());

        }
        public void LoadVbFunctionA(int id, int tid)
        {
            localPath.Add(RootPath + "a" + id.ToString() + ".vb");
            remoteCom.Add("server$2$K$" + tid.ToString() + "$" + id.ToString());

        }
        public void LoadVbFunctionP(int id, int tid)
        {
            localPath.Add(RootPath + "p" + id.ToString() + ".vb");
            remoteCom.Add("server$2$L$" + tid.ToString() + "$" + id.ToString());

        }

    }
}
