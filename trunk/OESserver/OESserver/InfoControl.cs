using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OES.Model;
using OES.UPanel;
using OES.XMLFile;
using OES.Net;

namespace OES
{
    public class InfoControl
    {
        //这里是网络部分接口
        private static ClientEvt clientObj = new ClientEvt();

        public static ClientEvt ClientObj
        {
            get { return InfoControl.clientObj; }
            set { InfoControl.clientObj = value; }
        }
        //--------------------------

        public static int WordID = 0;
        public static int PPTID = 0;
        public static int ExcelID = 0;
        public static int PCompletionID = 0;
        public static int PJudgeID = 0;
        public static int PModifID = 0;
        public static int Value = 0;
        public static OESConfig config = new OESConfig("PathConfig.xml",
            new string[,] {
            {"TempPaperPath","D:\\OES\\TempPaper\\"},
            {"ExcelPath","D:\\OES\\Excel\\"},
            {"WordPath","D:\\OES\\Word\\"},
            {"PPTPath","D:\\OES\\PPT\\"},
            {"CompletionPath","D:\\OES\\Completion\\"},
            {"FunctionPath","D:\\OES\\Function\\"},
            {"ModificationPath","D:\\OES\\Modification\\"},   
            });



        private static OESData oesData = new OESData();
        public static OESData OesData
        {
            get
            {
                if (oesData == null) { oesData = new OESData(); }
                return InfoControl.oesData;
            }
            set { InfoControl.oesData = value; }
        }

        private static Teacher teacher = null;
        public static Teacher User
        {
            get
            {
                if (teacher == null) { teacher = new Teacher(); }
                return InfoControl.teacher;
            }
            set { InfoControl.teacher = value; }
        }

        private static Paper paper = null;

        public static Paper TmpPaper
        {
            get
            {
                if (paper == null) { paper = new Paper(); }
                return InfoControl.paper;
            }
            set { InfoControl.paper = value; }
        }

