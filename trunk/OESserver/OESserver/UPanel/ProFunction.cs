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
    public partial class ProFunction : UserPanel
    {
        private DataTable dtAnsList;
        private List<ProgramAnswer> AnsList;
        private frmAddProData frmaddProData;
        private PLanguage language;
        private bool addnew;

        public ProFunction()
        {
            InitializeComponent();
            dtAnsList = new DataTable();
            dtAnsList.Columns.Add("输入");
            dtAnsList.Columns.Add("输出");

            dgvAnsList.DataSource = dtAnsList;
            dgvAnsList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAnsList.Columns[0].FillWeight = 50;
            dgvAnsList.Columns[1].FillWeight = 50;
            dgvAnsList.Columns[0].SortMode=DataGridViewColumnSortMode.NotSortable;
            dgvAnsList.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;

        }

        public override void ReLoad()
        {
            AnsList=new List<ProgramAnswer>();
            dtAnsList.Clear();
            addnew = true;
            this.Visible = true;
        }
        public override void ReLoad(int x)
        {
            addnew = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (addnew)
            {
                int Unit = (this.Parent.Parent as AddQuetionPanel).Capter;
                String PLevel = (this.Parent.Parent as AddQuetionPanel).Difficulity;
                int PID = InfoControl.OesData.AddProgram(rtbPContent.Text,ProgramPType.Function , language, Convert.ToInt32(Unit), Convert.ToInt32(PLevel));
                if (PID > 0)
                {
                    foreach (ProgramAnswer ans in AnsList)
                    {
                        InfoControl.OesData.AddProgramAnswer(PID, ans.SeqNum, ans.Input, ans.Output);
                    }
                }
                
            }
            else
            {
                
            }
        }

        private void btnBrowserSource_Click(object sender, EventArgs e)
        {
            if (ofdBrowser.ShowDialog() == DialogResult.OK)
            {
                tbProblemFile.Text = ofdBrowser.FileName;
            }
        }

        private void btnBrowserAns_Click(object sender, EventArgs e)
        {
            if (ofdBrowser.ShowDialog() == DialogResult.OK)
            {
                tbAnswerFile.Text = ofdBrowser.FileName;
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
            if(File.Exists(tbAnswerFile.Text))
            {
                frmaddProData = new frmAddProData(tbAnswerFile.Text);
                frmaddProData.ShowDialog();
                if (frmaddProData.Result==true)
                {
                    AnsList.Add(frmaddProData.ProAns);
                    dtAnsList.Rows.Add(new object[2] {frmaddProData.ProAns.Input, frmaddProData.ProAns.Output});
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvAnsList.CurrentRow != null && dgvAnsList.CurrentRow.Index>0)
            {
                frmaddProData = new frmAddProData(tbAnswerFile.Text, AnsList[dgvAnsList.CurrentRow.Index]);
                frmaddProData.ShowDialog();
                if (frmaddProData.Result == true)
                {
                    dtAnsList.Rows[dgvAnsList.CurrentRow.Index][0] = frmaddProData.ProAns.Input;
                    dtAnsList.Rows[dgvAnsList.CurrentRow.Index][1] = frmaddProData.ProAns.Output;
                    AnsList[dgvAnsList.CurrentRow.Index] = frmaddProData.ProAns;
                }
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (dgvAnsList.CurrentRow != null && dgvAnsList.CurrentRow.Index > 0)
            {
                AnsList.Remove(AnsList[dgvAnsList.CurrentRow.Index]);
                dtAnsList.Rows.Remove(dtAnsList.Rows[dgvAnsList.CurrentRow.Index]);
            }
        }
    }
}
