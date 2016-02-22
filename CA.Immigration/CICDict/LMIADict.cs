using System;
using System.Collections.Generic;
using System.Linq;
using CA.Immigration.Data;
using CA.Immigration.Utility;


namespace CA.Immigration.LMIA
{
    public partial class LMIADict
    {
        //public Dictionary<string, string> outputDict;


        // Build a dictionary of EMP5593 based on the Application Id
        public static Dictionary<string, string> EMP5593(int AppId)
        {
            LMIADCDataContext ld = new LMIADCDataContext();
            CommonDataContext cd = new CommonDataContext();

            //var joinedApplication = from c in cd.tblApplications
            //                        join l in ld.tblLMIAApplications
            //                        on c.Id equals l.ApplicationId
            //                        into cl
            //                        select cl;

            // Get employer, employee Ids from Application Id
            int ? employerId = (int)cd.tblApplications.Where(x => x.Id == AppId).Select(x => x.ApplicantId).FirstOrDefault();
            int? employeeId = (int)ld.tblLMIAApplications.Where(x => x.ApplicationId == AppId).Select(x => x.EmployeeId).FirstOrDefault();
            int? rcicId = (int)cd.tblApplications.Where(x => x.Id == AppId).Select(x => x.RCICId).FirstOrDefault();
            int? bizDetailId = (int)ld.tblBusinessDetails.Where(x => x.ApplicationID == AppId).Select(x => x.Id).FirstOrDefault();
            int? joboffer1Id = (int)ld.tblJobOffer1s.Where(x => x.ApplicationID == AppId).Select(x => x.Id).FirstOrDefault();
            int? joboffer2Id = (int)ld.tblJobOffer2s.Where(x => x.ApplicationID == AppId).Select(x => x.Id).FirstOrDefault();
            int? recruitsumId = (int)ld.tblRecruitSummaries.Where(x => x.ApplicationId == AppId).Select(x => x.Id).FirstOrDefault();
            int? impactlmId = (int)ld.tblImpactLMs.Where(x => x.ApplicationID == AppId).Select(x => x.Id).FirstOrDefault();
            int? creditcardId = (int)ld.tblCreditCards.Where(x => x.EmployerId == employerId).Select(x => x.Id).FirstOrDefault();
            //Get employer, employee information based on Ids
            var employer = ld.tblEmployers.Where(x => x.Id == employerId).Select(x => x).FirstOrDefault();
            var employee = cd.tblPersons.Where(x => x.Id == employeeId).Select(x => x).FirstOrDefault();
            var employeePassport = cd.tblPassports.Where(x => x.Id == employeeId).Select(x => x).FirstOrDefault();
            var employeeAddress = cd.tblAddresses.Where(x => x.Id == employeeId).Select(x => x).FirstOrDefault();
            var employeeMore = ld.tblEmployees.Where(x => x.Id == employeeId).Select(x => x).FirstOrDefault();
            var LMIAApp = ld.tblLMIAApplications.Where(x => x.ApplicationId == AppId).Select(x => x).FirstOrDefault();
            var bizdetail = ld.tblBusinessDetails.Where(x => x.Id == bizDetailId).Select(x => x).FirstOrDefault();
            var joboffer1 = ld.tblJobOffer1s.Where(x => x.Id == joboffer1Id).Select(x => x).FirstOrDefault();
            var joboffer2 = ld.tblJobOffer2s.Where(x => x.Id == joboffer2Id).Select(x => x).FirstOrDefault();
            var recruitsum = ld.tblRecruitSummaries.Where(x => x.Id == recruitsumId).Select(x => x).FirstOrDefault();
            var impactlm = ld.tblImpactLMs.Where(x => x.Id == impactlmId).Select(x => x).FirstOrDefault();
            var creditcard = ld.tblCreditCards.Where(x => x.Id == creditcardId).Select(x => x).FirstOrDefault();

            string rcicName;
            if(rcicId != null)
            {
                tblRCIC rcic = cd.tblRCICs.Where(x => x.Id == rcicId).Select(x => x).FirstOrDefault();
                rcicName = rcic.FirstName + " " + rcic.LastName;
            }
            else { rcicName = string.Empty; }

            
            Dictionary <string, string> dict = new Dictionary<string, string>()
            {

                ["EMP5593_E[0].Page1[0].rb_LMIA[0]"] = LMIAApp.LMIAType.ToString(), // 0 is for PR Only 2 is for PR+WP
                ["EMP5593_E[0].Page1[0].rb_skilled_trades[0]"] = (LMIAApp.SecondEmployer==null)?"0":"2", //0 is No 2 is Yes
                ["EMP5593_E[0].Page1[0].txtF_if_yes[0]"] = LMIAApp.SecondEmployer, // second employer name
                ["EMP5593_E[0].Page1[0].txtF_Emp_ID[0]"] = employer.ESDCId.ToString(),
                ["EMP5593_E[0].Page1[0].txtF_Bus_Number1[0]"] = employer.CRA_BN,
                ["EMP5593_E[0].Page1[0].txtF_Bus_Name[0]"] = employer.LegalName,
                ["EMP5593_E[0].Page1[0].txtF_Emp_Legal[0]"] = employer.OperatingName, // it's strange, but the form is like this
                ["EMP5593_E[0].Page1[0].txtF_Mail_Adress[0]"] = employer.MailingAddress,
                ["EMP5593_E[0].Page1[0].txtF_City[0]"] = employer.BizCity,
                ["EMP5593_E[0].Page1[0].txtF_Province[0]"] = employer.BizProvince,
                ["EMP5593_E[0].Page1[0].txtF_Postal_Code[0]"] = employer.BizCountry,
                ["EMP5593_E[0].Page1[0].txtF_Country[0]"] = employer.BizPostalCode,
                ["EMP5593_E[0].Page1[0].txtF_City[1]"] = employer.BizTelephone,
                ["EMP5593_E[0].Page1[0].txtF_City[2]"] = employer.BizAddress,
                ["EMP5593_E[0].Page2[0].txtF_City[0]"] = employer.BizCity,
                ["EMP5593_E[0].Page2[0].txtF_Province[0]"] = employer.BizProvince,
                ["EMP5593_E[0].Page2[0].txtF_Postal_Code[0]"] = employer.BizCountry, // ESDC form error, this refers to a country
                ["EMP5593_E[0].Page2[0].txtF_Country[0]"] = employer.BizPostalCode,
                //// P2 16 name is ridiculous
                ["EMP5593_E[0].Page2[0].cb_Benefit_Dis_Ins[0]"] = ((int)employer.CompanyType == 1) ? "1" : "0",  //1 is set // need change database
                ["EMP5593_E[0].Page2[0].cb_Benefit_Dental_Ins[0]"] = ((int)employer.CompanyType == 2) ? "1" : "0",
                ["EMP5593_E[0].Page2[0].cb_Benefit_Pension[0]"] = ((int)employer.CompanyType == 3) ? "1" : "0",
                ["EMP5593_E[0].Page2[0].cb_Benefit_Extended_Medical_Ins[0]"] = ((int)employer.CompanyType != 1 && (int)employer.CompanyType != 2 && (int)employer.CompanyType != 3) ? "1" : "0",
                // ["EMP5593_E[0].Page2[0].txtF_Other_Benefit[0]"] =employer. // Type of business other spficy, so far don't need it


                //// p2 17 franchis , update database define
                ["EMP5593_E[0].Page2[0].rb_Question4[1]"] = (employer.FranchiseName == null) ? "0" : "2", // 17 no is 0, yes is 2

                ////p2 18 
                ["EMP5593_E[0].Page2[0].rb_Question4[0]"] = employer.FranchiseAware.ToString(),  //18 yes is 1, no is 2, not applicable is 3

                ["EMP5593_E[0].Page2[0].txtF_Web_Employer[0]"] = employer.Website,
                ["EMP5593_E[0].Page2[0].txtF_Bus_Date[0]"] = String.Format("{0:yyyy-MM-dd}", employer.BizStartDate),
                ["EMP5593_E[0].Page2[0].txtF_Activity[0]"] = employer.BizActivity,
                ["EMP5593_E[0].Page2[0].txtF_Prim_Contact_last_Name[0]"] = employer.ContactLastName,
                ["EMP5593_E[0].Page2[0].txtF_Prim_Contact_Middle[0]"] = employer.ContactMiddleName,
                ["EMP5593_E[0].Page2[0].txtF_Prim_Contact_Name[0]"] = employer.ContactFirstName,
                ["EMP5593_E[0].Page2[0].txtF_Job_Title[0]"] = employer.ContactJobTitle,
                ["EMP5593_E[0].Page2[0].txtF_Contact_Tel[0]"] = employer.ContactPhone,
                ["EMP5593_E[0].Page2[0].txtF_Fax[0]"] = employer.ContactFax,
                ["EMP5593_E[0].Page2[0].txtF_Email[0]"] = employer.ContactEmail,
                ["EMP5593_E[0].Page2[0].rb_language[0]"] = "0",  //Contact preferred language: hard code to set it as English
                //// Below 3rd part: Recruiter
                ["EMP5593_E[0].Page2[0].rb_Using_a_Third_party[0]"] = "0", // hard code set to No
                ["EMP5593_E[0].Page2[0].txtF_Name_of_third_party_recruiter[0]"] = "", // hard code set to empty
                ["EMP5593_E[0].Page2[0].txtF_Registration_Number[0]"] = "", // hard code set to empty
                //// RCIC
                ["EMP5593_E[0].Page2[0].rb_Appointing_a_Third_party_Rep[0]"] = (rcicId == null) ? "0" : "1", // if no rcic, then 1, otherwise is 2
                ["EMP5593_E[0].Page2[0].txtF_Name_of_third_party_rep[0]"] = (rcicId == null) ? "" : rcicName,
                ["EMP5593_E[0].Page2[0].rb_Question6_E[0]"] = "2", // force to No
                //// Business Details
                ["EMP5593_E[0].Page2[0].txtF_Business_Activity[0]"] = bizdetail.TotalEmployeeUnderCRA.ToString(),
                ["EMP5593_E[0].Page2[0].txtF_Business_Activity[2]"] = bizdetail.TotalEmployeeThisLocation.ToString(),
                ["EMP5593_E[0].Page2[0].txtF_Business_Activity[1]"] = bizdetail.TotalCndThisLocation.ToString(),
                ["EMP5593_E[0].Page3[0].txtF_Business_Activity[1]"] = bizdetail.TotalEmployeeThisOccupationLocation.ToString(),
                ["EMP5593_E[0].Page3[0].txtF_Business_Activity[0]"] = bizdetail.TotalTFWAfterPositive.ToString(),
                ["EMP5593_E[0].Page3[0].rb_ForeignWorkerEmploy[0]"] = bizdetail.Q6.ToString(), //Did you employ a foreign worker (as the result of receiving a positive LMIA) in the last two years, prior to December 31, 2013?
                ["EMP5593_E[0].Page3[0].rb_ForeignWorkerEmploy[1]"] = bizdetail.Q6_1.ToString(), //If YES – did you provide all foreign workers employed by you in the last two years with wages, working conditions and employment in an occupation that
                ////were substantially the same as those that were described in the offer(s) of employment(and confirmed in the LMIA letter(s) and annexe(s)) ?
                //// 7 don't know where
                ////8 don't know where, miss 3
                ["EMP5593_E[0].Page3[0].txtF_Date_E[0]"] = bizdetail.Q8_2.ToString(), //Date
                ["EMP5593_E[0].Page3[0].num_How_Many[2]"] = bizdetail.Q8_3, // system file number

                ////9
                ["EMP5593_E[0].Page3[0].rb_EmployeesLaidOff[0]"] = bizdetail.Q9.ToString(), //lay off 1 no, 2 yes
                ["EMP5593_E[0].Page3[0].num_How_Many[0]"] = bizdetail.Q9_1.ToString(), //how many canadians
                ["EMP5593_E[0].Page3[0].num_How_Many[1]"] = bizdetail.Q9_2.ToString(), //how many tfw
                ["EMP5593_E[0].Page3[0].txtF_Reason_Of_Layoff[0]"] = bizdetail.Q9_3,  // reasons
                ////10
                ["EMP5593_E[0].Page3[0].rb_GoCProgramSupport[0]"] = bizdetail.Q10.ToString(),
                ["EMP5593_E[0].Page3[0].txtF_Other_Benefit[0]"] = bizdetail.Q10_1,

                //// Job offer
                ["EMP5593_E[0].Page3[0].txtF_Job_Title[0]"] = joboffer1.JobTile,
                ["EMP5593_E[0].Page3[0].txtF_Number_of_foreign_workers[0]"] = joboffer1.Number.ToString(),
                ["EMP5593_E[0].Page3[0].txtF_Days[0]"] = joboffer1.WorkingDays.ToString(),
                ["EMP5593_E[0].Page3[0].txtF_Weeks[0]"] = joboffer1.WorkingWeeks.ToString(),
                ["EMP5593_E[0].Page3[0].txtF_Months[0]"] = joboffer1.WorkingMonths.ToString(),
                ["EMP5593_E[0].Page3[0].txtF_Years[0]"] = joboffer1.WorkingYears.ToString(),
                ["EMP5593_E[0].Page3[0].chkB_Perm[0]"] = joboffer1.Permanent.ToString(),
                ["EMP5593_E[0].Page3[0].txtF_Date_E[0]"] = String.Format("{0:yyyy-MM-dd}", joboffer1.StartDate),
                ["EMP5593_E[0].Page3[0].txtF_LocationOfEmployment[0]"] = joboffer1.WorkLocation,
                ["EMP5593_E[0].Page4[0].txtF_City[0]"] = joboffer1.City,
                ["EMP5593_E[0].Page4[0].txtF_Province[0]"] = joboffer1.Province,
                ["EMP5593_E[0].Page4[0].txtF_PostalCode[0]"] = joboffer1.PostalCode,
                ["EMP5593_E[0].Page4[0].txtF_MainDuties[0]"] = joboffer1.Mainduties,
                ["EMP5593_E[0].Page4[0].chkB_DoctoratePhd[0]"] = joboffer1.Doctorate_PHD.ToString(),
                ["EMP5593_E[0].Page4[0].chkB_DoctorOfMedicine[0]"] = joboffer1.DoctorOfMdeicine.ToString(),
                ["EMP5593_E[0].Page4[0].chkB_MastersDegree[0]"] = joboffer1.MasterDegree.ToString(),
                ["EMP5593_E[0].Page4[0].chkB_BachelorsDegree[0]"] = joboffer1.Bachelor.ToString(),
                ["EMP5593_E[0].Page4[0].chkB_CollegeLevelDiploma[0]"] = joboffer1.College.ToString(),
                ["EMP5593_E[0].Page4[0].chkB_Apprenticeship[0]"] = joboffer1.Apprentice.ToString(),
                ["EMP5593_E[0].Page4[0].chkB_TradeDiploma[0]"] = joboffer1.Trade.ToString(), // need check, two trade in nodes
                ["EMP5593_E[0].Page4[0].chkB_SecondarySchool[0]"] = joboffer1.SecondarySchool.ToString(),
                ["EMP5593_E[0].Page4[0].chkB_VocationalSchool[0]"] = joboffer1.Vocational.ToString(),
                ["EMP5593_E[0].Page4[0].chkB_TradeDiploma[1]"] = joboffer1.NotRequired.ToString(), // need check
                ["EMP5593_E[0].Page4[0].txtF_AdditionalInformation[0]"] = joboffer1.EduAdditionalInfo,
                ["EMP5593_E[0].Page4[0].txtF_MainDuties[1]"] = joboffer1.SkillRequirement,
                // Language requirement
                ["EMP5593_E[0].Page4[0].chkB_OrallyIn[0]"] = joboffer1.Oral.ToString(),
                ["EMP5593_E[0].Page4[0].chkB_English1[0]"] = joboffer1.OralEnglish.ToString(),
                ["EMP5593_E[0].Page4[0].chkB_French1[0]"] = joboffer1.OralFrench.ToString(),
                ["EMP5593_E[0].Page4[0].chkB_EnglishAndFrench1[0]"] = joboffer1.oralEnglishandFrench.ToString(),
                ["EMP5593_E[0].Page4[0].chkB_EnglishOrFrench1[0]"] = joboffer1.OralEnglishorFrench.ToString(),
                ["EMP5593_E[0].Page4[0].chkB_TheOffer[0]"] = joboffer1.Writing.ToString(),
                ["EMP5593_E[0].Page4[0].chkB_English2[0]"] = joboffer1.WritingEnglish.ToString(),
                ["EMP5593_E[0].Page4[0].chkB_French2[0]"] = joboffer1.WritingFrench.ToString(),
                ["EMP5593_E[0].Page4[0].chkB_EnglishAndFrench2[0]"] = joboffer1.WritingEnglishandFrench.ToString(),
                ["EMP5593_E[0].Page4[0].chkB_EnglishOrFrench2[0]"] = joboffer1.WritingEnglishorFrench.ToString(),
                ["EMP5593_E[0].Page4[0].chkB_TheOffer2[0]"]= joboffer1.OtherLanguage.ToString(),

                // next line is question 13 about full time, very strange
                ["EMP5593_E[0].Page4[0].rb_Question4[0]"]=joboffer1.FullTime.ToString(),  // 0 yes 2 no
                ["EMP5593_E[0].Page4[0].txtF_Other_Benefit[0]"]=joboffer1.FullTimeExplanation,
                //Q16 if seasonal , strange
                ["EMP5593_E[0].Page4[0].rb_Question11_E[0]"]=joboffer1.Seasonal.ToString(), //0 yes, 2 no

                ["EMP5593_E[0].Page4[0].txtF_PerHour[0]"] = joboffer1.HourlyWage.ToString(),
                ["EMP5593_E[0].Page4[0].txtF_PerYear[0]"] = joboffer1.YearlyWage.ToString(),
                ["EMP5593_E[0].Page4[0].txtF_OtRate[0]"] = joboffer1.OverTimeRate.ToString(),
                ["EMP5593_E[0].Page4[0].txtF_hoursOfWorkPerWeek[0]"] = joboffer1.OverTimeStart.ToString(),
                ["EMP5593_E[0].Page4[0].txtF_NumberOfHours[0]"] = joboffer1.Dayhours.ToString(),
                ["EMP5593_E[0].Page4[0].txtF_TotalNumberOfHoursPerWeek[0]"] = joboffer1.WeeklyHours.ToString(),
                ["EMP5593_E[0].Page4[0].txtF_TotalNumberOfHoursPerMonth[0]"] = joboffer1.MonthlyHours.ToString(),
                ["EMP5593_E[0].Page4[0].txtF_PerHour[1]"] = joboffer1.LowestWage.ToString(), // check
                ["EMP5593_E[0].Page4[0].txtF_PerHour[2]"] = joboffer1.HighestWage.ToString(),
                // miss q15 final check 

                // q17-18 good
                ["EMP5593_E[0].Page5[0].chkB_DentalInsurance[0]"] = joboffer1.DentalInsurance.ToString(),
                ["EMP5593_E[0].Page5[0].chkB_DisabilityInsurance[0]"] = joboffer1.DisabilityInsurance.ToString(),
                ["EMP5593_E[0].Page5[0].chkB_ExtendedMed[0]"] = joboffer1.ExtendedMedical.ToString(),
                ["EMP5593_E[0].Page5[0].chkB_Pension[0]"] = joboffer1.Pension.ToString(),
                ["EMP5593_E[0].Page5[0].txtF_Days[0]"] = joboffer1.VacationDays.ToString(),
                ["EMP5593_E[0].Page5[0].txtF_Remuneration[0]"] = joboffer1.Remuneration.ToString(),
                ["EMP5593_E[0].Page5[0].txtF_OtherBenefits[0]"] = joboffer1.OtherBenefits,

                ////19 -21
                //["EMP5593_E[0].Page5[0].rb_Question19_E[0]"] = joboffer2.licenseRequired.ToString(),
                //// miss something... 

                
                ["EMP5593_E[0].Page5[0].txtF_IfYes16[0]"]=joboffer2.ProveYes,  // ok
                ["EMP5593_E[0].Page5[0].txtF_IfNo16[0]"]=joboffer2.ExplainifNo, //ok



                ////22 
                ["EMP5593_E[0].Page5[0].chkB_FillingLabourShortage[0]"] = joboffer2.FillLabourShort.ToString(),
                ["EMP5593_E[0].Page5[0].chkB_developmentOrTransfer[0]"] = joboffer2.SkillTransfer.ToString(),
                ["EMP5593_E[0].Page5[0].chkB_DirectJobCreation[0]"] = joboffer2.JobCreation.ToString(),
                ["EMP5593_E[0].Page5[0].chkB_Other[0]"] = joboffer2.Other.ToString(),
                ["EMP5593_E[0].Page5[0].txtF_ProvideDetails[0]"] = joboffer2.Details,
                ////23-28
                ["EMP5593_E[0].Page6[0].txtF_ProvideARationale[0]"] = joboffer2.JobOfferRationale,
                ["EMP5593_E[0].Page6[0].txtF_duties_resp[0]"] = joboffer2.WhoElse,
                ["EMP5593_E[0].Page6[0].txtF_identify_foreign[0]"] = joboffer2.HowToFindTheTFW,
                ["EMP5593_E[0].Page6[0].txtF_determine_foreign[0]"] = joboffer2.WhyTFWQualified,
                ["EMP5593_E[0].Page6[0].txtF_offer_foreign[0]"] = joboffer2.HowAndWhen,
                ["EMP5593_E[0].Page6[0].rb_Question23_E[0]"] = joboffer2.NoTraining.ToString(),  //0 is no, 1 is yes
                ["EMP5593_E[0].Page6[0].txtF_IfNo19[0]"] = joboffer2.ExplainNoTraining,
                ["EMP5593_E[0].Page6[0].txtF_IfYes19[0]"] = joboffer2.DescriptionTrainingPlan,

                //// Summary of meeting minium recruitment effort
                ["EMP5593_E[0].Page6[0].txtF_numberOfApplications[0]"] = recruitsum.CndResumesReceived.ToString(),
                ["EMP5593_E[0].Page6[0].txtF_NumberOfCanadiansHired[0]"] = recruitsum.CndInterviewed.ToString(),
                ["EMP5593_E[0].Page6[0].txtF_PermanentResidentsOffered[0]"] = recruitsum.CndNotQualified.ToString(),
                ["EMP5593_E[0].Page6[0].txtF_NumberOfCanadians[0]"] = recruitsum.CndJobOffered.ToString(),
                ["EMP5593_E[0].Page6[0].txtF_JobOffersDeclined[0]"] = recruitsum.CndOfferDeclined.ToString(),
                ["EMP5593_E[0].Page6[0].txtF_NumberOfCanadianNotQualified[0]"] = recruitsum.CndHired.ToString(),
                ["EMP5593_E[0].Page6[0].txtF_BriefExplanation[0]"] = recruitsum.WhyNotCnd,

                //// Impact on Canadian Labour Market
                ["EMP5593_E[0].Page7[0].rb_Question1_E[0]"] = impactlm.JobLoss.ToString(),
                ["EMP5593_E[0].Page7[0].rb_Question2_E[0]"] = impactlm.OutSourcing.ToString(),
                ["EMP5593_E[0].Page7[0].txtF_ProvideSummary[0]"] = impactlm.ContractSummary,
                ["EMP5593_E[0].Page7[0].txtF_ProvideDetails[0]"] = impactlm.ImpactCanadian,
                ["EMP5593_E[0].Page7[0].rb_QuestionC_E[0]"] = impactlm.HireWithoutLMIA.ToString(),
                // ["EMP5593_E[0].Page7[0].txtF_IfYes19[0]"] =
                ["EMP5593_E[0].Page7[0].txtF_Ci[0]"] = impactlm.RecruitEffort,
                ["EMP5593_E[0].Page7[0].txtF_Cii[0]"] = impactlm.HiringImpactCanadian,

                ////Foreign work Info
                ["EMP5593_E[0].Page8[0].txtF_Surname[0]"] = employee.LastName,
                ["EMP5593_E[0].Page8[0].txtF_GivenNames[0]"] = employee.FirstName,
                ["EMP5593_E[0].Page8[0].rb_Question3_E[0]"] = (employeePassport.GenderId.HasValue)?employeePassport.GenderId.Value.genderToString():"", 
                ["EMP5593_E[0].Page8[0].txtF_Date_E[0]"] = String.Format("{0:yyyy-MM-dd}",(DateTime)employeePassport.DOB),
                ["EMP5593_E[0].Page8[0].txtF_City[0]"] = employeeMore.OutCanadaCity,
                ["EMP5593_E[0].Page8[0].txtF_Country[0]"] = employeeMore.OutCanadaCountry,
                ["EMP5593_E[0].Page8[0].txtF_Citizenships[0]"] = (employeePassport.NationalityId.HasValue)? employeePassport.NationalityId.Value.countryToString():"",
                ["EMP5593_E[0].Page8[0].txtF_City2[0]"] = employeeMore.CanadaCity,
                ["EMP5593_E[0].Page8[0].txtF_Province[0]"] = employeeMore.CanadaProvince,
                ["EMP5593_E[0].Page8[0].rb_Question8[0]"]=((int)employeeMore.Hired==1)?"Yes":"No",
                ["EMP5593_E[0].Page8[0].FFRichText108[0]"] = employeeMore.Duration,
                ["EMP5593_E[0].Page8[0].chkB_Refugee[0]"] = employeeMore.RefugeeClaimant.ToString(),
                ["EMP5593_E[0].Page8[0].chkB_Student[0]"] = employeeMore.Student.ToString(),
                ["EMP5593_E[0].Page8[0].chkB_TempWorker[0]"] = employeeMore.ForeignWorker.ToString(),
                ["EMP5593_E[0].Page8[0].chkB_Visitor[0]"] = employeeMore.Visitor.ToString(),


                // Employer declaration
                ["EMP5593_E[0].Page8[0].rb_Declaration_E[0]"] = (employer.CompanyType == 1) ? "4" : "2", //company type 1 is incorporated 2 other. then 2 mark yes, 4 mark no
                ["EMP5593_E[0].Page8[0].rb_IfYes_E[0]"] = (employer.CompanyType != 1) ? "3" : "", // hard code to 3, otherwise cannot apply
                ["EMP5593_E[0].Page8[0].chkB_2[0]"] = "1",
                ["EMP5593_E[0].Page8[0].chkB_3[0]"] = "1",
                ["EMP5593_E[0].Page8[0].chkB_4[0]"] = "1",
                ["EMP5593_E[0].Page8[0].chkB_5[0]"] = "1",
                ["EMP5593_E[0].Page8[0].chkB_6[0]"] = "1",
                ["EMP5593_E[0].Page8[0].chkB_7[0]"] = "1",
                ["EMP5593_E[0].Page8[0].chkB_8[0]"] = "1",
                ["EMP5593_E[0].Page9[0].chkB_10[0]"] = "1",
                ["EMP5593_E[0].Page9[0].chkB_11[0]"] = "1",
                ["EMP5593_E[0].Page9[0].chkB_12[0]"] = "1",
                ["EMP5593_E[0].Page9[0].chkB_13[0]"] = "1",
                ["EMP5593_E[0].Page9[0].chkB_14[0]"] = "1",
                ["EMP5593_E[0].Page9[0].chkB_15[0]"] = "1",
                ["EMP5593_E[0].Page9[0].chkB_16[0]"] = "1",
                ["EMP5593_E[0].Page9[0].chkB_16[1]"] = "1",
                ["EMP5593_E[0].Page9[0].chkB_18[0]"] = "1",
                ["EMP5593_E[0].Page9[0].chkB_18[1]"] = "1",
                ["EMP5593_E[0].Page9[0].chkB_18[2]"] = "1",
                ["EMP5593_E[0].Page9[0].chkB_9[0]"] = "1",

                // Application type has no field, MUST BE FILLED MANUALLY
               // ["EMP5593_E[0].Page9[0].chkB_9[0]"] = (app.LMIAType == 2) ? "1" : "2",
                ["EMP5593_E[0].Page9[0].txtF_PrintedNameOfEmployer[0]"] = employer.ContactFirstName + " " + employer.ContactLastName,
                ["EMP5593_E[0].Page9[0].txtF_SignatureDate_E[0]"] =String.Format("{0:yyyy-MM-dd}", DateTime.Today),
                //["EMP5593_E[0].Page9[0].txtF_Signature_E[0]"] =
                ["EMP5593_E[0].Page9[0].txtF_TitleOfEmployer[0]"] = employer.ContactJobTitle,

                //Documentation required

                // Below should get data from Document List talbe, will do it someday
                ["EMP5593_E[0].Page10[0].CB10[0]"] = "0",
                ["EMP5593_E[0].Page10[0].CB11[0]"] = "0",
                ["EMP5593_E[0].Page10[0].CB12[0]"] = "0",
                ["EMP5593_E[0].Page10[0].CB3[0]"] = "0",
                ["EMP5593_E[0].Page10[0].CB5[0]"] = "0",
                ["EMP5593_E[0].Page10[0].CB8[0]"] = "0",
                ["EMP5593_E[0].Page10[0].CB9[0]"] = "0",
                ["EMP5593_E[0].Page10[0].CB[0]"] = "0",
                ["EMP5593_E[0].Page10[0].Table1[0]"] = "0",
                ["EMP5593_E[0].Page10[0].Table1[0].Row10[1]"] = "0",
                ["EMP5593_E[0].Page10[0].Table1[0].Row10[1].#subform[0]"] = "0",
                ["EMP5593_E[0].Page10[0].Table1[0].Row10[1].#subform[0].ClaimType[1]"] = "0",
                ["EMP5593_E[0].Page10[0].Table1[0].Row4[0]"] = "0",
                ["EMP5593_E[0].Page10[0].Table1[0].Row4[0].#subform[0]"] = "0",
                ["EMP5593_E[0].Page10[0].Table1[0].Row4[0].#subform[0].ClaimType[0]"] = "0",
                ["EMP5593_E[0].Page10[0].txtF_IfNo1[0]"] = "Not Applicable",

                // EMP5576(embeded in EMP5593)
                ["EMP5593_E[0].Page11[0].rb_Card_Type[0]"] = creditcard.CardType.ToString(),  // 0 is visa, 1 is master 2 is american express
                ["EMP5593_E[0].Page11[0].rb_Payment[0]"] = LMIAApp.PayMethod.ToString(),  //1 is cheque 2 is credit card
                ["EMP5593_E[0].Page11[0].txtF_Applicant_Name[0]"] = employer.ContactFirstName + " " + employer.ContactLastName,
                ["EMP5593_E[0].Page11[0].txtF_Applicant_Name[1]"] = creditcard.CardNumber.Substring(creditcard.CardNumber.Length - 4),  //get last four chars from a string
                ["EMP5593_E[0].Page11[0].txtF_CRA_Business_Number[0]"] = employer.CRA_BN,
                ["EMP5593_E[0].Page11[0].txtF_Card_Number[0]"] = creditcard.CardNumber,
                ["EMP5593_E[0].Page11[0].txtF_Charge[0]"] = (LMIAApp.NumberofPosition * LMIAApp.ApplicationFeePerPosition).ToString(),
                ["EMP5593_E[0].Page11[0].txtF_Day[0]"] = DateTime.Today.Year.ToString(),  //ESDC Form error, it refers this to a Year
                ["EMP5593_E[0].Page11[0].txtF_EMployer_Name[0]"] =employer.LegalName,
                ["EMP5593_E[0].Page11[0].txtF_Given_Names[0]"] =creditcard.CardHolderName,
                ["EMP5593_E[0].Page11[0].txtF_Month[0]"] =DateTime.Today.Month.ToString(),
                ["EMP5593_E[0].Page11[0].txtF_Month[1]"] =creditcard.ExpireMonth,
                ["EMP5593_E[0].Page11[0].txtF_Number_Positions[0]"] =LMIAApp.NumberofPosition.ToString(),
                ["EMP5593_E[0].Page11[0].txtF_Number_Positions[1]"] =creditcard.SecurityCode,
                ["EMP5593_E[0].Page11[0].txtF_Off_use[0]"] ="off use",
                ["EMP5593_E[0].Page11[0].txtF_Processing_Fee[0]"] = (LMIAApp.NumberofPosition * LMIAApp.ApplicationFeePerPosition).ToString(),
                //["EMP5593_E[0].Page11[0].txtF_Signature_E[0]"] ="sign",
                ["EMP5593_E[0].Page11[0].txtF_Year[0]"] =DateTime.Today.Day.ToString(),  //ESDC Form error, it refers this to a Day
                ["EMP5593_E[0].Page11[0].txtF_Year[1]"] =creditcard.ExpireYear
                

            };
           
            return dict;
            }

        }
 }

