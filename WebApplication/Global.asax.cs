
using System;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using DataBaseAccess;
using WebApplication.ComprobarMatriculaService;
using WebApplication.Framework;

namespace WebApplication {

	public class Global : HttpApplication {

		// Global.asax handlers and events: http://sandblogaspnet.blogspot.com/2008/03/methods-in-globalasax.html

		#region ASP.NET Handlers

		#region Application Handlers

		protected void Application_Start(object sender, EventArgs e) {

			ScriptResource.RegisterJQuery(AppConfig.WebSite.JQueryVersion);
			ScriptResource.RegisterBoostrap(AppConfig.WebSite.BoostrapVersion);

			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);

			SetupDataAccess();
			InitLoggedUsersTrack();
			InitEnrolledUsersService();

		}

		protected void Application_BeginRequest(object sender, EventArgs e) { }

		protected void Application_AuthenticateRequest(object sender, EventArgs e) { }

		protected void Application_EndRequest(object sender, EventArgs e) { }

		protected void Application_End(object sender, EventArgs e) { }

		protected void Application_Error(object sender, EventArgs e) { }

		#endregion

		#region Session Handlers

		protected void Session_Start(object sender, EventArgs e) {

			Lazy<DataAccessService> dataAccessService = new Lazy<DataAccessService>(() => (DataAccessService)Application.Get("DataAccess"));
			Session["DataAccess"] = dataAccessService.Value;

			Lazy<DataSet> dataSet = new Lazy<DataSet>(() => new DataSet());
			Session["UserDataSet"] = dataSet.Value;

			Session["IsLogged"] = false;
			Session["Email"] = "";
			Session["Name"] = "";
			Session["LastName"] = "";
			Session["UserType"] = "";

		}

		protected void Session_End(object sender, EventArgs e) {

			string email = Convert.ToString(Session["Email"]);
			string userType = Convert.ToString(Session["UserType"]);
			((ConnectedUsersTrack)Application.Get("LoggedUsers")).Remove(userType, email);

		}

		#endregion

		#endregion

		protected void SetupDataAccess() {

			DataAccessService dataAccess = new DataAccessService(ConfigurationManager.ConnectionStrings["HADS18-DB"].ConnectionString);
			Application.Lock();
			Application.Set("DataAccess", dataAccess);
			Application.UnLock();

		}

		protected void InitLoggedUsersTrack() {

			Application.Lock();
			if(Application.Get("LoggedUsers") == null) {
				Application.Set("LoggedUsers", new ConnectedUsersTrack());
			}
			Application.UnLock();

		}

		protected void InitEnrolledUsersService() {

			Application.Lock();
			if(Application.Get("Matriculas") == null) {
				Application.Set("Matriculas", new Matriculas());
			}
			Application.UnLock();

		}

	}

}
