using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;

namespace OESNet.UdpNet
{
    /// <summary>
    /// Udp广播消息
    /// </summary>
    public class UdpBroadcast
    {
        /// <summary>
        /// 当接收到Udp消息时发生
        /// </summary>
        public event UdpMsg OnReceiveMsg;

        /// <summary>
        /// Udp底层对象
        /// </summary>
        private UdpClient udpClient;

        /// <summary>
        /// Udp监听的端口/发送的目标端口
        /// </summary>
        private int port = 10000;
        /// <summary>
        /// Udp监听的端口/发送的目标端口
        /// </summary>
        public int Port
        {
            get { return port; }
            set { port = value; }
        }

        /// <summary>
        /// 广播的组播Ip
        /// </summary>
        private IPAddress domineIp = IPAddress.Parse("255.255.255.255");
        /// <summary>
        /// 广播的组播Ip
        /// </summary>
        public string DomineIp
        {
            get { return domineIp.ToString(); }
            set { domineIp = IPAddress.Parse(value); }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public UdpBroadcast()
        {
            udpClient = new UdpClient();
        }

        /// <summary>
        /// 广播内容
        /// </summary>
        /// <param name="content">需要广播的字符串</param>
        public void Broadcast(string content)
        {
            try
            {
                udpClient.Connect(domineIp, port);
                Byte[] sendBytes = Encoding.ASCII.GetBytes(content);
                udpClient.Send(sendBytes, sendBytes.Length);
            }
            catch (Exception e)
            {
                this.Close();
                Console.WriteLine(e.ToString());
            }
        }

        /// <summary>
        /// 监听打开（内部为异步监听）
        /// </summary>
        public void Listening()
        {
            udpClient = new UdpClient(port);
            try 
            {
                udpClient.BeginReceive(new AsyncCallback(receive_callBack),udpClient);
            }
            catch (Exception e) 
            {
                this.Close();
                Console.WriteLine(e.ToString());
            }
        }

        /// <summary>
        /// 当接受到消息时返回
        /// </summary>
        /// <param name="asy"></param>
        private void receive_callBack(IAsyncResult asy)
        {
            IPEndPoint iep = new IPEndPoint(IPAddress.Any, port);
            byte[] receiveBytes=udpClient.EndReceive(asy,ref iep);
            string returnData = Encoding.ASCII.GetString(receiveBytes);
            if (OnReceiveMsg != null)
            {
                OnReceiveMsg(returnData);
            }
            Console.WriteLine("This is the message you received " + returnData.ToString());
            Console.WriteLine("This message was sent from " + iep.Address.ToString() + " on their port number " + iep.Port.ToString());

            try
            {
                udpClient.BeginReceive(new AsyncCallback(receive_callBack), udpClient);
            }
            catch (Exception e)
            {
                this.Close();
                Console.WriteLine(e.ToString());
            }
        }
        /// <summary>
        /// 关闭Udp对象
        /// </summary>
        public void Close()
        {
            try
            {
                udpClient.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        /// <summary>
        /// Ip字符串地址转换成uint的数字
        /// </summary>
        /// <param name="ipaddress">Ip字符串</param>
        /// <returns>Ip数字</returns>
        public static uint GetLongIp(string ipaddress)
        {
            byte[] bytes = IPAddress.Parse(ipaddress).GetAddressBytes();
            Array.Reverse(bytes);
            return BitConverter.ToUInt32(bytes, 0);
        }
        /// <summary>
        /// uint的数字转换成字符串Ip
        /// </summary>
        /// <param name="ipaddress">Ip数字</param>
        /// <returns>Ip字符串</returns>
        public static string GetStringIp(uint ipaddress)
        {
            byte[] bytes = BitConverter.GetBytes(ipaddress);
            Array.Reverse(bytes);
            return new IPAddress(bytes).ToString();
        }
    }
    /// <summary>
    /// Udp消息委托
    /// </summary>
    /// <param name="msg">消息内容</param>
    public delegate void UdpMsg(string msg);


}
