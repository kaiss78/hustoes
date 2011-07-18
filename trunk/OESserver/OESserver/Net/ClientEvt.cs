﻿using System;
using System.Collections.Generic;
 
using System.Text;

namespace OES.Net
{
    public class ClientEvt
    {
        public static OESClient Client = new OESClient();
        public static event EventHandler LoginReturn;


        public ClientEvt()
        {
            Client.InitializeClient();
            Client.ReceivedTxt+=new EventHandler(Client_ReceivedTxt);
        }

        static void Client_ReceivedTxt(object sender, EventArgs e)
        {
            //string[] msgs=sender.ToString().Split('$');
            //if (msgs[0] == "server")
            //{
            //    switch (msgs[1])
            //    {
            //        case "1":
            //            switch (msgs[2])
            //            {
            //                case "1":
            //                    if (LoginReturn != null)
            //                    {
            //                        LoginReturn(msgs[3], null);
            //                    }
            //                    break;
            //                case "0":
            //                    if (LoginReturn != null)
            //                    {
            //                        LoginReturn(null, null);
            //                    }
            //                    break;
            //            }
            //            break;
            //        default:
            //            break;
            //    }
            //}
        }

        public void Login(int tid)
        {
            Client.SendTxt("server$4$"+tid.ToString());
        }
        public void LoadPaper(int id, int tid)
        {
            Client.Port.FilePath = Config.TempPaperPath  + id.ToString() + ".xml";
            Client.SendTxt("server$2$0$" + tid.ToString() + "$" + id.ToString());
            Client.ReceiveFile();
        }
        public void LoadWordA(int id, int tid)
        {
            Client.Port.FilePath = Config.WordPath + "a" + id.ToString() + ".doc";
            Client.SendTxt("server$2$1$" + tid.ToString() + "$" + id.ToString());
            Client.ReceiveFile();
        }
        public void LoadWordP(int id, int tid)
        {
            Client.Port.FilePath = Config.WordPath + "p" + id.ToString() + ".doc";
            Client.SendTxt("server$2$2$" + tid.ToString() + "$" + id.ToString());
            Client.ReceiveFile();
        }
        public void LoadWordT(int id, int tid)
        {
            Client.Port.FilePath = Config.WordPath + "t" + id.ToString() + ".xml";
            Client.SendTxt("server$2$3$" + tid.ToString() + "$" + id.ToString());
            Client.ReceiveFile();
        }
        public void LoadExcelA(int id, int tid)
        {
            Client.Port.FilePath = Config.ExcelPath + "a" + id.ToString() + ".xls";
            Client.SendTxt("server$2$4$" + tid.ToString() + "$" + id.ToString());
            Client.ReceiveFile();
        }
        public void LoadExcelP(int id, int tid)
        {
            Client.Port.FilePath = Config.ExcelPath + "p" + id.ToString() + ".xls";
            Client.SendTxt("server$2$5$" + tid.ToString() + "$" + id.ToString());
            Client.ReceiveFile();
        }
        public void LoadExcelT(int id, int tid)
        {
            Client.Port.FilePath = Config.ExcelPath + "t" + id.ToString() + ".xml";
            Client.SendTxt("server$2$6$" + tid.ToString() + "$" + id.ToString());
            Client.ReceiveFile();
        }
        public void LoadPowerPointA(int id, int tid)
        {
            Client.Port.FilePath = Config.PPTPath + "a" + id.ToString() + ".ppt";
            Client.SendTxt("server$2$7$" + tid.ToString() + "$" + id.ToString());
            Client.ReceiveFile();
        }
        public void LoadPowerPointP(int id, int tid)
        {
            Client.Port.FilePath = Config.PPTPath + "p" + id.ToString() + ".ppt";
            Client.SendTxt("server$2$8$" + tid.ToString() + "$" + id.ToString());
            Client.ReceiveFile();
        }
        public void LoadPowerPointT(int id, int tid)
        {
            Client.Port.FilePath = Config.PPTPath + "t" + id.ToString() + ".xml";
            Client.SendTxt("server$2$9$" + tid.ToString() + "$" + id.ToString());
            Client.ReceiveFile();
        }
        public void LoadCCompletion(int id, int tid)
        {
            Client.Port.FilePath = Config.CompletionPath  + id.ToString() + ".c";
            Client.SendTxt("server$2$A$" + tid.ToString() + "$" + id.ToString());
            Client.ReceiveFile();
        }
        public void LoadCModification(int id, int tid)
        {
            Client.Port.FilePath = Config.ModificationPath + id.ToString() + ".c";
            Client.SendTxt("server$2$B$" + tid.ToString() + "$" + id.ToString());
            Client.ReceiveFile();
        }
        public void LoadCFunctionA(int id, int tid)
        {
            Client.Port.FilePath = Config.FunctionPath + "a" + id.ToString() + ".c";
            Client.SendTxt("server$2$C$" + tid.ToString() + "$" + id.ToString());
            Client.ReceiveFile();
        }
        public void LoadCFunctionP(int id, int tid)
        {
            Client.Port.FilePath = Config.FunctionPath + "p" + id.ToString() + ".c";
            Client.SendTxt("server$2$D$" + tid.ToString() + "$" + id.ToString());
            Client.ReceiveFile();
        }
        public void LoadCppCompletion(int id, int tid)
        {
            Client.Port.FilePath = Config.CompletionPath + id.ToString() + ".cpp";
            Client.SendTxt("server$2$E$" + tid.ToString() + "$" + id.ToString());
            Client.ReceiveFile();
        }
        public void LoadCppModification(int id, int tid)
        {
            Client.Port.FilePath = Config.ModificationPath + id.ToString() + ".cpp";
            Client.SendTxt("server$2$F$" + tid.ToString() + "$" + id.ToString());
            Client.ReceiveFile();
        }
        public void LoadCppFunctionA(int id, int tid)
        {
            Client.Port.FilePath = Config.FunctionPath + "a" + id.ToString() + ".cpp";
            Client.SendTxt("server$2$G$" + tid.ToString() + "$" + id.ToString());
            Client.ReceiveFile();
        }
        public void LoadCppFunctionP(int id, int tid)
        {
            Client.Port.FilePath = Config.FunctionPath + "p" + id.ToString() + ".cpp";
            Client.SendTxt("server$2$H$" + tid.ToString() + "$" + id.ToString());
            Client.ReceiveFile();
        }
        public void LoadVbCompletion(int id, int tid)
        {
            Client.Port.FilePath = Config.CompletionPath + id.ToString() + ".vb";
            Client.SendTxt("server$2$I$" + tid.ToString() + "$" + id.ToString());
            Client.ReceiveFile();
        }
        public void LoadVbModification(int id, int tid)
        {
            Client.Port.FilePath = Config.ModificationPath + id.ToString() + ".vb";
            Client.SendTxt("server$2$J$" + tid.ToString() + "$" + id.ToString());
            Client.ReceiveFile();
        }
        public void LoadVbFunctionA(int id, int tid)
        {
            Client.Port.FilePath = Config.FunctionPath + "a" + id.ToString() + ".vb";
            Client.SendTxt("server$2$K$" + tid.ToString() + "$" + id.ToString());
            Client.ReceiveFile();
        }
        public void LoadVbFunctionP(int id, int tid)
        {
            Client.Port.FilePath = Config.FunctionPath + "p" + id.ToString() + ".vb";
            Client.SendTxt("server$2$L$" + tid.ToString() + "$" + id.ToString());
            Client.ReceiveFile();
        }
        public void SavePaper(int id, int tid)
        {
            Client.Port.FilePath = Config.TempPaperPath + id.ToString() + ".xml";
            Client.SendTxt("server$0$0$" + tid.ToString() + "$" + id.ToString());
            Client.SendFile();
        }
        public void SaveWordA(int id, int tid)
        {
            Client.Port.FilePath = Config.WordPath +"a"+ id.ToString() + ".doc";
            Client.SendTxt("server$0$1$" + tid.ToString() + "$" + id.ToString());
            Client.SendFile();
        }
        public void SaveWordP(int id, int tid)
        {
            Client.Port.FilePath = Config.WordPath + "p" + id.ToString() + ".doc";
            Client.SendTxt("server$0$2$" + tid.ToString() + "$" + id.ToString());
            Client.SendFile();
        }
        public void SaveWordT(int id, int tid)
        {
            Client.Port.FilePath = Config.WordPath + "t" + id.ToString() + ".xml";
            Client.SendTxt("server$0$3$" + tid.ToString() + "$" + id.ToString());
            Client.SendFile();
        }
        public void SaveExcelA(int id, int tid)
        {
            Client.Port.FilePath = Config.ExcelPath + "a" + id.ToString() + ".xls";
            Client.SendTxt("server$0$4$" + tid.ToString() + "$" + id.ToString());
            Client.SendFile();
        }
        public void SaveExcelP(int id, int tid)
        {
            Client.Port.FilePath = Config.ExcelPath + "p" + id.ToString() + ".xls";
            Client.SendTxt("server$0$5$" + tid.ToString() + "$" + id.ToString());
            Client.SendFile();
        }
        public void SaveExcelT(int id, int tid)
        {
            Client.Port.FilePath = Config.ExcelPath + "t" + id.ToString() + ".xml";
            Client.SendTxt("server$0$6$" + tid.ToString() + "$" + id.ToString());
            Client.SendFile();
        }
        public void SavePowerPointA(int id, int tid)
        {
            Client.Port.FilePath = Config.PPTPath + "a" + id.ToString() + ".ppt";
            Client.SendTxt("server$0$7$" + tid.ToString() + "$" + id.ToString());
            Client.SendFile();
        }
        public void SavePowerPointP(int id, int tid)
        {
            Client.Port.FilePath = Config.PPTPath + "p" + id.ToString() + ".ppt";
            Client.SendTxt("server$0$8$" + tid.ToString() + "$" + id.ToString());
            Client.SendFile();
        }
        public void SavePowerPointT(int id, int tid)
        {
            Client.Port.FilePath = Config.PPTPath + "a" + id.ToString() + ".xml";
            Client.SendTxt("server$0$9$" + tid.ToString() + "$" + id.ToString());
            Client.SendFile();
        }
        public void SaveCCompletion(int id, int tid)
        {
            Client.Port.FilePath = Config.CompletionPath + id.ToString() + ".c";
            Client.SendTxt("server$0$A$" + tid.ToString() + "$" + id.ToString());
            Client.SendFile();
        }
        public void SaveCModification(int id, int tid)
        {
            Client.Port.FilePath = Config.ModificationPath + id.ToString() + ".c";
            Client.SendTxt("server$0$B$" + tid.ToString() + "$" + id.ToString());
            Client.SendFile();
        }
        public void SaveCFunctionA(int id, int tid)
        {
            Client.Port.FilePath = Config.FunctionPath + "a" + id.ToString() + ".c";
            Client.SendTxt("server$0$C$" + tid.ToString() + "$" + id.ToString());
            Client.SendFile();
        }
        public void SaveCFunctionP(int id, int tid)
        {
            Client.Port.FilePath = Config.FunctionPath + "p" + id.ToString() + ".c";
            Client.SendTxt("server$0$D$" + tid.ToString() + "$" + id.ToString());
            Client.SendFile();
        }
        public void SaveCppCompletion(int id, int tid)
        {
            Client.Port.FilePath = Config.CompletionPath + id.ToString() + ".cpp";
            Client.SendTxt("server$0$E$" + tid.ToString() + "$" + id.ToString());
            Client.SendFile();
        }
        public void SaveCppModification(int id, int tid)
        {
            Client.Port.FilePath = Config.ModificationPath + id.ToString() + ".cpp";
            Client.SendTxt("server$0$F$" + tid.ToString() + "$" + id.ToString());
            Client.SendFile();
        }
        public void SaveCppFunctionA(int id, int tid)
        {
            Client.Port.FilePath = Config.FunctionPath + "a" + id.ToString() + ".cpp";
            Client.SendTxt("server$0$G$" + tid.ToString() + "$" + id.ToString());
            Client.SendFile();
        }
        public void SaveCppFunctionP(int id, int tid)
        {
            Client.Port.FilePath = Config.FunctionPath + "p" + id.ToString() + ".cpp";
            Client.SendTxt("server$0$H$" + tid.ToString() + "$" + id.ToString());
            Client.SendFile();
        }
        public void SaveVbCompletion(int id, int tid)
        {
            Client.Port.FilePath = Config.CompletionPath + id.ToString() + ".vb";
            Client.SendTxt("server$0$I$" + tid.ToString() + "$" + id.ToString());
            Client.SendFile();
        }
        public void SaveVbModification(int id, int tid)
        {
            Client.Port.FilePath = Config.ModificationPath + id.ToString() + ".vb";
            Client.SendTxt("server$0$J$" + tid.ToString() + "$" + id.ToString());
            Client.SendFile();
        }
        public void SaveVbFunctionA(int id, int tid)
        {
            Client.Port.FilePath = Config.FunctionPath + "a" + id.ToString() + ".vb";
            Client.SendTxt("server$0$K$" + tid.ToString() + "$" + id.ToString());
            Client.SendFile();
        }
        public void SaveVbFunctionP(int id, int tid)
        {
            Client.Port.FilePath = Config.FunctionPath + "p" + id.ToString() + ".vb";
            Client.SendTxt("server$0$L$" + tid.ToString() + "$" + id.ToString());
            Client.SendFile();
        }
    }
}
