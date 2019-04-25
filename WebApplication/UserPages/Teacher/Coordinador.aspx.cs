
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication.TimeMeanWebService;

namespace WebApplication.UserPages {

	public partial class Coordinador : Page {

		/*
		 * Cloud service: 
		 * https://timemeanwebservice.azurewebsites.net/SubjectsMeansService.asmx
		 * 
		 * Local service:
		 * http://localhost:50253/SubjectsMeansService.asmx
		 * 
		 */
		public SubjectsMeansService MeansService { get; set; } = new SubjectsMeansService();

		private DataSet UserDataSet { get => Master.UserDataSet; set => Master.UserDataSet = value; }

		private DataTable TimeMeansDataTable {
			get {
				return UserDataSet.Tables["TimeMeans"];
			}
			set {
				value.TableName = "TimeMeans";
				if(UserDataSet.Tables.Contains(value.TableName)) {
					UserDataSet.Tables.Remove(value.TableName);
				}
				UserDataSet.Tables.Add(value);
			}
		}

		protected void Page_Load(object sender, EventArgs e) {

			if(!IsPostBack) {

				Master.ShowPage(TeacherMenu.TasksMeans);

				InitGridViewTasksMeans();

			}

		}

		private void InitGridViewTasksMeans() {

			TimeMeansDataTable = MeansService.GetAllSubjectsMeans();
			UpdateDisplayedTasksMeansFilter($"CodAsig = '{DropDownSubjects.SelectedValue}'");

		}

		protected void DropDownSubjects_DataBinding(object sender, EventArgs e) {
			UpdateDisplayedTasksMeansFilter($"CodAsig = '{DropDownSubjects.SelectedValue}'");
		}

		protected void DropDownSubjects_SelectedIndexChanged(object sender, EventArgs e) {
			UpdateDisplayedTasksMeansFilter($"CodAsig = '{DropDownSubjects.SelectedValue}'");
		}

		private void UpdateDisplayedTasksMeansFilter(string rowFilter) {

			DataView dataView = TimeMeansDataTable.DefaultView;
			dataView.RowStateFilter = DataViewRowState.Unchanged;
			dataView.RowFilter = rowFilter;

			GridViewTasksMeans.DataSource = dataView;
			GridViewTasksMeans.DataBind();

		}

		protected void GridViewTasks_Sorting(object sender, GridViewSortEventArgs e) {

			if(TimeMeansDataTable != null) {

				DataView dataView = TimeMeansDataTable.DefaultView;
				dataView.Sort = $"{e.SortExpression} {GetSortDirection(e.SortExpression)}";

				GridViewTasksMeans.DataSource = dataView;
				GridViewTasksMeans.DataBind();

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

	}

}
