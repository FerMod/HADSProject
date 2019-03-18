
using System.Web.UI;

namespace WebApplication {

	public static class ScriptResource {

		/// <summary>
		/// Add a jQuery definition to the <c>ScriptManager.ScriptResourceMapping</c>.
		/// </summary>
		/// <param name="version">The <c>jQuery</c> version.</param>
		/// <param name="name">The name of the <c>jQuery</c> resource.</param>
		public static void RegisterJQuery(string version, string name = "jquery") {
			ScriptManager.ScriptResourceMapping.AddDefinition(name, new ScriptResourceDefinition() {
				Path = "~/Scripts/jquery-" + version + ".min.js",
				DebugPath = "~/Scripts/jquery-" + version + ".js",
				CdnPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-" + version + ".min.js",
				CdnDebugPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-" + version + ".js",
				CdnSupportsSecureConnection = true,
				LoadSuccessExpression = "window.jQuery"
			});
		}

		/// <summary>
		/// Add a Bootstrap definition to the <c>ScriptManager.ScriptResourceMapping</c>.
		/// </summary>
		/// <param name="version">The Bootstrap version.</param>
		/// <param name="name">The name of the Bootstrap resource.</param>
		public static void RegisterBoostrap(string version, string name = "bootstrap") {
			ScriptManager.ScriptResourceMapping.AddDefinition(name, new ScriptResourceDefinition() {
				Path = "~/Scripts/bootstrap.min.js",
				DebugPath = "~/Scripts/bootstrap.js",
				CdnPath = "http://ajax.aspnetcdn.com/ajax/bootstrap/" + version + "/bootstrap.min.js",
				CdnDebugPath = "http://ajax.aspnetcdn.com/ajax/bootstrap/" + version + "/bootstrap.js",
				CdnSupportsSecureConnection = true,
				LoadSuccessExpression = "window.jQuery.fn.carousel"
			});
		}

	}

}
