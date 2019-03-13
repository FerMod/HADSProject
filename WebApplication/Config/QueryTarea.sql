
SELECT Email, CodTarea, HEstimadas, HReales 
FROM EstudiantesTareas 
WHERE EstudiantesTareas.Email = 'pepe@ikasle.ehu.es'
AND CodTarea = 'HAS13-Lab4'

SELECT TG.Codigo, TG.Descripcion, TG.HEstimadas, TG.TipoTarea 
FROM TareasGenericas TG 
JOIN GruposClase GC 
ON GC.codigoasig = TG.CodAsig 
JOIN EstudiantesGrupo EG 
ON EG.Grupo = GC.codigo
WHERE TG.Explotacion = 1
AND EG.Email = 'pepe@ikasle.ehu.es'
AND TG.Codigo = 'HADS-Task01' 

/*
SELECT Email, CodTarea, HEstimadas, HReales 
FROM EstudiantesTareas 
WHERE EstudiantesTareas.Email = @Email 
AND CodTarea = @CodTarea
*/
