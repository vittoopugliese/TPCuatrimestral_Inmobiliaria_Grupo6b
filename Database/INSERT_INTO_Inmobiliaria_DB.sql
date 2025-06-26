USE Inmobiliaria_TPC
GO

INSERT INTO Rol (Descripcion) VALUES 
('Usuario'),
('Admin'),
('Anunciante');


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
('Tucumán'),
('No definido');


-- UPDATE Usuario SET IdRol =1 WHERE Email = 'test@testing.com';
-- DELETE FROM Usuario WHERE Email = 'dueno@testing.com';