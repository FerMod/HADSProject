using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Security;

namespace EmailLib {

	public class EmailService {

		private Lazy<SmtpClient> lazySmtpServer;
		private SmtpClient SmtpServer => lazySmtpServer.Value;

		public SmtpServerConfig SmtpConfig { get; private set; }

		public EmailService(SmtpServerConfig smtpServerConfig) {

			SmtpConfig = smtpServerConfig;

			lazySmtpServer = new Lazy<SmtpClient>(() => new SmtpClient {
				DeliveryMethod = SmtpConfig.DeliveryMethod,
				Credentials = new NetworkCredential(SmtpConfig.Account, SmtpConfig.Password),
				Host = SmtpConfig.Host,
				Port = Convert.ToInt32(SmtpConfig.Port),
				EnableSsl = SmtpConfig.EnableSsl
			});

		}

		public void SendEmail(MailMessage mailMessage) {
			SmtpServer.Send(mailMessage);
		}

	}

}
