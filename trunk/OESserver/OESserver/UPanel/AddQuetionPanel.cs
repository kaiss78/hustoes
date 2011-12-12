using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OES.UPanel;

namespace OES
{
    public partial class AddQuetionPanel : UserPanel
    {
        UserPanel SingleChoice = new AddSingleChoice();
        UserPanel fillblank = new AddFillBlank();
        public AddQuetionPanel()
        {
            InitializeComponent();
            this.Controls.Add(SingleChoice);
            this.Controls.Add(fillblank);
            SingleChoice.Visible = false;
            fillblank.Visible = false;
           
        }

        public override void ReLoad()
        {
            this.Visible = true;
        }
        
        private void comboBox2_TextChanged(object sender, EventArgs e)
        {

           
            if (comboBox2.Text == "选择")
            {

                fillblank.Visible = false;
                SingleChoice.Show();
                SingleChoice.Location = new Point(0,120 );
            }
            
            if (comboBox2.Text == "填空")
            {
                SingleChoice.Visible = false;
                
                fillblank.Show();
                fillblank.Location = new Point(0,120);
            }
        }
        public string Capter
        {
            get 
            {
                return Chapater.Text;
            }

        }

        public string Diffucity
        {
            get 
            {
                return comboBox1.Text;
            }
        }

        public string Teststyle
        {
            get
            {
                return comboBox2.Text;
            }
        }

     
        
        

        
       
        

      
    }
}
