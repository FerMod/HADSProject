using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;
using EmailLib;

namespace WebApplication {

	public class Global : HttpApplication {

		private string SmtpConfigPath => @"~/Config/SmtpServerConfig.json";

		void Application_Start(object sender, EventArgs e) {

			// Code that runs on application startup
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);


			SmtpServerConfig SmtpConfig = ConfigFile.ReadJsonConfig<SmtpServerConfig>(SmtpConfigPath);

			if(SmtpConfig is null) {

				SmtpConfig = new SmtpServerConfig {
					Host = "smtp.ehu.eus",
					Port = 25
				};

				// TODO: Get relative path
				ConfigFile.WriteJsonConfig(SmtpConfigPath, SmtpConfig);

			}

			Application.Add("SmtpConfig", SmtpConfig);
		}

	}

}
