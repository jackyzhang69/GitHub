-- Create Study Permit application database
create database SP

-- Create Intended study information in Canada table
use SP
GO

-- Create Application type
create table tblApplicaitonTypes
(
Id int not null primary key Identity(1,1),
TypeCode int not null,  -- to  match CIC defenition
ApplicationType varchar(50) not null
)

insert into tblApplicaitonTypes values (1, 'Initial Study Permit')
insert into tblApplicaitonTypes values (1, 'Study Permit Extention')
insert into tblApplicaitonTypes values (2, 'Study Permit Restoration')
insert into tblApplicaitonTypes values (3, 'Initial Temporary Resident Permit')
insert into tblApplicaitonTypes values (3, 'Temporary Tesident Permit Extention')

-- Create Event table 
create table tblEvents
(
Id int not null primary key Identity(1,1),
WhatHappend varchar(50)
)

insert into tblEvents values ('Missed documents required')
insert into tblEvents values ('Medical exam required')
----------------------------------------------------------------------------------
create table tblStudyInfos
(
Id int not null primary key Identity(1,1),
ApplicationId int,  -- Fk to reference Application
SchoolName varchar(100) ,
LevelId int,
FieldId int,
ProvinceId int,  --FK to reference Province in Canada
CityId int,  -- Fk to reference city in Canada
SchoolAddress varchar(100),
DLINumber character(12),
StudentId varchar(15),
FromDate date,
Todate date,
Tuition int,
RoomAndBoard money,
Othercost money,
FundsAvailable money,
WhoPayId nvarchar(50),  --Fk to reference the payer
OtherPayer varchar(50),
ApplyWP Bit,
TypeofWP varchar(50),
CAQNumber varchar(50),
CAQExpriyDate date
)

-- Create Study Permit Application table
create table tblSPApplications
(
Id int not null primary key Identity(1,1),
PersonId int,   -- FK to reference the Person Id
ApplicationType int,  -- FK to reference the Application type
FileOpenDate date,
SubmissionDate date,
ResultDate date,
Notes varchar(1000)
)

-- Create follow up table
create table tblFollowUPs
(
Id int not null primary key Identity(1,1),
ApplicationId int,  --FK  Reference to Application Id
HappenDate date,
WhatHappenedId int, --FK reference to Event Id
ResponseDate date,
Response varchar(100)
)






