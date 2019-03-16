
using System;
using System.Web.UI;
using WebApplication.Framework.Extensions;

namespace WebApplication {

	public partial class SiteMaster : MasterPage {

		protected void Page_Load(object sender, EventArgs e) {

			if((bool)Session["IsLogged"]) {

				LabelName.Text = (string)Session["Email"];
				LabelLastName.Text = (string)Session["Name"];
				LabelMail.Text = (string)Session["LastName"];

				userMenu.Visible = false;
				loggedUserMenu.Visible = true;

				ShowUserMenu((string)Session["UserType"]);

			} else {

				userMenu.Visible = true;
				loggedUserMenu.Visible = false;

			}

		}

		protected void ButtonProfile_Click(object sender, EventArgs e) {

		}

		protected void ButtonSignOut_Click(object sender, EventArgs e) {
			Session["IsLogged"] = false;
			Session["Email"] = "";
			Session["Name"] = "";
			Session["LastName"] = "";
			Response.Redirect(Request.Url.AbsolutePath);
			Session.Abandon();
		}

		private void ShowUserMenu(string userType) {

			switch(userType) {
				case "Alumno":
					studentMenu.Visible = true;
					teacherMenu.Visible = false;
					break;
				case "Profesor":
					studentMenu.Visible = false;
					teacherMenu.Visible = true;
					break;
				default:
					studentMenu.Visible = false;
					teacherMenu.Visible = false;
					break;
			}

		}

	}

}
