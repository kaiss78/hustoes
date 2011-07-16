using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using OES.Properties;
using OES.UPanel;
using OES.Model;

namespace OES.UControl
{
    public partial class ProListCho : UserControl
    {
 
        private readonly List<Button> subPanel = new List<Button>();
        private readonly List<int> subPanelStatus = new List<int>();
        private readonly List<Label> titleList = new List<Label>();
        public List<Button> checkList = new List<Button>();
        public List<checkCho> acheckproList = new List<checkCho>();
           
        public static int btnHeight;
        public static int choWidth;
        public static int count = 10;
        public static int listWidth;

        public string currentProNo;//当前题号
        public string nextProNo;//下题题号
        public int chptNo;//选择的章节号
        public Panel mainPanel;
        public static int numWidth;
        public int page = 1;
        public static int proWidth;

        public int totalpage = 1;
        ProManCho aProMan;
        public static string click_proid = "";


        public ProListCho(ProManCho pmc)
        {
            InitializeComponent();
            aProMan=pmc;
        }



        private void ProList_Resize(object sender, EventArgs e)
        {
            Controls.Clear();
            mainPanel = new Panel();
            mainPanel.Height = Height;
            mainPanel.Width = Width;
            Controls.Add(mainPanel);

            chptNo = Convert.ToInt32(ChptListCho.click_num);

            totalpage = ((ChptListCho.pro_num / count) + 1);
            
            mainPanel.AutoScroll = true;
            

            //判断动态生成题目列表
            for (int i = 0; i < ChptListCho.pro_num; i++)
            {
                //勾选按钮生成
                Button checkButton = new Button();
                checkButton.Height = btnHeight;
                checkButton.Width = choWidth;
                checkButton.Location = new Point(0, (btnHeight * i));
                checkButton.Font = new Font(new FontFamily("微软雅黑"), 20, FontStyle.Bold);
                checkButton.TextAlign = ContentAlignment.MiddleCenter;
                checkButton.BackgroundImage = null;
                checkButton.BackgroundImageLayout = ImageLayout.Stretch;
                checkButton.Tag = i;

                Label templ2 = new Label();
                templ2.Height = btnHeight;
                templ2.ForeColor = Color.White;
                templ2.BackColor = Color.Transparent;
                templ2.Tag = ChptListCho.choiceproL[i].num;
                templ2.Font = new Font(new FontFamily("微软雅黑"), 20, FontStyle.Bold);
                templ2.TextAlign = ContentAlignment.MiddleCenter;
                templ2.AutoSize = false;


                Label templ3 = new Label();
                templ3.Height = btnHeight;
                templ3.ForeColor = Color.White;
                templ3.BackColor = Color.Transparent;
                templ3.Tag = ChptListCho.choiceproL[i].num;
                templ3.Font = new Font(new FontFamily("微软雅黑"), 15, FontStyle.Bold);
                templ3.TextAlign = ContentAlignment.MiddleCenter;
                templ3.AutoSize = false;


                templ2.Location = new Point(0, 0);
                templ2.Width = numWidth;
                templ2.Text = ChptListCho.choiceproL[i].num;

                templ3.Location = new Point(numWidth, 0);
                templ3.Width = proWidth;
                templ3.Text = ChptListCho.choiceproL[i].pro;

                Button temp = new Button();
                temp.Width = (listWidth-choWidth);
                temp.Height = btnHeight;
                temp.Tag = ChptListCho.choiceproL[i].num;
                temp.Location = new Point(choWidth, (btnHeight * i));
                temp.BackgroundImage = Resources.btnmaobi;
                temp.BackgroundImageLayout = ImageLayout.Stretch;
                mainPanel.Controls.Add(temp);
                subPanel.Add(temp);
                subPanelStatus.Add(0);
                temp.FlatStyle = FlatStyle.Popup;
                temp.Controls.Add(templ2);
                temp.Controls.Add(templ3);

                mainPanel.Controls.Add(checkButton);
                checkList.Add(checkButton);
                checkCho acheck = new checkCho(false, ChptListCho.choiceproL[i].num);
                acheckproList.Add(acheck);
                aProMan.checkProNoList[aProMan.ProType][chptNo].Add("-1");
                                      
                temp.MouseClick +=new MouseEventHandler(temp_MouseClick);
                templ2.MouseClick += new MouseEventHandler(templ2_MouseClick);
                templ3.MouseClick += new MouseEventHandler(templ3_MouseClick);
                checkButton.MouseClick += new MouseEventHandler(checkButton_MouseClick);
                 
            }

        }
        
