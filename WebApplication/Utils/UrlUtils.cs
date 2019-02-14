using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Utils {

	public static class UrlUtils {

		/// <summary>
		/// Gets the base part of the URL 'http://www."
		/// </summary>
		public static string UrlRoot {
			get {
				Uri url = HttpContext.Current.Request.Url;
				return string.Format("{0}{1}{2}", url.Scheme, Uri.SchemeDelimiter, url.Authority);
			}
		}

		/// <summary>
		/// Returns the Virtual Path.
		/// </summary>
		/// <remarks>The path will start and end with a /</remarks>
		/// <returns></returns>
		public static string VirtualPath {
			get {

				string path = HttpRuntime.AppDomainAppVirtualPath;

				if(!path.StartsWith("/")) {
					path = "/" + path;
				}

				if(!path.EndsWith("/")) {
					path += "/";
				}

				return path;
			}
		}

		/// <summary>
		/// Contains the child folder portion of the path.
		/// </summary>
		public static string ApplicationFolder {
			get {
				string[] segments = HttpContext.Current.Request.Url.Segments;
				string url = "";

				for(int x = 0; x < segments.Length - 1; x++) {
					url += segments[x];
				}

				string virtualPath = VirtualPath;

				if(url.StartsWith(virtualPath)) {
					url = url.Substring(virtualPath.Length);
				}

				return url;
			}
		}

	}

}