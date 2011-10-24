﻿using System;
using System.Collections.Generic;
 
using System.Text;
using System.IO;

namespace OES.Net
{
    public class ClientEvt
    {
        public static OESClient Client = new OESClient();
        public static event EventHandler LoginReturn;
        List<string> remoteCom=new List<string>() ;
        List<string> localPath=new List<string>();
        public static Boolean isOver=false;

        public ClientEvt()
        {
            Client.InitializeClient();
            Client.ReceivedTxt+=new EventHandler(Client_ReceivedTxt);
            Client.Port.FileReceiveEnd += new EventHandler(Port_FileReceiveEnd);
            Client.Port.FileSendEnd += new EventHandler(Port_FileSendEnd);
        }

        void Port_FileSendEnd(object sender, EventArgs e)
        {
            isOver = true;
        }

        void Port_FileReceiveEnd(object sender, EventArgs e)
        {
            isOver = true;
        }

        public void SendFiles()
        {
            Client.SendFileList(remoteCom, localPath);
            Client.FileListSendEnd += new Action(Client_FileListSendEnd);
        }

        void Client_FileListSendEnd()
        {
            remoteCom.Clear();
            localPath.Clear();
        }

        public void ReceiveFiles()
        {
            Client.ReceiveFileList(remoteCom, localPath);
            Client.FileListRecieveEnd += new Action(Client_FileListRecieveEnd);
            
        }

