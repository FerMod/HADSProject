using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Configuration;

namespace WebApplication {

	// https://www.dotnetperls.com/appsettings

	public static class AppConfig {

		public static class WebSite {

			/// <summary>
			/// The version of JQuery currently in use.
			/// </summary>
			public static string JQueryVersion { get; internal set; }

			/// <summary>
			/// The version of Boostrap currently in use.
			/// </summary>
			public static string BoostrapVersion { get; internal set; }

			/// <summary>
			/// The website main page.
			/// </summary>
			public static string MainPage { get; internal set; }

			static WebSite() {

				JQueryVersion = WebConfigurationManager.AppSettings["jquery"];
				BoostrapVersion = WebConfigurationManager.AppSettings["boostrap"];
				MainPage = WebConfigurationManager.AppSettings["MainPage"];

			}

		}

		public static class SmtpServer {

			/// <summary>
			/// 
			/// </summary>
			public static string Account { get; internal set; }

			/// <summary>
			/// 
			/// </summary>
			public static string Password { get; internal set; }

			/// <summary>
			/// 
			/// </summary>
			public static string Host { get; internal set; }

			/// <summary>
			/// 
			/// </summary>
			public static int Port { get; internal set; }

			/// <summary>
			/// 
			/// </summary>
			public static SmtpDeliveryMethod DeliveryMethod { get; internal set; }

			/// <summary>
			/// 
			/// </summary>
			public static bool UseDefaultCredentials { get; internal set; }

			/// <summary>
			/// 
			/// </summary>
			public static bool EnableSsl { get; internal set; }

			static SmtpServer() {

				Account = WebConfigurationManager.AppSettings["Account"];
				Password = WebConfigurationManager.AppSettings["Password"];
				Host = WebConfigurationManager.AppSettings["Host"];
				Port = Int32.Parse(WebConfigurationManager.AppSettings["Port"]);
				DeliveryMethod = (SmtpDeliveryMethod)Int32.Parse(WebConfigurationManager.AppSettings["DeliveryMethod"]);
				UseDefaultCredentials = Convert.ToBoolean(WebConfigurationManager.AppSettings["UseDefaultCredentials"]);
				EnableSsl = Convert.ToBoolean(WebConfigurationManager.AppSettings["EnableSsl"]);

			}

		}

		public static class Xml {

			/// <summary>
			/// The path where the xml files are stored.
			/// </summary>
			public static string Folder { get; internal set; }

			/// <summary>
			/// The subjects XSL file.
			/// </summary>
			public static string SubjectsXsltFile { get; internal set; }

			static Xml() {

				Folder = HttpContext.Current.Server.MapPath(WebConfigurationManager.AppSettings["XmlFolder"]);
				SubjectsXsltFile = WebConfigurationManager.AppSettings["SubjectsXsltFile"];

			}

		}

		public static class Json {

			/// <summary>
			/// The path where the json files are stored.
			/// </summary>
			public static string Folder { get; internal set; }

			static Json() {

				Folder = HttpContext.Current.Server.MapPath(WebConfigurationManager.AppSettings["JsonFolder"]);

			}

		}

	}

}
