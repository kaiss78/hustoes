using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OES.UPanel;
using OES.Model;
using System.Collections;
namespace OES.UPanel
{
    
    public partial class AddFillBlank : UserPanel
    {
        public static int flag;
        public static int ProID;
        public static List<string> addanswer = new List<string>();
        public static List<Answer_Of_FiilBlank> panel = new List<Answer_Of_FiilBlank>();
        public AddFillBlank()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            Answer_Of_FiilBlank fillblanks = new Answer_Of_FiilBlank();
            this.flowLayoutPanel1.Controls.Add(fillblanks);
            panel.Add(fillblanks);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            int capter = (this.Parent.Parent as AddQuetionPanel).Capter;
            int diffcuty = (this.Parent.Parent as AddQuetionPanel).Difficulity;
            //String teststyle = (this.Parent.Parent as AddQuetionPanel).Teststyle;
            if ( contentOfFillblank.Text=="")
            {
                MessageBox.Show("请完成试题信息");
            }


            else if (MessageBox.Show("确定提交吗？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                foreach (Answer_Of_FiilBlank up in panel)
                {
                     
                    if(up.Visible==true&&up.getAnser!="")
                        addanswer.Add(up.getAnser);
                }
                if (flag == 0)
                {
                    if (addanswer.Count > 0)
                    {
                        InfoControl.OesData.AddCompletion(contentOfFillblank.Text, Convert.ToInt32(capter), diffcuty, addanswer);
                        MessageBox.Show("保存成功");
                        this.ReLoad();
                    }
                    else MessageBox.Show("请添加试题答案");
                }
                if (flag == 1)
                {
                    if (addanswer.Count > 0)
                    {
                        InfoControl.OesData.UpdateCompletion(ProID,contentOfFillblank.Text,capter,diffcuty,addanswer);
                        MessageBox.Show("保存成功");
                        this.ReLoad();
                    }
                    else MessageBox.Show("请添加试题答案");
                }
                
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定返回么？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                panel.Clear();
                addanswer.Clear();
                PanelControl.ChangPanel(0);
            }
        }

        public override void ReLoad()
        {
            flag = 0;
            this.contentOfFillblank.Text = "";

            flowLayoutPanel1.Controls.Clear();
            addanswer.Clear();
            this.Visible = true;
        }

        public override void ReLoad(int PID)
        {
           this.ReLoad();
           flag = 1;
           ProID = PID;
          (this.Parent.Parent as AddQuetionPanel).QueStyle = 2;
           List<Completion> list_completion=InfoControl.OesData.FindCompletionByPID(PID);
           (this.Parent.Parent as AddQuetionPanel).Capter = list_completion[0].unit.UnitId;
           (this.Parent.Parent as AddQuetionPanel).GetCbCourse = list_completion[0].unit.course.CourseId;
           (this.Parent.Parent as AddQuetionPanel).Difficulity = list_completion[0].Plevel;

           this.contentOfFillblank.Text = list_completion[0].problem;
           foreach (String ans in list_completion[0].ans)
           {
               Answer_Of_FiilBlank fillblanks = new Answer_Of_FiilBlank();
               this.flowLayoutPanel1.Controls.Add(fillblanks);
               panel.Add(fillblanks);
               fillblanks.getAnser = ans;
           }
           
           this.Visible = true;
           
        }

     

    }
}
