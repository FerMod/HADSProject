using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Framework.Extensions {

	public static class DictionaryExtension {

		///
		/// <summary>
		/// Adds the specified <c>NameValueCollection</c> collection to the dictionary.
		/// </summary>
		/// 
		/// <param name="nameValueCollection">
		/// The associated <c>System.String</c> keys and <c>System.String</c> values collection to add to the dictionary.
		/// </param>
		/// 
		/// <exception cref="ArgumentNullException">
		/// Key is null.
		/// </exception>
		/// 
		/// <exception cref="ArgumentException">
		/// An element with the same key already exists in the <c>System.Collections.Generic.Dictionary`2</c>.
		/// </exception>
		/// 
		/// <seealso cref="NameValueCollection"/>
		/// 
		public static void Add(this Dictionary<string, string> dictionary, NameValueCollection nameValueCollection) {
			foreach(var key in nameValueCollection.AllKeys) {
				dictionary.Add(key, nameValueCollection[key]);
			}
		}

	}

}
