create database Programing

use Programing
Go

-- Create knowledge table

create table tblKnowledges
(
Id int not null primary key identity(1,1),
KnowledgeType int not null,  -- FK to reference the type of knowledge
Tag varchar(100),
Syntax varchar(4000),
Sample varchar(8000)
)

-- Create knowledge type PK table
create table tblKnowledgeType
(
Id int not null primary key identity(1,1),
KnowledgeType varchar(20)
)

insert into tblKnowledgeType values('ALL')
insert into tblKnowledgeType values('SQL')
insert into tblKnowledgeType values('C#')
insert into tblKnowledgeType values('Itext')
insert into tblKnowledgeType values('XML')
insert into tblKnowledgeType values('PDF')

