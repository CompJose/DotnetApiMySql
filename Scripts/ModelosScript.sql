CREATE TABLE Modelos(
	Id int NOT null auto_increment,
	Nome varchar(20) NOT NULL,
	DataCriacao datetime(6) NOT NULL,
	NomeCriador varchar(30) NOT NULL,	
	PRIMARY KEY (Id)
);