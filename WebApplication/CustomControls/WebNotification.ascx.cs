
using System;
using System.Text.RegularExpressions;
using System.Web.UI;
using WebApplication.Framework;
using WebApplication.Framework.Extensions;

namespace WebApplication.CustomControls {

	public partial class WebNotification : UserControl {

		private string _title;
		private string _body;
		private AlertLevel _level = AlertLevel.None;
		private bool _dismissible = false;

		public string Title {
			get => _title;
			set {
				_title = value;
				AlertTitle.Text = (value != null && value.Length != 0) ? value : "";
			}
		}
		public int DepartmentID {
			get {
				if(ViewState["departmentID"] == null)
					return int.MinValue;
				else
					return (int)ViewState["departmentID"];
			}
			set { ViewState["departmentID"] = value; }
		}
		public AlertLevel Level {
			get => _level;
			set {
				if(_level != value) {
					Alert.CssClass = Regex.Replace(Alert.CssClass, "(alert-(?!dismissible|link|heading))(?:\\w*|$)", "");
				}
				Alert.AddCssClass(value.ToString());
				_level = value;
			}
		}

		public string Body {
			get => _body;
			set {
				_body = value;
				AlertBody.Text = value;
			}
		}

		public bool Dismissible {
			get => _dismissible;
			set {
				AlertCloseButton.Visible = value;
				if(value) {
					Alert.AddCssClass("alert-dismissible");
				} else {
					Alert.RemoveCssClass("alert-dismissible");
				}
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
