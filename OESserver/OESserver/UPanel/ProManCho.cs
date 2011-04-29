using System.Drawing;
using System.Windows.Forms;
using OES.UControl;
using System.Collections.Generic;
using OES.Properties;
using System;

namespace OES.UPanel
{
    public partial class ProManCho : ProMan
    {
        public ProListCho aProList;
        public ChptListCho aChptList;
        public static int ClWidth;
        public static int PlHeight;
        public static int TpHeight;
        public static int PlWidth;
        public static int BpHeight;

        public List<List<List<String>>> checkProNoList = new List<List<List<String>>>();
        
        public static bool isediting=false;//标识是否正在编辑题目

        private readonly List<Label> titleList = new List<Label>();

        public Panel bottomPanel = new Panel();
        public Panel titlePanel = new Panel();
        public Label CurrentNoCon;
        public Label NextNoCon;
        public int ProType;
        public List<UserControl> EditList=new List<UserControl>();
        public ChoiceEdit aChoiceEdit;
        public CompletionEdit aCompletionEdit;
        public JudgeEdit aJudgeEdit;
        public OfficeExcelEdit aOfficeExcelEdit;
        public OfficePowerpointEdit aOfficePowerpointEdit;
        public OfficeWordEdit aOfficeWordEdit;
        public CCompletionEdit aCCompletionEdit;
        public CModifEdit aCModifEdit;
        public CFuctionEdit aCFuctionEdit;
        public CppCompletionEdit aCppCompletionEdit;
        public CppModifEdit aCppModifEdit;
        public CppFuctionEdit aCppFuctionEdit ;

