using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace EmailLib {

	public class SmtpServerConfig {

		public string UserName { get; set; } = "";
		public string Password { get; set; } = "";
		public string Host { get; set; } = "";
		public SmtpDeliveryMethod DeliveryMethod = SmtpDeliveryMethod.Network;
		public int Port { get; set; } = 25;

	}

}
