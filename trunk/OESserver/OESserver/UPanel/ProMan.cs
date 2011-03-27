using System.Drawing;
using System.Windows.Forms;
using OES.UControl;
using System.Collections.Generic;
using OES.Properties;

namespace OES.UPanel
{
    public partial class ProMan : UserPanel
    {
        public ProList aProList;
        public ChptList aChptList;
        public static int ClWidth;
        public static int PlHeight;
        public static int TpHeight;
        public static int PlWidth;
        public static int BpHeight;
        
        public static bool isediting=false;//标识是否正在编辑题目

        private readonly List<Label> titleList = new List<Label>();

        public Panel bottomPanel = new Panel();
        public Panel titlePanel = new Panel();
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

        public ProMan()
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
            ProList.btnHeight = TpHeight;
            PlHeight = (int)(Height*0.9 - TpHeight);
            ProList.listWidth = (int)(PlWidth * 0.973);
            ProList.choWidth = (int)(PlWidth * 0.1);
            ProList.numWidth = (int)(PlWidth * 0.1);
            ProList.proWidth = (int)(PlWidth * 0.773);

            ProType=0;

            
            aChptList = new ChptList(this);
            aChptList.Size = new Size(ClWidth, Height);
            Controls.Add(aChptList);
            
            bottomPanel.SetBounds(ClWidth,(TpHeight+PlHeight), PlWidth, BpHeight);
            bottomPanel.BackColor = Color.Transparent;
            Controls.Add(bottomPanel);

            //底部按钮
            Button select = new Button();
            select.Height = 60;
            select.Width = 110;
            select.Location = new Point(30, 5);
            select.Text = "全部标记";
            select.ForeColor = Color.White;
            select.BackColor = Color.RoyalBlue;
            select.Font = new Font(new FontFamily("微软雅黑"), 13, FontStyle.Bold);
            select.TextAlign = ContentAlignment.MiddleCenter;
            bottomPanel.Controls.Add(select);
            select.FlatStyle = FlatStyle.Standard;
            select.MouseClick += new MouseEventHandler(select_MouseClick);

            Button cselect = new Button();
            cselect.Height = 60;
            cselect.Width = 110;
            cselect.Location = new Point(160, 5);
            cselect.Text = "取消全标";
            cselect.ForeColor = Color.White;
            cselect.BackColor = Color.RoyalBlue;
            cselect.Font = new Font(new FontFamily("微软雅黑"), 13, FontStyle.Bold);
            cselect.TextAlign = ContentAlignment.MiddleCenter;
            bottomPanel.Controls.Add(cselect);
            cselect.FlatStyle = FlatStyle.Standard;
            cselect.MouseClick += new MouseEventHandler(cselect_MouseClick);

            Button delete = new Button();
            delete.Height = 60;
            delete.Width = 110;
            delete.Location = new Point(290, 5);
            delete.Text = "删除标项";
            delete.ForeColor = Color.White;
            delete.BackColor = Color.RoyalBlue;
            delete.Font = new Font(new FontFamily("微软雅黑"), 13, FontStyle.Bold);
            delete.TextAlign = ContentAlignment.MiddleCenter;
            bottomPanel.Controls.Add(delete);
            delete.FlatStyle = FlatStyle.Standard;
            delete.MouseClick += new MouseEventHandler(delete_MouseClick);

            Button add = new Button();
            add.Height = 60;
            add.Width = 110;
            add.Location = new Point(420,5);
            add.Text = "添加题目";
            add.ForeColor = Color.White;
            add.BackColor = Color.RoyalBlue;
            add.Font = new Font(new FontFamily("微软雅黑"), 13, FontStyle.Bold);
            add.TextAlign = ContentAlignment.MiddleCenter;
            bottomPanel.Controls.Add(add);
            add.FlatStyle = FlatStyle.Standard;
            add.MouseClick += new MouseEventHandler(add_MouseClick);

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

            titleList[0].Text = "勾选";
            titleList[1].Text = "ID";
            titleList[2].Text = "题干";

            titleList[0].ForeColor = Color.IndianRed;
            titleList[1].ForeColor = Color.IndianRed;
            titleList[2].ForeColor = Color.IndianRed;

