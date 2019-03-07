
using System.Collections;
using System.Collections.Generic;

namespace DataBaseAccess {

	public class QueryResult {

		public List<Dictionary<string, object>> Rows { get; private set; }

		public QueryResult(List<Dictionary<string, object>> result) {
			this.Rows = result;
		}

	}

}
