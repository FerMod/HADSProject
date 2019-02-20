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

		// https://stackoverflow.com/a/1464929/4134376
		public int Insert(string query, IDictionary<string, object> parameters = null) {

			using(SqlConnection connection = new SqlConnection(ConnectionString)) {
				connection.Open();

				using(SqlCommand command = new SqlCommand(query, connection)) {
					if(parameters != null) {
						foreach(var item in parameters) {
							command.Parameters.AddWithValue(item.Key, item.Value);
						}
					}
					return command.ExecuteNonQuery();
				}

			}

		}

		public List<IDataRecord> Query(string query, IDictionary<string, object> parameters = null) {

			using(SqlConnection connection = new SqlConnection(ConnectionString)) {
				connection.Open();

				using(SqlCommand command = new SqlCommand(query, connection)) {
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


	}

}
