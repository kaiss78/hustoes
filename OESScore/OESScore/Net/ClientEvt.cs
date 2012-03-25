using System;
using System.Collections.Generic;

using System.Text;
using System.IO;
using ClientNet;
using OESScore;
using System.Windows.Forms;

namespace OES.Net
{
    public class ClientEvt
    {
        //文件操作完成事件，需要用时注册
        public static event Action FilesComplete;

        public static OESClient Client = new OESClient();
        public static event EventHandler LoginReturn;
        public static string RootPath = "";
        List<string> remoteCom = new List<string>();
        List<string> localPath = new List<string>();
        public static Boolean isOver = true;
        public static Boolean isError = false;

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
            Client.Port.RecieveFileRate += new ReturnVal(Port_RecieveFileRate);
            Client.Port.SendFileRate += new ReturnVal(Port_SendFileRate);
            Client.FileListCount += new FileListSize(Client_FileListCount);
            Client.FileListRecieveStart += new Action(Client_FileListRecieveStart);
            Client.FileListSendStart += new Action(Client_FileListSendStart);
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

        void Client_FileListSendStart()
        {
            while (!Program.MainForm.IsHandleCreated) ;
            Program.MainForm.BeginInvoke(new Action(() =>
            {
                FileListWaiting.Instance.ShowDialog();
            }));
        }

        void Client_FileListRecieveStart()
        {
            while (!Program.MainForm.IsHandleCreated) ;
            Program.MainForm.BeginInvoke(new Action(() =>
            {
                FileListWaiting.Instance.ShowDialog();
            }));
        }

        void Client_FileListCount(int count)
        {
            while (!Program.MainForm.IsHandleCreated) ;
            Program.MainForm.BeginInvoke(new Action(() =>
            {
                FileListWaiting.Instance.setText(count);
            }));
        }

        void Port_SendFileRate(double rate)
        {
            while (!Program.MainForm.IsHandleCreated) ;
            Program.MainForm.BeginInvoke(new Action(() =>
            {
                FileListWaiting.Instance.setProcessBar((int)(rate * 1000));
            }));
        }

        void Port_RecieveFileRate(double rate)
        {
            while (!Program.MainForm.IsHandleCreated) ;
            Program.MainForm.BeginInvoke(new Action(() =>
            {
                FileListWaiting.Instance.setProcessBar((int)(rate * 1000));
            }));
        }

        public void SendFiles()
        {
            isOver = false;
            Client.SendFileList(remoteCom, localPath);
            Client.FileListSendEnd += new Action(Client_FileListSendEnd);
        }

        void Client_FileListRecieveEnd()
        {
            remoteCom.Clear();
            localPath.Clear();
            isOver = true;
            isError = false;
            Client.FileListRecieveEnd -= Client_FileListRecieveEnd;
            while (!Program.MainForm.IsHandleCreated) ;
            Program.MainForm.Invoke(new Action(() =>
            {
                Program.MainForm.Enabled = true;
                FileListWaiting.Instance.Close();
            }));
            if (FilesComplete != null)
            {
                Program.MainForm.BeginInvoke(new Action(() =>
                {
                    FilesComplete();
                }
                    ));
            }
        }

        public void ReceiveFiles()
        {
            isOver = false;
            Client.ReceiveFileList(remoteCom, localPath);
            Client.FileListRecieveEnd += new Action(Client_FileListRecieveEnd);

        }

        void Client_FileListSendEnd()
        {
            remoteCom.Clear();
            localPath.Clear();
            isOver = true;
            isError = false;
            Client.FileListSendEnd -= Client_FileListSendEnd;
            while (!Program.MainForm.IsHandleCreated) ;
            Program.MainForm.Invoke(new Action(() =>
            {
                Program.MainForm.Enabled = true;
                FileListWaiting.Instance.Close();
            }));
            if (FilesComplete != null)
            {
                Program.MainForm.BeginInvoke(new Action(() =>
                {
                    FilesComplete();
                }
                    ));
            }
        }

        static void Client_ReceivedTxt(object sender, EventArgs e)
        {
            string[] msgs=sender.ToString().Split('$');
            if (msgs[0] == "server")
            {
                switch (msgs[1])
                {
                    case "fileError":
                        isOver = true;
                        isError = true;
                        MessageBox.Show(msgs[2] + " not exist!");
                        while (!Program.MainForm.IsHandleCreated) ;
                        Program.MainForm.Invoke(new Action(() =>
                        {
                            Program.MainForm.Enabled = true;
                            FileListWaiting.Instance.Close();
                        }));
                        break;
                }
            }
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
