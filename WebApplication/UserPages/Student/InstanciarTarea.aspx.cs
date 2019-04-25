
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI;
using DataBaseAccess;

namespace WebApplication.UserPages {

	public partial class InstanciarTarea : Page {

		private DataAccessService DataAccess => Master.DataAccess;
		private SqlDataAdapter TaskDataAdapter { get => (SqlDataAdapter)Session["TaskDataAdapter"]; set => Session["TaskDataAdapter"] = value; }
		private DataSet UserDataSet { get => Master.UserDataSet; set => Master.UserDataSet = value; }

		private DataTable StudentTasksDataTable {
			get {
				return UserDataSet.Tables["StudentTasks"];
			}
			set {
				value.TableName = "StudentTasks";
				if(UserDataSet.Tables.Contains(value.TableName)) {
					UserDataSet.Tables.Remove(value.TableName);
				}
				UserDataSet.Tables.Add(value);
			}
		}

		private DataTable TasksDataTable {
			get {
				return UserDataSet.Tables["Tasks"];
			}
			set {
				value.TableName = "Tasks";
				if(UserDataSet.Tables.Contains(value.TableName)) {
					UserDataSet.Tables.Remove(value.TableName);
				}
				UserDataSet.Tables.Add(value);
			}
		}

		protected void Page_Load(object sender, EventArgs e) {

			if(!Convert.ToBoolean(Session["IsLogged"])) {
				Response.Redirect(AppConfig.WebSite.MainPage);
			}

			if(!IsPostBack) {

				/*
				string codeParam = Request.QueryString["code"];
				if(String.IsNullOrWhiteSpace(codeParam)) {
					//TODO: Show message
				}
				*/

				string codeParam = Convert.ToString(Page.RouteData.Values["code"]);
				if(String.IsNullOrWhiteSpace(codeParam)) {
					//TODO: Show error message
				}

				string email = Convert.ToString(Session["Email"]);

				StudentTasksDataTable = CreateStudentsTasksDataTable(email);
				DataRow tasksRow = TasksDataTable.Select($"Codigo = '{codeParam}'").First();

				EmailTextBox.Text = email;
				CodTareaTextBox.Text = codeParam;
				HEstimadasTextBox.Text = tasksRow["HEstimadas"].ToString();

			}

		}

		private DataTable CreateStudentsTasksDataTable(string taskCode) {

			/*
			string query = "SELECT Email, CodTarea, HEstimadas, HReales " +
							"FROM EstudiantesTareas " +
							"WHERE Email = @Email " +
							"AND CodTarea = @CodTarea";

			Dictionary<string, object> parameters = new Dictionary<string, object> {
				{ "@CodTarea", taskCode },
				{ "@Email", email }
			};
			*/

			TaskDataAdapter = DataAccess.CreateDataAdapter("SELECT * FROM EstudiantesTareas");

			DataTable dataTable = new DataTable();
			TaskDataAdapter.Fill(dataTable);

			return dataTable;
		}

		protected void SaveChangesButton_Click(object sender, EventArgs e) {

			DataRow dataRow = StudentTasksDataTable.NewRow();
			dataRow.SetField("Email", EmailTextBox.Text);
			dataRow.SetField("CodTarea", CodTareaTextBox.Text);
			dataRow.SetField("HEstimadas", HEstimadasTextBox.Text);
			dataRow.SetField("HReales", HRealesTextBox.Text);

			StudentTasksDataTable.Rows.Add(dataRow);

			TaskDataAdapter.Update(StudentTasksDataTable);
			StudentTasksDataTable.AcceptChanges();
			Return();

		}

		protected void CancelButton_Click(object sender, EventArgs e) {
			Return();
		}

		private void Return() {
			//Response.Redirect("javascript:history.go(-1);");
			Response.RedirectToRoute("StudentTasks");
		}

	}

}
