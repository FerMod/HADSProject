
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

	public partial class StudentHome : Page {

		protected void Page_Load(object sender, EventArgs e) {

			Master.ShowPage(StudentMenu.Home);

		}

	}

}
