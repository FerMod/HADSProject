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
using EmailLib;
using WebApplication.Utils;

namespace WebApplication {

	public partial class Registro : System.Web.UI.Page {

		private Lazy<EmailService> lazyEmailService;
		private EmailService EmailService => lazyEmailService.Value;

		protected void Page_Load(object sender, EventArgs e) {

			if(!IsPostBack) {

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

		}

		protected void ButtonCreateAccount_Click(object sender, EventArgs e) {

			string confirmationUrl = $"{UrlUtils.UrlRoot}{Page.ResolveUrl(@"~/Confirmar")}";

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

			this.EmailService.SendEmail(mail);

		}

	}

}