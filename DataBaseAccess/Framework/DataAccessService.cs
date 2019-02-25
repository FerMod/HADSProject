using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseAccess.Extensions;

namespace DataBaseAccess {

	public class DataAccessService : IDataAccessService {

		public string ConnectionString { get; private set; }

		public DataAccessService(string connectionString) {
			this.ConnectionString = connectionString;
		}

		public int Insert(string query, Dictionary<string, object> parameters = null) {
			return Insert(query, CommandType.Text, parameters);
		}

		public int Insert(string query, CommandType commandType = CommandType.Text, Dictionary<string, object> parameters = null) {

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

		public List<IDataRecord> Query(string query, Dictionary<string, object> parameters = null) {
			return Query(query, CommandType.Text, parameters);
		}

		public List<IDataRecord> Query(string query, CommandType commandType = CommandType.Text, Dictionary<string, object> parameters = null) {

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
					return reader.GetDataRecords().ToList();
				}

			}

		}

		public int Update(string query, Dictionary<string, object> parameters = null) {
			return Update(query, CommandType.Text, parameters);
		}

		public int Update(string query, CommandType commandType = CommandType.Text, Dictionary<string, object> parameters = null) {

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

		public T Scalar<T>(string query, Dictionary<string, object> parameters = null) {
			return Scalar<T>(query, CommandType.Text, parameters);
		}

		public T Scalar<T>(string query, CommandType commandType = CommandType.Text, Dictionary<string, object> parameters = null) {

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

	}

}
