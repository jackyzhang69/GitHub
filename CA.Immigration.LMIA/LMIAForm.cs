using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CA.Immigration.Policy;
using CA.Immigration.Utility;
using CA.Immigration.Data;
using CA.Immigration.PDF;



namespace CA.Immigration.LMIA
{
    public partial class LMIAForm : Form
    {
        LMIAPolicy initApp = new LMIAPolicy();
        CommonDataContext dc = new CommonDataContext();

        public LMIAForm()
        {
            InitializeComponent();
        }

        private void LMIAForm_Load(object sender, EventArgs e)
        {
            

            stsEmployer.Text = "Employer has not bee assigned\t";
            stsEmployer.ForeColor = Color.Red;
            stsEmployee.Text = "Employee has not bee assigned\t";
            stsEmployee.ForeColor = Color.Red;
            stsAppId.Text = "Application has not been created";
            stsAppId.ForeColor = Color.Red;
            // Initialize Application Type
            for(int i = 0; i < initApp.LMIAType.Length; i++)
            {
                cmbApplicationType.Items.Add(initApp.LMIAType[i]);
            }
            // Initialize Stream Type
            for(int i = 0; i < initApp.LMIAStream.Length; i++)
            {
                cmbStream.Items.Add(initApp.LMIAStream[i]);
            }
            // Defalut: the another employer is invisible, unless skill trade selected
            ckbOtherEmployer.Visible = false;
            lblOtherEmployer.Visible = false;
            txtAnotherEmployer.Visible = false;


            dgvPositionQualification.DataSource = dc.tblMedias;

            // Initialize Province 
            for(int i = 0; i < Address.CndProvince.Length / 2; i++)
            {
                cmbProvince.Items.Add(Address.CndProvince[i, 0]);
            }
            cmbProvince.SelectedIndex = 1;  // Default is BC


            ////  example of media 
            //Media md = new Media();
            //md.MediaName = "Work Polis";
            //md.Scope = "National";
            //md.Type = "Commercial Website";
            //md.Cost = 0f;
            //md.Duration = 30;
            //md.Comments = "Good";
            
            DataGridViewCheckBoxColumn dcom = new DataGridViewCheckBoxColumn();
            dcom.HeaderText = "Pick";
            dgvMedia.Columns.Add(dcom);

            dgvMedia.DataSource = dc.tblMedias;


        }

        private void btnGoForPosting_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow dr in dgvMedia.Rows)
            {
                if(dr.Cells[0].Value != null && bool.Parse(dr.Cells[0].Value.ToString()))
                {

                    MessageBox.Show(dr.Cells[2].Value.ToString());
                }
                
            }
        }

        private void tbcADandMedia_Selecting(object sender, TabControlCancelEventArgs e)
        {
            // Check all information is ready
            // if ready, Generate Job Ad

            // now using Form variables to generate job ad
            StringBuilder jobAd = new StringBuilder();
            jobAd.AppendLine(txtJobTitle.Text+"\n");
            string locationofWork= "Location of Work: "+txtPOWork.Text+" "+txtAptWork.Text+" "+txtStreetNoWork+" "+txtStreetNameWork;
            jobAd.AppendLine(locationofWork);
            jobAd.AppendLine("Wage: " + txtHourlyRate.Text+"/Hour");
            jobAd.AppendLine("Term of Employment: " + txtEmploymentTerm.Text);

            txtJobAdPreview.Text = jobAd.ToString();

            PDFTools p=new PDFTools();
           // p.generatePDF(dc);


        }

      
     
    }
}

