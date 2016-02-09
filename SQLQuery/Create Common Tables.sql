use common
go

-- Create country PK table
create table tblCountries
(
Id int not null primary key Identity(1,1),
CountryCode int not null,  -- Match with CIC country code defenition
Country varchar(30) not null
)

-- Create Canada province PK table
create table tblCNDProvinces
(
Id int not null primary key Identity(1,1),
ProvinceCode int not null,  -- Match with CIC country code defenition
Province varchar(2) not null
)
insert into tblCNDProvinces values(1,'AB')
insert into tblCNDProvinces values(2,'BC')
insert into tblCNDProvinces values(3,'MB')
insert into tblCNDProvinces values(4,'NB')
insert into tblCNDProvinces values(5,'NL')
insert into tblCNDProvinces values(6,'NS')
insert into tblCNDProvinces values(7,'NT')
insert into tblCNDProvinces values(8,'NU')
insert into tblCNDProvinces values(9,'ON')
insert into tblCNDProvinces values(10,'PE')
insert into tblCNDProvinces values(11,'QC')
insert into tblCNDProvinces values(12,'SK')
insert into tblCNDProvinces values(13,'YT')

-- PK Table indicates education level
create table tblEducationLevels
(
Id int not null primary key Identity(1,1),
LevelCode int not null,  -- Matchs CIC defenition code
Level varchar(100) not null
)

insert into tblEducationLevels values(1,'Primary School')
insert into tblEducationLevels values(2,'Secondary School')
insert into tblEducationLevels values(3,'PTC/TCST/DVS/AVS')
insert into tblEducationLevels values(4,'CEGEP-Pre-universtiy')
insert into tblEducationLevels values(5,'CEGEP-Technical')
insert into tblEducationLevels values(6,'College-Certificate')
insert into tblEducationLevels values(7,'College-Diploma')
insert into tblEducationLevels values(8,'College-Applied Degree')
insert into tblEducationLevels values(9,'University-Bachelor Deg.')
insert into tblEducationLevels values(10,'University-Master Deg')
insert into tblEducationLevels values(11,'University-Doctorate')
insert into tblEducationLevels values(12,'University-Other Studies')
insert into tblEducationLevels values(13,'ESL/FSL')
insert into tblEducationLevels values(14,'ESL/FSL and College')
insert into tblEducationLevels values(16,'ESL/FSL and University')
insert into tblEducationLevels values(17,'Other Studies')
insert into tblEducationLevels values(18,'Not Applicable')


-- Creat Gender type PK table 
create table tblGenders
(
Id int not null primary key Identity(1,1),
Gender varchar(7) not null
)

insert into tblGenders values('Male')
insert into tblGenders values('Female')
insert into tblGenders values('Unknown')

-- Create Canada visit purpose PK table
create table tblCNDVisitPurposes
(
Id int not null primary key Identity(1,1),
PurposeCode int not null,  -- Matchs CIC defenition code
Purpose varchar(15) not null
)

insert into tblCNDVisitPurposes values (1,'Business')
insert into tblCNDVisitPurposes values (2,'Tourism')
insert into tblCNDVisitPurposes values (3,'Study')
insert into tblCNDVisitPurposes values (4,'Work')
insert into tblCNDVisitPurposes values (5,'Other')
insert into tblCNDVisitPurposes values (6,'Family Visit')

-- Creat phone type PK table
create table tblPhoneTypes
(
Id int not null primary key Identity(1,1),
TypeCode int not null,  -- Code matchs CIC Definition
Type varchar(10) not null
)

insert into tblPhoneTypes values(1, 'Residence')
insert into tblPhoneTypes values(2, 'Cellular')
insert into tblPhoneTypes values(3, 'Business')

-- Creat address type PK table
create table tblAddressTypes
(
Id int not null primary key Identity(1,1),
AddressType varchar(15) not null
)

insert into tblAddressTypes values('Residential')
insert into tblAddressTypes values('Mailing')

-- Creat language type PK table
create table tblLanguageTypes
(
Id int not null primary key Identity(1,1),
TypeCode int not null,  -- Code matchs CIC Definition
LanguageType varchar(10) not null
)

-- Create marriage status type PK table
create table tblMarriageStatusTypes
(
Id int not null primary key Identity(1,1),
TypeCode int not null,   -- Type code matchs CIC defenition
MarriageStatusType varchar(20) not null,
)

insert into tblMarriageStatusTypes values (1, 'Annulled Marriage')
insert into tblMarriageStatusTypes values (2, 'Common-Law')
insert into tblMarriageStatusTypes values (3, 'Divorced')
insert into tblMarriageStatusTypes values (4, 'Legally Separated')
insert into tblMarriageStatusTypes values (5, 'Married')
insert into tblMarriageStatusTypes values (6, 'Single')
insert into tblMarriageStatusTypes values (7, 'Unknown')
insert into tblMarriageStatusTypes values (8, 'Widowed')

-- Create Status type PK table
create table tblStatusTypes
(
Id int not null primary key Identity(1,1),
TypeCode int not null,  -- Code matchs CIC Definition
StatusType varchar(20) not null
)
insert into tblStatusTypes values (1, 'Citizen')
insert into tblStatusTypes values (2, 'Permanent resident')
insert into tblStatusTypes values (3, 'Visitor')
insert into tblStatusTypes values (4, 'Worker')
insert into tblStatusTypes values (5, 'Student')
insert into tblStatusTypes values (6, 'Other')
insert into tblStatusTypes values (7, 'Protected Person')
insert into tblStatusTypes values (8, 'Refugee Claiment')

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

