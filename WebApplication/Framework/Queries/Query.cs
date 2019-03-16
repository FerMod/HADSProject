using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Configuration;

namespace WebApplication.Framework {

	public static class Query {

		/// <summary>
		/// Obtain the query string that is used to query all the subjects tasks that the student is enrolled in.
		/// <para>
		/// Required query parameters:
		/// <list type="table">
		///   <listheader>
		///     <term>Parameter</term>
		///     <description>Description</description>
		///   </listheader>
		///   <item>
		///     <term><c>@email</c></term>
		///     <description>The student email</description>
		///   </item>
		/// </list>
		/// </para>
		/// </summary>
		public static string StudentSubjectsTasks =>
			"SELECT TG.Codigo, TG.Descripcion, TG.HEstimadas, TG.TipoTarea, TG.CodAsig " +
			"FROM TareasGenericas TG " +
			"JOIN GruposClase GC " +
			"ON GC.codigoasig = TG.CodAsig " +
			"JOIN EstudiantesGrupo EG " +
			"ON EG.Grupo = GC.codigo " +
			"WHERE TG.Explotacion = 1 " +
			"AND EG.Email = @email " +
			"AND NOT EXISTS ( " +
			"  SELECT Email " +
			"  FROM EstudiantesTareas " +
			"  WHERE CodTarea = TG.Codigo " +
			"  AND Email = EG.Email" +
			")";

		/// <summary>
		/// Obtain the student subjects query string.
		/// <para>
		/// Required query parameters:
		/// <list type="table">
		///   <listheader>
		///     <term>Parameter</term>
		///     <description>Description</description>
		///   </listheader>
		///   <item>
		///     <term><c>@email</c></term>
		///     <description>The student email</description>
		///   </item>
		/// </list>
		/// </para>
		/// </summary>
		public static string StudentSubjects =>
			"SELECT DISTINCT(GC.codigoasig) " +
			"FROM GruposClase GC " +
			"JOIN  EstudiantesGrupo EG " +
			"ON EG.Grupo = GC.codigo " +
			"WHERE EG.Email = @email";

		/// <summary>
		/// Obtain the teacher subjects query string.
		/// <para>
		/// Required query parameters:
		/// <list type="table">
		///   <listheader>
		///     <term>Parameter</term>
		///     <description>Description</description>
		///   </listheader>
		///   <item>
		///     <term><c>@email</c></term>
		///     <description>The teacher email</description>
		///   </item>
		/// </list>
		/// </para>
		/// </summary>
		public static string TeacherSubjects =>
			"SELECT DISTINCT(GC.codigoasig) " +
			"FROM GruposClase GC " +
			"JOIN  ProfesoresGrupo PG " +
			"ON PG.codigogrupo = GC.codigo " +
			"WHERE PG.email = @email";

	}

}
