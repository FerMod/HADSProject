
using System;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication.Framework;
using WebApplication.Framework.Extensions;

namespace WebApplication.CustomControls {

	public partial class WebNotification : UserControl {

		//private string _title;
		//private string _body;
		//private AlertLevel _level = AlertLevel.None;
		//private bool _dismissible = false;

		public string Title {
			get {
				return (string)ViewState["Title"] ?? String.Empty;
			}

			set {
				AlertTitle.Text = (value != null && value.Length != 0) ? value : String.Empty;
				ViewState["Title"] = value;
			}
		}

		public AlertLevel Level {
			get {
				return (AlertLevel)ViewState["Level"] ?? AlertLevel.None;
			}
			set {
				//if(_level != value) {
				//	Alert.CssClass = Regex.Replace(Alert.CssClass, "(alert-(?!dismissible|link|heading))(?:\\w*|$)", "");
				//}
				if(ViewState["Level"] is AlertLevel alertLevel && alertLevel != value) {
					Alert.RemoveCssClass(alertLevel.ToString());
				}
				Alert.AddCssClass(value.ToString());
				ViewState["Level"] = value;
			}
		}

		public string Body {
			get {
				return (string)ViewState["Body"] ?? String.Empty;
			}
			set {
				AlertBody.Text = value;
				ViewState["Body"] = value;
			}
		}

		public bool Dismissible {
			get {
				return ViewState["Dismissible"] is bool;
			}

			set {
				AlertCloseButton.Visible = value;
				if(value) {
					Alert.AddCssClass("alert-dismissible");
				} else {
					Alert.RemoveCssClass("alert-dismissible");
				}
				ViewState["Dismissible"] = value;
			}
		}

		public override bool Visible {
			get {
				return base.Visible;
			}
			set {
				base.Visible = value;
				Alert.Visible = value;
			}
		}

		public void ShowNotification(NotificationData notificationData) {

			Title = notificationData.Title;
			Body = notificationData.Body;
			Level = notificationData.Level;
			Dismissible = notificationData.Dismissible;

			Visible = true;

		}

		protected void AlertCloseButton_Click(object sender, EventArgs e) {
			Visible = false;
		}

	}

}
