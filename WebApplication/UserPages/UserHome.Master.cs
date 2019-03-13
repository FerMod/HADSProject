
using System;
using System.Data;
using System.Web.UI;
using DataBaseAccess;
using WebApplication.Framework.Extensions;

namespace WebApplication.UserPages {

	public partial class UserHome : MasterPage {

		public DataAccessService DataAccess => (DataAccessService)Session["DataAccess"];
		public DataSet UserDataSet { get => (DataSet)Session["UserDataSet"]; set => Session["UserDataSet"] = value; }

		public enum ActiveNavTab {
			None = -1,
			Home,
			Tasks
		}

		protected void Page_Load(object sender, EventArgs e) {
		}

		public void SetActiveNavTab(ActiveNavTab activeNav) {

			switch(activeNav) {
				case ActiveNavTab.Tasks:
					//Home.RemoveCssClass("active");
					//HomeTab.RemoveCssClass("show", "active");
					//Tasks.AddCssClass("active");
					//TasksTab.AddCssClass("show", "active");
					break;
				case ActiveNavTab.Home:
				default:
					//Home.AddCssClass("active");
					//HomeTab.AddCssClass("show", "active");
					//Tasks.RemoveCssClass("active");
					//TasksTab.RemoveCssClass("show", "active");
					break;
			}

		}

	}

}
