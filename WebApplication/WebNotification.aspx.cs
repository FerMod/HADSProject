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

		protected void Page_PreInit(object sender, EventArgs e) {
		}

		protected void Page_Load(object sender, EventArgs e) {

			if(!IsPostBack && Session["NotificationData"] != null) {
				UpdateContent((NotificationData)Session["NotificationData"]);
				alert.Visible = true;
			}

		}

		public void UpdateContent(NotificationData notificationData) {

			title.Visible = !String.IsNullOrWhiteSpace(notificationData.Title);
			if(title.Visible) {
				title.Text = $"{notificationData.Title}<hr>";
			}

			body.Text = notificationData.Body;
			alert.CssClass = $"{alert.CssClass} {notificationData.Level}";

			close.Visible = notificationData.Dismissable;
			if(notificationData.Dismissable) {
				alert.CssClass += " alert-dismissible fade show";
			}

		}

	}

}
