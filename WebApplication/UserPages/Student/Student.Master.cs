
using System;
using System.Data;
using System.Web.Routing;
using System.Web.UI;
using DataBaseAccess;
using WebApplication.Framework;
using WebApplication.Framework.Extensions;

namespace WebApplication.UserPages {

	public enum StudentMenu {
		None = -1,
		Home,
		Tasks
	}

	public partial class Student : MasterPage {

		public DataAccessService DataAccess => (DataAccessService)Session["DataAccess"];
		public DataSet UserDataSet { get => (DataSet)Session["UserDataSet"]; set => Session["UserDataSet"] = value; }

		private bool RequiresLoggedUser => true;
		private string[] AllowedUserTypes => new[] { "student" };

		protected void Page_Load(object sender, EventArgs e) {

			if(!IsPostBack) {

				if(!IsAllowedUser()) {
					Response.Redirect(AppConfig.WebSite.MainPage);
				}

			}

		}

		public void ShowPage(StudentMenu selectedMenu) {

			HomeTab.RemoveCssClass("active", "disabled");
			TasksTab.RemoveCssClass("active", "disabled");

			switch(selectedMenu) {
				case StudentMenu.Home:
					HomeTab.AddCssClass("active", "disabled");
					break;
				case StudentMenu.Tasks:
					TasksTab.AddCssClass("active", "disabled");
					break;
				case StudentMenu.None:
				default:
					break;
			}

		}

		private bool IsAllowedUser() {

			if(!Convert.ToBoolean(Session["IsLogged"]) && RequiresLoggedUser) {
				return false;
			}

			if(Array.IndexOf(AllowedUserTypes, Session["UserType"]) == -1) {
				return false;
			}

			return true;

		}
	}

}
