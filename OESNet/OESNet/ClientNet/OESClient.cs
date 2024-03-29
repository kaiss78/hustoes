﻿
#if DEBUG
using OESNet;
#endif

using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.Threading;
using System.IO;
using OES;


namespace ClientNet
{
    public class OESClient
    {

#if DEBUG
        public static ThreadsInfo logForm=new ThreadsInfo();
#endif
        /// <summary>
        /// 配置文件
        /// </summary>
        public static OESConfig Config = new OESConfig("ClientConfig.xml", new string[,]{
            {"RemoteIp","127.0.0.1"},
            {"RemotePort","20000"}
        });
        //客户端Socket--用于和服务端通信
        private TcpClient client;
        //命令端口大小
        private static int bufferSize = 2048;  
        //Byte数据数组
        private Byte[] buffer = new Byte[bufferSize];
        //网络流
        private NetworkStream ns;
        //字符串类型的原始消息
        private string raw_msg = String.Empty;
        /// <summary>
        /// 服务器地址
        /// </summary>
        public string server = Config["RemoteIp"];
        /// <summary>
        /// 服务器端口
        /// </summary>
        public int portNum = int.Parse(Config["RemotePort"]);
        /// <summary>
        /// 消息末尾字符
        /// </summary>
        public char EndOfMsg = '`';

        //客户端数据端口
        private DataPort port;
        /// <summary>
        /// 客户端数据端口
        /// </summary>
        public DataPort Port
        {
            get  
            {
                return port; 
            }
            set 
            {
                port = value;
            }
        }
        /// <summary>
        /// 远程文件命令列表
        /// </summary>
        private List<string> remoteCmd = new List<string>();
        /// <summary>
        /// 本地存储文件路径列表
        /// </summary>
        private List<string> localPath = new List<string>();

        #region 事件定义
        /// <summary>
        /// 连接上服务器
        /// </summary>
        public event EventHandler ConnectedServer;
        /// <summary>
        /// 接收到消息
        /// </summary>
        public event EventHandler ReceivedMsg;
        /// <summary>
        /// 接收到数据请求消息 客户端--->服务端
        /// </summary>
        public event EventHandler ReceivedDataRequest;
        /// <summary>
        /// 接收到数据发送消息 服务端--->客户端
        /// </summary>
        public event EventHandler ReceivedDataSubmit;
        /// <summary>
        /// 接收到文字消息.第一个参数为String类型,表示收到的消息
        /// </summary>
        public event EventHandler ReceivedTxt;
        /// <summary>
        /// 消息发送完成.第一个参数为String类型,表示发送出去的消息内容
        /// </summary>
        public event EventHandler WrittenMsg;
        /// <summary>
        /// 客户端连接服务端出现错误,第一个参数为错误信息
        /// </summary>
        public event ErrorEventHandler ConnectError;
        /// <summary>
        /// 接收时出现错误,第一个参数为错误信息(一般为文件路径不存在)
        /// </summary>
        public event ErrorEventHandler ReceiveError;
        /// <summary>
        /// 与服务端断开连接(一般为服务端网络出现问题)
        /// </summary>
        public event ErrorEventHandler DisConnectError;
        /// <summary>
        /// 文件传输错误
        /// </summary>
        public event ErrorEventHandler FileError;
        /// <summary>
        /// 返回当前列表中文件剩余数量
        /// </summary>
        public event FileListSize FileListCount;
        /// <summary>
        /// 文件列表发送开始
        /// </summary>
        public event Action FileListSendStart;
        /// <summary>
        /// 文件列表发送完毕
        /// </summary>
        public event Action FileListSendEnd;
        /// <summary>
        /// 文件列表接收开始
        /// </summary>
        public event Action FileListRecieveStart;
        /// <summary>
        /// 文件列表接收完毕
        /// </summary>
        public event Action FileListRecieveEnd;
        
        #endregion


