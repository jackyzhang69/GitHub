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
            //BuildupDictionary EMP5593 = new BuildupDictionary(ApplicationId);
            FillForm.fillForm("EMP5593", BuildupDictionary.EMP5593(ApplicationId));
        }

        private void getValueToolStripMenuItem_Click(object sender, EventArgs e)
        {
           PDFTools.getXFAValue(BuildupDictionary.EMP5593(1));

            // to get value from pdf
        
        }
    }
}
