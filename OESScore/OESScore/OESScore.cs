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
using OES;

namespace OESScore
{
    public partial class formOESScore : Form
    {
        
        public DataTable dtStuList = new DataTable();
        public DataView dvStuList = new DataView();
        public List<PaperFolder> papers = new List<PaperFolder>();
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
            dtStuList = new DataTable();
            dtStuList.Columns.Add("学号");
            dtStuList.Columns.Add("姓名");
            dtStuList.Columns.Add("试卷名称");
            dtStuList.Columns.Add("成绩",typeof(int));
            dtStuList.Columns.Add("状态");

            dvStuList=new DataView(dtStuList);            
            dgvStudentTable.DataSource = dvStuList;
            dgvStudentTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvStudentTable.Columns[0].FillWeight = 20;
            dgvStudentTable.Columns[1].FillWeight = 20;
            dgvStudentTable.Columns[2].FillWeight = 20;
            dgvStudentTable.Columns[3].FillWeight = 10;
            dgvStudentTable.Columns[4].FillWeight = 10;
 


            dtStuList.Columns.Add("状态");
            #region 网络连接状态初始化
            netState1.ReConnect += new EventHandler(netState1_ReConnect);
            netState1.State = 2;
            ClientEvt.Client.ConnectedServer += new EventHandler(Client_ConnectedServer);
            ClientEvt.Client.DisConnectError += new ErrorEventHandler(Client_DisConnectError);
            #endregion

            ScoreControl.scoreNet.Init();
            tsslPath.Text = ScoreControl.config["PaperPath"];
            //LoadStudentList();
        }

        public void init()
        {

        }

        #region 网络连接状态
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
        #endregion


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
            dtStuList.Rows.Clear();
            object[] values = new object[4];
            int i=0;

            foreach (DirectoryInfo stu in studentList)
            {
                tmpS = ScoreControl.OesData.FindStudentByStudentId(stu.Name);
                if ((tmpS.Count > 0) && (File.Exists(stu.FullName + "\\studentAns.xml")))
                {
                    tmpSF = new StuFolder();
                    tmpSF.PaperInfo = new Paper();
                    tmpSF.StuInfo = tmpS[0];
                    tmpSF.Score = new Score();
                    tmpSF.Score.Value = 0;
                    tmpSF.path = stu;
                    tmpSF.StuAns = ScoreControl.GetStuAns(stu.FullName);                   
                    tmpP = ScoreControl.OesData.FindPaperByPaperId(XMLControl.GetStudentAnsPaper(stu.FullName + "\\studentAns.xml"));
                    if (tmpP.Count > 0)
                    {
                        tmpSF.PaperInfo = tmpP[0];
                    }
                    else
                    {                        
                        tmpSF.PaperInfo.paperName = "试卷不存在";
                        tmpSF.PaperInfo.paperID = -1;
                    }
                    if (File.Exists(stu.FullName + "\\Result.xml"))
                    {
                        tmpSF.ReadResult(stu.FullName + "\\Result.xml");
                    }

                    StuList.Add(tmpSF);
                    values[0] = tmpSF.StuInfo.ID;
                    values[1] = tmpSF.StuInfo.sName;
                    values[2] = tmpSF.PaperInfo.paperName;
                    values[3] = tmpSF.Score.Value;
                    dtStuList.Rows.Add(values);                    
                }
                processBar.Value = ++i * 100 / studentList.Count ;
            } 
        }


        public void MarkAll()
        {
            for (int i = 0; i < StuList.Count; i++)
            {
                processBar.Value = (i+1) * 100 / StuList.Count;
                Mark(i);
            }
        }

        public int Mark(int RIndex)
        {
            List<string> proAns;
            int Score = 0, dScore = 0;            
            StuList[RIndex].Score.sum = new List<Sum>();
            ScoreControl.staAns = ScoreControl.SetStandardAnswer(StuList[RIndex].PaperInfo.paperID.ToString());
            XMLControl.CreateScoreXML(StuList[RIndex].path.FullName + "\\Result.xml", ScoreControl.staAns.PaperID, StuList[RIndex].StuInfo.ID);
            int i = 0;
            foreach (Answer ans in StuList[RIndex].StuAns.Ans)
            {
                dScore = 0;
                if ((ans.Ans!=null) && (ScoreControl.staAns.Ans[ans.ID].Ans.Split('\n').Contains(ans.Ans)))
                {
                    dScore = ScoreControl.staAns.Ans[ans.ID].Score;
                }
                StuList[RIndex].Score.addDetail(ans.Type, dScore);
                XMLControl.AddScore(ans.Type, ScoreControl.staAns.Ans[ans.ID].ID, dScore);
                Score += dScore;
                processBar.Value = ++i * 100 / StuList[RIndex].StuAns.Ans.Count;
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
        /// 解压所有考生答案
        /// </summary>
        /// <param name="path"></param>
        void UncompressAllStudentAns(string path)
        {
            if (RARHelper.Exists())
            {
                int count = Directory.GetFiles(path).Length;
                int i=0;
                foreach (FileInfo f in new DirectoryInfo(path).GetFiles())
                {
                    if (f.Extension == ".rar")
                    {
                        string pass;
                        if (!File.Exists(path + "\\Key\\" + f.Name.Replace(".rar", "") + ".pwd"))
                        { continue; }
                        using (StreamReader sr = new StreamReader(path + "\\Key\\" + f.Name.Replace(".rar", "") + ".pwd", Encoding.Default))
                        {
                            pass = sr.ReadToEnd();
                        }
                        RARHelper.UnCompressRAR(path + "\\" + f.Name.Replace(".rar", "") + "\\", path + "\\", f.Name, true, pass);
                        while (!Directory.Exists(path + "\\" + f.Name.Replace(".rar", "") + "\\")) ;
                    }
                    processBar.Value = ++i * 100 / count;
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
            if (fbdPaperPath.ShowDialog().Equals(DialogResult.OK))
            {
                if (Directory.Exists(fbdPaperPath.SelectedPath))
                {
                    UncompressAllStudentAns(fbdPaperPath.SelectedPath);
                    ScoreControl.config["PaperPath"] = fbdPaperPath.SelectedPath;
                    tsslPath.Text = ScoreControl.config["PaperPath"];
                    LoadStudentList();
                }
                else
                {
                    MessageBox.Show("文件夹不存在", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }

        /// <summary>
        /// 双击单元格，进入试卷评分界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvPaperTable_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int RIndex = dtStuList.Rows.IndexOf(dvStuList[e.RowIndex].Row);
            if (RIndex > -1)
            {
                StuList[RIndex].Score.Value=Mark(RIndex);
                dtStuList.Rows[RIndex][3]= StuList[RIndex].Score.Value;
            }
        }

        private void btnScore_Click(object sender, EventArgs e)
        {
            int RIndex;
            for (int i = 0; i < StuList.Count; i++)
            {
                RIndex = dtStuList.Rows.IndexOf(dvStuList[i].Row);
                StuList[i].Score.Value = Mark(i);
                dtStuList.Rows[RIndex][3]= StuList[i].Score.Value;
            }            
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            new ConfigForm().ShowDialog(this);
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            UncompressAllStudentAns(ScoreControl.config["PaperPath"]);
            LoadStudentList();
        }
    }
}
