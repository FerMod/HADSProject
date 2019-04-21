
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using DataBaseAccess;

/// <summary>
/// Summary description for SubjectsMeansService
/// </summary>
[WebService(Namespace = "http://localhost:50253/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX
[ScriptService]
public class SubjectsMeansService : WebService {

	private readonly DataAccessService dataAccess;

	public SubjectsMeansService() {

		dataAccess = new DataAccessService(ConfigurationManager.ConnectionStrings["HADS18-DB"].ConnectionString);

	}

	[WebMethod]
	public DataTable GetAllSubjectsMeans() {

		string query = "SELECT ET.Email, AVG(ET.HReales) as MediaHReales, TG.CodAsig " +
						"FROM EstudiantesTareas ET " +
						"JOIN TareasGenericas TG " +
						"ON ET.CodTarea = TG.Codigo " +
						"GROUP BY ET.Email, TG.CodAsig";


		DataTable dataTable = dataAccess.CreateQueryDataTable(query);
		dataTable.TableName = "SubjectsMeans";

		return dataTable;
	}


	[WebMethod]
	public DataTable GetSubjectMeans(string subjectCode) {

		string query = "SELECT ET.Email, AVG(ET.HReales) as MediaHReales, TG.CodAsig " +
						"FROM EstudiantesTareas ET " +
						"JOIN TareasGenericas TG " +
						"ON ET.CodTarea = TG.Codigo " +
						"WHERE ET.CodTarea = @codigo " +
						"GROUP BY ET.Email, TG.CodAsig";

		Dictionary<string, object> parameters = new Dictionary<string, object> {
			{ "@codigo", subjectCode }
		};


		DataTable dataTable = dataAccess.CreateQueryDataTable(query, parameters);
		dataTable.TableName = "SubjectsMeans";

		return dataTable;
	}

}
