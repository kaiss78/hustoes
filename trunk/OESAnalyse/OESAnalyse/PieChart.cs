using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OES.Model;

namespace OESAnalyse
{
    public partial class PieChart : Form
    {
        private float[] scoDistri = new float[5];
        private float[] distribution = new float[5];
        private List<Student> students ;
        public PieChart(List<Student> stu)
        {
            InitializeComponent();
            
            students = stu;
            getDistri();

            

            for (int i = 0; i < 5; i++)
            {
                chart1.Series["Series1"].Points.AddXY(scoDistri[i]/students.Count, scoDistri[i]/students.Count);
                
            }    
        }

        public void getDistri()
        {
            for (int i = 0; i < students.Count; i++)
            {
                //scoDistri[0]是90分以上，接着是80至90,70至80,60至70和不及格
                if (Convert.ToInt32(students[i].password) >= 90)
                    scoDistri[0]++;
                else if (Convert.ToInt32(students[i].password) >= 80)
                    scoDistri[1]++;
                else if (Convert.ToInt32(students[i].password) >= 70)
                    scoDistri[2]++;
                else if (Convert.ToInt32(students[i].password) >= 60)
                    scoDistri[3]++;
                else
                    scoDistri[4]++;
            }
            for (int i = 0; i < 5; i++)
            {
                distribution[i] = scoDistri[i] / students.Count*100;
            }
        }
    }
}
