
SELECT DISTINCT(GC.codigoasig)
FROM GruposClase GC 
JOIN  EstudiantesGrupo EG
ON EG.Grupo = GC.codigo
WHERE EG.Email = 'pepe@ikasle.ehu.es'

/*
SELECT DISTINCT(GC.codigoasig)
FROM GruposClase GC 
JOIN  EstudiantesGrupo EG
ON EG.Grupo = GC.codigo
WHERE EG.Email = @email
*/


SELECT DISTINCT(GC.codigoasig)
FROM GruposClase GC 
JOIN  ProfesoresGrupo PG
ON PG.codigogrupo = GC.codigo
WHERE PG.email = 'blanco@ehu.es'

/*
SELECT DISTINCT(GC.codigoasig)
FROM GruposClase GC 
JOIN  ProfesoresGrupo PG
ON PG.codigogrupo = GC.codigo
WHERE PG.email = @email
*/