            titleList[0].Location = new Point(0, 0);
            titleList[1].Location = new Point(ProList.choWidth, 0);
            titleList[2].Location = new Point((ProList.choWidth + ProList.numWidth), 0);

            


            {
                aChoiceEdit.Hide();
                aChoiceEdit.Location = new Point(ClWidth,0);
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
           

            EditList.Add(aChoiceEdit);
        }

        void add_MouseClick(object sender, MouseEventArgs e)
        {
            newedit(ProType);
        }

        void delete_MouseClick(object sender, MouseEventArgs e)
        {
            delete();
            aChptList.newpl();
        }

        void cselect_MouseClick(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < aProList.acheckproList.Count; i++)
            {
                aProList.acheckproList[i].selected = false;
                aProList.checkList[i].BackgroundImage = Resources.circle_black;

            }
        }

        void select_MouseClick(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < aProList.acheckproList.Count; i++)
            {
                aProList.acheckproList[i].selected = true;
                aProList.checkList[i].BackgroundImage = Resources.circle_red;
            }
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

        public void delete()
        {
            for (int i = 0; i < aProList.acheckproList.Count; i++)
            {
                if (aProList.acheckproList[i].selected)
                {
                    switch (ProType)
                    { 
                        case 0:
                            InfoControl.OesData.DeleteChoiceById(aProList.acheckproList[i].proid);
                            aProList.acheckproList.RemoveAt(i);
                            break;
                        case 1:
                            InfoControl.OesData.DeleteCompletionById(aProList.acheckproList[i].proid);
                            aProList.acheckproList.RemoveAt(i);
                            break;
                        case 2:
                            InfoControl.OesData.DeleteTofById(aProList.acheckproList[i].proid);
                            aProList.acheckproList.RemoveAt(i);
                            break;
                        case 3:
                            InfoControl.OesData.DeleteOffice(aProList.acheckproList[i].proid,"2");
                            aProList.acheckproList.RemoveAt(i);
                            break;
                        case 4:
                            InfoControl.OesData.DeleteOffice(aProList.acheckproList[i].proid, "3");
                            aProList.acheckproList.RemoveAt(i);
                            break;
                        case 5:
                            InfoControl.OesData.DeleteOffice(aProList.acheckproList[i].proid, "1");
                            aProList.acheckproList.RemoveAt(i);
                            break;
                        case 6:
                            InfoControl.OesData.DeleteCompletionModificationProgram(aProList.acheckproList[i].proid, "1");
                            aProList.acheckproList.RemoveAt(i);
                            break;
                        case 7:
                            InfoControl.OesData.DeleteCompletionModificationProgram(aProList.acheckproList[i].proid, "2");
                            aProList.acheckproList.RemoveAt(i);
                            break;
                        case 8:
                            InfoControl.OesData.DeleteFunProgram(aProList.acheckproList[i].proid);
                            aProList.acheckproList.RemoveAt(i);
                            break;
                        case 9:
                            InfoControl.OesData.DeleteCompletionModificationProgram(aProList.acheckproList[i].proid, "1");
                            aProList.acheckproList.RemoveAt(i);
                            break;
                        case 10:
                            InfoControl.OesData.DeleteCompletionModificationProgram(aProList.acheckproList[i].proid, "2");
                            aProList.acheckproList.RemoveAt(i);
                            break;
                        case 11:
                            InfoControl.OesData.DeleteFunProgram(aProList.acheckproList[i].proid);
                            aProList.acheckproList.RemoveAt(i);
                            break;
                        default:
                            break;
                    }
                    
                }
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
                    aChptList = new ChptList(this);
                    aChptList.Size = new Size(ClWidth, Height);
                    Controls.Add(aChptList);
                    aChptList.Show();
                    HideList();
                    this.Visible = true;
                }
                else
                {
                    aChptList.Hide();
                    aProList = new ProList(this);
                    aProList.SetBounds(ClWidth, TpHeight, PlWidth, PlHeight);

                    aChptList.newpl();
                    HideList();
                    Controls.Add(aProList);
                    aProList.Show();
                    this.Visible = true;
                }
            
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