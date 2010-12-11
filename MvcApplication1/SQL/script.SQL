/*
Created: 24/01/2009
Modified: 25/11/2006
Model: MS SQL Server 2008
Database: MS SQL Server 2008
*/

USE MASTER 
GO 

-- Create Database section -------------------------------------------------
IF EXISTS(SELECT NAME FROM SYS.DATABASES WHERE NAME = 'twisted') 
BEGIN 
	DROP DATABASE twisted 
END 
	CREATE DATABASE twisted 
GO 

PRINT 'La base de datos: twisted ha sido creada con exito. Gracias, j2l Team.' 
GO 

USE twisted 
GO 

-- Create tables section -------------------------------------------------

-- Table Viaje

CREATE TABLE [Viaje]
(
 [idViaje] Int IDENTITY(1,1)PRIMARY KEY CLUSTERED,
 [nombre] Varchar(25) NOT NULL,
 [fechaInicio] Date NOT NULL,
 [fechaFin] Date NOT NULL,
 [hospedaje] Varchar(50) NOT NULL,
 [privacidad] Varchar(25) NOT NULL,
 [destino] Varchar(35) NULL
)
go

-- Table Destino

CREATE TABLE [Destino]
(
 [idDestino] Int IDENTITY(1,1)PRIMARY KEY CLUSTERED,
 [nombre] Varchar(60) NOT NULL,
 [latitud] Float NOT NULL,
 [longitud] Float NOT NULL,
 [estatus] Varchar(25) NOT NULL,
 [url] Varchar(100) NOT NULL,
 [fecha] Date NULL,
 [direccion] Varchar(150) NULL,
 [descripcion] Varchar(150) NULL,
 [idViaje] Int NULL
)
go

-- Table Persona

CREATE TABLE [Persona]
(
 [nickname] Varchar(30) NOT NULL,
 [nombre] Varchar(25) NOT NULL,
 [apellido] Varchar(25) NOT NULL,
 [email] Varchar(100) NOT NULL,
 [fechaNacimiento] Date NOT NULL,
 [privacidad] Varchar(25) NOT NULL,
 [twitter] Varchar(30) NULL,
 [estatus] Varchar(25) NULL
)
go

-- Add keys for table Persona

ALTER TABLE [Persona] ADD CONSTRAINT [idPersona] PRIMARY KEY ([nickname])
go

-- Table Participante

CREATE TABLE [Participante]
(
 [idViaje] Int NOT NULL,
 [nickname] Varchar(30) NOT NULL,
 [tipo] Varchar(25) NOT NULL
)
go

-- Add keys for table Participante

ALTER TABLE [Participante] ADD CONSTRAINT [Key1] PRIMARY KEY ([idViaje],[nickname])
go

-- Table Amistad

CREATE TABLE [Amistad]
(
 [nicknameAmigo] Varchar(30) NOT NULL,
 [nickname] Varchar(30) NOT NULL,
 [fecha] Date NULL
)
go

-- Add keys for table Amistad

ALTER TABLE [Amistad] ADD CONSTRAINT [Key2] PRIMARY KEY ([nickname],[nicknameAmigo])
go

-- Table Comentario

CREATE TABLE [Comentario]
(
 [idDestino] Int NOT NULL,
 [nickname] Varchar(30) NOT NULL,
 [descripcion] Varchar(150) NOT NULL,
 [fecha] Date NOT NULL
)
go

-- Add keys for table Comentario

ALTER TABLE [Comentario] ADD CONSTRAINT [Key3] PRIMARY KEY ([idDestino],[nickname])
go

-- Table Foto

CREATE TABLE [Foto]
(
 [idFoto] Int IDENTITY(1,1)PRIMARY KEY CLUSTERED,
 [url] Varchar(100) NOT NULL,
 [nombre] Varchar(25) NULL,
 [descripcion] Varchar(150) NULL,
 [idViaje] Int NULL
)
go

-- Create relationships section ------------------------------------------------- 

ALTER TABLE [Participante] ADD CONSTRAINT [Relationship1] FOREIGN KEY ([idViaje]) REFERENCES [Viaje] ([idViaje])
go

ALTER TABLE [Participante] ADD CONSTRAINT [Relationship2] FOREIGN KEY ([nickname]) REFERENCES [Persona] ([nickname])
go

ALTER TABLE [Amistad] ADD CONSTRAINT [Relationship4] FOREIGN KEY ([nickname]) REFERENCES [Persona] ([nickname])
go

ALTER TABLE [Amistad] ADD CONSTRAINT [Relationship5] FOREIGN KEY ([nicknameAmigo]) REFERENCES [Persona] ([nickname])
go

ALTER TABLE [Destino] ADD CONSTRAINT [Relationship6] FOREIGN KEY ([idViaje]) REFERENCES [Viaje] ([idViaje])
go

ALTER TABLE [Comentario] ADD CONSTRAINT [Relationship7] FOREIGN KEY ([idDestino]) REFERENCES [Destino] ([idDestino])
go

ALTER TABLE [Comentario] ADD CONSTRAINT [Relationship8] FOREIGN KEY ([nickname]) REFERENCES [Persona] ([nickname])
go

ALTER TABLE [Foto] ADD CONSTRAINT [Relationship9] FOREIGN KEY ([idViaje]) REFERENCES [Viaje] ([idViaje])
go




