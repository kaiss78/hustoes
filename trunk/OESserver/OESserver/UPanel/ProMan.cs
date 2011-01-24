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
        private readonly List<Label> titleList = new List<Label>();
        public Panel bottomPanel = new Panel();
        public Panel titlePanel = new Panel();
        public int ProType;
        public List<UserControl> EditList=new List<UserControl>();
        public ChoiceEdit aChoiceEdit;
        public CompletionEdit aCompletionEdit;
        public JudgeEdit aJudgeEdit;
        public OfficeExcelEdit aOfficeExcelEdit = new OfficeExcelEdit();
        public OfficePowerpointEdit aOfficePowerpointEdit = new OfficePowerpointEdit();
        public OfficeWordEdit aOfficeWordEdit = new OfficeWordEdit();
        public CCompletionEdit aCCompletionEdit = new CCompletionEdit();
        public CModifEdit aCModifEdit = new CModifEdit();
        public CFuctionEdit aCFuctionEdit = new CFuctionEdit();
        public CppCompletionEdit aCppCompletionEdit = new CppCompletionEdit();
        public CppModifEdit aCppModifEdit = new CppModifEdit();
        public CppFuctionEdit aCppFuctionEdit = new CppFuctionEdit();

        public ProMan()
        {
            InitializeComponent();

            aChoiceEdit = new ChoiceEdit(this);
            aCompletionEdit = new CompletionEdit(this);
            aJudgeEdit = new JudgeEdit(this);
            
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
            select.ForeColor = Color.Blue;
            select.BackColor = Color.Transparent;
            select.Font = new Font(new FontFamily("微软雅黑"), 11, FontStyle.Bold);
            select.TextAlign = ContentAlignment.MiddleCenter;
            bottomPanel.Controls.Add(select);
            select.FlatStyle = FlatStyle.Popup;
            select.MouseClick += new MouseEventHandler(select_MouseClick);

            Button cselect = new Button();
            cselect.Height = 60;
            cselect.Width = 110;
            cselect.Location = new Point(160, 5);
            cselect.Text = "取消全部标记";
            cselect.ForeColor = Color.Blue;
            cselect.BackColor = Color.Transparent;
            cselect.Font = new Font(new FontFamily("微软雅黑"), 11, FontStyle.Bold);
            cselect.TextAlign = ContentAlignment.MiddleCenter;
            bottomPanel.Controls.Add(cselect);
            cselect.FlatStyle = FlatStyle.Popup;
            cselect.MouseClick += new MouseEventHandler(cselect_MouseClick);

            Button delete = new Button();
            delete.Height = 60;
            delete.Width = 110;
            delete.Location = new Point(290, 5);
            delete.Text = "删除标记项";
            delete.ForeColor = Color.Blue;
            delete.BackColor = Color.Transparent;
            delete.Font = new Font(new FontFamily("微软雅黑"), 11, FontStyle.Bold);
            delete.TextAlign = ContentAlignment.MiddleCenter;
            bottomPanel.Controls.Add(delete);
            delete.FlatStyle = FlatStyle.Popup;
            delete.MouseClick += new MouseEventHandler(delete_MouseClick);

            Button add = new Button();
            add.Height = 60;
            add.Width = 110;
            add.Location = new Point(420,5);
            add.Text = "添加题目";
            add.ForeColor = Color.Blue;
            add.BackColor = Color.Transparent;
            add.Font = new Font(new FontFamily("微软雅黑"), 11, FontStyle.Bold);
            add.TextAlign = ContentAlignment.MiddleCenter;
            bottomPanel.Controls.Add(add);
            add.FlatStyle = FlatStyle.Popup;
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
                templt.Font = new Font(new FontFamily("微软雅黑"), 11, FontStyle.Bold);
                templt.TextAlign = ContentAlignment.MiddleCenter;
                titleList.Add(templt);
                titlePanel.Controls.Add(templt);
            }
            titleList[0].Width = ProList.choWidth;
            titleList[1].Width = ProList.numWidth;
            titleList[2].Width = ProList.proWidth;

            titleList[0].Text = "勾选";
            titleList[1].Text = "题号";
            titleList[2].Text = "题干";

            titleList[0].ForeColor = Color.Blue;
            titleList[1].ForeColor = Color.Blue;
            titleList[2].ForeColor = Color.Blue;

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
            aProList.acheckproList.Clear();
            for (int i = 0; i < aProList.acheckproList.Count; i++)
            {
                aProList.acheckproList[i].selected = false;
                aProList.checkList[i].BackgroundImage = Resources.circle_black;

            }
        }

        void select_MouseClick(object sender, MouseEventArgs e)
        {
            aProList.acheckproList.Clear();
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
            }
            EditList[pt].Show();
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
                        default:
                            break;
                    }
                    
                }
            }
        }

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
                Controls.Add(aProList);
                HideList();
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