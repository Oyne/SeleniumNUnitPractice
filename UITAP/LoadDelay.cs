using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace UITAP
{
    internal class LoadDelay
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
            _driver.Navigate().GoToUrl("http://uitestingplayground.com/");
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Dispose();
        }

        [Test]
        public void LoadDelay_Test()
        {
            var driver = _driver;
            string loadButtonXpath = "//*[@id=\"overview\"]/div/div[1]/div[4]/h3/a";
            IWebElement loadButton = driver.FindElement(By.XPath(loadButtonXpath));
            loadButton.Click();
            string buttonXpath = "//button[contains(@class,\"btn-primary\")]";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement button = wait.Until(driver => driver.FindElement(By.XPath(buttonXpath)));
            button.Click();
            Assert.That(button.Enabled && button.Displayed);
        }
    }
}
