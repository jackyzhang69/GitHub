using System;
using System.Collections.Generic;
using System.Linq;
using CA.Immigration.Data;

namespace CA.Immigration.SP
{
    public partial class SPDict
    {

        //public Dictionary<string, string> outputDict;


        // Build a dictionary of IMM1294 based on the Application Id
        public static Dictionary<string, string> IMM1294(int AppId)
        {
            SPDataContext spdc = new SPDataContext();
            CommonDataContext cmdc = new CommonDataContext();

            int personId = spdc.tblSPApplications.Where(x => x.Id == AppId).Select(x => x.PersonId).FirstOrDefault();
            tblPerson person = cmdc.tblPersons.Where(x => x.Id == personId).Select(x => x).FirstOrDefault();
            tblPassport passport = cmdc.tblPassports.Where(x=> (x.PersonId == personId && x.IsValid==true)).Select(x => x).FirstOrDefault();


            Dictionary<string, string> dict = new Dictionary<string, string>()
            {
                ["form1[0].Page1[0].PersonalDetails[0].ServiceIn[0].ServiceIn[0]"] ="0",  // Hard code in English
                //["form1[0].Page1[0].PersonalDetails[0].VisaType[0].VisaType[0]"] =
                ["form1[0].Page1[0].PersonalDetails[0].UCIClientID[0]"] =person.UCI.ToString(),
                ["form1[0].Page1[0].PersonalDetails[0].Name[0].FamilyName[0]"] =person.LastName,
                ["form1[0].Page1[0].PersonalDetails[0].Name[0].GivenName[0]"] =person.FirstName,
                ["form1[0].Page1[0].PersonalDetails[0].AliasName[0].AliasFamilyName[0]"] =(person.IsAliasName==false)?"":person.AliasLastName,
                ["form1[0].Page1[0].PersonalDetails[0].AliasName[0].AliasGivenName[0]"] = (person.IsAliasName == false) ? "" :person.AliasFirstName,
                ["form1[0].Page1[0].PersonalDetails[0].AliasName[0].AliasNameIndicator[0].AliasNameIndicator[0]"] = (person.IsAliasName == false) ? "N" :"Y",
                //["form1[0].Page1[0].PersonalDetails[0].Sex[0].Sex[0]"] =passport.GenderId, //should check
                ["form1[0].Page1[0].PersonalDetails[0].DOBYear[0]"] =passport.DOB.Value.Year.ToString(),
                ["form1[0].Page1[0].PersonalDetails[0].DOBMonth[0]"] =passport.DOB.Value.Month.ToString(),
                ["form1[0].Page1[0].PersonalDetails[0].DOBDay[0]"] =passport.DOB.Value.Day.ToString(),
                ["form1[0].Page1[0].PersonalDetails[0].PlaceBirthCity[0]"] =passport.BrithPlace,
                //["form1[0].Page1[0].PersonalDetails[0].PlaceBirthCountry[0]"] =passport.BirthCountry,
                ["form1[0].Page1[0].PersonalDetails[0].Citizenship[0].Citizenship[0]"] =passport.NationalityId.ToString(), // should check
                //["form1[0].Page1[0].PersonalDetails[0].CurrentCOR[0].Row2[0].Country[0]"] =
                //["form1[0].Page1[0].PersonalDetails[0].CurrentCOR[0].Row2[0].Status[0]"] =


            };

            return dict;
        }
    }
}
