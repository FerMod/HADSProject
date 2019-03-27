
using System;
using System.Collections.Generic;
using System.Linq;
using DataBaseAccess;
using WebApplication.Framework;

namespace WebApplication {

	public partial class Confirmar : System.Web.UI.Page {

		private DataAccessService DataAccess => (DataAccessService)Session["DataAccess"];

		protected void Page_Load(object sender, EventArgs e) {

			string emailParam = Request.QueryString["email"];
			string codeParam = Request.QueryString["code"];

			NotificationData notificationData = new NotificationData();

			if(String.IsNullOrWhiteSpace(emailParam) || String.IsNullOrWhiteSpace(codeParam)) {

				notificationData.Body = $"<strong>Malformed url:</strong> The url parameters could be wrong.";
				notificationData.Level = AlertLevel.Danger;

			} else if(!Int32.TryParse(codeParam, out int code)) {

				notificationData.Body = $"<strong>Invalid code:</strong> The code is not of the correct type.";
				notificationData.Level = AlertLevel.Danger;

			} else {

				string queryUser = "SELECT email, nombre, apellidos, tipo FROM Usuarios WHERE email = @email AND numconfir = @numconfir";
				string queryUpdate = "UPDATE Usuarios SET confirmado = 1, numconfir = -1 WHERE email = @email AND numconfir = @numconfir";

				Dictionary<string, object> parameters = new Dictionary<string, object> {
					{ "@email", emailParam },
					{ "@numConfir", code.ToString() }
				};

				QueryResult queryResult = DataAccess.Query(queryUser, parameters);

				if(queryResult.Rows.Count != 1 || DataAccess.NonQuery(queryUpdate, parameters) != 1) {

					notificationData.Title = "Could Not Verify Account";
					notificationData.Body = $"The email could not be validated. Please try again.";
					notificationData.Level = AlertLevel.Danger;

				} else {

					Session["IsLogged"] = true;
					Session["Email"] = queryResult.Rows[0]["email"];
					Session["Name"] = queryResult.Rows[0]["nombre"];
					Session["LastName"] = queryResult.Rows[0]["apellidos"];
					Session["UserType"] = queryResult.Rows[0]["tipo"];

					notificationData.Title = "Account Confirmed";
					notificationData.Body = $"Thank you! Email successfully validated.";
					notificationData.Level = AlertLevel.Success;

				}

			}

			Session["NotificationData"] = notificationData;
			Response.Redirect("~/WebAlertNotification");

		}

	}

}
