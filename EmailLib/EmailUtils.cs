using System;
using System.Net.Mail;

namespace EmailLib {

	public class Email {

		public string From { get; set; }
		public string To { get; set; }

		public int Port { get; set; } = 25;
		public SmtpDeliveryMethod DeliveryMethod { get; set; } = SmtpDeliveryMethod.Network;
		public bool UseDefaultCredentials { get; set; } = false;
		public string Host { get; set; } = "smtp.ehu.eus";

		public Email(string from, string to) {
			From = from;
			To = to;
		}

		public void SendEmail(string subject, string body) {

			MailMessage email = new MailMessage(this.From, this.To, subject, body);

			SmtpClient client = new SmtpClient {
				Port = this.Port,
				DeliveryMethod = this.DeliveryMethod,
				UseDefaultCredentials = this.UseDefaultCredentials,
				Host = this.Host
			};

			client.Send(email);

		}

	}

}
