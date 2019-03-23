
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataBaseAccess;
using WebApplication.Framework;
using WebApplication.Framework.Extensions;
using WebApplication.Utils;

namespace WebApplication.UserPages {

	public partial class ImportarTareasXmlDocument : Page {

		protected void Page_Load(object sender, EventArgs e) {

			Master.ShowPage(TeacherMenu.ImportTasksXmlDocument);
			XmlData.TransformSource = Path.Combine(AppConfig.Xml.Folder, AppConfig.Xml.SubjectsXsltFile);

		}

		private void UpdateXmlData(string subject) {

			XmlData.DocumentSource = Path.Combine(AppConfig.Xml.Folder, $"{subject}.xml");

			if(!File.Exists(XmlData.DocumentSource)) {

				ImportNotification.Title = "File not found";
				ImportNotification.Body = $"No xml file containing the course tasks was found.<br />" +
										$"Check that the file <code>{subject}.xml</code> exists.";
				ImportNotification.Level = AlertLevel.Info;

				XmlData.Visible = false;
				ImportNotification.Visible = true;

			} else {
				XmlData.Visible = true;
				ImportNotification.Visible = false;
			}

		}

		protected void DropDownSubjects_DataBound(object sender, EventArgs e) {
			UpdateXmlData(DropDownSubjects.SelectedValue);
		}

		protected void DropDownSubjects_SelectedIndexChanged(object sender, EventArgs e) {
			UpdateXmlData(DropDownSubjects.SelectedValue);
		}

		protected void ImportTasks_Click(object sender, EventArgs e) {

		}

	}

}
