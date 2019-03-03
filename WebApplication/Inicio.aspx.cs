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
				Response.Redirect("/Default");
			}

		}

		protected void ButtonLogin_Click(object sender, EventArgs e) {

			string sql = "SELECT * FROM Usuarios WHERE Usuarios.email = @email AND Usuarios.pass = @password";
			Dictionary<string, object> parameters = new Dictionary<string, object> {
				{ "@email", textBoxEmail.Text },
				{ "@password", textBoxPassword.Text }
			};

			try {

				List<IDataRecord> result = DataAccess.Query(sql, parameters);

				if(result.Count == 1) {

					//IDataRecord dataRecord = result[0];
					Session["IsLogged"] = true;
					//Session["Email"] = dataRecord.GetValue(dataRecord.GetOrdinal("email"));
					//Session["Name"] = dataRecord.GetValue(dataRecord.GetOrdinal("nombre"));
					//Session["LastName"] = dataRecord.GetValue(dataRecord.GetOrdinal("apellidos"));

					Response.Redirect("/Default");
				} else {
					Debug.WriteLine("Wrong credentials");
				}

			} catch(Exception ex) {
				Debug.WriteLine("Exception caught: " + ex.Message);
			}

		}

	}

}