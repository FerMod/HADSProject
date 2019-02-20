using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
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

	public partial class Registro : System.Web.UI.Page {

		private Lazy<EmailService> lazyEmailService;
		private EmailService EmailService => lazyEmailService?.Value;

		protected void Page_Load(object sender, EventArgs e) {

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

		protected void ButtonCreateAccount_Click(object sender, EventArgs e) {

			Random generator = new Random();
			int code = (int)(generator.Next(0, 999999) + 1000000);

			ParametizedUrl parametizedUrl = new ParametizedUrl($"{UrlUtils.UrlRoot}{Page.ResolveUrl(@"~/Confirmar")}") {
				{ "email", textBoxEmail.Text },
				{ "code", code.ToString() }
			};

			string confirmationUrl = $"{parametizedUrl}";

			string displayName = "HADS";
			string subject = "Confirm Account";

			string text = $"Hi {textBoxName.Text} {textBoxLastName.Text}!\n\n";
			text += $"Please click on this link to '{subject}': {confirmationUrl}\n\n";
			text += "Thanks,\n";
			text += "HADS Team.";

			string html = $"Hi {textBoxName.Text} {textBoxLastName.Text}!<br/><br/>";
			html += $"Please confirm your account by clicking this link: <a href=\"{confirmationUrl}\">Confirm Account</a><br/>";
			html += $"Or click on the copy the following link on the browser: {HttpUtility.HtmlEncode(confirmationUrl)}<br/><br/>";
			html += "Thanks,";
			html += "HADS Team.";

			MailMessage mail = new MailMessage();
			mail.From = new MailAddress("noreply@ftudela001.ikasle.ehu.eus", displayName);
			mail.To.Add(new MailAddress(textBoxEmail.Text));
			mail.Subject = subject;
			mail.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(text, null, MediaTypeNames.Text.Plain));
			mail.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(html, null, MediaTypeNames.Text.Html));
			mail.IsBodyHtml = true;

			try {

				string sql = "insert into Usuarios(email, nombre, apellidos, numconfir, tipo, pass) values(@email, @nombre, @apellidos, @numconfir, @tipo, @pass)";

				Dictionary<string, object> parameters = new Dictionary<string, object> {
					{ "@email", textBoxEmail.Text },
					{ "@nombre", textBoxName.Text },
					{ "@apellidos", textBoxLastName.Text },
					{ "@numconfir", code },
					{ "@tipo", dropDownRol.SelectedValue },
					{ "@pass", textBoxPassword.Text }
				};

				int affectedRows = ((Account)Master).DataAccess.Insert(sql, parameters);

				if(affectedRows != 1) {
					this.EmailService.SendEmail(mail);
				} else {
					throw new Exception($"Unexpected number of rows affected.\nExpected: 1\nObtained: {affectedRows}");
				}

			} catch(Exception ex) {
				Debug.WriteLine("Exception caught: " + ex.Message);
			}

		}

	}

}
