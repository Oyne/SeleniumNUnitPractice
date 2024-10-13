using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace UITAP
{
    internal class TextInput
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
            _driver.Navigate().GoToUrl("http://uitestingplayground.com/textinput?");
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Dispose();
        }

        [Test]
        public void TextInput_Test()
        {
            var driver = _driver;
            string inputFieldXpath = "//*[@id=\"newButtonName\"]";
            string buttonXpath = "//*[@id=\"updatingButton\"]";
            IWebElement inputField = driver.FindElement(By.XPath(inputFieldXpath));
            IWebElement button = driver.FindElement(By.XPath(buttonXpath));
            inputField.SendKeys("Test");
            button.Click();
            Assert.That(button.Text == "Test");
        }
    }
}
