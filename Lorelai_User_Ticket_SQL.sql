create schema Lor_P1;

create table Lor_P1.users(
		user_ID int identity,
		legalname varchar(50)unique not null,
  		username varchar(50) unique not null,
  		password varchar(50) not null,
  		role varchar(30) not null,
  		primary key (user_ID)
  	);

create table Lor_P1.tickets(
		ticket_ID int identity,
		author varchar(100) unique not null,
		resolver varchar(100) unique not null,
		description varchar(255) not null,
		manager_note varchar(100)unique not null,
		amount double precision,
		ticket_fk varchar(50) foreign key references Lor_P1.users(username),
		primary key (ticket_ID)
);

insert into Lor_P1.users (legalname, username, password, role) values ('Laura', 'TheFakeLorLyons', 'P@ssw0rd!', 'manager');

insert into Lor_P1.users (legalname, username, password, role) values ('Lor', 'AnandamayiSoma', 'P@ssw0rd!', 'employee');

select * from Lor_P1.users

insert into Lor_P1.tickets (author, resolver, description, manager_note, amount) values ('Lorelai', 'Pending', 'Travel expenses', 'nothing', '10.57');