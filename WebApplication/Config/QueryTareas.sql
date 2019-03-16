--SET STATISTICS TIME ON;

/*

-- No filtra las asignaturas sin matricular

SELECT TG.Codigo, TG.Descripcion, TG.HEstimadas, TG.TipoTarea, TG.CodAsig
FROM TareasGenericas TG 
WHERE TG.Explotacion = 1
AND NOT EXISTS (
	SELECT Email 
	FROM EstudiantesTareas 
	WHERE CodTarea = TG.Codigo 
	AND Email = @email
)
*/

SELECT TG.Codigo, TG.Descripcion, TG.HEstimadas, TG.TipoTarea, TG.CodAsig
FROM TareasGenericas TG 
JOIN GruposClase GC 
ON GC.codigoasig = TG.CodAsig 
JOIN EstudiantesGrupo EG 
ON EG.Grupo = GC.codigo
WHERE TG.Explotacion = 1
AND EG.Email = 'pepe@ikasle.ehu.es'
AND NOT EXISTS (
	SELECT Email 
	FROM EstudiantesTareas 
	WHERE CodTarea = TG.Codigo 
	AND Email = EG.Email
)

/*
SELECT TG.Codigo, TG.Descripcion, TG.HEstimadas, TG.TipoTarea, TG.CodAsig 
FROM TareasGenericas TG 
JOIN GruposClase GC 
ON GC.codigoasig = TG.CodAsig 
JOIN EstudiantesGrupo EG 
ON EG.Grupo = GC.codigo
WHERE TG.Explotacion = 1
AND EG.Email = @email
AND NOT EXISTS (
	SELECT Email 
	FROM EstudiantesTareas 
	WHERE CodTarea = TG.Codigo 
	AND Email = EG.Email
)
*/

SELECT DISTINCT(TG.Codigo), TG.Descripcion, TG.HEstimadas, TG.Explotacion, TG.TipoTarea, TG.CodAsig
FROM TareasGenericas TG
JOIN GruposClase GC 
ON GC.codigoasig = TG.CodAsig 
JOIN  ProfesoresGrupo PG
ON PG.codigogrupo = GC.codigo
WHERE PG.email = 'blanco@ehu.es'

/*
SELECT DISTINCT(TG.Codigo), TG.Descripcion, TG.HEstimadas, TG.Explotacion, TG.TipoTarea, TG.CodAsig
FROM TareasGenericas TG
JOIN GruposClase GC 
ON GC.codigoasig = TG.CodAsig 
JOIN  ProfesoresGrupo PG
ON PG.codigogrupo = GC.codigo
WHERE PG.email = @email
*/
