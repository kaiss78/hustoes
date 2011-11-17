using System;
using System.Collections.Generic;
 
using System.Text;
using ServerNet;

namespace OESMonitor.Net
{
    public class ServerEvt
    {
        public static OESServer Server = new OESServer();
        public static OESNet.UdpNet.UdpBroadcast BroadcastHelper = new OESNet.UdpNet.UdpBroadcast();
        public ServerEvt()
        {
        }
    }
}