        public ProManCho()
        {
            InitializeComponent();

            aChoiceEdit = new ChoiceEdit(this);
            aCompletionEdit = new CompletionEdit(this);
            aJudgeEdit = new JudgeEdit(this);
            aOfficeExcelEdit = new OfficeExcelEdit(this);
            aOfficePowerpointEdit = new OfficePowerpointEdit(this);
            aOfficeWordEdit = new OfficeWordEdit(this);
            aCCompletionEdit = new CCompletionEdit(this);
            aCModifEdit = new CModifEdit(this);
            aCFuctionEdit = new CFuctionEdit(this);
            aCppCompletionEdit = new CppCompletionEdit(this);
            aCppModifEdit = new CppModifEdit(this);
            aCppFuctionEdit = new CppFuctionEdit(this);

            ClWidth = (int)(Width * 0.2);
            PlWidth = (int)(Width * 0.8);
            
            BpHeight = (int)(Height * 0.1);
            TpHeight = (int)((Height*0.9)/ ProList.count);  
            PlHeight = (int)(Height*0.9 - TpHeight);
            ProListCho.btnHeight = TpHeight;
            ProListCho.listWidth = (int)(PlWidth * 0.973);
            ProListCho.choWidth = (int)(PlWidth * 0.1);
            ProListCho.numWidth = (int)(PlWidth * 0.1);
            ProListCho.proWidth = (int)(PlWidth * 0.773);

            ProType=0;


            aChptList = new ChptListCho(this);
            aChptList.Size = new Size(ClWidth, Height);
            Controls.Add(aChptList);
            
            bottomPanel.SetBounds(ClWidth,(TpHeight+PlHeight), PlWidth, BpHeight);
            bottomPanel.BackColor = Color.Transparent;
            Controls.Add(bottomPanel);


            titlePanel.SetBounds(ClWidth,0, PlWidth,TpHeight);
            titlePanel.BackColor = Color.Transparent;
            Controls.Add(titlePanel);
            //顶部panel设置lable
            for (int i = 0; i < 3; i++)
            {
                var templt = new Label();
                templt.Height = ProList.btnHeight;
                templt.ForeColor = Color.White;
                templt.BackColor = Color.Transparent;
                templt.Font = new Font(new FontFamily("微软雅黑"), 15, FontStyle.Bold);
                templt.TextAlign = ContentAlignment.MiddleCenter;
                titleList.Add(templt);
                titlePanel.Controls.Add(templt);
            }
            titleList[0].Width = ProList.choWidth;
            titleList[1].Width = ProList.numWidth;
            titleList[2].Width = ProList.proWidth;

            titleList[0].Text = "选题";
            titleList[1].Text = "ID";
            titleList[2].Text = "题干";

            titleList[0].ForeColor = Color.White;
            titleList[1].ForeColor = Color.White;
            titleList[2].ForeColor = Color.White;

            titleList[0].Location = new Point(0, 0);
            titleList[1].Location = new Point(ProList.choWidth, 0);
            titleList[2].Location = new Point((ProList.choWidth + ProList.numWidth), 0);

            //初始化创建checkProNoList12项
            for (int i = 0; i < 13; i++)
            { 
                List<List<String>> temp =new List<List<String>>();
                for (int j = 0; j < 50; j++)
                {
                    List<String> subtemp = new List<String>();
                    temp.Add(subtemp);
                }
                    checkProNoList.Add(temp);
            }

            {
                aChoiceEdit.Hide();
                aChoiceEdit.Location = new Point(ClWidth, 0);
                this.Controls.Add(aChoiceEdit);
                EditList.Add(aChoiceEdit);

                aCompletionEdit.Hide();
                aCompletionEdit.Location = new Point(ClWidth, 0);
                this.Controls.Add(aCompletionEdit);
                EditList.Add(aCompletionEdit);

                aJudgeEdit.Hide();
                aJudgeEdit.Location = new Point(ClWidth, 0);
                this.Controls.Add(aJudgeEdit);
                EditList.Add(aJudgeEdit);

                aOfficeExcelEdit.Hide();
                aOfficeExcelEdit.Location = new Point(ClWidth, 0);
                this.Controls.Add(aOfficeExcelEdit);
                EditList.Add(aOfficeExcelEdit);

                aOfficePowerpointEdit.Hide();
                aOfficePowerpointEdit.Location = new Point(ClWidth, 0);
                this.Controls.Add(aOfficePowerpointEdit);
                EditList.Add(aOfficePowerpointEdit);

                aOfficeWordEdit.Hide();
                aOfficeWordEdit.Location = new Point(ClWidth, 0);
                this.Controls.Add(aOfficeWordEdit);
                EditList.Add(aOfficeWordEdit);

                aCCompletionEdit.Hide();
                aCCompletionEdit.Location = new Point(ClWidth, 0);
                this.Controls.Add(aCCompletionEdit);
                EditList.Add(aCCompletionEdit);

                aCModifEdit.Hide();
                aCModifEdit.Location = new Point(ClWidth, 0);
                this.Controls.Add(aCModifEdit);
                EditList.Add(aCModifEdit);

                aCFuctionEdit.Hide();
                aCFuctionEdit.Location = new Point(ClWidth, 0);
                this.Controls.Add(aCFuctionEdit);
                EditList.Add(aCFuctionEdit);

                aCppCompletionEdit.Hide();
                aCppCompletionEdit.Location = new Point(ClWidth, 0);
                this.Controls.Add(aCppCompletionEdit);
                EditList.Add(aCppCompletionEdit);

                aCppModifEdit.Hide();
                aCppModifEdit.Location = new Point(ClWidth, 0);
                this.Controls.Add(aCppModifEdit);
                EditList.Add(aCppModifEdit);

                aCppFuctionEdit.Hide();
                aCppFuctionEdit.Location = new Point(ClWidth, 0);
                this.Controls.Add(aCppFuctionEdit);
                EditList.Add(aCppFuctionEdit);



            }
           

            //底部panel显示当前题号
            Label CurrentNo = new Label();
            CurrentNo.Height = 40;
            CurrentNo.Width = 100;
            CurrentNo.Location = new Point(15, 10);
            CurrentNo.Text = "当前序号";
            CurrentNo.ForeColor = Color.White;
            CurrentNo.BackColor = Color.RoyalBlue;
            CurrentNo.Font = new Font(new FontFamily("微软雅黑"), 13, FontStyle.Bold);
            CurrentNo.TextAlign = ContentAlignment.MiddleCenter;
            bottomPanel.Controls.Add(CurrentNo);
            CurrentNo.FlatStyle = FlatStyle.Standard;

            CurrentNoCon = new Label();
            CurrentNoCon.Height = 40;
            CurrentNoCon.Width = 100;
            CurrentNoCon.Location = new Point(130, 10);
            CurrentNoCon.Text = "";
            CurrentNoCon.ForeColor = Color.White;
            CurrentNoCon.BackColor = Color.RoyalBlue;
            CurrentNoCon.Font = new Font(new FontFamily("微软雅黑"), 13, FontStyle.Bold);
            CurrentNoCon.TextAlign = ContentAlignment.MiddleCenter;
            bottomPanel.Controls.Add(CurrentNoCon);
            CurrentNoCon.FlatStyle = FlatStyle.Standard;

            Label NextNo = new Label();
            NextNo.Height = 40;
            NextNo.Width = 100;
            NextNo.Location = new Point(245, 10);
            NextNo.Text = "下题序号";
            NextNo.ForeColor = Color.White;
            NextNo.BackColor = Color.RoyalBlue;
            NextNo.Font = new Font(new FontFamily("微软雅黑"), 13, FontStyle.Bold);
            NextNo.TextAlign = ContentAlignment.MiddleCenter;
            bottomPanel.Controls.Add(NextNo);
            NextNo.FlatStyle = FlatStyle.Standard;

            NextNoCon = new Label();
            NextNoCon.Height = 40;
            NextNoCon.Width = 100;
            NextNoCon.Location = new Point(360, 10);
            NextNoCon.Text = "";
            NextNoCon.ForeColor = Color.White;
            NextNoCon.BackColor = Color.RoyalBlue;
            NextNoCon.Font = new Font(new FontFamily("微软雅黑"), 13, FontStyle.Bold);
            NextNoCon.TextAlign = ContentAlignment.MiddleCenter;
            bottomPanel.Controls.Add(NextNoCon);
            NextNoCon.FlatStyle = FlatStyle.Standard;

            //底部panel返回按钮
            Button backtoPlp = new Button();
            backtoPlp.Height = 40;
            backtoPlp.Width = 100;
            backtoPlp.Location = new Point(475, 10);
            backtoPlp.Text = "返回组题";
            backtoPlp.ForeColor = Color.White;
            backtoPlp.BackColor = Color.RoyalBlue;
            backtoPlp.Font = new Font(new FontFamily("微软雅黑"), 13, FontStyle.Bold);
            backtoPlp.TextAlign = ContentAlignment.MiddleCenter;
            bottomPanel.Controls.Add(backtoPlp);
            backtoPlp.FlatStyle = FlatStyle.Standard;
            backtoPlp.MouseClick += new MouseEventHandler(backtoPlp_MouseClick);
        }

