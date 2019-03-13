
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

	public partial class TareasAlumno : Page {

		public DataAccessService DataAccess => Master.DataAccess;
		private DataSet UserDataSet { get => Master.UserDataSet; set => Master.UserDataSet = value; }

		private DataTable CoursesDataTable {
			get {
				return UserDataSet.Tables["Courses"];
			}
			set {
				value.TableName = "Courses";
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
			UpdateDisplayedTasksFilter($"CodAsig = '{DropDownCourses.SelectedValue}'");

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

			string query = "SELECT TG.Codigo, TG.Descripcion, TG.HEstimadas, TG.TipoTarea, TG.CodAsig " +
							"FROM TareasGenericas TG " +
							"JOIN GruposClase GC " +
							"ON GC.codigoasig = TG.CodAsig " +
							"JOIN EstudiantesGrupo EG " +
							"ON EG.Grupo = GC.codigo " +
							"WHERE TG.Explotacion = 1 " +
							"AND EG.Email = @email " +
							"AND NOT EXISTS ( " +
							"  SELECT Email " +
							"  FROM EstudiantesTareas " +
							"  WHERE CodTarea = TG.Codigo " +
							"  AND Email = EG.Email" +
							")";

			Dictionary<string, object> parameters = new Dictionary<string, object> {
				{ "@Email", (string)Session["Email"] }
			};

			return DataAccess.CreateQueryDataTable(query, parameters);
		}

		protected void GridViewTasks_Sorting(object sender, GridViewSortEventArgs e) {

			if(CoursesDataTable != null) {

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

		protected void DropDownCourses_SelectedIndexChanged(object sender, EventArgs e) {
			UpdateDisplayedTasksFilter($"CodAsig = '{DropDownCourses.SelectedValue}'");
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

				ParametizedUrl parametizedUrl = new ParametizedUrl($"{UrlUtils.UrlRoot}{Page.ResolveUrl(@"~/UserPages/InstanciarTarea")}") {
					{"code", taskCode}
				};

				Response.Redirect(parametizedUrl);

			}

		}

	}

}
