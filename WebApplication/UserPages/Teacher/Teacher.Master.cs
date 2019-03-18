
using System;
using System.Data;
using System.Web.Routing;
using System.Web.UI;
using DataBaseAccess;
using WebApplication.Framework;
using WebApplication.Framework.Extensions;

namespace WebApplication.UserPages {

	public enum TeacherMenu {
		None = -1,
		Home,
		Tasks
	}

	public partial class Teacher : MasterPage {

		public DataAccessService DataAccess => (DataAccessService)Session["DataAccess"];
		public DataSet UserDataSet { get => (DataSet)Session["UserDataSet"]; set => Session["UserDataSet"] = value; }

		private bool RequiresLoggedUser => true;
		private string AllowedUserType => "Profesor";

		protected void Page_Load(object sender, EventArgs e) {

			if(!IsPostBack) {

				if(!IsUserAllowed()) {
					Response.Redirect("~/Default");
				}

			}

		}

		public void ShowPage(TeacherMenu selectedMenu) {
			switch(selectedMenu) {
				case TeacherMenu.Home:
					HomeTab.AddCssClass("active", "disabled");
					TasksTab.RemoveCssClass("active", "disabled");
					break;
				case TeacherMenu.Tasks:
					HomeTab.RemoveCssClass("active", "disabled");
					TasksTab.AddCssClass("active", "disabled");
					break;
				case TeacherMenu.None:
				default:
					HomeTab.RemoveCssClass("active", "disabled");
					TasksTab.RemoveCssClass("active", "disabled");
					break;
			}
		}

		private bool IsUserAllowed() {

			if(!Convert.ToBoolean(Session["IsLogged"]) && RequiresLoggedUser) {
				return false;
			}

			if(!Convert.ToString(Session["UserType"]).Equals(AllowedUserType)) {
				return false;
			}

			return true;

		}
	}

}
