
using System;
using System.Web.UI;

namespace WebApplication.UserPages {

	public partial class TareasProfesor : Page {

		protected void Page_Load(object sender, EventArgs e) {

			Master.ShowPage(TeacherMenu.Tasks);

		}

	}

}
