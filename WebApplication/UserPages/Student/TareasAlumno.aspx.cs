
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataBaseAccess;
using WebApplication.Framework;

namespace WebApplication.UserPages {

	public partial class TareasAlumno : Page {

		public DataAccessService DataAccess => Master.DataAccess;
		private DataSet UserDataSet { get => Master.UserDataSet; set => Master.UserDataSet = value; }

		private DataTable SubjectsDataTable {
			get {
				return UserDataSet.Tables["Subjects"];
			}
			set {
				value.TableName = "Subjects";
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

			if(!IsPostBack) {

				Master.ShowPage(StudentMenu.Tasks);

				InitDropDownSubjects();
				InitGridViewTasks();

			}

		}

		private void InitDropDownSubjects() {

			SubjectsDataTable = CreateSubjectsDataTable();

			// Specify the data source and field names for the Text 
			// and Value properties of the items (ListItem objects) 
			// in the DropDownList control.
			DropDownSubjects.DataSource = SubjectsDataTable;
			DropDownSubjects.DataTextField = "SubjectCode";
			DropDownSubjects.DataValueField = "SubjectCode";

			// Bind the data to the control
			DropDownSubjects.DataBind();

			// Set the default selected item
			DropDownSubjects.SelectedIndex = 0;

		}

		private void InitGridViewTasks() {

			TasksDataTable = CreateTasksDataTable();
			UpdateDisplayedTasksFilter($"CodAsig = '{DropDownSubjects.SelectedValue}'");

		}

		private DataTable CreateSubjectsDataTable() {

			// Create a table to store data for the DropDownList control
			DataTable dt = new DataTable();

			Dictionary<string, object> parameters = new Dictionary<string, object> {
				{ "@email", (string)Session["Email"] }
			};

			QueryResult queryResult = DataAccess.Query("StudentTasks", parameters, commandType: CommandType.StoredProcedure);

			#region Table columns

			// Define the columns of the table
			dt.Columns.Add(new DataColumn("SubjectCode", typeof(string)));
			dt.Columns.Add(new DataColumn("SubjectName", typeof(string)));

			#endregion

			#region Table rows

			foreach(var row in queryResult.Rows) {

				DataRow dr = dt.NewRow();
				dr.ItemArray = row.Values.ToArray();

				dt.Rows.Add(dr);

			}

			#endregion

			// Create a DataView from the DataTable to act as the data source for the DropDownList control
			return dt;
		}

		private DataTable CreateTasksDataTable() {

			Dictionary<string, object> parameters = new Dictionary<string, object> {
				{ "@email", Convert.ToString(Session["Email"]) }
			};

			return DataAccess.CreateQueryDataTable(Query.StudentSubjectsTasks, parameters);
		}

		protected void GridViewTasks_Sorting(object sender, GridViewSortEventArgs e) {

			if(SubjectsDataTable != null) {

				DataView dataView = TasksDataTable.DefaultView;

				//Sort the data.
				dataView.Sort = $"{e.SortExpression} {GetSortDirection(e.SortExpression)}";
				GridViewTasks.DataSource = dataView;
				GridViewTasks.DataBind();

			}

		}

		private string GetSortDirection(string column) {

			// By default, set the sort direction to ascending.
			bool sortAsc = true;

			// Retrieve the last column that was sorted, and check if the same column is being sorted.
			if((ViewState["SortExpression"] is string sortExpression) && sortExpression == column) {

				// Switch the direction of the sorting
				if((ViewState["SortAsc"] is bool lastDirection) && lastDirection) {
					sortAsc = !sortAsc;
				}

			}

			// Save new values in ViewState.
			ViewState["SortAsc"] = sortAsc;
			ViewState["SortExpression"] = column;

			return sortAsc ? "ASC" : "DESC";
		}

		protected void DropDownSubjects_SelectedIndexChanged(object sender, EventArgs e) {
			UpdateDisplayedTasksFilter($"CodAsig = '{DropDownSubjects.SelectedValue}'");
		}

		private void UpdateDisplayedTasksFilter(string rowFilter) {

			DataView dataView = TasksDataTable.DefaultView;
			dataView.RowStateFilter = DataViewRowState.Unchanged;
			dataView.RowFilter = rowFilter;

			GridViewTasks.DataSource = dataView;
			GridViewTasks.DataBind();

		}

		protected void GridViewTasks_RowCommand(object sender, GridViewCommandEventArgs e) {

			// Check that the command is the correct one
			if(e.CommandName.Equals("Instantiate")) {

				string taskCode = Convert.ToString(e.CommandArgument);

				//ParametizedUrl parametizedUrl = new ParametizedUrl($"{UrlUtils.UrlRoot}{Page.ResolveUrl(@"~/UserPages/InstanciarTarea")}") {
				//	{"code", taskCode}
				//};

				//Response.Redirect(parametizedUrl);

				Response.RedirectToRoute("StudentTaskInstantiation", new { code = taskCode });

			}

		}

	}

}
