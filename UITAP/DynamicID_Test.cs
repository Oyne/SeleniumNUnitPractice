using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
namespace UITAP
{
    public class DynamicID
    {
        private IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            ChromeOptions chromeOptions = new ChromeOptions();

            _driver = new ChromeDriver(chromeOptions);
            _driver.Navigate().GoToUrl("http://uitestingplayground.com/dynamicid");
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Dispose();
        }

        [Test]
        public void DynamicID_Test()
        {
            var driver = _driver;
            var buttonXpath = "//button[contains(@class,\"btn-primary\")]";
            IWebElement button = driver.FindElement(By.XPath(buttonXpath));
            button.Click();
            Assert.That(button.Enabled);
        }
    }
}