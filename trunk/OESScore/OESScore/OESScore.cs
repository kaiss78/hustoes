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
            InitList();
        }

        public List<DirectoryInfo> GetPaper(string path)
        {

            return new DirectoryInfo(path).GetDirectories().ToList<DirectoryInfo>();
        }

        public void InitList()
        {

            object[] values = new object[4];
            values[0] = "fafd";
            values[1] = "11";
            values[2] = false;
            values[3] = "11";
            dgvPaperList.Rows.Add(values);
            dgvPaperList.Rows.Add(values);
            dgvPaperList.Rows.Add(values);
        }
        private void btnBack_Click(object sender, EventArgs e)
        {

        }

        private void btnSelectPath_Click(object sender, EventArgs e)
        {
            string path;
            List<DirectoryInfo> paperList;
            List<Paper> tmpP;
            PaperFolder tmpPF;
            fbdPaperPath.ShowDialog();
            ScoreControl.config["PaperPath"] = fbdPaperPath.SelectedPath;
            tsslPath.Text = ScoreControl.config["PaperPath"];
            paperList = GetPaper(ScoreControl.config["PaperPath"]);

            foreach (DirectoryInfo paper in paperList)
            {
                tmpPF = new PaperFolder();
                tmpP = ScoreControl.OesData.FindPaperById(paper.Name);
                if (tmpP != null)
                {
                    tmpPF.paperInfo = tmpP[0];
                    papers.Add(tmpPF);
                }
            }
        }
    }
}
