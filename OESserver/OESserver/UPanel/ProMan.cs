using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OESserver.UControl;

namespace OESserver.UPanel
{
    public partial class ProMan : UserControl
    {
        int ClWidth;
        int PlWidth;
        int PlHeight;
        public ProMan()
        {
            InitializeComponent();

            ClWidth = (int)(this.Width * 0.2);
            PlWidth = (int)(this.Width * 0.8);
            PlHeight = (int)(this.Height * 0.9);

            ChptList aChptList = new ChptList();
            aChptList.Size = new Size(ClWidth, this.Height);
            this.Controls.Add(aChptList);
            ProList aProList = new ProList();
            aProList.SetBounds(ClWidth, 0,PlWidth,PlHeight);
            this.Controls.Add(aProList);

        }
    }
}
