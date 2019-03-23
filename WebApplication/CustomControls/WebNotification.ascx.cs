
using System;
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
				AlertTitle.Text = (value != null && value.Length != 0) ? $"{value}<hr>" : "";
			}
		}

		public AlertLevel Level {
			get => _level;
			set {
				if(_level != value) {
					Alert.RemoveCssClass(_level.ToString());
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
					Alert.AddCssClass("alert-dismissible", "fade", "show");
				} else {
					Alert.RemoveCssClass("alert-dismissible", "fade", "show");
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

		/*
		public void ShowNotification(NotificationData notificationData) {

			AlertTitle.Visible = !String.IsNullOrWhiteSpace(notificationData.Title);
			if(AlertTitle.Visible) {
				AlertTitle.Text = $"{notificationData.Title}<hr>";
			}

			AlertBody.Text = notificationData.Body;
			Alert.CssClass = $"{Alert.CssClass} {notificationData.Level}";

			AlertCloseButton.Visible = notificationData.Dismissible;
			if(notificationData.Dismissible) {
				Alert.CssClass += " alert-dismissible fade show";
			}

			Visible = true;

		}
		*/

	}

}
