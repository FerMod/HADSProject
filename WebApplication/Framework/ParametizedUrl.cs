using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Web;
using WebApplication.Framework.Extensions;

namespace WebApplication.Framework {

	public class ParametizedUrl : Dictionary<string, string> {

		public string Url { get; set; }

		public ParametizedUrl(string url) {

			if(url.Contains("?")) {

				Uri uri = new Uri(url);
				url = $"{uri.Scheme}{Uri.SchemeDelimiter}{uri.Authority}";

				this.Add(HttpUtility.ParseQueryString(uri.Query));

			}

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

		public static implicit operator string(ParametizedUrl parametizedUrl) {
			return parametizedUrl.ToString();
		}

	}

}