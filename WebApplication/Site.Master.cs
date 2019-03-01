using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication {

	public partial class SiteMaster : MasterPage {

		protected void Page_Load(object sender, EventArgs e) {

			// TODO: Implement a way to check if the user is logged in
			if(false) {

				userMenu.Visible = false;
				loggedUserMenu.Visible = true;

			}

		}

	}

}
