


--- lmia Database
use LMIA
go
-- If a required document is not attached, please explain:  do it someday

-- Recruitment Summary 
create table tblRecruitSummary(
Id int not null primary key identity(1,1),
ApplicationId int, 
CndResumesReceived int,  --How Many Canadians/PRs' resumes received
CndInterviewed int, --How many Canadians/PRs are interviewed
CndNotQualified int,  --How many Canadians/PRs are not qualified
CndJobOffered int,  --How many jobs offered to Canadians/PRs
CndOfferDeclined int,  --How many job offer declined by Canadians/PRs
CndHired int,  --How many Canadians/PRs are hired
WhyNotCnd nvarchar(4000) --Please explain why each Canadians/PRs is not qualified
)


-- Employer information
create table tblEmployer(
Id int not null primary key identity(1,1),
ESDCId int,   -- if not first apply, should have a ESDC employer ID
CRA_BN nvarchar(15) ,  -- CRA Business Number 
LegalName nvarchar(50) ,
OperatingName nvarchar(50),
FranchiseName nvarchar(50),
FranchiseAware int, --1 yes, 2 no, 3 not applicalb
CompanyType int,  -- 1 Incorporated 2 Partner 3 Solo proprietor
MailingAddress nvarchar(50),   -- street address for mailing address
MailingCity nvarchar(20),
MailingProvince nvarchar(20),
MailingCountry nvarchar(20),
MailingPostalCode nvarchar(10),
BizAddress nvarchar(50),   -- street address for business address, should check if same
BizCity nvarchar(20),
BizProvince nvarchar(20),
BizCountry nvarchar(20),
BizPostalCode nvarchar(10),
BizTelephone nvarchar(20),
Website nvarchar(100),
BizStartDate date,
BizActivity nvarchar(100),  --  Describe the principal business acivity
ContactFirstName nvarchar(20),
ContactMiddleName nvarchar(20),
ContactLastName nvarchar(20),
ContactJobTitle nvarchar(20),
ContactPhone nvarchar(20),
ContactFax nvarchar(20),
ContactEmail nvarchar(50),
Witness nvarchar(20)
)

-- Application information
create table tblLMIAApplication(
LMIAId int not null primary key identity(1,1),
ApplicationId int, -- refer to the mother application table
EmployeeId int,
LMIAType int, -- 1 Only for PR, 2 PR+WP 3 N/A  // this data can be stored in codes
SecondEmployer nvarchar(30),
NumberofPosition int,
ApplicationFeePerPosition money,
PayMethod int  -- Method of Payment:1 Certified cheque or money order (postal or bank) made payable to the Receiver General for Canada 2 Credit Card
)

-- Application followup 
create table tblFollowup(
Id int not null primary key identity(1,1),
ApplicationId int,
Request nvarchar(200),
RequestDate date,
Response nvarchar(200),
ResponseDate date
)

--Business detail table
create table tblBusinessDetail (
Id int not null primary key identity(1,1),
ApplicationID int,  -- Business information could be changed, so it only directly related to application, instead of Employer
TotalEmployeeUnderCRA int, --"1. Number of employees currently employed nationally under this Canada Revenue Agency Business number (e.g. 5 franchises are covered by the business
                                           -- number and there are a total of 100 employees):"

TotalEmployeeThisLocation int, --2. Total number of employees currently employed at the work location specified on this form:

TotalCndThisLocation int, --3. Total number of Canadian/permanent resident employees at the work location specified on this form:

TotalEmployeeThisOccupationLocation int,  --4. Total number of employees (including Canadians/permanent residents and TFWs) working in this occupation at this work location:
TotalTFWAfterPositive int,  --5. Total number of foreign workers (as a result of receiving a positive LMIA) at the work location specified on this form:
Q6 int , --	1 N 2 Y, within two years before 12/31/2013, did you employ a foreign worker(as the result of receiving LMIA)
Q6_1 int,  --  1N 2 Y,If YES – did you provide all foreign workers employed by you in the last two years with wages, working conditions and employment in an occupation that were substantially the same as those that were described in the offer(s) of employment (and confirmed in the LMIA letter(s) and annexe(s))?
Q7 int , --	Have you applied for and received a positive LMIA on or after December 31, 2013, and employed a foreign worker in that position?
Q7_1 int,  --	  If YES – did you provide all foreign workers employed by you, on LMIAs received on or after December 31, 2013, with employment in the same occupation as described in the offer(s) of employment (and confirmed in the LMIA letter(s) and annexe(s)) and with substantially the same wages and working conditions - but not less favourable than- those set out in that offer(s) of employment (and confirmed in the LMIA letter(s) and annexe(s))?
Q8 int ,  --	  Have you had an LMIA revoked, within the previous 2 years from the date you submitted this Application?
Q8_1 int, 	--If YES – was the LMIA revoked because you had provided false, misleading or inaccurate information in the context of a request for an opinion?
Q8_2 date, -- If yes, please provide the following details regarding this revocation:	Date (yyyy-mm-dd):
Q8_3 nvarchar(20),--System File Number:	  
Q8_4 nvarchar(100),	 -- If the public policy considerations that justified the revocation are no longer relevant, please provide a detailed explanation:
Q9 int, --   Were any employees laid off in the past 12 months?
Q9_1 int,  -- 	 If yes, how many Canadians/permanent residents?
Q9_2 int,  --  How many foreign workers?
Q9_3 nvarchar(100),	-- Reason(s) for layoff(s) and occupations affected:
Q10 int, --  Does your business receive support through any Government of Canada program (e.g. Work-Sharing Program)?
Q10_1 nvarchar(50)  -- If yes, name the program(s):

)


