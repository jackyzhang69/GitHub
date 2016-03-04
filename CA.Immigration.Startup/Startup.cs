using System;
using System.Windows.Forms;
using CA.Immigration.LMIA;
using CA.Immigration.SP;
using CA.Immigration.PDF;
using CA.Immigration.Utility;
using System.Linq;
using CA.Immigration.Data;
using System.Data;
using System.Drawing;
using CA.Immigration.App;

namespace CA.Immigration.Startup
{
    public partial class StartupForm : Form
    {
        public int CurrentPersonId { get; set; }
        public int CurrentEmployerId { get; set; }

        public StartupForm()
        {
            InitializeComponent();
        }

        private void lMIAToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //LMIAForm lmiaForm=new LMIAForm(1,2,3);
            //lmiaForm.Show();
        }

        private void qIIPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ApplicationId = 1;
            FormOPs.fillForm(@"c:\vba\EMP5593.pdf", LMIADict.EMP5593(ApplicationId));
        }

        private void getValueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PDFTools.getXFAValue(LMIADict.EMP5593(1));

            // to get value from pdf

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            int[] ids = new int[] {4,17};
            FormOPs.IMM5476Sign i5476 = new FormOPs.IMM5476Sign(ids);
            FormOPs.fillForm(@"c:\vba\imm5476.pdf", RepDict.IMM5476(3));
            FormOPs.signForm(@"c:\vba\imm5476.pdf",i5476.getFormData());
        }



        private void Startup_Load(object sender, EventArgs e)
        {


          
            // turn label things invisible
            lblSelectPerson.Visible = false;
            lblSelectedPersonId.Visible = false;
            lblSelectedEmployer.Visible = false;
            lblSelectedEmployerId.Visible = false;

            using (CommonDataContext cdc = new CommonDataContext())
            {
                cmbCategory.DataSource = cdc.tblCategories.Select(x => new { x.Name, x.Id });
                cmbCategory.DisplayMember = "Name";
                cmbCategory.ValueMember = "Id";
                cmbProgram.DataSource = cdc.tblPrograms.Select(x => new { x.Name, x.Id });
                cmbProgram.DisplayMember = "Name";
                cmbProgram.ValueMember = "Id";
                cmbPBIMS.DataSource = cdc.tblMarriageStatusTypes.Select(x => x.MarriageStatusType);

            }


            getAllApplications();
        }

        private void getAllApplications()
        {

            // if no person or/and employer selected, display all applications




        }
        private void getAllApplications(int personId, int employerId)
        {



            // if person or/employer selected, display all selected person/employer's applications


        }

        //private void getAllPersons(string personName) // get all persons matching the searching criteria
        //{
        //    using (CommonDataContext cdc = new CommonDataContext())
        //    {
        //        dgvPerson.DataSource = from p in cdc.tblPersons
        //                               join pp in cdc.tblPassports
        //                               on p.Id equals pp.PersonId
        //                               select new
        //                               {
        //                                   FirstName = p.FirstName,
        //                                   LastName = p.LastName,
        //                                   DOB = p.DOB,
        //                                   Nationality = pp.NationalityId.Value.countryToString(),
        //                                   UCI = p.UCI,
        //                                   Gender = pp.GenderId.Value.genderToString()
        //                               };
        //    }
        //}
        private void getAllPersons()
        {
            //using (CommonDataContext cdc = new CommonDataContext())
            //{
            //    dgvPerson.DataSource = from p in cdc.tblPersons
            //                           join pp in cdc.tblPassports
            //                           on p.Id equals pp.PersonId
            //                           select new
            //                           {
            //                               FirstName = p.FirstName,
            //                               LastName = p.LastName,
            //                               DOB = p.DOB,
            //                               Nationality = pp.NationalityId.Value.countryToString(),
            //                               UCI = p.UCI,
            //                               Gender = pp.GenderId.Value.genderToString()
            //                           };
            //}
        }

        //private void getAllEmployers(string empName)
        //{
        //    using (LMIADCDataContext ld = new LMIADCDataContext())
        //    {
        //        dgvEmployer.DataSource = from emp in ld.tblEmployers
        //                                 select new { emp.Id, emp.OperatingName, emp.ContactPhone, emp.ContactFirstName, emp.ContactLastName, emp.ContactEmail };

        //    }
        //}
        //private void getAllEmployers()
        //{
        //    using (LMIADCDataContext ld = new LMIADCDataContext())
        //    {
        //        dgvEmployer.DataSource = from emp in ld.tblEmployers
        //                                 select new { emp.Id, emp.OperatingName, emp.ContactPhone, emp.ContactFirstName, emp.ContactLastName, emp.ContactEmail };

        //    }
        //}


        //private void dgvPerson_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    lblSelectPerson.Text = "You picked: " + dgvPerson.Rows[e.RowIndex].Cells[1].Value.ToString();
        //    lblSelectPerson.Visible = true;
        //    lblSelectPerson.ForeColor = Color.FromArgb(50, 70, 190);
        //    lblSelectedPersonId.Text = "Person Id: " + dgvPerson.Rows[e.RowIndex].Cells[0].Value.ToString();
        //    lblSelectedPersonId.Visible = true;
        //    lblSelectedPersonId.ForeColor = Color.FromArgb(50, 70, 190);
        //}

        //private void dgvEmployer_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    lblSelectedEmployer.Text = "You picked: " + dgvEmployer.Rows[e.RowIndex].Cells[1].Value.ToString();
        //    lblSelectedEmployer.Visible = true;
        //    lblSelectedEmployer.ForeColor = Color.FromArgb(50, 70, 190);
        //    lblSelectedEmployerId.Text = "Employer Id: " + dgvEmployer.Rows[e.RowIndex].Cells[0].Value.ToString();
        //    lblSelectedEmployerId.Visible = true;
        //    lblSelectedEmployerId.ForeColor = Color.FromArgb(50, 70, 190);
        //}

        //private void txtFirstName_TextChanged(object sender, EventArgs e)
        //{
        //    TextBox textBox = sender as TextBox;

        //    getThePersons();

        //}

        private void getThePersons()
        {
            using (CommonDataContext cdc = new CommonDataContext())
            {
                //IQueryable<tblPerson> queryableData = cdc.tblPersons.AsQueryable<tblPerson>();
                //string query = "cd.tblPersons";


                //dgvPerson.DataSource = cdc.tblPersons
                //    .Where(sqr)
                //    .Select(x => new { Id = x.Id, Name = x.FirstName + " " + x.LastName, Gender = x.Gender, DOB = x.DOB, Phone = x.Phone, Email = x.Email }); 
            }
        }

        private void btnCreatePerson_Click(object sender, EventArgs e)
        {
            Form ps = new PersonSelector(this);
            ps.Show();
        }

        private void btnPBIInsert_Click(object sender, EventArgs e)
        {
            using (CommonDataContext cdc = new CommonDataContext())
            {
                tblPerson p = new tblPerson
                {
                    FirstName = txtPBIfn.Text,
                    MiddleName = txtPBImn.Text,
                    LastName = txtPBIln.Text,
                    DOB = dtpPBIDOB.Value,
                    Gender = cmbPBIGender.SelectedIndex,
                    IsAliasName = cbxAlias.Checked ? true : false,
                    AliasLastName = txtPBIAFN.Text,
                    AliasFirstName = txtPBIALN.Text,
                    UCI = txtPBIUCI.Text,
                    MarriageStatusId = cmbPBIMS.SelectedIndex.ToString(),
                    Phone = txtPBIPhone.Text,
                    Email = txtPBIEmail.Text
                };
                try
                {
                    cdc.tblPersons.InsertOnSubmit(p);
                    cdc.SubmitChanges();
                    int Id = p.Id; // get new Id of inserted person
                    lblPDIPPPersonId.Text = Id.ToString();
                    lblPDIPPPeronName.Text = cdc.tblPersons.Where(x => x.Id == Id).Select(x => (x.FirstName + " " + x.LastName)).FirstOrDefault();
                    btnInsertPassport.Visible = true;
                }
                catch (Exception exc)
                {

                    MessageBox.Show(exc.Message);
                }



            }
        }

        private void btnInsertPassport_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("PassportNumber"));
            dt.Columns.Add(new DataColumn("Name"));
            dt.Columns.Add(new DataColumn("GenderId"));
            dt.Columns.Add(new DataColumn("BirthCountryId"));
            dt.Columns.Add(new DataColumn("NationalityId"));
            dt.Columns.Add(new DataColumn("DOB"));
            dt.Columns.Add(new DataColumn("BrithPlace"));
            dt.Columns.Add(new DataColumn("IssueDate"));
            dt.Columns.Add(new DataColumn("IssuePlace"));
            dt.Columns.Add(new DataColumn("ExpiryDate"));
            dt.Columns.Add(new DataColumn("IssueCountryId"));
            dt.Columns.Add(new DataColumn("IsValid"));
            dgvPassport.DataSource = dt;



        }
        public void RefreshMainForm()
        {
            if (GlobalData.CurrentPersonId != null)
            {
                lblSelectedPersonId.Text = GlobalData.CurrentPersonId.ToString();
                using (CommonDataContext cdc = new CommonDataContext())
                {
                    tblPerson p = cdc.tblPersons.Where(x => x.Id == GlobalData.CurrentPersonId).Select(x => x).FirstOrDefault();
                    lblSelectPerson.Text = p.FirstName + " " + p.LastName;

                }
                lblSelectedPersonId.Visible = true;
                lblSelectPerson.Visible = true;
                lblSelectedPersonId.ForeColor = Color.FromArgb(50, 70, 190);
                lblSelectPerson.ForeColor = Color.FromArgb(50, 70, 190);
            }

            if (GlobalData.CurrentEmployerId != null)
            {
                lblSelectedEmployerId.Text = GlobalData.CurrentEmployerId.ToString();
                using (LMIADCDataContext ld = new LMIADCDataContext())
                {
                    tblEmployer e = ld.tblEmployers.Where(x => x.Id == GlobalData.CurrentEmployerId).Select(x => x).FirstOrDefault();
                    lblSelectedEmployer.Text = e.LegalName;
                }
                lblSelectedEmployer.Visible = true;
                lblSelectedEmployerId.Visible = true;
                lblSelectedEmployer.ForeColor = Color.FromArgb(50, 70, 190);
                lblSelectedEmployerId.ForeColor = Color.FromArgb(50, 70, 190);
            }

        }

        private void btnSelectEmployer_Click(object sender, EventArgs e)
        {
            EmployerSelector es = new EmployerSelector(this);
            es.Show();
        }

        

     

        private void cmbCategory_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GlobalData.CurrentCategoryId=int.Parse(cmbCategory.SelectedValue.ToString());
            using (CommonDataContext cdc = new CommonDataContext())
            {
                int id = int.Parse(cmbCategory.SelectedValue.ToString());
                if (cdc.tblPrograms.Where(x => x.CategoryId == id).Select(x => x.Name) != null)
                    cmbProgram.DataSource = cdc.tblPrograms.Where(x => x.CategoryId == id).Select(x => x.Name);
                else
                {
                    cmbProgram.SelectedIndex =-1;
                    cmbProgram.Text = "";
                }

            }
        }

        private void btnApplication_Click(object sender, EventArgs e)
        {
            // call functions based on program selected 
            GlobalData.CurrentStreamIdReadOnly = true;  // disable changing application id
            switch (GlobalData.CurrentStreamId) {
                case (int)GlobalData.AppStream.LMIAPRandWP:
                    LMIAApplicationForm lmiaform = new LMIAApplicationForm((int)GlobalData.CurrentEmployerId, (int)GlobalData.CurrentEmployerId);  //int appId,int employerId, int personId
                    lmiaform.Show();
                    break;
                default:
                    break;
            }

        }

        private void cmbProgram_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GlobalData.CurrentStreamId = int.Parse(cmbProgram.SelectedValue.ToString());
        }
    }
}
