using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Collections;
using OES.Model;
using OES;

namespace OESAnalyse
{
    public partial class OESAnalyse : Form
    {
        private FolderBrowserDialog fbd=new FolderBrowserDialog();
        private String path;
        private DirectoryInfo[] theFiles; 
        private DirectoryInfo firstFile;
        private List<FileInfo> results=new List<FileInfo>();
        private List<Student> students = new List<Student>();
        private List<string> stuIds = new List<string>();
       
        ScoreAnalyse sco = new ScoreAnalyse();
        private static OESData oesData = new OESData();
        public static OESData OesData
        {
            get
            {
                if (oesData == null) { oesData = new OESData(); }
                return OESAnalyse.oesData;
            }
            set { OESAnalyse.oesData = value; }
        }
        public OESAnalyse()
        {
            InitializeComponent();
        }

        private void PathBut_Click(object sender, EventArgs e)
        {
            string className = "";
            string examId = "";
            string stuId, paperId;

            if (fbd.ShowDialog().Equals(DialogResult.OK))
            {
                path = fbd.SelectedPath;
                firstFile = new DirectoryInfo(path);

                theFiles = firstFile.GetDirectories();
                if (theFiles != null)
                {
                    
                    for (int i = 0; i < theFiles.Length; i++)
                        if (theFiles[i].GetFiles("Result.xml").Length>0)
                            results.Add(theFiles[i].GetFiles("Result.xml")[0]);
                    for(int i=0;i<results.Count;i++)
                    {
                        sco.getSAndPId(results[i].FullName,out stuId,out paperId);
                        stuIds.Add(stuId);
                        students.Add(oesData.FindStudentByStudentId(stuIds[i])[0]);
                        students[i].examID = paperId;
                        while (students[i].className != className)
                        {
                            this.ClassCombo.Items.Add(students[i].className);
                            className = students[i].className;
                        }
                        while (students[i].examID != examId)
                        {
                            this.PaperCombo.Items.Add(students[i].examID);
                            examId = students[i].examID;
                        }
                    }
                }
            }

            
        }

        private void OrderCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (OrderCombo.SelectedIndex == 0)   
            {
                ClassCombo.Enabled = true;
                PaperCombo.Enabled = false;
            }
            else if (OrderCombo.SelectedIndex == 1)
            {
                PaperCombo.Enabled = true;
                ClassCombo.Enabled = false;
            } 
        }

        

    }
}
