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
            string inputFieldId = "newButtonName";
            string buttonId = "updatingButton";
            IWebElement inputField = driver.FindElement(By.Id(inputFieldId));
            IWebElement button = driver.FindElement(By.Id(buttonId));
            inputField.SendKeys("Test");
            button.Click();
            Assert.That(button.Text == "Test");
        }
    }
}
