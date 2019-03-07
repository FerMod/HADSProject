
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;

namespace WebApplication.UserPage {

	public partial class TareasAlumno : Page {

		protected void Page_Load(object sender, EventArgs e) {

			if(!IsPostBack) {
				InitDropDownCourses();
			}
			
		}

		private void InitDropDownCourses() {

			// Specify the data source and field names for the Text 
			// and Value properties of the items (ListItem objects) 
			// in the DropDownList control.
			DropDownCourses.DataSource = CreateDataSource();
			DropDownCourses.DataTextField = "TipoIvaName";
			DropDownCourses.DataValueField = "TipoIvaValue";

		}

		private DataView CreateDataSource() {

			// Create a table to store data for the DropDownList control
			DataTable dt = new DataTable();

			#region Table columns

			// Define the columns of the table
			dt.Columns.Add(new DataColumn("TipoIvaName", typeof(string)));
			dt.Columns.Add(new DataColumn("TipoIvaValue", typeof(string)));

			#endregion

			#region Table rows

			List<string> enumArray = new List<string>() //TODO: Init list
			int size = enumArray.Count;
			for(int i = 0; i < size; i++) {

				TipoIva tipoIva = enumArray[i];

				DataRow dr = dt.NewRow();
				dr[0] = tipoIva.GetName();
				dr[1] = tipoIva;

				dt.Rows.Add(dr);

			}

			#endregion

			// Create a DataView from the DataTable to act as the data source for the DropDownList control
			return new DataView(dt);
		}

	}

}
