use common
go

-- RCIC Information table
create table tblRCIC(
Id int not null primary key identity(1,1),
FirstName nvarchar(20),
MiddleName nvarchar(20),
LastName nvarchar(20),
JobTitle nvarchar(50),
Telephone nvarchar(15),
FaxNumber nvarchar(15),
Email nvarchar(50),
MembershipID nvarchar(10),
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

-- how to add image to column
update dbo.tblRCIC 
set Signature=(SELECT MyImage.* from Openrowset(Bulk 'C:\VBA\signature.png', Single_Blob) MyImage) 
where Id=2


-- Credit card table
create table tblCreditCard(
Id int not null primary key identity(1,1),
EmployerId int,
PersonId int,
CardType int , -- // 0 is visa, 1 is master 2 is american express
CardHolderName nvarchar(50),
--Last4Number nvarchar(4) not null,  this could be calculated by code
CardNumber nvarchar(16),
SecurityCode nvarchar(10),
ExpireMonth nvarchar(2),
ExpireYear nvarchar(4)
)

create table tblApplication(
Id int not null primary key identity(1,1),
ApplicantId int,
RCICId int,
ApplicationType int, -- need to define
CreatedDate date,
SubmittedDate date,
ClosedDate date,
ApplicationNumber nvarchar(20),
ApplicationFee money,
)

-- Create country PK table
create table tblCountry
(
Id int not null primary key Identity(1,1),
CountryCode int not null,  -- Match with CIC country code defenition
Country varchar(30) not null
)

-- Create Canada province PK table
create table tblCNDProvince
(
Id int not null primary key Identity(1,1),
ProvinceCode int not null,  -- Match with CIC country code defenition
Province varchar(2) not null
)
insert into tblCNDProvince values(1,'AB')
insert into tblCNDProvince values(2,'BC')
insert into tblCNDProvince values(3,'MB')
insert into tblCNDProvince values(4,'NB')
insert into tblCNDProvince values(5,'NL')
insert into tblCNDProvince values(6,'NS')
insert into tblCNDProvince values(7,'NT')
insert into tblCNDProvince values(8,'NU')
insert into tblCNDProvince values(9,'ON')
insert into tblCNDProvince values(10,'PE')
insert into tblCNDProvince values(11,'QC')
insert into tblCNDProvince values(12,'SK')
insert into tblCNDProvince values(13,'YT')

-- PK Table indicates education level
create table tblEducationLevel
(
Id int not null primary key Identity(1,1),
LevelCode int not null,  -- Matchs CIC defenition code
Level varchar(100) not null
)

insert into tblEducationLevel values(1,'Primary School')
insert into tblEducationLevel values(2,'Secondary School')
insert into tblEducationLevel values(3,'PTC/TCST/DVS/AVS')
insert into tblEducationLevel values(4,'CEGEP-Pre-universtiy')
insert into tblEducationLevel values(5,'CEGEP-Technical')
insert into tblEducationLevel values(6,'College-Certificate')
insert into tblEducationLevel values(7,'College-Diploma')
insert into tblEducationLevel values(8,'College-Applied Degree')
insert into tblEducationLevel values(9,'University-Bachelor Deg.')
insert into tblEducationLevel values(10,'University-Master Deg')
insert into tblEducationLevel values(11,'University-Doctorate')
insert into tblEducationLevel values(12,'University-Other Studies')
insert into tblEducationLevel values(13,'ESL/FSL')
insert into tblEducationLevel values(14,'ESL/FSL and College')
insert into tblEducationLevel values(16,'ESL/FSL and University')
insert into tblEducationLevel values(17,'Other Studies')
insert into tblEducationLevel values(18,'Not Applicable')


-- Creat Gender type PK table 
create table tblGender
(
Id int not null primary key Identity(1,1),
Gender varchar(7) not null
)

insert into tblGender values('Male')
insert into tblGender values('Female')
insert into tblGender values('Unknown')

-- Create Canada visit purpose PK table
create table tblCNDVisitPurpose
(
Id int not null primary key Identity(1,1),
PurposeCode int not null,  -- Matchs CIC defenition code
Purpose varchar(15) not null
)

insert into tblCNDVisitPurpose values (1,'Business')
insert into tblCNDVisitPurpose values (2,'Tourism')
insert into tblCNDVisitPurpose values (3,'Study')
insert into tblCNDVisitPurpose values (4,'Work')
insert into tblCNDVisitPurpose values (5,'Other')
insert into tblCNDVisitPurpose values (6,'Family Visit')

-- Creat phone type PK table
create table tblPhoneType
(
Id int not null primary key Identity(1,1),
TypeCode int not null,  -- Code matchs CIC Definition
Type varchar(10) not null
)

insert into tblPhoneType values(1, 'Residence')
insert into tblPhoneType values(2, 'Cellular')
insert into tblPhoneType values(3, 'Business')

-- Creat address type PK table
create table tblAddressType
(
Id int not null primary key Identity(1,1),
AddressType varchar(15) not null
)

insert into tblAddressType values('Residential')
insert into tblAddressType values('Business')
insert into tblAddressType values('Mailing')

-- Creat language type PK table
create table tblLanguageType
(
Id int not null primary key Identity(1,1),
TypeCode int,  -- Code matchs CIC Definition
LanguageType varchar(10)
)

-- Create marriage status type PK table
create table tblMarriageStatusType
(
Id int not null primary key Identity(1,1),
TypeCode int not null,   -- Type code matchs CIC defenition
MarriageStatusType varchar(20) not null,
)

insert into tblMarriageStatusType values (1, 'Annulled Marriage')
insert into tblMarriageStatusType values (2, 'Common-Law')
insert into tblMarriageStatusType values (3, 'Divorced')
insert into tblMarriageStatusType values (4, 'Legally Separated')
insert into tblMarriageStatusType values (5, 'Married')
insert into tblMarriageStatusType values (6, 'Single')
insert into tblMarriageStatusType values (7, 'Unknown')
insert into tblMarriageStatusType values (8, 'Widowed')

-- Create Status type PK table
create table tblStatusType
(
Id int not null primary key Identity(1,1),
TypeCode int not null,  -- Code matchs CIC Definition
StatusType varchar(20) not null
)
insert into tblStatusType values (1, 'Citizen')
insert into tblStatusType values (2, 'Permanent resident')
insert into tblStatusType values (3, 'Visitor')
insert into tblStatusType values (4, 'Worker')
insert into tblStatusType values (5, 'Student')
insert into tblStatusType values (6, 'Other')
insert into tblStatusType values (7, 'Protected Person')
insert into tblStatusType values (8, 'Refugee Claiment')
--Create Residence Type PK table
create table tblResidenceTypeId
(
Id int not null primary key Identity(1,1),
ResidenceType varchar(25)
)

insert into tblResidenceTypeId values('Current')
insert into tblResidenceTypeId values('Previous')
insert into tblResidenceTypeId values('Country where applying')

-------------------------------------------------------------------------

--alter table tblGenders
--add constraint DF_Gender
--default 3 for Id

-- Create education information 
-- PersonId: FK to reference the person who owns this education
-- LevelId: FK to reference the level of this eduation

create table tblEducation
(
Id int not null primary key Identity(1,1),
PersonId int,  -- Fk to reference the education owner
StartDate date,
EndDate date,
School varchar(100),
Program varchar(100),
LevelId int,  --FK to reference the educatin level
City varchar(50),
CountryId int, --FK to reference the country
ProvinceId int  --Fk to reference the Canada province
)

-- Create employment table
create table tblEmployment
(
Id int not null primary key Identity(1,1),
PersonId int,  -- FK to reference the Person Id
FromDate date,
ToDate date ,
ActivityorOccupation varchar(50) ,
CompanyorPlace varchar(100),
City varchar(50),
CountryId int,  -- FK to reference the country
ProvinceId int  --Fk to reference the Canada province
)

-- Create 

-- Create background information table
create table tblTRBackgroundInfo
(
Id int not null primary key Identity(1,1),
PersonId int,  -- FK to reference the Person Id,
Q1a bit ,  --within the past 2 years, have you or a family member ever had tuberculosis of the lungs or been in close contact with a person with tuberculosis?
Q1b bit ,
Q1c varchar(200),
Q2a bit ,
Q2b bit ,
Q2c bit ,
Q2d varchar(200),
Q3a bit ,
Q3b varchar(200),
Q4a bit ,
Q4b varchar(200),
Q5 bit ,
Q6 bit ,
)

-- Create coming to Canada table
create table tblTRCanadaVisit
(
Id int not null primary key Identity(1,1),
PersonId int,  -- FK to reference the Person Id,
OriginalEntryDate date,
OriginalEntryPlace varchar(20),
OriginalPurposeId int,  -- FK to reference the visit purpose
OtherPurpose varchar(50),
RecentEntryDate date,
RecentEntryPlace varchar(20),
MostRecentyDocNumber varchar(20)
)

-- Create Phone table
create table tblPhone
(
Id int not null primary key Identity(1,1),
PersonId int,  -- FK to reference the Person Id,
PhoneTypeId int , --FK to reference the phone type
CountryCode int ,
Number varchar(25)
)

--Create Address table
create table tblAddress
(
Id int not null primary key Identity(1,1),
PersonId int,  -- FK to reference the Person Id,
POBox varchar(10),
Unit varchar(20),
StreetNo varchar(15),
StreetName varchar(100),
City varchar(30),
CountryId int , -- FK to reference the Country
CNDProvinceId int,
PostalCode varchar(10),
AddressTypeId int
)

-- Create passport table
 create table tblPassport
(
Id int not null primary key Identity(1,1),
PersonId int ,  -- FK to reference the Person Id,
PassportNumber varchar(10),
Name nvarchar(30) ,
GenderId int,   -- 1 Male or 2 Female 3 unknown
BirthCountryId int, -- CIC Code 202 is China
NationalityId int ,   --reference the country code which Matchs CIC country definition
DOB date ,
BrithPlace varchar(20),
IssueDate date ,
IssuePlace varchar(20) ,
ExpiryDate date ,
IsValid bit 
)

-- Create language table
create table tblLanguage
(
Id int not null primary key Identity(1,1),
PersonId int ,  -- FK to reference the Person Id,
NativeLanguageId int ,  --FK to reference the language Id who matchs CIC defenition
English bit,
French bit 
)

-- Create marriage status table 
create table tblMarriage
(
Id int not null primary key Identity(1,1),
PersonId int ,  -- FK to reference the Person Id,
MarriageStatusId int,  --FK to reference marriage status
SpouseId int,   --FK to reference the Person Id
BeginDate date,
EndDate date
)

-- Create residence table

create table tblResidence
(
Id int not null primary key Identity(1,1),
PersonId int,  -- FK to reference the Person Id,
CountryId int , --Fk to reference the Country Id
StatusID int ,  --Fk to reference the Status Id
Other varchar(20),
FromDate date,
ToDate date ,
ResidenceTypeId int   --FK to reference the type of residence
)

-- Create person table

create table tblPerson
(
Id int not null primary key Identity(1,1),
FirstName varchar(20),
MiddleName varchar(20),
LastName varchar(20),
IsAliasName bit,
AliasLastName varchar(20),
AliasFirstName varchar(20),
UCI int
)


