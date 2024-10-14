using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
namespace UITAP
{
    public class HiddenLayers
    {
        private IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--headless=old"); // Run Chrome in headless mode
            //chromeOptions.AddArgument("--no-sandbox"); // Bypass OS security model
            //chromeOptions.AddArgument("--disable-dev-shm-usage"); // Overcome limited resource issue
            _driver = new ChromeDriver(chromeOptions);
            _driver.Navigate().GoToUrl("http://uitestingplayground.com/hiddenlayers");
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Dispose();
        }

        [Test]
        public void HiddenLayers_Test()
        {
            var driver = _driver;
            string buttonId = "greenButton";
            IWebElement button = driver.FindElement(By.Id(buttonId));
            button.Click();
            Assert.Throws<ElementClickInterceptedException>(button.Click);
        }
    }
}