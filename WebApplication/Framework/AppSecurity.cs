
using System;
using System.Security.Cryptography;
using System.Text;

namespace WebApplication.Framework {

	public class AppSecurity {

		// https://stackoverflow.com/questions/2138429/hash-and-salt-passwords-in-c-sharp

		public static string ComputeSha256Hash(string data) {

			// Create a hash algorithm instance  
			using(SHA256 sha256 = SHA256.Create()) {

				// ComputeHash, that returns byte array  
				byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(data));
				return ConvertToString(bytes);
			}

		}

		public static string ConvertToString(byte[] bytes) {

			// Convert byte array to a string   
			StringBuilder builder = new StringBuilder();
			for(int i = 0; i < bytes.Length; i++) {
				builder.Append(bytes[i].ToString("x2"));
			}

			return builder.ToString();
		}

	}

}
