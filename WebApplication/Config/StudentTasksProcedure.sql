CREATE PROCEDURE StudentTasks
	@email NVARCHAR(50)
AS
	SELECT DISTINCT(GC.codigoasig)
	FROM GruposClase GC
	JOIN  EstudiantesGrupo EG
	ON EG.Grupo = GC.codigo
	WHERE EG.Email = @email;

RETURN
