using System;
using System.Collections.Generic;
using System.Linq;
using CA.Immigration.Data;
using CA.Immigration.Utility;
using System.IO;

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

            int personId = (int)cmdc.tblApplications.Where(x => x.Id == AppId).Select(x => x.ApplicantId).FirstOrDefault();
            tblPerson person = cmdc.tblPersons.Where(x => x.Id == personId).Select(x => x).FirstOrDefault();
            tblPassport passport = cmdc.tblPassports.Where(x => (x.PersonId == personId && x.IsValid == true)).Select(x => x).FirstOrDefault();
            int rcicId=(int) cmdc.tblApplications.Where(x => x.Id == AppId).Select(x => x.RCICId).FirstOrDefault();
            tblRCIC rcic = cmdc.tblRCICs.Where(x => x.Id == rcicId).Select(x => x).FirstOrDefault();
            tblResidence currentRes = cmdc.tblResidences.Where(x => (x.ApplicationId == AppId && x.ResidenceType == 1)).Select(x => x).FirstOrDefault();
            List<tblResidence> previousRes = cmdc.tblResidences.Where(x => (x.ApplicationId == AppId && (x.ResidenceType == 2 || x.ResidenceType == 3))).Select(x => x).ToList();
            tblLanguage lgg = cmdc.tblLanguages.Where(x => x.PersonId == personId).Select(x => x).FirstOrDefault();
            List<tblMarriageHistory> mrghistory = cmdc.tblMarriageHistories.Where(x => x.PersonId == personId).Select(x => x).ToList();
            tblAddress address = cmdc.tblAddresses.Where(x => (x.PersonId == personId) && x.AddressTypeId=="Residential").Select(x => x).FirstOrDefault();
            tblPhone phone = cmdc.tblPhones.Where(x => x.PersonId == personId).Select(x => x).FirstOrDefault();

            tblStudyInfo std = spdc.tblStudyInfos.Where(x => x.ApplicationId == AppId).Select(x => x).FirstOrDefault();



            Dictionary<string, string> dict = new Dictionary<string, string>()
            {
                ["form1[0].Page1[0].PersonalDetails[0].ServiceIn[0].ServiceIn[0]"] = "01",  // Hard code in English
                //["form1[0].Page1[0].PersonalDetails[0].VisaType[0].VisaType[0]"] =
                ["form1[0].Page1[0].PersonalDetails[0].UCIClientID[0]"] = person.UCI.ToString(),
                ["form1[0].Page1[0].PersonalDetails[0].Name[0].FamilyName[0]"] = person.LastName,
                ["form1[0].Page1[0].PersonalDetails[0].Name[0].GivenName[0]"] = person.FirstName,
                ["form1[0].Page1[0].PersonalDetails[0].AliasName[0].AliasFamilyName[0]"] = (person.IsAliasName == false) ? "" : person.AliasLastName,
                ["form1[0].Page1[0].PersonalDetails[0].AliasName[0].AliasGivenName[0]"] = (person.IsAliasName == false) ? "" : person.AliasFirstName,
                ["form1[0].Page1[0].PersonalDetails[0].AliasName[0].AliasNameIndicator[0].AliasNameIndicator[0]"] = (person.IsAliasName == false) ? "N" : "Y",
                ["form1[0].Page1[0].PersonalDetails[0].Sex[0].Sex[0]"] = (passport.GenderId.HasValue) ? passport.GenderId.Value.genderToString() : "", //should check
                ["form1[0].Page1[0].PersonalDetails[0].DOBYear[0]"] = passport.DOB.Value.Year.ToString(),
                ["form1[0].Page1[0].PersonalDetails[0].DOBMonth[0]"] = passport.DOB.Value.Month.ToString(),
                ["form1[0].Page1[0].PersonalDetails[0].DOBDay[0]"] = passport.DOB.Value.Day.ToString(),
                ["form1[0].Page1[0].PersonalDetails[0].PlaceBirthCity[0]"] = passport.BrithPlace,
                ["form1[0].Page1[0].PersonalDetails[0].PlaceBirthCountry[0]"] = passport.BirthCountryId.ToString(),
                ["form1[0].Page1[0].PersonalDetails[0].Citizenship[0].Citizenship[0]"] = passport.NationalityId.ToString(), // should check
                ["form1[0].Page1[0].PersonalDetails[0].CurrentCOR[0].Row2[0].Country[0]"] = currentRes.CountryId.ToString(),
                ["form1[0].Page1[0].PersonalDetails[0].CurrentCOR[0].Row2[0].Status[0]"] = currentRes.StatusId.ToString(),
                ["form1[0].Page1[0].PersonalDetails[0].CurrentCOR[0].Row2[0].Other[0]"] = currentRes.OtherStatus,
                ["form1[0].Page1[0].PersonalDetails[0].CurrentCOR[0].Row2[0].FromDate[0]"] = String.Format("{0:yyyy-MM-dd}", currentRes.StartDate),
                ["form1[0].Page1[0].PersonalDetails[0].CurrentCOR[0].Row2[0].ToDate[0]"] = String.Format("{0:yyyy-MM-dd}", currentRes.EndDate),
                // Previous residence and country where applying use addtional way to process
                // Marriage:  
                ["form1[0].Page1[0].MaritalStatus[0].SectionA[0].MaritalStatus[0]"] = person.MarriageStatusId.ToString(),

                // Language
                ["form1[0].Page2[0].MaritalStatus[0].SectionA[0].Languages[0].languages[0].nativeLang[0].nativeLang[0]"] = lgg.NativeLanguageId,
                ["form1[0].Page2[0].MaritalStatus[0].SectionA[0].Languages[0].languages[0].lov[0].lov[0]"] = lgg.OtherMostlyUse,
                ["form1[0].Page2[0].MaritalStatus[0].SectionA[0].Languages[0].languages[0].ableToCommunicate[0]"] = lgg.CommIn,
                ["form1[0].Page2[0].MaritalStatus[0].SectionA[0].Languages[0].LanguageTest[0]"] = (lgg.LanguageTest == true) ? "Y" : "N",

                //Passport
                ["form1[0].Page2[0].MaritalStatus[0].SectionA[0].Passport[0].PassportNum[0].PassportNum[0]"] = passport.PassportNumber,
                ["form1[0].Page2[0].MaritalStatus[0].SectionA[0].Passport[0].CountryofIssue[0].CountryofIssue[0]"] = passport.IssueCountryId,
                ["form1[0].Page2[0].MaritalStatus[0].SectionA[0].Passport[0].IssueDate[0].IssueDate[0]"] = String.Format("{0:yyyy-MM-dd}", passport.IssueDate),
                ["form1[0].Page2[0].MaritalStatus[0].SectionA[0].Passport[0].ExpiryDate[0]"] = String.Format("{0:yyyy-MM-dd}", passport.ExpiryDate),
                //["form1[0].Page2[0].MaritalStatus[0].SectionA[0].Passport[0].IssueYYYY[0]"] =
                //["form1[0].Page2[0].MaritalStatus[0].SectionA[0].Passport[0].IssueMM[0]"] =
                //["form1[0].Page2[0].MaritalStatus[0].SectionA[0].Passport[0].IssueDD[0]"] =
                //["form1[0].Page2[0].MaritalStatus[0].SectionA[0].Passport[0].expiryYYYY[0]"] =
                //["form1[0].Page2[0].MaritalStatus[0].SectionA[0].Passport[0].expiryMM[0]"] =
                //["form1[0].Page2[0].MaritalStatus[0].SectionA[0].Passport[0].expiryDD[0]"] =

                //Mailing Address
                ["form1[0].Page2[0].contact[0].AddressRow1[0].POBox[0].POBox[0]"] = rcic.MailPO, //rcic address
                ["form1[0].Page2[0].contact[0].AddressRow1[0].Apt[0].AptUnit[0]"] = rcic.MailAptUnit,
                ["form1[0].Page2[0].contact[0].AddressRow1[0].StreetNum[0].StreetNum[0]"] = rcic.MailStreetNo,
                ["form1[0].Page2[0].contact[0].AddressRow1[0].Streetname[0].Streetname[0]"] = rcic.MailStreetName,
                ["form1[0].Page2[0].contact[0].AddressRow2[0].CityTow[0].CityTown[0]"] = rcic.City,
                ["form1[0].Page2[0].contact[0].AddressRow2[0].Country[0].Country[0]"] = rcic.Country.countryToCode().ToString(),
                ["form1[0].Page2[0].contact[0].AddressRow2[0].ProvinceState[0].ProvinceState[0]"] = rcic.Province,
                ["form1[0].Page2[0].contact[0].AddressRow2[0].PostalCode[0].PostalCode[0]"] = rcic.PostalCode,
                ["form1[0].Page2[0].contact[0].AddressRow2[0].District[0]"] = "",

                // Residential address   
                //QUESTION? how to operate related pick box

                ["form1[0].Page2[0].contact[0].SameAsMailingIndicator[0]"] = (address != null) ? "N" : "Y",
                ["form1[0].Page2[0].contact[0].ResidentialAddressRow1[0].AptUnit[0].AptUnit[0]"] = address.Unit,
                ["form1[0].Page2[0].contact[0].ResidentialAddressRow1[0].StreetNum[0].StreetNum[0]"] = address.StreetNo,
                ["form1[0].Page2[0].contact[0].ResidentialAddressRow1[0].StreetName[0].Streetname[0]"] = address.StreetName,
                ["form1[0].Page2[0].contact[0].ResidentialAddressRow1[0].CityTown[0].CityTown[0]"] = address.City,
                ["form1[0].Page2[0].contact[0].ResidentialAddressRow2[0].Country[0].Country[0]"] = address.CountryCode,
                ["form1[0].Page2[0].contact[0].ResidentialAddressRow2[0].ProvinceState[0].ProvinceState[0]"] = (address.CountryCode != "511") ? "" : address.CNDProvinceId.ToString(), //need check
                ["form1[0].Page2[0].contact[0].ResidentialAddressRow2[0].PostalCode[0].PostalCode[0]"] = address.PostalCode,
                ["form1[0].Page2[0].contact[0].ResidentialAddressRow2[0].District[0]"] = address.District,

                // Telephone
                ["form1[0].Page2[0].contact[0].PhoneNumbers[0].Phone[0].Type[0]"] = phone.PhoneType,
                ["form1[0].Page2[0].contact[0].PhoneNumbers[0].Phone[0].CanadaUS[0]"] = phone.USorCa,
                ["form1[0].Page2[0].contact[0].PhoneNumbers[0].Phone[0].Other[0]"] = phone.Other,
                ["form1[0].Page2[0].contact[0].PhoneNumbers[0].Phone[0].NumberExt[0]"] = phone.Extension,
                ["form1[0].Page2[0].contact[0].PhoneNumbers[0].Phone[0].NumberCountry[0]"] = phone.CountryCode,
                ["form1[0].Page2[0].contact[0].PhoneNumbers[0].Phone[0].ActualNumber[0]"] = phone.PhoneNumber,
                //["form1[0].Page2[0].contact[0].PhoneNumbers[0].Phone[0].NANumber[0].AreaCode[0]"] =
                //["form1[0].Page2[0].contact[0].PhoneNumbers[0].Phone[0].NANumber[0].FirstThree[0]"] =
                //["form1[0].Page2[0].contact[0].PhoneNumbers[0].Phone[0].NANumber[0].LastFive[0]"] =
                //["form1[0].Page2[0].contact[0].PhoneNumbers[0].Phone[0].IntlNumber[0].IntlNumber[0]"] =
                ["form1[0].Page2[0].contact[0].PhoneNumbers[0].AltPhone[0].Type[0]"] = "Business",
                ["form1[0].Page2[0].contact[0].PhoneNumbers[0].AltPhone[0].CanadaUS[0]"] = "1",
                ["form1[0].Page2[0].contact[0].PhoneNumbers[0].AltPhone[0].Other[0]"] = "0",
                ["form1[0].Page2[0].contact[0].PhoneNumbers[0].AltPhone[0].NumberExt[0]"] = "",
                ["form1[0].Page2[0].contact[0].PhoneNumbers[0].AltPhone[0].NumberCountry[0]"] = "1",
                ["form1[0].Page2[0].contact[0].PhoneNumbers[0].AltPhone[0].ActualNumber[0]"] = rcic.Telephone,
                ["form1[0].Page2[0].contact[0].PhoneNumbers[0].AltPhone[0].NANumber[0].AreaCode[0]"] = rcic.Telephone.Substring(0, 3),
                ["form1[0].Page2[0].contact[0].PhoneNumbers[0].AltPhone[0].NANumber[0].FirstThree[0]"] = rcic.Telephone.Substring(3, 3),
                ["form1[0].Page2[0].contact[0].PhoneNumbers[0].AltPhone[0].NANumber[0].LastFive[0]"] = rcic.Telephone.Substring(6),
                //["form1[0].Page2[0].contact[0].PhoneNumbers[0].AltPhone[0].IntlNumber[0].IntlNumber[0]"] =
                //["form1[0].Page2[0].contact[0].FaxEmail[0].Phone[0].CanadaUS[0]"] =
                //["form1[0].Page2[0].contact[0].FaxEmail[0].Phone[0].Other[0]"] =

                //Email
                ["form1[0].Page2[0].contact[0].FaxEmail[0].Email[0]"] = rcic.Email,

                // Details of intended study in Canada
                ["form1[0].Page2[0].DetailsOfStudy[0].PurposeRow1[0].schoolName[0].SchoolName[0]"] = std.SchoolName,
                //["form1[0].Page2[0].DetailsOfStudy[0].PurposeRow1[0].schoolName[0].Program[0]"] = std.FieldId,
                //["form1[0].Page2[0].DetailsOfStudy[0].PurposeRow1[0].schoolName[0].Level[0]"] =
                //["form1[0].Page2[0].DetailsOfStudy[0].PurposeRow1[0].ProvinceState[0].Prov[0]"] =
                //["form1[0].Page2[0].DetailsOfStudy[0].PurposeRow1[0].CityTown[0].CityTown[0]"] = std.CityId,
                ["form1[0].Page2[0].DetailsOfStudy[0].PurposeRow1[0].Address[0].Address[0]"] = std.SchoolAddress,
                ["form1[0].Page2[0].DetailsOfStudy[0].PurposeRow1[0].HowLongStudy[0].FromDate[0]"] = String.Format("{0:yyyy-MM-dd}", std.FromDate),
                ["form1[0].Page2[0].DetailsOfStudy[0].PurposeRow1[0].HowLongStudy[0].ToDate[0]"] = String.Format("{0:yyyy-MM-dd}", std.Todate),
                ["form1[0].Page2[0].DetailsOfStudy[0].PurposeRow1[0].DLI[0]"] = std.DLINumber,
                ["form1[0].Page2[0].DetailsOfStudy[0].PurposeRow1[0].StudentNo[0]"] = std.StudentId,
                ["form1[0].Page3[0].Contacts_Row1[0].tuition[0].amount[0]"] = std.Tuition.ToString(),
                ["form1[0].Page3[0].Contacts_Row1[0].roomBoard[0].amount[0]"] = std.RoomAndBoard.ToString(),
                ["form1[0].Page3[0].Contacts_Row1[0].other[0].amount[0]"] = std.Othercost.ToString(),
                ["form1[0].Page3[0].Contacts_Row1[0].expensesPaid[0].Funds[0].Funds[0]"] = std.FundsAvailable.ToString(),
                //["form1[0].Page3[0].Contacts_Row1[0].expensesPaid[0].expensesPaidBy[0]"] =std.WhoPayId,  // check
                ["form1[0].Page3[0].Contacts_Row1[0].expensesPaid[0].Other[0]"] =std.OtherPayer,





            };

            // Process previous residence and country where applying records
            tblResidence tr = cmdc.tblResidences.Where(x => (x.ApplicationId == AppId && x.ResidenceType == 3)).Select(x => x).FirstOrDefault();
            if(tr == null) dict.Add("form1[0].Page1[0].PersonalDetails[0].SameAsCORIndicator[0]", "Y");

            if(previousRes.Count > 0)
            {
                dict.Add("form1[0].Page1[0].PersonalDetails[0].PCRIndicator[0]", "Y");
                for(int i = 0; i < previousRes.Count; i++)
                {
                    if(previousRes[i].ResidenceType == 2)
                    {
                        string str1 = "form1[0].Page1[0].PersonalDetails[0].Fragment1[0].PreviousCOR[0].Row" + (i + 2) + "[0].Country[0]";
                        string str2 = "form1[0].Page1[0].PersonalDetails[0].Fragment1[0].PreviousCOR[0].Row" + (i + 2) + "[0].Status[0]";
                        string str3 = "form1[0].Page1[0].PersonalDetails[0].Fragment1[0].PreviousCOR[0].Row" + (i + 2) + "[0].Other[0]";
                        string str4 = "form1[0].Page1[0].PersonalDetails[0].Fragment1[0].PreviousCOR[0].Row" + (i + 2) + "[0].FromDate[0]";
                        string str5 = "form1[0].Page1[0].PersonalDetails[0].Fragment1[0].PreviousCOR[0].Row" + (i + 2) + "[0].ToDate[0]";
                        dict.Add(str1, previousRes[i].CountryId.ToString());
                        dict.Add(str2, previousRes[i].StatusId);
                        dict.Add(str3, previousRes[i].OtherStatus);
                        dict.Add(str4, String.Format("{0:yyyy-MM-dd}", previousRes[i].StartDate));
                        dict.Add(str5, String.Format("{0:yyyy-MM-dd}", previousRes[i].EndDate));
                    }
                    if(previousRes[i].ResidenceType == 3)
                    {
                        dict.Add("form1[0].Page1[0].PersonalDetails[0].SameAsCORIndicator[0]", "N");
                        string str1 = "form1[0].Page1[0].PersonalDetails[0].CountryWhereApplying[0].Row2[0].Country[0]";
                        string str2 = "form1[0].Page1[0].PersonalDetails[0].CountryWhereApplying[0].Row2[0].Status[0]";
                        string str3 = "form1[0].Page1[0].PersonalDetails[0].CountryWhereApplying[0].Row2[0].Other[0]";
                        string str4 = "form1[0].Page1[0].PersonalDetails[0].CountryWhereApplying[0].Row2[0].FromDate[0]";
                        string str5 = "form1[0].Page1[0].PersonalDetails[0].CountryWhereApplying[0].Row2[0].ToDate[0]";
                        dict.Add(str1, previousRes[i].CountryId.ToString());
                        dict.Add(str2, previousRes[i].StatusId);
                        dict.Add(str3, previousRes[i].OtherStatus);
                        dict.Add(str4, String.Format("{0:yyyy-MM-dd}", previousRes[i].StartDate));
                        dict.Add(str5, String.Format("{0:yyyy-MM-dd}", previousRes[i].EndDate));
                    }

                    // if records more than two, then write to a file 
                    if(i >= 2) writetoFile(previousRes[i], @"c:\vba\IMM1294-Appendix.csv"); // will be adjust in the future
                }
            }
            else
            {
                dict.Add("form1[0].Page1[0].PersonalDetails[0].PCRIndicator[0]", "N");
            }

            // Process marriage info
            switch(person.MarriageStatusId)
            {
                case "02":  //single
                    dict.Add("form1[0].Page2[0].MaritalStatus[0].SectionA[0].PrevMarriedIndicator[0]", "N");
                    break;
                case "03":  // common law partner
                case "01":  //Married 
                    //int spouseid = CurrentMariiageStatus.SpouseId.Value;
                    if(mrghistory.Count == 1)
                    {
                        dict.Add("form1[0].Page2[0].MaritalStatus[0].SectionA[0].PrevMarriedIndicator[0]", "N");
                        dict.Add("form1[0].Page1[0].MaritalStatus[0].SectionA[0].DateOfMarriage[0]", String.Format("{0:yyyy-MM-dd}", mrghistory[0].BeginDate));
                        // int spouseid = (int)cmdc.tblMarriageHistories.Where(x => x.Id == personId).Select(x => x.SpouseId).FirstOrDefault();
                        int spouseid = (int)mrghistory[0].SpouseId;
                        tblPerson spouse = cmdc.tblPersons.Where(x => x.Id == spouseid).Select(x => x).FirstOrDefault();
                        dict.Add("form1[0].Page1[0].MaritalStatus[0].SectionA[0].FamilyName[0]", spouse.LastName);
                        dict.Add("form1[0].Page1[0].MaritalStatus[0].SectionA[0].GivenName[0]", spouse.FirstName); 
                    }
                    if(mrghistory.Count == 2)
                    {  // more than one marriage
                        dict.Add("form1[0].Page2[0].MaritalStatus[0].SectionA[0].PrevMarriedIndicator[0]", "Y");
                        // fill current one
                        tblMarriageHistory currentone = getCurrentOne(mrghistory[0], mrghistory[1]);
                        int currentSPid = (int)currentone.SpouseId;
                        tblPerson Currentspouse = cmdc.tblPersons.Where(x => x.Id == currentSPid).Select(x => x).FirstOrDefault(); // get current spouse info
                        dict.Add("form1[0].Page1[0].MaritalStatus[0].SectionA[0].DateOfMarriage[0]", String.Format("{0:yyyy-MM-dd}", currentone.BeginDate));
                        //tblPerson spouse = cmdc.tblPersons.Where(x => x.Id == spouseid).Select(x => x).FirstOrDefault();
                        dict.Add("form1[0].Page1[0].MaritalStatus[0].SectionA[0].FamilyName[0]", Currentspouse.LastName);
                        dict.Add("form1[0].Page1[0].MaritalStatus[0].SectionA[0].GivenName[0]", Currentspouse.FirstName);

                        // FillPreviousOne(cmdc, mrghistory, dict);
                        dict.Add("form1[0].Page2[0].MaritalStatus[0].SectionA[0].TypeOfRelationship[0]", mrghistory[1].relationship);
                        PreMarriage(cmdc, mrghistory, dict, 1);
                    }
                    break;
                case "09":  // Annulled Marriage
                case "04":  // Divorced
                case "05":  // Legally Separated
                case "06":  // Widowed
                    dict.Add("form1[0].Page2[0].MaritalStatus[0].SectionA[0].PrevMarriedIndicator[0]", "Y");
                    PreMarriage(cmdc, mrghistory, dict,0);
                    break;
                default:
                    //dict.Add("form1[0].Page1[0].MaritalStatus[0].SectionA[0].DateOfMarriage[0]", "");
                    //dict.Add("form1[0].Page1[0].MaritalStatus[0].SectionA[0].FamilyName[0]", "");
                    //dict.Add("form1[0].Page1[0].MaritalStatus[0].SectionA[0].GivenName[0]", "");

                    break;

            }

            return dict;
        }

        private static void PreMarriage(CommonDataContext cmdc, List<tblMarriageHistory> mrghistory, Dictionary<string, string> dict, int i)
        {
            
            int preSPid = (int)mrghistory[0].SpouseId;
            tblPerson preSP = cmdc.tblPersons.Where(x => x.Id == preSPid).Select(x => x).FirstOrDefault(); // get previous spouse info
            dict.Add("form1[0].Page2[0].MaritalStatus[0].SectionA[0].PMFamilyName[0]", preSP.LastName);
            dict.Add("form1[0].Page2[0].MaritalStatus[0].SectionA[0].GivenName[0].PMGivenName[0]", preSP.FirstName);
            dict.Add("form1[0].Page2[0].MaritalStatus[0].SectionA[0].PrevSpouseDOB[0].DOBYear[0]", preSP.DOB.Value.Year.ToString());
            dict.Add("form1[0].Page2[0].MaritalStatus[0].SectionA[0].PrevSpouseDOB[0].DOBMonth[0]", preSP.DOB.Value.Month.ToString());
            dict.Add("form1[0].Page2[0].MaritalStatus[0].SectionA[0].PrevSpouseDOB[0].DOBDay[0]", preSP.DOB.Value.Day.ToString());
            dict.Add("form1[0].Page2[0].MaritalStatus[0].SectionA[0].FromDate[0]", String.Format("{0:yyyy-MM-dd}", mrghistory[i].BeginDate));
            dict.Add("form1[0].Page2[0].MaritalStatus[0].SectionA[0].ToDate[0].ToDate[0]", String.Format("{0:yyyy-MM-dd}", mrghistory[i].EndDate));
       
        }

    

        private static void writetoFile(tblResidence res, string filename)
        {
            using(StreamWriter w = new StreamWriter(filename))
            {
                w.WriteLine("Coutry\tStatus\tOther\tFrom\tTo");
                w.WriteLine(res.CountryId.Value.countryToString() + "\t" + res.StatusId.statusCodeToName() + "\t" + res.OtherStatus + "\t" + String.Format("{0:yyyy-MM-dd}", res.StartDate) + "\t" + String.Format("{0:yyyy-MM-dd}", res.EndDate));
            }
        }
        private static tblMarriageHistory getOlderOne(tblMarriageHistory m1, tblMarriageHistory m2) {

            return (m1.BeginDate < m2.BeginDate) ? m1 : m2;
        }
        private static tblMarriageHistory getCurrentOne(tblMarriageHistory m1, tblMarriageHistory m2)
        {

            return (m1.BeginDate < m2.BeginDate) ? m2 : m1;
        }

    }
}
