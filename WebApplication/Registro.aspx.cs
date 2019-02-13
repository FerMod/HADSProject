using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EmailLib;

namespace WebApplication {

	public partial class Registro : System.Web.UI.Page {

		protected void Page_Load(object sender, EventArgs e) {
			
		}

		protected void ButtonCreateAccount_Click(object sender, EventArgs e) {

			SmtpServerConfig smtpConfig = (SmtpServerConfig)Application.Get("SmtpConfig");

		}

	}

}