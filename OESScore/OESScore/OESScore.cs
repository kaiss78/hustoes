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
using OESOfficeScore;

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
                    try
                    {
                        Directory.CreateDirectory(st);
                    }
                    catch
                    {
                    }
                }
            }
            dtStuList = new DataTable();
            dtStuList.Columns.Add("学号");
            dtStuList.Columns.Add("姓名");
            dtStuList.Columns.Add("班级");
            dtStuList.Columns.Add("试卷名称");
            dtStuList.Columns.Add("成绩", typeof(int));
            dtStuList.Columns.Add("状态", typeof(ScoreState));

            dvStuList = new DataView(dtStuList);
            dgvStudentTable.DataSource = dvStuList;
            dgvStudentTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvStudentTable.Columns[0].FillWeight = 15;
            dgvStudentTable.Columns[1].FillWeight = 10;
            dgvStudentTable.Columns[2].FillWeight = 15;
            dgvStudentTable.Columns[3].FillWeight = 20;
            dgvStudentTable.Columns[4].FillWeight = 10;
            dgvStudentTable.Columns[5].FillWeight = 15;

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
            object[] values = new object[6];
            int i = 0;

            foreach (DirectoryInfo stu in studentList)
            {
                tmpS = ScoreControl.OesData.FindStudentByStudentId(stu.Name);
                if (tmpS.Count > 0)
                {
                    tmpSF = new StuFolder();
                    tmpSF.PaperInfo = new Paper();
                    tmpSF.StuInfo = tmpS[0];
                    tmpSF.Score = new Score();
                    tmpSF.Score.Value = 0;
                    tmpSF.path = stu;
                    values[0] = tmpSF.StuInfo.ID;
                    values[1] = tmpSF.StuInfo.sName;
                    values[2] = tmpSF.StuInfo.className;
                    values[3] = "";
                    values[4] = 0;
                    if (File.Exists(stu.FullName + "\\studentAns.xml"))
                    {
                        tmpSF.StuAns = ScoreControl.GetStuAns(stu.FullName);

                        tmpP = ScoreControl.OesData.FindPaperByPaperId(XMLControl.GetStudentAnsPaper(stu.FullName + "\\studentAns.xml"));
                        if (tmpP.Count > 0)
                        {
                            tmpSF.PaperInfo = tmpP[0];
                            tmpSF.state = ScoreState.None; ;
                            values[5] = ScoreState.None;
                        }
                        else
                        {
                            tmpSF.PaperInfo.paperName = "试卷不存在";
                            tmpSF.PaperInfo.paperID = -1;
                            tmpSF.state = ScoreState.PaperNotFound;
                            values[5] = ScoreState.PaperNotFound;
                        }
                        if (File.Exists(stu.FullName + "\\Result.xml"))
                        {
                            tmpSF.ReadResult(stu.FullName + "\\Result.xml");
                            values[4] = tmpSF.Score.Value;
                            tmpSF.state = ScoreState.Success;
                            values[5] = ScoreState.Success;
                        }
                        values[3] = tmpSF.PaperInfo.paperName;
                    }
                    else
                    {
                        tmpSF.state = ScoreState.AnswerNotFound;
                        values[5] = ScoreState.AnswerNotFound;
                    }
                    StuList.Add(tmpSF);
                    dtStuList.Rows.Add(values);
                }
                processBar.Value = ++i * 100 / studentList.Count;
            }
        }

        public void MarkAll()
        {
            for (int i = 0; i < StuList.Count; i++)
            {
                processBar.Value = (i + 1) * 100 / StuList.Count;
                //StuList[RIndex].s
                if ((StuList[i].state == ScoreState.None) || (StuList[i].state == ScoreState.None))
                {
                    Mark(i);
                }
            }
        }

        private string getExtension(PLanguage pLanguage)
        {
            switch (pLanguage)
            {
                case PLanguage.C:
                    return ".c";
                case PLanguage.CPP:
                    return ".cpp";
                case PLanguage.VB:
                    return ".vb";
            }
            return "";
        }

        public int Mark(int RIndex)
        {
            string fileName;
            int count;
            int Score = 0, dScore = 0;
            List<string> proAns;
            StuList[RIndex].Score.sum = new List<Sum>();
            ScoreControl.staAns = ScoreControl.SetStandardAnswer(StuList[RIndex].PaperInfo.paperID.ToString());
            if (ScoreControl.staAns != null)
            {
                XMLControl.CreateScoreXML(StuList[RIndex].path.FullName + "\\Result.xml", ScoreControl.staAns.PaperID, StuList[RIndex].StuInfo.ID);
                int i = 0;
                foreach (Answer ans in StuList[RIndex].StuAns.Ans)
                {

                    if ((ans.Type == ProblemType.Choice) || (ans.Type == ProblemType.Completion) || (ans.Type == ProblemType.Judgment))
                    {
                        dScore = 0;
                        if ((ans.Ans != null) && (ScoreControl.staAns.Ans[ans.ID].Ans.Split('\n').Contains(ans.Ans)))
                        {
                            dScore = ScoreControl.staAns.Ans[ans.ID].Score;
                        }
                        StuList[RIndex].Score.addDetail(ans.Type, dScore);
                        XMLControl.AddScore(ans.Type, ScoreControl.staAns.Ans[ans.ID].ID, dScore);
                        Score += dScore;
                    }
                    //processBar.Value = ++i * 100 / StuList[RIndex].StuAns.Ans.Count;
                }

                for (i = 0; i < ScoreControl.staAns.PCList.Count; i++)
                {
                    fileName = StuList[RIndex].path.FullName + "\\g" + i.ToString() + getExtension(ScoreControl.staAns.PCList[i].language);
                    if (File.Exists(fileName))
                    {
                        dScore = 0;
                        proAns = ProgramScore.correctPC(fileName);
                        count = 0;
                        for (int j = 0; j < proAns.Count; j++)
                        {
                            foreach (ProgramAnswer pa in ScoreControl.staAns.PCList[i].ansList)
                            {
                                if ((pa.Output == proAns[j]) && (pa.SeqNum == j - 1))
                                {
                                    count++;
                                    break;
                                }
                            }
                        }
                        dScore = count * ScoreControl.staAns.PCList[i].score / proAns.Count;
                        XMLControl.AddScore(ScoreControl.staAns.PCList[i].type, ScoreControl.staAns.PCList[i].problemId, dScore);
                        Score = Score + dScore;
                    }
                }


                for (i = 0; i < ScoreControl.staAns.PMList.Count; i++)
                {
                    fileName = StuList[RIndex].path.FullName + "\\h" + i.ToString() + getExtension(ScoreControl.staAns.PMList[i].language);
                    if (File.Exists(fileName))
                    {

                        proAns = ProgramScore.correctPC(fileName);
                        count = 0;
                        dScore = 0;
                        for (int j = 0; j < proAns.Count; j++)
                        {
                            foreach (ProgramAnswer pa in ScoreControl.staAns.PMList[i].ansList)
                            {
                                if ((ProgramScore.Clean(pa.Output) == proAns[j]) && (pa.SeqNum == j - 1))
                                {
                                    count++;
                                    break;
                                }
                            }
                        }
                        dScore = count * ScoreControl.staAns.PMList[i].score / proAns.Count;
                        XMLControl.AddScore(ScoreControl.staAns.PMList[i].type, ScoreControl.staAns.PMList[i].problemId, dScore);
                        Score = Score + dScore;
                    }
                }
                for (i = 0; i < ScoreControl.staAns.PFList.Count; i++)
                {
                    fileName = StuList[RIndex].path.FullName + "\\i" + i.ToString() + getExtension(ScoreControl.staAns.PFList[i].language);
                    if (File.Exists(fileName))
                    {

                        count = 0;
                        dScore = 0;
                        foreach (ProgramAnswer pa in ScoreControl.staAns.PFList[i].ansList)
                        {
                            if (ProgramScore.correctPF(fileName, pa.Input) == ProgramScore.Clean(pa.Output))
                            {
                                count++;
                            }
                        }
                        dScore = count * ScoreControl.staAns.PFList[i].score / ScoreControl.staAns.PFList[i].ansList.Count;
                        XMLControl.AddScore(ScoreControl.staAns.PFList[i].type, ScoreControl.staAns.PFList[i].problemId, dScore);
                        Score = Score + dScore;
                    }
                }
                for (i = 0; i < ScoreControl.staAns.WordList.Count; i++)
                {
                    fileName = StuList[RIndex].path.FullName + "\\d" + i.ToString() + ".doc";
                    if (File.Exists(fileName))
                    {
                        Score += WordScore.ws.checkPoints(fileName, ScoreControl.staAns.WordList[i].OfficeFile, ScoreControl.staAns.WordList[i].XMLFile, ScoreControl.staAns.WordList[i].score);
                    }
                }

                for (i = 0; i < ScoreControl.staAns.ExcelList.Count; i++)
                {
                    fileName = StuList[RIndex].path.FullName + "\\e" + i.ToString() + ".xls";
                    if (File.Exists(fileName))
                    {
                        Score += ExcelScore.es.checkPoints(fileName, ScoreControl.staAns.ExcelList[i].OfficeFile, ScoreControl.staAns.ExcelList[i].XMLFile, ScoreControl.staAns.ExcelList[i].score);
                    }
                }
                for (i = 0; i < ScoreControl.staAns.PowerPointList.Count; i++)
                {
                    fileName = StuList[RIndex].path.FullName + "\\f" + i.ToString() + ".ppt";
                    if (File.Exists(fileName))
                    {
                        Score += PowerPointScore.ps.checkPoints(fileName, ScoreControl.staAns.PowerPointList[i].OfficeFile, ScoreControl.staAns.PowerPointList[i].XMLFile,ScoreControl.staAns.PowerPointList[i].score);
                    }
                }
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
                int i = 0;
                foreach (FileInfo f in new DirectoryInfo(path).GetFiles())
                {
                    if (f.Extension == ".rar")
                    {
                        string pass;
                        if (!File.Exists(path + "\\Key\\" + f.Name.Replace(".rar", "") + ".pwd"))
                        {
                            Directory.CreateDirectory(path + "\\" + f.Name.Replace(".rar", "") + "\\");
                            continue;
                        }
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
                    if (ScoreControl.config["PaperPath"].Last() != '\\')
                    {
                        ScoreControl.config["PaperPath"] = fbdPaperPath.SelectedPath + "\\";
                    }
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
            //MessageBox.Show(dtStuList.Rows.IndexOf(dvStuList[e.RowIndex].Row).ToString());
            if (e.RowIndex > -1)
            {
                int RIndex = dtStuList.Rows.IndexOf(dvStuList[e.RowIndex].Row);
                //MessageBox.Show(RIndex.ToString() + "  " + e.RowIndex.ToString());
                //MessageBox.Show()
                if (RIndex > -1)
                {
                    if (Convert.ToInt32(dtStuList.Rows[RIndex][5]) < 2)
                    {
                        StuList[RIndex].Score.Value = Mark(RIndex);
                        StuList[RIndex].state = ScoreState.Success;
                        dtStuList.Rows[RIndex][4] = StuList[RIndex].Score.Value;
                        dtStuList.Rows[RIndex][5] = ScoreState.Success;

                    }
                }
            }
        }

        /// <summary>
        /// 对所有试卷评分
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnScore_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < StuList.Count; i++)
            {
                if (Convert.ToInt32(dtStuList.Rows[i][5]) < 2)
                {
                    StuList[i].Score.Value = Mark(i);
                    StuList[i].state = ScoreState.Success;
                    dtStuList.Rows[i][4] = StuList[i].Score.Value;
                    dtStuList.Rows[i][5] = ScoreState.Success;
                }
                processBar.Value = (i + 1) * 100 / StuList.Count;
            }
        }

        /// <summary>
        /// 配置文件按钮。点击进入修改配置文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfig_Click(object sender, EventArgs e)
        {
            new ConfigForm().ShowDialog(this);
        }

        /// <summary>
        /// 载入按钮，点击载入试卷信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoad_Click(object sender, EventArgs e)
        {
            UncompressAllStudentAns(ScoreControl.config["PaperPath"]);
            LoadStudentList();
        }

        //导出成简易的Excel表格
        private void btnExport_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StringBuilder content = new StringBuilder();
                for (int i = 0; i < dtStuList.Rows.Count; i++)
                {
                    for (int j = 0; j < 6; j++)
                        content.Append(dtStuList.Rows[i][j] + "\t");
                    content.AppendLine();
                }
                using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName, false, Encoding.Default))
                {
                    sw.Write(content);
                }
            }
        }
    }
}
