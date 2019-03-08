
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataBaseAccess;

namespace WebApplication.UserPage {

	public partial class TareasAlumno : Page {

		private DataAccessService DataAccess => (DataAccessService)Session["DataAccess"];
		private DataView TasksDataView { get; set; }

		protected void Page_Load(object sender, EventArgs e) {

			if(!IsPostBack) {
				InitDropDownCourses();
			}

		}

		private void InitDropDownCourses() {

			TasksDataView = CreateDataSource();

			// Specify the data source and field names for the Text 
			// and Value properties of the items (ListItem objects) 
			// in the DropDownList control.
			DropDownCourses.DataSource = TasksDataView;
			DropDownCourses.DataTextField = "CourseCode";
			DropDownCourses.DataValueField = "CourseCode";

			// Bind the data to the control
			DropDownCourses.DataBind();

			// Set the default selected item
			DropDownCourses.SelectedIndex = 0;

		}

		private DataView CreateDataSource() {

			// Create a table to store data for the DropDownList control
			DataTable dt = new DataTable();

			string query = "SELECT codigo, Nombre FROM Asignaturas";

			QueryResult queryResult = DataAccess.Query(query);

			#region Table columns

			// Define the columns of the table
			dt.Columns.Add(new DataColumn("CourseCode", typeof(string)));
			dt.Columns.Add(new DataColumn("CourseName", typeof(string)));

			#endregion

			#region Table rows

			foreach(var row in queryResult.Rows) {
				dt.Rows.Add(row);
			}

			#endregion

			// Create a DataView from the DataTable to act as the data source for the DropDownList control
			return new DataView(dt);
		}

		protected void GridViewTasks_Sorting(object sender, GridViewSortEventArgs e) {

			if(TasksDataView != null) {

				//Sort the data.
				TasksDataView.Table.DefaultView.Sort = $"{e.SortExpression} {GetSortDirection(e.SortExpression)}";
				GridViewTasks.DataSource = TasksDataView;
				GridViewTasks.DataBind();

			}

		}

		private string GetSortDirection(string column) {

			// By default, set the sort direction to ascending.
			bool sortAsc = true;

			// Retrieve the last column that was sorted, and check if the same column is being sorted.
			if((ViewState["SortExpression"] is string sortExpression) && sortExpression == column) {

				// Invert the direction of the sorting
				if((ViewState["SortAsc"] is bool lastDirection) && sortAsc) {
					sortAsc = !sortAsc;
				}

			}

			// Save new values in ViewState.
			ViewState["SortAsc"] = sortAsc;
			ViewState["SortExpression"] = column;

			return sortAsc ? "ASC" : "DESC";
		}

	}

}
