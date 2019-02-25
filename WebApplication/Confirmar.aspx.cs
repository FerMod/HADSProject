using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataBaseAccess;

namespace WebApplication {

	public partial class Confirmar : System.Web.UI.Page {

		private DataAccessService DataAccess { get; set; }

		protected void Page_Load(object sender, EventArgs e) {

			string emailParam = Request.QueryString["email"];
			string codeParam = Request.QueryString["code"];

			if(String.IsNullOrWhiteSpace(emailParam) || String.IsNullOrWhiteSpace(codeParam)) {
				// TODO: Show notification to user
			}

			if(!Int32.TryParse(Request.QueryString["code"], out int code)) {
				// TODO: Show message. Error parsing
			}

			// TODO: Fix issue, not a lazy object
			if(!IsPostBack && Session["SessionDataAccess"] != null) {
				DataAccess = (DataAccessService)Session["SessionDataAccess"];
			} else {
				Application.Lock();
				Session["SessionDataAccess"] = (DataAccessService)Application["DataAccess"];
				Application.UnLock();
			}

			/* TODO: Query code from database and compare to the obtained in the url
			 * if both match update value of "confirmed" from the database.
			 * Otherwhise, show a message to the user saying that "Could not confirm the email"
			 */

			string queryUser = "SELECT COUNT(*) FROM Usuarios WHERE email = @email AND numconfir = @numconfir";

			Dictionary<string, object> parameters = new Dictionary<string, object> {
				{ "@email", emailParam },
				{ "@numConfir", code.ToString() }
			};

			if(DataAccess.Scalar<int>(queryUser, parameters) == 1) {

				string queryUpdate = "UPDATE Usuarios SET confirmado = 1, numconfir = -1 WHERE email = @email AND numconfir = @numconfir";

				if(DataAccess.Update(queryUpdate, parameters) != 1) {
					// TODO: Show update error
				}

			}


		}

	}

}