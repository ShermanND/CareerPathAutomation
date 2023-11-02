using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace CareerPathAutomation
{
    [TestFixture]
    public class HomeFooter
	{
        IWebDriver driver;
        HomeFooter_POM homefooterpom;

        static void Main() { }

        [OneTimeSetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            Driver_POM driverpom = new Driver_POM(driver);
            driverpom.DriverSetUp();
            homefooterpom = new HomeFooter_POM(driver);
            Thread.Sleep(3000);
        }

        [Test, Order(1)]
        [Category("Test Case 71: Accessing Home Footer")]
        public void Test0101()
        {
            // Given I have accessed to Parabank website
            // When I navigate to Home screen
            // Then I verify that Home in the Footer is working
            homefooterpom.NavigateToHomeFooter();
            string title = driver.Title;
            Assert.AreEqual(homefooterpom.title, title);
        }


    }
}
