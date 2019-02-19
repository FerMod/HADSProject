using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataBaseAccess;

namespace WebApplication {

	public partial class Account : System.Web.UI.MasterPage {

		private Lazy<DataAccessService> lazyDataAccess;
		public DataAccessService DataAccess => lazyDataAccess?.Value;

		protected void Page_Load(object sender, EventArgs e) {

			if(lazyDataAccess == null) {
				lazyDataAccess = new Lazy<DataAccessService>(() => {
					DataAccessService daService;
					Application.Lock();
					daService = Application["DataAccess"] as DataAccessService;
					Application.UnLock();
					return daService;
				});

			}

		}

	}

}
