
--CREATE PROCEDURE SP_RegistrarUsuario
--    @Email NVARCHAR(50),
--    @Contrasena NVARCHAR(50)
--AS
--BEGIN
--	SET NOCOUNT ON;

--    IF EXISTS (SELECT 1 FROM Usuario WHERE Email = @Email)
--    BEGIN
--        SELECT 0;
--        RETURN;
--    END

--    INSERT INTO Usuario (Email, Contrasena, IdRol) OUTPUT inserted.IdUsuario
--    VALUES (@Email, @Contrasena, 1);
--END;



