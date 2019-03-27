using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataBaseAccess;
using EmailLib;
using WebApplication.Framework;
using WebApplication.Utils;

namespace WebApplication {

	public partial class Registro : Page {

		private Lazy<EmailService> lazyEmailService;
		private EmailService EmailService => lazyEmailService?.Value;

		private DataAccessService DataAccess => (DataAccessService)Session["DataAccess"];

		protected void Page_Load(object sender, EventArgs e) {

			if((bool)Session["IsLogged"]) {
				Response.Redirect("/Default");
			}

			Master.SetActiveNav(Account.ActiveNav.CreateAccount);

			SmtpServerConfig smtpServerConfig = new SmtpServerConfig() {
				Account = AppConfig.SmtpServer.Account,
				Password = AppConfig.SmtpServer.Password,
				Host = AppConfig.SmtpServer.Host,
				Port = AppConfig.SmtpServer.Port,
				DeliveryMethod = AppConfig.SmtpServer.DeliveryMethod,
				UseDefaultCredentials = AppConfig.SmtpServer.UseDefaultCredentials,
				EnableSsl = AppConfig.SmtpServer.EnableSsl
			};

			lazyEmailService = new Lazy<EmailService>(() => new EmailService(smtpServerConfig));

		}

		// TODO: Check MailDefinition. https://stackoverflow.com/a/886750/4134376
		protected void ButtonCreateAccount_Click(object sender, EventArgs e) {

			Random generator = new Random();
			int code = (int)(generator.Next(0, 999999) + 1000000);

			ParametizedUrl parametizedUrl = new ParametizedUrl($"{UrlUtils.UrlRoot}{Page.ResolveUrl(@"~/Confirmar")}") {
				{ "email", textBoxEmail.Text },
				{ "code", code.ToString() }
			};

			string displayName = "HADS";
			string address = "noreply@ftudela001.ikasle.ehu.eus";
			string subject = "Confirm Account";

			string emailTemplate = File.ReadAllText(HttpContext.Current.Server.MapPath("~/MailTemplates/AccountVerification.html"));

			/*
			Email Fields:
			0 LogoImgUrl
			1 Name
			2 LastName
			3 VerificationUrl
			4 HelpWebsiteUrl
			5 WebsiteUrl
			6 FooterLogoImgUrl
			*/

			string[] emailFields = {
				"",
				textBoxName.Text,
				textBoxLastName.Text,
				parametizedUrl,
				"",
				UrlUtils.UrlRoot,
				""
			};

			string emailHtml = String.Format(emailTemplate, emailFields);

			MailMessage mail = new MailMessage();
			mail.From = new MailAddress(address, displayName);
			mail.To.Add(new MailAddress(textBoxEmail.Text));
			mail.Subject = subject;
			mail.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(emailHtml, null, MediaTypeNames.Text.Html));
			mail.IsBodyHtml = true;

			try {

				string sql = "INSERT INTO Usuarios(email, nombre, apellidos, numconfir, tipo, pass) VALUES(@email, @nombre, @apellidos, @numconfir, @tipo, @pass)";

				Dictionary<string, object> parameters = new Dictionary<string, object> {
					{ "@email", textBoxEmail.Text },
					{ "@nombre", textBoxName.Text },
					{ "@apellidos", textBoxLastName.Text },
					{ "@numconfir", code },
					{ "@tipo", dropDownRol.SelectedValue },
					{ "@pass", textBoxPassword.Text }
				};

				int affectedRows = DataAccess.NonQuery(sql, parameters);

				if(affectedRows == 1) {
					this.EmailService.SendEmail(mail);
					Session["NotificationData"] = new NotificationData() {
						Title = "Confirm Email",
						Body = $"Confirmation email sent to <span class=\"font-weight-bold font-italic\">{textBoxEmail.Text}</span>. Please verify your account email.",
						Level = AlertLevel.Info
					};
					//Session["NotificationData"] as NotificationData).Body += $"<br><br><strong><small><a href=\"{parametizedUrl}\">Ir a Pagina de Confirmacion de forma Directa</a></small></strong>";
					Response.Redirect("~/WebAlertNotification");
				} else {
					throw new Exception($"Unexpected number of rows affected.\nExpected: 1\nObtained: {affectedRows}");
				}

			} catch(Exception ex) {
				Debug.WriteLine("Exception caught: " + ex.Message);
			}

		}

	}

}
