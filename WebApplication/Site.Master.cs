
using System;
using System.Web.UI;
using WebApplication.Framework.Extensions;

namespace WebApplication {

	public partial class SiteMaster : MasterPage {

		protected void Page_Load(object sender, EventArgs e) {

			if((bool)Session["IsLogged"]) {

				LabelName.Text = Convert.ToString(Session["Name"]);
				LabelLastName.Text = Convert.ToString(Session["LastName"]);
				LabelMail.Text = Convert.ToString(Session["Email"]);

				userMenu.Visible = false;
				loggedUserMenu.Visible = true;

				ShowUserMenu(Convert.ToString(Session["UserType"]));

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

			studentMenu.Visible = false;
			teacherMenu.Visible = false;

			switch(userType) {
				case "Alumno":
					studentMenu.Visible = true;
					break;
				case "Profesor":
					teacherMenu.Visible = true;
					break;
			}

		}

	}

}
