using System.Drawing;
using System.Windows.Forms;
using OESserver.UControl;

namespace OESserver.UPanel
{
    public partial class ProMan : UserPanel
    {
        private readonly int ClWidth;
        private readonly int PlHeight;
        private readonly int PlWidth;
        private readonly int BpHeight;      

        public ProMan()
        {
            InitializeComponent();

            ClWidth = (int) (Width*0.2);
            PlWidth = (int) (Width*0.8);
            PlHeight = (int) (Height*0.9);
            BpHeight=(int)(Height*0.9);

            var aChptList = new ChptList();
            aChptList.Size = new Size(ClWidth, Height);
            Controls.Add(aChptList);
            var aProList = new ProList();
            aProList.SetBounds(ClWidth, 0, PlWidth, PlHeight);
            Controls.Add(aProList);
            Panel bottomPanel = new Panel();
            bottomPanel.SetBounds(ClWidth, PlHeight, PlWidth, BpHeight);
            this.Controls.Add(bottomPanel);
        }
        override public void ReLoad()
        {
            this.Visible = true;
        }
    }
}