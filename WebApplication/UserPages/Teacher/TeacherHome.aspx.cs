
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataBaseAccess;
using WebApplication.Framework;
using WebApplication.Framework.Extensions;
using WebApplication.Utils;

namespace WebApplication.UserPages {

	public partial class TeacherHome : Page {

		public ConnectedUsersTrack ConnectedUsers => (ConnectedUsersTrack)Application.Get("LoggedUsers");

		protected void Page_Load(object sender, EventArgs e) {

			Master.ShowPage(TeacherMenu.Home);
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
