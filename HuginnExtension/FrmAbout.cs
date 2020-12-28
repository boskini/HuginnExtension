using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Build.Evaluation;

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
