using System;
using System.Net.Mail;

namespace EmailLib {

	public static class EmailUtils {

		public static void SendEmail(string email, string subject, string body) {

			MailMessage mail = new MailMessage("you@yourcompany.com", email) {
				Subject = subject,
				Body = body
			};

			SmtpClient client = new SmtpClient {
				Port = 25,
				DeliveryMethod = SmtpDeliveryMethod.Network,
				UseDefaultCredentials = false,
				Host = "smtp.ehu.eus"
			};

			client.Send(mail);

		}

	}

}
