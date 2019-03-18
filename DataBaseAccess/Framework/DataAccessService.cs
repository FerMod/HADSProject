
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using DataBaseAccess.Extensions;

namespace DataBaseAccess {

	public class DataAccessService : IDataAccessService {

		/// <inheritdoc/>
		public string ConnectionString { get; private set; }

		public DataAccessService(string connectionString) {
			this.ConnectionString = connectionString;
		}

		/// <inheritdoc/>
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

		/// <inheritdoc/>
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

		/// <inheritdoc/>
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

		/// <inheritdoc/>
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

		public SqlDataAdapter CreateDataAdapter(string query, Dictionary<string, object> parameters = null, CommandType commandType = CommandType.Text) {

			SqlConnection connection = new SqlConnection(ConnectionString);

			SqlCommand command = new SqlCommand(query, connection) {
				CommandType = commandType
			};

			if(parameters != null) {
				foreach(var item in parameters) {
					command.Parameters.AddWithValue(item.Key, item.Value);
				}
			}


			SqlDataAdapter adapter = new SqlDataAdapter(command);
			SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);

			adapter.UpdateCommand = commandBuilder.GetUpdateCommand();
			adapter.InsertCommand = commandBuilder.GetInsertCommand();
			adapter.DeleteCommand = commandBuilder.GetDeleteCommand();

			return adapter;
		}

	}

}
