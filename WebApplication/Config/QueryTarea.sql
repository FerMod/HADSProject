
SELECT Email, CodTarea, HEstimadas, HReales 
FROM EstudiantesTareas 
WHERE EstudiantesTareas.Email = 'pepe@ikasle.ehu.es'
AND CodTarea = 'HAS13-Lab4'

/*
SELECT Email, CodTarea, HEstimadas, HReales 
FROM EstudiantesTareas 
WHERE EstudiantesTareas.Email = @Email 
AND CodTarea = @CodTarea
*/
