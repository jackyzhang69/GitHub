using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CA.Immigration.Utility;

namespace CA.Immigration.Policy
{
    public class LMIAPolicy
    {
        private int _JobAdAmount = 3;
       // private int _JobAdType = 3;
        public string Title { get; set; }
        public char[] NOC { get; set; }
        public float LocalNOCMedianWage { get; set; }
        public float ProvincialMedianWage { get; set; }
        public float Wage { get; set; }
        public float WorkingHours { get; set; }

        public float UnemploymentRate { get; set; }
        public int COPSIndicator { get; set; } // 3,2,1,0 is star indicator, express the labour shortage. 3 is short, 1 is surplus, 0 is no data

        public string[,] JobDuties { get; set; } // The position's mainduties
        public string [,] NOCMainDuties { get; set; } //The main duties listed in ESDC NOC description
        
        public string[,]  NOCQualification { get; set; } // the qualification listed in ESDC NOC description

        public string OperatingName { get; set; }
        public Address BusinessAddress { get; set; }
        public Address WorkingLocation { get; set; }
        public Address MailingAddress { get; set; }
        public string TermsofEmployment { get; set; }
        public string[]  BenefitPackage { get; set; } // multiple choices
        public ContactInfo Contact { get; set; }

        // The position's qualification requirement
        public string[] EducationRequirement { get; set; }
        public string[] SkillRequirement { get; set; }
        public string[] WorkExperienceRequirement { get; set; }
        public string[] LanguageRequirement { get; set; }

        public string[] LMIAType = new string[] {

            "For PR Only",
            "For PR & Work Permit",
            "For Work Permit"
        };

        public string[] LMIAStream = new string[] {

            "High Wage Stream",
            "Low Wage Stream",
            "Skilled Trade"
        };





        public bool JobAdAmountValid(int JobAdAmount) {
            if(JobAdAmount >= _JobAdAmount) return true;
            else return false;
        }




    }

    public class LMIA_PR : LMIAPolicy
    {

    }
    public class LMIA_WP : LMIAPolicy
    {

    }

   
}
