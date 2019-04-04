
using System;
using System.Web.UI;

namespace WebApplication {

	public partial class RedirectPage : Page {

		protected void Page_Init(object sender, EventArgs e) {
			Response.Redirect(AppConfig.WebSite.MainPage, true);
		}

	}

}
