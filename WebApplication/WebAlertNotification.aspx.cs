
using System;
using System.Web.UI;
using WebApplication.Framework;
using WebApplication.Framework.Extensions;

namespace WebApplication {

	public partial class WebAlertNotification : Page {

		protected void Page_Load(object sender, EventArgs e) {

			if(!IsPostBack && Session["NotificationData"] is NotificationData notificationData) {
				GlobalNotification.ShowNotification(notificationData);
			}

		}

	}

}
