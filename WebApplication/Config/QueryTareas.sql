
SELECT TareasGenericas.Codigo, TareasGenericas.Descripcion, TareasGenericas.HEstimadas, EstudiantesTareas.HReales, TareasGenericas.TipoTarea
FROM TareasGenericas
LEFT JOIN EstudiantesTareas
ON TareasGenericas.Codigo = EstudiantesTareas.CodTarea
WHERE TareasGenericas.CodAsig = 'HAS'
AND EstudiantesTareas.Email = 'pepe@ikasle.ehu.es'
AND TareasGenericas.Explotacion = 1

/*
SELECT TareasGenericas.Codigo, TareasGenericas.Descripcion, TareasGenericas.HEstimadas, EstudiantesTareas.HReales, TareasGenericas.TipoTarea
FROM TareasGenericas
LEFT JOIN EstudiantesTareas
ON TareasGenericas.Codigo = EstudiantesTareas.CodTarea
WHERE TareasGenericas.CodAsig = @CodAsig
AND EstudiantesTareas.Email = @email
AND TareasGenericas.Explotacion = 1
*/