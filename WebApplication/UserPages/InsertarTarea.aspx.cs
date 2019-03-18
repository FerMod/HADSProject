
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataBaseAccess;
using WebApplication.Framework.Extensions;

namespace WebApplication.UserPages {

	public partial class InsertarTarea : Page {

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

			if(!(bool)Session["IsLogged"]) {
				Response.Redirect("~/Default");
			}

			if(!IsPostBack) {

				string codeParam = Request.QueryString["code"];
				if(String.IsNullOrWhiteSpace(codeParam)) {
					//TODO: Show message
				}

				string email = (string)Session["Email"];

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
			Response.Redirect(Page.ResolveUrl(@"~/UserPages/TareasAlumno"));
		}

	}

}