using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseAccess.Extensions {

	public static class DataReaderExtension {

		public static IEnumerable<T> Select<T>(this IDataReader reader, Func<IDataReader, T> projection) {
			while(reader.Read()) {
				yield return projection(reader);
			}
		}

		public static IEnumerable<IDataRecord> GetDataRecords(this IDataReader reader) {
			while(reader.Read()) {
				yield return reader;
			}
		}

	}

}
