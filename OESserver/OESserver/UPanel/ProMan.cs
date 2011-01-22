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
        private readonly int ClWidth;
        private readonly int PlHeight;
        private readonly int PlWidth;
        private readonly int BpHeight;
        private bool selectall=false;
        public Panel bottomPanel = new Panel();
        public int ProType;
        public List<UserControl> EditList=new List<UserControl>();
        public ChoiceEdit aChoiceEdit;
        public CompletionEdit aCompletionEdit;
        public JudgeEdit aJudgeEdit = new JudgeEdit();
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
            
            ClWidth = (int)(Width * 0.2);
            PlWidth = (int)(Width * 0.8);
            PlHeight = (int)(Height * 0.9);
            BpHeight = (int)(Height * 0.9);

            ProType=0;

            
            aChptList = new ChptList(this);
            aChptList.Size = new Size(ClWidth, Height);
            Controls.Add(aChptList);
            aProList = new ProList(this);
            aProList.SetBounds(ClWidth, 0, PlWidth, PlHeight);
            Controls.Add(aProList);
            bottomPanel.SetBounds(ClWidth, PlHeight, PlWidth, BpHeight);
            this.Controls.Add(bottomPanel);

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

        void cselect_MouseClick(object sender, MouseEventArgs e)
        {
            selectall = false;
            aProList.checkNumList.Clear();
            for (int i = 0; i < aProList.checkClickList.Count; i++)
            {
                aProList.checkClickList[i] = false;
                aProList.checkList[i].BackgroundImage = Resources.circle_black;

            }
        }

        void select_MouseClick(object sender, MouseEventArgs e)
        {
            selectall = true;
            aProList.checkNumList.Clear();
            for (int i = 0; i < aProList.checkClickList.Count; i++)
            {
                aProList.checkClickList[i] = true;
                aProList.checkList[i].BackgroundImage = Resources.circle_red;
                aProList.checkNumList.Add(i);
            }
        }

        override public void ReLoad(int x)
        {

            ProType = x;
            if (ProType < 3)
            {
                aChptList.Dispose();
                aChptList = new ChptList(this);
                aChptList.Size = new Size(ClWidth, Height);
                Controls.Add(aChptList);

                aProList.Reload();
                HideList();
                aChptList.Show();
                aProList.Show();
                this.Visible = true;
            }
            else
            {
                aChptList.Hide();
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