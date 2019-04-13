
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;
using System.Web.UI;
using WebApplication.Framework;
using WebApplication.Framework.Extensions;

namespace WebApplication {

	public partial class SiteMaster : MasterPage {

		protected void Page_Load(object sender, EventArgs e) {

			if(Convert.ToBoolean(Session["IsLogged"])) {

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
			SignOut();
		}

		private void SignOut() {
			FormsAuthentication.SignOut();
			Session.Abandon();
			FormsAuthentication.RedirectToLoginPage();
		}

		private void ShowUserMenu(string userType) {

			studentMenu.Visible = false;
			teacherMenu.Visible = false;

			switch(userType) {
				case "student":
					studentMenu.Visible = true;
					break;
				case "teacher_admin":
				case "teacher":
					teacherMenu.Visible = true;
					break;
			}

		}

	}

}
