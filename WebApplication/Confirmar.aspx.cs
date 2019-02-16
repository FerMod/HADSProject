using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication {

	public partial class Confirmar : System.Web.UI.Page {

		protected void Page_Load(object sender, EventArgs e) {

			string emailParam = Request.QueryString["email"];
			string codeParam = Request.QueryString["code"];

			if(String.IsNullOrWhiteSpace(emailParam) || String.IsNullOrWhiteSpace(codeParam)) {
				// TODO: Show notification to user
			}

			Int32.TryParse(Request.QueryString["code"], out int code);

			/* TODO: Query code from database and compare to the obtained in the url
			 * if both match update value of "confirmed" from the database.
			 * Otherwhise, show a message to the user saying that "Could not confirm the email"
			 */


		}

	}

}