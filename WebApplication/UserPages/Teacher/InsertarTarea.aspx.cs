
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using DataBaseAccess;

namespace WebApplication.UserPages {

	public partial class InsertarTarea : Page {

		private DataAccessService DataAccess => Master.DataAccess;
		private SqlDataAdapter TaskDataAdapter { get => (SqlDataAdapter)Session["TaskDataAdapter"]; set => Session["TaskDataAdapter"] = value; }

		private DataTable TasksDataTable {
			get {
				return Master.UserDataSet.Tables["Tasks"];
			}
			set {
				value.TableName = "Tasks";
				if(Master.UserDataSet.Tables.Contains(value.TableName)) {
					Master.UserDataSet.Tables.Remove(value.TableName);
				}
				Master.UserDataSet.Tables.Add(value);
			}
		}

		protected void Page_Load(object sender, EventArgs e) {

			if(!Convert.ToBoolean(Session["IsLogged"])) {
				Response.Redirect(AppConfig.WebSite.MainPage);
			}

			if(!IsPostBack) {
				InitTasksDataTable();
			}

		}

		private void InitTasksDataTable() {
			TasksDataTable = new DataTable();
			TaskDataAdapter = DataAccess.CreateDataAdapter(GenericTasksSqlDataSource.SelectCommand);
			TaskDataAdapter.Fill(TasksDataTable);
		}

		protected void AddTaskButton_Click(object sender, EventArgs e) {

			if(TasksDataTable.Select($"Codigo = '{CodeTextBox.Text}'").Length > 0) {
				//ShowError("Duplicated code", "There is already a task with that code");
				return;
			}

			DataRow dataRow = TasksDataTable.NewRow();
			dataRow.SetField("Codigo", CodeTextBox.Text);
			dataRow.SetField("Descripcion", DescriptionTextBox.Text);
			dataRow.SetField("HEstimadas", EstimatedHoursTextBox.Text);
			dataRow.SetField("CodAsig", SubjectsDropDown.Text);
			dataRow.SetField("Explotacion", ActiveCheckBox.Checked);
			dataRow.SetField("TipoTarea", TaskType.Text);

			TasksDataTable.Rows.Add(dataRow);

			TaskDataAdapter.Update(TasksDataTable);
			TasksDataTable.AcceptChanges();
			Return();

		}

		protected void CancelButton_Click(object sender, EventArgs e) {
			Return();
		}

		private void Return() {
			//Response.Redirect("javascript:history.go(-1);");
			Response.RedirectToRoute("TeacherTasks");
		}

	}

}
