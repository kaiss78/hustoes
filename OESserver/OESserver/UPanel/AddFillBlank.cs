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
        public  int flag;//符号标志位，判断是添加试题还是查询试题
        public static int ProID;// 试题的编号
        public static List<string> addanswer = new List<string>(); //添加答案的List
        public static List<Answer_Of_FiilBlank> panel = new List<Answer_Of_FiilBlank>();
        public AddFillBlank()
        {
            InitializeComponent();
        }

        //添加试题的按钮
        private void AddButton_Click(object sender, EventArgs e)
        {
            Answer_Of_FiilBlank fillblanks = new Answer_Of_FiilBlank();
            this.flowLayoutPanel1.Controls.Add(fillblanks);//在flowlayoutpanle中添加一个小控件
            panel.Add(fillblanks);
        }

        //确定提交按钮
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            int capter = (this.Parent.Parent as AddQuetionPanel).Capter;
            int diffcuty = (this.Parent.Parent as AddQuetionPanel).Difficulity;

         
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
                if (flag == 0)//标志位为零，添加试题
                {
                    if (addanswer.Count > 0)
                    {
                        InfoControl.OesData.AddCompletion(contentOfFillblank.Text, Convert.ToInt32(capter), diffcuty, addanswer);
                        MessageBox.Show("保存成功");
                        this.ReLoad();
                    }
                    else MessageBox.Show("请添加试题答案");
                }
                if (flag == 1)//标志位为一，更改试题 
                {
                    
                    if (addanswer.Count > 0)
                    {
                        InfoControl.OesData.UpdateCompletion(ProID,contentOfFillblank.Text,capter,diffcuty,addanswer);
                        MessageBox.Show("保存成功");
                        this.ReLoad();
                        PanelControl.ChangPanel(0);
                        
                    }
                    else MessageBox.Show("请添加试题答案");
                }
                
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)//返回
        {
            if (MessageBox.Show("确定返回么？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                flowLayoutPanel1.Controls.Clear();
                panel.Clear();
                addanswer.Clear();
                PanelControl.ChangPanel(0);
            }
        }

        public override void ReLoad()//重新加载此界面，重置标志位
        {
            flag = 0;
            this.contentOfFillblank.Text = "";

            flowLayoutPanel1.Controls.Clear();
            addanswer.Clear();
            this.Visible = true;
        }

        public override void ReLoad(int PID)//根据pid寻找试题内容
        {
            
           ProID = PID;
       
           List<Completion> list_completion=InfoControl.OesData.FindCompletionByPID(PID);
         
              
           flag = 1;//将标志位变为1 进入  查询/更改  状态

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
