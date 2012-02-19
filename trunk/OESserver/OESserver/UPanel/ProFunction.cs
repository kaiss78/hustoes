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
using OES.Net;

namespace OES.UPanel
{
    public partial class ProFunction : UserPanel
    {
        private DataTable dtAnsList;
        public ProgramProblem newProblem;
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
            dgvAnsList.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvAnsList.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;

        }

        public override void ReLoad()
        {
            AnsList = new List<ProgramAnswer>();
            dtAnsList.Clear();
            addnew = true;
            this.Visible = true;

        }
        public override void ReLoad(int pid)
        {
            addnew = false;
            ReLoad();
            newProblem = InfoControl.getProProblem(pid);
            rtbPContent.Text = newProblem.problem;
            foreach (ProgramAnswer ans in newProblem.ansList)
            {
                dtAnsList.Rows.Add(new object[2] { ans.Input, ans.Output });
            }
            switch (newProblem.language)
            {
                case PLanguage.C:
                    InfoControl.ClientObj.LoadCFunctionA(pid, Convert.ToInt32(InfoControl.User.Id));
                    InfoControl.ClientObj.LoadCFunctionP(pid, Convert.ToInt32(InfoControl.User.Id));
                    tbProblemFile.Text = InfoControl.config["CompletionPath"] + "p" + pid.ToString() + ".c";
                    tbAnswerFile.Text = InfoControl.config["CompletionPath"] + "a" + pid.ToString() + ".c";
                    break;
                case PLanguage.CPP:
                    InfoControl.ClientObj.LoadCppFunctionA(pid, Convert.ToInt32(InfoControl.User.Id));
                    InfoControl.ClientObj.LoadCppFunctionP(pid, Convert.ToInt32(InfoControl.User.Id));
                    tbProblemFile.Text = InfoControl.config["CompletionPath"] + "p" + pid.ToString() + ".cpp";
                    tbAnswerFile.Text = InfoControl.config["CompletionPath"] + "a" + pid.ToString() + ".cpp";
                    break;
                case PLanguage.VB:
                    InfoControl.ClientObj.LoadVbFunctionA(pid, Convert.ToInt32(InfoControl.User.Id));
                    InfoControl.ClientObj.LoadVbFunctionP(pid, Convert.ToInt32(InfoControl.User.Id));
                    tbProblemFile.Text = InfoControl.config["CompletionPath"] + "p" + pid.ToString() + ".vb";
                    tbAnswerFile.Text = InfoControl.config["CompletionPath"] + "a" + pid.ToString() + ".vb";
                    break;
            }
            InfoControl.ClientObj.ReceiveFiles();
            while (!ClientEvt.isOver) ;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (addnew)
            {
                int Unit = (this.Parent.Parent as AddQuetionPanel).Capter;
                int PLevel = (this.Parent.Parent as AddQuetionPanel).Difficulity;
                int PID = InfoControl.OesData.AddProgram(rtbPContent.Text, ProgramPType.Function, language, Convert.ToInt32(Unit), Convert.ToInt32(PLevel));
                if (PID > 0)
                {
                    foreach (ProgramAnswer ans in AnsList)
                    {
                        InfoControl.OesData.AddProgramAnswer(PID, ans.SeqNum, ans.Input, ans.Output);
                    }
                    switch (language)
                    {
                        case PLanguage.C:
                            File.Copy(tbProblemFile.Text, InfoControl.config["FunctionPath"] + "p" + PID.ToString() + ".c");
                            File.Copy(tbAnswerFile.Text, InfoControl.config["FunctionPath"] + "a" + PID.ToString() + ".c");
                            InfoControl.ClientObj.SaveCFunctionA(PID, Convert.ToInt32(InfoControl.User.Id));
                            InfoControl.ClientObj.SaveCFunctionP(PID, Convert.ToInt32(InfoControl.User.Id));
                            break;
                        case PLanguage.CPP:
                            File.Copy(tbProblemFile.Text, InfoControl.config["FunctionPath"] + "p" + PID.ToString() + ".cpp");
                            File.Copy(tbAnswerFile.Text, InfoControl.config["FunctionPath"] + "a" + PID.ToString() + ".cpp");
                            InfoControl.ClientObj.SaveCppFunctionA(PID, Convert.ToInt32(InfoControl.User.Id));
                            InfoControl.ClientObj.SaveCppFunctionP(PID, Convert.ToInt32(InfoControl.User.Id));
                            break;
                        case PLanguage.VB:
                            File.Copy(tbProblemFile.Text, InfoControl.config["FunctionPath"] + "p" + PID.ToString() + ".vb");
                            File.Copy(tbAnswerFile.Text, InfoControl.config["FunctionPath"] + "a" + PID.ToString() + ".vb");
                            InfoControl.ClientObj.SaveVbFunctionP(PID, Convert.ToInt32(InfoControl.User.Id));
                            InfoControl.ClientObj.SaveVbFunctionA(PID, Convert.ToInt32(InfoControl.User.Id));
                            break;
                    }
                    InfoControl.ClientObj.SendFiles();
                    while (!ClientEvt.isOver) ;
                    MessageBox.Show("题目添加成功！", "通知", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (File.Exists(tbAnswerFile.Text))
            {
                frmaddProData = new frmAddProData(tbAnswerFile.Text);
                frmaddProData.ShowDialog();
                if (frmaddProData.Result == true)
                {
                    AnsList.Add(frmaddProData.ProAns);
                    dtAnsList.Rows.Add(new object[2] { frmaddProData.ProAns.Input, frmaddProData.ProAns.Output });
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvAnsList.CurrentRow != null && dgvAnsList.CurrentRow.Index > 0)
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
