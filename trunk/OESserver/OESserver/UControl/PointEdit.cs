using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OES.UControl
{
    public partial class PointEdit : UserControl
    {
        public OfficeExcelEdit aOfficeExcelEdit;
        public PointEdit(OfficeExcelEdit exl)
        {
            InitializeComponent();
            aOfficeExcelEdit = exl;
        }


    }
}
