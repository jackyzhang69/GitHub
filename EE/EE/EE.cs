using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EE
{
    public partial class EE : Form
    {
        public EE()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            EEFormOps.getInput(this);
            EEFormOps.refreshScore(this);
        }

        private void EE_Load(object sender, EventArgs e)
        {
            EEFormOps.Construct(this);
            
        }

        private void EE_TextChanged(object sender, EventArgs e)
        {
            EEFormOps.getInput(this);
            EEFormOps.refreshScore(this);
        }

        private void chkSingle_CheckedChanged(object sender, EventArgs e)
        {
            grpSP.Visible = chkSingle.Checked ? false : true;
            grpSPFactors.Visible = chkSingle.Checked ? false : true;        
            EEFormOps.getInput(this);
            EEFormOps.refreshScore(this);
        }


        private void chkSecondLanguage_CheckedChanged(object sender, EventArgs e)
        {
            grpSecondLanguage.Visible = chkSecondLanguage.Checked ? true : false;
        }
    }
}
