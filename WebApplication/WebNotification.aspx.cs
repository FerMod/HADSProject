using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication {

	public partial class WebNotification : Page {

		protected void Page_Load(object sender, EventArgs e) {

			if(!IsPostBack) {

				if(Session["NotificationTitle"] != null) {
					title.Text = (string)Session["NotificationTitle"];
				}

				if(Session["NotificationBody"] != null) {
					body.Text = (string)Session["NotificationBody"];
				}

			}

		}

	}

}
