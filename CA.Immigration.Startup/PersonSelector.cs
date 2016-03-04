using CA.Immigration.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CA.Immigration.Startup
{
    public partial class PersonSelector : Form
    {
        StartupForm sf;
        public PersonSelector(StartupForm mainform)
        {
            InitializeComponent();
            sf = mainform;
        }

        private void PersonSelector_Load(object sender, EventArgs e)
        {
            using (CommonDataContext cdc=new CommonDataContext()) {
                 dgvPerson.DataSource = cdc.tblPersons.Select(x => new { Id = x.Id, Name = x.FirstName + " " + x.LastName, Gender = x.Gender, DOB = x.DOB, Phone = x.Phone, Email = x.Email });
                DataGridViewColumn pcolumn0 = dgvPerson.Columns[0]; //Id
                pcolumn0.Width = 30;
                DataGridViewColumn pcolumn1 = dgvPerson.Columns[1]; // Name
                pcolumn1.Width = 100;
                DataGridViewColumn pcolumn2 = dgvPerson.Columns[2]; //Gender
                pcolumn2.Width = 50;
                DataGridViewColumn pcolumn3 = dgvPerson.Columns[3]; //DOB
                pcolumn3.Width = 65;
                DataGridViewColumn pcolumn4 = dgvPerson.Columns[4]; // Phone
                pcolumn4.Width = 100;
                DataGridViewColumn pcolumn5 = dgvPerson.Columns[5]; //Email
                pcolumn5.Width = 200;
            }
        }

        //private void dgvPerson_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        //{
          
        //}

        private void dgvPerson_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (GlobalData.CurrentPersonIdReadOnly == false)
            {
                //GlobalData.CurrentPersonIdReadOnly = true;  // use it after application is created
                GlobalData.CurrentPersonId = int.Parse(dgvPerson.SelectedRows[0].Cells[0].Value.ToString()); //get Person ID
                sf.RefreshMainForm();
                this.Close();
            }
            else MessageBox.Show("Someone is working with current person. \nPlease finish that task then do it again.","Message",MessageBoxButtons.OK,MessageBoxIcon.Error);
            
         }
    }
}
