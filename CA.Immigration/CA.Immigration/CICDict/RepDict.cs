using CA.Immigration.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CA.Immigration.Utility;


namespace CA.Immigration
{

    public partial class RepDict
    {

        //public Dictionary<string, string> outputDict;


        // Build a dictionary of IMM1294 based on the Application Id
        public static Dictionary<string, string> IMM5476(int ApplicantId,int RCICId)
        {
            CommonDataContext cmdc = new CommonDataContext();

            //int personId = (int)cmdc.tblApplications.Where(x => x.Id == ApplicantId).Select(x => x.ApplicantId).FirstOrDefault();
            //int rcicId = (int)cmdc.tblApplications.Where(x => x.Id == ApplicantId).Select(x => x.RCICId).FirstOrDefault();

            tblPerson person = cmdc.tblPersons.Where(x => x.Id == ApplicantId).Select(x => x).FirstOrDefault();
            tblRCIC rcic = cmdc.tblRCICs.Where(x => x.Id == RCICId).Select(x => x).FirstOrDefault();
            //tblPassport passport = cmdc.tblPassports.Where(x => (x.PersonId == ApplicantId && x.IsValid == true)).Select(x => x).FirstOrDefault();

            DateTime dob = (DateTime)person.DOB;
            
            int PAage = DateDiff.age(dob);

            Dictionary <string, string> dict = new Dictionary<string, string>()
            {
                ["IMM_5476[0].page1[0].Subform2[0].appoint[0]"] = "1",  // Appoint a rep
                ["IMM_5476[0].page1[0].Subform2[0].cancel[0]"] = "0", // Withdraw a rep
                ["IMM_5476[0].page1[0].#subform[0].familyName[0]"] = person.LastName,
                ["IMM_5476[0].page1[0].#subform[0].givenName[0]"] = person.FirstName,
                ["IMM_5476[0].page1[0].#subform[0].givenName1[0]"] = person.AliasFirstName,
                ["IMM_5476[0].page1[0].#subform[0].dateBirth[0]"] = String.Format("{0:yyyy-MM-dd}", dob),
                ["IMM_5476[0].page1[0].#subform[0].nameOffice[0]"] = "", // Visa office name
                ["IMM_5476[0].page1[0].#subform[0].type[0]"] = "", // application type
                ["IMM_5476[0].page1[0].#subform[0].clientId[0]"] = (person.UCI!= null)?person.UCI.ToString():"",
                ["IMM_5476[0].page1[0].Subform2[1].familyName[0]"] = rcic.LastName,
                ["IMM_5476[0].page1[0].Subform2[1].givenName[0]"] = rcic.FirstName,
                ["IMM_5476[0].page1[0].Subform2[1].isMember[0]"] = "1",  // Hard code to be ICCRC Member
                ["IMM_5476[0].page1[0].Subform2[1].memId[0]"] = rcic.MembershipID,
                ["IMM_5476[0].page2[0].Subform2[0].Subform3[0].nameFirm[0]"] = rcic.BusinessLegalName,
                ["IMM_5476[0].page2[0].Subform2[0].Subform3[0].mailAddress[0]"] = rcic.MailingAddress,
                ["IMM_5476[0].page2[0].Subform2[0].Subform3[0].mailAddress[1]"] = rcic.City,
                ["IMM_5476[0].page2[0].Subform2[0].Subform3[0].PostalcodeZIP[0]"] = rcic.PostalCode,
                ["IMM_5476[0].page2[0].Subform2[0].Subform3[0].Subform4[0].countryCode[0]"] = "1",
                ["IMM_5476[0].page2[0].Subform2[0].Subform3[0].Subform4[0].number[0]"] = rcic.Telephone,
                ["IMM_5476[0].page2[0].Subform2[0].Subform3[0].emailAddress[0]"] = rcic.Email,
                ["IMM_5476[0].page2[0].Subform2[0].date[0]"] = String.Format("{0:yyyy-MM-dd}", DateTime.Today),
                ["IMM_5476[0].page2[0].Subform2[2].date[0]"] = String.Format("{0:yyyy-MM-dd}", DateTime.Today),  //PA signing date
                ["IMM_5476[0].page2[0].Subform2[2].date[1]"] = (PAage < 19) ? String.Format("{0:yyyy-MM-dd}", DateTime.Today) : "" //if PA<19 years old, parents sign

            };

            return dict;
        }

        public static Dictionary<string, string> EMP5575(int AppId)
        {
            CommonDataContext cmdc = new CommonDataContext();

            // tblApplication has to be changed... to be adaptable for more applications
            int personId = (int)cmdc.tblApplications.Where(x => x.Id == AppId).Select(x => x.ApplicantId).FirstOrDefault();
            // and employer Id
            int rcicId = (int)cmdc.tblApplications.Where(x => x.Id == AppId).Select(x => x.RCICId).FirstOrDefault();

            tblPerson person = cmdc.tblPersons.Where(x => x.Id == personId).Select(x => x).FirstOrDefault();
            tblRCIC rcic = cmdc.tblRCICs.Where(x => x.Id == rcicId).Select(x => x).FirstOrDefault();
            tblPassport passport = cmdc.tblPassports.Where(x => (x.PersonId == personId && x.IsValid == true)).Select(x => x).FirstOrDefault();

            DateTime dob = DateTime.Parse(passport.DOB.ToString());

            int PAage = DateDiff.age(dob);

            Dictionary<string, string> dict = new Dictionary<string, string>()
            {
                
                //["IMM_5476[0].page2[0].Subform2[2].date[1]"] = (PAage < 19) ? String.Format("{0:yyyy-MM-dd}", DateTime.Today) : "" //if PA<19 years old, parents sign

            };

            return dict;
        }

    }
}
