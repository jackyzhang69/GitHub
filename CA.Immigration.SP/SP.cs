using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CA.Immigration.Data;

namespace CA.Immigration.SP
{
    public partial class SP : Form
    {
        public SP()
        {
            InitializeComponent();
        }

        private void SP_Load(object sender, EventArgs e)
        {
            using(CommonDataContext cdc = new CommonDataContext()) {
               
            }

        }
    }
}
