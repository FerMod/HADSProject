
using System.Collections.Generic;
using System.Data;

namespace DataBaseAccess {

	public interface IDataAccessService {

		string ConnectionString { get; }

		/// <summary>
		/// Executes the passed sql query in the database and returns the number of rows affected.
		/// For UPDATE, INSERT, and DELETE statements, the return value is the number of rows affected by the command.
		/// When a trigger exists on a table being inserted or updated, the return value includes the number of rows affected by both the insert or update operation and the number of rows affected by the trigger or triggers.
		/// For all other types of statements and rollbacks the return value is -1.
		/// </summary>
		/// <param name="query">The sql query to execute</param>
		/// <param name="parameters">The query aditional parameters</param>
		/// <param name="commandType">Indicates how the query string will be interpreted. The default is <see cref="CommandType.Text" /></param>
		/// <returns>The number of rows affected</returns>
		int NonQuery(string query, Dictionary<string, object> parameters = null, CommandType commandType = CommandType.Text);

		/// <summary> 
		/// Executes the passed sql query in the database and returns a <see cref="List{T}" /> of elements of type <see cref="Dictionary{TKey, TValue}" />.
		/// Each element in the list represents a row and each dictionary element represents a column. The column value can be accesed by its same.
		/// </summary>
		/// <param name="query">The sql query to execute</param>
		/// <param name="parameters">The query aditional parameters</param>
		/// <param name="commandType">Indicates how the query string will be interpreted. The default is <see cref="CommandType.Text" /></param>
		/// <returns>A collection of rows returned by the query</returns>
		QueryResult Query(string query, Dictionary<string, object> parameters = null, CommandType commandType = CommandType.Text);

		/// <summary> 
		/// Retrieve a single value from a database.
		/// It returns the first column of the first row in the result set returned by the query, the additional columns or rows are ignored.
		/// </summary>
		/// <typeparam name="T">The expected scalar query type</typeparam>
		/// <param name="query">The sql query to execute</param>
		/// <param name="parameters">The query aditional parameters</param>
		/// <param name="commandType">Indicates how the query string will be interpreted. The default is <see cref="CommandType.Text" /></param>
		/// <returns>The first column of the first row in the result set, or a <see langword="null" /> reference if the result set is empty.</returns>
		T Scalar<T>(string query, Dictionary<string, object> parameters = null, CommandType commandType = CommandType.Text);

		/// <summary>
		/// Creates and returns a <see cref="DataTable"/> with the sql query string passed as parameter.
		/// </summary>
		/// <param name="query">The sql query to execute</param>
		/// <param name="parameters">The query aditional parameters</param>
		/// <param name="commandType">Indicates how the query string will be interpreted. The default is <see cref="CommandType.Text" /></param>
		/// <returns>The created <see cref="DataTable"/></returns>
		DataTable CreateQueryDataTable(string query, Dictionary<string, object> parameters = null, CommandType commandType = CommandType.Text);

	}

}
