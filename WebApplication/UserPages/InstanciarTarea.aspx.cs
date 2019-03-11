
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
				}

				InitTaskDataTable((string)Session["Email"], codeParam);

				EmailTextBox.Text = TaskDataTable.Rows[0]["Email"].ToString();
				CodTareaTextBox.Text = TaskDataTable.Rows[0]["CodTarea"].ToString();
				HEstimadasTextBox.Text = TaskDataTable.Rows[0]["HEstimadas"].ToString();
				HRealesTextBox.Text = TaskDataTable.Rows[0]["HReales"].ToString();

			}

		}

		private void InitTaskDataTable(string email, string taskCode) {

			string query = "SELECT Email, CodTarea, HEstimadas, HReales " +
							"FROM EstudiantesTareas " +
							"WHERE Email = @Email " +
							"AND CodTarea = @CodTarea";

			Dictionary<string, object> parameters = new Dictionary<string, object> {
				{ "@CodTarea", taskCode },
				{ "@Email", email }
			};

			//TaskDataTable = DataAccess.CreateQueryDataTable(query, parameters);
			TaskDataAdapter = DataAccess.CreateDataAdapter(query, parameters);

			TaskDataTable = new DataTable();
			TaskDataAdapter.Fill(TaskDataTable);
			
		}

		protected void SaveChangesButton_Click(object sender, EventArgs e) {

			TaskDataTable.Rows[0]["HReales"] = Convert.ToInt32(HRealesTextBox.Text);

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
