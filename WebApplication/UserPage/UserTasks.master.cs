
using System;
using System.Web.UI;
using WebApplication.Framework.Extensions;

namespace WebApplication {

	public partial class UserTasks : MasterPage {

		public enum ActiveNav {
			None = -1,
			StudentTasks,
			InstantiateTask
		}

		protected void Page_Load(object sender, EventArgs e) {
		}

		public void SetActiveNav(ActiveNav activeNav) {

			switch(activeNav) {
				case ActiveNav.StudentTasks:
					StudentTasks.AddCssClass("active");
					InstantiateTask.RemoveCssClass("active");
					break;
				case ActiveNav.InstantiateTask:
					InstantiateTask.AddCssClass("active");
					StudentTasks.RemoveCssClass("active");
					break;
				default:
					InstantiateTask.RemoveCssClass("active");
					StudentTasks.RemoveCssClass("active");
					break;
			}

		}

	}

}
