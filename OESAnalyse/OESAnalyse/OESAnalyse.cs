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
using System.Xml;

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
        private Boolean classFirst = true;
        DataTable myTable = new DataTable();
        ScoreAnalyse sco = new ScoreAnalyse();
        List<Student>myList=new List<Student>();
        

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
            this.panel1.Visible = false;
        }

        private void PathBut_Click(object sender, EventArgs e)
        {
            List<string> className = new List<string>();
            List<string> examId = new List<string>();
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
                        students[i].password = Convert.ToString(sco.getScore(results[i].FullName));
                        while (!className.Contains(students[i].className))
                        {
                            className.Add(students[i].className);
                            this.ClassCombo.Items.Add(students[i].className);
                        }
                        while (!examId.Contains(students[i].examID))
                        {
                            examId.Add(students[i].examID);
                            this.PaperCombo.Items.Add(students[i].examID);
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
                classFirst = true;
            }
            else if (OrderCombo.SelectedIndex == 1)
            {
                dataGridView1.DataSource = null;
                dataGridView1.Refresh();
                PaperCombo.Enabled = true;
                ClassCombo.Enabled = false;
                classFirst = false;
            } 
        }


        private void ClassCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> papers = new List<string>();
            if (this.PaperCombo.Enabled == true && this.ClassCombo.Enabled == true)
            {
                //传List<Student>
                printOut(findStuByCAP(Convert.ToString(this.ClassCombo.SelectedItem), Convert.ToString(this.PaperCombo.SelectedItem)));
            }
            if (classFirst)
            {
                this.PaperCombo.Items.Clear();
                papers = findPIdByClassId(Convert.ToString(this.ClassCombo.SelectedItem));
                for (int i = 0; i < papers.Count; i++)
                {
                    this.PaperCombo.Items.Add(papers[i]);
                }
                this.PaperCombo.Enabled = true;
            }
            
        }


        //根据班级寻找当前目录下该班级所考试卷id
        public List<string> findPIdByClassId(string className)
        {
            List<string> paperIds = new List<string>();
            for (int i = 0; i < students.Count; i++)
            {
                while (students[i].className == className && !paperIds.Contains(students[i].examID))
                {
                    paperIds.Add(students[i].examID);
                }
            }
            return paperIds;

        }
        public List<Prob> findProbID(string rootPath, string pID) 
        {
            List<Prob> stuProb=new List<Prob>(); 
            DirectoryInfo root = new DirectoryInfo(path);
            DirectoryInfo[] stu = root.GetDirectories("*");
            for (int j = 0; j < stu.Length; j++)
            {
                FileInfo[] result = stu[j].GetFiles("Result*");
                if (result.Length == 1)
                {
                    XmlDocument document = new XmlDocument();
                    document.Load(result[0].FullName);
                    XmlNode root1 = document.DocumentElement;
                    if (root1.FirstChild.Attributes["paperId"].Value == pID) 
                    {
                        XmlNode node, node1;
                        node = root1.FirstChild.FirstChild;
                        do
                        {
                            node1 = node.FirstChild;
                            for (int i = 0; i <= 9; i++)
                            {
                                Prob aProb=new Prob ();
                                aProb.problemType = node.Name;
                                aProb.problemID = Convert.ToInt16(node1.InnerText);
                                stuProb.Add(aProb);
                                node1 = node1.NextSibling.NextSibling;
                            }
                            node = node.NextSibling;
                        }
                        while (node.FirstChild!=null);
                    }  
                    break;
                    
                }
            }
            return (stuProb);
        }


        public  void printOut(List<Student> myList)
        {
            object[] newRow=new object[5];
            myTable = new DataTable("paper");
            myTable.Columns.Add("学号");
            myTable.Columns.Add("姓名");
            myTable.Columns.Add("班级");
            myTable.Columns.Add("试卷名称");
            myTable.Columns.Add("成绩");

            for (int i = 0; i <myList.Count; i++)
            {
                
                newRow[0] = myList[i].ID;
                newRow[1] = myList[i].sName;
                newRow[2] = myList[i].className;
                newRow[3] = myList[i].examID;
                newRow[4] = myList[i].password;
                myTable.Rows.Add(newRow);
            }
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.DataSource = myTable.DefaultView;
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ReadOnly = true;
        }

        //根据试卷寻找当前目录下班级
        public List<string> findCNByPaperId(string paperId)
        {
            List<string> classNames = new List<string>();
            for (int i = 0; i < students.Count; i++)
            {
                while (students[i].examID == paperId && !classNames.Contains(students[i].className))
                {
                    classNames.Add(students[i].className);
                }
            }
            return classNames;
        }
        //根据试卷id和班级寻找学生
        public List<Student> findStuByCAP(string className, string paperId)
        {
            List<Student> stus = new List<Student>();
            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].className == className && students[i].examID == paperId)
                {
                    stus.Add(students[i]);
                }
            }
            return stus;
        }


        private void PaperCombo_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            List<string> classes = new List<string>();
            if (this.PaperCombo.Enabled == true && this.ClassCombo.Enabled == true)
            {
                //传List<Student>
                printOut(findStuByCAP(Convert.ToString(this.ClassCombo.SelectedItem), Convert.ToString(this.PaperCombo.SelectedItem)));
            }
            if (!classFirst)
            {
                this.ClassCombo.Items.Clear();
                classes = findCNByPaperId(Convert.ToString(this.PaperCombo.SelectedItem));
                for (int i = 0; i < classes.Count; i++)
                {
                    this.ClassCombo.Items.Add(classes[i]);
                }
                this.ClassCombo.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            object[] newRow = new object[4];
            this.panel1.Visible = true;
            DataTable paperTable = new DataTable();
            paperTable.Columns.Add("试题ID");
            paperTable.Columns.Add("试题类型");
            paperTable.Columns.Add("题干");
            paperTable.Columns.Add("分值");
            List<Prob> newProb = new List<Prob>();
            newProb = findProbID(path, Convert.ToString(this.PaperCombo.SelectedItem));
            for (int i = 0; i < newProb.Count; i++)
            {
                if (newProb[i].problemType == "Choice")
                {
                    List<Choice> aChoice = new List<Choice>();
                    aChoice = oesData.FindChoiceByPID(newProb[i].problemID);
                    if (aChoice.Count == 0)
                    {
                        newRow[0] = newProb[i].problemID;
                        newRow[1] = newProb[i].problemType;
                        newRow[2] = "题目已丢失";
                        newRow[3] = "";
                    }
                    else
                    {
                        newRow[0] = newProb[i].problemID;
                        newRow[1] = "Choice";
                        newRow[2] = aChoice[0].problem;
                        newRow[3] = aChoice[0].score;
                    }
                }
                else if (newProb[i].problemType == "Completion")
                {
                    List<Completion> aCompletion = new List<Completion>();
                    aCompletion = oesData.FindCompletionByPID(newProb[i].problemID);
                    if (aCompletion.Count == 0)
                    {
                        newRow[0] = newProb[i].problemID;
                        newRow[1] = newProb[i].problemType;
                        newRow[2] = "题目已丢失";
                        newRow[3] = "";
                    }
                    else
                    {
                        newRow[0] = newProb[i].problemID;
                        newRow[1] = newProb[i].problemType;
                        newRow[2] = aCompletion[0].problem;
                        newRow[3] = aCompletion[0].score;
                    }
                }
                else if (newProb[i].problemType == "Judgment")
                {
                    List<Judgment> aJudgment = new List<Judgment>();
                    aJudgment = oesData.FindJudgmentByPID(newProb[i].problemID);
                    if (aJudgment.Count == 0)
                    {
                        newRow[0] = newProb[i].problemID;
                        newRow[1] = newProb[i].problemType;
                        newRow[2] = "题目已丢失";
                        newRow[3] = "";
                    }
                    else
                    {
                        newRow[0] = newProb[i].problemID;
                        newRow[1] = newProb[i].problemType;
                        newRow[2] = aJudgment[0].problem;
                        newRow[3] = aJudgment[0].score;
                    }
                }
                paperTable.Rows.Add(newRow);

            }
            dataGridView3.RowHeadersVisible = false;
            dataGridView3.DataSource = paperTable.DefaultView;
            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView3.ReadOnly = true;
        }

        private void backButn_Click(object sender, EventArgs e)
        {
            this.panel1.Visible = false;
        }

        private void CorrectBut_Click(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = null;
            //this.dataGridView1.Refresh();
            object[] newRow = new object[3];
            Percentage newPercentage = new Percentage();
            ArrayList list = new ArrayList();
            List<Student> stu = new List<Student>();
            stu = findStuByCAP(Convert.ToString(ClassCombo.SelectedItem), Convert.ToString(PaperCombo.SelectedItem));
            list = newPercentage.printPercentage(path, stu, this.PaperCombo.SelectedText);
            myTable = new DataTable();
            myTable.Columns.Add("试题类型");
            myTable.Columns.Add("试题ID");
            myTable.Columns.Add("正确率");
            for (int i = 2; i <= list.Count; i++)
            {

                newRow[0] = ((Percentage)list[i - 1]).type;
                newRow[1] = ((Percentage)list[i - 1]).ID;
                newRow[2] = ((Percentage)list[i - 1]).percentage;
                myTable.Rows.Add(newRow);
            }
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.DataSource = myTable.DefaultView;
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ReadOnly = true;

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void ScoreDistriBut_Click(object sender, EventArgs e)
        {
            PieChart pie = new PieChart(findStuByCAP(Convert.ToString(this.ClassCombo.SelectedItem), Convert.ToString(this.PaperCombo.SelectedItem)));
            pie.Visible = true;
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ProblemForm pf = new ProblemForm();
            String ProType=Convert.ToString(this.dataGridView3.Rows[this.dataGridView3.CurrentRow.Index].Cells[1].Value);
            String ProName=Convert.ToString(this.dataGridView3.Rows[this.dataGridView3.CurrentRow.Index].Cells[2].Value);
            int ProID=Convert.ToInt16(this.dataGridView3.Rows[this.dataGridView3.CurrentRow.Index].Cells[0].Value);
            pf.newTextBox.Multiline = true;
            pf.newTextBox.WordWrap = true;
            if ( ProType == "Choice") 
            {
                String output;
                if (ProName != "题目已丢失")
                {
                    List<Choice> newChoice = new List<Choice>();
                    output = "题目：" + ProName + "\r\n";
                    newChoice = oesData.FindChoiceByPID(ProID);
                    output += "A." + newChoice[0].optionA + "\r\n";
                    output += "B." + newChoice[0].optionB + "\r\n";
                    output += "C." + newChoice[0].optionC + "\r\n";
                    output += "D." + newChoice[0].optionD + "\r\n";
                    output += "答案：" + newChoice[0].ans;
                    pf.newTextBox.Text = output;
                }
                else 
                { 
                    output = "题目不存在";
                    pf.newTextBox.Text = output;
                }
            }
            else if (ProType == "Completion") 
            {
                String output;
                if (ProName != "题目已丢失")
                {
                    List<Completion> newCompletion = new List<Completion>();
                    output = "题目：" + ProName + "\r\n";
                    newCompletion = oesData.FindCompletionByPID(ProID);
                    for (int i = 0; i < newCompletion[0].ans.Count; i++)
                    {
                        output += "答案：" + newCompletion[0].ans[i] + "\r\n";
                    }
                    pf.newTextBox.Text = output;
                }
                else 
                {
                    output = "题目不存在";
                    pf.newTextBox.Text = output;
                }
            }
            else if (ProType == "Judgment") 
            {
                String output;
                if (ProName != "题目已丢失")
                {
                    List<Judgment> newJudgment = new List<Judgment>();
                    output = "题目：" + ProName + "\r\n";
                    newJudgment = oesData.FindJudgmentByPID(ProID);
                    output += "答案：" + newJudgment[0].ans;
                    pf.newTextBox.Text = output;
                }
                else 
                {
                    output = "题目不存在";
                    pf.newTextBox.Text = output;
                }
            }
            else if (ProType == "Word") 
            {
                String output;
                if (ProName != "题目已丢失")
                {

                }
                else 
                {
                    output = "题目不存在";
                    pf.newTextBox.Text = output;
                }
            }
      
            pf.newTextBox.ReadOnly = true;
            pf.Visible = true;
            
        }

        private void ConfigBut_Click(object sender, EventArgs e)
        {
            new ConfigForm().ShowDialog(this);
        }

        private void ExcelBut_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog=new SaveFileDialog();
            saveFileDialog.Filter = "Excel files(*.xls)|*.xls";
             if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StringBuilder content = new StringBuilder();
                for (int i = 0; i < myTable.Rows.Count; i++)
                {
                    for (int j = 0; j < myTable.Columns.Count; j++)
                        content.Append(myTable.Rows[i][j] + "\t");
                    content.AppendLine();
                }
                using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName, false, Encoding.Default))
                {
                    sw.Write(content);
                }
            }
        }

        private void OESAnalyse_Load(object sender, EventArgs e)
        {

        }

       

    }
}
