
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataBaseAccess;
using WebApplication.Framework.Extensions;

namespace WebApplication.UserPage {

	public partial class InstanciarTarea : Page {

		protected void Page_Load(object sender, EventArgs e) {

			if(!IsPostBack) {
				Master.SetActiveNav(UserTasks.ActiveNav.InstantiateTask);
			}

		}

	}

}
