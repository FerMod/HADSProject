
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DataBaseAccess.Extensions {

	public static class DataReaderExtension {

		public static IEnumerable<T> Select<T>(this IDataReader reader, Func<IDataReader, T> projection) {
			while(reader.Read()) {
				yield return projection(reader);
			}
		}

		public static IEnumerable<Dictionary<string, object>> GetDataDictionary(this IDataReader reader) {
			while(reader.Read()) { 
				yield return Enumerable.Range(0, reader.FieldCount).ToDictionary(reader.GetName, reader.GetValue);
			}
		}

		public static IEnumerable<IDataRecord> GetDataRecords(this IDataReader reader) {
			while(reader.Read()) {
				yield return reader;
			}
		}

		// https://stackoverflow.com/a/1464929/4134376
		// public static Customer FromDataReader(IDataReader reader) { ... }

	}

}
