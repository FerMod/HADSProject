using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Test {

	[TestFixture]
	public class UnitTest1 {

		private static IEnumerable<TestCaseData> TestData {
			get {
				yield return new TestCaseData(1);
				yield return new TestCaseData(2);
				yield return new TestCaseData(3);
			}
		}

		[Test, Description("Test Method"), TestCaseSource(nameof(TestData))]
		public void TestMethod1() {
		}

	}

}