        //checkbutton加载已选题号列表,遍历查找，此处可优化
        void loadchecklist(List<Choice> pronolist)
        {
            aProMan.NextNoCon.Text = InfoControl.GetProNum(aProMan.ProType).ToString();
            for (int i = 0; i < acheckproList.Count; i++)
            {
                checkList[i].Text = "";
            }
            for (int i = 0; i < acheckproList.Count; i++)
            {
                if (InfoControl.TmpPaper.choice[i].problemId.ToString() == acheckproList[i].proid)
                {
                    checkList[i].Text = (i + 1).ToString();
                }
            }
        }

        //勾选题目进试卷的checkbutton事件
        void checkButton_MouseClick(object sender, MouseEventArgs e)
        {
            if (aProMan.checkProNoList[aProMan.ProType][chptNo][(int)((Button)sender).Tag] != "-1")
            {
                loadProNoifSel(sender);       
            }
            else
            {
                loadProNoifNoSel(sender);               
            }
        }

        //加载已存的已勾选题号，在checkbutton列上显示
        public void loadAllProNo()
        { 
            for (int i = 0; i < acheckproList.Count; i++)
            {
                if (aProMan.checkProNoList[aProMan.ProType][chptNo][i] != "-1")
                {
                    checkList[i].Text = aProMan.checkProNoList[aProMan.ProType][chptNo][i];
                }
            }
            nextProNo = InfoControl.GetProNum(aProMan.ProType).ToString();
            if (nextProNo != "-1")
            {
                aProMan.NextNoCon.Text = nextProNo;
            }
            else
            {
                aProMan.NextNoCon.Text = currentProNo;
            }
        }


        //点选已亮的checkbutton时的加载事件
        public void loadProNoifSel(object butn)
        {
            InfoControl.DelProblem(aProMan.ProType, Convert.ToInt32(((Button)butn).Text) - 1);
            ((Button)butn).Text = "";
            aProMan.checkProNoList[aProMan.ProType][chptNo][(int)((Button)butn).Tag] = "-1";
            nextProNo = InfoControl.GetProNum(aProMan.ProType).ToString();
            aProMan.NextNoCon.Text = nextProNo;
        }

        //点选未亮的checkbutton时的加载事件
        public void loadProNoifNoSel(object butn)
        {
            if (nextProNo != "")
            {
                currentProNo = nextProNo;
                aProMan.CurrentNoCon.Text = currentProNo;
                ((Button)butn).Text = aProMan.CurrentNoCon.Text;


                InfoControl.Value = -1;
                InfoControl.SetProblem(aProMan.ProType, Convert.ToInt32((aProMan.CurrentNoCon.Text)) - 1, 
                    Convert.ToInt32((acheckproList[(int)((Button)butn).Tag].proid)),
                    ChptListCho.choiceproL[(int)((Button)butn).Tag].pro);
                aProMan.checkProNoList[aProMan.ProType][chptNo][(int)((Button)butn).Tag] = currentProNo;
                nextProNo = InfoControl.GetProNum(aProMan.ProType).ToString();
                if (nextProNo != "-1")
                {
                    aProMan.checkProNoList[aProMan.ProType][chptNo][(int)((Button)butn).Tag] = currentProNo;
                    aProMan.NextNoCon.Text = nextProNo;
                }
                else
                {
                    nextProNo = "";
                    aProMan.NextNoCon.Text = "";
                }
            }
        }


