
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication.Framework;

namespace WebApplication.UserPages {

	public partial class StudentHome : Page {

		public ConnectedUsersTrack ConnectedUsers => (ConnectedUsersTrack)Application.Get("LoggedUsers");

		protected void Page_Load(object sender, EventArgs e) {

			Master.ShowPage(StudentMenu.Home);
			RefreshConnectedUsers();

		}

		protected void ConnectedUsersTimer_Tick(object sender, EventArgs e) {
			RefreshConnectedUsers();
		}


		private void RefreshConnectedUsers() {

			List<string> connectedStudents = ConnectedUsers.GetUsers("student").ToList();
			ConnectedStudentCount.Text = $"Connected students ({connectedStudents.Count.ToString()}):";

			ConnectedStudents.AppendDataBoundItems = false;
			ConnectedStudents.DataSource = connectedStudents;
			ConnectedStudents.DataBind();


			List<string> connectedTeachers = ConnectedUsers.GetUsers("teacher", "teacher_admin").ToList();
			ConnectedTeacherCount.Text = $"Connected teachers ({connectedTeachers.Count.ToString()}):";

			ConnectedStudents.AppendDataBoundItems = false;
			ConnectedTeachers.DataSource = connectedTeachers;
			ConnectedTeachers.DataBind();

		}

	}

}
