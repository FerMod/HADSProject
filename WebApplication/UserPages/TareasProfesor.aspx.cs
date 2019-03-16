
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

	public partial class TareasProfesor : Page {

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

			if(!(bool)Session["IsLogged"]) {
				Response.Redirect("~/Default");
			}

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
