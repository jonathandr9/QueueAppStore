CREATE TABLE Order(
	Id int primary key identity(1,1),
	IdClient int not null,
	IdApp int not null,
	PaymentStatus int not null,
	Amounts int not null,
	LastCardDigits int not null,
	Value decimal(10,2) not null
)