using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;

namespace OES.Net
{
    public class OESClient
    {
        private TcpClient client;
        private static int bufferSize = 128;    //命令端口大小
        private Byte[] buffer = new Byte[bufferSize];
        private NetworkStream ns;
        private string temp = String.Empty;
        private bool IsEnd;

        private int msg_type;
        private string msg;
        private DataPort port;

        public string paperPath = "F:/paper.ppt";           //发送数据的文件路径
        private IPAddress remoteIP;      //接收试卷所需信息
        private int remotePort;
        public string fileName = "test.ppt";

        public string server = "222.20.59.83";  //服务器地址
        public int portNum = 20000;
        private IPAddress ip;

        public delegate void Submited();
        public event Submited SubmitReporter;        

        public OESClient()
        {
            IsEnd = false;
            client = new TcpClient();
            RetrieveHostIpv4Address();
            port = new DataPort(ip,SearchSparePort());                       
        }

        private void RetrieveHostIpv4Address()
        {
            //获得所有的ip地址，包括ipv6和ipv4
            IPAddress[] ips = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress tip in ips)
            {
                //ipv4的最大长度为15，ipv6为39
                if (tip.ToString().Length <= 15)
                {
                    ip = tip;
                    return;
                }
            }
        }

        //搜索当前空闲端口号
        private int SearchSparePort()
        {
            int start_port = 10005;
            IPGlobalProperties ipgloabalprops = IPGlobalProperties.GetIPGlobalProperties();          
            IPEndPoint[] tcpListInfos = ipgloabalprops.GetActiveTcpListeners();
            TcpConnectionInformation[] tcpConnInfos = ipgloabalprops.GetActiveTcpConnections();
            IPEndPoint[] udpInfos = ipgloabalprops.GetActiveUdpListeners();

            List<int> ports = new List<int>();
            foreach(IPEndPoint tcpl in tcpListInfos)
            {
                ports.Add(tcpl.Port);
                Console.Write(tcpl.Port+" ");
            }
            Console.WriteLine("");
            foreach (TcpConnectionInformation tcpi in tcpConnInfos)
            {
                ports.Add(tcpi.LocalEndPoint.Port);
                Console.Write(tcpi.LocalEndPoint.Port+" ");
            }
            Console.WriteLine("");
            foreach (IPEndPoint udpl in udpInfos)
            {
                ports.Add(udpl.Port);
                Console.Write(udpl.Port+" ");
            }

            ports.Sort();
            int port = start_port;
            for (int i = 0; i < ports.Count; i++)
            {
                if (ports[i] <= port)
                    continue;

                port++;
                if (port != ports[i])
                    break;
               
            }          
            return port;
        }

        public bool InitializeClient()
        {
            try
            {
                client.BeginConnect(IPAddress.Parse(server), portNum, new AsyncCallback(connect_callBack), client);
            }
            catch (Exception e)
            {
                //网络出错处理程序
                return (false);
            }
            return (true);
        }

        public bool EndConnection()
        {
            if (client.Connected)
            {
                string tmsg = "#STX#-1#NULL#ETX";
                byte[] tBuffer = System.Text.Encoding.Default.GetBytes(tmsg);
                try
                {
                    ns.BeginWrite(tBuffer, 0, tBuffer.Length, new AsyncCallback(write_callBack), client);

                   // MessageSupervisor.targetFrm.showMessage("End Connection : " + tmsg);
                }
                catch (Exception e)
                {
                    //网络出错处理程序
                    return (false);
                }
            }
            return (true);
        }

        public bool EndAllConnection()
        {            
            string tmsg = "#STX#-2#NULL#ETX";
            byte[] tBuffer = System.Text.Encoding.Default.GetBytes(tmsg);
            try
            {
                ns.BeginWrite(tBuffer, 0, tBuffer.Length, new AsyncCallback(write_callBack), client);

                //MessageSupervisor.targetFrm.showMessage("End Connection : " + tmsg);
            }
            catch (Exception e)
            {
                //网络出错处理程序
                return (false);
            }
            
            return (true);
        }

        public void EndService()
        {           
            ns.Close();
            client.Close();
            IsEnd = true;            
        }

