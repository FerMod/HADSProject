using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataBaseAccess;
using WebApplication.Framework;

namespace WebApplication {

	public partial class Account : System.Web.UI.MasterPage {

		public DataAccessService DataAccess => (Session["SessionLazyDataAccess"] as Lazy<DataAccessService>)?.Value;

		protected void Page_Load(object sender, EventArgs e) {
		}

	}

}
