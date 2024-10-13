using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace UITAP
{
    internal class Click
    {
        private IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            //chromeOptions.AddArgument("--headless"); // Run Chrome in headless mode
            //chromeOptions.AddArgument("--no-sandbox"); // Bypass OS security model
            //chromeOptions.AddArgument("--disable-dev-shm-usage"); // Overcome limited resource issue
            _driver = new ChromeDriver(chromeOptions);
            _driver.Navigate().GoToUrl("http://uitestingplayground.com/click");
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Dispose();
        }

        [Test]
        public void Click_Test()
        {
            var driver = _driver;
            string buttonId = "badButton";
            IWebElement button = driver.FindElement(By.Id(buttonId));
            button.Click();
            button.Click();
            Assert.That(button.Enabled && button.Displayed);
        }
    }
}
