using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Immigration.Utility
{
    public class Address
    {
        public string Country { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }

        public string POBox { get; set; }
        public string AptUnit { get; set; }
        public string StreetNo { get; set; }
        public string StreetName { get; set; }

        public string getStreetAddress()
        {
            if(POBox != string.Empty && AptUnit != string.Empty)
                return POBox + ", " + AptUnit + ", " + StreetNo + " " + StreetName;
            else if(POBox != string.Empty) return POBox + ", " + StreetNo + " " + StreetName;
            else if(AptUnit != string.Empty) return AptUnit + ", " + StreetNo + " " + StreetName;
            else return StreetNo + " " + StreetName;
        }

        public string getFullAddress()
        {
            if(POBox != string.Empty && AptUnit != string.Empty)
                return POBox + ", " + AptUnit + ", " + StreetNo + " " + StreetName + "," + City + ", " + Province + ", " + Country + " " + PostalCode;
            else if(POBox != string.Empty) return POBox + " " + StreetNo + " " + StreetName + "," + City + ", " + Province + ", " + Country + " " + PostalCode;
            else if(AptUnit != string.Empty) return AptUnit + " " + StreetNo + " " + StreetName + "," + City + ", " + Province + ", " + Country + " " + PostalCode;
            else return StreetNo + " " + StreetName + "," + City + ", " + Province + ", " + Country + " " + PostalCode;

        }

        public static string[,] CndProvince = new string[,] {

        {"AB","Alberta" },
        {"BC","British Columbia"},
        {"MB","Manitoba" },
        {"NB"," New Brunswick" },
        {"NL","Newfoundland and Labrador" },
        {"NS","Nova Scotia" },
        {"NT","Northwest Territories" },
        {"NU","Nunavut" },
        {"ON","Ontario"},
        {"PE","Prince Edward Island" },
        {"QC","Quebec" },
        {"SK","Saskatchewan" },
        {"YT","Yukon" }
        };
    }

    public class ContactInfo
    {
        public string Telephone { get; set; }
        public string Cellphone { get; set; }
        public string Email { get; set; }
        public string Fax { get; set; }
        public Address ContactAddress { get; set; }


    }


    public class Media
    {

        public string MediaName { get; set; }
        public string Type { get; set; }   // Official, Commercial website, Industrial Specific, Classfic, Social Media, Employer website,underrepresented people targeted
        public string Scope { get; set; }  // National or Local
        public float Cost { get; set; }
        public int Duration { get; set; }  // how many days the Ad will be posted
        public string Comments { get; set; }  // Comments about the media


        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public bool IsPrinted { get; set; }  // Remind if the AD is printed out
        public int ProvenDuration { get; set; } // Make sure the duration is valid

      
    }

    




}
