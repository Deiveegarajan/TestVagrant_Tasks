using System;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace Selenium.Tests
{
	public static class Driver
	{
		public static void Run(TestContext testContext, string url, Action<RemoteWebDriver> action)
		{
			using(var driver = Get(testContext, url))
			{
				try
				{
					action(driver);
				}
				 catch
				{
					//driver.AddScreenshotToTestContext("SeleniumTest_Screenshot");                    
                    throw;
				}
                finally
                {
                    driver.Manage().Cookies.DeleteAllCookies();
                    driver.Quit();
                }
            }
		}
		
		private static RemoteWebDriver Get(TestContext testContext, string url)
		{
            //var webDriver = GetDriver(testContext, driver, headless);
            RemoteWebDriver webDriver = new ChromeDriver();
            webDriver.Manage().Cookies.DeleteAllCookies();
            webDriver.Navigate().GoToUrl(url);
			

			var window = webDriver.Manage().Window;
			window.Size = new Size(1024, 800);
			window.Position = new Point(0, 0);

            webDriver.Manage().Window.Maximize();
            return webDriver;
		}
	}
}
