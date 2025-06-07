USE Inmobiliaria_TPC
GO

INSERT INTO Rol (Descripcion) VALUES 
('Inquilino'),
('Inmobiliaria'),
('Dueño Directo');


INSERT INTO Provincia (Nombre) VALUES
('Buenos Aires'),
('Catamarca'),
('Chaco'),
('Chubut'),
('Córdoba'),
('Corrientes'),
('Entre Ríos'),
('Formosa'),
('Jujuy'),
('La Pampa'),
('La Rioja'),
('Mendoza'),
('Misiones'),
('Neuquén'),
('Río Negro'),
('Salta'),
('San Juan'),
('San Luis'),
('Santa Cruz'),
('Santa Fe'),
('Santiago del Estero'),
('Tierra del Fuego'),
('Tucumán');

select * from Imagenes;

INSERT INTO Usuario (Email,Nombre,Contrasena) VALUES ('test@testing.com','Nahuel','1234');

UPDATE Usuario SET IdRol =1 WHERE Email = 'test@testing.com';

SELECT * FROM Usuario;