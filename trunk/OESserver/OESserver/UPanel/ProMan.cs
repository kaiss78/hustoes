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
        public ProMan()
        {
            InitializeComponent();
            ChptList aChptList = new ChptList();
            aChptList.Location = new Point(0, 0);

        }
    }
}
