﻿
using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace ServerNet
{
    public class DataPort
    {
        /// <summary>
        /// 本数据端口端口号
        /// </summary>
        public int localPort;
        /// <summary>
        /// 本机Ip
        /// </summary>
        public IPAddress ip;
        /// <summary>
        /// 客户端数据端口号
        /// </summary>
        public int remotePort;
        /// <summary>
        /// 客户端数据端口Ip
        /// </summary>
        public IPAddress remoteIp;
        //客户端数据端口信息
        private EndPoint remoteEndPoint;
        //数据端口监听
        private TcpListener dataListener;
        //数据端Socket
        private TcpClient client = new TcpClient();
        //数据端Socket--用于和服务端数据端口通信
        private TcpClient dataTrans;
        //网络流
        private NetworkStream data_ns;
        /// <summary>
        /// 接收数据还是发送数据
        /// </summary>
        public bool IsSend = false;
        //接收和发送时的文件路径
        private string filePath = "";
        /// <summary>
        /// 接收和发送时的文件路径
        /// </summary>
        public string FilePath
        {
            get
            {
                return filePath;
            }
            set
            {
                filePath = value;
                if (File.Exists(filePath))
                {
                    fileLength = new FileInfo(filePath).Length;
                }
                else
                {
                    if (IsSend)
                    {
                        fileLength = 0;
                    }
                }
            }
        }
        /// <summary>
        /// 文件大小
        /// </summary>
        public long fileLength = 0;

        #region 事件定义
        /// <summary>
        /// 端口收回事件
        /// </summary>
        /// <param name="port">待回收的数据端口</param>
        public delegate void portUsed(DataPort port);
        public event portUsed portRecycle;
        /// <summary>
        /// 文件传输开始
        /// </summary>
        public event DataPortEventHandler FileSendBegin;
        /// <summary>
        /// 文件传输结束
        /// </summary>
        public event DataPortEventHandler FileSendEnd;
        /// <summary>
        /// 文件接收开始
        /// </summary>
        public event DataPortEventHandler FileReceiveBegin;
        /// <summary>
        /// 文件接收结束
        /// </summary>
        public event DataPortEventHandler FileReceiveEnd;
        /// <summary>
        /// 接收客户端数据端口连接请求
        /// </summary>
        public event DataPortEventHandler AcceptedDataPort;
        /// <summary>
        /// 文件传输大小错误(一般为网络中丢包)
        /// </summary>
        public event ErrorEventHandler FileSizeError;
        /// <summary>
        /// 文件发送过程中出错(一般为客户端断开连接)
        /// </summary>
        public event ErrorEventHandler FileSendError;
        /// <summary>
        /// 文件接收过程中出错(一般为客户端断开连接)
        /// </summary>
        public event ErrorEventHandler FileReceiveError;
        /// <summary>
        /// 传送文件比例
        /// </summary>
        public event ReturnVal SendFileRate;
        /// <summary>
        /// 接收文件比例
        /// </summary>
        public event ReturnVal RecieveFileRate;
        #endregion

        /// <summary>
        /// 数据端口构造函数
        /// </summary>
        /// <param name="ip">本机Ip</param>
        /// <param name="localPort">端口号</param>
        public DataPort(IPAddress ip, int localPort)
        {
#if DEBUG
            OESServer.logForm.InsertMsg("Init [DataPort.DataPort]");
#endif
            this.ip = ip;
            this.localPort = localPort;
            dataListener = new TcpListener(ip, localPort);
            dataListener.Start();
            dataListener.BeginAcceptTcpClient(new AsyncCallback(accept_callBack), dataListener);
        }

        /// <summary>
        /// 初始化DataPort
        /// </summary>
        /// <param name="ep">客户端数据端口信息</param>
        public void InitDataPort(EndPoint ep)
        {
#if DEBUG
            OESServer.logForm.InsertMsg("In [DataPort.InitDataPort]");
#endif
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse(ep.ToString().Split(':')[0]), Int32.Parse(ep.ToString().Split(':')[1]));
            this.remoteIp = iep.Address;
            this.remotePort = iep.Port;
            this.remoteEndPoint = ep;
        }

        /// <summary>
        /// 给远程端口发送数据
        /// </summary>
        /// <param name="asy">异步返回信息</param>
        public void accept_callBack(IAsyncResult asy)
        {
#if DEBUG
            OESServer.logForm.InsertMsg("In [DataPort.accept_callBack]");
#endif
            TcpListener listener = (TcpListener)asy.AsyncState;
            dataTrans = (TcpClient)listener.EndAcceptTcpClient(asy);
            data_ns = dataTrans.GetStream();
            if (AcceptedDataPort != null)
            {
                AcceptedDataPort(this);
            }
            if (dataTrans.Client.RemoteEndPoint.ToString().Split(':')[0] != this.remoteEndPoint.ToString().Split(':')[0])
            {
                dataListener.BeginAcceptTcpClient(new AsyncCallback(accept_callBack), dataListener);
            }
            else
            {
                if (IsSend)
                {
                    Thread thread = new Thread(SendData);
                    thread.Start();
                }
                else
                {
                    Thread thread = new Thread(ReceiveData);
                    thread.Start();
                }
                dataListener.BeginAcceptTcpClient(new AsyncCallback(accept_callBack), dataListener);
            }
        }
        /// <summary>
        /// 接收文件
        /// </summary>
        private void ReceiveData()
        {
#if DEBUG
            OESServer.logForm.InsertMsg("In [DataPort.ReceiveData]");
#endif
            try
            {
                if (FileReceiveBegin != null)
                {
                    FileReceiveBegin(this);
                }
                while (fileLength == 0)
                {
                    int i = 20;
                    Thread.Sleep(10);
                    i--;
                    if (i == 0) break;
                }
                long total = fileLength;
                int byteRead;
                Byte[] buffer = new Byte[1024];
                FileStream file = new FileStream(filePath, FileMode.Create, FileAccess.Write);
                byteRead = data_ns.Read(buffer, 0, 1024);

                while (byteRead > 0)
                {
                    total -= byteRead;
                    file.Write(buffer, 0, byteRead);
                    Array.Clear(buffer, 0, 1024);
                    byteRead = data_ns.Read(buffer, 0, 1024);
                    if (RecieveFileRate != null)
                    {
                        RecieveFileRate(1.0 - (double)total / fileLength);
                    }
                }

                data_ns.Dispose();
                dataTrans.Close();
                file.Close();

                if (FileReceiveEnd != null)
                {
                    FileReceiveEnd(this);
                }

                if (portRecycle != null)
                    portRecycle(this);
                if (total != 0L)
                {
                    if (FileSizeError != null)
                    {
                        FileSizeError(this, null);
                    }
                }
            }
            catch (Exception ex)
            {
                if (FileReceiveError != null)
                    FileReceiveError(this, new ErrorEventArgs(ex));
                if (portRecycle != null)
                    portRecycle(this);
            }
        }

        /// <summary>
        /// 传输文件
        /// </summary>
        private void SendData()
        {
#if DEBUG
            OESServer.logForm.InsertMsg("In [DataPort.SendData]");
#endif
            try
            {
                if (FileSendBegin != null)
                {
                    FileSendBegin(this);
                }
                int byteRead;
                long totle = 0L;
                Byte[] buffer = new Byte[1024];
                FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);

                byteRead = file.Read(buffer, 0, 1024);
                while (byteRead > 0)
                {
                    data_ns.Write(buffer, 0, byteRead);
                    Array.Clear(buffer, 0, 1024);
                    byteRead = file.Read(buffer, 0, 1024);
                    totle += byteRead;
                    if (SendFileRate != null)
                    {
                        SendFileRate((double)totle / fileLength);
                    }
                }

                data_ns.Dispose();
                dataTrans.Close();
                file.Close();

                if (FileSendEnd != null)
                {
                    FileSendEnd(this);
                }

                if (portRecycle != null)
                    portRecycle(this);
            }
            catch (Exception ex)
            {
                if (FileSendError != null)
                    FileSendError(this, new ErrorEventArgs(ex));
                if (portRecycle != null)
                    portRecycle(this);
            }
            
        }
    }
    public delegate void DataPortEventHandler(DataPort dataPort);
    public delegate void ReturnVal(double rate);
}
