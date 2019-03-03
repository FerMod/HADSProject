using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace WebApplication.Framework {

	public class UserCredentials {

		private readonly HttpSessionState session;
		public bool IsLogged { get; set; } = false;

		public UserCredentials(HttpSessionState session) {
			this.session = session;
		}

	}

}
