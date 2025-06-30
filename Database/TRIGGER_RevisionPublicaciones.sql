CREATE TRIGGER TR_RevisionPublicaciones
ON Propiedad
AFTER INSERT, UPDATE
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
        CASE 
            WHEN EXISTS (
                SELECT 1 FROM inserted i
                JOIN deleted d ON i.IdPropiedad = d.IdPropiedad
            ) THEN 'UPDATE'
            ELSE 'INSERT'
        END,
        'Pendiente',
        NULL
    FROM inserted i;
END;