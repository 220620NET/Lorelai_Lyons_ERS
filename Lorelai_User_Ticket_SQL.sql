create schema Lor_P1; --schema for my tables

create table Lor_P1.users(
		user_Id int identity,
		legalName varchar(50)unique not null,
  		userName varchar(50) unique not null,
  		password varchar(50) not null,
  		role varchar(30) not null check (role in ('Employee', 'Manager')) default 'Employee',
  		primary key (user_ID)
 		);

create table Lor_P1.tickets(
		ticket_Id int identity,
		author_fk int not null foreign key references Lor_P1.users(user_Id),
		resolver_fk int not null foreign key references Lor_P1.users(user_Id),
		description varchar(255) not null,
		status varchar(8) not null check (status in ('Pending', 'Approved', 'Denied')) default 'Pending',
		manager_note varchar(100),
		amount money not null,
		primary key (ticket_ID)
		);

insert into Lor_P1.users (legalName, userName, password, role) values ('Laura', 'TheFakeLorLyons', 'P@ssw0rd!', 'Manager');

insert into Lor_P1.users (legalName, userName, password) values ('Lor', 'AnandamayiSoma', 'P@ssw0rd!');

select * from Lor_P1.users; --checking to ensure my default inputs worked

insert into Lor_P1.tickets (author_fk, resolver_fk, description, manager_note, amount) values (2, 1, 'Test Description', 'noteTest', '10.57');

select * from Lor_P1.tickets; --checking to ensure my default inputs worked

drop table Lor_P1.tickets;    --leaving both of these here in case I want to rework them later
drop table Lor_P1.users;      --will give me just some quick access to dropping and recreating.

select count(*) from Lor_P1.tickets where author_fk = 3;

select * from Lor_P1.tickets where author_fk = 1;