        private void connect_callBack(IAsyncResult asy)
        {
            client.EndConnect(asy);
            ns = client.GetStream();

           // MessageSupervisor.targetFrm.showMessage("Local Machine: " + client.Client.LocalEndPoint.ToString() + " ----> " + "Connect server: " + client.Client.RemoteEndPoint.ToString());

            ns.BeginRead(buffer, 0, bufferSize, new AsyncCallback(receive_callBack), client);
        }

        private void receive_callBack(IAsyncResult asy)
        {
            int result = ns.EndRead(asy);
            GetActualFullMessage();

            if(!IsEnd)
                ns.BeginRead(buffer, 0, bufferSize, new AsyncCallback(receive_callBack), client);
        }

        private void GetActualFullMessage()
        {
            string[] messages;
            char[] sparator = new char[] { '#' };
            msg_type = -2;

            temp += System.Text.Encoding.Default.GetString(buffer, 0, buffer.Length).Trim('\0');
            Array.Clear(buffer, 0, bufferSize);

            messages = temp.Split(sparator, StringSplitOptions.RemoveEmptyEntries);       

            //当达到可能长度解析信息内容,要保证能收到最新一条正确的信息,保证所有正确的信息都能执行完
            while (messages.Length > 3)
            {
                GetFullMessage(messages);
                messages = temp.Split(sparator, StringSplitOptions.RemoveEmptyEntries);
            }
            
        }

        private void GetFullMessage(string[] messages)
        {

            if (messages[0].Equals("STX"))
            {
                if (messages[3].Equals("ETX"))
                {
                    msg_type = Convert.ToInt32(messages[1]);
                    msg = messages[2];
                    
                    //测试用    
                   // MessageSupervisor.targetFrm.showMessage("Message: [code]" + msg_type.ToString() + " [content]" + msg + " From: " + client.Client.RemoteEndPoint.ToString());

                    MessageScheduler();
                }
            }
            int index = temp.IndexOf("#ETX");
            if (index > 0)
                index += 4;
            else
                index = 0;


            temp = temp.Substring(index);
        }
        
        public void sendData()
        {
            port.LoadData(paperPath);
            string tmsg = "#STX#2#" + port.ip.ToString() + "$" + port.localPort.ToString() + "#ETX";
            byte[] tBuffer = System.Text.Encoding.Default.GetBytes(tmsg);
            try
            {
                ns.BeginWrite(tBuffer, 0, tBuffer.Length, new AsyncCallback(write_callBack), client);
            }
            catch (Exception e)
            {
                //网络出错处理程序
            }
        }    
       
        private void write_callBack(IAsyncResult asy)
        {
            try
            {
                ns.EndWrite(asy);
            }
            catch (Exception e)
            {
            }
        }

        public void RequestingPaper()
        {
            string tmsg = "#STX#0#NULL#ETX";
            byte[] tBuffer = System.Text.Encoding.Default.GetBytes(tmsg);
            try
            {
                ns.BeginWrite(tBuffer, 0, tBuffer.Length, new AsyncCallback(write_callBack), client);

                //MessageSupervisor.targetFrm.showMessage("Requesting Paper : " + tmsg);
            }
            catch (Exception e)
            {
                //网络出错处理程序
            }
        }

        public void SubmittingPaper()
        {
            string tmsg = "#STX#1#用户信息#ETX";
            byte[] tBuffer = System.Text.Encoding.Default.GetBytes(tmsg);
            try
            {
                ns.BeginWrite(tBuffer, 0, tBuffer.Length, new AsyncCallback(write_callBack), client);
            }
            catch (Exception e)
            {
                //网络出错处理程序
            }
        }

        private void ReceiveData()
        {                   
           if(!(port.DownloadData(remoteIP, remotePort, fileName)))
           {
               //网络出错处理程序
           }

        }

        private void MessageScheduler()
        {
            switch (msg_type)
            {
                case 0:
                    string[] msgs = msg.Split(new char[] { '$' });
                    remoteIP = IPAddress.Parse(msgs[0]);
                    remotePort = Convert.ToInt32(msgs[1]);
                    ReceiveData();
                    break;

                case 1:
                    //发送数据给服务端
                    sendData();
                    break;

                case 2:
                    //成功交卷
                    if (SubmitReporter != null)
                        SubmitReporter();
                    break;

                case -1:                   
                    //结束通信
                    EndService();
                    break;

                case -2:
                    //断开与服务器的连接
                    if (EndAllConnection())
                        EndService();
                    break;

                default:
                    //网络出错程序
                    break;
            }
        }

    }
}
