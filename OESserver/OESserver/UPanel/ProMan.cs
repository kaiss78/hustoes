using System.Drawing;
using System.Windows.Forms;
using OES.UControl;
using System.Collections.Generic;

namespace OES.UPanel
{
    public partial class ProMan : UserPanel
    {
        private readonly int ClWidth;
        private readonly int PlHeight;
        private readonly int PlWidth;
        private readonly int BpHeight;
        public Panel bottomPanel = new Panel();
        public int ProType;
        public List<UserControl> EditList=new List<UserControl>();
        public ChoiceEdit aChoiceEdit = new ChoiceEdit();
        public CompletionEdit aCompletionEdit = new CompletionEdit();

        public ProMan()
        {
            InitializeComponent();
            
            ClWidth = (int)(Width * 0.2);
            PlWidth = (int)(Width * 0.8);
            PlHeight = (int)(Height * 0.9);
            BpHeight = (int)(Height * 0.9);

            ProType=0;

            
            var aChptList = new ChptList();
            aChptList.Size = new Size(ClWidth, Height);
            Controls.Add(aChptList);
            var aProList = new ProList(this);
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
                
            }
           

            EditList.Add(aChoiceEdit);
        }

        override public void ReLoad(int x)
        {
            ProType = x;
            this.Visible = true;
        }
    }
}