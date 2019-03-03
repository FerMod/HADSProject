using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication {

	public partial class SiteMaster : MasterPage {

		protected void Page_Load(object sender, EventArgs e) {

			if((bool)Session["IsLoggedIn"]) {
				userMenu.Visible = false;
				loggedUserMenu.Visible = true;
				LabelName.Text = (string)Session["Name"];
				LabelLastName.Text = (string)Session["LastName"];
				LabelMail.Text = (string)Session["Email"];
			} else {
				userMenu.Visible = true;
				loggedUserMenu.Visible = false;
			}

		}

		protected void ButtonProfile_Click(object sender, EventArgs e) {

		}

		protected void ButtonSignOut_Click(object sender, EventArgs e) {
			Session.Abandon();
		}

	}

}
