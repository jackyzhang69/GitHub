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
            List<Education> edu = new List<Education>();
            edu.Add(new Education(2, "master’s level"));
            edu.Add(new Education(3, "two-year post-secondary credential"));
            
            PA pa = new PA() {
                age = 28,
                education = edu,
                ielts = new IELTS(9, 7.5f, 8f, 9f),
                secondlanguage=7,
                canadianWorkExperience=2,
                foreignWorkExperience=1
            };
            pa.calculate();
            MessageBox.Show(pa.totalPoints.ToString());

        }
    }
}
