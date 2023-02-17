CREATE TABLE Card (
    Id int identity(1,1) primary key,
    IdClient int not null,
    Number varchar(16) not null,
    NameIn varchar(60) not null,
    ValidThru DateTime not null,
    CVC int not null
 )

