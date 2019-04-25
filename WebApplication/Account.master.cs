
using System;
using System.Web.UI;
using WebApplication.CustomControls;
using WebApplication.Framework.Extensions;

namespace WebApplication {

	public partial class Account : MasterPage {

		public enum ActiveNav {
			None = -1,
			LogIn,
			CreateAccount
		}

		//FIXME: Error when calling property
		public WebNotification UserNotification => Notification;

		protected void Page_Load(object sender, EventArgs e) {

		}

		public void SetActiveNav(ActiveNav activeNav) {

			switch(activeNav) {
				case ActiveNav.LogIn:
					LogIn.AddCssClass("active");
					CreateAccount.RemoveCssClass("active");
					break;
				case ActiveNav.CreateAccount:
					CreateAccount.AddCssClass("active");
					LogIn.RemoveCssClass("active");
					break;
				default:
					LogIn.RemoveCssClass("active");
					CreateAccount.RemoveCssClass("active");
					break;
			}

		}

	}

}