        /// <summary>
        /// OESClient构造函数.会初始化命令端口和数据端口.
        /// </summary>
        public OESClient()
        {
#if DEBUG
            logForm.Text = "OESClient";
            logForm.Show();
            logForm.InsertMsg("Init [OESClient.OESClient]");
#endif
        }
        /// <summary>
        /// 开始连接服务端
        /// </summary>
        /// <returns></returns>
        public bool InitializeClient()
        {
#if DEBUG
            logForm.InsertMsg("In [OESClient.InitializeClient]");
#endif
            try
            {
                client = new TcpClient();
                port = new DataPort();
                client.BeginConnect(IPAddress.Parse(server), portNum, new AsyncCallback(connect_callBack), client);
            }
            catch (Exception e)
            {
                if (ConnectError != null)
                {
                    ConnectError(e, null);
                }
                SendError(e.ToString());
                return (false);
            }
            return (true);
        }

        /// <summary>
        /// 命令Socket连接服务器的回调函数
        /// </summary>
        /// <param name="asy">异步返回结果</param>
        private void connect_callBack(IAsyncResult asy)
        {
#if DEBUG
            logForm.InsertMsg("In [OESClient.connect_callBack]");
#endif
            try
            {
                client.EndConnect(asy);
                ns = client.GetStream();
                if (ConnectedServer != null)
                {
                    ConnectedServer(this, null);
                }
                ns.BeginRead(buffer, 0, bufferSize, new AsyncCallback(receive_callBack), client);
            }
            catch(Exception e)
            {
                if (ConnectError != null)
                {
                    ConnectError(e, null);
                }
            }
        }
        /// <summary>
        /// 命令Socket接收信息的回调函数
        /// </summary>
        /// <param name="asy">异步返回结果</param>
        private void receive_callBack(IAsyncResult asy)
        {
#if DEBUG
            logForm.InsertMsg("In [OESClient.connect_callBack]");
#endif
            try
            {
                int result = ns.EndRead(asy);
                DispatchMessage();
            }
            catch (Exception e)
            {
                if (ReceiveError != null)
                {
                    ReceiveError(e, null);
                }
            }
            try
            {
                ns.BeginRead(buffer, 0, bufferSize, new AsyncCallback(receive_callBack), client);
            }
            catch (Exception e)
            {
                client = new TcpClient();
                if (DisConnectError != null)
                {
                    DisConnectError(this, null);
                }
            }
        }
        /// <summary>
        /// 内部消息处理函数
        /// cmd#1#0#IP#Port 向客户端请求文件
        /// cmd#1#1#IP#Port#FileName#FileSize 向客户端发送文件
        /// cmd#-2 客户端上传文件失败,要求重传
        /// txt#content 服务端传来的文字消息
        /// </summary>
        private void DispatchMessage()
        {
#if DEBUG
            logForm.InsertMsg("In [OESClient.DispatchMessage]");
#endif
            string raw_msgs = System.Text.Encoding.Default.GetString(buffer, 0, buffer.Length).Trim('\0');
            foreach (string onemsg in raw_msgs.Split(EndOfMsg))
            {
                if (!String.IsNullOrEmpty(onemsg))
                {
                    string[] messages;
                    char[] sparator = new char[] { '#' };

                    raw_msg = onemsg;
                    Array.Clear(buffer, 0, bufferSize);

                    if (ReceivedMsg != null)
                    {
                        ReceivedMsg(raw_msg, null);
                    }

                    messages = raw_msg.Split(sparator, StringSplitOptions.RemoveEmptyEntries);
                    switch (messages[0])
                    {
                        case "cmd":
                            switch (messages[1])
                            {
                                case "1":
                                    port.remoteIp = IPAddress.Parse(messages[3]);
                                    port.remotePort = Int32.Parse(messages[4]);
                                    switch (messages[2])
                                    {
                                        case "0":
                                            if (ReceivedDataRequest != null)
                                            {
                                                ReceivedDataRequest(this, null);
                                            }
                                            SendFileMsg();
                                            port.IsSend = true;
                                            port.Connect();
                                            break;
                                        case "1":
                                            if (ReceivedDataSubmit != null)
                                            {
                                                ReceivedDataSubmit(this, null);
                                            }
                                            port.IsSend = false;
                                            port.fileLength = Int64.Parse(messages[6]);
                                            port.Connect();
                                            break;
                                    }
                                    break;
                                case "-1":
                                    switch (messages[2])
                                    {
                                        case "Send":
                                        case "Recieve":
                                        case "Size":
                                            if (FileError != null)
                                            {
                                                FileError(messages[2], null);
                                            }
                                            break;
                                    }
                                    break;
                                case "-2":
                                    SendFile();
                                    break;
                            }
                            break;
                        case "txt":
                            if (ReceivedTxt != null)
                            {
                                ReceivedTxt(messages[1], null);
                            }
                            break;
                    }
                }
            }
        }
        /// <summary>
        /// 当客户端需要上传文件时,发送文件大小信息
        /// </summary>
        public void SendFileMsg()
        {
#if DEBUG
            logForm.InsertMsg("In [OESClient.SendFileMsg]");
#endif
            if (File.Exists(port.FilePath))
            {
                FileInfo fi = new FileInfo(port.FilePath);
                string tmsg = "cmd#2#" + fi.Length.ToString();
                WriteMsg(tmsg);
            }
        }
        
