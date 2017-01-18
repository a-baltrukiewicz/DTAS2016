--Micha³ G³azik
--baza TAS
--v0.4.1
--
--v0.4.1: U³atwienie usuwania Userów
--v0.4.0: Uciek³a, zniknê³a w odmêtach Git-a :(
--v0.3.0: Poprawiono tagi.
--v0.2.0: Testowanie bazy, poprawki b³êdów.
--v0.1.0: Nietestowana jeszcze baza, a dok³adniej jej szkielet.
--


drop table FilledPolls
drop table Questions
drop table Polls
drop table Users
drop table QuestionTable
drop table AnswersTable
drop table FilledFields
drop table Tags
drop table TagsTable


create table Users
(
	ID			int				primary key IDENTITY(1,1), 
	firstName	varchar(100)	not null,
	lastName	varchar(100)	not null,
	email		varchar(100),
	password	varchar(100),
	sex			varchar(10),
	deleted		int
)

create table Polls
(
	ID			int				primary key IDENTITY(1,1),
	name		varchar(200),
	description	varchar(1000),
	addingDate	date,
	expirationDate	date
)

create table Tags
(
	ID			int				primary key IDENTITY(1,1),
	tagText		varchar(100)
)

create table TagsTable
(
	pollID		int				foreign key references Polls(ID),
	tagID		int				foreign key references Tags(ID)
)


create table Questions
(
	ID			int				primary key IDENTITY(1,1),
	openQstn	bit,
	question	varchar(1000)
)

create table QuestionTable
(
	pollID		int				foreign key references Polls(ID),
	questionID	int				foreign key references Questions(ID)
)

create table AnswersTable
(
	questionID	int				references Questions(ID),
	text		varchar(1000)
)

create table FilledPolls
(
	userID		int				references Users(ID),
	pollID		int				references Polls(ID),
	ID			int				primary key IDENTITY(1,1),
)

create table FilledFields
(
	fillID		int				foreign key references FilledPolls(ID),
	questionID	int				references Questions(ID),
	answer		varchar(500)
)



--Testowe zainicjowanie bazy

insert into Users values ( 'Micha³', 'G³azik', 'michal.glazik@mail.com', '123456','M', 0)
insert into Polls values ('Testowa ankieta', 'Brak', getdate(), NULL)
insert into Questions values (1, 'Wyjaœnij sens pisania w Javie.'),
	(1, 'W jakim jêzyku programujesz najczêœciej?')
insert into QuestionTable values (1,1), (1,2)
insert into FilledPolls values (1, 1)
insert into FilledFields values (1, 1, 'Pisanie w Javie nie ma sensu XD') ,
	(1, 2, 'Ostatnio najczêœciej w Pythonie 3.')

insert into Users values ('Kamil', 'Hliwa', 'elas@mail.com' ,'password','M', 0)
insert into Polls values ('Ankieta z zamknietymi pytaniami', 'Brak', getdate(), NULL)
insert into Questions values (0, 'Co wybierasz na obiad?'),
	(0, 'Która z tych gier zapad³a Ci w pamiêæ najbardziej?')
insert into QuestionTable values (2, 3), (2, 4)
insert into FilledPolls values (2, 2)
insert into AnswersTable values (3, 'Ziemniaki'), (3, 'Ry¿'), (3, 'Kaszê'), (4, 'WiedŸmin'),  (4, 'Half-Life'), (4, 'Call of Duty')
insert into FilledFields values (2, 3, 'Ziemniaki') , (2, 4, 'Wiedzmin')
insert into Users values ('Jan', 'Bachleda', 'janbach@a.com', 'pswd', 'M', 0)
insert into Tags values ('ksiazki'), ('jedzenie'), ('gry'), ('trudna_ankieta')
insert into TagsTable values (1, 4), (2, 3)
