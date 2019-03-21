
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace WebApplication {

	public static class RouteConfig {

		public static void RegisterRoutes(RouteCollection routes) {

			FriendlyUrlSettings settings = new FriendlyUrlSettings {
				AutoRedirectMode = RedirectMode.Permanent
			};
			routes.EnableFriendlyUrls(settings);

			RegisterPagesRoutes(routes);

		}

		private static void RegisterPagesRoutes(RouteCollection routes) {

			/*
			// Example: https://weblogs.asp.net/psheriff/using-friendly-urls-in-web-forms
			routes.MapPageRoute(
				"ProductsByCategoryRoute",
				"Category/{categoryName}",
				"~/ProductList.aspx"
			);
			*/

			routes.MapPageRoute(
				"",
				"Default",
				"~/Default.aspx"
			);

			routes.MapPageRoute(
				"StudentHome",
				"Student/Home",
				"~/UserPages/Student/StudentHome.aspx"
			);

			routes.MapPageRoute(
				"StudentTasks",
				"Student/Tasks",
				"~/UserPages/Student/TareasAlumno.aspx"
			);

			routes.MapPageRoute(
				"StudentTaskInstantiation",
				"Student/Tasks/{code}",
				"~/UserPages/Student/InstanciarTarea.aspx"
			);

			routes.MapPageRoute(
				"TeacherHome",
				"Teacher/Home",
				"~/UserPages/Teacher/TeacherHome.aspx"
			);

			routes.MapPageRoute(
				"TeacherTasks",
				"Teacher/Tasks",
				"~/UserPages/Teacher/TareasProfesor.aspx"
			);

			routes.MapPageRoute(
				"TeacherNewTask",
				"Teacher/Tasks/NewTask",
				"~/UserPages/Teacher/InsertarTarea.aspx"
			);

			routes.MapPageRoute(
				"TeacherImportTasksXmlDocument",
				"Teacher/Tasks/ImportTasksXmlDocument",
				"~/UserPages/Teacher/ImportarTareasXmlDocument.aspx"
			);

			routes.MapPageRoute(
				"TeacherImportTasksDataSet",
				"Teacher/Tasks/ImportTasksDataSet",
				"~/UserPages/Teacher/ImportarTareasDataSet.aspx"
			);

		}

	}

}
