using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;
using DataBaseAccess;
using EmailLib;
using WebApplication.Utils;

namespace WebApplication {

	public class Global : HttpApplication {

		void Application_Start(object sender, EventArgs e) {

			// Code that runs on application startup
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);

			SetupDataAccess();

		}

		void SetupDataAccess() {

			DataAccessService dataAccess = new DataAccessService(ConfigurationManager.ConnectionStrings["HADS18-DB"].ConnectionString);
			Application.Lock();
			Application.Contents.Set("DataAccess", dataAccess);
			Application.UnLock();

		}

	}

}
