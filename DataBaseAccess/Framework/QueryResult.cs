
using System.Collections.Generic;

namespace DataBaseAcces {

	public class QueryResult {

		public List<Dictionary<string, object>> Result { get; set; }

		public QueryResult(List<Dictionary<string, object>> result) {
			this.Result = result;
		}

	}

}
