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
            reademfile.readfile(readstring);

        }

        private void radioButtonA_CheckedChanged(object sender, EventArgs e)
        {
            
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

     

        private void Fillingintheblank_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = readstring[i];
            richTextBox2.Text =  readstring[i+1];
         //   radioButtonA.Text = readstring[i + 2] + "\r\n" + readstring[i];
            radioButtonA.Text = write(readstring[i + 2]);
            radioButtonB.Text = write( readstring[i+3]);
            radioButtonC.Text = write(readstring[i+4]);
            radioButtonD.Text = write(readstring[i+5]);
            i += 6;

        }

        private void nextstep_Click(object sender, EventArgs e)
        {
            if (readstring[i+6] == null)
            { MessageBox.Show("后面没题了，可以做其他的题目");
              
            }
            else
            {
               
                richTextBox1.Text =  readstring[i];
                richTextBox2.Text = readstring[i + 1];
                radioButtonA.Text = write(readstring[i + 2]);
                radioButtonB.Text = write(readstring[i + 3]);
                radioButtonC.Text = write(readstring[i + 4]);
                radioButtonD.Text = write(readstring[i + 5]);
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
                radioButtonA.Text = write(readstring[i + 2]);
                radioButtonB.Text = write(readstring[i + 3]);
                radioButtonC.Text = write( readstring[i + 4]);
                radioButtonD.Text = write(readstring[i + 5]);
                i += 6;
            }
            else
            { MessageBox.Show("前面没题了");
             i += 12;
           
            }
        }
      public string write(string str)
        {
            string s,sr;
           
            s = str;

          //  if ( System.Text.Encoding.Default.GetByteCount(str) > 30)
           if(str.Length>30)
            {
                s=s.Insert(30,"\r\n");
                if (str.Length > 60)
                { s=s.Insert(60, "\r\n"); }
                if (str.Length >90)
                { s = s.Insert(90, "\r\n"); }
                sr = s;
            }
            else 
            {
                sr = s;
            }
            return sr;
        }
      public int getLengthb(string str1)
      {
          return System.Text.Encoding.Default.GetByteCount(str1);
      }

      private void submit_Click(object sender, EventArgs e)
      {

      }
      public void getmarks()
      {

      }
    }
        
    }
   

