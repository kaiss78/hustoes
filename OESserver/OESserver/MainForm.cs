using System.Windows.Forms;
using OESserver.UPanel;

namespace OESserver
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            PaperInfo paperInfo=new PaperInfo();
            MainPanel.Controls.Add(paperInfo);
            paperInfo.Dock = DockStyle.Fill;
        }
    }
}