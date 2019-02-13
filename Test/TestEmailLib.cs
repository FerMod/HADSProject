using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using EmailLib;
using NUnit.Framework;

namespace Tests.EmailLib {

	[TestFixture]
	public class TestConfigFile {

		private static double Tolerance => 0.01d;
		private static string ConfigPath => "/Config/EmailServerConfig.json";

		private static IEnumerable<TestCaseData> WriteConfigTestData {
			get {
				yield return new TestCaseData();
			}
		}

		private static IEnumerable<TestCaseData> ReadConfigTestData {
			get {
				yield return new TestCaseData(new SmtpServerConfig() {
					UserName = "Username",
					Password = "password",
					Host = "smtp",
					Port = 25
				});
			}
		}

		[Test, Description("ReadJsonFile Return null"), TestCaseSource(nameof(ReadConfigTestData))]
		public void TestReadJsonFile() {
			string execAbsolutePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
			string configAbsolutePath = execAbsolutePath + ConfigPath;
			SmtpServerConfig config = ConfigFile.ReadJsonConfig<SmtpServerConfig>("NonExistingFile");
			Assert.That(config, Is.Null);
		}

		[Test, Description("ReadJsonFile"), TestCaseSource(nameof(ReadConfigTestData))]
		public void TestReadJsonFile(SmtpServerConfig expected) {

			string execAbsolutePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
			string configAbsolutePath = execAbsolutePath + ConfigPath;

			ConfigFile.WriteJsonConfig(configAbsolutePath, expected);
			SmtpServerConfig config = ConfigFile.ReadJsonConfig<SmtpServerConfig>(ConfigPath);

			Assert.That(config, Is.Not.Null);
		}

		[Test, Description("WriteJsonFile"), TestCaseSource(nameof(WriteConfigTestData))]
		public void TestWriteJsonFile() {
			string execAbsolutePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
			string configAbsolutePath = execAbsolutePath + ConfigPath;
			SmtpServerConfig config = new SmtpServerConfig() {
				UserName = "Username",
				Password = "password",
				Host = "smtp",
				Port = 25
			};
			ConfigFile.WriteJsonConfig(configAbsolutePath, config);
			Assert.That(File.Exists(configAbsolutePath));
		}
	}

}