create table tblEducations
(
Id int not null primary key Identity(1,1),
PersonId int not null,  -- Fk to reference the education owner
StartDate date not null,
EndDate date not null,
School varchar(100) not null,
Program varchar(100),
LevelId int not null,  --FK to reference the educatin level
City varchar(50) not null,
CountryId int not null, --FK to reference the country
ProvinceId int  --Fk to reference the Canada province
)

-- Create employment table
create table tblEmployments
(
Id int not null primary key Identity(1,1),
PersonId int not null,  -- FK to reference the Person Id
FromDate date not null,
ToDate date not null,
ActivityorOccupation varchar(50) not null,
CompanyorPlace varchar(100) not null,
City varchar(50) not null,
CountryId int not null,  -- FK to reference the country
ProvinceId int  --Fk to reference the Canada province
)

-- Create 

-- Create background information table
create table tblTRBackgroundInfos
(
Id int not null primary key Identity(1,1),
PersonId int not null,  -- FK to reference the Person Id,
Q1a bit not null,  --within the past 2 years, have you or a family member ever had tuberculosis of the lungs or been in close contact with a person with tuberculosis?
Q1b bit not null,
Q1c varchar(200),
Q2a bit not null,
Q2b bit not null,
Q2c bit not null,
Q2d varchar(200),
Q3a bit not null,
Q3b varchar(200),
Q4a bit not null,
Q4b varchar(200),
Q5 bit not null,
Q6 bit not null,
)

-- Create coming to Canada table
create table tblTRCanadaVisits
(
Id int not null primary key Identity(1,1),
PersonId int not null,  -- FK to reference the Person Id,
OriginalEntryDate date not null,
OriginalEntryPlace varchar(20) not null,
OriginalPurposeId int not null,  -- FK to reference the visit purpose
OtherPurpose varchar(50),
RecentEntryDate date,
RecentEntryPlace varchar(20),
MostRecentyDocNumber varchar(20)
)

-- Create Phone table
create table tblPhones
(
Id int not null primary key Identity(1,1),
PersonId int not null,  -- FK to reference the Person Id,
PhoneTypeId int not null, --FK to reference the phone type
CountryCode int not null,
Number int not null
)

--Create Address table
create table tblAddresses
(
Id int not null primary key Identity(1,1),
PersonId int not null,  -- FK to reference the Person Id,
POBox varchar(10),
Unit varchar(20),
StreetNo varchar(15),
StreetName varchar(100) not null,
City varchar(30) not null,
CountryId int not null, -- FK to reference the Country
CNDProvinceId int,
PostalCode varchar(10),
AddressTypeId int not null
)

-- Create passport table
create table tblPassports
(
Id int not null primary key Identity(1,1),
PersonId int not null,  -- FK to reference the Person Id,
PassportNumber varchar(10) not null,
Name varchar(30) not null,
GenderId int not null,   --FK to reference the gender 
NationalityId int not null,   --FK to reference the country code which Matchs CIC country definition
DOB date not null,
BrithPlace varchar(20) not null,
IssueDate date not null,
IssuePlace varchar(20) not null,
ExpiryDate date not null,
IsValid bit not null
)

-- Create language table
create table tblLanguages
(
Id int not null primary key Identity(1,1),
PersonId int not null,  -- FK to reference the Person Id,
NativeLanguageId int not null,  --FK to reference the language Id who matchs CIC defenition
English bit not null,
French bit not null
)

-- Create marriage status table 
create table tblMarriages
(
Id int not null primary key Identity(1,1),
PersonId int not null,  -- FK to reference the Person Id,
MarriageStatusId int not null,  --FK to reference marriage status
SpouseId int,   --FK to reference the Person Id
BeginDate date,
EndDate date
)

-- Create residence table

create table tblResidences
(
Id int not null primary key Identity(1,1),
PersonId int not null,  -- FK to reference the Person Id,
CountryId int not null, --Fk to reference the Country Id
StatusID int not null,  --Fk to reference the Status Id
Other varchar(20),
FromDate date not null,
ToDate date not null,
ResidenceTypeId int not null  --FK to reference the type of residence
)

-- Create person table

create table tblPersons
(
Id int not null primary key Identity(1,1),
FirstName varchar(20) not null,
MiddleName varchar(20),
LastName varchar(20) not null,
IsAliasName bit not null,
AliasLastName varchar(20),
AliasFirstName varchar(20),
UCI int
)

-- Create media table
create table tblMedia
(
Id int not null primary key Identity(1,1),
MediaName nvarchar(100) not null, 
Type nvarchar(30) not null,
Scope nvarchar(30) not null,
Cost Money not null,
Duration int,
Comments nvarchar(200)
)

-- Creat Job AD tracking table
create table tblJobAdPost(
Id int primary key Identity(1,1),
AppId int not null,
MediaId int not null,	    
StartDate date not null,
EndDate date,
IsPrinted bit not null,
ProvenDuration int 
)
