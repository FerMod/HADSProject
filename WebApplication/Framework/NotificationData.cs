
using System.Collections.Generic;

namespace WebApplication.Framework {

	public class NotificationData {

		public string Title { get; set; }
		public string Body { get; set; }
		public AlertLevel Level { get; set; } = AlertLevel.None;
		public bool Dismissable { get; set; } = false;
		//public Dictionary<string, object> Data { get; set; } = new Dictionary<string, object>();

	}

}
