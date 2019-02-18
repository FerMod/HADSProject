using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseAccess.Extensions;

namespace DataBaseAccess {

	public class DataAccess : IDataAccess {

		public string ConnectionString { get; set; }

		public DataAccess(string connectionString) {
			this.ConnectionString = connectionString;
		}

		public int Insert(string query) {

			using(SqlConnection connection = new SqlConnection(ConnectionString)) {
				connection.Open();

				using(SqlCommand command = new SqlCommand(query, connection)) {
					return command.ExecuteNonQuery();
				}

			}

		}

		public List<IDataRecord> Query<T>(string query) {

			using(SqlConnection connection = new SqlConnection(ConnectionString)) {
				connection.Open();

				using(SqlCommand command = new SqlCommand(query, connection)) {
					IDataReader reader = command.ExecuteReader();
					return reader.GetDataRecords().ToList();
				}

			}

		}


	}

}
