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
            EEFormOps.getInput(this);
            EEFormOps.refreshScore(this);
        }

        private void txtAge_Leave(object sender, EventArgs e)
        {
            EEFormOps.getInput(this);
            EEFormOps.refreshScore(this);
        }

        private void cmbHighestEdu_SelectionChangeCommitted(object sender, EventArgs e)
        {
            EEFormOps.getInput(this);
            EEFormOps.refreshScore(this);
        }

        private void text_Leave(object sender, EventArgs e)
        {
            EEFormOps.getInput(this);
            EEFormOps.refreshScore(this);
        }

        private void chkCofQ_CheckedChanged(object sender, EventArgs e)
        {
            EEFormOps.getInput(this);
            EEFormOps.refreshScore(this);
        }

        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('\r'))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void btnEEGenerateReport_Click(object sender, EventArgs e)
        {
            EEFormOps.getInput(this);
            EEFormOps.refreshScore(this);
            EEFormOps.getReport();
        }

        private void cmbSPLanguageType_SelectedIndexChanged(object sender, EventArgs e)
        {
            EEFormOps.getInput(this);
            EEFormOps.refreshScore(this);
        }

        private void ckbEduInCa_CheckedChanged(object sender, EventArgs e)
        {
                EEFormOps.getInput(this);
                EEFormOps.refreshScore(this);
        }
    }
}
