using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OESMonitor.Model;

namespace OESMonitor
{
    public partial class Computer : UserControl
    {
        private static List<Computer> computerList = new List<Computer>();
       
        private int state=0;

        public int State
        {
            get 
            {
                return state; 
            }
            set 
            {

                switch (value)
                {
                    case 0:
                        this.Invoke(new MethodInvoker(() =>
                        { 
                            ico.BackgroundImage = Properties.Resources.s0; 
                            lab.Text = "未启动";
                            
                        }));
                        break;
                    case 1:
                        this.Invoke(new MethodInvoker(() =>
                        {
                            ico.BackgroundImage = Properties.Resources.s1;
                            lab.Text = "未登录";
                            
                        }));
                        break;
                    case 2:
                        this.Invoke(new MethodInvoker(() =>
                        {
                            ico.BackgroundImage = Properties.Resources.s2;
                            lab.Text = "已登录";
                            
                        }));
                        break;
                    case 3:
                        this.Invoke(new MethodInvoker(() =>
                        {
                            ico.BackgroundImage = Properties.Resources.s3;
                            lab.Text = "考试中";
                            
                        }));
                        break;
                    case 4:
                        this.Invoke(new MethodInvoker(() =>
                        {
                            ico.BackgroundImage = Properties.Resources.s4;
                            lab.Text = "已交卷";
                            
                        }));
                        break;
                    default:
                        this.Invoke(new MethodInvoker(() =>
                        {
                            ico.BackgroundImage = Properties.Resources.s0;
                            lab.Text = "未启动";
                            
                        }));
                        break;
                        

                }
                
                state = value; 
            }
        }
        private Net.Client client;

        public Net.Client Client
        {
            get 
            {
                return client; 
            }
            set 
            {
                client = value;
                client.computer = this;
            }
        }

        private Student student = new Student("", "", "", "");

        public Student Student
        {
            get 
            {
                return student; 
            }
            set 
            { 
                student = value;
                StuLabel.Invoke(new MethodInvoker(() => { StuLabel.Text = student.ID; }));
                
            }
        }
        public Computer()
        {
            InitializeComponent();
            
        }

        private void Computer_MouseClick(object sender, MouseEventArgs e)
        {
            foreach (Computer c in computerList)
            {
                c.BorderStyle = BorderStyle.None;
            }
            this.BorderStyle = BorderStyle.FixedSingle;
            ComputerState.getInstance().setStudent(student);
            ComputerState.getInstance().setState(lab.Text);
            ComputerState.getInstance().setIpPort(client.clientInfo().Split(':')[0], Convert.ToInt32(client.clientInfo().Split(':')[1]));
        }
        public static void Add(Computer c)
        {
            computerList.Add(c);
        }
    }
}
