
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using DataBaseAccess;
using WebApplication.CustomControls;
using WebApplication.Framework;
using WebApplication.Framework.Extensions;
using WebApplication.Utils;

namespace WebApplication.UserPages {

	public partial class ImportarTareasXmlDocument : Page {

		public DataAccessService DataAccess => Master.DataAccess;
		private DataSet UserDataSet { get => Master.UserDataSet; set => Master.UserDataSet = value; }
		private SqlDataAdapter GenericTaskDataAdapter { get => (SqlDataAdapter)Session["TaskDataAdapter"]; set => Session["TaskDataAdapter"] = value; }

		private DataTable GenericTasksDataTable {
			get {
				return UserDataSet.Tables["TareasGenericas"];
			}
			set {
				value.TableName = "TareasGenericas";
				if(UserDataSet.Tables.Contains(value.TableName)) {
					UserDataSet.Tables.Remove(value.TableName);
				}
				UserDataSet.Tables.Add(value);
			}
		}

		public string XmlDocumentSource {
			get {
				return (ViewState["XmlDocumentSource"] is String str) ? str : String.Empty;
			}
			set {
				ViewState["XmlDocumentSource"] = value;
			}
		}

		protected void Page_Load(object sender, EventArgs e) {

			if(!IsPostBack) {

				// Change the current selected menu element
				Master.ShowPage(TeacherMenu.ImportTasksXmlDocument);

				InitGenericTasksData();
				UpdateXmlData(DropDownSubjects.SelectedValue);

			}

			XmlData.TransformSource = Path.Combine(AppConfig.Xml.Folder, AppConfig.Xml.SubjectsXsltFile);

		}

		protected void DropDownSubjects_DataBound(object sender, EventArgs e) {
			UpdateXmlData(DropDownSubjects.SelectedValue);
		}

		protected void DropDownSubjects_SelectedIndexChanged(object sender, EventArgs e) {
			UpdateXmlData(DropDownSubjects.SelectedValue);
		}

		protected void ImportTasks_Click(object sender, EventArgs e) {

			try {

				StringBuilder sb = new StringBuilder();

				XmlDocument xmlDoc = new XmlDocument();
				xmlDoc.Load(XmlDocumentSource);

				XmlNodeList tasksNodeList = xmlDoc.DocumentElement.ChildNodes;
				foreach(XmlElement taskElement in tasksNodeList) {

					string code = taskElement.Attributes["codigo"].Value;
					DataRow[] resultRows = GenericTasksDataTable.Select($"Codigo = '{code}'");
					bool updateRow = resultRows.Length > 0;

					DataRow dataRow;
					if(updateRow) {
						// Row already exists
						dataRow = resultRows[0];
					} else {
						// Create new row
						dataRow = GenericTasksDataTable.NewRow();
						dataRow["Codigo"] = code;
					}

					dataRow["Descripcion"] = Convert.ToString(taskElement["descripcion"].InnerXml);
					dataRow["CodAsig"] = DropDownSubjects.SelectedValue;
					dataRow["HEstimadas"] = Convert.ToInt32(taskElement["hestimadas"].InnerXml);
					dataRow["Explotacion"] = Convert.ToBoolean(taskElement["explotacion"].InnerXml);
					dataRow["TipoTarea"] = Convert.ToString(taskElement["tipotarea"].InnerXml);

					if(updateRow) {
						sb.AppendFormat("<b>Updated row:</b> \"<code>{0}</code>\"<br />", dataRow["Codigo"]);
					} else {
						GenericTasksDataTable.Rows.Add(dataRow);
						sb.AppendFormat("<b>Inserted row:</b> \"<code>{0}</code>\"<br />", dataRow["Codigo"]);
					}

				}

				GenericTaskDataAdapter.Update(GenericTasksDataTable);
				GenericTasksDataTable.AcceptChanges();

				NotificationData data = new NotificationData {
					Body = sb.ToString(),
					Level = AlertLevel.Info,
					Dismissible = true
				};

				ImportNotification.ShowNotification(data);

			} catch(Exception ex) {

				NotificationData data = new NotificationData {
					Title = "Exception caught<hr>",
					Body = ex.ToString(),
					Level = AlertLevel.Danger,
					Dismissible = true
				};

				ImportNotification.ShowNotification(data);

			}

		}

		private void InitGenericTasksData() {

			GenericTaskDataAdapter = DataAccess.CreateDataAdapter(Query.GenericTasks.Select);
			GenericTasksDataTable = new DataTable();
			GenericTaskDataAdapter.Fill(GenericTasksDataTable);

		}

		private void UpdateXmlData(string subject) {

			XmlDocumentSource = Path.Combine(AppConfig.Xml.Folder, $"{subject}.xml");
			XmlData.DocumentSource = XmlDocumentSource;

			if(!File.Exists(XmlData.DocumentSource)) {

				NotificationData data = new NotificationData {
					Title = "File not found<hr>",
					Body = $"No xml file containing the course tasks was found.<br /> Check that the file '<code>{subject}.xml</code>' exists.",
					Level = AlertLevel.Info,
					Dismissible = true
				};
				ImportNotification.ShowNotification(data);


				XmlData.Visible = false;
				ImportTasksButton.Enabled = false;

			} else {

				XmlData.Visible = true;
				ImportNotification.Visible = false;
				ImportTasksButton.Enabled = true;

			}

		}

	}

}
