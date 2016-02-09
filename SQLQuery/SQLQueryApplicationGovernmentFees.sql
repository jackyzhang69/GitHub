
-- Create category table
create table tblCategory
(
Id int primary key not null identity,
Name varchar(100) not null
)
insert into tblCategory values('LMIA')
insert into tblCategory values('BCPNP')

-- Create Program table
create table tblProgram
(
Id int primary key not null identity,
Name varchar(100) not null,
FK_CategoryId int not null foreign key references tblCategory(Id)
)

-- Create Government fee table
create table tblGovernmentFee
(
Id int primary key not null identity,
Name varchar(100),
CName varchar(100),  -- Chinese name
CDescription varchar(500), --Chinese description
Fee Money  not null
)



-- Create intermediary table connecting Program and government fee tables
create table tblProgram_GovernmentFee
(
Id int primary key not null identity,
FK_GovernmentFeeId int not null foreign key  references tblGovernmentFee(Id),
FK_ProgramId int not null foreign key  references tblProgram(Id)
 )

 insert into tblProgram values ('LMIA for Work Permit',1)
 insert into tblGovernmentFee values('LIMA for work Permit Application Fee','支持工签的LMIA政府费',1000)
 insert into tblProgram_GovernmentFee values(1,1)
  insert into tblProgram values ('BCPNP Skilled Worker',2)
 insert into tblGovernmentFee values('BCPNP','BCPNP政府费',550)
 insert into tblProgram_GovernmentFee values(2,2)

 
 -- Function which returns Name and Fee by ProgramId
create function fn_getNameFeeByProgramId (@ProgramId int)
 returns table
 as
 return(
 select CName, Fee from tblGovernmentFee f
 inner join tblProgram_GovernmentFee pg
 on pg.FK_GovernmentFeeId=f.Id
 where FK_ProgramId=@ProgramId
 )

 -- call the function
 select * from fn_getNameFeeByProgramId(2)