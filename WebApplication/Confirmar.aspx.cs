using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataBaseAccess;
using WebApplication.Framework;

namespace WebApplication {

	public partial class Confirmar : System.Web.UI.Page {

		public DataAccessService DataAccess => (Session["SessionLazyDataAccess"] as Lazy<DataAccessService>)?.Value;

		protected void Page_Load(object sender, EventArgs e) {

			string emailParam = Request.QueryString["email"];
			string codeParam = Request.QueryString["code"];

			NotificationData notificationData = new NotificationData();

			if(String.IsNullOrWhiteSpace(emailParam) || String.IsNullOrWhiteSpace(codeParam)) {
				// TODO: Show notification to user
			}

			if(!Int32.TryParse(Request.QueryString["code"], out int code)) {
				// TODO: Show message. Error parsing
			}

			/* TODO: Query code from database and compare to the obtained in the url
			 * if both match update value of "confirmed" from the database.
			 * Otherwhise, show a message to the user saying that "Could not confirm the email"
			 */

			string queryUser = "SELECT COUNT(*) FROM Usuarios WHERE email = @email AND numconfir = @numconfir";
			string queryUpdate = "UPDATE Usuarios SET confirmado = 1, numconfir = -1 WHERE email = @email AND numconfir = @numconfir";

			Dictionary<string, object> parameters = new Dictionary<string, object> {
				{ "@email", emailParam },
				{ "@numConfir", code.ToString() }
			};

			if(DataAccess.Scalar<int>(queryUser, parameters) != 1 || DataAccess.Update(queryUpdate, parameters) != 1) {
				notificationData.Title = "Could Not Confirm The Email";
				notificationData.Body = $"Thank you! Email successfully validated.";
				notificationData.Level = AlertLevel.Danger;
			} else {
				Session["IsLoggedIn"] = true;
				notificationData.Title = "Account Confirmed";
				notificationData.Body = $"Thank you! Email successfully validated.";
				notificationData.Level = AlertLevel.Success;
			}

			Session["NotificationData"] = notificationData;
			Response.Redirect("/WebNotification");
		}

	}

}