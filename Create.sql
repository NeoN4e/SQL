create database MyDatabase on primary (name=MyTestDb,filename='D:\\MyBaze.mf',size=10MB,maxsize=20Mb,filegrowth=10%)
log on(name=MyTestDb_log,filename='D:\\MyBaze.log',size=20MB,maxsize=20Mb,filegrowth=1MB)
drop database MyDatabase

use MyDatabase
create table Mytable (
id int primary key identity(1,1),
firstname nvarchar(70) not null,
lastname nvarchar(70) not null,
age int null
)

insert into Mytable values('Vasya','Pypkin',null)

select * from Mytable