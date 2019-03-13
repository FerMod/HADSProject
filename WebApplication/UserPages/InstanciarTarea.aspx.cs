
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

namespace WebApplication.UserPage {

	public partial class InstanciarTarea : Page {

		private DataAccessService DataAccess => Master.DataAccess;
		private DataTable TaskDataTable { get => (DataTable)Session["TaskDataTable"]; set => Session["TaskDataTable"] = value; }
		private SqlDataAdapter TaskDataAdapter { get => (SqlDataAdapter)Session["TaskDataAdapter"]; set => Session["TaskDataAdapter"] = value; }

		protected void Page_Load(object sender, EventArgs e) {

			if(!IsPostBack) {

				string codeParam = Request.QueryString["code"];

				if(String.IsNullOrWhiteSpace(codeParam)) {
					//TODO: Show message
				}

				InitTaskDataTable(codeParam);

				if(TaskDataTable.Rows.Count != 1) {
					//TODO: Show message
				}

				EmailTextBox.Text = (string)Session["Email"];
				CodTareaTextBox.Text = TaskDataTable.Rows[0]["Codigo"].ToString();
				HEstimadasTextBox.Text = TaskDataTable.Rows[0]["HEstimadas"].ToString();

			}

		}

		private void InitTaskDataTable(string taskCode) {

			string query = "SELECT Codigo, HEstimadas " +
							"FROM TareasGenericas TG " +
							"WHERE TG.Explotacion = 1 " +
							"AND TG.Codigo = @Codigo";

			Dictionary<string, object> parameters = new Dictionary<string, object> {
				{ "@Codigo", taskCode }
			};

			//TaskDataTable = DataAccess.CreateQueryDataTable(query, parameters);
			TaskDataAdapter = DataAccess.CreateDataAdapter(query, parameters);

			TaskDataTable = new DataTable();
			TaskDataAdapter.Fill(TaskDataTable);
			
		}

		protected void SaveChangesButton_Click(object sender, EventArgs e) {

			DataRow dataRow = TaskDataTable.NewRow();
			dataRow.SetField("Email", EmailTextBox.Text);
			dataRow.SetField("CodTarea", CodTareaTextBox.Text);
			dataRow.SetField("HEstimadas", HEstimadasTextBox.Text);
			dataRow.SetField("HReales", HRealesTextBox.Text);

			TaskDataTable.Rows.Add(dataRow);

			TaskDataAdapter.Update(TaskDataTable);
			TaskDataTable.AcceptChanges();
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
