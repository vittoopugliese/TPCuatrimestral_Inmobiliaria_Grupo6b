
CREATE DATABASE Inmobiliaria_TPC
GO

DROP DATABASE Inmobiliaria_TPC;

USE Inmobiliaria_TPC
GO

CREATE TABLE TipoPropiedad (
    IdTipo INT IDENTITY(1,1) PRIMARY KEY,
    Descripcion NVARCHAR(100) NOT NULL
);

CREATE TABLE Provincia (
    IdProvincia INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL
);

CREATE TABLE Rol (
    IdRol INT IDENTITY(1,1) PRIMARY KEY,
    Descripcion NVARCHAR(100) NOT NULL
);


CREATE TABLE TipoOperacion (
    IdTipoOperacion INT IDENTITY(1,1) PRIMARY KEY,
    Descripcion NVARCHAR(100) NOT NULL
);

DROP TABLE Usuarios

CREATE TABLE Usuario (
    IdUsuario INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(255),
    Apellido VARCHAR(255),
    Email VARCHAR(255) UNIQUE NOT NULL,
    Contrasena VARCHAR(255) NOT NULL,
    Telefono VARCHAR(20),
    Direccion VARCHAR(255),
    Localidad VARCHAR(255),
    IdProvincia INT,
    IdRol INT NOT NULL,
    FOREIGN KEY (IdProvincia) REFERENCES Provincia(IdProvincia),
    FOREIGN KEY (IdRol) REFERENCES Rol(IdRol)
);

DROP TABLE Usuario;



CREATE TABLE Propiedad (
    IdPropiedad INT PRIMARY KEY IDENTITY(1,1),
    IdUsuario INT,
    Titulo VARCHAR(200),
    Direccion VARCHAR(100),
    Ubicacion VARCHAR(100),
    Precio VARCHAR(50),
	Moneda VARCHAR(50),
    Descripcion VARCHAR(MAX),
    Tipo VARCHAR(50),
    TipoOperacion VARCHAR(50),
    ImagenUrl VARCHAR(500),
    Localidad VARCHAR(50),
    TipoDueno VARCHAR(50),
    Email VARCHAR(100),
    WhatsApp VARCHAR(20),
    Visitas INT DEFAULT 0,
    Visible BIT DEFAULT 1,
    Eliminada BIT DEFAULT 0,
    FechaPublicacion DATETIME2 DEFAULT GETDATE(),
    FechaModificacion DATETIME2 DEFAULT GETDATE(),
    Ambientes INT,
    Sup_m2_Total DECIMAL(10,2),
    Sup_m2_Cubierto DECIMAL(10,2),
    Dormitorios INT,
    Baños INT,
    ConPatio BIT DEFAULT 0,
    ConBalcon BIT DEFAULT 0,
    AnosAntiguedad INT,
    AptoCredito BIT DEFAULT 0,
    Reservada BIT DEFAULT 0,
    IdProvincia INT,
    
    FOREIGN KEY (IdUsuario) REFERENCES Usuario(IdUsuario),
    FOREIGN KEY (IdProvincia) REFERENCES Provincia(IdProvincia)
);

CREATE TABLE Imagen (
    IdImagen INT PRIMARY KEY,
    IdPropiedad INT,
    UrlImagen NVARCHAR(255),
    FOREIGN KEY (IdImagen) REFERENCES Propiedad(IdPropiedad)
    );

CREATE TABLE Favorito (
	IdFavorito INT PRIMARY KEY IDENTITY(1,1),
	IdPropiedad INT,
	IdUsuario INT
	);