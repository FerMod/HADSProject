using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Configuration;

namespace WebApplication {

	public static class AppConfig {

		public static class SmtpServer {

			/// <summary>
			/// 
			/// </summary>
			public static string Account { get; set; }

			/// <summary>
			/// 
			/// </summary>
			public static string Password { get; set; }

			/// <summary>
			/// 
			/// </summary>
			public static string Host { get; set; }

			/// <summary>
			/// 
			/// </summary>
			public static int Port { get; set; }

			/// <summary>
			/// 
			/// </summary>
			public static SmtpDeliveryMethod DeliveryMethod { get; set; }

			/// <summary>
			/// 
			/// </summary>
			public static bool UseDefaultCredentials { get; set; }

			/// <summary>
			/// 
			/// </summary>
			public static bool EnableSsl { get; set; }

			static SmtpServer() {

				Account = WebConfigurationManager.AppSettings["Account"];
				Password = WebConfigurationManager.AppSettings["Password"];
				Host = WebConfigurationManager.AppSettings["Host"];
				Port = Int32.Parse(WebConfigurationManager.AppSettings["Port"]);
				DeliveryMethod = (SmtpDeliveryMethod)Enum.ToObject(typeof(SmtpDeliveryMethod), WebConfigurationManager.AppSettings["DeliveryMethod"]);
				UseDefaultCredentials = Convert.ToBoolean(WebConfigurationManager.AppSettings["UseDefaultCredentials"]);
				EnableSsl = Convert.ToBoolean(WebConfigurationManager.AppSettings["EnableSsl"]);

			}

		}

	}

}