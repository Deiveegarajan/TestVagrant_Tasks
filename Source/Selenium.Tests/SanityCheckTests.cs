using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace Selenium.Tests.SmokeTest
{
	[TestClass]
	[TestCategory("SmokeTest")]
	public class SanityCheckTests
	{
		public TestContext TestContext { get; set; }

		[TestMethod]
		public void GoogleForCheese()
		{
			Driver.Run(TestContext, "https://www.google.com", (driver) =>
			{
				var query = driver.FindElement(By.Name("q"));
				query.SendKeys("Cheese");
				query.Submit();
			});
		}
	}
}
