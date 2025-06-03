
--CREATE DATABASE Inmobiliaria_TPC
--GO

--USE Inmobiliaria_TPC
--GO

--/*Tabala aun sin definir
--TipoPropiedad
--Provincia
--Rol
--TipoOperacion
--Servicio
--Propietario
--Inmobiliaria
--Propiedad
--Contactos
--...
--*/

--CREATE TABLE TipoPropiedad (
--    IdTipo INT IDENTITY(1,1) PRIMARY KEY,
--    Descripcion NVARCHAR(100) NOT NULL
--);

--CREATE TABLE Provincia (
--    IdProvincia INT IDENTITY(1,1) PRIMARY KEY,
--    Nombre NVARCHAR(100) NOT NULL
--);

--CREATE TABLE Rol (
--    IdRol INT IDENTITY(1,1) PRIMARY KEY,
--    Descripcion NVARCHAR(100) NOT NULL
--);

--CREATE TABLE TipoOperacion (
--    IdTipoOperacion INT IDENTITY(1,1) PRIMARY KEY,
--    Descripcion NVARCHAR(100) NOT NULL
--);

--CREATE TABLE Servicio (
--    IdServicio INT IDENTITY(1,1) PRIMARY KEY,
--    Descripcion NVARCHAR(255) NOT NULL,
--    IdPropiedad INT NOT NULL,
--    FOREIGN KEY (IdPropiedad) REFERENCES TipoPropiedad(IdTipo)
--);

--CREATE TABLE Propietario (
--    IdPropietario INT PRIMARY KEY IDENTITY(1,1),
--    Nombre VARCHAR(50),
--    Apellido VARCHAR(50),
--    Documento VARCHAR(20),
--    Email VARCHAR(100),
--    Telefono VARCHAR(20),
--    Direccion VARCHAR(100),
--    Localidad VARCHAR(50),
--    IdProvincia INT,
--	FOREIGN KEY (IdProvincia) REFERENCES Provincia(IdProvincia)
--);

--CREATE TABLE Inmobiliaria (
--    IdInmobiliaria INT PRIMARY KEY IDENTITY(1,1),
--    Nombre VARCHAR(100),
--    Email VARCHAR(100),
--    Telefono VARCHAR(20),
--    Direccion VARCHAR(100),
--    Localidad VARCHAR(50),
--    IdProvincia INT,
--    FOREIGN KEY (IdProvincia) REFERENCES Provincia(IdProvincia)
--);

--CREATE TABLE Propiedad (
--    IdPropiedad INT PRIMARY KEY IDENTITY(1,1),
--    Descripcion VARCHAR(255),
--    Ambientes INT,
--    Sup_m2_Total DECIMAL(10,2),
--    Sup_m2_Cubierto DECIMAL(10,2),
--    Dormitorios INT,
--    Baños INT,
--    ConPatio BIT,
--	ConBalcón BIT,
--    IdTipo INT,
--    Direccion VARCHAR(100),
--    Localidad VARCHAR(50),
--    IdProvincia INT,
--    AnosAntiguedad INT,
--    AptoCredito BIT,
--    Reservada BIT,
--    IdPropietario INT,

--    FOREIGN KEY (IdTipo) REFERENCES TipoPropiedad(IdTipo),
--    FOREIGN KEY (IdProvincia) REFERENCES Provincia(IdProvincia),
--    FOREIGN KEY (IdPropietario) REFERENCES Propietario(IdPropietario)
--);


--CREATE TABLE Contactos (
--    IdContacto INT PRIMARY KEY IDENTITY(1,1),
--    Nombre VARCHAR(50),
--    Apellido VARCHAR(50),
--    Email VARCHAR(100),
--    Telefono VARCHAR(20),
--    IdPropiedad INT,
--    IdTipoOperacion INT,
--    FOREIGN KEY (IdPropiedad) REFERENCES Propiedad(IdPropiedad),
--    FOREIGN KEY (IdTipoOperacion) REFERENCES TipoOperacion(IdTipoOperacion)
--);

--CREATE TABLE Imagenes (
--    IdImagen INT PRIMARY KEY IDENTITY(1,1),
--    IdPropiedad INT,
--    UrlImagen NVARCHAR(255)
--    FOREIGN KEY (IdImagen) REFERENCES Propiedad(IdPropiedad),
--);