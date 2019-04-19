using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataBaseAccess;
using WebApplication.Framework;
using WebApplication.ComprobarMatriculaService;

namespace WebApplication {

	public partial class Inicio : Page {

		private DataAccessService DataAccess => (DataAccessService)Session["DataAccess"];

		protected void Page_Load(object sender, EventArgs e) {

			if(Convert.ToBoolean(Session["IsLogged"])) {
				Response.Redirect(AppConfig.WebSite.MainPage);
			}

			Master.SetActiveNav(Account.ActiveNav.LogIn);

		}

		protected void ButtonLogin_Click(object sender, EventArgs e) {

			string sql = "SELECT email, nombre, apellidos, tipo " +
						"FROM Usuarios " +
						"WHERE email = @email " +
						"AND pass = @password";

			byte[] hashedPass = AppSecurity.GenerateHash(textBoxPassword.Text);

			Dictionary<string, object> parameters = new Dictionary<string, object> {
				{ "@email", textBoxEmail.Text },
				{ "@password", hashedPass }
			};
			
			try {

				QueryResult queryResult = DataAccess.Query(sql, parameters);

				if(queryResult.Rows.Count != 1) {

					Debug.WriteLine("Wrong credentials");

				} else {

					Session["IsLogged"] = true;
					string email = Convert.ToString(queryResult.Rows[0]["email"]);
					Session["Email"] = email;
					Session["Name"] = queryResult.Rows[0]["nombre"];
					Session["LastName"] = queryResult.Rows[0]["apellidos"];
					string tipo = Convert.ToString(queryResult.Rows[0]["tipo"]);
					Session["UserType"] = GetUserTypeName(email, tipo);

					FormsAuthentication.SetAuthCookie(Session["UserType"].ToString(), true);

					AddConnectedUsers(Session["UserType"].ToString(), email);

					Response.Redirect(AppConfig.WebSite.MainPage);

				}

			} catch(Exception ex) {
				Debug.WriteLine("Exception caught: " + ex.Message);
			}

		}

		private void AddConnectedUsers(string type, string email) {

			((ConnectedUsersTrack)Application.Get("LoggedUsers")).Add(Session["UserType"].ToString(), email);

		}

		private string GetUserTypeName(string email, string type) {

			// Special case
			if(email.Equals("vadillo@ehu.es")) {
				return "teacher_admin";
			}

			switch(type.ToLower()) {
				case "alumno":
					return "student";
				case "profesor":
					return "teacher";
				default:
					return String.Empty;
			}

		}

	}

}
