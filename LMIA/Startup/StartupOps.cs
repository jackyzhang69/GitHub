using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace Startup
{
    public class StartupOps
    {
        public static void startupInitialize(StartupForm sf)
        {
            // turn label things invisible
            sf.lblSelectedPerson.Visible = false;
            sf.lblSelectedPersonId.Visible = false;
            sf.lblSelectedEmployer.Visible = false;
            sf.lblSelectedEmployerId.Visible = false;

            using (CommonDataContext cdc = new CommonDataContext())
            {
                //Setup Category Inforamtion
                sf.cmbCategory.DataSource = cdc.tblCategories.Select(x => new { x.Name, x.Id });
                sf.cmbCategory.DisplayMember = "Name";
                sf.cmbCategory.ValueMember = "Id";
                sf.cmbProgram.DataSource = cdc.tblPrograms.Select(x => new { x.Name, x.Id });
                sf.cmbProgram.DisplayMember = "Name";
                sf.cmbProgram.ValueMember = "Id";
                sf.cmbProgram.SelectedIndex = 0;
                //Setup Program Information
                GlobalData.CurrentProgramId = sf.cmbProgram.SelectedIndex + 1;
                sf.cmbSelectRCIC.DataSource = cdc.tblRCICs.Where(x => x != null).Select(x => new { Id = x.Id, Prompt = x.FirstName + " " + x.LastName + "@" + x.BusinessLegalName });
                sf.cmbSelectRCIC.DisplayMember = "Prompt";
                sf.cmbSelectRCIC.ValueMember = "Id";
                sf.cmbSelectRCIC.SelectedIndex = 0;
                GlobalData.CurrentRCICId = cdc.tblRCICs.Select(x => x.Id).First();

                //Setup Marriage stauts               
                foreach (KeyValuePair<string, string> kvp in Definition.MarriageStatus) sf.cmbPBIMS.Items.Add(kvp.Value);
                foreach (KeyValuePair<int, string> kvp in Definition.Gender) sf.cmbPBIGender.Items.Add(kvp.Value);

            }

            getAllApplications(sf);
        }
        public static void getAllApplications(StartupForm sf)
        {
            // if no person or/and employer selected, display all applications
            // Get LMIA application 
            using (CommonDataContext cdc = new CommonDataContext())
            {
                sf.dgvLMIAApplication.DataSource = cdc.tblLMIAApplications.Select(x => new { ID = x.Id, Employer = x.EmployerId.getEmployerFromId(), Employee = (x.EmployeeId).getEmployeeFromId(), CreateDate = x.CreatedDate, SubmitDate = x.SubmittedDate, ApplicationNumber = x.ApplicationNumber, PositionNumber = x.NumberofPosition });
                sf.dgvLMIAApplication.Columns[0].Width = 35;
                sf.dgvLMIAApplication.Columns[1].Width = 185;
                sf.dgvLMIAApplication.Columns[2].Width = 110;
                sf.dgvLMIAApplication.Columns[3].Width = 80;
                sf.dgvLMIAApplication.Columns[4].Width = 80;
                sf.dgvLMIAApplication.Columns[5].Width = 85;
                sf.dgvLMIAApplication.Columns[6].Width = 85;
            }

            // Get ... application





        }
        public static void RefreshMainForm(StartupForm sf)
        {
            getAllApplications(sf);
            if (GlobalData.CurrentPersonId != null)
            {
                sf.lblSelectedPersonId.Text = GlobalData.CurrentPersonId.ToString();
                using (CommonDataContext cdc = new CommonDataContext())
                {
                    tblPerson p = cdc.tblPersons.Where(x => x.Id == GlobalData.CurrentPersonId).Select(x => x).FirstOrDefault();
                    sf.lblSelectedPerson.Text = p.FirstName + " " + p.LastName;
                }
                sf.lblSelectedPersonId.Visible = true;
                sf.lblSelectedPerson.Visible = true;
                // get Person Info
                Person.loadFromDB();
                Person.fillForm(sf);
                sf.btnPBIInsert.Visible = false;
            }
            else {
                Person.clearForm(sf);
                clearSelectedPerson(sf);
                sf.btnPBIInsert.Visible = true;
            }

            if (GlobalData.CurrentEmployerId != null)
            {
                sf.lblSelectedEmployerId.Text = GlobalData.CurrentEmployerId.ToString();
                using (CommonDataContext cdc = new CommonDataContext())
                {
                    tblEmployer e = cdc.tblEmployers.Where(x => x.Id == GlobalData.CurrentEmployerId).Select(x => x).FirstOrDefault();
                    sf.lblSelectedEmployer.Text = e.LegalName;
                }
                sf.lblSelectedEmployer.Visible = true;
                sf.lblSelectedEmployerId.Visible = true;
                Employer.loadFromDB();
                Employer.fillForm(sf);
                sf.btnEBIInsert.Visible = false;
            }
            else { Employer.clearForm(sf); clearSelectedEmployer(sf); sf.btnEBIInsert.Visible = true; }

        }

        public static void clearSelectedPerson(StartupForm sf)
        {
            sf.lblSelectedPerson.Text = null;
            sf.lblSelectedPersonId.Text = null;
        }
        public static void clearSelectedEmployer(StartupForm sf)
        {
            sf.lblSelectedEmployer.Text = null;
            sf.lblSelectedEmployerId.Text = null;
        }
        public static void buildupEMP5575()
        {
            Dictionary<string, string> dict5575 = new Dictionary<string, string>();

            //RCIC's company Information
            RCIC.buildupDict5575(ref dict5575);
            // Employer Information
            Employer.buildupDict5575(ref dict5575);
            // Employee information
            Person.buildupDict5575(ref dict5575);
            try
            {
                System.IO.File.Copy(App.Folders.DefaultFormFolder + @"\emp5575.pdf", App.Folders.DefaultLMIAFolder + App.Folders.ApplicationSubFolder + @"\emp5575.pdf", true);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            FormOPs.fillForm(App.Folders.DefaultLMIAFolder + App.Folders.ApplicationSubFolder + @"\emp5575.pdf", dict5575);
        }
        public static void buildupEMP5602()
        {

            Dictionary<string, string> dict5602 = new Dictionary<string, string>();

            // Analysis information
            LMIAAnalysis.buildupDict5602(ref dict5602);
            //Employer Information
            Employer.buildupDict5602(ref dict5602);
            //3rd party information
            RCIC.buildupDict5602(ref dict5602);
            // Business detail Information
            LMIABusinessDetail.buildupDict5602(ref dict5602);
            // Job offer information
            LMIAJobOffer.buildupDict5602(ref dict5602);


            try
            {
                System.IO.File.Copy(App.Folders.DefaultFormFolder + @"\emp5602.pdf", App.Folders.DefaultLMIAFolder + App.Folders.ApplicationSubFolder + @"\emp5602.pdf", true);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            FormOPs.fillForm(App.Folders.DefaultLMIAFolder + App.Folders.ApplicationSubFolder + @"\emp5602.pdf", dict5602);
        }
        public static void buildupEMP5593()
        {
            Dictionary<string, string> dict5593 = new Dictionary<string, string>();
            // Analysis information
            LMIAAnalysis.buildupDict5593(ref dict5593);
            //Employer Information
            Employer.buildupDict5593(ref dict5593);
            //3rd party information
            RCIC.buildupDict5593(ref dict5593);
            // Business detail Information
            LMIABusinessDetail.buildupDict5593(ref dict5593);
            // Job offer information
            JobAd.buildupDict5593(ref dict5593);
            // Job offer information
            LMIAJobOffer.buildupDict5593(ref dict5593);
            //Rcic info
            RCIC.buildupDict5593(ref dict5593);
            //Person Info
            Person.buildupDict5593(ref dict5593);
            try
            {
                System.IO.File.Copy(App.Folders.DefaultFormFolder+@"\emp5593.pdf", App.Folders.DefaultLMIAFolder + App.Folders.ApplicationSubFolder + @"\emp5593.pdf", true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

            FormOPs.fillForm(App.Folders.DefaultLMIAFolder+App.Folders.ApplicationSubFolder + @"\emp5593.pdf", dict5593);
        }
    }
}
