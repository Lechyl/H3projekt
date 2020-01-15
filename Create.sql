--create database LongigantenDB;
/*
use LongigantenDB;



create table Kategorier(
	id int PRIMARY KEY IDENTITY(1,1),
	navn nvarchar(50) unique not null,
	parent_KategoriID int foreign key references Kategorier(id) null
	
);

create table Producent(
	id int primary key identity(1,1),
	producentNavn nvarchar(50) unique NOT NULL
);

create table Leverandor(
	id int primary key identity(1,1),
	leverandorNavn nvarchar(50) unique not null,
	kontaktPerson nvarchar(50) default 'ingen',
	email nvarchar(50) default 'ingen',
	telefon nvarchar(15) not null
);

create table Produkter(
	id int primary key identity(1,1),
	produktNavn nvarchar(100) unique not null,
	beskrivelse nvarchar(max) not null,
	pris decimal(8,2) check(pris > 0) not null,
	kategoriID int foreign key references Kategorier(id),
	producentID int foreign key references Producent(id),
	leverandorID int foreign key references Leverandor(id)
);
/*
create table PostNr(
	id int primary key not null,
	byNavn nvarchar(50) not null
);
*/
create table Adresser(
	id int primary key identity(1,1),
	postnrID int foreign key references PostNr(id),
	adresse nvarchar(100) unique not null,
	etage nvarchar(25) default 'ingen',
);

create table Butikker(
	id int primary key identity(1,1),
	adresseID int unique foreign key references Adresser(id)
);

create table Lager_Status(
	id int primary key identity(1,1),
	status nvarchar(20) unique not null

);

create table Butikker_har_Vare(
	produktID int foreign key references Produkter(id),
	butikID int foreign key references Butikker(id),
	statusID int foreign key references Lager_Status(id),
	antal int default 0
);

create table Afdelinger(
	id int primary key identity(1,1),
	afdeling nvarchar(50) unique not null,
	parent_Afdeling int foreign key references Afdelinger(id) null
);

create table Medarbejder(
	id int primary key identity(1,1),
	fornavn nvarchar(50) not null,
	efternavn nvarchar(50) not null,
	kontonr int not null,
	reg int not null,
	email nvarchar(50) default 'ingen',
	telefon nvarchar(15) not null,
	adresseID int foreign key references Adresser(id),
	afdelingID int foreign key references Afdelinger(id),
	butikID int foreign key references Butikker(id)
);

create table Kunder(
	id int primary key identity(1,1),
	fornavn nvarchar(50) not null,
	efternavn nvarchar(50) not null,
	email nvarchar(50) not null,
	telefon nvarchar(15) default 'ingen'
);

create table Adresse_Type(
	id int primary key identity(1,1),
	type nvarchar(50) not null,

);

create table Kunder_har_Adresser(
	adresseID int foreign key references Adresser(id),
	kundeID int foreign key references Kunder(id),
	adresseType int foreign key references Adresse_Type(id)
);

create table Ordre_Status(
	id int primary key identity(1,1),
	status nvarchar(25) unique not null
);

create table Ordre_Leverings_Metode(
	id int primary key identity(1,1),
	metodeNavn nvarchar(50) unique not null,
	pris decimal(8,2) check(pris > 0) not null
);

create table Ordre(
	id int primary key identity(1,1),
	opretsDato date default getdate(),
	kundeID int foreign key references Kunder(id),
	leveringsMetodeID int foreign key references Ordre_Leverings_Metode(id),
	leveringsAdresseID int foreign key references Adresser(id),
	statusID int foreign key references Ordre_Status(id)
);

create table Ordrelinjer(
	kundeID int foreign key references Kunder(id),
	ordreID int foreign key references Ordre(id),
	antal int check(antal > 0) not null,
	pris decimal(8,2) check(pris > 0) not null
);

create table Kunde_Support(
	id int primary key identity(1,1),
	medarbejderID int foreign key references Medarbejder(id),
	kundeID int foreign key references Kunder(id) null,
	beskrivelse nvarchar(max) not null
);*/