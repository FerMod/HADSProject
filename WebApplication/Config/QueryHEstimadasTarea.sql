
--SELECT Email, CodTarea, HEstimadas, HReales 
--FROM EstudiantesTareas 
--WHERE EstudiantesTareas.Email = 'pepe@ikasle.ehu.es'
--AND CodTarea = 'HAS13-Lab4'

SELECT Codigo, HEstimadas
FROM TareasGenericas TG 
WHERE TG.Explotacion = 1
AND TG.Codigo = 'HADS-Task01' 

/*
SELECT Codigo, HEstimadas
FROM TareasGenericas TG 
WHERE TG.Explotacion = 1
AND TG.Codigo = @Codigo 
*/
