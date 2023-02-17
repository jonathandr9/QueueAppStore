CREATE TABLE Client(
	Id int primary key identity(1,1),
	Name varchar(100) not null,
	Cpf varchar(11) not null,
	DateOfBirth Datetime not null,
	Sex varchar(50) not null,
	Address varchar(255) not null,
	IdentityId UNIQUEIDENTIFIER not null
)
