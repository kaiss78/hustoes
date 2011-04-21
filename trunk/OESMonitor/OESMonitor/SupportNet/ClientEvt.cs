using System;
using System.Collections.Generic;
 
using System.Text;
using OESMonitor.PaperControl;

namespace OESMonitor.SupportNet
{
    public class ClientEvt
    {
        public OESClient Client;
        public Config conf;
        public ClientEvt()
        {
            conf=new Config();
            Client = new OESClient();
            Client.ReceivedTxt += new EventHandler(Client_ReceivedTxt);
            Client.InitializeClient();
        }

        void Client_ReceivedTxt(object sender, EventArgs e)
        {
            Console.WriteLine(sender.ToString());
        }

        public void LoadPaper(int id, int tid)
        {
             Client.SendTxt("server$2$0$" + tid.ToString() + "$" + id.ToString());
        }
        public void LoadWordA(int id, int tid)
        {
             Client.SendTxt("server$2$1$" + tid.ToString() + "$" + id.ToString());
        }
        public void LoadWordB(int id, int tid)
        {
             Client.SendTxt("server$2$2$" + tid.ToString() + "$" + id.ToString());
        }
        public void LoadExcelA(int id, int tid)
        {
             Client.SendTxt("server$2$3$" + tid.ToString() + "$" + id.ToString());
        }
        public void LoadExcelB(int id, int tid)
        {
             Client.SendTxt("server$2$4$" + tid.ToString() + "$" + id.ToString());
        }
        public void LoadPowerPointA(int id, int tid)
        {
             Client.SendTxt("server$2$5$" + tid.ToString() + "$" + id.ToString());
        }
        public void LoadPowerPointB(int id, int tid)
        {
             Client.SendTxt("server$2$6$" + tid.ToString() + "$" + id.ToString());
        }
        public void LoadCCompletion(int id, int tid)
        {
             Client.SendTxt("server$2$7$" + tid.ToString() + "$" + id.ToString());
        }
        public void LoadCModification(int id, int tid)
        {
             Client.SendTxt("server$2$8$" + tid.ToString() + "$" + id.ToString());
        }
        public void LoadCFunctionA(int id, int tid)
        {
             Client.SendTxt("server$2$9$" + tid.ToString() + "$" + id.ToString());
        }
        public void LoadCFunctionB(int id, int tid)
        {
             Client.SendTxt("server$2$A$" + tid.ToString() + "$" + id.ToString());
        }
        public void LoadCppCompletion(int id, int tid)
        {
             Client.SendTxt("server$2$B$" + tid.ToString() + "$" + id.ToString());
        }
        public void LoadCppModification(int id, int tid)
        {
             Client.SendTxt("server$2$C$" + tid.ToString() + "$" + id.ToString());
        }
        public void LoadCppFunctionA(int id, int tid)
        {
             Client.SendTxt("server$2$D$" + tid.ToString() + "$" + id.ToString());
        }
        public void LoadCppFunctionB(int id, int tid)
        {
             Client.SendTxt("server$2$E$" + tid.ToString() + "$" + id.ToString());
        }
        public void LoadVbCompletion(int id, int tid)
        {
             Client.SendTxt("server$2$F$" + tid.ToString() + "$" + id.ToString());
        }
        public void LoadVbModification(int id, int tid)
        {
             Client.SendTxt("server$2$G$" + tid.ToString() + "$" + id.ToString());
        }
        public void LoadVbFunctionA(int id, int tid)
        {
             Client.SendTxt("server$2$H$" + tid.ToString() + "$" + id.ToString());
        }
        public void LoadVbFunctionB(int id, int tid)
        {
             Client.SendTxt("server$2$I$" + tid.ToString() + "$" + id.ToString());
        }
        public void SaveWordA(int id, int tid)
        {
             Client.SendTxt("server$0$0$" + tid.ToString() + "$" + id.ToString());
        }
        public void SaveWordB(int id, int tid)
        {
             Client.SendTxt("server$0$1$" + tid.ToString() + "$" + id.ToString());
        }
        public void SaveExcelA(int id, int tid)
        {
             Client.SendTxt("server$0$2$" + tid.ToString() + "$" + id.ToString());
        }
        public void SaveExcelB(int id, int tid)
        {
             Client.SendTxt("server$0$3$" + tid.ToString() + "$" + id.ToString());
        }
        public void SavePowerPointA(int id, int tid)
        {
             Client.SendTxt("server$0$4$" + tid.ToString() + "$" + id.ToString());
        }
        public void SavePowerPointB(int id, int tid)
        {
             Client.SendTxt("server$0$5$" + tid.ToString() + "$" + id.ToString());
        }
        public void SavePaper(int id, int tid)
        {
             Client.SendTxt("server$0$6$" + tid.ToString() + "$" + id.ToString());
        }
        public void SaveCCompletion(int id, int tid)
        {
             Client.SendTxt("server$0$7$" + tid.ToString() + "$" + id.ToString());
        }
        public void SaveCModification(int id, int tid)
        {
             Client.SendTxt("server$0$8$" + tid.ToString() + "$" + id.ToString());
        }
        public void SaveCFunctionA(int id, int tid)
        {
             Client.SendTxt("server$0$9$" + tid.ToString() + "$" + id.ToString());
        }
        public void SaveCFunctionB(int id, int tid)
        {
             Client.SendTxt("server$0$A$" + tid.ToString() + "$" + id.ToString());
        }
        public void SaveCppCompletion(int id, int tid)
        {
             Client.SendTxt("server$0$B$" + tid.ToString() + "$" + id.ToString());
        }
        public void SaveCppModification(int id, int tid)
        {
             Client.SendTxt("server$0$C$" + tid.ToString() + "$" + id.ToString());
        }
        public void SaveCppFunctionA(int id, int tid)
        {
             Client.SendTxt("server$0$D$" + tid.ToString() + "$" + id.ToString());
        }
        public void SaveCppFunctionB(int id, int tid)
        {
             Client.SendTxt("server$0$E$" + tid.ToString() + "$" + id.ToString());
        }
        public void SaveVbCompletion(int id, int tid)
        {
             Client.SendTxt("server$0$F$" + tid.ToString() + "$" + id.ToString());
        }
        public void SaveVbModification(int id, int tid)
        {
             Client.SendTxt("server$0$G$" + tid.ToString() + "$" + id.ToString());
        }
        public void SaveVbFunctionA(int id, int tid)
        {
             Client.SendTxt("server$0$H$" + tid.ToString() + "$" + id.ToString());
        }
        public void SaveVbFunctionB(int id, int tid)
        {
             Client.SendTxt("server$0$I$" + tid.ToString() + "$" + id.ToString());
        }
    }
}
