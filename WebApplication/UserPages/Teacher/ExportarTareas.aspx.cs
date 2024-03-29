
using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Xml;
using DataBaseAccess;
using Newtonsoft.Json;
using WebApplication.Framework;
using Formatting = Newtonsoft.Json.Formatting;

namespace WebApplication.UserPages {

	public partial class ExportarTareas : Page {

		public DataAccessService DataAccess => Master.DataAccess;
		private DataSet UserDataSet { get => Master.UserDataSet; set => Master.UserDataSet = value; }

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

		protected void Page_Load(object sender, EventArgs e) {

			if(!IsPostBack) {

				Master.ShowPage(TeacherMenu.ExportTasks);
				GenericTasksDataTable = DataAccess.CreateQueryDataTable(Query.GenericTasks.Select);

			}

		}

		protected void ExportTasks_Click(object sender, EventArgs e) {

			try {

				string subject = DropDownSubjects.SelectedValue;

				EnumerableRowCollection<DataRow> rowColection = GenericTasksDataTable.AsEnumerable().Where(r => r.Field<string>("CodAsig") == subject);
				DataTable tasksDataTable = rowColection.Any() ? rowColection.CopyToDataTable() : GenericTasksDataTable.Clone();
				tasksDataTable.Columns.Remove("CodAsig");
				tasksDataTable.TableName = "tarea";
				int rowCount = tasksDataTable.Rows.Count;

				DataSet tasksDataSet = new DataSet("tareas") {
					Locale = CultureInfo.InvariantCulture
				};
				tasksDataSet.Tables.Add(tasksDataTable);

				if(rowCount > 0) {
					foreach(DataColumn column in tasksDataTable.Columns) {
						column.ColumnName = column.ColumnName.ToLower();
						if(column.ColumnName.Equals("codigo", StringComparison.InvariantCultureIgnoreCase)) {
							column.ColumnMapping = MappingType.Attribute;
						}
					}
				}

				StringBuilder sb = new StringBuilder();

				string fileExtension = FileFormatDropDown.SelectedValue.ToLower();
				switch(fileExtension) {
					case "xml":
						Directory.CreateDirectory(AppConfig.Xml.Folder);
						string xmlFilePath = Path.Combine(AppConfig.Xml.Folder, $"{subject}.{fileExtension}");
						if(File.Exists(xmlFilePath)) {
							sb.Append($"Existing XML file overrided.<br />");
						}
						tasksDataSet.WriteXml(xmlFilePath);
						AddXmlNamespaceAttribute(xmlFilePath);
						break;
					case "json":
						Directory.CreateDirectory(AppConfig.Json.Folder);
						string jsonFilePath = Path.Combine(AppConfig.Json.Folder, $"{subject}.{fileExtension}");
						if(File.Exists(jsonFilePath)) {
							sb.Append($"Existing JSON file overrided.<br />");
						}
						File.WriteAllText(jsonFilePath, JsonConvert.SerializeObject(tasksDataTable, Formatting.Indented));
						break;
					default:
						break;
				}

				sb.Append($"Exported {rowCount} rows to file \"<code>{subject}.{fileExtension}</code>\".");

				NotificationData data = new NotificationData {
					Body = sb.ToString(),
					Level = AlertLevel.Info,
					Dismissible = true
				};
				ExportNotification.ShowNotification(data);

			} catch(Exception ex) {

				NotificationData data = new NotificationData {
					Title = "Exception caught<hr>",
					Body = ex.ToString(),
					Level = AlertLevel.Danger,
					Dismissible = true
				};
				ExportNotification.ShowNotification(data);

			}

		}

		protected void GridViewTasks_DataBound(object sender, EventArgs e) {
			// Enable export button only if there are rows
			ExportTasksButton.Enabled = GridViewTasks.Rows.Count > 0;
		}

		private static void AddXmlNamespaceAttribute(string filePath) {

			XmlDocument xmlDoc = new XmlDocument();
			xmlDoc.Load(filePath);
			xmlDoc.DocumentElement.SetAttribute("xmlns:has", "http://ji.ehu.es/has");
			xmlDoc.Save(filePath);

		}

		protected void FileFormatDropDown_Load(object sender, EventArgs e) {
			UpdateFileExtensionLabel(FileFormatDropDown.SelectedValue);
		}

		protected void FileFormatDropDown_SelectedIndexChanged(object sender, EventArgs e) {
			UpdateFileExtensionLabel(FileFormatDropDown.SelectedValue);
		}

		private void UpdateFileExtensionLabel(string fileExtension) {
			FileExtensionLabel.Text = $".{fileExtension.ToLower()}";
		}

	}

}
