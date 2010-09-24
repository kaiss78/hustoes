using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace oesdemoliuyuan
{   
    public partial class Fillingintheblank : UserControl
    {
        ReadEMFile reademfile=new ReadEMFile();
        string [] readstring=new string[200];
        int i=0;
        
        public Fillingintheblank()
        {
            InitializeComponent();
            ReadEMFile reademfile = new ReadEMFile();
            reademfile.read(readstring);

        }

        private void radioButtonA_CheckedChanged(object sender, EventArgs e)
        {
           // this.Focus();
          
           // this.Visible = true;
          //  this.Name = readstring[2];
           
            
        }

        private void radioButtonB_CheckedChanged(object sender, EventArgs e)
        {
            
           
        }

        private void radioButtonC_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void radioButtonD_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            
           
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Fillingintheblank_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = readstring[i];
            richTextBox2.Text = readstring[i+1];
            radioButtonA.Text = readstring[i+2];
            radioButtonB.Text = readstring[i+3];
            radioButtonC.Text = readstring[i+4];
            radioButtonD.Text = readstring[i+5];
            i += 6;

        }

        private void nextstep_Click(object sender, EventArgs e)
        {

         //   richTextBox1.Text = " ";
        //    richTextBox2.Text = " ";
        //    richTextBox1.SelectedText = " ";
       /*     radioButtonA.Text = " ";
            radioButtonB.Text = " ";
            radioButtonC.Text = " ";
            radioButtonD.Text = " ";
            ReadEMFile reademfile = new ReadEMFile();
            reademfile.read(readstring);*/
            if (readstring[i+6] == null)
            { MessageBox.Show("后面没题了，可以做其他的题目"); }
            else
            {
                richTextBox1.Text = readstring[i];
                richTextBox2.Text = readstring[i + 1];
                radioButtonA.Text = readstring[i + 2];
                radioButtonB.Text = readstring[i + 3];
                radioButtonC.Text = readstring[i + 4];
                radioButtonD.Text = readstring[i + 5];
                i += 6;
            }
           
            
        }

        private void laststep_Click(object sender, EventArgs e)
        {
            i -= 12;
            if (i >= 0)
            {
                richTextBox1.Text = readstring[i];
                richTextBox2.Text = readstring[i + 1];
                radioButtonA.Text = readstring[i + 2];
                radioButtonB.Text = readstring[i + 3];
                radioButtonC.Text = readstring[i + 4];
                radioButtonD.Text = readstring[i + 5];
            }
            else
            { MessageBox.Show("前面没题了");}
        }

       
    }
        
    }
   

