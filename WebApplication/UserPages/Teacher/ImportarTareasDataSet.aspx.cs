
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

	public partial class ImportarTareasDataSet : Page {

		protected void Page_Load(object sender, EventArgs e) {

			if(!IsPostBack) {

				// Change the current selected menu element
				Master.ShowPage(TeacherMenu.ImportTasksDataSet);

			}

		}

	}

}
