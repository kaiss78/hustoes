using System.Drawing;
using System.Windows.Forms;
using OES.UControl;
using System.Collections.Generic;

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
        public Panel bottomPanel = new Panel();
        public int ProType;
        public List<UserControl> EditList=new List<UserControl>();
        public ChoiceEdit aChoiceEdit = new ChoiceEdit();
        public CompletionEdit aCompletionEdit = new CompletionEdit();
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
            
            ClWidth = (int)(Width * 0.2);
            PlWidth = (int)(Width * 0.8);
            PlHeight = (int)(Height * 0.9);
            BpHeight = (int)(Height * 0.9);

            ProType=0;

            
            aChptList = new ChptList();
            aChptList.Size = new Size(ClWidth, Height);
            Controls.Add(aChptList);
            aProList = new ProList(this);
            aProList.SetBounds(ClWidth, 0, PlWidth, PlHeight);
            Controls.Add(aProList);
            bottomPanel.SetBounds(ClWidth, PlHeight, PlWidth, BpHeight);
            this.Controls.Add(bottomPanel);

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

        override public void ReLoad(int x)
        {

            ProType = x;
            aProList.Reload(ProType);
            aProList.Show();
            this.Visible = true;
        }
    }
}