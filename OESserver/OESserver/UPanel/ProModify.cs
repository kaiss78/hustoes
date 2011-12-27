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
    public partial class ProModify : UserPanel
    {
        public ProgramProblem newProblem;
        public DataTable dtAnsList;
        public DataView dvAnsList;        
        public int BlankCount;
        public int AnsCount;

        private PLanguage language;
        private ProgramPType ProType = ProgramPType.Modify;
        private bool addnew;

        private frmAddAnswer newans;

        public ProModify()
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
            dtAnsList.Columns.Add("SeqNum", typeof(int));
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
                Path.GetExtension(ofdBrowser.FileName);
                MessageBox.Show(Path.GetExtension(ofdBrowser.FileName).ToLower());
                switch (Path.GetExtension(ofdBrowser.FileName).ToLower())
                {
                    case ".c":
                        language = PLanguage.C;
                        break;
                    case ".cpp":
                        language = PLanguage.CPP;
                        break;
                    case ".vb":
                        language = PLanguage.VB;
                        break;
                    default:
                        language = PLanguage.Null;
                        break;
                }

            }
        }

        private void btnAddAns_Click(object sender, EventArgs e)
        {

            if (File.Exists(tbProblemFile.Text))
            {
                if (BlankCount > 0)
                {
                    newans = new frmAddAnswer(BlankCount);
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
                newans = new frmAddAnswer(BlankCount, newProblem.ansList[dtAnsList.Rows.IndexOf(dr)]);
                newans.ShowDialog();
                if (newans.Result)
                {
                    newProblem.ansList[dtAnsList.Rows.IndexOf(dr)] = newans.ProAns;
                    dr[0] = newans.ProAns.SeqNum;
                    dr[1] = newans.ProAns.SeqNum.ToString() + ": " + newans.ProAns.Output;
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
                int Unit = (this.Parent.Parent as AddQuetionPanel).Capter;
                String PLevel = (this.Parent.Parent as AddQuetionPanel).Difficulity;
                int PID = InfoControl.OesData.AddProgram(rtbPContent.Text, ProType, language, Convert.ToInt32(Unit), Convert.ToInt32(PLevel));
                if (PID > 0)
                {
                    foreach (ProgramAnswer ans in newProblem.ansList)
                    {
                        InfoControl.OesData.AddProgramAnswer(PID, ans.SeqNum, ans.Input, ans.Output);
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }


    }
}
