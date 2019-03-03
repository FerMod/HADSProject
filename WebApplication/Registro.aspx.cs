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

		private DataAccessService DataAccess => ((Account)Master).DataAccess;

		protected void Page_Load(object sender, EventArgs e) {

			if((bool)Session["IsLoggedIn"]) {
				Response.Redirect("/Default");
			}

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
			string subject = "Confirm Account";

			string text = $"Hi {textBoxName.Text} {textBoxLastName.Text}!\n\n";
			text += $"Please click on this link to '{subject}': {parametizedUrl}\n\n";
			text += "Thanks,\n";
			text += "HADS Team.";

			string html = $"Hi {textBoxName.Text} {textBoxLastName.Text}!<br /><br />";
			html += $"Please confirm your account by clicking this link: <a href=\"{parametizedUrl}\">Confirm Account</a><br />";
			html += $"Or click on the copy the following link on the browser: {HttpUtility.HtmlEncode(parametizedUrl)}<br /><br />";
			html += "Thanks,<br />";
			html += "HADS Team.";


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
			mail.From = new MailAddress("noreply@ftudela001.ikasle.ehu.eus", displayName);
			mail.To.Add(new MailAddress(textBoxEmail.Text));
			mail.Subject = subject;
			mail.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(text, null, MediaTypeNames.Text.Plain));
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

				int affectedRows = DataAccess.Insert(sql, parameters);

				if(affectedRows == 1) {
					this.EmailService.SendEmail(mail);
					Session["NotificationData"] = new NotificationData() {
						Title = "Confirm Email",
						Body = $"Confirmation email sent to <span class=\"font-weight-bold font-italic\">{textBoxEmail.Text}</span>. If yount don't receive any email use the following link to <a href=\"{parametizedUrl}\">resend email</a>.",
						Level = AlertLevel.Info
					};
					Response.Redirect("/WebNotification");
				} else {
					throw new Exception($"Unexpected number of rows affected.\nExpected: 1\nObtained: {affectedRows}");
				}

			} catch(Exception ex) {
				Debug.WriteLine("Exception caught: " + ex.Message);
			}

		}

	}

}
