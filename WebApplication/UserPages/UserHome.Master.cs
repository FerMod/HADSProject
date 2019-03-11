
using System;
using System.Web.UI;
using DataBaseAccess;
using WebApplication.Framework.Extensions;

namespace WebApplication {

	public partial class UserTasks : MasterPage {

		public DataAccessService DataAccess => (DataAccessService)Session["DataAccess"];

		protected void Page_Load(object sender, EventArgs e) {
		}

	}

}
