
using System;
using System.Data;
using System.Web.Routing;
using System.Web.UI;
using DataBaseAccess;
using WebApplication.CustomControls;
using WebApplication.Framework;
using WebApplication.Framework.Extensions;

namespace WebApplication.UserPages {

	public enum TeacherMenu {
		None = -1,
		Home,
		Tasks,
		ImportTasksXmlDocument,
		ImportTasksDataSet,
		ExportTasks
	}

	public partial class Teacher : MasterPage {

		public DataAccessService DataAccess => (DataAccessService)Session["DataAccess"];
		public DataSet UserDataSet { get => (DataSet)Session["UserDataSet"]; set => Session["UserDataSet"] = value; }

		private bool RequiresLoggedUser => true;
		private string AllowedUserType => "Profesor";

		protected void Page_Load(object sender, EventArgs e) {

			if(!IsPostBack) {

				if(!IsAllowedUser()) {
					Response.Redirect(AppConfig.WebSite.MainPage);
				}

			}

		}

		public void ShowPage(TeacherMenu selectedMenu) {

			HomeTab.RemoveCssClass("active", "disabled");
			TasksTab.RemoveCssClass("active", "disabled");
			ImportTasksXmlDocumentTab.RemoveCssClass("active", "disabled");
			ImportTasksDataSetTab.RemoveCssClass("active", "disabled");

			switch(selectedMenu) {
				case TeacherMenu.Home:
					HomeTab.AddCssClass("active", "disabled");
					break;
				case TeacherMenu.Tasks:
					TasksTab.AddCssClass("active", "disabled");
					break;
				case TeacherMenu.ImportTasksXmlDocument:
					ImportTasksXmlDocumentTab.AddCssClass("active", "disabled");
					break;
				case TeacherMenu.ImportTasksDataSet:
					ImportTasksDataSetTab.AddCssClass("active", "disabled");
					break;
				case TeacherMenu.ExportTasks:
					ExportTasksTab.AddCssClass("active", "disabled");
					break;
				case TeacherMenu.None:
				default:
					break;
			}
		}

		private bool IsAllowedUser() {

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
