
using System.Collections.Generic;
using System.Linq;

namespace WebApplication.Framework {

	public class ConnectedUsersTrack {

		public Dictionary<string, List<string>> Users { get; protected set; } = new Dictionary<string, List<string>>();

		public IEnumerable<string> GetUsers(params string[] typeParams) {
			// Get all the users of the passed UsserType 
			IEnumerable<List<string>> connectedUsers = typeParams
				.Where(Users.ContainsKey)
				.Select(x => Users[x]);
			// Flatten the IEnumerable list of string as a one Ienumrable of strings
			return connectedUsers.SelectMany(x => x);
		}

		public void Remove(string type, string value) {
			if(Users.TryGetValue(type, out List<string> usersList) && usersList.Contains(value)) {
				usersList.Remove(value);
			}
		}

		public void Add(string type, string value) {

			if(!Users.TryGetValue(type, out List<string> usersList)) {
				Users[type] = new List<string>();
			}

			if(!Users[type].Contains(value)) {
				Users[type].Add(value);
			}

		}

	}

}
