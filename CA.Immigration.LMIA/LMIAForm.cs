using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CA.Immigration.Policy;
using CA.Immigration.Utility;
using CA.Immigration.Data;
using CA.Immigration.PDF;



namespace CA.Immigration.LMIA
{
    public partial class LMIAApplicationForm : Form
    {
        LMIAPolicy initApp = new LMIAPolicy();
        private int _appId;
        private int _employerId;
        private int _personId;


        public LMIAApplicationForm()
        {
            InitializeComponent();
        }

        public LMIAApplicationForm(int employerId)
        {
            InitializeComponent();
            _employerId = employerId;
        }
        public LMIAApplicationForm(int employerId, int personId)
        {
            InitializeComponent();
            _employerId = employerId;
            _personId = personId;
        }
        public LMIAApplicationForm(int appId, int employerId, int personId)
        {
            InitializeComponent();
            _appId = appId;
            _employerId = employerId;
            _personId = personId;
        }


        private void LMIAForm_Load(object sender, EventArgs e)
        {
            

            stsEmployer.Text = GlobalData.CurrentEmployerId==null?"Employer has not bee assigned\t":"Employer Id="+GlobalData.CurrentEmployerId.ToString();
            stsEmployer.ForeColor = GlobalData.CurrentEmployerId == null ? Color.Red:Color.Green;
            stsEmployee.Text = GlobalData.CurrentPersonId == null ? "Employee has not bee assigned\t" : "Employee Id=" + GlobalData.CurrentPersonId.ToString();
            stsEmployee.ForeColor = GlobalData.CurrentPersonId==null?Color.Red:Color.Green;
            stsAppId.Text = GlobalData.CurrentApplicationId == null ? "Application has not been created" : "Application Id=" + GlobalData.CurrentApplicationId.ToString();
            stsAppId.ForeColor = Color.Red;
            // Initialize Application Type
            using (CommonDataContext cdc = new CommonDataContext())
            {
                txtProgram.Text = cdc.tblPrograms.Where(x => x.Id == GlobalData.CurrentStreamId).Select(x => x.Name).Single();
                txtProgram.ReadOnly = true;
                dgvPositionQualification.DataSource = cdc.tblMedias;
            }
            
            // Initialize Stream Type
            for(int i = 0; i < initApp.LMIAStream.Length; i++)
            {
                cmbStream.Items.Add(initApp.LMIAStream[i]);
            }
            // Default: the another employer is invisible, unless skill trade selected
            ckbOtherEmployer.Visible = false;
            lblOtherEmployer.Visible = false;
            txtAnotherEmployer.Visible = false;



            

            // Initialize Province 
            for(int i = 0; i < Address.CndProvince.Length / 2; i++)
            {
                cmbProvince.Items.Add(Address.CndProvince[i, 0]);
            }
            cmbProvince.SelectedIndex = 1;  // Default is BC

            using(LMIADCDataContext ld = new LMIADCDataContext()) {
                dgvEmployer.DataSource = from emp in ld.tblEmployers
                                         select new {emp.LegalName,emp.MailingAddress,emp.BizCity,emp.ContactPhone};
            }

            ////  example of media 
            //Media md = new Media();
            //md.MediaName = "Work Polis";
            //md.Scope = "National";
            //md.Type = "Commercial Website";
            //md.Cost = 0f;
            //md.Duration = 30;
            //md.Comments = "Good";
            
            //DataGridViewCheckBoxColumn dcom = new DataGridViewCheckBoxColumn();
            //dcom.HeaderText = "Pick";
            //dgvMedia.Columns.Add(dcom);

            //dgvMedia.DataSource = dc.tblMedias;

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

