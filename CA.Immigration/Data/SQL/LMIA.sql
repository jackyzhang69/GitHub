-- RCIC Information table

create table tblRCIC(
Id int not null primary key identity(1,1),
FirstName nvarchar(20) not null,
MiddleName nvarchar(20),
LastName nvarchar(20) not null,
JobTitle nvarchar(50),
Telephone nvarchar(15),
FaxNumber nvarchar(15),
Email nvarchar(50) not null,
MembershipID nvarchar(10) not null,
BusinessOperatingName nvarchar(50),
CRABN nvarchar(15),
BusinessLegalName nvarchar(50),
ESDCThirdPartyID nvarchar(20),
MailingAddress nvarchar(30),
BusinessAddress nvarchar(30),
City nvarchar(20),
Province nvarchar(10),
Country nvarchar(20),
PostalCode nvarchar(10),
MainBizActivities nvarchar(100)
)

create table tblCreditCard(
Id int not null primary key identity(1,1),
CardType int not null, -- 1 Visa 2 MasterCard 3 American Express
CardHolderName nvarchar(50) not null,
--Last4Number nvarchar(4) not null,  this could be calculated by code
CardNumber nvarchar(16) not null,
SecurityCode nvarchar(10) not null,
ExpireMonth nvarchar(2) not null,
ExpireYear nvarchar(4) not null
)

create table tblEmployee(
Id int not null primary key identity(1,1),
FirstName nvarchar(20) not null,
MiddleName nvarchar(20),
LastName nvarchar(20) not null,
Gender nvarchar(6) not null,
DOB date not null,
Citizen nvarchar(20) not null,
OutCanadaCountry nvarchar(20),
OutCanadaCity nvarchar(20),
InCanadaCity nvarchar(20),
InCanadaProvince nvarchar(2),
Status nvarchar(20) not null,
EmployedorEmploying bit not null,
EmploymentStart date,
EmploymentEnd date 
)


-- If a required document is not attached, please explain:  do it someday
-- Market impact table ... do it someday


-- Recruitment Summary 
create table tblRecruitSummary(
Id int not null primary key identity(1,1),
CndResumesReceived int not null,  --How Many Canadians/PRs' resumes received
CndInterviewed int not null, --How many Canadians/PRs are interviewed
CndNotQualified int not null,  --How many Canadians/PRs are not qualified
CndJobOffered int not null,  --How many jobs offered to Canadians/PRs
CndOfferDeclined int not null,  --How many job offer declined by Canadians/PRs
CndHired int not null,  --How many Canadians/PRs are hired
WhyNotCnd nvarchar(4000) --Please explain why each Canadians/PRs is not qualified
)


-- Employer information
create table tblEmployer(
Id int not null primary key identity(1,1),
ESDCId int,   -- if not first apply, should have a ESDC employer ID
CRA_BN nvarchar(15) ,  -- CRA Business Number 
LegalName nvarchar(50) ,
OperatingName nvarchar(50),
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
Id int not null primary key identity(1,1),
EmployerID int not null,
EmployeeId int,
LMIAType int not null, -- 1 Only for PR, 2 PR+WP 3 N/A  // this data can be stored in codes
AnotherEmployer int not null, -- 1 Skilled trader only with one employer, 2 there are other employer
SecondEmployer nvarchar(30),
PayMethod int not null  -- Method of Payment:1 Certified cheque or money order (postal or bank) made payable to the Receiver General for Canada 2 Credit Card
)


--Business detail table
create table tblBusinessDetail (
Id int not null primary key identity(1,1),
ApplicationID int not null,  -- Business information could be changed, so it only directly related to application, instead of Employer
TotalEmployeeUnderCRA int, --"1. Number of employees currently employed nationally under this Canada Revenue Agency Business number (e.g. 5 franchises are covered by the business
                                           -- number and there are a total of 100 employees):"

TotalEmployeeThisLocation int, --2. Total number of employees currently employed at the work location specified on this form:

TotalCndThisLocation int, --3. Total number of Canadian/permanent resident employees at the work location specified on this form:

TotalEmployeeThisOccupationLocation int,  --4. Total number of employees (including Canadians/permanent residents and TFWs) working in this occupation at this work location:
TotalTFWAfterPositive int,  --5. Total number of foreign workers (as a result of receiving a positive LMIA) at the work location specified on this form:


)




-- Job offer table, do it later...
