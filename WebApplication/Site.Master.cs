
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using WebApplication.Framework;
using WebApplication.Framework.Extensions;

namespace WebApplication {

	public partial class SiteMaster : MasterPage {

		public ConnectedUsersTrack ConnectedUsers => (ConnectedUsersTrack)Application.Get("LoggedUsers");

		protected void Page_Load(object sender, EventArgs e) {

			if(Convert.ToBoolean(Session["IsLogged"])) {

				LabelName.Text = Convert.ToString(Session["Name"]);
				LabelLastName.Text = Convert.ToString(Session["LastName"]);
				LabelMail.Text = Convert.ToString(Session["Email"]);

				userMenu.Visible = false;
				loggedUserMenu.Visible = true;

				ShowUserMenu(Convert.ToString(Session["UserType"]));

			} else {

				userMenu.Visible = true;
				loggedUserMenu.Visible = false;

			}

			RefreshConnectedUsers();

		}

		protected void ButtonProfile_Click(object sender, EventArgs e) {

		}

		protected void ButtonSignOut_Click(object sender, EventArgs e) {
			//Session["IsLogged"] = false;
			//Session["Email"] = "";
			//Session["Name"] = "";
			//Session["LastName"] = "";
			//Response.Redirect(AppConfig.WebSite.MainPage);
			Session.Abandon();
		}

		private void ShowUserMenu(string userType) {

			studentMenu.Visible = false;
			teacherMenu.Visible = false;

			switch(userType) {
				case "student":
					studentMenu.Visible = true;
					break;
				case "teacher_admin":
				case "teacher":
					teacherMenu.Visible = true;
					break;
			}

		}

		protected void ConnectedUsersTimer_Tick(object sender, EventArgs e) {
			RefreshConnectedUsers();
		}

		private void RefreshConnectedUsers() {

			List<string> connectedStudents = ConnectedUsers.GetUsers("student").ToList();
			ConnectedStudentCount.Text = connectedStudents.Count.ToString();
			ConnectedStudents.DataSource = connectedStudents;

			List<string> connectedTeachers = ConnectedUsers.GetUsers("teacher", "teacher_admin").ToList();
			ConnectedTeacherCount.Text = connectedTeachers.Count.ToString();
			ConnectedTeachers.DataSource = connectedTeachers;

		}

	}

}
