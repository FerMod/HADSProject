
using System;
using System.Data;
using System.Web.UI;
using DataBaseAccess;
using WebApplication.Framework;
using WebApplication.Framework.Extensions;

namespace WebApplication.UserPages {

	public partial class UserHome : MasterPage {

		public DataAccessService DataAccess => (DataAccessService)Session["DataAccess"];
		public DataSet UserDataSet { get => (DataSet)Session["UserDataSet"]; set => Session["UserDataSet"] = value; }

		protected void Page_Load(object sender, EventArgs e) {

			if(!IsPostBack) {
				ShowUserPanel((string)Session["UserType"]);
			}

		}

		private void ShowUserPanel(string userType) {

			switch(userType) {
				case "Alumno":
					StudentPages.Visible = true;
					TeacherPages.Visible = false;
					break;
				case "Profesor":
					StudentPages.Visible = false;
					TeacherPages.Visible = true;
					break;
				default:
					break;
			}

		}

	}

}
