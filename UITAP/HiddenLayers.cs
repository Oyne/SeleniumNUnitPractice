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
            var buttonXpath = "//*[@id=\"greenButton\"]";
            IWebElement button = driver.FindElement(By.XPath(buttonXpath));
            button.Click();
            Assert.Throws<ElementClickInterceptedException>(button.Click);
        }
    }
}