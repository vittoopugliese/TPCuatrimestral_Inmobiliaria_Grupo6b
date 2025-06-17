
CREATE PROCEDURE SP_RegistrarUsuario
    @Email NVARCHAR(50),
    @Contrasena NVARCHAR(50)
AS
BEGIN
    INSERT INTO Usuario (Email, Contrasena, IdRol) OUTPUT inserted.IdUsuario
    VALUES (@Email, @Contrasena, 1);
END;



