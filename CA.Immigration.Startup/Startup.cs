using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CA.Immigration.LMIA;

namespace CA.Immigration.Startup
{
    public partial class Startup : Form
    {
        public Startup()
        {
            InitializeComponent();
        }

        private void lMIAToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            LMIAForm lmiaForm=new LMIAForm();
            lmiaForm.Show();
        }
    }
}
