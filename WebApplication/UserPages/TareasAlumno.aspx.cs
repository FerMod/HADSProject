
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataBaseAccess;
using WebApplication.Framework;
using WebApplication.Utils;

namespace WebApplication.UserPage {

	public partial class TareasAlumno : Page {

		private DataAccessService DataAccess => (DataAccessService)Session["DataAccess"];
		private DataTable CoursesDataTable { get => (DataTable)Session["CoursesDataTable"]; set => Session["CoursesDataTable"] = value; }
		private DataTable TasksDataTable { get => (DataTable)Session["CoursesDataTable"]; set => Session["CoursesDataTable"] = value; }

		protected void Page_Load(object sender, EventArgs e) {

			if(!IsPostBack) {
#if DEBUG
				Session["Email"] = "pepe@ikasle.ehu.es";
#endif

				InitDropDownCourses();
				InitGridViewTasks();
			}

		}

		private void InitDropDownCourses() {

			CoursesDataTable = CreateCoursesDataTable();

			// Specify the data source and field names for the Text 
			// and Value properties of the items (ListItem objects) 
			// in the DropDownList control.
			DropDownCourses.DataSource = CoursesDataTable;
			DropDownCourses.DataTextField = "CourseCode";
			DropDownCourses.DataValueField = "CourseCode";

			// Bind the data to the control
			DropDownCourses.DataBind();

			// Set the default selected item
			DropDownCourses.SelectedIndex = 0;

		}

		private void InitGridViewTasks() {

			TasksDataTable = CreateTasksDataTable();
			UpdateDisplayedTasks($"CodAsig = '{DropDownCourses.SelectedValue}'");

		}

		private DataTable CreateCoursesDataTable() {

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

				DataRow dr = dt.NewRow();
				dr.ItemArray = row.Values.ToArray();

				dt.Rows.Add(dr);

			}

			#endregion

			// Create a DataView from the DataTable to act as the data source for the DropDownList control
			return dt;
		}

		private DataTable CreateTasksDataTable() {

			string query = "SELECT TareasGenericas.CodAsig, TareasGenericas.Codigo, TareasGenericas.Descripcion, TareasGenericas.HEstimadas, EstudiantesTareas.HReales, TareasGenericas.TipoTarea " +
							"FROM TareasGenericas " +
							"LEFT JOIN EstudiantesTareas " +
							"ON TareasGenericas.Codigo = EstudiantesTareas.CodTarea " +
							"WHERE EstudiantesTareas.Email = @Email " +
							"AND TareasGenericas.Explotacion = 1";

			Dictionary<string, object> parameters = new Dictionary<string, object> {
				{ "@CodAsig", DropDownCourses.SelectedValue },
				{ "@Email", (string)Session["Email"] }
			};

			return DataAccess.CreateQueryDataTable(query, parameters);
		}

		protected void GridViewTasks_Sorting(object sender, GridViewSortEventArgs e) {

			if(CoursesDataTable != null) {

				DataView dataView = CoursesDataTable.DefaultView;

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

		protected void DropDownCourses_SelectedIndexChanged(object sender, EventArgs e) {
			UpdateDisplayedTasks($"CodAsig = '{DropDownCourses.SelectedValue}'");
		}

		private void UpdateDisplayedTasks(string rowFilter) {

			DataView dataView = TasksDataTable.DefaultView;
			dataView.RowStateFilter = DataViewRowState.Unchanged;
			dataView.RowFilter = rowFilter;

			GridViewTasks.DataSource = dataView;
			GridViewTasks.DataBind();

		}

		protected void GridViewTasks_RowCommand(object sender, GridViewCommandEventArgs e) {

			// Check that the command is the correct one
			if(e.CommandName.Equals("Instantiate")) {

				// Obtain the row number
				int rowIndex = Convert.ToInt32(e.CommandArgument);

				// Retrieve the row that contains the button clicked
				GridViewRow row = GridViewTasks.Rows[rowIndex];

				// Obtain the column index by its name
				int columnIndex = GetColumnIndexByName(row, "Codigo");

				if(columnIndex == -1) {
					throw new Exception("Could not find the column index for the given name.");
				}

				ParametizedUrl parametizedUrl = new ParametizedUrl($"{UrlUtils.UrlRoot}{Page.ResolveUrl(@"~/UserPages/InstanciarTarea")}") {
					{"code", row.Cells[columnIndex].Text}
				};

				Response.Redirect(parametizedUrl);

			}

		}

		private int GetColumnIndexByName(GridViewRow row, string columnName) {

			int columnIndex = 0;
			foreach(DataControlFieldCell cell in row.Cells) {
				if((cell.ContainingField is BoundField containingField) && containingField.DataField.Equals(columnName)) {
					return columnIndex;
				}
				columnIndex++;
			}

			return -1;
		}

	}

}