        /// <summary>
        /// 获取下一题题号
        /// </summary>
        /// <param name="type">题目类型</param>
        /// <returns>题号</returns>
        public static int GetProNum(int type)
        {
            if (type > 2)
            {
                if (type > 8)
                {
                    type = type - 3;
                }
                if (InfoControl.TmpPaper.ProList[type][0].problemId == -1)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
            int tmp = InfoControl.Value;
            if (InfoControl.Value == -1)
            {
                for (int i = 0; i < InfoControl.TmpPaper.ProList[type].Count; i++)
                {
                    if (InfoControl.TmpPaper.ProList[type][i].problemId == -1)
                        return (i + 1);
                }
            }
            return tmp;
        }

        public static void getPaper(string paperID)
        {
            Problem tmpPro;
            TmpPaper = OesData.FindPaperById(paperID)[0];
            InfoControl.clientObj.LoadPaper(Convert.ToInt32(TmpPaper.paperID), Convert.ToInt32(User.Id));
            InfoControl.clientObj.ReceiveFiles();
            while (!ClientEvt.isOver) ;
            TmpPaper.paperPath = InfoControl.config["TempPaperPath"] + TmpPaper.paperID + ".xml";
            List<IdScoreType> tmpList = XMLControl.ReadPaper(TmpPaper.paperPath);
            for (int i = 0; i < 9; i++)
            {
                TmpPaper.ProList[i] = new List<Problem>();
            }
            foreach (IdScoreType pro in tmpList)
            {
                tmpPro = new Problem();
                switch (pro.pt)
                {
                    case ProblemType.Choice:
                        tmpPro = InfoControl.OesData.FindChoiceById(pro.id.ToString())[0];
                        InfoControl.TmpPaper.ProList[0].Add(tmpPro);
                        InfoControl.TmpPaper.score_choice = pro.score;
                        break;
                    case ProblemType.Tof:
                        tmpPro = InfoControl.OesData.FindTofById(pro.id.ToString())[0];
                        InfoControl.TmpPaper.ProList[2].Add(tmpPro);
                        InfoControl.TmpPaper.score_judge = pro.score;
                        break;
                    case ProblemType.Completion:
                        tmpPro = InfoControl.OesData.FindCompletionById(pro.id.ToString())[0];
                        InfoControl.TmpPaper.ProList[1].Add(tmpPro);
                        InfoControl.TmpPaper.score_completion = pro.score;
                        break;
                    case ProblemType.Word:
                        tmpPro = InfoControl.OesData.FindOfficeWordById(pro.id.ToString())[0];
                        InfoControl.TmpPaper.ProList[5].Add(tmpPro);
                        InfoControl.TmpPaper.score_officeWord = pro.score;
                        break;
                    case ProblemType.PowerPoint:
                        tmpPro = InfoControl.OesData.FindOfficePowerPointById(pro.id.ToString())[0];
                        InfoControl.TmpPaper.ProList[4].Add(tmpPro);
                        InfoControl.TmpPaper.score_officePPT = pro.score;
                        break;
                    case ProblemType.Excel:
                        tmpPro = InfoControl.OesData.FindOfficeExcelById(pro.id.ToString())[0];
                        InfoControl.TmpPaper.ProList[3].Add(tmpPro);
                        InfoControl.TmpPaper.score_officeExcel = pro.score;
                        break;
                    case ProblemType.ProgramModification:
                        tmpPro = InfoControl.OesData.FindModificationProgramById(pro.id.ToString())[0];
                        InfoControl.TmpPaper.ProList[7].Add(tmpPro);
                        InfoControl.TmpPaper.score_pModif = pro.score;
                        break;
                    case ProblemType.ProgramCompletion:
                        tmpPro = InfoControl.OesData.FindCompletionProgramById(pro.id.ToString())[0];
                        InfoControl.TmpPaper.ProList[6].Add(tmpPro);
                        InfoControl.TmpPaper.score_pCompletion = pro.score;
                        break;
                    case ProblemType.ProgramFun:
                        tmpPro = InfoControl.OesData.FindFunProgramById(pro.id.ToString())[0];
                        InfoControl.TmpPaper.ProList[8].Add(tmpPro);
                        InfoControl.TmpPaper.score_pFunction = pro.score;
                        break;
                }
                tmpPro.problemId = pro.id;
                tmpPro.score = pro.score;
            }
        }

        /// <summary>
        ///设置题目
        /// </summary>
        /// <param name="type">题目类型</param>
        /// <param name="num">题号</param>
        /// <param name="ProID">题目ID</param>
        /// <param name="ProInfo">题目内容</param>
        public static void SetProblem(int type, int num, int ProID, string ProInfo)
        {
            if (type > 8)
            {
                InfoControl.TmpPaper.ProList[type - 3][num].problemId = ProID;
                InfoControl.TmpPaper.ProList[type - 3][num].problem = ProInfo;
            }
            else
            {
                InfoControl.TmpPaper.ProList[type][num].problemId = ProID;
                InfoControl.TmpPaper.ProList[type][num].problem = ProInfo;
            }
            if (type > 2)
            {
                PaperEditPanel.propanel.ProText.Text = ProInfo;
            }
            else
            {
                PaperEditPanel.ItemList[num].ItemText.Text = ProInfo;
            }
        }

        /// <summary>
        /// 删除题目
        /// </summary>
        /// <param name="type">题目类型</param>
        /// <param name="num">题号</param>
        public static void DelProblem(int type, int num)
        {
            if (type > 8)
            {
                InfoControl.TmpPaper.ProList[type - 3][num].problemId = -1;
            }
            else
            {
                InfoControl.TmpPaper.ProList[type][num].problemId = -1;
            }
            if (type > 2)
            {
                PaperEditPanel.propanel.ProText.Text = "-";
            }
            else
            {
                PaperEditPanel.ItemList[num].ItemText.Text = "-";
            }
        }

        #region 窗体逻辑控制
        private static LoginForm loginForm = null;
        public static LoginForm LoginForm
        {
            get
            {
                if (loginForm == null || loginForm.IsDisposed) { LoginForm = new LoginForm(); }
                return InfoControl.loginForm;
            }
            set { InfoControl.loginForm = value; }
        }

        private static MainForm mainForm = null;
        public static MainForm MainForm
        {
            get
            {
                if (mainForm == null || mainForm.IsDisposed) { MainForm = new MainForm(); }
                return InfoControl.mainForm;
            }
            set { InfoControl.mainForm = value; }
        }

        #endregion 窗体逻辑控制
    }
}
