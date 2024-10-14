using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace UITAP
{
    internal class ProgressBar
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
            _driver.Navigate().GoToUrl("http://uitestingplayground.com/progressbar");
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Dispose();
        }

        [Test]
        public void ProgressBar_Test()
        {
            var driver = _driver;
            string startButtonId = "startButton";
            IWebElement startButton = driver.FindElement(By.Id(startButtonId));

            string stopButtonId = "stopButton";
            IWebElement stopButton = driver.FindElement(By.Id(stopButtonId));

            string progressBarId = "progressBar";
            IWebElement progressBar = driver.FindElement(By.Id(progressBarId));

            startButton.Click();

            while (progressBar.Text != "75%")
            { }

            stopButton.Click();

            string labelId = "result";
            IWebElement label = driver.FindElement(By.Id(labelId));

            string result = label.Text.Split(',')[0];
            Assert.That(result == "Result: 0" && progressBar.Text == "75%");
        }
    }
}
