using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;

namespace EmailLib {

	public static class ConfigFile {

		//Server.MapPath("~/Config/EmailServerConfig.json")
		public static T ReadJsonConfig<T>(string filePath) {
			return File.Exists(filePath) ? JsonConvert.DeserializeObject<T>(File.ReadAllText(filePath)) : default(T);
		}

		public static void WriteJsonConfig<T>(string filePath, T data) {
			FileInfo file = new FileInfo(filePath);
			file.Directory.Create();
			File.WriteAllText(file.FullName, JsonConvert.SerializeObject(data, Formatting.Indented));
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
		public static String MakeRelativePath(String fromPath, String toPath) {

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
			String relativePath = Uri.UnescapeDataString(relativeUri.ToString());

			if(toUri.Scheme.Equals("file", StringComparison.InvariantCultureIgnoreCase)) {
				relativePath = relativePath.Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar);
			}

			return relativePath;
		}



	}

}
