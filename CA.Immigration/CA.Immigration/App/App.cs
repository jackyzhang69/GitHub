using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Immigration.App
{
    public class App
    {
        public int ApplicationID;
        public DateTime CreationDate { get; set; }
        public DateTime SubmissionDate { get; set; }
        public string ApplicationNumber { get; set; }

    }

    public class Followup
    {
        public int ApplicationID { get; set; }
        public string Requst { get; set; }
        public DateTime RequestDate { get; set; }
        public string Response { get; set; }
        public DateTime ResponseDate { get; set; }
    }

    public class LMIAApplication : App
    {
        public int  EmployerID { get; set; }
        public int EmployeeID { get; set; }
    }



}
