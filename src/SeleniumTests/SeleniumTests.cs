using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Firefox;


namespace SeleniumTests
{
    [TestClass]
    public class SeleniumTests
    {
        private RemoteWebDriver _driver;
        public TestContext TestContext { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            //var options = new ChromeOptions();
            var options = new FirefoxOptions();
            //var remoteWebDriverUrl = TestContext.Properties["remoteWebDriverUrl"] as string;
            _driver = new RemoteWebDriver(new Uri("http://seleniumhub:4444/wd/hub"), options);
        }

        [TestMethod]
        public void PageLive_Test()
        {
            _driver.Manage().Window.Maximize();
            //_driver.Navigate().GoToUrl("http://agent:5000");
            _driver.Navigate().GoToUrl("http://itsas.pl/devops/");
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            Assert.IsTrue(_driver.PageSource.Contains("The time on the server is "));
        }
    }
}