-- Job offer tables, 1 for Job itself(5593:1-18), 2 for related info(5593:19-28)
create table tblJobOffer1(
Id int not null primary key identity(1,1),
ApplicationID int,  -- Business information could be changed, so it only directly related to application, instead of Employer
JobTile nvarchar(30),
Number int, 
WorkingDays int, 
WorkingWeeks int,
WorkingMonths int,
WorkingYears int,
Permanent int,
StartDate date,
WorkLocation nvarchar(50), -- street address
City nvarchar(20),
Province nvarchar(20),
PostalCode nvarchar(7),
Mainduties nvarchar(1000),
Doctorate_PHD int, 
DoctorOfMdeicine int,
MasterDegree int,
Bachelor int,
College int,
Apprentice int,
Trade int,
SecondarySchool int,
Vocational int,
NotRequired int,
EduAdditionalInfo nvarchar(100),
SkillRequirement nvarchar(500),
Oral int,
OralEnglish int, 
OralFrench int,
OralEnglishorFrench int,
oralEnglishandFrench int,
Writing int,
WritingEnglish int, 
WritingFrench int,
WritingEnglishorFrench int,
WritingEnglishandFrench int,
OtherLanguage int,
OtherLangugeExplanation nvarchar(500),  -- use seperate sheet 
FullTime int,
FullTimeExplanation nvarchar(100),
HourlyWage money,  -- per hour
YearlyWage money,
Dayhours float,
WeeklyHours float,
MonthlyHours float,
OverTimeRate money,
OverTimeStart float,
LowestWage money,
HighestWage money,
NoEmployeeInSamePosition int,
Seasonal int,
DisabilityInsurance int,   -- check
DentalInsurance int,
Pension int,
ExtendedMedical int,
VacationDays int,
Remuneration int,
OtherBenefits nvarchar(100)
)

create table tblJobOffer2(
Id int not null primary key identity(1,1),
ApplicationID int,  -- Business information could be changed, so it only directly related to application, instead of Employer
IsUnionized int, 
UnionName nvarchar(50), -- if it's null, then means no union
UnionKnows int, 
UnionDoesnotKnow nvarchar(100),
UnionOpinion nvarchar(100),
-- 19(5593)	   Are there any federal/provincial/territorial certification, licensing or registration requirements for this job?
licenseRequired int, 
NameOfLicense nvarchar(50),
HaveLicense int,	   -- Yes No use 
WhenCanHaveDay int, -- how many days, weeks,months
WhenCanHaveWeek int, -- how many days, weeks,months
WhenCanHaveMonth int, -- how many days, weeks,months

AttemptedtoRecruitCnd int,
ExplainifNo nvarchar(100),
ProveYes nvarchar(100),
-- 22(5593) What are the potential benefits to Canadian
FillLabourShort int, 
SkillTransfer int,
JobCreation int,
Other int,
Details nvarchar(500),
--23(5593) Provide a rationale for the job offer you are making to the foreign worker(s) (e.g. what led to the vacancy of the position or creation of the position) and
--describe how this will meet your employment needs:
JobOfferRationale nvarchar(500),
--24(5593) Who is currently filling the duties and responsibilities of the position?
WhoElse nvarchar(100),
-- 25(5593)  How did you find or identify the foreign worker for this position?
HowToFindTheTFW nvarchar(500),
-- 26(5593)How did you determine that the foreign worker was qualified for the job?
WhyTFWQualified nvarchar(500),
--27(5593) How and when did you offer this job to the foreign worker?
HowAndWhen nvarchar(300),
-- 28(5593) Do you plan to hire or train Canadians/permanent residents for the position(s) for which you are requesting an LMIA?
NoTraining int,
ExplainNoTraining nvarchar(100),
DescriptionTrainingPlan nvarchar(100)

)

create table tblImpactLM(
Id int not null primary key identity(1,1),
ApplicationID int,  -- Business information could be changed, so it only directly related to application, instead of Employer
JobLoss int,  --  the TFW hiring will lead Canadian job lose?
JobLossExplain nvarchar(200),
OutSourcing int, 
ContractSummary nvarchar(200),
ImpactCanadian nvarchar(200),
HireWithoutLMIA int, 
RecruitEffort nvarchar(200), -- past 2 years hire effore
HiringImpactCanadian nvarchar(200)
) 

create table tblEmployee(
Id int not null primary key identity(1,1),
PersonId int,
OutCanadaCity nvarchar(20),
OutCanadaCountry nvarchar(20),
StatusinCanada nvarchar(20),
CanadaCity nvarchar(20),
CanadaProvince nvarchar(20),
Visitor int, 
Student int,
ForeignWorker int,
RefugeeClaimant int,
Hired int, 
Duration nvarchar(30)
)
