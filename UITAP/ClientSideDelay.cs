using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace UITAP
{
    internal class ClientSideDelay
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
            _driver.Navigate().GoToUrl("http://uitestingplayground.com/clientdelay");
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Dispose();
        }

        [Test]
        public void ClientSideDelay_Test()
        {
            var driver = _driver;
            string buttonId = "ajaxButton";
            IWebElement button = driver.FindElement(By.Id(buttonId));
            button.Click();
            string labelXPath = "//*[@class=\"bg-success\"]";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            IWebElement label = wait.Until(driver => driver.FindElement(By.XPath(labelXPath)));
            label.Click();
            Assert.That(label.Enabled && label.Displayed);
        }
    }
}
