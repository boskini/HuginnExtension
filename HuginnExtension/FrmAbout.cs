using System;
using System.Windows.Forms;

namespace HuginnExtension
{
    public partial class FrmAbout : Form
    {
        public FrmAbout()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            var teste = System.IO.Directory.GetCurrentDirectory();
            var teste2 = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
            var teste3 = AppDomain.CurrentDomain.BaseDirectory;

            var tes = 1;
        }
    }
}