        void Client_FileListRecieveEnd()
        {
            remoteCom.Clear();
            localPath.Clear();
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
            isOver=false;
            Client.Port.FilePath = InfoControl.config["TempPaperPath"] + id.ToString() + ".xml";
            Client.SendTxt("server$2$0$" + tid.ToString() + "$" + id.ToString());
            Client.ReceiveFile();
        }
        public void LoadWordA(int id, int tid)
        {
            localPath.Add(InfoControl.config["WordPath"] + "a" + id.ToString() + ".doc");
            remoteCom.Add("server$2$1$" + tid.ToString() + "$" + id.ToString());
        }
        public void LoadWordP(int id, int tid)
        {
            localPath.Add(InfoControl.config["WordPath"] + "p" + id.ToString() + ".doc");
            remoteCom.Add("server$2$2$" + tid.ToString() + "$" + id.ToString());
             
        }
        public void LoadWordT(int id, int tid)
        {
            localPath.Add(InfoControl.config["WordPath"] + "t" + id.ToString() + ".xml");
            remoteCom.Add("server$2$3$" + tid.ToString() + "$" + id.ToString());
             
        }
        public void LoadExcelA(int id, int tid)
        {
            localPath.Add(InfoControl.config["ExcelPath"] + "a" + id.ToString() + ".xls");
            remoteCom.Add("server$2$4$" + tid.ToString() + "$" + id.ToString());
             
        }
        public void LoadExcelP(int id, int tid)
        {
            localPath.Add(InfoControl.config["ExcelPath"] + "p" + id.ToString() + ".xls");
            remoteCom.Add("server$2$5$" + tid.ToString() + "$" + id.ToString());
             
        }
        public void LoadExcelT(int id, int tid)
        {
            localPath.Add(InfoControl.config["ExcelPath"] + "t" + id.ToString() + ".xml");
            remoteCom.Add("server$2$6$" + tid.ToString() + "$" + id.ToString());
             
        }
        public void LoadPowerPointA(int id, int tid)
        {
            localPath.Add(InfoControl.config["PPTPath"] + "a" + id.ToString() + ".ppt");
            remoteCom.Add("server$2$7$" + tid.ToString() + "$" + id.ToString());
             
        }
        public void LoadPowerPointP(int id, int tid)
        {
            localPath.Add(InfoControl.config["PPTPath"] + "p" + id.ToString() + ".ppt");
            remoteCom.Add("server$2$8$" + tid.ToString() + "$" + id.ToString());
             
        }
        public void LoadPowerPointT(int id, int tid)
        {
            localPath.Add(InfoControl.config["PPTPath"] + "t" + id.ToString() + ".xml");
            remoteCom.Add("server$2$9$" + tid.ToString() + "$" + id.ToString());
             
        }
        public void LoadCCompletion(int id, int tid)
        {
            localPath.Add(InfoControl.config["CompletionPath"] + id.ToString() + ".c");
            remoteCom.Add("server$2$A$" + tid.ToString() + "$" + id.ToString());
             
        }
        public void LoadCModification(int id, int tid)
        {
            localPath.Add(InfoControl.config["ModificationPath"] + id.ToString() + ".c");
            remoteCom.Add("server$2$B$" + tid.ToString() + "$" + id.ToString());
             
        }
        public void LoadCFunctionA(int id, int tid)
        {
            localPath.Add(InfoControl.config["FunctionPath"] + "a" + id.ToString() + ".c");
            remoteCom.Add("server$2$C$" + tid.ToString() + "$" + id.ToString());
             
        }
        public void LoadCFunctionP(int id, int tid)
        {
            localPath.Add(InfoControl.config["FunctionPath"] + "p" + id.ToString() + ".c");
            remoteCom.Add("server$2$D$" + tid.ToString() + "$" + id.ToString());
             
        }
        public void LoadCppCompletion(int id, int tid)
        {
            localPath.Add(InfoControl.config["CompletionPath"] + id.ToString() + ".cpp");
            remoteCom.Add("server$2$E$" + tid.ToString() + "$" + id.ToString());
             
        }
        public void LoadCppModification(int id, int tid)
        {
            localPath.Add(InfoControl.config["ModificationPath"] + id.ToString() + ".cpp");
            remoteCom.Add("server$2$F$" + tid.ToString() + "$" + id.ToString());
             
        }
        public void LoadCppFunctionA(int id, int tid)
        {
            localPath.Add(InfoControl.config["FunctionPath"] + "a" + id.ToString() + ".cpp");
            remoteCom.Add("server$2$G$" + tid.ToString() + "$" + id.ToString());
             
        }
        public void LoadCppFunctionP(int id, int tid)
        {
            localPath.Add(InfoControl.config["FunctionPath"] + "p" + id.ToString() + ".cpp");
            remoteCom.Add("server$2$H$" + tid.ToString() + "$" + id.ToString());
             
        }
        public void LoadVbCompletion(int id, int tid)
        {
            localPath.Add(InfoControl.config["CompletionPath"] + id.ToString() + ".vb");
            remoteCom.Add("server$2$I$" + tid.ToString() + "$" + id.ToString());
             
        }
        public void LoadVbModification(int id, int tid)
        {
            localPath.Add(InfoControl.config["ModificationPath"] + id.ToString() + ".vb");
            remoteCom.Add("server$2$J$" + tid.ToString() + "$" + id.ToString());
             
        }
        public void LoadVbFunctionA(int id, int tid)
        {
            localPath.Add(InfoControl.config["FunctionPath"] + "a" + id.ToString() + ".vb");
            remoteCom.Add("server$2$K$" + tid.ToString() + "$" + id.ToString());
             
        }
        public void LoadVbFunctionP(int id, int tid)
        {
            localPath.Add(InfoControl.config["FunctionPath"] + "p" + id.ToString() + ".vb");
            remoteCom.Add("server$2$L$" + tid.ToString() + "$" + id.ToString());
             
        }
        public void SavePaper(int id, int tid)
        {
            isOver = false;
            Client.Port.FilePath = InfoControl.config["TempPaperPath"] + id.ToString() + ".xml";
            Client.SendTxt("server$0$0$" + tid.ToString() + "$" + id.ToString());
            Client.SendFile();
        }
        public void SaveWordA(int id, int tid)
        {
            localPath.Add(InfoControl.config["WordPath"] + "a" + id.ToString() + ".doc");
            remoteCom.Add("server$0$1$" + tid.ToString() + "$" + id.ToString());
             
        }
        public void SaveWordP(int id, int tid)
        {
            localPath.Add(InfoControl.config["WordPath"] + "p" + id.ToString() + ".doc");
            remoteCom.Add("server$0$2$" + tid.ToString() + "$" + id.ToString());
             
        }
        public void SaveWordT(int id, int tid)
        {
            localPath.Add(InfoControl.config["WordPath"] + "t" + id.ToString() + ".xml");
            remoteCom.Add("server$0$3$" + tid.ToString() + "$" + id.ToString());
             
        }
        public void SaveExcelA(int id, int tid)
        {
            localPath.Add(InfoControl.config["ExcelPath"] + "a" + id.ToString() + ".xls");
            remoteCom.Add("server$0$4$" + tid.ToString() + "$" + id.ToString());
             
        }
        public void SaveExcelP(int id, int tid)
        {
            localPath.Add(InfoControl.config["ExcelPath"] + "p" + id.ToString() + ".xls");
            remoteCom.Add("server$0$5$" + tid.ToString() + "$" + id.ToString());
             
        }
        public void SaveExcelT(int id, int tid)
        {
            localPath.Add(InfoControl.config["ExcelPath"] + "t" + id.ToString() + ".xml");
            remoteCom.Add("server$0$6$" + tid.ToString() + "$" + id.ToString());
             
        }
        public void SavePowerPointA(int id, int tid)
        {
            localPath.Add(InfoControl.config["PPTPath"] + "a" + id.ToString() + ".ppt");
            remoteCom.Add("server$0$7$" + tid.ToString() + "$" + id.ToString());
             
        }
        public void SavePowerPointP(int id, int tid)
        {
            localPath.Add(InfoControl.config["PPTPath"] + "p" + id.ToString() + ".ppt");
            remoteCom.Add("server$0$8$" + tid.ToString() + "$" + id.ToString());
             
        }
        public void SavePowerPointT(int id, int tid)
        {
            localPath.Add(InfoControl.config["PPTPath"] + "a" + id.ToString() + ".xml");
            remoteCom.Add("server$0$9$" + tid.ToString() + "$" + id.ToString());
             
        }
        public void SaveCCompletion(int id, int tid)
        {
            localPath.Add(InfoControl.config["CompletionPath"] + id.ToString() + ".c");
            remoteCom.Add("server$0$A$" + tid.ToString() + "$" + id.ToString());
             
        }
        public void SaveCModification(int id, int tid)
        {
            localPath.Add(InfoControl.config["ModificationPath"] + id.ToString() + ".c");
            remoteCom.Add("server$0$B$" + tid.ToString() + "$" + id.ToString());
             
        }
        public void SaveCFunctionA(int id, int tid)
        {
            localPath.Add(InfoControl.config["FunctionPath"] + "a" + id.ToString() + ".c");
            remoteCom.Add("server$0$C$" + tid.ToString() + "$" + id.ToString());
             
        }
        public void SaveCFunctionP(int id, int tid)
        {
            localPath.Add(InfoControl.config["FunctionPath"] + "p" + id.ToString() + ".c");
            remoteCom.Add("server$0$D$" + tid.ToString() + "$" + id.ToString());
             
        }
        public void SaveCppCompletion(int id, int tid)
        {
            localPath.Add(InfoControl.config["CompletionPath"] + id.ToString() + ".cpp");
            remoteCom.Add("server$0$E$" + tid.ToString() + "$" + id.ToString());
             
        }
        public void SaveCppModification(int id, int tid)
        {
            localPath.Add(InfoControl.config["ModificationPath"] + id.ToString() + ".cpp");
            remoteCom.Add("server$0$F$" + tid.ToString() + "$" + id.ToString());
             
        }
        public void SaveCppFunctionA(int id, int tid)
        {
            localPath.Add(InfoControl.config["FunctionPath"] + "a" + id.ToString() + ".cpp");
            remoteCom.Add("server$0$G$" + tid.ToString() + "$" + id.ToString());
             
        }
        public void SaveCppFunctionP(int id, int tid)
        {
            localPath.Add(InfoControl.config["FunctionPath"] + "p" + id.ToString() + ".cpp");
            remoteCom.Add("server$0$H$" + tid.ToString() + "$" + id.ToString());
             
        }
        public void SaveVbCompletion(int id, int tid)
        {
            localPath.Add(InfoControl.config["CompletionPath"] + id.ToString() + ".vb");
            remoteCom.Add("server$0$I$" + tid.ToString() + "$" + id.ToString());
             
        }
        public void SaveVbModification(int id, int tid)
        {
            localPath.Add(InfoControl.config["ModificationPath"] + id.ToString() + ".vb");
            remoteCom.Add("server$0$J$" + tid.ToString() + "$" + id.ToString());
             
        }
        public void SaveVbFunctionA(int id, int tid)
        {
            localPath.Add(InfoControl.config["FunctionPath"] + "a" + id.ToString() + ".vb");
            remoteCom.Add("server$0$K$" + tid.ToString() + "$" + id.ToString());
             
        }
        public void SaveVbFunctionP(int id, int tid)
        {
            localPath.Add(InfoControl.config["FunctionPath"] + "p" + id.ToString() + ".vb");
            remoteCom.Add("server$0$L$" + tid.ToString() + "$" + id.ToString());
             
        }

    }
    public class FileConvertHelper
    {
        public enum ProblemEnum
        {
            Paper,
            WordA,
            WordP,
            WordT,
            ExcelA,
            ExcelP,
            ExcelT,
            PowerPointA,
            PowerPointP,
            PowerPointT,
            CCompletion,
            CModification,
            CFunctionA,
            CFunctionP,
            CppCompletion,
            CppModification,
            CppFunctionA,
            CppFunctionP,
            VbCompletion,
            VbModification,
            VbFunctionA,
            VbFunctionP
        }
        /// <summary>
        /// 执行文件拷贝，并改变名称
        /// </summary>
        /// <param name="fromFile">原始文件路径</param>
        /// <param name="problemId">问题Id</param>
        /// <param name="problemType">问题类型</param>
        public static void Execute(String fromFile, int problemId, ProblemEnum problemType)
        {
            switch (problemType)
            {
                case ProblemEnum.Paper:
                    File.Copy(fromFile, InfoControl.config["TempPaperPath"] + problemId.ToString() + ".xml", true);
                    break;
                case ProblemEnum.WordA:
                    File.Copy(fromFile, InfoControl.config["WordPath"] + "a" + problemId.ToString() + ".doc", true);
                    break;
                case ProblemEnum.WordP:
                    File.Copy(fromFile, InfoControl.config["WordPath"] + "p" + problemId.ToString() + ".doc", true);
                    break;
                case ProblemEnum.WordT:
                    File.Copy(fromFile, InfoControl.config["WordPath"] + "t" + problemId.ToString() + ".xml", true);
                    break;
                case ProblemEnum.ExcelA:
                    File.Copy(fromFile, InfoControl.config["ExcelPath"] + "a" + problemId.ToString() + ".xls", true);
                    break;
                case ProblemEnum.ExcelP:
                    File.Copy(fromFile, InfoControl.config["ExcelPath"] + "p" + problemId.ToString() + ".xls", true);
                    break;
                case ProblemEnum.ExcelT:
                    File.Copy(fromFile, InfoControl.config["ExcelPath"] + "t" + problemId.ToString() + ".xml", true);
                    break;
                case ProblemEnum.PowerPointA:
                    File.Copy(fromFile, InfoControl.config["PPTPath"] + "a" + problemId.ToString() + ".ppt", true);
                    break;
                case ProblemEnum.PowerPointP:
                    File.Copy(fromFile, InfoControl.config["PPTPath"] + "p" + problemId.ToString() + ".ppt", true);
                    break;
                case ProblemEnum.PowerPointT:
                    File.Copy(fromFile, InfoControl.config["PPTPath"] + "t" + problemId.ToString() + ".xml", true);
                    break;
                case ProblemEnum.CCompletion:
                    File.Copy(fromFile, InfoControl.config["CompletionPath"] + problemId.ToString() + ".c", true);
                    break;
                case ProblemEnum.CModification:
                    File.Copy(fromFile, InfoControl.config["ModificationPath"] + problemId.ToString() + ".c", true);
                    break;
                case ProblemEnum.CFunctionA:
                    File.Copy(fromFile, InfoControl.config["FunctionPath"] + "a" + problemId.ToString() + ".c", true);
                    break;
                case ProblemEnum.CFunctionP:
                    File.Copy(fromFile, InfoControl.config["FunctionPath"] + "p" + problemId.ToString() + ".c", true);
                    break;
                case ProblemEnum.CppCompletion:
                    File.Copy(fromFile, InfoControl.config["CompletionPath"] + problemId.ToString() + ".cpp", true);
                    break;
                case ProblemEnum.CppModification:
                    File.Copy(fromFile, InfoControl.config["ModificationPath"] + problemId.ToString() + ".cpp", true);
                    break;
                case ProblemEnum.CppFunctionA:
                    File.Copy(fromFile, InfoControl.config["FunctionPath"] + "a" + problemId.ToString() + ".cpp", true);
                    break;
                case ProblemEnum.CppFunctionP:
                    File.Copy(fromFile, InfoControl.config["FunctionPath"] + "p" + problemId.ToString() + ".cpp", true);
                    break;
                case ProblemEnum.VbCompletion:
                    File.Copy(fromFile, InfoControl.config["CompletionPath"] + problemId.ToString() + ".vb", true);
                    break;
                case ProblemEnum.VbModification:
                    File.Copy(fromFile, InfoControl.config["ModificationPath"] + problemId.ToString() + ".vb", true);
                    break;
                case ProblemEnum.VbFunctionA:
                    File.Copy(fromFile, InfoControl.config["FunctionPath"] + "a" + problemId.ToString() + ".vb", true);
                    break;
                case ProblemEnum.VbFunctionP:
                    File.Copy(fromFile, InfoControl.config["FunctionPath"] + "p" + problemId.ToString() + ".vb", true);
                    break;
            }
        }
    }
}
