using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Collections;
using System.Threading;
using System.Windows.Forms;
using System.IO;

namespace OESMonitor.Net
{
    public class Client
    {
        private TcpClient client;
        private static int bufferSize = 128;    //命令端口大小
        private Byte[] buffer = new Byte[bufferSize];
        private NetworkStream ns;
        private string temp = String.Empty;
        private bool IsEnd;

        public int msg_type;
        public string msg;
        public DataPort port;
        public string paperPath;    //该考生试卷路径

        

        public IPAddress remoteIP;      //接收试卷所需信息
        public int remotePort;
        public string fileName;
        //public Computer computer;       //对应的界面元素

        #region 事件定义
        public delegate void SimpleFun();

        //消息处理
        public delegate void DisposeMessage(Client client);
        public event DisposeMessage MessageScheduler;
        
        //开始考试
        public delegate void StartTest(int reason);
        public event StartTest TestStarted;

        //登录检测
        public delegate bool ValidateLogin(string name, string id, string pwd);
        public event ValidateLogin LoginValidating;

        //登录成功
        public event SimpleFun LoginSuccess;

        //客户端崩溃
        public event SimpleFun ClientCrashed;

        //准备发卷
        public event SimpleFun PaperDelivering;

        //准备收卷
        public event SimpleFun AnswerHanding;

        //发卷完毕
        public event SimpleFun PaperDelivered;

        //收卷完毕
        public event SimpleFun AnswerHanded;

        //登出
        public event SimpleFun LogoutSuccess;

        #endregion
        public Client(TcpClient client)
        {
            IsEnd = false;
            this.client = client;
            ns = client.GetStream();
            ns.BeginRead(buffer, 0, bufferSize, new AsyncCallback(receive_callBack), client);
            MessageSupervisor.targetFrm.showMessage("Accept client: " + client.Client.RemoteEndPoint.ToString());
        }

        //试卷下发完毕
        public void port_paperDelivered(object sender, EventArgs e)
        {
            if (PaperDelivered != null)
                PaperDelivered();
            
        }

        //答案上交完毕
        public void port_answerHanded(object sender, EventArgs e)
        {
            if (AnswerHanded != null)
                AnswerHanded();
            
        }

        public string clientInfo()
        {
            try
            {
                return (client.Client.RemoteEndPoint.ToString());
            }
            catch
            {
                return "";
            }
        }

        //结束本连接
        public bool EndConnection()
        {
            string tmsg = "#STX#-1#NULL#ETX";
            MessageSupervisor.targetFrm.showMessage("Send Message: " + tmsg + " --->" + clientInfo());

            byte[] tBuffer = System.Text.Encoding.Default.GetBytes(tmsg);
            try
            {
                ns.BeginWrite(tBuffer, 0, tBuffer.Length, new AsyncCallback(write_callBack), client); 
            }
            catch (Exception e)
            {
                //网络出错处理程序
                return (false);
            }
            return (true);
        }
        
        //结束所有连接
        public void EndAllConnection()
        {
            if (client.Connected)
            {
                string tmsg = "#STX#-2#NULL#ETX";
                MessageSupervisor.targetFrm.showMessage("Send Message: " + tmsg + " --->" + clientInfo());

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
        }

        public void EndService()
        {
            MessageSupervisor.targetFrm.showMessage("Client :" + client.Client.RemoteEndPoint.ToString() + " End Connection");
            ns.Close();
            client.Close();
            IsEnd = true;
        }

        //Receive回调函数
        private void receive_callBack(IAsyncResult asy)
        {
            try
            {
                TcpClient tclient = (TcpClient)asy.AsyncState;
                int result = ns.EndRead(asy);
                GetActualFullMessage();

                if (!IsEnd)
                    ns.BeginRead(buffer, 0, bufferSize, new AsyncCallback(receive_callBack), client);
            }
            catch
            {
                if (ClientCrashed != null)
                    ClientCrashed();
           
                this.EndConnection();
                this.EndService();
                
            }
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
                    MessageSupervisor.targetFrm.showMessage("Message: [code]"+msg_type.ToString()+" [content]"+msg+" From: " + client.Client.RemoteEndPoint.ToString());
                    
                    MessageScheduler(this);
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
            if (PaperDelivering != null)
                PaperDelivering();
            port.LoadData(paperPath);
            FileInfo fi = new FileInfo(this.paperPath);
            string tmsg = "#STX#0#" + port.ip.ToString() + "$" + port.localPort.ToString() +"$"+fi.Length.ToString()+ "#ETX";

            MessageSupervisor.targetFrm.showMessage("Send Message: " + tmsg + " --->" + clientInfo());

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

        //学生登录
        public void Login(string name ,string id,string pwd)
        {
            string tmsg;
            if(LoginValidating ==null || LoginValidating(name,id,pwd))
            {
                tmsg = "#STX#3#" + "true" + "#ETX";
                if (LoginSuccess != null)
                    LoginSuccess();
            }
            else
            {
                tmsg = "#STX#3#" + "false" + "#ETX";
            }
            MessageSupervisor.targetFrm.showMessage("Login: " + tmsg + " --->" + clientInfo());

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

        //学生登出
        public void Logout()
        {
            if (LogoutSuccess != null)
                LogoutSuccess();
        }

        //Write回调函数
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

        public void FetchData()
        {
            string tmsg = "#STX#1#NULL#ETX";
            MessageSupervisor.targetFrm.showMessage("Send Message: " + tmsg + " --->" + clientInfo());

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

        public void ReceiveData()
        {
            if (AnswerHanding != null)
                AnswerHanding();
            
           if(!(port.DownloadData(remoteIP, remotePort, fileName)))
           {
               //网络出错处理程序
           }

        }

        //开始考试
        public void Start(int reason)
        {
            if (TestStarted != null)
                TestStarted(reason);
        }

    }
}
