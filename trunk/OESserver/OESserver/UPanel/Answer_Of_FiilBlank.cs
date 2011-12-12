using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OES.UPanel;

namespace OES.UPanel
{
    public partial class Answer_Of_FiilBlank : UserPanel
    {
        public Answer_Of_FiilBlank()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
        public String getAnser
        {
            get 
            {
                return Answer.Text;
            }
        }
      
    }
}
