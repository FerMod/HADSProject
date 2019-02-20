using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace WebApplication.Framework {

	public class ParametizedUrl : Dictionary<string, string> {

		public string Url { get; set; }

		public ParametizedUrl(string url) {
			this.Url = url;
		}

		public override string ToString() {

			StringBuilder sb = new StringBuilder($"{this.Url}");
			if(this.Count > 0) {
				sb.Append("?");
			}

			int i = 1;
			foreach(var entry in this) {
				sb.Append($"{entry.Key}={entry.Value}");
				if(i < this.Count) {
					sb.Append("&");
					i++;
				}
			}

			return sb.ToString();
		}

	}

}