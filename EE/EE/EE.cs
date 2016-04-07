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
            //List<Education> edu = new List<Education>();
            //edu.Add(new Education(2, "master’s level"));
            //edu.Add(new Education(3, "two-year post-secondary credential"));

            //Person pa = new Person() {
            //    age = 28,
            //    education = edu,
            //    married = true,
            //    applicant="PA",
            //    ielts = new IELTS(9, 7.5f, 8f, 9f),
            //    tef = new TEF(250, 380, 280, 350),
            //    //secondlanguage=7,
            //    canadianWorkExperience = 2,
            //    foreignWorkExperience = 1,
            //    CofQ = true

            //};
            //pa.calculate();

            //Person sp = new Person()
            //{
            //    age = 28,
            //    education = edu,
            //    married = true,
            //    applicant = "SP",
            //    ielts = new IELTS(9, 7.5f, 8f, 9f),
            //    tef = new TEF(250, 380, 280, 350),
            //    //secondlanguage=7,
            //    canadianWorkExperience = 2,
            //    foreignWorkExperience = 1,
            //    CofQ = true

            //};
            //sp.calculate();
            //MessageBox.Show("Pa total:"+pa.totalPoints.ToString()+",Sp total: "+sp.totalPoints.ToString()+",Total:"+(pa.totalPoints+sp.totalPoints).ToString());
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
            EEFormOps.PA.married = chkSingle.Checked ? false : true;
            EEFormOps.SP.married = chkSingle.Checked ? false : true;
        }

        private void chkSecondEdu_CheckedChanged(object sender, EventArgs e)
        {
            grpSecondEdu.Visible = chkSecondEdu.Checked ? true : false;
        }

        private void chkSecondLanguage_CheckedChanged(object sender, EventArgs e)
        {
            grpSecondLanguage.Visible = chkSecondLanguage.Checked ? true : false;
        }
    }
}
