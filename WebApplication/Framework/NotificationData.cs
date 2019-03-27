
using System;

namespace WebApplication.Framework {

	public class NotificationData {

		public string Title { get; set; } = String.Empty;
		public string Body { get; set; } = String.Empty;
		public AlertLevel Level { get; set; } = AlertLevel.None;
		public bool Dismissible { get; set; } = false;

	}

}
