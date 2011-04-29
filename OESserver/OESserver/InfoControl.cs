using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OES.Model;
using OES.UPanel;

namespace OES
{
    public class InfoControl
    {        
        public static int WordID = 0;
        public static int PPTID = 0;
        public static int ExcelID = 0;
        public static int PCompletionID = 0;
        public static int PJudgeID = 0;
        public static int PModifID = 0;
        public static int Value = 0;

        private static OESData oesData = null;
        public static OESData OesData
        {
            get
            {
                if (oesData == null) { oesData = new OESData(); }
                return InfoControl.oesData;
            }
            set { InfoControl.oesData = value; }
        }

        private static Teacher teacher=null;
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
                if (paper == null){paper = new Paper();}
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
            if (InfoControl.Value  == -1)
            {
                for (int i = 0; i < InfoControl.TmpPaper.ProList[type].Count; i++)
                {
                    if (InfoControl.TmpPaper.ProList[type][i].problemId == -1)
                        return (i + 1);
                }                
            }
            return tmp;
        }

        /// <summary>
        ///设置题目
        /// </summary>
        /// <param name="type">题目类型</param>
        /// <param name="num">题号</param>
        /// <param name="ProID">题目ID</param>
        /// <param name="ProInfo">题目内容</param>
        public static void SetProblem(int type,int num,int ProID,string ProInfo)
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
                InfoControl.TmpPaper.ProList[type-3][num].problemId = -1;                
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
                if (mainForm == null || mainForm.IsDisposed) {MainForm = new MainForm();}
                return InfoControl.mainForm;
            }
            set { InfoControl.mainForm = value; }
        }

        #endregion 窗体逻辑控制
    }
}
