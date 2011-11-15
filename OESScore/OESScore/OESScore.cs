using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using OES.Model;
using OES.Net;

namespace OESScore
{
    public partial class formOESScore : Form
    {
        public ClientEvt scoreNet = new ClientEvt();
        public DataTable dtPaperList = new DataTable();
        public List<PaperFolder> papers = new List<PaperFolder>();
        private System.Windows.Forms.DataGridViewTextBoxColumn StuID;
        private System.Windows.Forms.DataGridViewTextBoxColumn StuName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Score;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvAnsTable;

        public formOESScore()
        {
            InitializeComponent();
            netState1.ReConnect += new EventHandler(netState1_ReConnect);
            netState1.State = 2;
            ClientEvt.Client.ConnectedServer += new EventHandler(Client_ConnectedServer);
            ClientEvt.Client.DisConnectError += new ErrorEventHandler(Client_DisConnectError);
            scoreNet.Init();
            tsslPath.Text = ScoreControl.config["PaperPath"];
            LoadPaperList();
        }

        void Client_DisConnectError(object sender, ErrorEventArgs e)
        {
            while (!this.IsHandleCreated) ;
            this.BeginInvoke(new MethodInvoker(() =>
            {
                netState1.State = 0;
            }));
        }

        void Client_ConnectedServer(object sender, EventArgs e)
        {
            while (!this.IsHandleCreated) ;
            this.BeginInvoke(new MethodInvoker(() =>
            {
                netState1.State = 1;
            }));
        }

        void netState1_ReConnect(object sender, EventArgs e)
        {
            if (netState1.State == 0)
            {
                ClientEvt.Client.InitializeClient();
            }
            else
            {
                netState1.State = 0;
            }
        }


        /// <summary>
        /// 往表格中添加试卷信息
        /// </summary>
        /// <param name="ID">试卷ID</param>
        /// <param name="Name">试卷名</param>
        /// <param name="Progress">评分进度</param>
        /// <param name="count">考生答案总数</param>
        public void AddToDGV(PaperFolder pf)
        {
            DataGridViewProgressBarCell tmp = new DataGridViewProgressBarCell();
            object[] values = new object[4];
            values[0] = pf.paperInfo.paperID;
            values[1] = pf.paperInfo.paperName;
            values[2] = 50;
            values[3] = ScoreControl.GetFolderInfo(pf.Path.FullName).Count;
            dgvPaperTable.Rows.Add(values);
        }

        /// <summary>
        /// 载入试卷
        /// 获取试卷目录里的试卷信息，在表格中显示出来
        /// </summary>
        public void LoadPaperList()
        {
            List<DirectoryInfo> paperList;
            List<Paper> tmpP;
            PaperFolder tmpPF;
            paperList = ScoreControl.GetFolderInfo(ScoreControl.config["PaperPath"]);
            dgvPaperTable.Rows.Clear();
            foreach (DirectoryInfo paper in paperList)
            {

                tmpP = ScoreControl.OesData.FindPaperById(paper.Name);
                if (tmpP.Count > 0)
                {
                    tmpPF = new PaperFolder();
                    tmpPF.paperInfo = tmpP[0];
                    tmpPF.Path = paper;
                    papers.Add(tmpPF);
                    AddToDGV(tmpPF);
                }
            }
        }


        /// <summary>
        /// 选择路径
        /// 设置试卷所在目录，保存到配置文件并刷新试卷列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectPath_Click(object sender, EventArgs e)
        {
            string path;

            if (fbdPaperPath.ShowDialog().Equals(DialogResult.OK))
            {
                if (Directory.Exists(fbdPaperPath.SelectedPath))
                {
                    ScoreControl.config["PaperPath"] = fbdPaperPath.SelectedPath;
                    tsslPath.Text = ScoreControl.config["PaperPath"];
                }
                else
                {
                    MessageBox.Show("文件夹不存在", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


            LoadPaperList();
        }

        /// <summary>
        /// 双击单元格，进入试卷评分界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvPaperTable_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int RIndex = e.RowIndex;
            if (RIndex > -1)
            {
                formScore formscore = new formScore(papers[RIndex].Path.FullName);

                ScoreControl.staAns = ScoreControl.SetStandardAnswer(papers[RIndex].Path.Name, papers[RIndex].Path.FullName);

                formscore.ShowDialog();
                formscore.Dispose();
            }
        }

        private void btnScore_Click(object sender, EventArgs e)
        {
            int RIndex = dgvPaperTable.CurrentRow.Index;
            if (RIndex > -1)
            {
                ScoreControl.staAns = ScoreControl.SetStandardAnswer(papers[RIndex].Path.Name, papers[RIndex].Path.FullName);
                formScore formscore = new formScore(papers[RIndex].Path.FullName);
            }


        }
    }
}
