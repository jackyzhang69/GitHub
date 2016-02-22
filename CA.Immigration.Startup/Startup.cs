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
using CA.Immigration.SP;
using CA.Immigration.PDF;


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

        private void qIIPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ApplicationId = 1;
            FillForm.fillForm("EMP5593", LMIADict.EMP5593(ApplicationId));
        }

        private void getValueToolStripMenuItem_Click(object sender, EventArgs e)
        {
           PDFTools.getXFAValue(LMIADict.EMP5593(1));

            // to get value from pdf
        
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FillForm.fillForm("IMM1294", SPDict.IMM1294(1));
        }
    }
}
