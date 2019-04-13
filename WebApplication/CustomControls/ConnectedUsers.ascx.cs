
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication.Framework;
using WebApplication.Framework.Extensions;

namespace WebApplication.CustomControls {

	public partial class ConnectedUsers : UserControl {

		public ConnectedUsersTrack LoggedUsers => (ConnectedUsersTrack)Application.Get("LoggedUsers");

		public int UpdateRate {
			get {
				return (int)ViewState["UpdateRate"];
			}

			set {
				UpdateTimer.Interval = value;
				ViewState["UpdateRate"] = value;
			}
		}

		protected void UpdateTimer_Tick(object sender, EventArgs e) {
			RefreshConnectedUsers();
		}

		private void RefreshConnectedUsers() {

			List<string> connectedStudents = LoggedUsers.GetUsers("student").ToList();
			StudentCount.Text = connectedStudents.Count.ToString();
			StudentList.DataSource = connectedStudents;

			List<string> connectedTeachers = LoggedUsers.GetUsers("teacher", "teacher_admin").ToList();
			TeacherCount.Text = connectedTeachers.Count.ToString();
			TeacherList.DataSource = connectedTeachers;

		}

	}

}