        /// <summary>
        /// 向服务端请求上传文件
        /// </summary>
        public void SendFile()
        {
#if DEBUG
            logForm.InsertMsg("In [OESClient.SendFile]");
#endif
            string tmsg = "cmd#0#0";
            WriteMsg(tmsg);
        }
        /// <summary>
        /// 向服务端请求下载文件
        /// </summary>
        public void ReceiveFile()
        {
#if DEBUG
            logForm.InsertMsg("In [OESClient.ReceiveFile]");
#endif
            string tmsg = "cmd#0#1";
            WriteMsg(tmsg);
        }
        /// <summary>
        /// 通知服务端客户端出错,请求回收数据端口
        /// </summary>
        /// <param name="error">错误消息</param>
        public void SendError(String error)
        {
#if DEBUG
            logForm.InsertMsg("In [OESClient.SendError]");
#endif
            string tmsg = "cmd#-1#" + error;
            WriteMsg(tmsg);
        }
        /// <summary>
        /// 想服务端发送文字消息
        /// </summary>
        /// <param name="content"></param>
        public void SendTxt(String content)
        {
#if DEBUG
            logForm.InsertMsg("In [OESClient.SendTxt]");
#endif
            string tmsg = "txt#" + content;
            WriteMsg(tmsg);
        }
        /// <summary>
        /// 发送命令Socket消息
        /// </summary>
        /// <param name="msg"></param>
        private void WriteMsg(String msg)
        {
#if DEBUG
            logForm.InsertMsg("In [OESClient.WriteMsg]");
#endif
            byte[] tBuffer = System.Text.Encoding.Default.GetBytes(msg+EndOfMsg);
            try
            {
                ns.BeginWrite(tBuffer, 0, tBuffer.Length, new AsyncCallback(write_callBack), client);
                if (WrittenMsg != null)
                {
                    WrittenMsg(msg, null);
                }
            }
            catch (Exception e)
            {
                //网络出错处理程序
                //Console.WriteLine("[{0}] {1}",DateTime.Now.ToString(),e.ToString());
            }
        }
        /// <summary>
        /// 命令Socket发送信息的回调函数
        /// </summary>
        /// <param name="asy">异步返回结果</param>
        private void write_callBack(IAsyncResult asy)
        {
#if DEBUG
            logForm.InsertMsg("In [OESClient.write_callBack]");
#endif
            try
            {
                ns.EndWrite(asy);
            }
            catch (Exception e)
            {
                SendError(e.ToString());
            }
        }

