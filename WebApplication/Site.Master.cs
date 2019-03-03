using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication.Framework;

namespace WebApplication {

	public partial class SiteMaster : MasterPage {

		protected void Page_Load(object sender, EventArgs e) {

			if((bool)Session["IsLogged"]) {

				LabelName.Text = (string)Session["Email"];
				LabelLastName.Text = (string)Session["Name"];
				LabelMail.Text = (string)Session["LastName"];

				userMenu.Visible = false;
				loggedUserMenu.Visible = true;

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
		}

	}

}
