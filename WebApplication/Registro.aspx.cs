using System;
using System.Collections.Generic;
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
		private DataAccess dataAccess;

		protected void Page_Load(object sender, EventArgs e) {

			if(!IsPostBack) {
				Application.Lock();
				dataAccess = Application["DataAccess"] as DataAccess;
				Application.UnLock();
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
			string text = $"Please click on this link to '{subject}': {confirmationUrl}";
			string html = $"Please confirm your account by clicking this link: <a href=\"{confirmationUrl}\">link</a><br/>";
			html += HttpUtility.HtmlEncode($"Or click on the copy the following link on the browser: {confirmationUrl}");

			MailMessage mail = new MailMessage();
			mail.From = new MailAddress("noreply@ftudela001.ikasle.ehu.eus", displayName);
			mail.To.Add(new MailAddress(textBoxEmail.Text));
			mail.Subject = subject;
			mail.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(text, null, MediaTypeNames.Text.Plain));
			mail.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(html, null, MediaTypeNames.Text.Html));
			mail.IsBodyHtml = true;

			try {

				string sql = "insert into Usuarios(email, nombre, apellidos, numconfir, confirmado, tipo, pass) values(@email, @nombre, @apellidos, @numconfir, 0, @tipo, @pass)";

				sql = sql.Replace("@email", $"'{textBoxEmail.Text}'");
				sql = sql.Replace("@nombre", $"'Nombre?'");
				sql = sql.Replace("@apellidos", $"'Apellidos?'");
				sql = sql.Replace("@numconfir", $"'{code.ToString()}'");
				sql = sql.Replace("@tipo", $"'{dropDownRol.SelectedValue}'");
				sql = sql.Replace("@pass", $"'{textBoxPassword1.Text}'");

				dataAccess.Insert(sql);
				this.EmailService.SendEmail(mail);

			} catch(Exception ex) {
				Debug.WriteLine("Exception caught: " + ex.Message);
			}

		}

	}

}
