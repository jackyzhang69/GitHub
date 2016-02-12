-- Create tables for LMIA job ad, media, and jobposting monitoring
-- Should be stored in LMIA database

create table tblJobAd(
Id int primary key not null identity(1,1),
AppId int not null,  -- foreign key to Application Id
OperatingName nvarchar(100),
BusinessAddress nvarchar(150),
WorkLocation nvarchar(150),
TitleofPosition nvarchar(100),
Terms nvarchar(150),
Wage money,
Benefits nvarchar(150),
JobDuties nvarchar(1000),
ContactInfo nvarchar(200),
EducationReq nvarchar(150),
ExperienceReq nvarchar(200),
SkillReq nvarchar(200),
LanguageReq nvarchar(100)
)


create table tblMedia(
Id int primary key not null identity(1,1),
MediaName nvarchar(50) not null,
MediaType nvarchar(30) not null,
MediaScope nvarchar(20) not null,
Cost money not null,
ADDays int,
Pro nvarchar(200),
Con nvarchar(200)
)

create table tblJobPosting(
Id int primary key not null identity(1,1),
AppId int not null,  -- foreign key to Application Id
MediaId int not null,
PostDate date,
ExpiryDate date,
InitialPrintDate date,
LastPrintDate date,
ADDays int,
Invoice bit,
CurrentStatus  nvarchar(20),
Account nvarchar(100),
AccountPassword nvarchar(100),
Cost money,
JobAdLink nvarchar(200),
Remark nvarchar(100)
)
