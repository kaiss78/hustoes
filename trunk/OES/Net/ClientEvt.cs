using System;
using System.Collections.Generic;
using System.Text;
using ClientNet;
using OESNet.UdpNet;
using System.Net;
using System.Windows.Forms;
using OES.DAO;
using System.IO;
namespace OES.Net
{
    public class ClientEvt
    {
        public static OESClient Client = new OESClient();
        public static UdpBroadcast BroadcastHelper = new UdpBroadcast();
        public static event EventHandler LoginReturn;
        public static event EventHandler ConfirmReStart;
      
        public static void validStudent(string name, string id, string pwd)
        {
            Net.ClientEvt.Client.ReceivedTxt -= Client_ReceivedTxt;
            Net.ClientEvt.Client.ReceivedTxt += new EventHandler(Client_ReceivedTxt);
            Client.SendTxt("oes$0$" + name + "$" + id + "$" + pwd);
        }

        public static void getPassword()
        {
            Client.SendTxt("oes$4");
        }

        public static void ChangeServerIpPort(string sender)
        {
            string[] msgs = sender.Split('#');
            if (msgs[0] == "monitor")
            {
                long myip=RetrieveHostIpv4Address();
                if (myip >= long.Parse(msgs[1]) && myip <= long.Parse(msgs[2]))
                {
                    if (Client.server != msgs[3] || Client.portNum != int.Parse(msgs[4]))
                    {
                        Client.server = msgs[3];
                        Client.portNum = int.Parse(msgs[4]);
                        Client.InitializeClient();
                    }
                }
            }
        }

        /// <summary>
        /// 获取本机Ip
        /// </summary>
        /// <returns>返回第一个本机Ipv4</returns>
        private static long RetrieveHostIpv4Address()
        {
            //获得所有的ip地址，包括ipv6和ipv4
            IPAddress[] ips = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress tip in ips)
            {
                //ipv4的最大长度为15，ipv6为39
                if (tip.ToString().Length <= 15)
                {
                    return UdpBroadcast.GetLongIp(tip.ToString());
                }
            }
            return 0;
        }

        public static void Client_ReceivedTxt(object sender, EventArgs e)
        {
            string[] msgs=sender.ToString().Split('$');
            if (msgs[0] == "oes")
            {
                switch (msgs[1])
                {
                    case "1":
                        switch (msgs[2])
                        {
                            case "1":
                                if (LoginReturn != null)
                                {
                                    LoginReturn(new string[] { msgs[3], msgs[4] }, null);
                                }
                                break;
                            case "0":
                                if (LoginReturn != null)
                                {
                                    LoginReturn(null, null);
                                }
                                break;
                        }
                        break;
                    case "2":
                        if (msgs[2] == "4")
                        {
                            if (ConfirmReStart != null)
                            {
                                ConfirmReStart(null, null);
                            }
                        }
                        break;
                    case "4":
                        ClientControl.password = msgs[2];
                        ClientControl.isGetPwd = true;
                        break;
                    case "5":
                        ClientControl.ControlBar.butHandIn_Click(null, null);
                        break;
                    case "6":
                        ClientControl.ControlBar.SetTime(Convert.ToInt32(msgs[2])*60);
                        break;
                    case "7":
                        MessageBox.Show(msgs[2]);
                        break;
                    case "8":
                        SystemControl.LogOffComputer();
                        break;
                    case "9":
                        if (ClientControl.WaitingForm.Visible)
                        {
                            ClientControl.WaitingForm.BeginInvoke(new MethodInvoker(() =>
                                {
                                    ClientControl.WaitingForm.Hide();
                                    ClientControl.WaitingForm = null;
                                    ClientControl.LoginForm.Show();
                                    ClientControl.LoginForm.SetNetState(0);
                                    OES.DAO.MD5File.GenerateSecurityFile("End");
                                    if (Directory.Exists(Config.paperPath))
                                        Directory.Delete(Config.paperPath, true);
                                    Directory.Move(Config.stuPath, Config.HistoryPath + DateTime.Now.Ticks.ToString());
                                }));
                        }
                        break;
                    default:
                        break;
                }
            }
        }


        public static void beginExam(int p,string pwd)
        {
            switch (p)
            {
                case 0:
                case 1:
                case 2:
                    Client.SendTxt("oes$2$" + p.ToString());
                    break;
                case 3:
                    Client.SendTxt("oes$2$3$" + pwd);
                    break;
            }
        }

        public static void logout()
        {
            Client.SendTxt("oes$3");
        }

        public static string Paper
        {
            get 
            {
                return ClientEvt.Client.Port.FilePath;
            }
            set 
            {
                ClientEvt.Client.Port.FilePath = value;
            }
        }

        public static string Answer
        {
            get
            {
                return ClientEvt.Client.Port.FilePath;
            }
            set 
            {
                ClientEvt.Client.Port.FilePath = value;
            }
        }
    }
}