        void temp_MouseClick(object sender, MouseEventArgs e)
        {
            this.Hide();
            aProMan.bottomPanel.Hide();
            aProMan.titlePanel.Hide();
            change(Convert.ToInt32(((Button)sender).Tag),aProMan.ProType);

        }

        void templ3_MouseClick(object sender, MouseEventArgs e)
        {
            this.Hide();
            aProMan.bottomPanel.Hide();
            aProMan.titlePanel.Hide();
            change(Convert.ToInt32(((Label)sender).Tag), aProMan.ProType);
        }

        void templ2_MouseClick(object sender, MouseEventArgs e)
        {
            this.Hide();
            aProMan.bottomPanel.Hide();
            aProMan.titlePanel.Hide();
            change(Convert.ToInt32(((Label)sender).Tag), aProMan.ProType);
        }

        //调用加载函数，控制控件隐藏现实的转换
        void change(int id,int pt)
        {
            click_proid = Convert.ToString(id);
            loadpro(id, pt);
            aProMan.EditList[pt].Show();
            ProMan.isediting = true;
            for (int i=0; i < 12 && i != pt; i++)
            {
                aProMan.EditList[i].Hide();
            }
        }

        
        //加载函数，加载问题编辑界面的原始数据
        void loadpro(int id,int pt)
        {
            
            switch (pt)
            {
                case 0:
                    aProMan.aChoiceEdit.isnew = false;
                    aProMan.aChoiceEdit.fill(InfoControl.OesData.FindChoiceById(id.ToString()));
                    break;
                case 1:
                    aProMan.aCompletionEdit.isnew = false;
                    aProMan.aCompletionEdit.fill(InfoControl.OesData.FindCompletionById(id.ToString()));
                    break;
                case 2:
                    aProMan.aJudgeEdit.isnew = false;
                    aProMan.aJudgeEdit.fill(InfoControl.OesData.FindTofById(id.ToString()));
                    break;
                case 3:
                    aProMan.aOfficeExcelEdit.isnew = false;
                    aProMan.aOfficeExcelEdit.fill(InfoControl.OesData.FindOfficeExcelById(id.ToString()));
                    break;
                case 4:
                    aProMan.aOfficePowerpointEdit.isnew = false;
                    aProMan.aOfficePowerpointEdit.fill(InfoControl.OesData.FindOfficePowerPointById(id.ToString()));
                    break;
                case 5:
                    aProMan.aOfficeWordEdit.isnew = false;
                    aProMan.aOfficeWordEdit.fill(InfoControl.OesData.FindOfficeWordById(id.ToString()));
                    break;
                case 6:
                    aProMan.aCCompletionEdit.isnew = false;
                    aProMan.aCCompletionEdit.fill(InfoControl.OesData.FindCompletionProgramById(id.ToString()));
                    break;
                case 7:
                    aProMan.aCModifEdit.isnew = false;
                    aProMan.aCModifEdit.fill(InfoControl.OesData.FindModificationProgramById(id.ToString()));
                    break;
                case 8:
                    aProMan.aCFuctionEdit.isnew = false;
                    aProMan.aCFuctionEdit.fill(InfoControl.OesData.FindFunProgramById(id.ToString()));
                    break;
                case 9:
                    aProMan.aCppCompletionEdit.isnew = false;
                    aProMan.aCppCompletionEdit.fill(InfoControl.OesData.FindCompletionProgramById(id.ToString()));
                    break;
                case 10:
                    aProMan.aCppModifEdit.isnew = false;
                    aProMan.aCppModifEdit.fill(InfoControl.OesData.FindModificationProgramById(id.ToString()));
                    break;
                case 11:
                    aProMan.aCppFuctionEdit.isnew = false;
                    aProMan.aCppFuctionEdit.fill(InfoControl.OesData.FindFunProgramById(id.ToString()));
                    break;
                default:
                    break;
            }
        }

        #region Nested type: choicepro

        public class checkCho
        {
            public bool selected;
            public string proid,proNo;

            public checkCho(bool s, string p)
            {
                selected = s;
                proid = p;
            }
        }

        #endregion

        
    }
}