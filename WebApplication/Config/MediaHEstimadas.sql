SELECT ET.Email, AVG(ET.HReales) as MediaHReales, TG.CodAsig
FROM EstudiantesTareas ET
JOIN TareasGenericas TG
ON ET.CodTarea = TG.Codigo
GROUP BY ET.Email, TG.CodAsig
