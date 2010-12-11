using System.Windows.Forms;
using OESserver.UPanel;

namespace OESserver
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            ProMan aProMan = new ProMan();
            MainPanel.Controls.Add(aProMan);
        }
    }
}