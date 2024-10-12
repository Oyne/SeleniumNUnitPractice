using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
namespace UITAP
{
    public class ClassAttribute
    {
        private IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            ChromeOptions chromeOptions = new ChromeOptions();

            _driver = new ChromeDriver(chromeOptions);
            _driver.Navigate().GoToUrl("http://uitestingplayground.com/classattr");
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Dispose();
        }

        [Test]
        public void ClassAttribute_Test()
        {
            var driver = _driver;
            var buttonXpath = "//button[contains(concat(' ', normalize-space(@class), ' '), ' btn-primary ')]";
            IWebElement button = driver.FindElement(By.XPath(buttonXpath));
            Assert.That(button.Enabled);
            button.Click();
        }
    }
}