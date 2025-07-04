CREATE TRIGGER TR_RevisionPublicaciones
ON Propiedad
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO RevisionPublicaciones (
        IdPropiedad,
        IdUsuario,
        FechaAccion,
        TipoAccion,
        EstadoRevision,
        ObservacionesAdmin
    )
    SELECT
        i.IdPropiedad,
        i.IdUsuario,
        GETDATE(),
        'INSERT',
        'Pendiente',
        NULL
    FROM inserted i;
END;