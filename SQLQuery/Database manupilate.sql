-- Copy table

select Name,telephone into Persons
from Persons1
where 1=0

-- copy table data

INSERT INTO Persons (Name,Telephone)
SELECT [Name],[Telephone]
FROM Persons1

create table Persons
(
Id int not null primary key identity(1,1),
Name varchar(50) not null,
Telephone varchar(12)
)


insert into Persons  values('Jacky','7783215110')
insert into Persons values('May','7788985110')

insert into tblKnowledges(KnowledgeType,Tag,Syntax,Sample)
select KnowledgeType,Tag,Syntax,Sample from tblKnowledges1
