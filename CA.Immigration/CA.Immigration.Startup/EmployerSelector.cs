using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CA.Immigration;
using CA.Immigration.Data;

namespace CA.Immigration.Startup
{
    public partial class EmployerSelector : Form
    {
        StartupForm _sf;
        public EmployerSelector(StartupForm sf)
        {
            InitializeComponent();
            _sf = sf;
        }

        private void EmployerSelector_Load(object sender, EventArgs e)
        {
            using (LMIADCDataContext ld = new LMIADCDataContext())
            {
                dgvEmployer.DataSource = ld.tblEmployers.Select(x => new { Id = x.Id, OperatingName = x.OperatingName, Contact = x.ContactFirstName + " " + x.ContactLastName, Phone = x.ContactPhone, Email = x.ContactEmail, City = x.BizCity });

            }
            DataGridViewColumn ecolumn0 = dgvEmployer.Columns[0]; //Id
            ecolumn0.Width = 30;
            DataGridViewColumn ecolumn1 = dgvEmployer.Columns[1]; //Operating name
            ecolumn1.Width = 100;
            DataGridViewColumn ecolumn2 = dgvEmployer.Columns[2]; //Contact
            ecolumn2.Width = 100;
            DataGridViewColumn ecolumn3 = dgvEmployer.Columns[3]; //Contact phone
            ecolumn3.Width = 80;
            DataGridViewColumn ecolumn4 = dgvEmployer.Columns[4]; //Contact email
            ecolumn4.Width = 150;
            DataGridViewColumn ecolumn5 = dgvEmployer.Columns[5]; // City
            ecolumn5.Width = 65;
        }

        private void dgvEmployer_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (GlobalData.CurrentEmployerIdReadOnly == false)
            {
                GlobalData.CurrentEmployerId = int.Parse(dgvEmployer.SelectedRows[0].Cells[0].Value.ToString());
              //  GlobalData.CurrentEmployerIdReadOnly = true; // could be used after application is create. after application closed, set it to false
                _sf.RefreshMainForm();
                this.Close();
            }
            else MessageBox.Show("Someone is working on this employer.\nPlease finish that task and then work on this", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
    }

}
