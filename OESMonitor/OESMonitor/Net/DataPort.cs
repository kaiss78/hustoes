﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace OESMonitor.Net
{
    public class DataPort
    {
        public int localPort;
        public IPAddress ip;

        private TcpListener dataListener;
        private TcpClient dataReceiver;

        private TcpClient client = new TcpClient();
        private TcpClient dataSender;        

        private NetworkStream receiver_ns;
        private NetworkStream sender_ns;
        private string filePath;

        //文件接收时的默认路径
        public string archiveDirectory = "D:/";

        //端口收回事件
        public delegate void portUsed(DataPort port);
        public event portUsed portRecycle;

        //试卷发放完毕事件
        public event EventHandler paperDelivered;

        //试卷接受完毕事件
        public event EventHandler answerHanded;
        public DataPort(IPAddress ip, int localPort)
        {
            this.ip = ip;
            this.localPort = localPort;
            dataListener = new TcpListener(ip, localPort);
            dataListener.Start();
            dataListener.BeginAcceptTcpClient(new AsyncCallback(accept_callBack), dataListener);

            MessageSupervisor.targetFrm.showMessage("Initialize DataPort: "+dataListener.LocalEndpoint.ToString());
        }

        public string portInfo()
        {
            return (dataListener.LocalEndpoint.ToString());
        }

        //装载数据
        public void LoadData(string file)
        {
            this.filePath = file;
        }

        //接收数据
        public bool DownloadData(IPAddress ip, int port, string filename)
        {
            this.filePath = archiveDirectory + filename;
            return (Connect(ip, port));
        }


        //给远程端口发送数据
        public void accept_callBack(IAsyncResult asy)
        {
            Console.WriteLine(Thread.CurrentThread.Name);
            TcpListener listener = (TcpListener)asy.AsyncState;
            dataSender = (TcpClient)listener.EndAcceptTcpClient(asy);
            sender_ns = dataSender.GetStream();

            Thread thread = new Thread(SendData);
            thread.Start();

            dataListener.BeginAcceptTcpClient(new AsyncCallback(accept_callBack), dataListener);
           
        }

        public bool Connect(IPAddress ip, int port)
        {
            try
            {
                client.BeginConnect(ip, port, new AsyncCallback(connect_callBack), client);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        //连接远程端口接收数据
        public void connect_callBack(IAsyncResult asy)
        {
            dataReceiver = (TcpClient)asy.AsyncState;
            dataReceiver.EndConnect(asy);
            receiver_ns = dataReceiver.GetStream();

            Thread thread = new Thread(ReceiveData);
            thread.Start(); 
        }

        private void ReceiveData()
        {
            int byteRead;
            Byte[] buffer = new Byte[1024];
            FileStream file = new FileStream(@filePath, FileMode.Create, FileAccess.Write);
            byteRead = receiver_ns.Read(buffer, 0, 1024);

            while (byteRead > 0)
            {
                file.Write(buffer, 0, byteRead);
                Array.Clear(buffer, 0, 1024);
                byteRead = receiver_ns.Read(buffer, 0, 1024);
            }

            receiver_ns.Dispose();
            dataReceiver.Close();
            file.Close();

            answerHanded(this, null);

            if (portRecycle != null)
                portRecycle(this);
        }

        private void SendData()
        {
            int byteRead;
            Byte[] buffer = new Byte[1024];
            FileStream file = new FileStream(@filePath, FileMode.Open, FileAccess.Read, FileShare.None);

            byteRead = file.Read(buffer, 0, 1024);
            while (byteRead > 0)
            {
                sender_ns.Write(buffer, 0, byteRead);
                Array.Clear(buffer, 0, 1024);
                byteRead = file.Read(buffer, 0, 1024);
            }

            sender_ns.Dispose();
            dataSender.Close();
            file.Close();

            paperDelivered(this, null);

            if (portRecycle != null)
                portRecycle(this);
        }
    }
}
