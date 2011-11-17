using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;

namespace OESNet.UdpNet
{
    public class UdpBroadcast
    {
        public event UdpMsg OnReceiveMsg;

        private UdpClient udpClient;

        private int port = 10000;

        public int Port
        {
            get { return port; }
            set { port = value; }
        }

        private IPAddress domineIp = IPAddress.Parse("255.255.255.255");

        public string DomineIp
        {
            get { return domineIp.ToString(); }
            set { domineIp = IPAddress.Parse(value); }
        }

        public UdpBroadcast()
        {
            udpClient = new UdpClient(port);
        }

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
                Console.WriteLine(e.ToString());
            }
        }

        public void Listening()
        {
            try 
            {
                udpClient.BeginReceive(new AsyncCallback(receive_callBack),udpClient);
            }
            catch (Exception e) 
            {
                Console.WriteLine(e.ToString());
            }
        }

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
                Console.WriteLine(e.ToString());
            }
        }
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
        public static uint GetLongIp(string ipaddress)
        {
            byte[] bytes = IPAddress.Parse(ipaddress).GetAddressBytes();
            Array.Reverse(bytes);
            return BitConverter.ToUInt32(bytes, 0);
        }
        public static string GetStringIp(uint ipaddress)
        {
            return new IPAddress(ipaddress).ToString();
        }
    }
    public delegate void UdpMsg(string msg);


}
