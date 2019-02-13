using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Security;
using Newtonsoft.Json;

namespace EmailLib {

	public class Email {

		public string From { get; set; }
		public string To { get; set; }

		private SmtpServerConfig SmtpConfig { get; set; }

		public Email(string from, string to, SmtpServerConfig emailServerConfig) {
			From = from;
			To = to;
			SmtpConfig = emailServerConfig;
		}

		public void SendEmail(string subject, string body) {

			MailMessage email = new MailMessage(this.From, this.To, subject, body);

			SmtpClient client = new SmtpClient {
				Credentials = new NetworkCredential(SmtpConfig.UserName, SmtpConfig.Password),
				Port = SmtpConfig.Port,
				DeliveryMethod = SmtpConfig.DeliveryMethod,
				Host = SmtpConfig.Host
			};

			client.Send(email);

		}

	}

}
