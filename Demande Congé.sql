create database Demande_Cong�
use Demande_Cong�
create table DemandeConge(
Matricule int primary key,
Nom varchar(50),
Prenom varchar(50),
Type_Conge varchar(50),
Duree int ,
Date_Debut date,
Remarques varchar(1000),)
