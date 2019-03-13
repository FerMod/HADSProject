using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataBaseAccess;
using WebApplication.Framework;

namespace WebApplication {

	public partial class Inicio : Page {

		private DataAccessService DataAccess => (DataAccessService)Session["DataAccess"];

		protected void Page_Load(object sender, EventArgs e) {

			if((bool)Session["IsLogged"]) {
				Response.Redirect("~/Default");
			}

			Master.SetActiveNav(Account.ActiveNav.LogIn);

		}

		protected void ButtonLogin_Click(object sender, EventArgs e) {

			string sql = "SELECT email, nombre, apellidos, tipo " +
						"FROM Usuarios " +
						"WHERE email = @email " +
						"AND pass = @password";
			Dictionary<string, object> parameters = new Dictionary<string, object> {
				{ "@email", textBoxEmail.Text },
				{ "@password", textBoxPassword.Text }
			};

			try {

				QueryResult queryResult = DataAccess.Query(sql, parameters);

				if(queryResult.Rows.Count != 1) {

					Debug.WriteLine("Wrong credentials");

				} else {

					Session["IsLogged"] = true;
					Session["Email"] = queryResult.Rows[0]["email"];
					Session["Name"] = queryResult.Rows[0]["nombre"];
					Session["LastName"] = queryResult.Rows[0]["apellidos"];
					Session["UserType"] = queryResult.Rows[0]["tipo"];

					Response.Redirect("~/Default");
				}

			} catch(Exception ex) {
				Debug.WriteLine("Exception caught: " + ex.Message);
			}

		}

	}

}