using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OES.Model;

namespace OES.UPanel
{
    public partial class UserPanel : UserControl
    {
        public int PanelID;
        public UserPanel()
        {
            InitializeComponent();
        }

        virtual public void ReLoad()
        {
        }

        virtual public void ReLoad(int x)
        {
        }
        virtual public void HideAll()
        {
        }
        virtual public void ReLoad(Paper x)
        {
        }
        virtual public void ReLoad(int PID, int PType)
        {
        }
    }
}
