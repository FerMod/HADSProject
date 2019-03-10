
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using DataBaseAccess.Extensions;

namespace DataBaseAccess {

	public class DataAccessService : IDataAccessService {

		public string ConnectionString { get; private set; }

		public DataAccessService(string connectionString) {
			this.ConnectionString = connectionString;
		}

		public int NonQuery(string query, Dictionary<string, object> parameters = null, CommandType commandType = CommandType.Text) {

			using(SqlConnection connection = new SqlConnection(ConnectionString)) {
				connection.Open();

				using(SqlCommand command = new SqlCommand(query, connection)) {
					command.CommandType = commandType;
					if(parameters != null) {
						foreach(var item in parameters) {
							command.Parameters.AddWithValue(item.Key, item.Value);
						}
					}
					return command.ExecuteNonQuery();
				}

			}
		}

		public QueryResult Query(string query, Dictionary<string, object> parameters = null, CommandType commandType = CommandType.Text) {

			using(SqlConnection connection = new SqlConnection(ConnectionString)) {
				connection.Open();

				using(SqlCommand command = new SqlCommand(query, connection)) {
					command.CommandType = commandType;
					if(parameters != null) {
						foreach(var item in parameters) {
							command.Parameters.AddWithValue(item.Key, item.Value);
						}
					}
					IDataReader reader = command.ExecuteReader();
					return new QueryResult(reader.GetDataDictionary().ToList());
				}

			}

		}

		public T Scalar<T>(string query, Dictionary<string, object> parameters = null, CommandType commandType = CommandType.Text) {

			using(SqlConnection connection = new SqlConnection(ConnectionString)) {
				connection.Open();

				using(SqlCommand command = new SqlCommand(query, connection)) {
					command.CommandType = commandType;
					if(parameters != null) {
						foreach(var item in parameters) {
							command.Parameters.AddWithValue(item.Key, item.Value);
						}
					}
					return (T)command.ExecuteScalar();
				}

			}

		}

		public DataTable CreateQueryDataTable(string query, Dictionary<string, object> parameters = null, CommandType commandType = CommandType.Text) {

			using(SqlConnection connection = new SqlConnection(ConnectionString)) {
				connection.Open();

				using(SqlCommand command = new SqlCommand(query, connection)) {

					command.CommandType = commandType;
					if(parameters != null) {
						foreach(var item in parameters) {
							command.Parameters.AddWithValue(item.Key, item.Value);
						}
					}

					DataTable dataTable = new DataTable();
					using(SqlDataAdapter adapter = new SqlDataAdapter(command)) {
						adapter.Fill(dataTable);
					}

					return dataTable;
				}

			}

		}

	}

}
