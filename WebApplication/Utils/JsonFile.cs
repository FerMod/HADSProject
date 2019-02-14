using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;

namespace WebApplication.Utils {

	public static class JsonFile {

		public static T Read<T>(string path) {
			return File.Exists(path) ? JsonConvert.DeserializeObject<T>(File.ReadAllText(path)) : default(T);
		}

		public static void Write<T>(string path, T data, Formatting formatting = Formatting.Indented) {
			FileInfo file = new FileInfo(path);
			file.Directory.Create();
			File.WriteAllText(file.FullName, JsonConvert.SerializeObject(data, formatting));
		}

		/// <summary>
		/// Creates a relative path from one file or folder to another.
		/// </summary>
		/// <param name="fromPath">Contains the directory that defines the start of the relative path.</param>
		/// <param name="toPath">Contains the path that defines the endpoint of the relative path.</param>
		/// <returns>The relative path from the start directory to the end path or <c>toPath</c> if the paths are not related.</returns>
		/// <exception cref="ArgumentNullException"></exception>
		/// <exception cref="UriFormatException"></exception>
		/// <exception cref="InvalidOperationException"></exception>
		public static string MakeRelativePath(string fromPath, string toPath) {

			if(String.IsNullOrEmpty(fromPath)) {
				throw new ArgumentNullException("fromPath");
			}

			if(String.IsNullOrEmpty(toPath)) {
				throw new ArgumentNullException("toPath");
			}

			Uri fromUri = new Uri(fromPath);
			Uri toUri = new Uri(toPath);

			// Path can't be made relative.
			if(fromUri.Scheme != toUri.Scheme) {
				return toPath;
			}

			Uri relativeUri = fromUri.MakeRelativeUri(toUri);
			string relativePath = Uri.UnescapeDataString(relativeUri.ToString());

			if(toUri.Scheme.Equals("file", StringComparison.InvariantCultureIgnoreCase)) {
				relativePath = relativePath.Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar);
			}

			return relativePath;
		}



	}

}
