create database Gestion_Conges
use Gestion_Conges
create table GesEmploye(
Matricule int primary key,
Nom varchar(30),
Prenom varchar(30),

)
ALTER TABLE GesEmploye drop Column TypeConge;
delete from GesEmploye;
DELETE FROM Conge

create table Conge(
Matricule int foreign key references GesEmploye(Matricule),
DateDebut date,
Duree int,
DateFin date,
primary key(Matricule),
)
ALTER TABLE Conge add TypeConge varchar(20) ;


select * from Conge
select * from GesEmploye
select * from Stock_Conge



create table Stock_Conge(
Matricule int foreign key references GesEmploye(Matricule),
NbrJours int default 26,
primary key(Matricule),
)

delete from Stock_Conge
create table Login(
UserName varchar(50) primary key,
Pass varchar(60),)

insert into Login values('Abdelhaq','AZER1234');
select * from Login
delete from Login

insert into GesEmploye values(4,'a','r');
insert into GesEmploye values(6,'a','r');