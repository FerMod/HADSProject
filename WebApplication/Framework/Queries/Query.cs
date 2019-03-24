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

		/// <summary>
		/// Obtain all the teacher generic tasks query string.
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
		public static string TeacherGenericTasks =>
			"SELECT DISTINCT(TG.Codigo), TG.Descripcion, TG.CodAsig, TG.HEstimadas, TG.Explotacion, TG.TipoTarea " +
			"FROM TareasGenericas TG " +
			"JOIN GruposClase GC " +
			"ON GC.codigoasig = TG.CodAsig " +
			"JOIN  ProfesoresGrupo PG " +
			"ON PG.codigogrupo = GC.codigo " +
			"WHERE PG.email = @email";

		public static class GenericTasks {

			/// <summary>
			/// Obtain the generic tasks select command string.
			/// </summary>
			public static string Select =>
				"SELECT Codigo, Descripcion, CodAsig, HEstimadas, Explotacion, TipoTarea " +
				"FROM TareasGenericas";

			/// <summary>
			/// Obtain the generic tasks insert command string.
			/// <para>
			/// Required query parameters:
			/// <list type="table">
			///   <listheader>
			///     <term>Parameter</term>
			///     <description>Description</description>
			///   </listheader>
			///   <item>
			///     <term><c>@codigo</c></term>
			///     <description>The task key</description>
			///   </item>
			///   <item>
			///     <term><c>@descripcion</c></term>
			///     <description>A brief description of the task</description>
			///   </item>
			///   <item>
			///     <term><c>@codasig</c></term>
			///     <description>The subject key</description>
			///   </item>
			///   <item>
			///     <term><c>@hestimadas</c></term>
			///     <description>The ammount of hours estimation</description>
			///   </item>
			///   <item>
			///     <term><c>@explotacion</c></term>
			///     <description>Value referencing if the task is currently active</description>
			///   </item>
			///   <item>
			///     <term><c>@tipoTarea</c></term>
			///     <description>The type of the task</description>
			///   </item>
			/// </list>
			/// </para>
			/// </summary>
			public static string Insert =>
				"INSERT INTO TareasGenericas (Codigo, Descripcion, CodAsig, HEstimadas, Explotacion, TipoTarea) " +
				"VALUES(@codigo, @descripcion, @codasig, @hestimadas, @explotacion, @tipoTarea)";

			/// <summary>
			/// Obtain the generic tasks update command string.
			/// <para>
			/// Required query parameters:
			/// <list type="table">
			///   <listheader>
			///     <term>Parameter</term>
			///     <description>Description</description>
			///   </listheader>
			///   <item>
			///     <term><c>@codigo</c></term>
			///     <description>The task key</description>
			///   </item>
			///   <item>
			///     <term><c>@descripcion</c></term>
			///     <description>A brief description of the task</description>
			///   </item>
			///   <item>
			///     <term><c>@codasig</c></term>
			///     <description>The subject key</description>
			///   </item>
			///   <item>
			///     <term><c>@hestimadas</c></term>
			///     <description>The ammount of hours estimation</description>
			///   </item>
			///   <item>
			///     <term><c>@explotacion</c></term>
			///     <description>Value referencing if the task is currently active</description>
			///   </item>
			///   <item>
			///     <term><c>@tipoTarea</c></term>
			///     <description>The type of the task</description>
			///   </item>
			/// </list>
			/// </para>
			/// </summary>
			public static string Update =>
				"UPDATE TareasGenericas SET Descripcion = @descripcion, CodAsig = @codasig, HEstimadas = @hestimadas, Explotacion = @explotacion, TipoTarea = @tipotarea " +
				"WHERE Codigo = @codigo";


		}
		

	}

}
