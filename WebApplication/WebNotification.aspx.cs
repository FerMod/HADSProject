using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication.Framework;

namespace WebApplication {

	public partial class WebNotification : Page {

		protected void Page_Load(object sender, EventArgs e) {

			if(!IsPostBack && Session["NotificationData"] != null) {
				Alert.Visible = true;
				UpdateContent((NotificationData)Session["NotificationData"]);
			}

		}

		public void UpdateContent(NotificationData notificationData) {

			AlertTitle.Visible = !String.IsNullOrWhiteSpace(notificationData.Title);
			if(AlertTitle.Visible) {
				AlertTitle.Text = $"{notificationData.Title}<hr>";
			}

			AlertBody.Text = notificationData.Body;
			Alert.CssClass = $"{Alert.CssClass} {notificationData.Level}";

			AlertCloseButton.Visible = notificationData.Dismissable;
			if(notificationData.Dismissable) {
				Alert.CssClass += " alert-dismissible fade show";
			}

		}

	}

}
