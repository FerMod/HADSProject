using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;
using EmailLib;
using WebApplication.Utils;
using System.Web.Configuration;

namespace WebApplication {

	public class Global : HttpApplication {

		private readonly string smtpConfigPath = @"~/Config/secrets/SmtpServerConfig.json";

		void Application_Start(object sender, EventArgs e) {

			// Code that runs on application startup
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);

			string filePath = Server.MapPath(smtpConfigPath);
			SmtpServerConfig SmtpConfig = JsonFile.Read<SmtpServerConfig>(filePath);

			if(SmtpConfig is null) {

				SmtpConfig = new SmtpServerConfig();

				JsonFile.Write(filePath, SmtpConfig);

			}
			SmtpConfig.Account = WebConfigurationManager.AppSettings["Account"];
			Application.Add("SmtpConfig", SmtpConfig);
		}

	}

}