        void backtoPlp_MouseClick(object sender, MouseEventArgs e)
        {
            this.Hide();
            HideTBPanelCho();
            PanelControl.ReturnToPaper();
        }

        public void HideTBPanelCho()
        {
            titlePanel.Hide();
            bottomPanel.Hide();
        }

        public void ShowTBPanelCho()
        {
            titlePanel.Show();
            bottomPanel.Show();
        }

        public void newedit(int pt)
        {
            
            aProList.Hide();
            bottomPanel.Hide();
            titlePanel.Hide();

            switch (pt)
            {
                case 0:
                    aChoiceEdit.Dispose();
                    aChoiceEdit = new ChoiceEdit(this);
                    aChoiceEdit.Location = new Point(ClWidth, 0);
                    this.Controls.Add(aChoiceEdit);
                    EditList[pt]=aChoiceEdit;
                    aChoiceEdit.isnew = true;
                    break;
                case 1:
                    aCompletionEdit.Dispose();
                    aCompletionEdit = new CompletionEdit(this);
                    aCompletionEdit.Location = new Point(ClWidth, 0);
                    this.Controls.Add(aCompletionEdit);
                    EditList[pt] = aCompletionEdit;
                    aCompletionEdit.isnew = true;
                    break;
                case 2:
                    aJudgeEdit.Dispose();
                    aJudgeEdit = new JudgeEdit(this);
                    aJudgeEdit.Location = new Point(ClWidth, 0);
                    this.Controls.Add(aJudgeEdit);
                    EditList[pt] = aJudgeEdit;
                    aJudgeEdit.isnew = true;
                    break;
                case 3:
                    aOfficeExcelEdit.Dispose();
                    aOfficeExcelEdit = new OfficeExcelEdit(this);
                    aOfficeExcelEdit.Location = new Point(ClWidth, 0);
                    this.Controls.Add(aOfficeExcelEdit);
                    EditList[pt] = aOfficeExcelEdit;
                    aOfficeExcelEdit.isnew = true;
                    break;
                case 4:
                    aOfficePowerpointEdit.Dispose();
                    aOfficePowerpointEdit = new OfficePowerpointEdit(this);
                    aOfficePowerpointEdit.Location = new Point(ClWidth, 0);
                    this.Controls.Add(aOfficePowerpointEdit);
                    EditList[pt] = aOfficePowerpointEdit;
                    aOfficePowerpointEdit.isnew = true;
                    break;
                case 5:
                    aOfficeWordEdit.Dispose();
                    aOfficeWordEdit = new OfficeWordEdit(this);
                    aOfficeWordEdit.Location = new Point(ClWidth, 0);
                    this.Controls.Add(aOfficeWordEdit);
                    EditList[pt] = aOfficeWordEdit;
                    aOfficeWordEdit.isnew = true;
                    break;
                case 6:
                    aCCompletionEdit.Dispose();
                    aCCompletionEdit = new CCompletionEdit(this);
                    aCCompletionEdit.Location = new Point(ClWidth, 0);
                    this.Controls.Add(aCCompletionEdit);
                    EditList[pt] = aCCompletionEdit;
                    aCCompletionEdit.isnew = true;
                    break;
                case 7:
                    aCModifEdit.Dispose();
                    aCModifEdit = new CModifEdit(this);
                    aCModifEdit.Location = new Point(ClWidth, 0);
                    this.Controls.Add(aCModifEdit);
                    EditList[pt] = aCModifEdit;
                    aCModifEdit.isnew = true;
                    break;
                case 8:
                    aCFuctionEdit.Dispose();
                    aCFuctionEdit = new CFuctionEdit(this);
                    aCFuctionEdit.Location = new Point(ClWidth, 0);
                    this.Controls.Add(aCFuctionEdit);
                    EditList[pt] = aCFuctionEdit;
                    aCFuctionEdit.isnew = true;
                    break;
                case 9:
                    aCppCompletionEdit.Dispose();
                    aCppCompletionEdit = new CppCompletionEdit(this);
                    aCppCompletionEdit.Location = new Point(ClWidth, 0);
                    this.Controls.Add(aCppCompletionEdit);
                    EditList[pt] = aCppCompletionEdit;
                    aCppCompletionEdit.isnew = true;
                    break;
                case 10:
                    aCppModifEdit.Dispose();
                    aCppModifEdit = new CppModifEdit(this);
                    aCppModifEdit.Location = new Point(ClWidth, 0);
                    this.Controls.Add(aCppModifEdit);
                    EditList[pt] = aCppModifEdit;
                    aCppModifEdit.isnew = true;
                    break;
                case 11:
                    aCppFuctionEdit.Dispose();
                    aCppFuctionEdit = new CppFuctionEdit(this);
                    aCppFuctionEdit.Location = new Point(ClWidth, 0);
                    this.Controls.Add(aCppFuctionEdit);
                    EditList[pt] = aCppFuctionEdit;
                    aCppFuctionEdit.isnew = true;
                    break;
            }
            EditList[pt].Show();
            isediting = true;
            for (int i = 0; i < 12 && i != pt; i++)
            {
                EditList[i].Hide();
            }

            
        }

 
        //从题型panel传入的题型作处理，分0,1,2有章节，其余没有
        override public void ReLoad(int x)
        {
            
                ProType = x;
                if (Controls.Contains(aProList))
                {
                    aProList.Dispose();
                }
                if (ProType < 3)
                {
                    aChptList.Dispose();
                    aChptList = new ChptListCho(this);
                    aChptList.Size = new Size(ClWidth, Height);
                    Controls.Add(aChptList);
                    aChptList.Show();
                    ShowTBPanel();
                    HideList();
                    this.Visible = true;
                }
                else
                {
                    aChptList.Hide();
                    aProList = new ProListCho(this);
                    aProList.SetBounds(ClWidth, TpHeight, PlWidth, PlHeight);

                    aChptList.newpl();
                    ShowTBPanel();
                    HideList();
                    Controls.Add(aProList);
                    aProList.Show();
                    this.Visible = true;
                }
            
        }

        public void HideTBPanel()
        {
            titlePanel.Hide();
            bottomPanel.Hide();
        }

        public void ShowTBPanel()
        {
            titlePanel.Show();
            bottomPanel.Show();
        }

        public void HideList()
        {
            for (int i = 0; i < 12; i++)
            {
                EditList[i].Hide();
            }
        }
    }
}