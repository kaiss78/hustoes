using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace OESMonitor.Net
{
    public class ClientInfo
    {
        public int index;
        public TcpClient client;
        public static int bufferSize = 128;
        public Byte[] buffer = new Byte[bufferSize];
        public NetworkStream ns;
    }
}
