
using System;
using System.Security.Cryptography;
using System.Text;

namespace WebApplication.Framework {

	public class AppSecurity {

		// https://stackoverflow.com/questions/2138429/hash-and-salt-passwords-in-c-sharp

		/// <summary>
		/// <para>
		/// Generate a hash with the given salt.
		/// </para>
		/// <para>
		/// To convert a hash to its string representation <see cref="Convert.ToBase64String(byte[])"/> and <see cref="Convert.FromBase64String(string)"/> to convert it back.
		/// </para>
		/// </summary>
		/// <param name="data">The data to hash</param>
		/// <param name="salt">The salt to apply</param>
		/// <returns>The salted hash byte array</returns>
		public static byte[] GenerateHash(string data, string salt = "") {
			return GenerateSaltedHash(Encoding.UTF8.GetBytes(data), Encoding.UTF8.GetBytes(salt));
		}

		/// <summary>
		/// <para>
		/// Generate a salted hash with the given salt.
		/// </para>
		/// <para>
		/// To convert text to byte arrays can be done using the method <see cref="Encoding.UTF8.GetBytes(string)"/>.
		/// To convert a hash to its string representation <see cref="Convert.ToBase64String(byte[])"/> and <see cref="Convert.FromBase64String(string)"/> to convert it back.
		/// </para>
		/// </summary>
		/// <param name="data">The data to hash in bytes</param>
		/// <param name="salt">The salt to apply in bytes</param>
		/// <returns>The salted hash byte array</returns>
		public static byte[] GenerateSaltedHash(byte[] data, byte[] salt = null) {

			salt = salt ?? new byte[0];

			HashAlgorithm algorithm = new SHA256Managed();

			byte[] dataWithSaltBytes = new byte[data.Length + salt.Length];

			for(int i = 0; i < data.Length; i++) {
				dataWithSaltBytes[i] = data[i];
			}

			for(int i = 0; i < salt.Length; i++) {
				dataWithSaltBytes[data.Length + i] = salt[i];
			}

			return algorithm.ComputeHash(dataWithSaltBytes);
		}

		public static bool CompareByteArrays(byte[] array1, byte[] array2) {

			if(array1.Length != array2.Length) {
				return false;
			}

			for(int i = 0; i < array1.Length; i++) {
				if(array1[i] != array2[i]) {
					return false;
				}
			}

			return true;
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
