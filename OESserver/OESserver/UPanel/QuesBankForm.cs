using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OES.UPanel
{
    public partial class QuesBankForm : UserPanel
    {
        private DataTable questionTable;
        public QuesBankForm()
        {
            InitializeComponent();

        }
        public override void ReLoad()
        {
            this.Visible = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {

            }
            if (comboBox1.SelectedIndex == 1)
            {
                
            }
            if (comboBox1.SelectedIndex == 2)
            {

            }
            if (comboBox1.SelectedIndex == 3)
            {

            }
           
        }
    }
}
