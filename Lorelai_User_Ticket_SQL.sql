create schema Lor_P1; --schema for my tables

create table Lor_P1.users(
		user_Id int identity,
		legalName varchar(50)unique not null,
  		userName varchar(50) unique not null,
  		password varchar(50) not null,
  		role varchar(30) not null check (role in ('Employee', 'Manager')),
  		primary key (user_ID)
 		);

create table Lor_P1.tickets(
		ticket_Id int identity,
		author_fk int not null foreign key references Lor_P1.users(user_Id),
		resolver_fk int not null foreign key references Lor_P1.users(user_Id),
		description varchar(255) not null,
		status varchar(8) not null check (status in ('Pending', 'Approved', 'Denied')),
		manager_note varchar(100),
		amount decimal,
		primary key (ticket_ID)
		);

insert into Lor_P1.users (legalName, userName, password, role) values ('Laura', 'TheFakeLorLyons', 'P@ssw0rd!', 'Manager');

insert into Lor_P1.users (legalName, userName, password, role) values ('Lor', 'AnandamayiSoma', 'P@ssw0rd!', 'Employee');

select * from Lor_P1.users; --checking to ensure my default inputs worked

insert into Lor_P1.tickets (author_fk, resolver_fk, description, status, manager_note, amount) values (2, 1, 'Test Description', 'Pending', 'noteTest', '10.57');

select * from Lor_P1.tickets; --checking to ensure my default inputs worked

drop table Lor_P1.tickets;    --leaving both of these here in case I want to rework them later
drop table Lor_P1.users;      --will give me just some quick access to dropping and recreating.