        /// <summary>
        /// 发送文件列表
        /// </summary>
        /// <param name="remoteCmd">远程文件命令列表</param>
        /// <param name="localPath">本地文件路径列表</param>
        public void SendFileList(List<string> remoteCmd, List<string> localPath)
        {
#if DEBUG
            logForm.InsertMsg("In [OESClient.SendFileList]");
#endif
            if (FileListSendStart != null)
                FileListSendStart();

            this.remoteCmd = remoteCmd;
            this.localPath = localPath;
            this.Port.FileSendEnd += new EventHandler(Port_FileSendEnd);

            if (remoteCmd.Count != localPath.Count)
            {
                this.Port.FileSendEnd -= Port_FileSendEnd;
                if (FileListSendEnd != null)
                    FileListSendEnd();
                return;
            }

            if (remoteCmd.Count == 0 || localPath.Count == 0)
            {
                this.Port.FileSendEnd -= Port_FileSendEnd;
                if (FileListSendEnd != null)
                    FileListSendEnd();
                return;
            }

            this.SendTxt(remoteCmd[0]);
            this.Port.FilePath = localPath[0];
            this.SendFile();

            remoteCmd.RemoveAt(0);
            localPath.RemoveAt(0);
            
            if(FileListCount!=null)
                FileListCount(remoteCmd.Count);
        }
        
        private void Port_FileSendEnd(object sender, EventArgs e)
        {
#if DEBUG
            logForm.InsertMsg("In [OESClient.Port_FileSendEnd]");
#endif
            if (remoteCmd.Count != localPath.Count)
            {
                this.Port.FileSendEnd -= Port_FileSendEnd;
                if (FileListSendEnd != null)
                    FileListSendEnd();
                return;
            }

            if (remoteCmd.Count != 0)
            {
                this.SendTxt(remoteCmd[0]);
                this.Port.FilePath = localPath[0];
                this.SendFile();

                remoteCmd.RemoveAt(0);
                localPath.RemoveAt(0);

                if (FileListCount != null)
                    FileListCount(remoteCmd.Count);
            }
            else
            {
                this.Port.FileSendEnd -= Port_FileSendEnd;
                if (FileListSendEnd != null)
                    FileListSendEnd();
            }
        }
        /// <summary>
        /// 接收文件列表
        /// </summary>
        /// <param name="remoteCmd">远程文件命令列表</param>
        /// <param name="localPath">本地文件路径列表</param>
        public void ReceiveFileList(List<string> remoteCmd, List<string> localPath)
        {
#if DEBUG
            logForm.InsertMsg("In [OESClient.ReceiveFileList]");
#endif
            if (FileListRecieveStart != null)
                FileListRecieveStart();

            this.remoteCmd = remoteCmd;
            this.localPath = localPath;
            this.Port.FileReceiveEnd += new EventHandler(Port_FileReceiveEnd);

            if (remoteCmd.Count != localPath.Count)
            {
                this.Port.FileReceiveEnd -= Port_FileReceiveEnd;

                if (FileListRecieveEnd != null)
                    FileListRecieveEnd();
                return;
            }

            if (remoteCmd.Count == 0 || localPath.Count == 0)
            {
                this.Port.FileReceiveEnd -= Port_FileReceiveEnd;

                if (FileListRecieveEnd != null)
                    FileListRecieveEnd();
                return;
            }

            this.SendTxt(remoteCmd[0]);
            this.Port.FilePath = localPath[0];
            this.ReceiveFile();

            remoteCmd.RemoveAt(0);
            localPath.RemoveAt(0);

            if (FileListCount != null)
                FileListCount(remoteCmd.Count);
        }

        private void Port_FileReceiveEnd(object sender, EventArgs e)
        {
#if DEBUG
            logForm.InsertMsg("In [OESClient.Port_FileReceiveEnd]");
#endif
            if (remoteCmd.Count != localPath.Count)
            {
                this.Port.FileReceiveEnd -= Port_FileReceiveEnd;

                if (FileListRecieveEnd != null)
                    FileListRecieveEnd();
                return;
            }

            if (remoteCmd.Count != 0)
            {
                this.SendTxt(remoteCmd[0]);
                this.Port.FilePath = localPath[0];
                this.ReceiveFile();

                remoteCmd.RemoveAt(0);
                localPath.RemoveAt(0);

                if (FileListCount != null)
                    FileListCount(remoteCmd.Count);
            }
            else
            {
                this.Port.FileReceiveEnd-=Port_FileReceiveEnd;

                if (FileListRecieveEnd != null)
                    FileListRecieveEnd();
            }
        }
    }
    public delegate void FileListSize(int count);
}
