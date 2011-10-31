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

namespace OESScore
{
    public partial class OESScore : Form
    {
        public DataTable dtPaperList = new DataTable();
        public List<PaperFolder> papers = new List<PaperFolder>();

        public OESScore()
        {
            InitializeComponent();
            tsslPath.Text = ScoreControl.config["PaperPath"];
            LoadPaperList();
        }

        public List<DirectoryInfo> GetPaper(string path)
        {

            return new DirectoryInfo(path).GetDirectories().ToList<DirectoryInfo>();
        }

        public void AddToDGV(string ID,string Name,string Progress,int count)
        {

            object[] values = new object[4];
            values[0] = ID;
            values[1] = Name;
            values[2] = Progress;
            values[3] = count;
            dgvPaperList.Rows.Add(values);
        }

        public void LoadPaperList()
        {
            List<DirectoryInfo> paperList;
            List<Paper> tmpP;
            PaperFolder tmpPF;
            paperList = GetPaper(ScoreControl.config["PaperPath"]);

            foreach (DirectoryInfo paper in paperList)
            {
                tmpPF = new PaperFolder();
                tmpP = ScoreControl.OesData.FindPaperById(paper.Name);
                if (tmpP != null)
                {
                    tmpPF.paperInfo = tmpP[0];
                    papers.Add(tmpPF);
                    AddToDGV(tmpPF.paperInfo.paperID, tmpPF.paperInfo.paperName, "0%", 10);
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {

        }

        private void btnSelectPath_Click(object sender, EventArgs e)
        {
            string path;

            fbdPaperPath.ShowDialog();
            ScoreControl.config["PaperPath"] = fbdPaperPath.SelectedPath;
            tsslPath.Text = ScoreControl.config["PaperPath"];
            LoadPaperList();
        }
    }
}
