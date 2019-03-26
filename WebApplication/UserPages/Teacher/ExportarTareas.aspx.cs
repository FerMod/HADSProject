
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using DataBaseAccess;
using WebApplication.Framework;
using WebApplication.Framework.Extensions;
using WebApplication.Utils;

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

				StringBuilder sb = new StringBuilder();

				string subject = DropDownSubjects.SelectedValue;

				DataRow[] dataRowsResult = GenericTasksDataTable.Select($"CodAsig = '{subject}'");
				if(dataRowsResult.Length >= 0) {

					string filePath = Path.Combine(AppConfig.Xml.Folder, $"{subject}.xml");
					if(File.Exists(filePath)) {
						sb.Append($"Overriden already existing file \"<code>{subject}.xml</code>\".");
					} else {
						sb.Append($"Data saved in file \"<code>{subject}.xml</code>\".");
					}

					////
					foreach(DataColumn column in GenericTasksDataTable.Columns) {
						column.ColumnName = column.ColumnName.ToLower();
						if(column.ColumnName.Equals("codigo", StringComparison.InvariantCultureIgnoreCase)) {
							column.ColumnMapping = MappingType.Attribute;
						}
					}
					GenericTasksDataTable.WriteXml(filePath);
					////
					
					/*
					// TODO: Generate correctly the xml 
					XmlDocument xmlDoc = new XmlDocument();

					//string localName = subject.ToLower();
					//string namespaceUrl = String.Format("http://ji.ehu.es/{0}", localName);
					//XmlAttribute nsAttribute = xmlDoc.CreateAttribute("xmlns", localName, namespaceUrl);
					//xmlDoc.DocumentElement.Attributes.Append(nsAttribute);

					foreach(DataRow row in dataRowsResult) {
						XmlElement tarea = xmlDoc.CreateElement("tarea");
						//tarea.AppendChild();

						XmlElement element = xmlDoc.CreateElement("descripcion");
						XmlText textElement = xmlDoc.CreateTextNode(Convert.ToString(row["Descripcion"]));
						element.AppendChild(textElement);
						tarea.AppendChild(element);

						xt = xd.CreateTextNode("Chicot, Marcos")
							aut.AppendChild(xt)
							libro.AppendChild(aut)
						XmlT descripcion = xmlDoc.CreateTextNode(descripcion);
						 = Convert.ToString(taskElement["descripcion"].InnerXml);
						row["CodAsig"] = DropDownSubjects.SelectedValue;
						row["HEstimadas"] = Convert.ToInt32(taskElement["hestimadas"].InnerXml);
						row["Explotacion"] = Convert.ToBoolean(taskElement["explotacion"].InnerXml);
						row["TipoTarea"] = Convert.ToString(taskElement["tipotarea"].InnerXml);
						xmlDoc.Attributes.Append(nsAttribute);
						xmlDoc.E
						xmlDoc.CreateElement("tarea");
					}
					*/

				}


				NotificationData data = new NotificationData {
					Body = sb.ToString(),
					Level = AlertLevel.Info,
					Dismissible = true
				};
				ExportNotification.ShowNotification(data);


				//XmlDocument xmlDoc = new XmlDocument();
				//		xmlDoc.Load(XmlDocumentSource);

				//		XmlNodeList tasksNodeList = xmlDoc.DocumentElement.ChildNodes;
				//		foreach(XmlElement taskElement in tasksNodeList) {

				//			string code = taskElement.Attributes["codigo"].Value;
				//			DataRow[] resultRows = GenericTasksDataTable.Select($"Codigo = '{code}'");
				//			bool updateRow = resultRows.Length > 0;

				//			DataRow dataRow;
				//			if(updateRow) {
				//				// Row already exists
				//				dataRow = resultRows[0];
				//			} else {
				//				// Create new row
				//				dataRow = GenericTasksDataTable.NewRow();
				//				dataRow["Codigo"] = code;
				//			}

				//			dataRow["Descripcion"] = Convert.ToString(taskElement["descripcion"].InnerXml);
				//			dataRow["CodAsig"] = DropDownSubjects.SelectedValue;
				//			dataRow["HEstimadas"] = Convert.ToInt32(taskElement["hestimadas"].InnerXml);
				//			dataRow["Explotacion"] = Convert.ToBoolean(taskElement["explotacion"].InnerXml);
				//			dataRow["TipoTarea"] = Convert.ToString(taskElement["tipotarea"].InnerXml);

				//			if(updateRow) {
				//				sb.AppendFormat("<b>Updated row:</b> \"<code>{0}</code>\"<br />", dataRow["Codigo"]);
				//			} else {
				//				GenericTasksDataTable.Rows.Add(dataRow);
				//				sb.AppendFormat("<b>Inserted row:</b> \"<code>{0}</code>\"<br />", dataRow["Codigo"]);
				//			}

				//		}

				//		GenericTaskDataAdapter.Update(GenericTasksDataTable);
				//		GenericTasksDataTable.AcceptChanges();

				//		NotificationData data = new NotificationData {
				//			Body = sb.ToString(),
				//			Level = AlertLevel.Info,
				//			Dismissible = true
				//		};

				//		ImportNotification.ShowNotification(data);

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

	}

}
