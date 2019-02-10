using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;

namespace WebApplication {

	public class Global : HttpApplication {

		void Application_Start(object sender, EventArgs e) {

			// Code that runs on application startup
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);

			ScriptManager.ScriptResourceMapping.AddDefinition("jquery", new ScriptResourceDefinition {
				Path = "~/Scripts/jquery-3.3.1.min.js",
				DebugPath = "~/Scripts/jquery-3.3.1.min.js",
				CdnPath = "https://ajax.aspnetcdn.com/ajax/jQuery/jquery-3.3.1.min.js",
				CdnDebugPath = "https://ajax.aspnetcdn.com/ajax/jQuery/jquery-3.3.1.js"
			});

			ScriptManager.ScriptResourceMapping.AddDefinition("bootstrap", new ScriptResourceDefinition {
				Path = "~/Scripts/bootstrap.min.js",
				DebugPath = "~/Scripts/bootstrap.min.js",
				CdnPath = "https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/js/bootstrap.min.js",
				CdnDebugPath = "https://maxcdn.bootstrapcdn.com/bootstrap/3.4.0/js/bootstrap.min.js"
			});


		}

	}

}
