using OpenQA.Selenium;

namespace CareerPathAutomation.SetUp
{
    public class Driver
    {
        private IWebDriver driver;

        public Driver(IWebDriver driver)
        {
            this.driver = driver;
        }

        // METHODS
        public void DriverSetUp()
        {
            driver.Navigate().GoToUrl("https://para.testar.org/parabank/index.htm");
            driver.Manage().Window.FullScreen();
        }
    }
}