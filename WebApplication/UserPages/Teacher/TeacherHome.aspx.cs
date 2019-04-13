
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using DataBaseAccess;
using WebApplication.Framework;
using WebApplication.Framework.Extensions;
using WebApplication.Utils;

namespace WebApplication.UserPages {

	public partial class TeacherHome : Page {

		public ConnectedUsersTrack ConnectedUsers => (ConnectedUsersTrack)Application.Get("LoggedUsers");

		private Dictionary<string, List<decimal>> ChartData {
			get {
				if(Session["OnlineUsersChartData"] == null) {
					Session["OnlineUsersChartData"] = new Dictionary<string, List<decimal>>();
				}
				return (Dictionary<string, List<decimal>>)Session["OnlineUsersChartData"];
			}
			set {
				Session["OnlineUsersChartData"] = value;
			}
		}

		private List<string> OnlineUsersChartAxis {
			get {
				if(Session["OnlineUsersChartAxis"] == null) {
					Session["OnlineUsersChartAxis"] = new List<string>();
				}
				return (List<string>)Session["OnlineUsersChartAxis"];
			}
			set {
				Session["OnlineUsersChartAxis"] = value;
			}
		}

		protected void Page_Load(object sender, EventArgs e) {

			Master.ShowPage(TeacherMenu.Home);
			
			if(!IsPostBack) {
				RefreshConnectedUsers();
				UpdateConnectedUsersChart(Convert.ToDecimal(ConnectedUsers.GetUsers("student").Count()), Convert.ToDecimal(ConnectedUsers.GetUsers("teacher", "teacher_admin").Count()));
			}

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

		private void UpdateConnectedUsersChart(params decimal[] values) {
			OnlineUsersChartAxis.Add(DateTime.Now.ToString("HH:mm:ss"));
			OnlineUsersChart.CategoriesAxis = String.Join(", ", OnlineUsersChartAxis);
			
			//int height = Convert.ToInt32(OnlineUsersChart.ChartHeight);

			int size = OnlineUsersChart.Series.Count;
			for(int i = 0; i < size; i++) {

				BarChartSeries serie = OnlineUsersChart.Series[i];
				if(!ChartData.ContainsKey(serie.Name)) {
					ChartData[serie.Name] = new List<decimal>();
				}

				ChartData[serie.Name].Add(values[i]);

				OnlineUsersChart.Series[i].Data = ChartData[serie.Name].ToArray();

				//int maxValue = Convert.ToInt32(OnlineUsersChart.Series[i].Data.Max());
				//if(height < maxValue) {
				//	height += maxValue + 100;
				//}

			}

			//OnlineUsersChart.ChartHeight = height.ToString();

		}

	}

}
