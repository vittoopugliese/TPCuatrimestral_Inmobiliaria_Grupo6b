CREATE PROCEDURE SP_ActualizarPerfil
    @IdUsuario INT,
    @Nombre NVARCHAR(50),
    @Apellido NVARCHAR(50),
    @Contrasena NVARCHAR(50),
    @Telefono NVARCHAR(20),
    @Direccion NVARCHAR(100),
    @Localidad NVARCHAR(50),
    @IdProvincia INT,
    @IdRol INT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Usuario
    SET
        Nombre = @Nombre,
        Apellido = @Apellido,
        Contrasena = @Contrasena,
        Telefono = @Telefono,
        Direccion = @Direccion,
        Localidad = @Localidad,
        IdProvincia = @IdProvincia,
        IdRol = @IdRol
    WHERE IdUsuario = @IdUsuario;
END