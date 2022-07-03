use Reviews
go

create table Reviews (
Id int IDENTITY(1,1) CONSTRAINT PK_Id primary key not null,
Shop_name nvarchar(255) not null,
Text nvarchar(400) not null,
CreationDate datetime not null
)

create table User_(
Id_user int identity(1,1) constraint PK_user primary key not null,
Name nvarchar(255) not null,
Birth datetime not null,
Id_account int not null,
Mail nvarchar(255) not null
)

create table User_rating(
Id_user int foreign key references User_(Id_user) not null,
Id int foreign key references Reviews(Id) not null
)

create table Account_data(
Id_account int identity(1,1) constraint PK_account primary key not null,
Login nvarchar(255) not null,
Password nvarchar(255) not null,
Role nvarchar(255) not null,
Id_user int foreign key references User_(Id_user) not null
)