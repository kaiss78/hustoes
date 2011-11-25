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
using OES.XMLFile;

namespace OESScore
{
    public partial class formOESScore : Form
    {
        
        public DataTable dtPaperList = new DataTable();
        public List<PaperFolder> papers = new List<PaperFolder>();
        private System.Windows.Forms.DataGridViewTextBoxColumn StuID;
        private System.Windows.Forms.DataGridViewTextBoxColumn StuName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Score;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView dgvAnsTable;
        private List<StuFolder> StuList = new List<StuFolder>();

        public formOESScore()
        {
            InitializeComponent();
            foreach (string st in ScoreControl.config.GetAllConfig().Values)
            {
                if (!Directory.Exists(st))
                {
                    Directory.CreateDirectory(st);
                }
            }
            netState1.ReConnect += new EventHandler(netState1_ReConnect);
            netState1.State = 2;
            ClientEvt.Client.ConnectedServer += new EventHandler(Client_ConnectedServer);
            ClientEvt.Client.DisConnectError += new ErrorEventHandler(Client_DisConnectError);
            ScoreControl.scoreNet.Init();
            tsslPath.Text = ScoreControl.config["PaperPath"];
            //LoadStudentList();
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
            dgvStudentTable.Rows.Add(values);
        }

        /// <summary>
        /// 载入试卷
        /// 获取试卷目录里的试卷信息，在表格中显示出来
        /// </summary>
        public void LoadStudentList()
        {
            StuFolder tmpSF;
            List<Student> tmpS;
            List<Paper> tmpP;
            List<DirectoryInfo> studentList;
            StuList = new List<StuFolder>();
            studentList = ScoreControl.GetFolderInfo(ScoreControl.config["PaperPath"]);
            dgvStudentTable.Rows.Clear();
            object[] values = new object[4];

            foreach (DirectoryInfo stu in studentList)
            {
                tmpS = ScoreControl.OesData.FindStudentByStudentId(stu.Name);
                if (tmpS.Count > 0)
                {
                    tmpSF = new StuFolder();
                    tmpSF.PaperInfo = new Paper();
                    tmpSF.StuInfo = tmpS[0];
                    tmpSF.Score = new Score();
                    tmpSF.Score.score = "0";
                    tmpSF.path = stu;
                    tmpSF.StuAns = ScoreControl.GetStuAns(stu.FullName);                   
                    tmpP = ScoreControl.OesData.FindPaperById(XMLControl.GetStudentAnsPaper(stu.FullName + "\\studentAns.xml").ToString());
                    if (tmpP.Count > 0)
                    {
                        tmpSF.PaperInfo = tmpP[0];
                    }
                    else
                    {                        
                        tmpSF.PaperInfo.paperName = "试卷不存在";
                        tmpSF.PaperInfo.paperID = "-1";
                    }
                    if (File.Exists(stu.FullName + "\\Result.xml"))
                    {
                        tmpSF.ReadResult(stu.FullName + "\\Result.xml");
                    }

                    StuList.Add(tmpSF);
                    values[0] = tmpSF.StuInfo.ID;
                    values[1] = tmpSF.StuInfo.sName;
                    values[2] = tmpSF.PaperInfo.paperName;
                    values[3] = tmpSF.Score.score;
                    dgvStudentTable.Rows.Add(values);
                }
            } 
        }
        public void MarkAll()
        {
            for (int i = 0; i < StuList.Count; i++)
            {
                Mark(i);
            }
        }

        public int Mark(int RIndex)
        {
            List<string> proAns;
            int Score = 0, dScore = 0;
            StuList[RIndex].Score.sum = new List<Sum>();
            ScoreControl.staAns = ScoreControl.SetStandardAnswer(StuList[RIndex].PaperInfo.paperID);
            XMLControl.CreateScoreXML(StuList[RIndex].path.FullName + "\\Result.xml", ScoreControl.staAns.PaperID, StuList[RIndex].StuInfo.ID);
            foreach (Answer ans in StuList[RIndex].StuAns.Ans)
            {
                dScore = 0;
                if ((ScoreControl.staAns.Ans[ans.ID].Ans.Split('\n').Contains(ans.Ans)))
                {
                    dScore = ScoreControl.staAns.Ans[ans.ID].Score;
                }
                StuList[RIndex].Score.addDetail(ans.Type, dScore);
                XMLControl.AddScore(ans.Type, ScoreControl.staAns.Ans[ans.ID].ID, dScore);
                Score += dScore;
            }
            if (File.Exists(StuList[RIndex].path.FullName + "\\g.c"))  //程序改错
            {
                proAns = ScoreControl.correctPC(StuList[RIndex].path.FullName + "\\g.c");
            }
            if (File.Exists(StuList[RIndex].path.FullName + "\\h.c"))  //程序综合
            {
            }
            if (File.Exists(StuList[RIndex].path.FullName + "\\i.c"))  //程序填空
            {
                proAns = ScoreControl.correctPC(StuList[RIndex].path.FullName + "\\i.c");
            }
            return Score;
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
            LoadStudentList();
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
                StuList[RIndex].Score.score=Mark(RIndex).ToString();
                dgvStudentTable.Rows[RIndex].Cells[3].Value= StuList[RIndex].Score.score;
                //formScore formscore = new formScore(papers[RIndex].Path.FullName);

                //ScoreControl.staAns = ScoreControl.SetStandardAnswer(papers[RIndex].Path.Name, papers[RIndex].Path.FullName);

                //formscore.ShowDialog();
                //formscore.Dispose();
            }
        }

        private void btnScore_Click(object sender, EventArgs e)
        {
            int RIndex = dgvStudentTable.CurrentRow.Index;
            if (RIndex > -1)
            {
                //ScoreControl.staAns = ScoreControl.SetStandardAnswer(papers[RIndex].Path.Name, papers[RIndex].Path.FullName);
                //formScore formscore = new formScore(papers[RIndex].Path.FullName);
            }


        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            new ConfigForm().ShowDialog(this);
        }
    }
}
