using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace EmailLib {

	public class SmtpServerConfig {

		public string Account { get; set; } = "";
		public string Password { get; set; } = "";
		public string Host { get; set; } = "";
		public int Port { get; set; } = 587;
		public SmtpDeliveryMethod DeliveryMethod { get; set; } = SmtpDeliveryMethod.Network;
		public bool UseDefaultCredentials { get; set; } = false;
		public bool EnableSsl { get; set; } = true;

	}

}
