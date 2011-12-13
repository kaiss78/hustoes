using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using OES.Model;

namespace OES.UPanel
{
    public partial class ProCompletion : UserPanel
    {
        static List<string> ansList;
        public ProgramProblem newProblem;
        public DataTable dtAnsList;
        public DataView dvAnsList;
        public int BlankCount;
        public int AnsCount;
        private bool addnew;
        private formAddAnswer newans;

        public ProCompletion()
        {
            InitializeComponent();
        }

        public override void ReLoad()
        {
            newProblem = new ProgramProblem();
            rtbPContent.Text = "";            
            tbProblemFile.Text = "";
            BlankCount = 0;
            AnsCount = 0;

            dtAnsList = new DataTable();
            dtAnsList.Columns.Add("SeqNum",typeof(int));
            dtAnsList.Columns.Add("Value", typeof(string));
            dvAnsList = new DataView(dtAnsList);
            dvAnsList.Sort = "SeqNum";
            lbAnsList.DataSource = dvAnsList;
            lbAnsList.DisplayMember = "Value";
            addnew = true;
            this.Visible = true;
        }

        public override void ReLoad(int x)
        {
            addnew = false;
        }


        private void btnBrowser_Click(object sender, EventArgs e)
        {
            if (ofdBrowser.ShowDialog() == DialogResult.OK)
            {
                tbProblemFile.Text = ofdBrowser.FileName;
                BlankCount = InfoControl.coutnAnswer(tbProblemFile.Text);
            }
        }

        private void btnAddAns_Click(object sender, EventArgs e)
        {            
            
            if (File.Exists(tbProblemFile.Text))
            {
                if (BlankCount > 0)
                {
                    newans = new formAddAnswer(BlankCount);
                    newans.ShowDialog();
                    if (newans.Result)
                    {
                        newProblem.ansList.Add(newans.ProAns);
                        object[] values = new object[2];
                        values[0] = newans.ProAns.SeqNum;
                        values[1] = newans.ProAns.SeqNum.ToString() + ": " + newans.ProAns.Output;
                        dtAnsList.Rows.Add(values);
                    }
                }
                else
                { 

                }
            }
            else
            { 

            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (lbAnsList.SelectedIndex >= 0)
            {                
                DataRow dr = dvAnsList[lbAnsList.SelectedIndex].Row;
                newProblem.ansList.Remove(newProblem.ansList[dtAnsList.Rows.IndexOf(dr)]);
                dtAnsList.Rows.Remove(dr);                
            }
            else
            { 

            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lbAnsList.SelectedIndex >= 0)
            {
                DataRow dr = dvAnsList[lbAnsList.SelectedIndex].Row;
                newans = new formAddAnswer(BlankCount, newProblem.ansList[dtAnsList.Rows.IndexOf(dr)]);
                newans.ShowDialog();
                if (newans.Result)
                {                    
                    newProblem.ansList[dtAnsList.Rows.IndexOf(dr)] = newans.ProAns;
                    dr[0] = newans.ProAns.SeqNum;
                    dr[1]=newans.ProAns.SeqNum.ToString() + ": " + newans.ProAns.Output;
                }
            }
            else
            {

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (addnew)
            {
                
            }
        }
    }
}

