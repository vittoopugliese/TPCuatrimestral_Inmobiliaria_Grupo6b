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


SELECT * FROM Usuario;


--INQUILINO
INSERT INTO Usuario (Email,Nombre,Contrasena,IdRol) VALUES ('inquilino@testing.com','Nahuel','1234',1);

--INMOBILIARIA
INSERT INTO Usuario (Email,Nombre,Contrasena,IdRol) VALUES ('inmobiliaria@testing.com','Vito','1234',2);

--DUEÑO DIRECTO
INSERT INTO Usuario (Email,Nombre,Contrasena,IdRol) VALUES ('dueno@testing.com','Alex','1234',3);

-- UPDATE Usuario SET IdRol =1 WHERE Email = 'test@testing.com';
-- DELETE FROM Usuario WHERE Email = 'dueno@testing.com';