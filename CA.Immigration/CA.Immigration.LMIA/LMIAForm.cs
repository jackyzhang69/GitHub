using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CA.Immigration.LMIA
{
    public partial class LMIAForm : Form
    {
        int _employerId;
        int _employeeId;

        public LMIAForm()
        {
            InitializeComponent();
        }
        public LMIAForm(int employerId, int employeeId)
        {
            InitializeComponent();
            _employerId = employerId;
            _employeeId = employeeId;
        }

        private void LMIAForm_Load(object sender, EventArgs e)
        {

            UCAppStream.lblAnotherEmployer.Visible = false;
            UCAppStream.txtAnotherEmployer.Visible = false;
        
        }
    }
}
