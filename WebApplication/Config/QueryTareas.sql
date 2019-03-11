
--select TG1.Codigo, TG1.Descripcion, TG1.HEstimadas, TG1.TipoTarea, GC.codigoasig
--from(EstudiantesGrupo as EG inner join GruposClase as GC on EG.Grupo = GC.codigo) 
--inner join TareasGenericas as TG1 on GC.codigoasig = TG1.CodAsig 
--where EG.Email = 'pepe@ikasle.ehu.es' and TG1.Explotacion = 1 and not exists(SELECT * FROM EstudiantesTareas WHERE CodTarea = TG1.Codigo and Email = EG.Email)

SELECT TG.Codigo, TG.Descripcion, TG.HEstimadas, ET.HReales, TG.TipoTarea
FROM EstudiantesTareas ET
LEFT JOIN TareasGenericas TG
ON ET.CodTarea = TG.Codigo 
WHERE ET.Email = 'pepe@ikasle.ehu.es'
AND TG.Explotacion = 1
AND TG.CodAsig IS NULL

--SELECT TareasGenericas.Codigo, TareasGenericas.Descripcion, TareasGenericas.HEstimadas, EstudiantesTareas.HReales, TareasGenericas.TipoTarea
--FROM TareasGenericas
--LEFT JOIN EstudiantesTareas
--ON TareasGenericas.Codigo = EstudiantesTareas.CodTarea
--WHERE EstudiantesTareas.Email = 'pepe@ikasle.ehu.es'
--AND TareasGenericas.Explotacion = 1

/*
SELECT TareasGenericas.Codigo, TareasGenericas.Descripcion, TareasGenericas.HEstimadas, EstudiantesTareas.HReales, TareasGenericas.TipoTarea
FROM TareasGenericas
LEFT JOIN EstudiantesTareas
ON TareasGenericas.Codigo = EstudiantesTareas.CodTarea
WHERE TareasGenericas.CodAsig = @CodAsig
AND EstudiantesTareas.Email = @email
AND TareasGenericas.Explotacion = 1
*/